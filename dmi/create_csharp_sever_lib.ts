import fs from "fs";
import { dm_funcs as funcs, dm_funcs, func_names } from "./dm_funcs";

function getCSType(type: string) {
    if (type === "_bstr_t") {
        return `string`;
    }
    if (type === "long") {
        return `int`;
    }
    if (type === "__int64") {
        return `long`;
    }
    if (type === "float") {
        return `float`;
    }
    if (type === "double") {
        return `double`;
    }
    if (type === "VARIANT*") {
        return `out int`;
    }
}

// language=CS
const template = (injected: string) => `using System.Runtime.InteropServices;

namespace gadmnet.dm;

public class GaDm
{
    public Idmsoft Dm;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public GaDm()
    {
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CA1416 // Validate platform compatibility
        Dm = Activator.CreateInstance(Type.GetTypeFromProgID("dm.dmsoft")!) as Idmsoft;
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning restore CS8601 // Possible null reference assignment.
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    // 调用此接口进行com对象释放
    private void ReleaseObj()
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (Dm == null)
        {
            return;
        }
#pragma warning disable CA1416 // Validate platform compatibility
        _ = Marshal.ReleaseComObject(Dm);
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Dm = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    ~GaDm()
    {
        ReleaseObj();
    }

    [DllImport("dll/DmReg.dll", CharSet = CharSet.Ansi)]
    private static extern int SetDllPathA(string path, int mode);

    // 免注册调用大漠插件
    public static bool Register()
    {
        var setDllPathResult = SetDllPathA("dll/dm.dll", 1);
        if (setDllPathResult == 0)
        {
            // 加载 dm.dll 失败
            throw new Exception("插件加载失败，程序无法运行");
        }

        return true;
    }

    // 大漠实例方法

        ${injected
            .split("\n")
            .map((v, k) => (k === 0 ? v : `    ${v}`))
            .join("\n")}
}
`;

export default function create_charp_server_lib() {
    const injected = funcs
        .map((f, i) => {
            let paramsStr = f.params
                .map((v, i) => {
                    if (v.type === "_bstr_t") {
                        return `string ${v.name.replace("lock", "locks")}`;
                    }
                    if (v.type === "long") {
                        return `int ${v.name.replace("lock", "locks")}`;
                    }
                    if (v.type === "__int64") {
                        return `long ${v.name.replace("lock", "locks")}`;
                    }
                    if (v.type === "float") {
                        return `float ${v.name.replace("lock", "locks")}`;
                    }
                    if (v.type === "double") {
                        return `double ${v.name.replace("lock", "locks")}`;
                    }
                    if (v.type === "VARIANT*") {
                        return ``;
                    }
                })
                .filter((v) => v !== "")
                .join(", ");
            let paramsStr2 = f.params
                .map((v, i) => {
                    if (v.type === "_bstr_t") {
                        return ` ${v.name.replace("lock", "locks")}`;
                    }
                    if (v.type === "long") {
                        return ` ${v.name.replace("lock", "locks")}`;
                    }
                    if (v.type === "__int64") {
                        return ` ${v.name.replace("lock", "locks")}`;
                    }
                    if (v.type === "float") {
                        return ` ${v.name.replace("lock", "locks")}`;
                    }
                    if (v.type === "double") {
                        return ` ${v.name.replace("lock", "locks")}`;
                    }
                    if (v.type === "VARIANT*") {
                        return `out object ${v.name.replace("lock", "locks")}`;
                    }
                })
                .filter((v) => v !== "")
                .join(", ");

            let retType1 = `${f.returnType
                .replace("_bstr_t", "string")
                .replace("long", "int")
                .replace("__int64", "long")
                .replace("float", "float")
                .replace("double", "double")}`;

            let retType = retType1;

            if (f.outParams.length > 0) {
                retType = `(${retType}, ${f.outParams
                    .map((v) => "int")
                    .join(",")})`;
            }

            let l = "";
            l += `public ${retType} ${f.funcName} (${paramsStr}){\n`;

            l += `var ret = Dm.${f.funcName}(${paramsStr2});\n`;

            if (f.outParams.length > 0) {
                l += `return (ret, ${f.outParams
                    .map((v) => `(int)${v.name}`)
                    .join(",")});\n`;
            } else {
                l += `return ret;\n`;
            }

            l += `}\n`;
            return l;
        })
        .join("\n");

    const result = template(injected);
    fs.writeFileSync("lib/dm.cs", result);
}
