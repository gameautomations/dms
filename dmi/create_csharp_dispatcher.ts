import fs from "fs";
import { dm_funcs } from "./dm_funcs";

// language=cpp
const template = (injected: string) => `#include "dm_dispatcher.h"

string dm_call(string cmd, Idmsoft* dm)
{
	vector<std::string> cmds = split(cmd);

    VARIANT x;
    VARIANT y;
    VARIANT x1;
    VARIANT y1;
    VARIANT x2;
    VARIANT y2;
    VARIANT data;
    VARIANT size;
    VARIANT width;
    VARIANT height;

    switch (stoi(cmds[0]))
    {
    ${injected
        .split("\n")
        .map((v, k) => (k === 0 ? v : `    ${v}`))
        .join("\n")}
    default:
        return "Error";
    }
}
`;

export default function create_mmf_sever_dispatcher() {
    const injected = dm_funcs
        .map((f, i) => {
            const paramsStr = f.params
                .map((v, i) => {
                    if (v.type === "_bstr_t") {
                        return `encodedURIComponentToBstr(cmds.at(${i + 1}))`;
                    }
                    if (v.type === "long") {
                        return `stol(cmds.at(${i + 1}))`;
                    }
                    if (v.type === "__int64") {
                        return `stoll(cmds.at(${i + 1}))`;
                    }
                    if (v.type === "float") {
                        return `stof(cmds.at(${i + 1}))`;
                    }
                    if (v.type === "double") {
                        return `stod(cmds.at(${i + 1}))`;
                    }
                    if (v.type === "VARIANT*") {
                        return `&${v.name}`;
                    }
                })
                .join(", ");

            const placeholders = [...new Array(f.outParams.length + 1)].map(
                (v) => "{}"
            );
            const ret = `dm->${f.funcName}(${paramsStr})`;
            const retStr =
                f.returnType === "_bstr_t" ? `bstrToUtf8(${ret})` : ret;
            let outPutStr = f.outParams
                .map((v) => `${v.name}.intVal`)
                .join(",");
            if (f.outParams.length > 0) {
                outPutStr = `, ${outPutStr}`;
            }
            let l = "";
            l += `case ${f.hashCode}:\n`;
            l += `    return format("${placeholders}", ${retStr}${outPutStr});`;
            return l;
        })
        .join("\n");

    const result = template(injected);
    fs.writeFileSync("lib/dm_dispatcher.cs", result);
}
