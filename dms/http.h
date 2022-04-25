// ReSharper disable CppClangTidyBugproneBranchClone
#pragma once

#include <uwebsockets/App.h>
#include <thread>
#include <algorithm>
#include <mutex>
#include <nlohmann/json.hpp>

#include "dm.h"
#include "dm_task_control.h"

inline std::mutex stdout_mutex;

constexpr int port = 14144;

inline void cors(auto* res) {
    res->writeHeader("Access-Control-Allow-Origin", "*");
    res->writeHeader("Access-Control-Allow-Credentials", "true");
    res->writeHeader("Content-Type", "text/json; charset=utf-8");
}

struct ReqData {
    /* Fill with user data */
};

inline int http() {
    // 先初始化一个大漠服务实例
    create_dm_task(dm_task_type::dm_task_http);

    std::vector<std::thread*> threads(std::thread::hardware_concurrency());
    ranges::transform(
        threads.begin(),
        threads.end(),
        threads.begin(),
        [](std::thread*/*t*/) {
            return new std::thread(
                []() {
                    auto app = uWS::App();

                    // 创建大漠服务实例
                    app.get(
                        "/dm/create",
                        [](auto* res, uWS::HttpRequest* req) {
                            cors(res);
                            res->end(std::to_string(create_dm_task(dm_task_type::dm_task_http)));
                        }
                    );

                    // 查看大漠实例详情
                    app.get(
                        "/dm/get/:id",
                        [](auto* res, uWS::HttpRequest* req) {
                            cors(res);
                            try {
                                const int i = std::stoi(string(req->getParameter(0)));
                                res->end(get_dm_task(i));
                            }
                            catch (exception& e) {
                                res->writeStatus("400 Bad Request");
                                res->end(e.what());
                            }
                        }
                    );

                    // 查看所有大漠实例
                    app.get(
                        "/dm/getAll",
                        [](auto* res, uWS::HttpRequest* req) {
                            cors(res);
                            res->end(get_dm_tasks());
                        }
                    );

                    // 归还大漠实例
                    app.get(
                        "/dm/return/:id",
                        [](auto* res, uWS::HttpRequest* req) {
                            cors(res);

                            try {
                                const int i = std::stoi(string(req->getParameter(0)));
                                dm_tasks_return(i);
                                res->end("OK");
                            }
                            catch (exception& e) {
                                res->writeStatus("400 Bad Request");
                                res->end(e.what());
                            }
                        }
                    );

                    // 归还所有大漠实例
                    app.get(
                        "/dm/returnAll",
                        [](auto* res, uWS::HttpRequest* req) {
                            cors(res);
                            dm_tasks_return_all();
                            res->end("OK");
                        }
                    );

                    // 释放大漠实例
                    app.get(
                        "/dm/release/:id",
                        [](auto* res, uWS::HttpRequest* req) {
                            cors(res);

                            try {
                                const int i = std::stoi(string(req->getParameter(0)));
                                dm_tasks_release(i);
                                res->end("OK");
                            }
                            catch (exception& e) {
                                res->writeStatus("400 Bad Request");
                                res->end(std::format("{}{}", request_error, e.what()));
                            }
                        }
                    );

                    // 释放所有大漠实例
                    app.get(
                        "/dm/releaseAll",
                        [](auto* res, uWS::HttpRequest* req) {
                            cors(res);
                            dm_tasks_release_all();
                            res->end("OK");
                        }
                    );

                    // 在指定实例上执行命令
                    app.get(
                        "/dm/c/:id",
                        [](auto* res, uWS::HttpRequest* req) {
                            res->writeHeader("Access-Control-Allow-Origin", "*");
                            res->writeHeader("Access-Control-Allow-Credentials", "true");
                            res->writeHeader("Content-Type", "text/json; charset=utf-8");

                            const int i = std::stoi(string(req->getParameter(0)));

                            try {
                                string ret = call_http_thread(
                                    i, split(std::string(req->getQuery()), "=")[1]);
                                res->end(ret);
                            }
                            catch (exception& e) {
                                res->writeStatus("400 Bad Request");
                                res->end(std::format("{}{}", request_error, e.what()));
                            }
                        }
                    );

                    // websocket服务
                    app.ws<ReqData>("/*",
                        {
                            .open = [](auto* ws)
                            {
                            ws->subscribe("sensors/+/house");
                            },
                            .message = [](auto* ws, std::string_view message, uWS::OpCode opCode)
                            {
                                ws->send(message, opCode);
                            }
                        });

                    // 服务监听到 port 端口
                    app.listen(
                        port,
                        [](const auto* listen_socket) {
                            stdout_mutex.lock();
                            if (listen_socket) {
                                std::cout << std::format("线程 {} 监听到端口 {} 成功\n", 1, port);
                            }
                            else {
                                std::cout << std::format("线程 {} 监听到端口 {} 失败\n", 1, port);
                            }
                            stdout_mutex.unlock();
                        }
                    );

                    app.run();
                }
            );
        }
    );

    ranges::for_each(threads.begin(), threads.end(), [](std::thread* t) { t->join(); });
    return 1;
}
