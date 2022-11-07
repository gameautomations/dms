import fs from "fs";
import { dm_funcs } from "./dm_funcs";

// language=cpp
const template = (injected: string) => `// clang-format off
#pragma once

#include "dm.h"
#include "str.h"

using namespace std; // NOLINT(clang-diagnostic-header-hygiene)

// ReSharper disable once CppNonInlineFunctionDefinitionInHeaderFile
string dm_call(const vector<std::string> &cmds, Idmsoft *dm) {
  VARIANT x{0};      // NOLINT
  VARIANT y{0};      // NOLINT
  VARIANT x1{0};     // NOLINT
  VARIANT y1{0};     // NOLINT
  VARIANT x2{0};     // NOLINT
  VARIANT y2{0};     // NOLINT
  VARIANT data{0};   // NOLINT
  VARIANT size{0};   // NOLINT
  VARIANT width{0};  // NOLINT
  VARIANT height{0}; // NOLINT

  switch (stoi(cmds[0])) {
  ${injected
      .split("\n")
      .map((v, k) => (k === 0 ? v : `  ${v}`))
      .join("\n")}
  default:
    return "1\\n接口不存在";
  }
}
`;

export default function create_mmf_sever_dispatcher() {
    const injected = dm_funcs
        .map((f, i) => {
            const paramsStr = f.params
                .map((v, i) => {
                    if (v.type === "_bstr_t") {
                        return `utf8_to_bstr(cmds.at(${i + 1}))`;
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
                f.returnType === "_bstr_t" ? `bstr_to_utf8(${ret})` : ret;
            let outPutStr = f.outParams
                .map((v) => `${v.name}.intVal`)
                .join(",");
            if (f.outParams.length > 0) {
                outPutStr = `, ${outPutStr}`;
            }

            let l = "";
            l += `case ${f.hashCode}:\n`;
            l += `  return format("0\\n${placeholders.join(
                `\\n`
            )}", ${retStr}${outPutStr});`;
            return l;
        })
        .join("\n");

    const result = template(injected);
    fs.writeFileSync("lib/dm_dispatcher.cpp", result);
}
