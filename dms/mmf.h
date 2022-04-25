#pragma once

#include "framework.h"

#include "dm.h"
#include "dm_task_control.h"

inline int mmf() {
    const HANDLE& dmmmf = CreateFileMappingA(
        INVALID_HANDLE_VALUE,
        nullptr,
        PAGE_READWRITE,
        0,
        main_mmf_size,
        main_mmf_name
    );

    if (dmmmf == nullptr) {
        return 1;
    }

    const LPVOID& dmmmf_view = MapViewOfFile(dmmmf, FILE_MAP_ALL_ACCESS, 0, 0, main_mmf_size);
    const HANDLE& dmmmf_req_event = CreateEventA(nullptr, false, false, main_event_req_name);
    const HANDLE& dmmmf_res_event = CreateEventA(nullptr, false, false, main_event_res_name);

    if (dmmmf_view == nullptr) return 1;

    if (dmmmf_req_event == nullptr) return 1;
    if (dmmmf_res_event == nullptr) return 1;

    // 预先创建实例 并初始化大漠服务
    create_dm_task(dm_task_type::dm_task_mmf);

    while (true) {
        // 等待请求事件
        WaitForSingleObject(dmmmf_req_event, INFINITE);

        // 从内存中读取请求命令
        const auto req = static_cast<char*>(dmmmf_view);

        std::string reqstr(req);
        std::string delimiter = ",";

        std::vector<std::string> cmds;
        size_t pos;
        std::string token;
        while ((pos = reqstr.find(delimiter)) != std::string::npos) {
            token = reqstr.substr(0, pos);
            cmds.push_back(token);
            reqstr.erase(0, pos + delimiter.length());
        }

        cmds.push_back(reqstr);

        for (std::string& i : cmds) {
            std::cout << i << std::endl;
        }

        if (std::string cmd(cmds[0]); cmd == "Create") {
            std::string temp = std::format("{}", create_dm_task(dm_task_type::dm_task_mmf));
            const char* res = temp.c_str();
            CopyMemory(dmmmf_view, res, (strlen(res) * sizeof(char) + 1));
        }

        else if (cmd == "Return") {
            dm_tasks_return(stoi(cmds[1]));
            const auto res = "true";
            CopyMemory(dmmmf_view, res, (strlen(res) * sizeof(char) + 1));
        }
        else if (cmd == "ReturnAll") {
            dm_tasks_return_all();
            const auto res = "true";
            CopyMemory(dmmmf_view, res, (strlen(res) * sizeof(char) + 1));
        }
        else if (cmd == "Release") {
            dm_tasks_release(stoi(cmds[1]));
            const auto res = "true";
            CopyMemory(dmmmf_view, res, (strlen(res) * sizeof(char) + 1));
        }
        else if (cmd == "ReleaseAll") {
            dm_tasks_release_all();
            const auto res = "true";
            CopyMemory(dmmmf_view, res, (strlen(res) * sizeof(char) + 1));
        }
        else if (cmd == "RunningCount") {
            std::string temp = std::format("{}", dm_tasks_get_running_count());
            const char* res = temp.c_str();
            CopyMemory(dmmmf_view, res, (strlen(res) * sizeof(char) + 1));
        }
        else if (cmd == "ConnectedCount") {
            std::string temp = std::format("{}", dm_tasks_get_connected_count());
            const char* res = temp.c_str();
            CopyMemory(dmmmf_view, res, (strlen(res) * sizeof(char) + 1));
        }
        else {
            // 啥事儿不干
        }

        SetEvent(dmmmf_res_event);
    }

    // if (dmmmf_view) UnmapViewOfFile(dmmmf_view);
    // if (dmmmf) CloseHandle(dmmmf);
    // if (dmmmf_req_signal) CloseHandle(dmmmf_req_signal);
    // if (dmmmf_res_signal) CloseHandle(dmmmf_res_signal);
    //
    // return 1;
}
