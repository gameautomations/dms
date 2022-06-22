// ReSharper disable CppClangTidyClangDiagnosticInvalidSourceEncoding
#pragma once

#include "str_utils.h"
#include "dm.h"
#include "dm_task_constants.h"

using namespace std; // NOLINT(clang-diagnostic-header-hygiene)

// ReSharper disable once CppNonInlineFunctionDefinitionInHeaderFile
string dm_call(const vector<std::string>&& cmds, Idmsoft* dm) {
    VARIANT x{ 0 }; // NOLINT
    VARIANT y{ 0 }; // NOLINT
    VARIANT x1{ 0 }; // NOLINT
    VARIANT y1{ 0 }; // NOLINT
    VARIANT x2{ 0 }; // NOLINT
    VARIANT y2{ 0 }; // NOLINT
    VARIANT data{ 0 }; // NOLINT
    VARIANT size{ 0 }; // NOLINT
    VARIANT width{ 0 }; // NOLINT
    VARIANT height{ 0 }; // NOLINT

    switch (stoi(cmds[0])) {
    case 0: // NOLINT(bugprone-branch-clone)
        return format("{}", bstr_to_utf8(dm->Ver()));
    case 1:
        return format("{}", dm->SetPath(encoded_uri_component_to_bstr(cmds.at(1))));
    case 2:
        return format("{}", bstr_to_utf8(dm->Ocr(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)), stod(cmds.at(6)))));
    case 3:
        return format("{},{},{}", dm->FindStr(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)), &x, &y),
            x.intVal, y.intVal);
    case 4:
        return format("{}", dm->GetResultCount(encoded_uri_component_to_bstr(cmds.at(1))));
    case 5:
        return format("{},{},{}", dm->GetResultPos(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2)), &x, &y),
            x.intVal, y.intVal);
    case 6:
        return format("{}", dm->StrStr(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2))));
    case 7:
        return format("{}", dm->SendCommand(encoded_uri_component_to_bstr(cmds.at(1))));
    case 8:
        return format("{}", dm->UseDict(stol(cmds.at(1))));
    case 9:
        return format("{}", bstr_to_utf8(dm->GetBasePath()));
    case 10:
        return format("{}", dm->SetDictPwd(encoded_uri_component_to_bstr(cmds.at(1))));
    case 11:
        return format("{}", bstr_to_utf8(dm->OcrInFile(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)))));
    case 12:
        return format("{}", dm->Capture(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5))));
    case 13:
        return format("{}", dm->KeyPress(stol(cmds.at(1))));
    case 14:
        return format("{}", dm->KeyDown(stol(cmds.at(1))));
    case 15:
        return format("{}", dm->KeyUp(stol(cmds.at(1))));
    case 16:
        return format("{}", dm->LeftClick());
    case 17:
        return format("{}", dm->RightClick());
    case 18:
        return format("{}", dm->MiddleClick());
    case 19:
        return format("{}", dm->LeftDoubleClick());
    case 20:
        return format("{}", dm->LeftDown());
    case 21:
        return format("{}", dm->LeftUp());
    case 22:
        return format("{}", dm->RightDown());
    case 23:
        return format("{}", dm->RightUp());
    case 24:
        return format("{}", dm->MoveTo(stol(cmds.at(1)), stol(cmds.at(2))));
    case 25:
        return format("{}", dm->MoveR(stol(cmds.at(1)), stol(cmds.at(2))));
    case 26:
        return format("{}", bstr_to_utf8(dm->GetColor(stol(cmds.at(1)), stol(cmds.at(2)))));
    case 27:
        return format("{}", bstr_to_utf8(dm->GetColorBGR(stol(cmds.at(1)), stol(cmds.at(2)))));
    case 28:
        return format("{}", bstr_to_utf8(dm->RGB2BGR(encoded_uri_component_to_bstr(cmds.at(1)))));
    case 29:
        return format("{}", bstr_to_utf8(dm->BGR2RGB(encoded_uri_component_to_bstr(cmds.at(1)))));
    case 30:
        return format("{}", dm->UnBindWindow());
    case 31:
        return format("{}", dm->CmpColor(stol(cmds.at(1)), stol(cmds.at(2)), encoded_uri_component_to_bstr(cmds.at(3)),
            stod(cmds.at(4))));
    case 32:
        return format("{},{},{}", dm->ClientToScreen(stol(cmds.at(1)), &x, &y), x.intVal, y.intVal);
    case 33:
        return format("{},{},{}", dm->ScreenToClient(stol(cmds.at(1)), &x, &y), x.intVal, y.intVal);
    case 34:
        return format("{}", dm->ShowScrMsg(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6))));
    case 35:
        return format("{}", dm->SetMinRowGap(stol(cmds.at(1))));
    case 36:
        return format("{}", dm->SetMinColGap(stol(cmds.at(1))));
    case 37:
        return format("{},{},{}", dm->FindColor(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)), stod(cmds.at(6)),
            stol(cmds.at(7)), &x, &y), x.intVal, y.intVal);
    case 38:
        return format("{}", bstr_to_utf8(dm->FindColorEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            stod(cmds.at(6)), stol(cmds.at(7)))));
    case 39:
        return format("{}", dm->SetWordLineHeight(stol(cmds.at(1))));
    case 40:
        return format("{}", dm->SetWordGap(stol(cmds.at(1))));
    case 41:
        return format("{}", dm->SetRowGapNoDict(stol(cmds.at(1))));
    case 42:
        return format("{}", dm->SetColGapNoDict(stol(cmds.at(1))));
    case 43:
        return format("{}", dm->SetWordLineHeightNoDict(stol(cmds.at(1))));
    case 44:
        return format("{}", dm->SetWordGapNoDict(stol(cmds.at(1))));
    case 45:
        return format("{}", dm->GetWordResultCount(encoded_uri_component_to_bstr(cmds.at(1))));
    case 46:
        return format(
            "{},{},{}", dm->GetWordResultPos(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2)), &x, &y),
            x.intVal, y.intVal);
    case 47:
        return format(
            "{}", bstr_to_utf8(dm->GetWordResultStr(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2)))));
    case 48:
        return format("{}", bstr_to_utf8(dm->GetWords(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            stod(cmds.at(6)))));
    case 49:
        return format("{}", bstr_to_utf8(dm->GetWordsNoDict(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)))));
    case 50:
        return format("{}", dm->SetShowErrorMsg(stol(cmds.at(1))));
    case 51:
        return format("{},{},{}", dm->GetClientSize(stol(cmds.at(1)), &width, &height), width.intVal, height.intVal);
    case 52:
        return format("{}", dm->MoveWindow(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3))));
    case 53:
        return format("{}", bstr_to_utf8(dm->GetColorHSV(stol(cmds.at(1)), stol(cmds.at(2)))));
    case 54:
        return format(
            "{}", bstr_to_utf8(dm->GetAveRGB(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)))));
    case 55:
        return format(
            "{}", bstr_to_utf8(dm->GetAveHSV(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)))));
    case 56:
        return format("{}", dm->GetForegroundWindow());
    case 57:
        return format("{}", dm->GetForegroundFocus());
    case 58:
        return format("{}", dm->GetMousePointWindow());
    case 59:
        return format("{}", dm->GetPointWindow(stol(cmds.at(1)), stol(cmds.at(2))));
    case 60:
        return format("{}", bstr_to_utf8(dm->EnumWindow(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)), stol(cmds.at(4)))));
    case 61:
        return format("{}", dm->GetWindowState(stol(cmds.at(1)), stol(cmds.at(2))));
    case 62:
        return format("{}", dm->GetWindow(stol(cmds.at(1)), stol(cmds.at(2))));
    case 63:
        return format("{}", dm->GetSpecialWindow(stol(cmds.at(1))));
    case 64:
        return format("{}", dm->SetWindowText(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 65:
        return format("{}", dm->SetWindowSize(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3))));
    case 66:
        return format("{},{},{},{},{}", dm->GetWindowRect(stol(cmds.at(1)), &x1, &y1, &x2, &y2), x1.intVal, y1.intVal,
            x2.intVal, y2.intVal);
    case 67:
        return format("{}", bstr_to_utf8(dm->GetWindowTitle(stol(cmds.at(1)))));
    case 68:
        return format("{}", bstr_to_utf8(dm->GetWindowClass(stol(cmds.at(1)))));
    case 69:
        return format("{}", dm->SetWindowState(stol(cmds.at(1)), stol(cmds.at(2))));
    case 70:
        return format("{}", dm->CreateFoobarRect(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            stol(cmds.at(5))));
    case 71:
        return format("{}", dm->CreateFoobarRoundRect(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), stol(cmds.at(5)), stol(cmds.at(6)),
            stol(cmds.at(7))));
    case 72:
        return format("{}", dm->CreateFoobarEllipse(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), stol(cmds.at(5))));
    case 73:
        return format("{}", dm->CreateFoobarCustom(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            encoded_uri_component_to_bstr(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)), stod(cmds.at(6))));
    case 74:
        return format("{}", dm->FoobarFillRect(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            stol(cmds.at(5)), encoded_uri_component_to_bstr(cmds.at(6))));
    case 75:
        return format("{}", dm->FoobarDrawText(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            stol(cmds.at(5)), encoded_uri_component_to_bstr(cmds.at(6)),
            encoded_uri_component_to_bstr(cmds.at(7)), stol(cmds.at(8))));
    case 76:
        return format("{}", dm->FoobarDrawPic(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            encoded_uri_component_to_bstr(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5))));
    case 77:
        return format("{}", dm->FoobarUpdate(stol(cmds.at(1))));
    case 78:
        return format("{}", dm->FoobarLock(stol(cmds.at(1))));
    case 79:
        return format("{}", dm->FoobarUnlock(stol(cmds.at(1))));
    case 80:
        return format("{}", dm->FoobarSetFont(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stol(cmds.at(3)), stol(cmds.at(4))));
    case 81:
        return format("{}", dm->FoobarTextRect(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            stol(cmds.at(5))));
    case 82:
        return format("{}", dm->FoobarPrintText(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3))));
    case 83:
        return format("{}", dm->FoobarClearText(stol(cmds.at(1))));
    case 84:
        return format("{}", dm->FoobarTextLineGap(stol(cmds.at(1)), stol(cmds.at(2))));
    case 85:
        return format("{}", dm->Play(encoded_uri_component_to_bstr(cmds.at(1))));
    case 86:
        return format("{}", dm->FaqCapture(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            stol(cmds.at(5)), stol(cmds.at(6)), stol(cmds.at(7))));
    case 87:
        return format("{}", dm->FaqRelease(stol(cmds.at(1))));
    case 88:
        return format("{}", bstr_to_utf8(dm->FaqSend(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2)),
            stol(cmds.at(3)), stol(cmds.at(4)))));
    case 89:
        return format("{}", dm->Beep(stol(cmds.at(1)), stol(cmds.at(2))));
    case 90:
        return format("{}", dm->FoobarClose(stol(cmds.at(1))));
    case 91:
        return format("{}", dm->MoveDD(stol(cmds.at(1)), stol(cmds.at(2))));
    case 92:
        return format("{}", dm->FaqGetSize(stol(cmds.at(1))));
    case 93:
        return format("{}", dm->LoadPic(encoded_uri_component_to_bstr(cmds.at(1))));
    case 94:
        return format("{}", dm->FreePic(encoded_uri_component_to_bstr(cmds.at(1))));
    case 95:
        return format("{}", dm->GetScreenData(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4))));
    case 96:
        return format("{}", dm->FreeScreenData(stol(cmds.at(1))));
    case 97:
        return format("{}", dm->WheelUp());
    case 98:
        return format("{}", dm->WheelDown());
    case 99:
        return format("{}", dm->SetMouseDelay(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2))));
    case 100:
        return format("{}", dm->SetKeypadDelay(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2))));
    case 101:
        return format("{}", bstr_to_utf8(dm->GetEnv(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)))));
    case 102:
        return format("{}", dm->SetEnv(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3))));
    case 103:
        return format("{}", dm->SendString(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 104:
        return format("{}", dm->DelEnv(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 105:
        return format("{}", bstr_to_utf8(dm->GetPath()));
    case 106:
        return format("{}", dm->SetDict(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 107:
        return format("{},{},{}", dm->FindPic(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)),
            stol(cmds.at(8)), &x, &y), x.intVal, y.intVal);
    case 108:
        return format("{}", bstr_to_utf8(dm->FindPicEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)),
            stol(cmds.at(8)))));
    case 109:
        return format("{}", dm->SetClientSize(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3))));
    case 110:
        return format("{}", dm->ReadInt(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)), stol(cmds.at(3))));
    case 111:
        return format("{}", dm->ReadFloat(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 112:
        return format("{}", dm->ReadDouble(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 113:
        return format("{}", bstr_to_utf8(dm->FindInt(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stoll(cmds.at(3)), stoll(cmds.at(4)), stol(cmds.at(5)))));
    case 114:
        return format("{}", bstr_to_utf8(dm->FindFloat(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stof(cmds.at(3)), stof(cmds.at(4)))));
    case 115:
        return format("{}", bstr_to_utf8(dm->FindDouble(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stod(cmds.at(3)), stod(cmds.at(4)))));
    case 116:
        return format("{}", bstr_to_utf8(dm->FindString(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)), stol(cmds.at(4)))));
    case 117:
        return format("{}", dm->GetModuleBaseAddr(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 118:
        return format(
            "{}", bstr_to_utf8(dm->MoveToEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)))));
    case 119:
        return format("{}", bstr_to_utf8(dm->MatchPicName(encoded_uri_component_to_bstr(cmds.at(1)))));
    case 120:
        return format("{}", dm->AddDict(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 121:
        return format("{}", dm->EnterCri());
    case 122:
        return format("{}", dm->LeaveCri());
    case 123:
        return format("{}", dm->WriteInt(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)), stol(cmds.at(3)),
            stoll(cmds.at(4))));
    case 124:
        return format("{}", dm->WriteFloat(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stof(cmds.at(3))));
    case 125:
        return format("{}", dm->WriteDouble(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stod(cmds.at(3))));
    case 126:
        return format("{}", dm->WriteString(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stol(cmds.at(3)), encoded_uri_component_to_bstr(cmds.at(4))));
    case 127:
        return format("{}", dm->AsmAdd(encoded_uri_component_to_bstr(cmds.at(1))));
    case 128:
        return format("{}", dm->AsmClear());
    case 129:
        return format("{}", dm->AsmCall(stol(cmds.at(1)), stol(cmds.at(2))));
    case 130:
        return format("{},{},{}", dm->FindMultiColor(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)),
            stol(cmds.at(8)), &x, &y), x.intVal, y.intVal);
    case 131:
        return format("{}", bstr_to_utf8(dm->FindMultiColorEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)),
            stod(cmds.at(7)), stol(cmds.at(8)))));
    case 132:
        return format("{}", bstr_to_utf8(dm->Assemble(stoll(cmds.at(1)), stol(cmds.at(2)))));
    case 133:
        return format("{}", bstr_to_utf8(dm->DisAssemble(encoded_uri_component_to_bstr(cmds.at(1)), stoll(cmds.at(2)),
            stol(cmds.at(3)))));
    case 134:
        return format("{}", dm->SetWindowTransparent(stol(cmds.at(1)), stol(cmds.at(2))));
    case 135:
        return format("{}", bstr_to_utf8(dm->ReadData(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stol(cmds.at(3)))));
    case 136:
        return format("{}", dm->WriteData(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3))));
    case 137:
        return format("{}", bstr_to_utf8(dm->FindData(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)))));
    case 138:
        return format("{}", dm->SetPicPwd(encoded_uri_component_to_bstr(cmds.at(1))));
    case 139:
        return format("{}", dm->Log(encoded_uri_component_to_bstr(cmds.at(1))));
    case 140:
        return format("{}", bstr_to_utf8(dm->FindStrE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)))));
    case 141:
        return format("{}", bstr_to_utf8(dm->FindColorE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            stod(cmds.at(6)), stol(cmds.at(7)))));
    case 142:
        return format("{}", bstr_to_utf8(dm->FindPicE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)),
            stol(cmds.at(8)))));
    case 143:
        return format("{}", bstr_to_utf8(dm->FindMultiColorE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)),
            stod(cmds.at(7)), stol(cmds.at(8)))));
    case 144:
        return format("{}", dm->SetExactOcr(stol(cmds.at(1))));
    case 145:
        return format("{}", bstr_to_utf8(dm->ReadString(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stol(cmds.at(3)), stol(cmds.at(4)))));
    case 146:
        return format("{}", dm->FoobarTextPrintDir(stol(cmds.at(1)), stol(cmds.at(2))));
    case 147:
        return format("{}", bstr_to_utf8(dm->OcrEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            stod(cmds.at(6)))));
    case 148:
        return format("{}", dm->SetDisplayInput(encoded_uri_component_to_bstr(cmds.at(1))));
    case 149:
        return format("{}", dm->GetTime());
    case 150:
        return format("{}", dm->GetScreenWidth());
    case 151:
        return format("{}", dm->GetScreenHeight());
    case 152:
        return format("{}", dm->BindWindowEx(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)),
            encoded_uri_component_to_bstr(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)), stol(cmds.at(6))));
    case 153:
        return format("{}", bstr_to_utf8(dm->GetDiskSerial(stol(cmds.at(1)))));
    case 154:
        return format("{}", bstr_to_utf8(dm->Md5(encoded_uri_component_to_bstr(cmds.at(1)))));
    case 155:
        return format("{}", bstr_to_utf8(dm->GetMac()));
    case 156:
        return format("{}", dm->ActiveInputMethod(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 157:
        return format("{}", dm->CheckInputMethod(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 158:
        return format("{}", dm->FindInputMethod(encoded_uri_component_to_bstr(cmds.at(1))));
    case 159:
        return format("{},{},{}", dm->GetCursorPos(&x, &y), x.intVal, y.intVal);
    case 160:
        return format("{}", dm->BindWindow(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)),
            encoded_uri_component_to_bstr(cmds.at(4)), stol(cmds.at(5))));
    case 161:
        return format("{}", dm->FindWindow(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2))));
    case 162:
        return format("{}", dm->GetScreenDepth());
    case 163:
        return format("{}", dm->SetScreen(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3))));
    case 164:
        return format("{}", dm->ExitOs(stol(cmds.at(1))));
    case 165:
        return format("{}", bstr_to_utf8(dm->GetDir(stol(cmds.at(1)))));
    case 166:
        return format("{}", dm->GetOsType());
    case 167:
        return format("{}", dm->FindWindowEx(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3))));
    case 168:
        return format("{}", dm->SetExportDict(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 169:
        return format("{}", bstr_to_utf8(dm->GetCursorShape()));
    case 170:
        return format("{}", dm->DownCpu(stol(cmds.at(1)), stol(cmds.at(2))));
    case 171:
        return format("{}", bstr_to_utf8(dm->GetCursorSpot()));
    case 172:
        return format("{}", dm->SendString2(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 173:
        return format("{}", dm->FaqPost(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4))));
    case 174:
        return format("{}", bstr_to_utf8(dm->FaqFetch()));
    case 175:
        return format("{}", bstr_to_utf8(dm->FetchWord(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)))));
    case 176:
        return format("{}", dm->CaptureJpg(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)), stol(cmds.at(6))));
    case 177:
        return format("{},{},{}", dm->FindStrWithFont(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)),
            encoded_uri_component_to_bstr(cmds.at(8)), stol(cmds.at(9)),
            stol(cmds.at(10)), &x, &y), x.intVal, y.intVal);
    case 178:
        return format("{}", bstr_to_utf8(dm->FindStrWithFontE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)),
            stod(cmds.at(7)),
            encoded_uri_component_to_bstr(cmds.at(8)),
            stol(cmds.at(9)), stol(cmds.at(10)))));
    case 179:
        return format("{}", bstr_to_utf8(dm->FindStrWithFontEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)),
            stod(cmds.at(7)),
            encoded_uri_component_to_bstr(cmds.at(8)),
            stol(cmds.at(9)), stol(cmds.at(10)))));
    case 180:
        return format("{}", bstr_to_utf8(dm->GetDictInfo(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)))));
    case 181:
        return format("{}", dm->SaveDict(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 182:
        return format("{}", dm->GetWindowProcessId(stol(cmds.at(1))));
    case 183:
        return format("{}", bstr_to_utf8(dm->GetWindowProcessPath(stol(cmds.at(1)))));
    case 184:
        return format("{}", dm->LockInput(stol(cmds.at(1))));
    case 185:
        return format("{}", bstr_to_utf8(dm->GetPicSize(encoded_uri_component_to_bstr(cmds.at(1)))));
    case 186:
        return format("{}", dm->GetID());
    case 187:
        return format("{}", dm->CapturePng(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5))));
    case 188:
        return format("{}", dm->CaptureGif(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)), stol(cmds.at(6)),
            stol(cmds.at(7))));
    case 189:
        return format("{}", dm->ImageToBmp(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2))));
    case 190:
        return format("{},{},{}", dm->FindStrFast(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)), &x, &y),
            x.intVal, y.intVal);
    case 191:
        return format("{}", bstr_to_utf8(dm->FindStrFastEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)),
            stod(cmds.at(7)))));
    case 192:
        return format("{}", bstr_to_utf8(dm->FindStrFastE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)),
            stod(cmds.at(7)))));
    case 193:
        return format("{}", dm->EnableDisplayDebug(stol(cmds.at(1))));
    case 194:
        return format("{}", dm->CapturePre(encoded_uri_component_to_bstr(cmds.at(1))));
    case 195:
        return format("{}", dm->RegEx(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3))));
    case 196:
        return format("{}", bstr_to_utf8(dm->GetMachineCode()));
    case 197:
        return format("{}", dm->SetClipboard(encoded_uri_component_to_bstr(cmds.at(1))));
    case 198:
        return format("{}", bstr_to_utf8(dm->GetClipboard()));
    case 199:
        return format("{}", dm->GetNowDict());
    case 200:
        return format("{}", dm->Is64Bit());
    case 201:
        return format("{}", dm->GetColorNum(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)), stod(cmds.at(6))));
    case 202:
        return format("{}", bstr_to_utf8(dm->EnumWindowByProcess(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)),
            stol(cmds.at(4)))));
    case 203:
        return format("{}", dm->GetDictCount(stol(cmds.at(1))));
    case 204:
        return format("{}", dm->GetLastError());
    case 205:
        return format("{}", bstr_to_utf8(dm->GetNetTime()));
    case 206:
        return format("{}", dm->EnableGetColorByCapture(stol(cmds.at(1))));
    case 207:
        return format("{}", dm->CheckUAC());
    case 208:
        return format("{}", dm->SetUAC(stol(cmds.at(1))));
    case 209:
        return format("{}", dm->DisableFontSmooth());
    case 210:
        return format("{}", dm->CheckFontSmooth());
    case 211:
        return format("{}", dm->SetDisplayAcceler(stol(cmds.at(1))));
    case 212:
        return format("{}", dm->FindWindowByProcess(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3))));
    case 213:
        return format("{}", dm->FindWindowByProcessId(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3))));
    case 214:
        return format("{}", bstr_to_utf8(dm->ReadIni(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)))));
    case 215:
        return format("{}", dm->WriteIni(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)),
            encoded_uri_component_to_bstr(cmds.at(4))));
    case 216:
        return format("{}", dm->RunApp(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2))));
    case 217:
        return format("{}", dm->delay(stol(cmds.at(1))));
    case 218:
        return format("{}", dm->FindWindowSuper(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2)),
            stol(cmds.at(3)), encoded_uri_component_to_bstr(cmds.at(4)),
            stol(cmds.at(5)), stol(cmds.at(6))));
    case 219:
        return format("{}", bstr_to_utf8(dm->ExcludePos(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2)),
            stol(cmds.at(3)), stol(cmds.at(4)), stol(cmds.at(5)),
            stol(cmds.at(6)))));
    case 220:
        return format("{}", bstr_to_utf8(dm->FindNearestPos(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2)),
            stol(cmds.at(3)), stol(cmds.at(4)))));
    case 221:
        return format("{}", bstr_to_utf8(dm->SortPosDistance(encoded_uri_component_to_bstr(cmds.at(1)),
            stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)))));
    case 222:
        return format("{},{},{}", dm->FindPicMem(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)),
            stol(cmds.at(8)), &x, &y), x.intVal, y.intVal);
    case 223:
        return format("{}", bstr_to_utf8(dm->FindPicMemEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)),
            stol(cmds.at(8)))));
    case 224:
        return format("{}", bstr_to_utf8(dm->FindPicMemE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)),
            stol(cmds.at(8)))));
    case 225:
        return format("{}", bstr_to_utf8(
            dm->AppendPicAddr(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2)),
                stol(cmds.at(3)))));
    case 226:
        return format("{}", dm->WriteFile(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2))));
    case 227:
        return format("{}", dm->Stop(stol(cmds.at(1))));
    case 228:
        return format("{}", dm->SetDictMem(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3))));
    case 229:
        return format("{}", bstr_to_utf8(dm->GetNetTimeSafe()));
    case 230:
        return format("{}", dm->ForceUnBindWindow(stol(cmds.at(1))));
    case 231:
        return format("{}", bstr_to_utf8(dm->ReadIniPwd(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)),
            encoded_uri_component_to_bstr(cmds.at(4)))));
    case 232:
        return format("{}", dm->WriteIniPwd(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)),
            encoded_uri_component_to_bstr(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5))));
    case 233:
        return format("{}", dm->DecodeFile(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2))));
    case 234:
        return format("{}", dm->KeyDownChar(encoded_uri_component_to_bstr(cmds.at(1))));
    case 235:
        return format("{}", dm->KeyUpChar(encoded_uri_component_to_bstr(cmds.at(1))));
    case 236:
        return format("{}", dm->KeyPressChar(encoded_uri_component_to_bstr(cmds.at(1))));
    case 237:
        return format("{}", dm->KeyPressStr(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2))));
    case 238:
        return format("{}", dm->EnableKeypadPatch(stol(cmds.at(1))));
    case 239:
        return format("{}", dm->EnableKeypadSync(stol(cmds.at(1)), stol(cmds.at(2))));
    case 240:
        return format("{}", dm->EnableMouseSync(stol(cmds.at(1)), stol(cmds.at(2))));
    case 241:
        return format("{}", dm->DmGuard(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 242:
        return format("{}", dm->FaqCaptureFromFile(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            stol(cmds.at(6))));
    case 243:
        return format("{}", bstr_to_utf8(dm->FindIntEx(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stoll(cmds.at(3)), stoll(cmds.at(4)), stol(cmds.at(5)),
            stol(cmds.at(6)), stol(cmds.at(7)), stol(cmds.at(8)))));
    case 244:
        return format("{}", bstr_to_utf8(dm->FindFloatEx(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stof(cmds.at(3)), stof(cmds.at(4)), stol(cmds.at(5)),
            stol(cmds.at(6)), stol(cmds.at(7)))));
    case 245:
        return format("{}", bstr_to_utf8(dm->FindDoubleEx(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stod(cmds.at(3)), stod(cmds.at(4)), stol(cmds.at(5)),
            stol(cmds.at(6)), stol(cmds.at(7)))));
    case 246:
        return format("{}", bstr_to_utf8(dm->FindStringEx(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)), stol(cmds.at(4)),
            stol(cmds.at(5)), stol(cmds.at(6)), stol(cmds.at(7)))));
    case 247:
        return format("{}", bstr_to_utf8(dm->FindDataEx(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)), stol(cmds.at(4)),
            stol(cmds.at(5)), stol(cmds.at(6)))));
    case 248:
        return format("{}", dm->EnableRealMouse(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3))));
    case 249:
        return format("{}", dm->EnableRealKeypad(stol(cmds.at(1))));
    case 250:
        return format("{}", dm->SendStringIme(encoded_uri_component_to_bstr(cmds.at(1))));
    case 251:
        return format("{}", dm->FoobarDrawLine(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            stol(cmds.at(5)), encoded_uri_component_to_bstr(cmds.at(6)),
            stol(cmds.at(7)), stol(cmds.at(8))));
    case 252:
        return format("{}", bstr_to_utf8(dm->FindStrEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)))));
    case 253:
        return format("{}", dm->IsBind(stol(cmds.at(1))));
    case 254:
        return format("{}", dm->SetDisplayDelay(stol(cmds.at(1))));
    case 255:
        return format("{}", dm->GetDmCount());
    case 256:
        return format("{}", dm->DisableScreenSave());
    case 257:
        return format("{}", dm->DisablePowerSave());
    case 258:
        return format("{}", dm->SetMemoryHwndAsProcessId(stol(cmds.at(1))));
    case 259:
        return format("{},{},{}", dm->FindShape(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)), stod(cmds.at(6)),
            stol(cmds.at(7)), &x, &y), x.intVal, y.intVal);
    case 260:
        return format("{}", bstr_to_utf8(dm->FindShapeE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            stod(cmds.at(6)), stol(cmds.at(7)))));
    case 261:
        return format("{}", bstr_to_utf8(dm->FindShapeEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            stod(cmds.at(6)), stol(cmds.at(7)))));
    case 262:
        return format("{},{},{}", bstr_to_utf8(dm->FindStrS(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)),
            &x, &y)), x.intVal, y.intVal);
    case 263:
        return format("{}", bstr_to_utf8(dm->FindStrExS(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)))));
    case 264:
        return format("{},{},{}", bstr_to_utf8(dm->FindStrFastS(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)),
            stod(cmds.at(7)), &x, &y)), x.intVal, y.intVal);
    case 265:
        return format("{}", bstr_to_utf8(dm->FindStrFastExS(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)),
            stod(cmds.at(7)))));
    case 266:
        return format("{},{},{}", bstr_to_utf8(dm->FindPicS(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)),
            stol(cmds.at(8)), &x, &y)), x.intVal, y.intVal);
    case 267:
        return format("{}", bstr_to_utf8(dm->FindPicExS(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stod(cmds.at(7)),
            stol(cmds.at(8)))));
    case 268:
        return format("{}", dm->ClearDict(stol(cmds.at(1))));
    case 269:
        return format("{}", bstr_to_utf8(dm->GetMachineCodeNoMac()));
    case 270:
        return format("{},{},{},{},{}", dm->GetClientRect(stol(cmds.at(1)), &x1, &y1, &x2, &y2), x1.intVal, y1.intVal,
            x2.intVal, y2.intVal);
    case 271:
        return format("{}", dm->EnableFakeActive(stol(cmds.at(1))));
    case 272:
        return format(
            "{},{},{}", dm->GetScreenDataBmp(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
                &data, &size), data.intVal, size.intVal);
    case 273:
        return format("{}", dm->EncodeFile(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2))));
    case 274:
        return format("{}", bstr_to_utf8(dm->GetCursorShapeEx(stol(cmds.at(1)))));
    case 275:
        return format("{}", dm->FaqCancel());
    case 276:
        return format("{}", bstr_to_utf8(dm->IntToData(stoll(cmds.at(1)), stol(cmds.at(2)))));
    case 277:
        return format("{}", bstr_to_utf8(dm->FloatToData(stof(cmds.at(1)))));
    case 278:
        return format("{}", bstr_to_utf8(dm->DoubleToData(stod(cmds.at(1)))));
    case 279:
        return format(
            "{}", bstr_to_utf8(dm->StringToData(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2)))));
    case 280:
        return format("{}", dm->SetMemoryFindResultToFile(encoded_uri_component_to_bstr(cmds.at(1))));
    case 281:
        return format("{}", dm->EnableBind(stol(cmds.at(1))));
    case 282:
        return format("{}", dm->SetSimMode(stol(cmds.at(1))));
    case 283:
        return format("{}", dm->LockMouseRect(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4))));
    case 284:
        return format("{}", dm->SendPaste(stol(cmds.at(1))));
    case 285:
        return format("{}", dm->IsDisplayDead(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            stol(cmds.at(5))));
    case 286:
        return format("{}", dm->GetKeyState(stol(cmds.at(1))));
    case 287:
        return format("{}", dm->CopyFile(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)), stol(cmds.at(3))));
    case 288:
        return format("{}", dm->IsFileExist(encoded_uri_component_to_bstr(cmds.at(1))));
    case 289:
        return format("{}", dm->DeleteFile(encoded_uri_component_to_bstr(cmds.at(1))));
    case 290:
        return format("{}", dm->MoveFile(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2))));
    case 291:
        return format("{}", dm->CreateFolder(encoded_uri_component_to_bstr(cmds.at(1))));
    case 292:
        return format("{}", dm->DeleteFolder(encoded_uri_component_to_bstr(cmds.at(1))));
    case 293:
        return format("{}", dm->GetFileLength(encoded_uri_component_to_bstr(cmds.at(1))));
    case 294:
        return format("{}", bstr_to_utf8(dm->ReadFile(encoded_uri_component_to_bstr(cmds.at(1)))));
    case 295:
        return format("{}", dm->WaitKey(stol(cmds.at(1)), stol(cmds.at(2))));
    case 296:
        return format("{}", dm->DeleteIni(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3))));
    case 297:
        return format("{}", dm->DeleteIniPwd(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)),
            encoded_uri_component_to_bstr(cmds.at(4))));
    case 298:
        return format("{}", dm->EnableSpeedDx(stol(cmds.at(1))));
    case 299:
        return format("{}", dm->EnableIme(stol(cmds.at(1))));
    case 300:
        return format("{}", dm->Reg(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2))));
    case 301:
        return format("{}", bstr_to_utf8(dm->SelectFile()));
    case 302:
        return format("{}", bstr_to_utf8(dm->SelectDirectory()));
    case 303:
        return format("{}", dm->LockDisplay(stol(cmds.at(1))));
    case 304:
        return format("{}", dm->FoobarSetSave(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stol(cmds.at(3)), encoded_uri_component_to_bstr(cmds.at(4))));
    case 305:
        return format("{}", bstr_to_utf8(dm->EnumWindowSuper(encoded_uri_component_to_bstr(cmds.at(1)),
            stol(cmds.at(2)), stol(cmds.at(3)),
            encoded_uri_component_to_bstr(cmds.at(4)),
            stol(cmds.at(5)), stol(cmds.at(6)), stol(cmds.at(7)))));
    case 306:
        return format("{}", dm->DownloadFile(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)), stol(cmds.at(3))));
    case 307:
        return format("{}", dm->EnableKeypadMsg(stol(cmds.at(1))));
    case 308:
        return format("{}", dm->EnableMouseMsg(stol(cmds.at(1))));
    case 309:
        return format("{}", dm->RegNoMac(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2))));
    case 310:
        return format("{}", dm->RegExNoMac(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3))));
    case 311:
        return format("{}", dm->SetEnumWindowDelay(stol(cmds.at(1))));
    case 312:
        return format("{}", dm->FindMulColor(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)), stod(cmds.at(6))));
    case 313:
        return format("{}", bstr_to_utf8(dm->GetDict(stol(cmds.at(1)), stol(cmds.at(2)))));
    case 314:
        return format("{}", dm->GetBindWindow());
    case 315:
        return format("{}", dm->FoobarStartGif(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            encoded_uri_component_to_bstr(cmds.at(4)), stol(cmds.at(5)),
            stol(cmds.at(6))));
    case 316:
        return format("{}", dm->FoobarStopGif(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            encoded_uri_component_to_bstr(cmds.at(4))));
    case 317:
        return format("{}", dm->FreeProcessMemory(stol(cmds.at(1))));
    case 318:
        return format("{}", bstr_to_utf8(dm->ReadFileData(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2)),
            stol(cmds.at(3)))));
    case 319:
        return format("{}", dm->VirtualAllocEx(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4))));
    case 320:
        return format("{}", dm->VirtualFreeEx(stol(cmds.at(1)), stoll(cmds.at(2))));
    case 321:
        return format("{}", bstr_to_utf8(dm->GetCommandLine(stol(cmds.at(1)))));
    case 322:
        return format("{}", dm->TerminateProcess(stol(cmds.at(1))));
    case 323:
        return format("{}", bstr_to_utf8(dm->GetNetTimeByIp(encoded_uri_component_to_bstr(cmds.at(1)))));
    case 324:
        return format("{}", bstr_to_utf8(dm->EnumProcess(encoded_uri_component_to_bstr(cmds.at(1)))));
    case 325:
        return format("{}", bstr_to_utf8(dm->GetProcessInfo(stol(cmds.at(1)))));
    case 326:
        return format("{}", dm->ReadIntAddr(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3))));
    case 327:
        return format("{}", bstr_to_utf8(dm->ReadDataAddr(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)))));
    case 328:
        return format("{}", dm->ReadDoubleAddr(stol(cmds.at(1)), stoll(cmds.at(2))));
    case 329:
        return format("{}", dm->ReadFloatAddr(stol(cmds.at(1)), stoll(cmds.at(2))));
    case 330:
        return format(
            "{}", bstr_to_utf8(dm->ReadStringAddr(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)),
                stol(cmds.at(4)))));
    case 331:
        return format("{}", dm->WriteDataAddr(stol(cmds.at(1)), stoll(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3))));
    case 332:
        return format("{}", dm->WriteDoubleAddr(stol(cmds.at(1)), stoll(cmds.at(2)), stod(cmds.at(3))));
    case 333:
        return format("{}", dm->WriteFloatAddr(stol(cmds.at(1)), stoll(cmds.at(2)), stof(cmds.at(3))));
    case 334:
        return format("{}", dm->WriteIntAddr(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)), stoll(cmds.at(4))));
    case 335:
        return format("{}", dm->WriteStringAddr(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)),
            encoded_uri_component_to_bstr(cmds.at(4))));
    case 336:
        return format("{}", dm->Delays(stol(cmds.at(1)), stol(cmds.at(2))));
    case 337:
        return format("{},{},{}", dm->FindColorBlock(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            stod(cmds.at(6)), stol(cmds.at(7)), stol(cmds.at(8)),
            stol(cmds.at(9)), &x, &y), x.intVal, y.intVal);
    case 338:
        return format("{}", bstr_to_utf8(dm->FindColorBlockEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)),
            stod(cmds.at(6)), stol(cmds.at(7)), stol(cmds.at(8)),
            stol(cmds.at(9)))));
    case 339:
        return format("{}", dm->OpenProcess(stol(cmds.at(1))));
    case 340:
        return format("{}", bstr_to_utf8(dm->EnumIniSection(encoded_uri_component_to_bstr(cmds.at(1)))));
    case 341:
        return format("{}", bstr_to_utf8(dm->EnumIniSectionPwd(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)))));
    case 342:
        return format("{}", bstr_to_utf8(dm->EnumIniKey(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)))));
    case 343:
        return format("{}", bstr_to_utf8(dm->EnumIniKeyPwd(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)))));
    case 344:
        return format("{}", dm->SwitchBindWindow(stol(cmds.at(1))));
    case 345:
        return format("{}", dm->InitCri());
    case 346:
        return format("{}", dm->SendStringIme2(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stol(cmds.at(3))));
    case 347:
        return format("{}", bstr_to_utf8(dm->EnumWindowByProcessId(stol(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)),
            stol(cmds.at(4)))));
    case 348:
        return format("{}", bstr_to_utf8(dm->GetDisplayInfo()));
    case 349:
        return format("{}", dm->EnableFontSmooth());
    case 350:
        return format("{}", bstr_to_utf8(dm->OcrExOne(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            stod(cmds.at(6)))));
    case 351:
        return format("{}", dm->SetAero(stol(cmds.at(1))));
    case 352:
        return format("{}", dm->FoobarSetTrans(stol(cmds.at(1)), stol(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)), stod(cmds.at(4))));
    case 353:
        return format("{}", dm->EnablePicCache(stol(cmds.at(1))));
    case 354:
        return format("{}", dm->FaqIsPosted());
    case 355:
        return format("{}", dm->LoadPicByte(stol(cmds.at(1)), stol(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3))));
    case 356:
        return format("{}", dm->MiddleDown());
    case 357:
        return format("{}", dm->MiddleUp());
    case 358:
        return format("{}", dm->FaqCaptureString(encoded_uri_component_to_bstr(cmds.at(1))));
    case 359:
        return format("{}", dm->VirtualProtectEx(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), stol(cmds.at(5))));
    case 360:
        return format("{}", dm->SetMouseSpeed(stol(cmds.at(1))));
    case 361:
        return format("{}", dm->GetMouseSpeed());
    case 362:
        return format("{}", dm->EnableMouseAccuracy(stol(cmds.at(1))));
    case 363:
        return format("{}", dm->SetExcludeRegion(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 364:
        return format("{}", dm->EnableShareDict(stol(cmds.at(1))));
    case 365:
        return format("{}", dm->DisableCloseDisplayAndSleep());
    case 366:
        return format("{}", dm->Int64ToInt32(stoll(cmds.at(1))));
    case 367:
        return format("{}", dm->GetLocale());
    case 368:
        return format("{}", dm->SetLocale());
    case 369:
        return format("{}", dm->ReadDataToBin(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stol(cmds.at(3))));
    case 370:
        return format("{}", dm->WriteDataFromBin(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2)),
            stol(cmds.at(3)), stol(cmds.at(4))));
    case 371:
        return format("{}", dm->ReadDataAddrToBin(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3))));
    case 372:
        return format("{}", dm->WriteDataAddrFromBin(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4))));
    case 373:
        return format("{}", dm->SetParam64ToPointer());
    case 374:
        return format("{}", dm->GetDPI());
    case 375:
        return format("{}", dm->SetDisplayRefreshDelay(stol(cmds.at(1))));
    case 376:
        return format("{}", dm->IsFolderExist(encoded_uri_component_to_bstr(cmds.at(1))));
    case 377:
        return format("{}", dm->GetCpuType());
    case 378:
        return format("{}", dm->ReleaseRef());
    case 379:
        return format("{}", dm->SetExitThread(stol(cmds.at(1))));
    case 380:
        return format("{}", dm->GetFps());
    case 381:
        return format("{}", bstr_to_utf8(dm->VirtualQueryEx(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)))));
    case 382:
        return format(
            "{}", dm->AsmCallEx(stol(cmds.at(1)), stol(cmds.at(2)), encoded_uri_component_to_bstr(cmds.at(3))));
    case 383:
        return format("{}", dm->GetRemoteApiAddress(stol(cmds.at(1)), stoll(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3))));
    case 384:
        return format("{}", bstr_to_utf8(dm->ExecuteCmd(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)), stol(cmds.at(3)))));
    case 385:
        return format("{}", dm->SpeedNormalGraphic(stol(cmds.at(1))));
    case 386:
        return format("{}", dm->UnLoadDriver());
    case 387:
        return format("{}", dm->GetOsBuildNumber());
    case 388:
        return format("{}", dm->HackSpeed(stod(cmds.at(1))));
    case 389:
        return format("{}", bstr_to_utf8(dm->GetRealPath(encoded_uri_component_to_bstr(cmds.at(1)))));
    case 390:
        return format("{}", dm->ShowTaskBarIcon(stol(cmds.at(1)), stol(cmds.at(2))));
    case 391:
        return format("{}", dm->AsmSetTimeout(stol(cmds.at(1)), stol(cmds.at(2))));
    case 392:
        return format("{}", bstr_to_utf8(dm->DmGuardParams(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2)),
            encoded_uri_component_to_bstr(cmds.at(3)))));
    case 393:
        return format("{}", dm->GetModuleSize(stol(cmds.at(1)), encoded_uri_component_to_bstr(cmds.at(2))));
    case 394:
        return format("{}", dm->IsSurrpotVt());
    case 395:
        return format("{}", bstr_to_utf8(dm->GetDiskModel(stol(cmds.at(1)))));
    case 396:
        return format("{}", bstr_to_utf8(dm->GetDiskReversion(stol(cmds.at(1)))));
    case 397:
        return format("{}", dm->EnableFindPicMultithread(stol(cmds.at(1))));
    case 398:
        return format("{}", dm->GetCpuUsage());
    case 399:
        return format("{}", dm->GetMemoryUsage());
    case 400:
        return format("{}", bstr_to_utf8(dm->Hex32(stol(cmds.at(1)))));
    case 401:
        return format("{}", bstr_to_utf8(dm->Hex64(stoll(cmds.at(1)))));
    case 402:
        return format("{}", dm->GetWindowThreadId(stol(cmds.at(1))));
    case 403:
        return format("{}", dm->DmGuardExtract(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2))));
    case 404:
        return format("{}", dm->DmGuardLoadCustom(encoded_uri_component_to_bstr(cmds.at(1)),
            encoded_uri_component_to_bstr(cmds.at(2))));
    case 405:
        return format("{}", dm->SetShowAsmErrorMsg(stol(cmds.at(1))));
    case 406:
        return format(
            "{}", bstr_to_utf8(dm->GetSystemInfo(encoded_uri_component_to_bstr(cmds.at(1)), stol(cmds.at(2)))));
    case 407:
        return format("{}", dm->SetFindPicMultithreadCount(stol(cmds.at(1))));
    case 408:
        return format("{},{},{}", dm->FindPicSim(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stol(cmds.at(7)),
            stol(cmds.at(8)), &x, &y), x.intVal, y.intVal);
    case 409:
        return format("{}", bstr_to_utf8(dm->FindPicSimEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stol(cmds.at(7)),
            stol(cmds.at(8)))));
    case 410:
        return format("{},{},{}", dm->FindPicSimMem(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stol(cmds.at(7)),
            stol(cmds.at(8)), &x, &y), x.intVal, y.intVal);
    case 411:
        return format("{}", bstr_to_utf8(dm->FindPicSimMemEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)),
            encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)),
            stol(cmds.at(7)), stol(cmds.at(8)))));
    case 412:
        return format("{}", bstr_to_utf8(dm->FindPicSimE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stol(cmds.at(7)),
            stol(cmds.at(8)))));
    case 413:
        return format("{}", bstr_to_utf8(dm->FindPicSimMemE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)),
            stol(cmds.at(4)), encoded_uri_component_to_bstr(cmds.at(5)),
            encoded_uri_component_to_bstr(cmds.at(6)), stol(cmds.at(7)),
            stol(cmds.at(8)))));
    case 414:
        return format("{}", dm->SetInputDm(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3))));
    default:
        return std::format("{}, 服务方法不存在!", request_error);
    }
}
