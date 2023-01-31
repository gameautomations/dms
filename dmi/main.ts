import { dm_funcs } from "./dm_funcs";
const a1 = {
    hashCode: 413,
    returnType: "_bstr_t",
    funcName: "FindPicSimMemE",
    params: [
        { type: "long", name: "x1" },
        { type: "long", name: "y1" },
        { type: "long", name: "x2" },
        { type: "long", name: "y2" },
        { type: "_bstr_t", name: "pic_info" },
        { type: "_bstr_t", name: "delta_color" },
        { type: "long", name: "sim" },
        { type: "long", name: "dir" },
    ],
    outParams: [],
};

// c语言类型转换为 JS 类型
function cType2CsType(cType: string, name) {
    return {
        __int64: `long.Parse(${name})`,
        long: `int.Parse(${name})`,
        float: `float.Parse(${name})`,
        double: `double.Parse(${name})`,
        _bstr_t: name,
    }[cType];
}

let a = "";

dm_funcs.forEach((v) => {
    let funcStr = "";

    const allParams = [...v.params, ...v.outParams];

    const paramsListStr = allParams
        .map((p, k) => {
            return p.type === "VARIANT*"
                ? `out ${p.name}`
                : cType2CsType(p.type, `inputs[${k + 1}]`);
        })
        .join(",");
    const resultListStr = v.outParams
        .map((p) => {
            return `\\n{${p.name}}`;
        })
        .join("");

    funcStr += `case ${v.hashCode}:`;
    funcStr += `res = dm.${v.funcName}(${paramsListStr});\n`;
    funcStr += `return $"{res}${resultListStr}";`;

    if (v.hashCode === 32 || v.hashCode === 33) {
        a += `
            case ${v.hashCode}:
            refX = int.Parse(inputs[2]);
            refY = int.Parse(inputs[3]);
            res = dm.ClientToScreen(int.Parse(inputs[1]), ref refX, ref refY);
            return $"{res}\\n{refX}\\n{refY}";`;
    } else {
        a += funcStr;
    }
});

import fs from "node:fs";
fs.writeFileSync("a.txt", a);
