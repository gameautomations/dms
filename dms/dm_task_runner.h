// ReSharper disable CppClangTidyClangDiagnosticInvalidSourceEncoding
#pragma once

#include "framework.h"

#include "str_utils.h"
#include "dm_dispatcher.h"
#include "dm_task_states.h"

/* 大漠实例任务调度 */

// 内存映射通信任务
inline bool run_mmf_task(const int i) {
    if (i >= max_tasks) return false;
    Idmsoft* dm = create_dm();

    if (i == 0) dm->Reg("ysh35dd46fa0a5c6dfa485e5efe738aa2f2e2", "112358");

    const HANDLE& dmmmf = CreateFileMappingA(
        INVALID_HANDLE_VALUE,
        nullptr,
        PAGE_READWRITE,
        0,
        worker_mmf_size,
        std::format("{}{}", worker_mmf_name, i).c_str()
    );

    if (dmmmf == nullptr) {
        return false;
    }

    // 创建 映射文件 及 2 个同步事件
    const LPVOID& dmmmf_view = MapViewOfFile(dmmmf, FILE_MAP_ALL_ACCESS, 0, 0, worker_mmf_size);
    const HANDLE& dmmmf_req_event =
        CreateEventA(nullptr, false, false, std::format("{}{}", worker_event_req_name, i).c_str());
    const HANDLE& dmmmf_res_event =
        CreateEventA(nullptr, false, false, std::format("{}{}", worker_event_res_name, i).c_str());

    if (dmmmf_view == nullptr) return false;

    if (dmmmf_req_event == nullptr) return false;
    if (dmmmf_res_event == nullptr) return false;

    // 初始化此任务状态
    dm_tasks[i].id = i;
    dm_tasks[i].running = true;
    dm_tasks[i].connected = true;
    if (i > 0) dm_tasks[i].connected = true;

    while (!dm_tasks[i].stopping) {
        // 等待调用
        WaitForSingleObject(dmmmf_req_event, INFINITE);

        // 从内存读取调用参数
        const auto req = static_cast<char*>(dmmmf_view);

        // 参数为 `,` 分割的字符串
        std::vector<std::string> cmds = split(std::string(req), ",");
        std::string ret;

        try {
            // 调用大漠返回结果
            ret = dm_call(std::move(cmds), dm);
        }
        catch (exception& e) {
            ret = std::format("{}{}", request_error, e.what());
        }

        // 内存中写入调用结果
        const char* ret_chars = ret.c_str();
        CopyMemory(dmmmf_view, ret_chars, (strlen(ret_chars) * sizeof(char) + 1));

        // 通知调用者调用成功
        SetEvent(dmmmf_res_event);
    }

    // 任务结束 释放资源
    dm_tasks[i].stopping = false;
    dm_tasks[i].connected = false;
    dm_tasks[i].running = false;
    dm->Release();
    if (dmmmf_view) UnmapViewOfFile(dmmmf_view);
    if (dmmmf) CloseHandle(dmmmf);
    if (dmmmf_req_event) CloseHandle(dmmmf_req_event);
    if (dmmmf_res_event) CloseHandle(dmmmf_res_event);
    dm_tasks[i].http_req_event = nullptr;
    dm_tasks[i].http_res_event = nullptr;

    return true;
}

// HTTP 射通信任务
inline bool run_http_task(const int i) {
    if (i >= max_tasks) return false;
    Idmsoft* dm = create_dm();

    if (i == 0) dm->Reg("ysh35dd46fa0a5c6dfa485e5efe738aa2f2e2", "112358");

    // 创建线程同步事件
    dm_tasks[i].http_req_event = CreateEventA(nullptr, false, false, nullptr);

    if (dm_tasks[i].http_req_event == nullptr) return false;

    // 初始化此任务状态
    dm_tasks[i].id = i;
    dm_tasks[i].running = true;
    if (i > 0) dm_tasks[i].connected = true;

    while (!dm_tasks[i].stopping) {
        // 等待调用者
        WaitForSingleObject(dm_tasks[i].http_req_event, INFINITE);

        // TODO 结束任务
        if (dm_tasks[i].stopping) {
            dm_tasks[i].stopping = false;
            break;
        }

        try {
            // 调用大漠 参数为 `,` 分割的字符串
            const std::string ret = dm_call(split(dm_tasks[i].message, ","), dm);
            dm_tasks[i].message = ret;
        }
        catch (const std::exception& e) {
            dm_tasks[i].message = std::format("{}{}", request_error, e.what());
        }

        // 通知调用者调用成功
        SetEvent(dm_tasks[i].http_req_event);
    }

    // 任务结束 释放资源
    dm_tasks[i].stopping = false;
    dm_tasks[i].connected = false;
    dm_tasks[i].running = false;
    dm->Release();
    if (dm_tasks[i].http_req_event) CloseHandle(dm_tasks[i].http_req_event);

    dm_tasks[i].http_req_event = nullptr;

    return true;
}

inline std::string call_http_thread(const int i, std::string cmd) {
    if (i >= max_tasks || dm_tasks[i].running == false || dm_tasks[i].connected == false) {
        // 调用 iD 错误
        throw std::runtime_error(std::format("没有找到 ID 为: {} 的服务", i));
    }
    if (dm_tasks[i].busy == true) {
        throw std::runtime_error("服务占线中");
    }
    dm_tasks[i].busy = true;
    dm_tasks[i].message = std::move(cmd);
    SetEvent(dm_tasks[i].http_req_event);
    WaitForSingleObject(dm_tasks[i].http_req_event, INFINITE);

    dm_tasks[i].busy = false;
    return dm_tasks[i].message;
}
