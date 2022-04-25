// ReSharper disable CppClangTidyClangDiagnosticCastFunctionType
// ReSharper disable CppClangTidyClangDiagnosticLanguageExtensionToken
// ReSharper disable CppClangTidyMiscMisplacedConst
#pragma once

#import "dll/dm.dll" no_namespace

// ReSharper disable once CppNonInlineFunctionDefinitionInHeaderFile
Idmsoft* create_dm() {
    Idmsoft* dm_obj = nullptr;

    // 开始直接加载 大漠 DLL 文件 避免注册到系统
    using pfn_gco = HRESULT(_stdcall*)(REFCLSID, REFIID, void**);
    const auto dm_path = L"dll/dm.dll";
    // 加载 DLL file
    const HINSTANCE hdll_inst = LoadLibrary(dm_path);

    if (hdll_inst == nullptr) {
        // 不能在指定路径找到 DLL 文件 程序不能运行
        return nullptr;
    }

    // 获得大漠 DLL 中的函数
    if (
        const auto fn_gco = reinterpret_cast<pfn_gco>(GetProcAddress(hdll_inst, "DllGetClassObject"));
        fn_gco != nullptr
        ) {
        IClassFactory* class_factory = nullptr;

        if (
            HRESULT h_result = (fn_gco)(__uuidof(dmsoft), IID_IClassFactory, reinterpret_cast<void**>(&class_factory));
            SUCCEEDED(h_result) && (class_factory != nullptr)
            ) {
            // 创建大漠 实例
            h_result = class_factory->CreateInstance(nullptr, __uuidof(Idmsoft), reinterpret_cast<void**>(&dm_obj));

            if ((SUCCEEDED(h_result) && (dm_obj != nullptr)) == FALSE) {
                return nullptr;
            }
        }

        class_factory->Release();
    }

    return dm_obj;
}
