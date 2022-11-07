// clang-format off
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
  case 0:
    return format("0\n{}", bstr_to_utf8(dm->Ver()));
  case 1:
    return format("0\n{}", dm->SetPath(utf8_to_bstr(cmds.at(1))));
  case 2:
    return format("0\n{}", bstr_to_utf8(dm->Ocr(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6)))));
  case 3:
    return format("0\n{}\n{}\n{}", dm->FindStr(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), &x, &y), x.intVal,y.intVal);
  case 4:
    return format("0\n{}", dm->GetResultCount(utf8_to_bstr(cmds.at(1))));
  case 5:
    return format("0\n{}\n{}\n{}", dm->GetResultPos(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2)), &x, &y), x.intVal,y.intVal);
  case 6:
    return format("0\n{}", dm->StrStr(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 7:
    return format("0\n{}", dm->SendCommand(utf8_to_bstr(cmds.at(1))));
  case 8:
    return format("0\n{}", dm->UseDict(stol(cmds.at(1))));
  case 9:
    return format("0\n{}", bstr_to_utf8(dm->GetBasePath()));
  case 10:
    return format("0\n{}", dm->SetDictPwd(utf8_to_bstr(cmds.at(1))));
  case 11:
    return format("0\n{}", bstr_to_utf8(dm->OcrInFile(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)))));
  case 12:
    return format("0\n{}", dm->Capture(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5))));
  case 13:
    return format("0\n{}", dm->KeyPress(stol(cmds.at(1))));
  case 14:
    return format("0\n{}", dm->KeyDown(stol(cmds.at(1))));
  case 15:
    return format("0\n{}", dm->KeyUp(stol(cmds.at(1))));
  case 16:
    return format("0\n{}", dm->LeftClick());
  case 17:
    return format("0\n{}", dm->RightClick());
  case 18:
    return format("0\n{}", dm->MiddleClick());
  case 19:
    return format("0\n{}", dm->LeftDoubleClick());
  case 20:
    return format("0\n{}", dm->LeftDown());
  case 21:
    return format("0\n{}", dm->LeftUp());
  case 22:
    return format("0\n{}", dm->RightDown());
  case 23:
    return format("0\n{}", dm->RightUp());
  case 24:
    return format("0\n{}", dm->MoveTo(stol(cmds.at(1)), stol(cmds.at(2))));
  case 25:
    return format("0\n{}", dm->MoveR(stol(cmds.at(1)), stol(cmds.at(2))));
  case 26:
    return format("0\n{}", bstr_to_utf8(dm->GetColor(stol(cmds.at(1)), stol(cmds.at(2)))));
  case 27:
    return format("0\n{}", bstr_to_utf8(dm->GetColorBGR(stol(cmds.at(1)), stol(cmds.at(2)))));
  case 28:
    return format("0\n{}", bstr_to_utf8(dm->RGB2BGR(utf8_to_bstr(cmds.at(1)))));
  case 29:
    return format("0\n{}", bstr_to_utf8(dm->BGR2RGB(utf8_to_bstr(cmds.at(1)))));
  case 30:
    return format("0\n{}", dm->UnBindWindow());
  case 31:
    return format("0\n{}", dm->CmpColor(stol(cmds.at(1)), stol(cmds.at(2)), utf8_to_bstr(cmds.at(3)), stod(cmds.at(4))));
  case 32:
    return format("0\n{}\n{}\n{}", dm->ClientToScreen(stol(cmds.at(1)), &x, &y), x.intVal,y.intVal);
  case 33:
    return format("0\n{}\n{}\n{}", dm->ScreenToClient(stol(cmds.at(1)), &x, &y), x.intVal,y.intVal);
  case 34:
    return format("0\n{}", dm->ShowScrMsg(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6))));
  case 35:
    return format("0\n{}", dm->SetMinRowGap(stol(cmds.at(1))));
  case 36:
    return format("0\n{}", dm->SetMinColGap(stol(cmds.at(1))));
  case 37:
    return format("0\n{}\n{}\n{}", dm->FindColor(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6)), stol(cmds.at(7)), &x, &y), x.intVal,y.intVal);
  case 38:
    return format("0\n{}", bstr_to_utf8(dm->FindColorEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6)), stol(cmds.at(7)))));
  case 39:
    return format("0\n{}", dm->SetWordLineHeight(stol(cmds.at(1))));
  case 40:
    return format("0\n{}", dm->SetWordGap(stol(cmds.at(1))));
  case 41:
    return format("0\n{}", dm->SetRowGapNoDict(stol(cmds.at(1))));
  case 42:
    return format("0\n{}", dm->SetColGapNoDict(stol(cmds.at(1))));
  case 43:
    return format("0\n{}", dm->SetWordLineHeightNoDict(stol(cmds.at(1))));
  case 44:
    return format("0\n{}", dm->SetWordGapNoDict(stol(cmds.at(1))));
  case 45:
    return format("0\n{}", dm->GetWordResultCount(utf8_to_bstr(cmds.at(1))));
  case 46:
    return format("0\n{}\n{}\n{}", dm->GetWordResultPos(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2)), &x, &y), x.intVal,y.intVal);
  case 47:
    return format("0\n{}", bstr_to_utf8(dm->GetWordResultStr(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2)))));
  case 48:
    return format("0\n{}", bstr_to_utf8(dm->GetWords(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6)))));
  case 49:
    return format("0\n{}", bstr_to_utf8(dm->GetWordsNoDict(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)))));
  case 50:
    return format("0\n{}", dm->SetShowErrorMsg(stol(cmds.at(1))));
  case 51:
    return format("0\n{}\n{}\n{}", dm->GetClientSize(stol(cmds.at(1)), &width, &height), width.intVal,height.intVal);
  case 52:
    return format("0\n{}", dm->MoveWindow(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3))));
  case 53:
    return format("0\n{}", bstr_to_utf8(dm->GetColorHSV(stol(cmds.at(1)), stol(cmds.at(2)))));
  case 54:
    return format("0\n{}", bstr_to_utf8(dm->GetAveRGB(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)))));
  case 55:
    return format("0\n{}", bstr_to_utf8(dm->GetAveHSV(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)))));
  case 56:
    return format("0\n{}", dm->GetForegroundWindow());
  case 57:
    return format("0\n{}", dm->GetForegroundFocus());
  case 58:
    return format("0\n{}", dm->GetMousePointWindow());
  case 59:
    return format("0\n{}", dm->GetPointWindow(stol(cmds.at(1)), stol(cmds.at(2))));
  case 60:
    return format("0\n{}", bstr_to_utf8(dm->EnumWindow(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)), stol(cmds.at(4)))));
  case 61:
    return format("0\n{}", dm->GetWindowState(stol(cmds.at(1)), stol(cmds.at(2))));
  case 62:
    return format("0\n{}", dm->GetWindow(stol(cmds.at(1)), stol(cmds.at(2))));
  case 63:
    return format("0\n{}", dm->GetSpecialWindow(stol(cmds.at(1))));
  case 64:
    return format("0\n{}", dm->SetWindowText(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 65:
    return format("0\n{}", dm->SetWindowSize(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3))));
  case 66:
    return format("0\n{}\n{}\n{}\n{}\n{}", dm->GetWindowRect(stol(cmds.at(1)), &x1, &y1, &x2, &y2), x1.intVal,y1.intVal,x2.intVal,y2.intVal);
  case 67:
    return format("0\n{}", bstr_to_utf8(dm->GetWindowTitle(stol(cmds.at(1)))));
  case 68:
    return format("0\n{}", bstr_to_utf8(dm->GetWindowClass(stol(cmds.at(1)))));
  case 69:
    return format("0\n{}", dm->SetWindowState(stol(cmds.at(1)), stol(cmds.at(2))));
  case 70:
    return format("0\n{}", dm->CreateFoobarRect(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), stol(cmds.at(5))));
  case 71:
    return format("0\n{}", dm->CreateFoobarRoundRect(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), stol(cmds.at(5)), stol(cmds.at(6)), stol(cmds.at(7))));
  case 72:
    return format("0\n{}", dm->CreateFoobarEllipse(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), stol(cmds.at(5))));
  case 73:
    return format("0\n{}", dm->CreateFoobarCustom(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), utf8_to_bstr(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6))));
  case 74:
    return format("0\n{}", dm->FoobarFillRect(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), stol(cmds.at(5)), utf8_to_bstr(cmds.at(6))));
  case 75:
    return format("0\n{}", dm->FoobarDrawText(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), stol(cmds.at(5)), utf8_to_bstr(cmds.at(6)), utf8_to_bstr(cmds.at(7)), stol(cmds.at(8))));
  case 76:
    return format("0\n{}", dm->FoobarDrawPic(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), utf8_to_bstr(cmds.at(4)), utf8_to_bstr(cmds.at(5))));
  case 77:
    return format("0\n{}", dm->FoobarUpdate(stol(cmds.at(1))));
  case 78:
    return format("0\n{}", dm->FoobarLock(stol(cmds.at(1))));
  case 79:
    return format("0\n{}", dm->FoobarUnlock(stol(cmds.at(1))));
  case 80:
    return format("0\n{}", dm->FoobarSetFont(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4))));
  case 81:
    return format("0\n{}", dm->FoobarTextRect(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), stol(cmds.at(5))));
  case 82:
    return format("0\n{}", dm->FoobarPrintText(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3))));
  case 83:
    return format("0\n{}", dm->FoobarClearText(stol(cmds.at(1))));
  case 84:
    return format("0\n{}", dm->FoobarTextLineGap(stol(cmds.at(1)), stol(cmds.at(2))));
  case 85:
    return format("0\n{}", dm->Play(utf8_to_bstr(cmds.at(1))));
  case 86:
    return format("0\n{}", dm->FaqCapture(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), stol(cmds.at(5)), stol(cmds.at(6)), stol(cmds.at(7))));
  case 87:
    return format("0\n{}", dm->FaqRelease(stol(cmds.at(1))));
  case 88:
    return format("0\n{}", bstr_to_utf8(dm->FaqSend(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)))));
  case 89:
    return format("0\n{}", dm->Beep(stol(cmds.at(1)), stol(cmds.at(2))));
  case 90:
    return format("0\n{}", dm->FoobarClose(stol(cmds.at(1))));
  case 91:
    return format("0\n{}", dm->MoveDD(stol(cmds.at(1)), stol(cmds.at(2))));
  case 92:
    return format("0\n{}", dm->FaqGetSize(stol(cmds.at(1))));
  case 93:
    return format("0\n{}", dm->LoadPic(utf8_to_bstr(cmds.at(1))));
  case 94:
    return format("0\n{}", dm->FreePic(utf8_to_bstr(cmds.at(1))));
  case 95:
    return format("0\n{}", dm->GetScreenData(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4))));
  case 96:
    return format("0\n{}", dm->FreeScreenData(stol(cmds.at(1))));
  case 97:
    return format("0\n{}", dm->WheelUp());
  case 98:
    return format("0\n{}", dm->WheelDown());
  case 99:
    return format("0\n{}", dm->SetMouseDelay(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2))));
  case 100:
    return format("0\n{}", dm->SetKeypadDelay(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2))));
  case 101:
    return format("0\n{}", bstr_to_utf8(dm->GetEnv(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)))));
  case 102:
    return format("0\n{}", dm->SetEnv(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3))));
  case 103:
    return format("0\n{}", dm->SendString(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 104:
    return format("0\n{}", dm->DelEnv(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 105:
    return format("0\n{}", bstr_to_utf8(dm->GetPath()));
  case 106:
    return format("0\n{}", dm->SetDict(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 107:
    return format("0\n{}\n{}\n{}", dm->FindPic(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), stol(cmds.at(8)), &x, &y), x.intVal,y.intVal);
  case 108:
    return format("0\n{}", bstr_to_utf8(dm->FindPicEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), stol(cmds.at(8)))));
  case 109:
    return format("0\n{}", dm->SetClientSize(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3))));
  case 110:
    return format("0\n{}", dm->ReadInt(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stol(cmds.at(3))));
  case 111:
    return format("0\n{}", dm->ReadFloat(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 112:
    return format("0\n{}", dm->ReadDouble(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 113:
    return format("0\n{}", bstr_to_utf8(dm->FindInt(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stoll(cmds.at(3)), stoll(cmds.at(4)), stol(cmds.at(5)))));
  case 114:
    return format("0\n{}", bstr_to_utf8(dm->FindFloat(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stof(cmds.at(3)), stof(cmds.at(4)))));
  case 115:
    return format("0\n{}", bstr_to_utf8(dm->FindDouble(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stod(cmds.at(3)), stod(cmds.at(4)))));
  case 116:
    return format("0\n{}", bstr_to_utf8(dm->FindString(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)), stol(cmds.at(4)))));
  case 117:
    return format("0\n{}", dm->GetModuleBaseAddr(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 118:
    return format("0\n{}", bstr_to_utf8(dm->MoveToEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)))));
  case 119:
    return format("0\n{}", bstr_to_utf8(dm->MatchPicName(utf8_to_bstr(cmds.at(1)))));
  case 120:
    return format("0\n{}", dm->AddDict(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 121:
    return format("0\n{}", dm->EnterCri());
  case 122:
    return format("0\n{}", dm->LeaveCri());
  case 123:
    return format("0\n{}", dm->WriteInt(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stol(cmds.at(3)), stoll(cmds.at(4))));
  case 124:
    return format("0\n{}", dm->WriteFloat(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stof(cmds.at(3))));
  case 125:
    return format("0\n{}", dm->WriteDouble(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stod(cmds.at(3))));
  case 126:
    return format("0\n{}", dm->WriteString(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stol(cmds.at(3)), utf8_to_bstr(cmds.at(4))));
  case 127:
    return format("0\n{}", dm->AsmAdd(utf8_to_bstr(cmds.at(1))));
  case 128:
    return format("0\n{}", dm->AsmClear());
  case 129:
    return format("0\n{}", dm->AsmCall(stol(cmds.at(1)), stol(cmds.at(2))));
  case 130:
    return format("0\n{}\n{}\n{}", dm->FindMultiColor(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), stol(cmds.at(8)), &x, &y), x.intVal,y.intVal);
  case 131:
    return format("0\n{}", bstr_to_utf8(dm->FindMultiColorEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), stol(cmds.at(8)))));
  case 132:
    return format("0\n{}", bstr_to_utf8(dm->Assemble(stoll(cmds.at(1)), stol(cmds.at(2)))));
  case 133:
    return format("0\n{}", bstr_to_utf8(dm->DisAssemble(utf8_to_bstr(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)))));
  case 134:
    return format("0\n{}", dm->SetWindowTransparent(stol(cmds.at(1)), stol(cmds.at(2))));
  case 135:
    return format("0\n{}", bstr_to_utf8(dm->ReadData(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stol(cmds.at(3)))));
  case 136:
    return format("0\n{}", dm->WriteData(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3))));
  case 137:
    return format("0\n{}", bstr_to_utf8(dm->FindData(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)))));
  case 138:
    return format("0\n{}", dm->SetPicPwd(utf8_to_bstr(cmds.at(1))));
  case 139:
    return format("0\n{}", dm->Log(utf8_to_bstr(cmds.at(1))));
  case 140:
    return format("0\n{}", bstr_to_utf8(dm->FindStrE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)))));
  case 141:
    return format("0\n{}", bstr_to_utf8(dm->FindColorE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6)), stol(cmds.at(7)))));
  case 142:
    return format("0\n{}", bstr_to_utf8(dm->FindPicE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), stol(cmds.at(8)))));
  case 143:
    return format("0\n{}", bstr_to_utf8(dm->FindMultiColorE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), stol(cmds.at(8)))));
  case 144:
    return format("0\n{}", dm->SetExactOcr(stol(cmds.at(1))));
  case 145:
    return format("0\n{}", bstr_to_utf8(dm->ReadString(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)))));
  case 146:
    return format("0\n{}", dm->FoobarTextPrintDir(stol(cmds.at(1)), stol(cmds.at(2))));
  case 147:
    return format("0\n{}", bstr_to_utf8(dm->OcrEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6)))));
  case 148:
    return format("0\n{}", dm->SetDisplayInput(utf8_to_bstr(cmds.at(1))));
  case 149:
    return format("0\n{}", dm->GetTime());
  case 150:
    return format("0\n{}", dm->GetScreenWidth());
  case 151:
    return format("0\n{}", dm->GetScreenHeight());
  case 152:
    return format("0\n{}", dm->BindWindowEx(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)), utf8_to_bstr(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stol(cmds.at(6))));
  case 153:
    return format("0\n{}", bstr_to_utf8(dm->GetDiskSerial(stol(cmds.at(1)))));
  case 154:
    return format("0\n{}", bstr_to_utf8(dm->Md5(utf8_to_bstr(cmds.at(1)))));
  case 155:
    return format("0\n{}", bstr_to_utf8(dm->GetMac()));
  case 156:
    return format("0\n{}", dm->ActiveInputMethod(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 157:
    return format("0\n{}", dm->CheckInputMethod(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 158:
    return format("0\n{}", dm->FindInputMethod(utf8_to_bstr(cmds.at(1))));
  case 159:
    return format("0\n{}\n{}\n{}", dm->GetCursorPos(&x, &y), x.intVal,y.intVal);
  case 160:
    return format("0\n{}", dm->BindWindow(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)), utf8_to_bstr(cmds.at(4)), stol(cmds.at(5))));
  case 161:
    return format("0\n{}", dm->FindWindow(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 162:
    return format("0\n{}", dm->GetScreenDepth());
  case 163:
    return format("0\n{}", dm->SetScreen(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3))));
  case 164:
    return format("0\n{}", dm->ExitOs(stol(cmds.at(1))));
  case 165:
    return format("0\n{}", bstr_to_utf8(dm->GetDir(stol(cmds.at(1)))));
  case 166:
    return format("0\n{}", dm->GetOsType());
  case 167:
    return format("0\n{}", dm->FindWindowEx(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3))));
  case 168:
    return format("0\n{}", dm->SetExportDict(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 169:
    return format("0\n{}", bstr_to_utf8(dm->GetCursorShape()));
  case 170:
    return format("0\n{}", dm->DownCpu(stol(cmds.at(1)), stol(cmds.at(2))));
  case 171:
    return format("0\n{}", bstr_to_utf8(dm->GetCursorSpot()));
  case 172:
    return format("0\n{}", dm->SendString2(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 173:
    return format("0\n{}", dm->FaqPost(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4))));
  case 174:
    return format("0\n{}", bstr_to_utf8(dm->FaqFetch()));
  case 175:
    return format("0\n{}", bstr_to_utf8(dm->FetchWord(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)))));
  case 176:
    return format("0\n{}", dm->CaptureJpg(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stol(cmds.at(6))));
  case 177:
    return format("0\n{}\n{}\n{}", dm->FindStrWithFont(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), utf8_to_bstr(cmds.at(8)), stol(cmds.at(9)), stol(cmds.at(10)), &x, &y), x.intVal,y.intVal);
  case 178:
    return format("0\n{}", bstr_to_utf8(dm->FindStrWithFontE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), utf8_to_bstr(cmds.at(8)), stol(cmds.at(9)), stol(cmds.at(10)))));
  case 179:
    return format("0\n{}", bstr_to_utf8(dm->FindStrWithFontEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), utf8_to_bstr(cmds.at(8)), stol(cmds.at(9)), stol(cmds.at(10)))));
  case 180:
    return format("0\n{}", bstr_to_utf8(dm->GetDictInfo(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)))));
  case 181:
    return format("0\n{}", dm->SaveDict(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 182:
    return format("0\n{}", dm->GetWindowProcessId(stol(cmds.at(1))));
  case 183:
    return format("0\n{}", bstr_to_utf8(dm->GetWindowProcessPath(stol(cmds.at(1)))));
  case 184:
    return format("0\n{}", dm->LockInput(stol(cmds.at(1))));
  case 185:
    return format("0\n{}", bstr_to_utf8(dm->GetPicSize(utf8_to_bstr(cmds.at(1)))));
  case 186:
    return format("0\n{}", dm->GetID());
  case 187:
    return format("0\n{}", dm->CapturePng(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5))));
  case 188:
    return format("0\n{}", dm->CaptureGif(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stol(cmds.at(6)), stol(cmds.at(7))));
  case 189:
    return format("0\n{}", dm->ImageToBmp(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 190:
    return format("0\n{}\n{}\n{}", dm->FindStrFast(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), &x, &y), x.intVal,y.intVal);
  case 191:
    return format("0\n{}", bstr_to_utf8(dm->FindStrFastEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)))));
  case 192:
    return format("0\n{}", bstr_to_utf8(dm->FindStrFastE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)))));
  case 193:
    return format("0\n{}", dm->EnableDisplayDebug(stol(cmds.at(1))));
  case 194:
    return format("0\n{}", dm->CapturePre(utf8_to_bstr(cmds.at(1))));
  case 195:
    return format("0\n{}", dm->RegEx(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3))));
  case 196:
    return format("0\n{}", bstr_to_utf8(dm->GetMachineCode()));
  case 197:
    return format("0\n{}", dm->SetClipboard(utf8_to_bstr(cmds.at(1))));
  case 198:
    return format("0\n{}", bstr_to_utf8(dm->GetClipboard()));
  case 199:
    return format("0\n{}", dm->GetNowDict());
  case 200:
    return format("0\n{}", dm->Is64Bit());
  case 201:
    return format("0\n{}", dm->GetColorNum(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6))));
  case 202:
    return format("0\n{}", bstr_to_utf8(dm->EnumWindowByProcess(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)), stol(cmds.at(4)))));
  case 203:
    return format("0\n{}", dm->GetDictCount(stol(cmds.at(1))));
  case 204:
    return format("0\n{}", dm->GetLastError());
  case 205:
    return format("0\n{}", bstr_to_utf8(dm->GetNetTime()));
  case 206:
    return format("0\n{}", dm->EnableGetColorByCapture(stol(cmds.at(1))));
  case 207:
    return format("0\n{}", dm->CheckUAC());
  case 208:
    return format("0\n{}", dm->SetUAC(stol(cmds.at(1))));
  case 209:
    return format("0\n{}", dm->DisableFontSmooth());
  case 210:
    return format("0\n{}", dm->CheckFontSmooth());
  case 211:
    return format("0\n{}", dm->SetDisplayAcceler(stol(cmds.at(1))));
  case 212:
    return format("0\n{}", dm->FindWindowByProcess(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3))));
  case 213:
    return format("0\n{}", dm->FindWindowByProcessId(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3))));
  case 214:
    return format("0\n{}", bstr_to_utf8(dm->ReadIni(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)))));
  case 215:
    return format("0\n{}", dm->WriteIni(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)), utf8_to_bstr(cmds.at(4))));
  case 216:
    return format("0\n{}", dm->RunApp(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2))));
  case 217:
    return format("0\n{}", dm->delay(stol(cmds.at(1))));
  case 218:
    return format("0\n{}", dm->FindWindowSuper(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), utf8_to_bstr(cmds.at(4)), stol(cmds.at(5)), stol(cmds.at(6))));
  case 219:
    return format("0\n{}", bstr_to_utf8(dm->ExcludePos(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), stol(cmds.at(5)), stol(cmds.at(6)))));
  case 220:
    return format("0\n{}", bstr_to_utf8(dm->FindNearestPos(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)))));
  case 221:
    return format("0\n{}", bstr_to_utf8(dm->SortPosDistance(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)))));
  case 222:
    return format("0\n{}\n{}\n{}", dm->FindPicMem(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), stol(cmds.at(8)), &x, &y), x.intVal,y.intVal);
  case 223:
    return format("0\n{}", bstr_to_utf8(dm->FindPicMemEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), stol(cmds.at(8)))));
  case 224:
    return format("0\n{}", bstr_to_utf8(dm->FindPicMemE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), stol(cmds.at(8)))));
  case 225:
    return format("0\n{}", bstr_to_utf8(dm->AppendPicAddr(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)))));
  case 226:
    return format("0\n{}", dm->WriteFile(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 227:
    return format("0\n{}", dm->Stop(stol(cmds.at(1))));
  case 228:
    return format("0\n{}", dm->SetDictMem(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3))));
  case 229:
    return format("0\n{}", bstr_to_utf8(dm->GetNetTimeSafe()));
  case 230:
    return format("0\n{}", dm->ForceUnBindWindow(stol(cmds.at(1))));
  case 231:
    return format("0\n{}", bstr_to_utf8(dm->ReadIniPwd(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)), utf8_to_bstr(cmds.at(4)))));
  case 232:
    return format("0\n{}", dm->WriteIniPwd(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)), utf8_to_bstr(cmds.at(4)), utf8_to_bstr(cmds.at(5))));
  case 233:
    return format("0\n{}", dm->DecodeFile(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 234:
    return format("0\n{}", dm->KeyDownChar(utf8_to_bstr(cmds.at(1))));
  case 235:
    return format("0\n{}", dm->KeyUpChar(utf8_to_bstr(cmds.at(1))));
  case 236:
    return format("0\n{}", dm->KeyPressChar(utf8_to_bstr(cmds.at(1))));
  case 237:
    return format("0\n{}", dm->KeyPressStr(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2))));
  case 238:
    return format("0\n{}", dm->EnableKeypadPatch(stol(cmds.at(1))));
  case 239:
    return format("0\n{}", dm->EnableKeypadSync(stol(cmds.at(1)), stol(cmds.at(2))));
  case 240:
    return format("0\n{}", dm->EnableMouseSync(stol(cmds.at(1)), stol(cmds.at(2))));
  case 241:
    return format("0\n{}", dm->DmGuard(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 242:
    return format("0\n{}", dm->FaqCaptureFromFile(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stol(cmds.at(6))));
  case 243:
    return format("0\n{}", bstr_to_utf8(dm->FindIntEx(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stoll(cmds.at(3)), stoll(cmds.at(4)), stol(cmds.at(5)), stol(cmds.at(6)), stol(cmds.at(7)), stol(cmds.at(8)))));
  case 244:
    return format("0\n{}", bstr_to_utf8(dm->FindFloatEx(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stof(cmds.at(3)), stof(cmds.at(4)), stol(cmds.at(5)), stol(cmds.at(6)), stol(cmds.at(7)))));
  case 245:
    return format("0\n{}", bstr_to_utf8(dm->FindDoubleEx(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stod(cmds.at(3)), stod(cmds.at(4)), stol(cmds.at(5)), stol(cmds.at(6)), stol(cmds.at(7)))));
  case 246:
    return format("0\n{}", bstr_to_utf8(dm->FindStringEx(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)), stol(cmds.at(4)), stol(cmds.at(5)), stol(cmds.at(6)), stol(cmds.at(7)))));
  case 247:
    return format("0\n{}", bstr_to_utf8(dm->FindDataEx(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)), stol(cmds.at(4)), stol(cmds.at(5)), stol(cmds.at(6)))));
  case 248:
    return format("0\n{}", dm->EnableRealMouse(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3))));
  case 249:
    return format("0\n{}", dm->EnableRealKeypad(stol(cmds.at(1))));
  case 250:
    return format("0\n{}", dm->SendStringIme(utf8_to_bstr(cmds.at(1))));
  case 251:
    return format("0\n{}", dm->FoobarDrawLine(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), stol(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stol(cmds.at(7)), stol(cmds.at(8))));
  case 252:
    return format("0\n{}", bstr_to_utf8(dm->FindStrEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)))));
  case 253:
    return format("0\n{}", dm->IsBind(stol(cmds.at(1))));
  case 254:
    return format("0\n{}", dm->SetDisplayDelay(stol(cmds.at(1))));
  case 255:
    return format("0\n{}", dm->GetDmCount());
  case 256:
    return format("0\n{}", dm->DisableScreenSave());
  case 257:
    return format("0\n{}", dm->DisablePowerSave());
  case 258:
    return format("0\n{}", dm->SetMemoryHwndAsProcessId(stol(cmds.at(1))));
  case 259:
    return format("0\n{}\n{}\n{}", dm->FindShape(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6)), stol(cmds.at(7)), &x, &y), x.intVal,y.intVal);
  case 260:
    return format("0\n{}", bstr_to_utf8(dm->FindShapeE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6)), stol(cmds.at(7)))));
  case 261:
    return format("0\n{}", bstr_to_utf8(dm->FindShapeEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6)), stol(cmds.at(7)))));
  case 262:
    return format("0\n{}\n{}\n{}", bstr_to_utf8(dm->FindStrS(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), &x, &y)), x.intVal,y.intVal);
  case 263:
    return format("0\n{}", bstr_to_utf8(dm->FindStrExS(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)))));
  case 264:
    return format("0\n{}\n{}\n{}", bstr_to_utf8(dm->FindStrFastS(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), &x, &y)), x.intVal,y.intVal);
  case 265:
    return format("0\n{}", bstr_to_utf8(dm->FindStrFastExS(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)))));
  case 266:
    return format("0\n{}\n{}\n{}", bstr_to_utf8(dm->FindPicS(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), stol(cmds.at(8)), &x, &y)), x.intVal,y.intVal);
  case 267:
    return format("0\n{}", bstr_to_utf8(dm->FindPicExS(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stod(cmds.at(7)), stol(cmds.at(8)))));
  case 268:
    return format("0\n{}", dm->ClearDict(stol(cmds.at(1))));
  case 269:
    return format("0\n{}", bstr_to_utf8(dm->GetMachineCodeNoMac()));
  case 270:
    return format("0\n{}\n{}\n{}\n{}\n{}", dm->GetClientRect(stol(cmds.at(1)), &x1, &y1, &x2, &y2), x1.intVal,y1.intVal,x2.intVal,y2.intVal);
  case 271:
    return format("0\n{}", dm->EnableFakeActive(stol(cmds.at(1))));
  case 272:
    return format("0\n{}\n{}\n{}", dm->GetScreenDataBmp(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), &data, &size), data.intVal,size.intVal);
  case 273:
    return format("0\n{}", dm->EncodeFile(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 274:
    return format("0\n{}", bstr_to_utf8(dm->GetCursorShapeEx(stol(cmds.at(1)))));
  case 275:
    return format("0\n{}", dm->FaqCancel());
  case 276:
    return format("0\n{}", bstr_to_utf8(dm->IntToData(stoll(cmds.at(1)), stol(cmds.at(2)))));
  case 277:
    return format("0\n{}", bstr_to_utf8(dm->FloatToData(stof(cmds.at(1)))));
  case 278:
    return format("0\n{}", bstr_to_utf8(dm->DoubleToData(stod(cmds.at(1)))));
  case 279:
    return format("0\n{}", bstr_to_utf8(dm->StringToData(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2)))));
  case 280:
    return format("0\n{}", dm->SetMemoryFindResultToFile(utf8_to_bstr(cmds.at(1))));
  case 281:
    return format("0\n{}", dm->EnableBind(stol(cmds.at(1))));
  case 282:
    return format("0\n{}", dm->SetSimMode(stol(cmds.at(1))));
  case 283:
    return format("0\n{}", dm->LockMouseRect(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4))));
  case 284:
    return format("0\n{}", dm->SendPaste(stol(cmds.at(1))));
  case 285:
    return format("0\n{}", dm->IsDisplayDead(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), stol(cmds.at(5))));
  case 286:
    return format("0\n{}", dm->GetKeyState(stol(cmds.at(1))));
  case 287:
    return format("0\n{}", dm->CopyFile(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stol(cmds.at(3))));
  case 288:
    return format("0\n{}", dm->IsFileExist(utf8_to_bstr(cmds.at(1))));
  case 289:
    return format("0\n{}", dm->DeleteFile(utf8_to_bstr(cmds.at(1))));
  case 290:
    return format("0\n{}", dm->MoveFile(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 291:
    return format("0\n{}", dm->CreateFolder(utf8_to_bstr(cmds.at(1))));
  case 292:
    return format("0\n{}", dm->DeleteFolder(utf8_to_bstr(cmds.at(1))));
  case 293:
    return format("0\n{}", dm->GetFileLength(utf8_to_bstr(cmds.at(1))));
  case 294:
    return format("0\n{}", bstr_to_utf8(dm->ReadFile(utf8_to_bstr(cmds.at(1)))));
  case 295:
    return format("0\n{}", dm->WaitKey(stol(cmds.at(1)), stol(cmds.at(2))));
  case 296:
    return format("0\n{}", dm->DeleteIni(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3))));
  case 297:
    return format("0\n{}", dm->DeleteIniPwd(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)), utf8_to_bstr(cmds.at(4))));
  case 298:
    return format("0\n{}", dm->EnableSpeedDx(stol(cmds.at(1))));
  case 299:
    return format("0\n{}", dm->EnableIme(stol(cmds.at(1))));
  case 300:
    return format("0\n{}", dm->Reg(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 301:
    return format("0\n{}", bstr_to_utf8(dm->SelectFile()));
  case 302:
    return format("0\n{}", bstr_to_utf8(dm->SelectDirectory()));
  case 303:
    return format("0\n{}", dm->LockDisplay(stol(cmds.at(1))));
  case 304:
    return format("0\n{}", dm->FoobarSetSave(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stol(cmds.at(3)), utf8_to_bstr(cmds.at(4))));
  case 305:
    return format("0\n{}", bstr_to_utf8(dm->EnumWindowSuper(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), utf8_to_bstr(cmds.at(4)), stol(cmds.at(5)), stol(cmds.at(6)), stol(cmds.at(7)))));
  case 306:
    return format("0\n{}", dm->DownloadFile(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stol(cmds.at(3))));
  case 307:
    return format("0\n{}", dm->EnableKeypadMsg(stol(cmds.at(1))));
  case 308:
    return format("0\n{}", dm->EnableMouseMsg(stol(cmds.at(1))));
  case 309:
    return format("0\n{}", dm->RegNoMac(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 310:
    return format("0\n{}", dm->RegExNoMac(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3))));
  case 311:
    return format("0\n{}", dm->SetEnumWindowDelay(stol(cmds.at(1))));
  case 312:
    return format("0\n{}", dm->FindMulColor(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6))));
  case 313:
    return format("0\n{}", bstr_to_utf8(dm->GetDict(stol(cmds.at(1)), stol(cmds.at(2)))));
  case 314:
    return format("0\n{}", dm->GetBindWindow());
  case 315:
    return format("0\n{}", dm->FoobarStartGif(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), utf8_to_bstr(cmds.at(4)), stol(cmds.at(5)), stol(cmds.at(6))));
  case 316:
    return format("0\n{}", dm->FoobarStopGif(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), utf8_to_bstr(cmds.at(4))));
  case 317:
    return format("0\n{}", dm->FreeProcessMemory(stol(cmds.at(1))));
  case 318:
    return format("0\n{}", bstr_to_utf8(dm->ReadFileData(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)))));
  case 319:
    return format("0\n{}", dm->VirtualAllocEx(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4))));
  case 320:
    return format("0\n{}", dm->VirtualFreeEx(stol(cmds.at(1)), stoll(cmds.at(2))));
  case 321:
    return format("0\n{}", bstr_to_utf8(dm->GetCommandLine(stol(cmds.at(1)))));
  case 322:
    return format("0\n{}", dm->TerminateProcess(stol(cmds.at(1))));
  case 323:
    return format("0\n{}", bstr_to_utf8(dm->GetNetTimeByIp(utf8_to_bstr(cmds.at(1)))));
  case 324:
    return format("0\n{}", bstr_to_utf8(dm->EnumProcess(utf8_to_bstr(cmds.at(1)))));
  case 325:
    return format("0\n{}", bstr_to_utf8(dm->GetProcessInfo(stol(cmds.at(1)))));
  case 326:
    return format("0\n{}", dm->ReadIntAddr(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3))));
  case 327:
    return format("0\n{}", bstr_to_utf8(dm->ReadDataAddr(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)))));
  case 328:
    return format("0\n{}", dm->ReadDoubleAddr(stol(cmds.at(1)), stoll(cmds.at(2))));
  case 329:
    return format("0\n{}", dm->ReadFloatAddr(stol(cmds.at(1)), stoll(cmds.at(2))));
  case 330:
    return format("0\n{}", bstr_to_utf8(dm->ReadStringAddr(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)))));
  case 331:
    return format("0\n{}", dm->WriteDataAddr(stol(cmds.at(1)), stoll(cmds.at(2)), utf8_to_bstr(cmds.at(3))));
  case 332:
    return format("0\n{}", dm->WriteDoubleAddr(stol(cmds.at(1)), stoll(cmds.at(2)), stod(cmds.at(3))));
  case 333:
    return format("0\n{}", dm->WriteFloatAddr(stol(cmds.at(1)), stoll(cmds.at(2)), stof(cmds.at(3))));
  case 334:
    return format("0\n{}", dm->WriteIntAddr(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)), stoll(cmds.at(4))));
  case 335:
    return format("0\n{}", dm->WriteStringAddr(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)), utf8_to_bstr(cmds.at(4))));
  case 336:
    return format("0\n{}", dm->Delays(stol(cmds.at(1)), stol(cmds.at(2))));
  case 337:
    return format("0\n{}\n{}\n{}", dm->FindColorBlock(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6)), stol(cmds.at(7)), stol(cmds.at(8)), stol(cmds.at(9)), &x, &y), x.intVal,y.intVal);
  case 338:
    return format("0\n{}", bstr_to_utf8(dm->FindColorBlockEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6)), stol(cmds.at(7)), stol(cmds.at(8)), stol(cmds.at(9)))));
  case 339:
    return format("0\n{}", dm->OpenProcess(stol(cmds.at(1))));
  case 340:
    return format("0\n{}", bstr_to_utf8(dm->EnumIniSection(utf8_to_bstr(cmds.at(1)))));
  case 341:
    return format("0\n{}", bstr_to_utf8(dm->EnumIniSectionPwd(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)))));
  case 342:
    return format("0\n{}", bstr_to_utf8(dm->EnumIniKey(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)))));
  case 343:
    return format("0\n{}", bstr_to_utf8(dm->EnumIniKeyPwd(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)))));
  case 344:
    return format("0\n{}", dm->SwitchBindWindow(stol(cmds.at(1))));
  case 345:
    return format("0\n{}", dm->InitCri());
  case 346:
    return format("0\n{}", dm->SendStringIme2(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stol(cmds.at(3))));
  case 347:
    return format("0\n{}", bstr_to_utf8(dm->EnumWindowByProcessId(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)), stol(cmds.at(4)))));
  case 348:
    return format("0\n{}", bstr_to_utf8(dm->GetDisplayInfo()));
  case 349:
    return format("0\n{}", dm->EnableFontSmooth());
  case 350:
    return format("0\n{}", bstr_to_utf8(dm->OcrExOne(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), stod(cmds.at(6)))));
  case 351:
    return format("0\n{}", dm->SetAero(stol(cmds.at(1))));
  case 352:
    return format("0\n{}", dm->FoobarSetTrans(stol(cmds.at(1)), stol(cmds.at(2)), utf8_to_bstr(cmds.at(3)), stod(cmds.at(4))));
  case 353:
    return format("0\n{}", dm->EnablePicCache(stol(cmds.at(1))));
  case 354:
    return format("0\n{}", dm->FaqIsPosted());
  case 355:
    return format("0\n{}", dm->LoadPicByte(stol(cmds.at(1)), stol(cmds.at(2)), utf8_to_bstr(cmds.at(3))));
  case 356:
    return format("0\n{}", dm->MiddleDown());
  case 357:
    return format("0\n{}", dm->MiddleUp());
  case 358:
    return format("0\n{}", dm->FaqCaptureString(utf8_to_bstr(cmds.at(1))));
  case 359:
    return format("0\n{}", dm->VirtualProtectEx(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), stol(cmds.at(5))));
  case 360:
    return format("0\n{}", dm->SetMouseSpeed(stol(cmds.at(1))));
  case 361:
    return format("0\n{}", dm->GetMouseSpeed());
  case 362:
    return format("0\n{}", dm->EnableMouseAccuracy(stol(cmds.at(1))));
  case 363:
    return format("0\n{}", dm->SetExcludeRegion(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 364:
    return format("0\n{}", dm->EnableShareDict(stol(cmds.at(1))));
  case 365:
    return format("0\n{}", dm->DisableCloseDisplayAndSleep());
  case 366:
    return format("0\n{}", dm->Int64ToInt32(stoll(cmds.at(1))));
  case 367:
    return format("0\n{}", dm->GetLocale());
  case 368:
    return format("0\n{}", dm->SetLocale());
  case 369:
    return format("0\n{}", dm->ReadDataToBin(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stol(cmds.at(3))));
  case 370:
    return format("0\n{}", dm->WriteDataFromBin(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4))));
  case 371:
    return format("0\n{}", dm->ReadDataAddrToBin(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3))));
  case 372:
    return format("0\n{}", dm->WriteDataAddrFromBin(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4))));
  case 373:
    return format("0\n{}", dm->SetParam64ToPointer());
  case 374:
    return format("0\n{}", dm->GetDPI());
  case 375:
    return format("0\n{}", dm->SetDisplayRefreshDelay(stol(cmds.at(1))));
  case 376:
    return format("0\n{}", dm->IsFolderExist(utf8_to_bstr(cmds.at(1))));
  case 377:
    return format("0\n{}", dm->GetCpuType());
  case 378:
    return format("0\n{}", dm->ReleaseRef());
  case 379:
    return format("0\n{}", dm->SetExitThread(stol(cmds.at(1))));
  case 380:
    return format("0\n{}", dm->GetFps());
  case 381:
    return format("0\n{}", bstr_to_utf8(dm->VirtualQueryEx(stol(cmds.at(1)), stoll(cmds.at(2)), stol(cmds.at(3)))));
  case 382:
    return format("0\n{}", dm->AsmCallEx(stol(cmds.at(1)), stol(cmds.at(2)), utf8_to_bstr(cmds.at(3))));
  case 383:
    return format("0\n{}", dm->GetRemoteApiAddress(stol(cmds.at(1)), stoll(cmds.at(2)), utf8_to_bstr(cmds.at(3))));
  case 384:
    return format("0\n{}", bstr_to_utf8(dm->ExecuteCmd(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), stol(cmds.at(3)))));
  case 385:
    return format("0\n{}", dm->SpeedNormalGraphic(stol(cmds.at(1))));
  case 386:
    return format("0\n{}", dm->UnLoadDriver());
  case 387:
    return format("0\n{}", dm->GetOsBuildNumber());
  case 388:
    return format("0\n{}", dm->HackSpeed(stod(cmds.at(1))));
  case 389:
    return format("0\n{}", bstr_to_utf8(dm->GetRealPath(utf8_to_bstr(cmds.at(1)))));
  case 390:
    return format("0\n{}", dm->ShowTaskBarIcon(stol(cmds.at(1)), stol(cmds.at(2))));
  case 391:
    return format("0\n{}", dm->AsmSetTimeout(stol(cmds.at(1)), stol(cmds.at(2))));
  case 392:
    return format("0\n{}", bstr_to_utf8(dm->DmGuardParams(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2)), utf8_to_bstr(cmds.at(3)))));
  case 393:
    return format("0\n{}", dm->GetModuleSize(stol(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 394:
    return format("0\n{}", dm->IsSurrpotVt());
  case 395:
    return format("0\n{}", bstr_to_utf8(dm->GetDiskModel(stol(cmds.at(1)))));
  case 396:
    return format("0\n{}", bstr_to_utf8(dm->GetDiskReversion(stol(cmds.at(1)))));
  case 397:
    return format("0\n{}", dm->EnableFindPicMultithread(stol(cmds.at(1))));
  case 398:
    return format("0\n{}", dm->GetCpuUsage());
  case 399:
    return format("0\n{}", dm->GetMemoryUsage());
  case 400:
    return format("0\n{}", bstr_to_utf8(dm->Hex32(stol(cmds.at(1)))));
  case 401:
    return format("0\n{}", bstr_to_utf8(dm->Hex64(stoll(cmds.at(1)))));
  case 402:
    return format("0\n{}", dm->GetWindowThreadId(stol(cmds.at(1))));
  case 403:
    return format("0\n{}", dm->DmGuardExtract(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 404:
    return format("0\n{}", dm->DmGuardLoadCustom(utf8_to_bstr(cmds.at(1)), utf8_to_bstr(cmds.at(2))));
  case 405:
    return format("0\n{}", dm->SetShowAsmErrorMsg(stol(cmds.at(1))));
  case 406:
    return format("0\n{}", bstr_to_utf8(dm->GetSystemInfo(utf8_to_bstr(cmds.at(1)), stol(cmds.at(2)))));
  case 407:
    return format("0\n{}", dm->SetFindPicMultithreadCount(stol(cmds.at(1))));
  case 408:
    return format("0\n{}\n{}\n{}", dm->FindPicSim(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stol(cmds.at(7)), stol(cmds.at(8)), &x, &y), x.intVal,y.intVal);
  case 409:
    return format("0\n{}", bstr_to_utf8(dm->FindPicSimEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stol(cmds.at(7)), stol(cmds.at(8)))));
  case 410:
    return format("0\n{}\n{}\n{}", dm->FindPicSimMem(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stol(cmds.at(7)), stol(cmds.at(8)), &x, &y), x.intVal,y.intVal);
  case 411:
    return format("0\n{}", bstr_to_utf8(dm->FindPicSimMemEx(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stol(cmds.at(7)), stol(cmds.at(8)))));
  case 412:
    return format("0\n{}", bstr_to_utf8(dm->FindPicSimE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stol(cmds.at(7)), stol(cmds.at(8)))));
  case 413:
    return format("0\n{}", bstr_to_utf8(dm->FindPicSimMemE(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3)), stol(cmds.at(4)), utf8_to_bstr(cmds.at(5)), utf8_to_bstr(cmds.at(6)), stol(cmds.at(7)), stol(cmds.at(8)))));
  case 414:
    return format("0\n{}", dm->SetInputDm(stol(cmds.at(1)), stol(cmds.at(2)), stol(cmds.at(3))));
  default:
    return "1\n接口不存在";
  }
}
