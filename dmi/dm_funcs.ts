import fs from "node:fs";
import path from "node:path";
const rawFile = fs
    .readFileSync(path.resolve(__dirname, "../dms/dm.tlh"))
    .toString();

const startIndex = rawFile.indexOf("Wrapper methods for error-handling");
const endIndex = rawFile.indexOf("Raw methods provided by interface");

const funcs = rawFile
    .slice(startIndex, endIndex)
    .replace("Wrapper methods for error-handling", "")
    .replaceAll("//", "")
    .trim()
    .split(";")
    .filter((v) => v.length > 1)
    .map((str, idx) => {
        const func: any = {};
        func.hashCode = idx;
        const split = str.split("(");

        func.returnType = split[0].trim().split(" ")[0];
        func.funcName = split[0].trim().split(" ")[1];
        func.params = [];
        func.outParams = [];

        split[1]
            ?.replace(")", "")
            .split(",")
            .map((v) => v.trim())
            .map((v) => {
                const _split = v
                    .trim()
                    .replace("VARIANT *", "VARIANT*")
                    .split(" ");

                if (_split[0]) {
                    if (_split[0] === "VARIANT*") {
                        func.outParams.push({
                            type: _split[0],
                            name: _split[1],
                        });
                    } else {
                        func.params.push({
                            type: _split[0],
                            name: _split[1],
                        });
                    }
                }
            });

        return func;
    });

export const dm_funcs = funcs;
