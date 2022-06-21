#pragma once


#include "dm.h"
#include "dm_dispatcher.h"

#include "framework.h"
#include <exception>
#include "str_utils.h"

namespace Demo {



    string handle_message(std::string message, Idmsoft* dm) {
        std::vector<std::string> cmds = split(message, ",");
        std::string ret;
        try {
            // 调用大漠返回结果
            ret = dm_call(std::move(cmds), dm);
        }
        catch (exception& e) {
            ret = std::format("{}{}", request_error, e.what());
        }

        return ret;

    }

}
