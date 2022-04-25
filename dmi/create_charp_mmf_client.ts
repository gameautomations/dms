import fs from "fs";
import { dm_funcs as funcs, dm_funcs, func_names } from "./dm_funcs";

// language=CS
const template = (injected: string) => `
using System.IO.MemoryMappedFiles;
using System.Text;

namespace gacs.Dm;
public class Dmsoft {
    private static readonly int BUFF_SIZE = 1024;
    private readonly int _id = 0;
    private readonly MemoryMappedFile _mmf;
    private readonly MemoryMappedViewAccessor _mmfAccessor;
    private readonly Semaphore _dmmmfReqSignal;
    private readonly Semaphore _dmmmfResSignal;
    private bool ready = true;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    public Dmsoft() {
        _id = DmFactory.Create();
        _mmf = MemoryMappedFile.OpenExisting($"dmmmf_____{_id}");
        _mmfAccessor = _mmf.CreateViewAccessor(0, BUFF_SIZE);
        _dmmmfReqSignal = Semaphore.OpenExisting($"dmmmfReqSignal_____{_id}");
        _dmmmfResSignal = Semaphore.OpenExisting($"dmmmfResSignal_____{_id}");
    }

    ~Dmsoft() {
        _mmfAccessor.Dispose();
        _mmf.Dispose();
        _dmmmfReqSignal.Dispose();
        _dmmmfResSignal.Dispose();
    }

    // getId
    public int GetId() {
        return _id;
    }

    // 发送消息
    public string Call(params object[] list) {
        string cmd = "";
        for (int i = 0; i < list.Length; i++) {
            cmd += list[i] + (i == list.Length - 1 ? "" : ",");
        }

        byte[] reqBuffer = Encoding.UTF8.GetBytes(_id + "," + cmd + '\0');
        _mmfAccessor.WriteArray(0, reqBuffer, 0, reqBuffer.Length);
        _dmmmfReqSignal.Release();
        _dmmmfResSignal.WaitOne();
        byte[] resBuffer = new byte[BUFF_SIZE];
        _mmfAccessor.ReadArray(0, resBuffer, 0, resBuffer.Length);
        string res = Encoding.UTF8.GetString(resBuffer);
        return res.Split("\0")[0];
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
            l += "try {\n";
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
            l += `} catch (Exception e) {}\n`;

            if (f.outParams.length > 0) {
                const parser = `${f.outParams
                    .map((v, k) => `int.Parse(resArray[${k + 1}])`)
                    .join(",")}`;
                l += `string[] resArray = resStr.Split(",");\n`;
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
