#pragma once

#include "framework.h"
#include <nlohmann/json.hpp>
#include "dm_task_runner.h"

/* 大漠实例控制中心 */

// 创建大漠实例
inline int create_dm_task(dm_task_type task_type) {
    // 查找空闲实例
    int i = dm_tasks_get_ready();

    if (i == -1) {
        // 查找可用索引
        i = dm_tasks_get_position();

        if (i != -1) {
            // 在可用索引上创建大漠服务实例
            std::thread thread(task_type == dm_task_type::dm_task_http ? run_http_task : run_mmf_task, i);
            thread.detach();

            // 等待创建成功 返回创建成功
            while (true) {
                if (i == 0 || dm_tasks[i].connected) break;
                std::this_thread::sleep_for(std::chrono::milliseconds(10));
            }
        }
    }
    else {
        // 更新空闲实例状态
        dm_tasks[i].connected = true;
    }

    return i;
}

// 查看大漠详情
inline std::string get_dm_task(int i) {
    try {
        if (i >= max_tasks) {
            return std::format("{}{}{}", request_error, "实例 ID 最大为", max_tasks - 1);
        }

        nlohmann::json j = {
            {"id", i},
            {"running", dm_tasks[i].running},
            {"connected", dm_tasks[i].connected},
            {"busy", dm_tasks[i].busy},
            {"hwnd", dm_tasks[i].hwnd},
            {"stopping", dm_tasks[i].stopping},
        };
        return j.dump();
    }
    catch (exception& e) {
        return e.what();
    }
}

// 查看所有大漠实例
inline std::string get_dm_tasks() {
    try {
        nlohmann::json tasks;
        for (int i = 0; i < max_tasks; i++) {
            nlohmann::json j = {
                {"id", i},
                {"running", dm_tasks[i].running},
                {"connected", dm_tasks[i].connected},
                {"busy", dm_tasks[i].busy},
                {"hwnd", dm_tasks[i].hwnd},
                {"stopping", dm_tasks[i].stopping},
            };
            tasks.push_back(j);
        }
        return tasks.dump();
    }
    catch (exception& e) {
        return e.what();
    }
}
