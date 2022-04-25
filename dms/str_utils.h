#pragma once

//
inline std::string bstr_to_utf8(const _bstr_t& bstr) {
    const int len = SysStringLen(bstr); // NOLINT
    if (len == 0) return "";
    const int size_needed = WideCharToMultiByte(CP_UTF8, 0, bstr, len, nullptr, 0, nullptr, nullptr);
    std::string ret(size_needed, '\0');
    WideCharToMultiByte(
        CP_UTF8,
        0,
        bstr,
        len,
        ret.data(),
        ret.size(), // NOLINT
        nullptr,
        nullptr
    );

    return ret;
}

//
inline std::wstring utf8_to_utf16(const std::string& str) {
    if (str.empty())
        return {};

    const size_t chars_needed = ::MultiByteToWideChar(
        CP_UTF8, 0,
        str.data(),
        static_cast<int>(str.size()),
        nullptr,
        0
    );
    if (chars_needed == 0)
        throw std::runtime_error("Failed converting UTF-8 string to UTF-16");

    std::vector<wchar_t> buffer(chars_needed);
    const int chars_converted = ::MultiByteToWideChar(
        CP_UTF8, 0,
        str.data(),
        static_cast<int>(str.size()), &buffer[0],
        buffer.size() // NOLINT
    );
    if (chars_converted == 0)
        throw std::runtime_error("Failed converting UTF-8 string to UTF-16");

    return std::wstring(&buffer[0], chars_converted); // NOLINT
}

// split
inline std::vector<std::string> split(std::string input, const std::string& delimiter = ",") {
    std::vector<std::string> cmds;
    size_t pos;
    while ((pos = input.find(delimiter)) != std::string::npos) {
        std::string token = input.substr(0, pos);
        cmds.push_back(token);
        input.erase(0, pos + delimiter.length());
    }

    cmds.push_back(input);
    return cmds;
}

inline unsigned char to_hex(unsigned char x) {
    return x > 9 ? x + 55 : x + 48;
}

inline unsigned char from_hex(unsigned char x) {
    unsigned char y = 0;
    if (x >= 'A' && x <= 'Z') y = x - 'A' + 10;
    else if (x >= 'a' && x <= 'z') y = x - 'a' + 10;
    else if (x >= '0' && x <= '9') y = x - '0';
    else
        assert(0);
    return y;
}

inline std::string url_encode(const std::string& str) {
    std::string str_temp;
    const size_t length = str.length();
    for (size_t i = 0; i < length; i++) {
        if (isalnum(static_cast<unsigned char>(str[i])) ||
            (str[i] == '-') ||
            (str[i] == '_') ||
            (str[i] == '.') ||
            (str[i] == '~'))
            str_temp += str[i];
        else if (str[i] == ' ')
            str_temp += "+";
        else {
            str_temp += '%';
            str_temp += to_hex(static_cast<unsigned char>(str[i]) >> 4); // NOLINT
            str_temp += to_hex(static_cast<unsigned char>(str[i]) % 16); // NOLINT
        }
    }
    return str_temp;
}

inline std::string url_decode(const std::string& str) {
    std::string str_temp;
    const size_t length = str.length();
    for (size_t i = 0; i < length; i++) {
        if (str[i] == '+') str_temp += ' ';
        else if (str[i] == '%') {
            assert(i + 2 < length);
            const unsigned char high = from_hex(static_cast<unsigned char>(str[++i]));
            const unsigned char low = from_hex(static_cast<unsigned char>(str[++i]));
            str_temp += high * 16 + low; // NOLINT
        }
        else str_temp += str[i];
    }
    return str_temp;
}

// 字符串 转 URL Encoded
inline _bstr_t encoded_uri_component_to_bstr(const std::string& encoded) {
    return { utf8_to_utf16(url_decode(encoded)).c_str() };
}
