import { dm_funcs } from "./dm_funcs";

// c语言类型转换为 JS 类型
function cType2JsType(cType: string) {
    return {
        __int64: "number",
        long: "number",
        float: "number",
        double: "number",
        _bstr_t: "string",
    }[cType];
}

// 更具类型获得类型转换函数
function transType(name: string, type: string) {
    const jsType = cType2JsType(type);
    if (jsType === "number") {
        return `Number(${name})`;
    }

    return name;
}

let a = "";

dm_funcs.forEach((v) => {
    let funcStr = "";

    const paramsListStr = v.params
        .map((p) => `${p.name}: ${cType2JsType(p.type)}`)
        .join(",");

    const outParamsListStr = v.outParams.map((p) => "number").join(",");

    if (outParamsListStr.length) {
        funcStr += `async ${
            v.funcName
        }(${paramsListStr}):Promise<[${cType2JsType(
            v.returnType
        )},${outParamsListStr}]>`;
    } else {
        funcStr += `async ${
            v.funcName
        }(${paramsListStr}):Promise<${cType2JsType(v.returnType)}>`;
    }

    const callParamsListStr = v.params.map((p) => p.name).join(",");

    funcStr += `{ const res = await this.exec(${v.hashCode},${callParamsListStr});`;

    if (outParamsListStr.length) {
        const outputStr =
            `${transType("arr[0]", v.returnType)},` +
            v.outParams.map((p, k) => `Number(arr[${k + 1}])`).join(",");
        funcStr += `const arr = res.split('\\n');`;
        funcStr += `return [${outputStr}];}\n`;
    } else {
        funcStr += `return ${transType("res", v.returnType)};}\n`;
    }

    a += funcStr;
});
import fs from "node:fs";
fs.writeFileSync("a.txt", a);
