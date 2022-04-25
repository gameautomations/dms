#pragma once

#include "framework.h"
#include "dm_task_constants.h"

/* 大漠实例数据中心 */

// 大漠任务类型
enum dm_task_type {
    dm_task_http,
    dm_task_mmf
};

// 大漠实例结构体
struct dm_task {
    int id = 0;
    int hwnd = 0;
    bool busy = false;

    // mmf
    bool running = false;
    bool connected = false;
    bool stopping = false;
    long last_pinged_time = 0;

    // http
    HANDLE http_req_event = nullptr;
    HANDLE http_res_event = nullptr;
    std::string message;
};

// 大漠实例存储中心
dm_task dm_tasks[max_tasks];


/* 大漠实例信息管理中心 */

// 获取可用的实例
inline int dm_tasks_get_ready() {
    for (int i = 0; i < max_tasks; ++i) {
        if (dm_tasks[i].running && !dm_tasks[i].connected) {
            return i;
        }
    }
    return -1;
}

// 获取可用实例位置
inline int dm_tasks_get_position() {
    for (int i = 0; i < max_tasks; ++i) {
        if (!dm_tasks[i].connected && !dm_tasks[i].running) {
            return i;
        }
    }
    return -1;
}

// 获取正在运行的实例数量
inline int dm_tasks_get_running_count() {
    int i = 0;
    // ReSharper disable once CppUseStructuredBinding
    for (const auto& dm_task : dm_tasks) {
        if (dm_task.running) {
            i += 1;
        }
    }
    return i;
}

// 获取已经连接的实例数量
inline int dm_tasks_get_connected_count() {
    int i = 0;
    // ReSharper disable once CppUseStructuredBinding
    for (const auto& dm_task : dm_tasks) {
        if (dm_task.connected) {
            i += 1;
        }
    }
    return i;
}

// 归还一个实例
inline bool dm_tasks_return(int i) {
    if (i >= max_tasks || dm_tasks[i].running == false || dm_tasks[i].connected == false) {
        throw std::runtime_error(std::format("No connected instance of id: {}", i));
    }
    dm_tasks[i].connected = false;
    return true;
}

// 归还所有实例
inline bool dm_tasks_return_all() {
    // ReSharper disable once CppUseStructuredBinding
    for (auto& dm_task : dm_tasks) {
        if (dm_task.connected) {
            dm_task.connected = false;
        }
    }
    return true;
}

// 释放一个实例
inline bool dm_tasks_release(int i) {
    if (i >= max_tasks || dm_tasks[i].running == false) {
        throw std::runtime_error(std::format("No running instance of id: {}", i));
    }
    dm_tasks[i].stopping = true;
    dm_tasks[i].message = "0";
    SetEvent(dm_tasks[i].http_req_event);

    while (dm_tasks[i].stopping == true) {
        if (dm_tasks[i].stopping == false) break;
        std::this_thread::sleep_for(std::chrono::milliseconds(10));
    }
    return true;
}

// 释放所有实例
inline bool dm_tasks_release_all() {
    // ReSharper disable once CppUseStructuredBinding
    for (auto& dm_task : dm_tasks) {
        dm_task.stopping = true;
    }

    while (true) {
        bool done = true;
        // ReSharper disable once CppUseStructuredBinding
        for (const auto& dm_task : dm_tasks) {
            if (dm_task.stopping == true) {
                done = false;
            }
        }
        std::this_thread::sleep_for(std::chrono::milliseconds(10));
        if (done == true) {
            break;
        }
    }
    return true;
}
