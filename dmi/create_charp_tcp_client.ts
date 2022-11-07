import fs from "fs";
import { dm_funcs as funcs, dm_funcs, func_names } from "./dm_funcs";

// language=CS
const template = (injected: string) => `
using System.Net.Sockets;
using System.Text;

namespace gas.GaEngine;
public class Dmsoft {
    private static string host = "localhost";
    private static int port = 13000;
    private TcpClient _client;
    private NetworkStream _stream;

    public Dmsoft()
    {
        _client = new TcpClient(host, port);
        _stream = _client.GetStream();
    }

    ~Dmsoft()
    {
        Release();
    }

    public void Release()
    {
        if (_stream != null) _stream.Close();
        if (_client != null) _client.Close();
    }
    // 发送消息
    public string Call(params object[] list)
    {
        string cmd = "";
        for (int i = 0; i < list.Length; i++)
        {
            cmd += list[i] + (i == list.Length - 1 ? "" : "\\n");
        }

        cmd += "\\0";

        byte[] reqBuffer = Encoding.UTF8.GetBytes(cmd);

        _stream.Write(reqBuffer);

        byte[] resBuffer = new byte[256];
        _stream.Read(resBuffer, 0, resBuffer.Length);
        string res = Encoding.UTF8.GetString(resBuffer).Split("\\0")[0];
        var result = res.Split("\\n");
        var code = result[0];
        if(code == "0")
        {
            return result[1];
        }
        throw new Exception(result[1]);
    }

        ${injected
            .split("\n")
            .map((v, k) => (k === 0 ? v : `    ${v}`))
            .join("\n")}
}

`;

export default function create_charp_mmf_client() {
    const injected = funcs
        .map((f, i) => {
            let paramsStr = f.params
                .map((v, i) => {
                    if (v.type === "_bstr_t") {
                        return `string ${v.name.replace("lock", "_lock")}`;
                    }
                    if (v.type === "long") {
                        return `int ${v.name.replace("lock", "_lock")}`;
                    }
                    if (v.type === "__int64") {
                        return `long ${v.name.replace("lock", "_lock")}`;
                    }
                    if (v.type === "float") {
                        return `float ${v.name.replace("lock", "_lock")}`;
                    }
                    if (v.type === "double") {
                        return `double ${v.name.replace("lock", "_lock")}`;
                    }
                    if (v.type === "VARIANT*") {
                        return ``;
                    }
                })
                .filter((v) => v !== "")
                .join(", ");

            let retType = `${f.returnType
                .replace("_bstr_t", "string")
                .replace("long", "int")
                .replace("__int64", "long")
                .replace("float", "float")
                .replace("double", "double")
                .replace("VARIANT*", "string")}`;
            if (f.outParams.length > 0) {
                retType = `(${retType},${f.outParams
                    .map((v) => "int")
                    .join(",")})`;
            } else {
                retType = `${retType}`;
            }

            let l = "";
            l += `public ${retType} ${f.funcName} (${paramsStr}){\n`;
            l += `${
                f.outParams.length > 0
                    ? "string resStr ="
                    : `return ${f.returnType === "_bstr_t" ? "" : "int.Parse("}`
            } Call(${func_names[f.funcName]}${
                f.params.filter((v) => v.type !== "VARIANT*").length > 0
                    ? ","
                    : ""
            }${f.params
                .filter((v) => v.type !== "VARIANT*")
                .map((v) => v.name.replace("lock", "_lock"))
                .join(", ")})${
                f.returnType !== "_bstr_t" && f.outParams.length === 0
                    ? ")"
                    : ""
            };\n`;

            if (f.outParams.length > 0) {
                const parser = `${f.outParams
                    .map((v, k) => `int.Parse(resArray[${k + 1}])`)
                    .join(",")}`;
                l += `string[] resArray = resStr.Split("\\n");\n`;
                l += `return (${
                    f.returnType === "_bstr_t"
                        ? "resArray[0]"
                        : `int.Parse(resArray[0])`
                },${parser});\n`;
            }
            l += `}\n`;
            return l;
        })
        .join("\n");

    const result = template(injected);
    fs.writeFileSync("lib/Dmsoft.cs", result);
}
