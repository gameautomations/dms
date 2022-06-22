#ifndef WIN32_LEAN_AND_MEAN
#define WIN32_LEAN_AND_MEAN
#endif
#include <windows.h>
#include <WinSock2.h>
#include <WS2tcpip.h>
#include <IPHlpApi.h>
#include <stdio.h>
#include <thread>
#include "tcp_handler.h"

#pragma comment(lib, "Ws2_32.lib")

#define DEFAULT_PORT "13000"
#define DeFAULT_BUFLEN 256

inline void run(SOCKET&& ClientSocket)
{
    int code;
    char data[DeFAULT_BUFLEN];

    Idmsoft* dm = create_dm();

    while (code = recv(ClientSocket, data, DeFAULT_BUFLEN, 0))
    {
        if (code <= 0) break;

        // 调用大漠
        std::string ret = handle_message(std::string(data), dm);

        // 发送结果
        code = send(ClientSocket, ret.c_str(), DeFAULT_BUFLEN, 0);
        if (code == SOCKET_ERROR)
        {
            printf("Socket 发送失败: %d\n", WSAGetLastError());
            break;
        }
    }

    // 断开连接并清理连接
    code = shutdown(ClientSocket, SD_SEND);
    closesocket(ClientSocket);
    dm->Release();
}

inline int tcp()
{
    // 初始化全局 大漠 并注册
    Idmsoft* dm = create_dm();
    dm->Reg("ysh35dd46fa0a5c6dfa485e5efe738aa2f2e2", "112358");

    // 创建 socket 服务器
    WSADATA wsaData;
    int iResult;
    int iSendResult;
    struct addrinfo* result = NULL;
    struct addrinfo hints;
    SOCKET ListenSocket = INVALID_SOCKET;

    iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
    if (iResult != 0)
    {
        printf("WSAStartup 失败: %d\n", iResult);
        return 1;
    }

    ZeroMemory(&hints, sizeof(hints));
    hints.ai_family = AF_INET;
    hints.ai_socktype = SOCK_STREAM;
    hints.ai_protocol = IPPROTO_TCP;
    hints.ai_flags = AI_PASSIVE;

    // 为服务器确定本地地址和端口
    iResult = getaddrinfo(NULL, DEFAULT_PORT, &hints, &result);
    if (iResult != 0)
    {
        printf("获得地址失败: %d\n", iResult);
        WSACleanup();
        return 1;
    }

    ListenSocket = socket(result->ai_family, result->ai_socktype, result->ai_protocol);
    if (ListenSocket == INVALID_SOCKET)
    {
        printf("错误的套接字: %ld\n", WSAGetLastError());
        freeaddrinfo(result);
        WSACleanup();
        return 1;
    }

    iResult = bind(ListenSocket, result->ai_addr, (int)result->ai_addrlen);
    if (iResult == SOCKET_ERROR)
    {
        printf("服务器绑定错误: %d\n", WSAGetLastError());
        freeaddrinfo(result);
        closesocket(ListenSocket);
        WSACleanup();
        return 1;
    }

    freeaddrinfo(result);

    iResult = listen(ListenSocket, SOMAXCONN);
    if (iResult == SOCKET_ERROR)
    {
        printf("服务器监听错误: %d\n", WSAGetLastError());
        closesocket(ListenSocket);
        WSACleanup();
        return 1;
    }

    // 等待客户端连接
    while (true)
    {
        SOCKET ClientSocket = accept(ListenSocket, NULL, NULL);
        if (ClientSocket == INVALID_SOCKET)
        {
            printf("客户端连接失败: %d\n", WSAGetLastError());
            closesocket(ClientSocket);
            break;
        }

        // 处理客户端连接
        std::thread t(run, ClientSocket);
        t.detach();
    }

    // 关闭服务器
    closesocket(ListenSocket);
    WSACleanup();
    return 0;
}
