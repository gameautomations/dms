import fs from "fs";
import path from "path";
import * as console from "console";

// @ts-ignore
String.prototype.hashCode = function () {
    var hash = 0,
        i,
        chr;
    if (this.length === 0) return hash;
    for (i = 0; i < this.length; i++) {
        chr = this.charCodeAt(i);
        hash = (hash << 5) - hash + chr;
        hash |= 0; // Convert to 32bit integer
    }
    return hash;
};

interface Func {
    returnType: string;
    hashCode: number;
    funcName: string;
    params: Array<{ type: string; name: string }>;
    outParams: Array<{ type: string; name: string }>;
}

import { dm_funcs as funcs, func_names } from "../dm_funcs";

const injected = funcs
    .map((f, i) => {
        let paramsStr = f.params
            .map((v, i) => {
                if (v.type === "_bstr_t") {
                    return `${v.name}: string`;
                }
                if (v.type === "long") {
                    return `${v.name}: number`;
                }
                if (v.type === "__int64") {
                    return `${v.name}: number`;
                }
                if (v.type === "float") {
                    return `${v.name}: number`;
                }
                if (v.type === "double") {
                    return `${v.name}: number`;
                }
                if (v.type === "VARIANT*") {
                    return ``;
                }
            })
            .filter((v) => v !== "")
            .join(", ");

        let retType = `${f.returnType
            .replace("_bstr_t", "string")
            .replace("long", "number")
            .replace("__int64", "number")
            .replace("float", "number")
            .replace("double", "number")
            .replace("VARIANT*", "string")}`;
        if (f.outParams.length > 0) {
            retType = `[${retType},${f.outParams
                .map((v) => "number")
                .join(",")}]`;
        } else {
            retType = `${retType}`;
        }

        let l = "";
        l += `async ${f.funcName} (${paramsStr}): Promise<${retType}>{\n`;
        l += `${
            f.outParams.length > 0
                ? "const resStr ="
                : `return ${f.returnType === "_bstr_t" ? "" : "Number("}`
        } await this.exec(${func_names[f.funcName]}${
            f.params.length > 0 ? "," : ""
        }${f.params
            .filter((v) => v.type !== "VARIANT*")
            .map((v) => v.name)
            .join(", ")})${
            f.returnType !== "_bstr_t" && f.outParams.length === 0 ? ")" : ""
        };\n`;

        if (f.outParams.length > 0) {
            const parser = `${f.outParams
                .map((v, k) => `Number(resArray[${k + 1}])`)
                .join(",")}`;
            l += `const resArray = resStr.split(",");\n`;
            l += `return [${
                f.returnType === "_bstr_t"
                    ? "resArray[0]"
                    : `Number(resArray[0])`
            },${parser}];\n`;
        }
        l += `}\n`;
        return l;
    })
    .join("\n");

// language=TypeScript
const cTemp = `
export class dmsoft {
    static API_BASE = "https://localhost:14114";
    static fetch: (url: string) => Promise<string> = (url: string) =>
      fetch(\`$\{dmsoft.API_BASE}/$\{url}\`).then((res) => res.text());
    id: number;

    constructor(id: number) {
      this.id = id;
    }

    async exec(...args: any[]): Promise<string> {
      return await dmsoft.fetch(\`d?i=$\{this.id}&c=$\{args.join(",")}\`);
    }

    ${injected
        .split("\n")
        .map((v, k) => (k === 0 ? v : `    ${v}`))
        .join("\n")}


  }

`;
fs.writeFileSync(path.resolve(__dirname, "aa.ts"), cTemp);
