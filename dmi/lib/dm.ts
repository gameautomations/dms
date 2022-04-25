export class dmsoft {
    static API_BASE = "https://localhost:14114";
    static fetch: (url: string) => Promise<string> = (url: string) =>
      fetch(`${dmsoft.API_BASE}/${url}`).then((res) => res.text());
    id: number;

    constructor(id: number) {
      this.id = id;
    }

    async exec(...args: any[]): Promise<string> {
      return await dmsoft.fetch(`d?i=${this.id}&c=${args.join(",")}`);
    }

    async Ver (): Promise<string>{
    return  await this.exec(0);
    }
    
    async SetPath (path: string): Promise<number>{
    return Number( await this.exec(1,path));
    }
    
    async Ocr (x1: number, y1: number, x2: number, y2: number, color: string, sim: number): Promise<string>{
    return  await this.exec(2,x1, y1, x2, y2, color, sim);
    }
    
    async FindStr (x1: number, y1: number, x2: number, y2: number, str: string, color: string, sim: number): Promise<[number,number,number]>{
    const resStr = await this.exec(3,x1, y1, x2, y2, str, color, sim);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async GetResultCount (str: string): Promise<number>{
    return Number( await this.exec(4,str));
    }
    
    async GetResultPos (str: string, index: number): Promise<[number,number,number]>{
    const resStr = await this.exec(5,str, index);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async StrStr (s: string, str: string): Promise<number>{
    return Number( await this.exec(6,s, str));
    }
    
    async SendCommand (cmd: string): Promise<number>{
    return Number( await this.exec(7,cmd));
    }
    
    async UseDict (index: number): Promise<number>{
    return Number( await this.exec(8,index));
    }
    
    async GetBasePath (): Promise<string>{
    return  await this.exec(9);
    }
    
    async SetDictPwd (pwd: string): Promise<number>{
    return Number( await this.exec(10,pwd));
    }
    
    async OcrInFile (x1: number, y1: number, x2: number, y2: number, pic_name: string, color: string, sim: number): Promise<string>{
    return  await this.exec(11,x1, y1, x2, y2, pic_name, color, sim);
    }
    
    async Capture (x1: number, y1: number, x2: number, y2: number, file: string): Promise<number>{
    return Number( await this.exec(12,x1, y1, x2, y2, file));
    }
    
    async KeyPress (vk: number): Promise<number>{
    return Number( await this.exec(13,vk));
    }
    
    async KeyDown (vk: number): Promise<number>{
    return Number( await this.exec(14,vk));
    }
    
    async KeyUp (vk: number): Promise<number>{
    return Number( await this.exec(15,vk));
    }
    
    async LeftClick (): Promise<number>{
    return Number( await this.exec(16));
    }
    
    async RightClick (): Promise<number>{
    return Number( await this.exec(17));
    }
    
    async MiddleClick (): Promise<number>{
    return Number( await this.exec(18));
    }
    
    async LeftDoubleClick (): Promise<number>{
    return Number( await this.exec(19));
    }
    
    async LeftDown (): Promise<number>{
    return Number( await this.exec(20));
    }
    
    async LeftUp (): Promise<number>{
    return Number( await this.exec(21));
    }
    
    async RightDown (): Promise<number>{
    return Number( await this.exec(22));
    }
    
    async RightUp (): Promise<number>{
    return Number( await this.exec(23));
    }
    
    async MoveTo (x: number, y: number): Promise<number>{
    return Number( await this.exec(24,x, y));
    }
    
    async MoveR (rx: number, ry: number): Promise<number>{
    return Number( await this.exec(25,rx, ry));
    }
    
    async GetColor (x: number, y: number): Promise<string>{
    return  await this.exec(26,x, y);
    }
    
    async GetColorBGR (x: number, y: number): Promise<string>{
    return  await this.exec(27,x, y);
    }
    
    async RGB2BGR (rgb_color: string): Promise<string>{
    return  await this.exec(28,rgb_color);
    }
    
    async BGR2RGB (bgr_color: string): Promise<string>{
    return  await this.exec(29,bgr_color);
    }
    
    async UnBindWindow (): Promise<number>{
    return Number( await this.exec(30));
    }
    
    async CmpColor (x: number, y: number, color: string, sim: number): Promise<number>{
    return Number( await this.exec(31,x, y, color, sim));
    }
    
    async ClientToScreen (hwnd: number): Promise<[number,number,number]>{
    const resStr = await this.exec(32,hwnd);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async ScreenToClient (hwnd: number): Promise<[number,number,number]>{
    const resStr = await this.exec(33,hwnd);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async ShowScrMsg (x1: number, y1: number, x2: number, y2: number, msg: string, color: string): Promise<number>{
    return Number( await this.exec(34,x1, y1, x2, y2, msg, color));
    }
    
    async SetMinRowGap (row_gap: number): Promise<number>{
    return Number( await this.exec(35,row_gap));
    }
    
    async SetMinColGap (col_gap: number): Promise<number>{
    return Number( await this.exec(36,col_gap));
    }
    
    async FindColor (x1: number, y1: number, x2: number, y2: number, color: string, sim: number, dir: number): Promise<[number,number,number]>{
    const resStr = await this.exec(37,x1, y1, x2, y2, color, sim, dir);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async FindColorEx (x1: number, y1: number, x2: number, y2: number, color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(38,x1, y1, x2, y2, color, sim, dir);
    }
    
    async SetWordLineHeight (line_height: number): Promise<number>{
    return Number( await this.exec(39,line_height));
    }
    
    async SetWordGap (word_gap: number): Promise<number>{
    return Number( await this.exec(40,word_gap));
    }
    
    async SetRowGapNoDict (row_gap: number): Promise<number>{
    return Number( await this.exec(41,row_gap));
    }
    
    async SetColGapNoDict (col_gap: number): Promise<number>{
    return Number( await this.exec(42,col_gap));
    }
    
    async SetWordLineHeightNoDict (line_height: number): Promise<number>{
    return Number( await this.exec(43,line_height));
    }
    
    async SetWordGapNoDict (word_gap: number): Promise<number>{
    return Number( await this.exec(44,word_gap));
    }
    
    async GetWordResultCount (str: string): Promise<number>{
    return Number( await this.exec(45,str));
    }
    
    async GetWordResultPos (str: string, index: number): Promise<[number,number,number]>{
    const resStr = await this.exec(46,str, index);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async GetWordResultStr (str: string, index: number): Promise<string>{
    return  await this.exec(47,str, index);
    }
    
    async GetWords (x1: number, y1: number, x2: number, y2: number, color: string, sim: number): Promise<string>{
    return  await this.exec(48,x1, y1, x2, y2, color, sim);
    }
    
    async GetWordsNoDict (x1: number, y1: number, x2: number, y2: number, color: string): Promise<string>{
    return  await this.exec(49,x1, y1, x2, y2, color);
    }
    
    async SetShowErrorMsg (show: number): Promise<number>{
    return Number( await this.exec(50,show));
    }
    
    async GetClientSize (hwnd: number): Promise<[number,number,number]>{
    const resStr = await this.exec(51,hwnd);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async MoveWindow (hwnd: number, x: number, y: number): Promise<number>{
    return Number( await this.exec(52,hwnd, x, y));
    }
    
    async GetColorHSV (x: number, y: number): Promise<string>{
    return  await this.exec(53,x, y);
    }
    
    async GetAveRGB (x1: number, y1: number, x2: number, y2: number): Promise<string>{
    return  await this.exec(54,x1, y1, x2, y2);
    }
    
    async GetAveHSV (x1: number, y1: number, x2: number, y2: number): Promise<string>{
    return  await this.exec(55,x1, y1, x2, y2);
    }
    
    async GetForegroundWindow (): Promise<number>{
    return Number( await this.exec(56));
    }
    
    async GetForegroundFocus (): Promise<number>{
    return Number( await this.exec(57));
    }
    
    async GetMousePointWindow (): Promise<number>{
    return Number( await this.exec(58));
    }
    
    async GetPointWindow (x: number, y: number): Promise<number>{
    return Number( await this.exec(59,x, y));
    }
    
    async EnumWindow (parent: number, title: string, class_name: string, filter: number): Promise<string>{
    return  await this.exec(60,parent, title, class_name, filter);
    }
    
    async GetWindowState (hwnd: number, flag: number): Promise<number>{
    return Number( await this.exec(61,hwnd, flag));
    }
    
    async GetWindow (hwnd: number, flag: number): Promise<number>{
    return Number( await this.exec(62,hwnd, flag));
    }
    
    async GetSpecialWindow (flag: number): Promise<number>{
    return Number( await this.exec(63,flag));
    }
    
    async SetWindowText (hwnd: number, text: string): Promise<number>{
    return Number( await this.exec(64,hwnd, text));
    }
    
    async SetWindowSize (hwnd: number, width: number, height: number): Promise<number>{
    return Number( await this.exec(65,hwnd, width, height));
    }
    
    async GetWindowRect (hwnd: number): Promise<[number,number,number,number,number]>{
    const resStr = await this.exec(66,hwnd);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2]),Number(resArray[3]),Number(resArray[4])];
    }
    
    async GetWindowTitle (hwnd: number): Promise<string>{
    return  await this.exec(67,hwnd);
    }
    
    async GetWindowClass (hwnd: number): Promise<string>{
    return  await this.exec(68,hwnd);
    }
    
    async SetWindowState (hwnd: number, flag: number): Promise<number>{
    return Number( await this.exec(69,hwnd, flag));
    }
    
    async CreateFoobarRect (hwnd: number, x: number, y: number, w: number, h: number): Promise<number>{
    return Number( await this.exec(70,hwnd, x, y, w, h));
    }
    
    async CreateFoobarRoundRect (hwnd: number, x: number, y: number, w: number, h: number, rw: number, rh: number): Promise<number>{
    return Number( await this.exec(71,hwnd, x, y, w, h, rw, rh));
    }
    
    async CreateFoobarEllipse (hwnd: number, x: number, y: number, w: number, h: number): Promise<number>{
    return Number( await this.exec(72,hwnd, x, y, w, h));
    }
    
    async CreateFoobarCustom (hwnd: number, x: number, y: number, pic: string, trans_color: string, sim: number): Promise<number>{
    return Number( await this.exec(73,hwnd, x, y, pic, trans_color, sim));
    }
    
    async FoobarFillRect (hwnd: number, x1: number, y1: number, x2: number, y2: number, color: string): Promise<number>{
    return Number( await this.exec(74,hwnd, x1, y1, x2, y2, color));
    }
    
    async FoobarDrawText (hwnd: number, x: number, y: number, w: number, h: number, text: string, color: string, align: number): Promise<number>{
    return Number( await this.exec(75,hwnd, x, y, w, h, text, color, align));
    }
    
    async FoobarDrawPic (hwnd: number, x: number, y: number, pic: string, trans_color: string): Promise<number>{
    return Number( await this.exec(76,hwnd, x, y, pic, trans_color));
    }
    
    async FoobarUpdate (hwnd: number): Promise<number>{
    return Number( await this.exec(77,hwnd));
    }
    
    async FoobarLock (hwnd: number): Promise<number>{
    return Number( await this.exec(78,hwnd));
    }
    
    async FoobarUnlock (hwnd: number): Promise<number>{
    return Number( await this.exec(79,hwnd));
    }
    
    async FoobarSetFont (hwnd: number, font_name: string, size: number, flag: number): Promise<number>{
    return Number( await this.exec(80,hwnd, font_name, size, flag));
    }
    
    async FoobarTextRect (hwnd: number, x: number, y: number, w: number, h: number): Promise<number>{
    return Number( await this.exec(81,hwnd, x, y, w, h));
    }
    
    async FoobarPrintText (hwnd: number, text: string, color: string): Promise<number>{
    return Number( await this.exec(82,hwnd, text, color));
    }
    
    async FoobarClearText (hwnd: number): Promise<number>{
    return Number( await this.exec(83,hwnd));
    }
    
    async FoobarTextLineGap (hwnd: number, gap: number): Promise<number>{
    return Number( await this.exec(84,hwnd, gap));
    }
    
    async Play (file: string): Promise<number>{
    return Number( await this.exec(85,file));
    }
    
    async FaqCapture (x1: number, y1: number, x2: number, y2: number, quality: number, delay: number, time: number): Promise<number>{
    return Number( await this.exec(86,x1, y1, x2, y2, quality, delay, time));
    }
    
    async FaqRelease (handle: number): Promise<number>{
    return Number( await this.exec(87,handle));
    }
    
    async FaqSend (server: string, handle: number, request_type: number, time_out: number): Promise<string>{
    return  await this.exec(88,server, handle, request_type, time_out);
    }
    
    async Beep (fre: number, delay: number): Promise<number>{
    return Number( await this.exec(89,fre, delay));
    }
    
    async FoobarClose (hwnd: number): Promise<number>{
    return Number( await this.exec(90,hwnd));
    }
    
    async MoveDD (dx: number, dy: number): Promise<number>{
    return Number( await this.exec(91,dx, dy));
    }
    
    async FaqGetSize (handle: number): Promise<number>{
    return Number( await this.exec(92,handle));
    }
    
    async LoadPic (pic_name: string): Promise<number>{
    return Number( await this.exec(93,pic_name));
    }
    
    async FreePic (pic_name: string): Promise<number>{
    return Number( await this.exec(94,pic_name));
    }
    
    async GetScreenData (x1: number, y1: number, x2: number, y2: number): Promise<number>{
    return Number( await this.exec(95,x1, y1, x2, y2));
    }
    
    async FreeScreenData (handle: number): Promise<number>{
    return Number( await this.exec(96,handle));
    }
    
    async WheelUp (): Promise<number>{
    return Number( await this.exec(97));
    }
    
    async WheelDown (): Promise<number>{
    return Number( await this.exec(98));
    }
    
    async SetMouseDelay (type: string, delay: number): Promise<number>{
    return Number( await this.exec(99,type, delay));
    }
    
    async SetKeypadDelay (type: string, delay: number): Promise<number>{
    return Number( await this.exec(100,type, delay));
    }
    
    async GetEnv (index: number, name: string): Promise<string>{
    return  await this.exec(101,index, name);
    }
    
    async SetEnv (index: number, name: string, value: string): Promise<number>{
    return Number( await this.exec(102,index, name, value));
    }
    
    async SendString (hwnd: number, str: string): Promise<number>{
    return Number( await this.exec(103,hwnd, str));
    }
    
    async DelEnv (index: number, name: string): Promise<number>{
    return Number( await this.exec(104,index, name));
    }
    
    async GetPath (): Promise<string>{
    return  await this.exec(105);
    }
    
    async SetDict (index: number, dict_name: string): Promise<number>{
    return Number( await this.exec(106,index, dict_name));
    }
    
    async FindPic (x1: number, y1: number, x2: number, y2: number, pic_name: string, delta_color: string, sim: number, dir: number): Promise<[number,number,number]>{
    const resStr = await this.exec(107,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async FindPicEx (x1: number, y1: number, x2: number, y2: number, pic_name: string, delta_color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(108,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    async SetClientSize (hwnd: number, width: number, height: number): Promise<number>{
    return Number( await this.exec(109,hwnd, width, height));
    }
    
    async ReadInt (hwnd: number, addr: string, type: number): Promise<number>{
    return Number( await this.exec(110,hwnd, addr, type));
    }
    
    async ReadFloat (hwnd: number, addr: string): Promise<number>{
    return Number( await this.exec(111,hwnd, addr));
    }
    
    async ReadDouble (hwnd: number, addr: string): Promise<number>{
    return Number( await this.exec(112,hwnd, addr));
    }
    
    async FindInt (hwnd: number, addr_range: string, int_value_min: number, int_value_max: number, type: number): Promise<string>{
    return  await this.exec(113,hwnd, addr_range, int_value_min, int_value_max, type);
    }
    
    async FindFloat (hwnd: number, addr_range: string, float_value_min: number, float_value_max: number): Promise<string>{
    return  await this.exec(114,hwnd, addr_range, float_value_min, float_value_max);
    }
    
    async FindDouble (hwnd: number, addr_range: string, double_value_min: number, double_value_max: number): Promise<string>{
    return  await this.exec(115,hwnd, addr_range, double_value_min, double_value_max);
    }
    
    async FindString (hwnd: number, addr_range: string, string_value: string, type: number): Promise<string>{
    return  await this.exec(116,hwnd, addr_range, string_value, type);
    }
    
    async GetModuleBaseAddr (hwnd: number, module_name: string): Promise<number>{
    return Number( await this.exec(117,hwnd, module_name));
    }
    
    async MoveToEx (x: number, y: number, w: number, h: number): Promise<string>{
    return  await this.exec(118,x, y, w, h);
    }
    
    async MatchPicName (pic_name: string): Promise<string>{
    return  await this.exec(119,pic_name);
    }
    
    async AddDict (index: number, dict_info: string): Promise<number>{
    return Number( await this.exec(120,index, dict_info));
    }
    
    async EnterCri (): Promise<number>{
    return Number( await this.exec(121));
    }
    
    async LeaveCri (): Promise<number>{
    return Number( await this.exec(122));
    }
    
    async WriteInt (hwnd: number, addr: string, type: number, v: number): Promise<number>{
    return Number( await this.exec(123,hwnd, addr, type, v));
    }
    
    async WriteFloat (hwnd: number, addr: string, v: number): Promise<number>{
    return Number( await this.exec(124,hwnd, addr, v));
    }
    
    async WriteDouble (hwnd: number, addr: string, v: number): Promise<number>{
    return Number( await this.exec(125,hwnd, addr, v));
    }
    
    async WriteString (hwnd: number, addr: string, type: number, v: string): Promise<number>{
    return Number( await this.exec(126,hwnd, addr, type, v));
    }
    
    async AsmAdd (asm_ins: string): Promise<number>{
    return Number( await this.exec(127,asm_ins));
    }
    
    async AsmClear (): Promise<number>{
    return Number( await this.exec(128));
    }
    
    async AsmCall (hwnd: number, mode: number): Promise<number>{
    return Number( await this.exec(129,hwnd, mode));
    }
    
    async FindMultiColor (x1: number, y1: number, x2: number, y2: number, first_color: string, offset_color: string, sim: number, dir: number): Promise<[number,number,number]>{
    const resStr = await this.exec(130,x1, y1, x2, y2, first_color, offset_color, sim, dir);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async FindMultiColorEx (x1: number, y1: number, x2: number, y2: number, first_color: string, offset_color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(131,x1, y1, x2, y2, first_color, offset_color, sim, dir);
    }
    
    async Assemble (base_addr: number, is_64bit: number): Promise<string>{
    return  await this.exec(132,base_addr, is_64bit);
    }
    
    async DisAssemble (asm_code: string, base_addr: number, is_64bit: number): Promise<string>{
    return  await this.exec(133,asm_code, base_addr, is_64bit);
    }
    
    async SetWindowTransparent (hwnd: number, v: number): Promise<number>{
    return Number( await this.exec(134,hwnd, v));
    }
    
    async ReadData (hwnd: number, addr: string, len: number): Promise<string>{
    return  await this.exec(135,hwnd, addr, len);
    }
    
    async WriteData (hwnd: number, addr: string, data: string): Promise<number>{
    return Number( await this.exec(136,hwnd, addr, data));
    }
    
    async FindData (hwnd: number, addr_range: string, data: string): Promise<string>{
    return  await this.exec(137,hwnd, addr_range, data);
    }
    
    async SetPicPwd (pwd: string): Promise<number>{
    return Number( await this.exec(138,pwd));
    }
    
    async Log (info: string): Promise<number>{
    return Number( await this.exec(139,info));
    }
    
    async FindStrE (x1: number, y1: number, x2: number, y2: number, str: string, color: string, sim: number): Promise<string>{
    return  await this.exec(140,x1, y1, x2, y2, str, color, sim);
    }
    
    async FindColorE (x1: number, y1: number, x2: number, y2: number, color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(141,x1, y1, x2, y2, color, sim, dir);
    }
    
    async FindPicE (x1: number, y1: number, x2: number, y2: number, pic_name: string, delta_color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(142,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    async FindMultiColorE (x1: number, y1: number, x2: number, y2: number, first_color: string, offset_color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(143,x1, y1, x2, y2, first_color, offset_color, sim, dir);
    }
    
    async SetExactOcr (exact_ocr: number): Promise<number>{
    return Number( await this.exec(144,exact_ocr));
    }
    
    async ReadString (hwnd: number, addr: string, type: number, len: number): Promise<string>{
    return  await this.exec(145,hwnd, addr, type, len);
    }
    
    async FoobarTextPrintDir (hwnd: number, dir: number): Promise<number>{
    return Number( await this.exec(146,hwnd, dir));
    }
    
    async OcrEx (x1: number, y1: number, x2: number, y2: number, color: string, sim: number): Promise<string>{
    return  await this.exec(147,x1, y1, x2, y2, color, sim);
    }
    
    async SetDisplayInput (mode: string): Promise<number>{
    return Number( await this.exec(148,mode));
    }
    
    async GetTime (): Promise<number>{
    return Number( await this.exec(149));
    }
    
    async GetScreenWidth (): Promise<number>{
    return Number( await this.exec(150));
    }
    
    async GetScreenHeight (): Promise<number>{
    return Number( await this.exec(151));
    }
    
    async BindWindowEx (hwnd: number, display: string, mouse: string, keypad: string, public_desc: string, mode: number): Promise<number>{
    return Number( await this.exec(152,hwnd, display, mouse, keypad, public_desc, mode));
    }
    
    async GetDiskSerial (index: number): Promise<string>{
    return  await this.exec(153,index);
    }
    
    async Md5 (str: string): Promise<string>{
    return  await this.exec(154,str);
    }
    
    async GetMac (): Promise<string>{
    return  await this.exec(155);
    }
    
    async ActiveInputMethod (hwnd: number, id: string): Promise<number>{
    return Number( await this.exec(156,hwnd, id));
    }
    
    async CheckInputMethod (hwnd: number, id: string): Promise<number>{
    return Number( await this.exec(157,hwnd, id));
    }
    
    async FindInputMethod (id: string): Promise<number>{
    return Number( await this.exec(158,id));
    }
    
    async GetCursorPos (): Promise<[number,number,number]>{
    const resStr = await this.exec(159,);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async BindWindow (hwnd: number, display: string, mouse: string, keypad: string, mode: number): Promise<number>{
    return Number( await this.exec(160,hwnd, display, mouse, keypad, mode));
    }
    
    async FindWindow (class_name: string, title_name: string): Promise<number>{
    return Number( await this.exec(161,class_name, title_name));
    }
    
    async GetScreenDepth (): Promise<number>{
    return Number( await this.exec(162));
    }
    
    async SetScreen (width: number, height: number, depth: number): Promise<number>{
    return Number( await this.exec(163,width, height, depth));
    }
    
    async ExitOs (type: number): Promise<number>{
    return Number( await this.exec(164,type));
    }
    
    async GetDir (type: number): Promise<string>{
    return  await this.exec(165,type);
    }
    
    async GetOsType (): Promise<number>{
    return Number( await this.exec(166));
    }
    
    async FindWindowEx (parent: number, class_name: string, title_name: string): Promise<number>{
    return Number( await this.exec(167,parent, class_name, title_name));
    }
    
    async SetExportDict (index: number, dict_name: string): Promise<number>{
    return Number( await this.exec(168,index, dict_name));
    }
    
    async GetCursorShape (): Promise<string>{
    return  await this.exec(169);
    }
    
    async DownCpu (type: number, rate: number): Promise<number>{
    return Number( await this.exec(170,type, rate));
    }
    
    async GetCursorSpot (): Promise<string>{
    return  await this.exec(171);
    }
    
    async SendString2 (hwnd: number, str: string): Promise<number>{
    return Number( await this.exec(172,hwnd, str));
    }
    
    async FaqPost (server: string, handle: number, request_type: number, time_out: number): Promise<number>{
    return Number( await this.exec(173,server, handle, request_type, time_out));
    }
    
    async FaqFetch (): Promise<string>{
    return  await this.exec(174);
    }
    
    async FetchWord (x1: number, y1: number, x2: number, y2: number, color: string, word: string): Promise<string>{
    return  await this.exec(175,x1, y1, x2, y2, color, word);
    }
    
    async CaptureJpg (x1: number, y1: number, x2: number, y2: number, file: string, quality: number): Promise<number>{
    return Number( await this.exec(176,x1, y1, x2, y2, file, quality));
    }
    
    async FindStrWithFont (x1: number, y1: number, x2: number, y2: number, str: string, color: string, sim: number, font_name: string, font_size: number, flag: number): Promise<[number,number,number]>{
    const resStr = await this.exec(177,x1, y1, x2, y2, str, color, sim, font_name, font_size, flag);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async FindStrWithFontE (x1: number, y1: number, x2: number, y2: number, str: string, color: string, sim: number, font_name: string, font_size: number, flag: number): Promise<string>{
    return  await this.exec(178,x1, y1, x2, y2, str, color, sim, font_name, font_size, flag);
    }
    
    async FindStrWithFontEx (x1: number, y1: number, x2: number, y2: number, str: string, color: string, sim: number, font_name: string, font_size: number, flag: number): Promise<string>{
    return  await this.exec(179,x1, y1, x2, y2, str, color, sim, font_name, font_size, flag);
    }
    
    async GetDictInfo (str: string, font_name: string, font_size: number, flag: number): Promise<string>{
    return  await this.exec(180,str, font_name, font_size, flag);
    }
    
    async SaveDict (index: number, file: string): Promise<number>{
    return Number( await this.exec(181,index, file));
    }
    
    async GetWindowProcessId (hwnd: number): Promise<number>{
    return Number( await this.exec(182,hwnd));
    }
    
    async GetWindowProcessPath (hwnd: number): Promise<string>{
    return  await this.exec(183,hwnd);
    }
    
    async LockInput (lock: number): Promise<number>{
    return Number( await this.exec(184,lock));
    }
    
    async GetPicSize (pic_name: string): Promise<string>{
    return  await this.exec(185,pic_name);
    }
    
    async GetID (): Promise<number>{
    return Number( await this.exec(186));
    }
    
    async CapturePng (x1: number, y1: number, x2: number, y2: number, file: string): Promise<number>{
    return Number( await this.exec(187,x1, y1, x2, y2, file));
    }
    
    async CaptureGif (x1: number, y1: number, x2: number, y2: number, file: string, delay: number, time: number): Promise<number>{
    return Number( await this.exec(188,x1, y1, x2, y2, file, delay, time));
    }
    
    async ImageToBmp (pic_name: string, bmp_name: string): Promise<number>{
    return Number( await this.exec(189,pic_name, bmp_name));
    }
    
    async FindStrFast (x1: number, y1: number, x2: number, y2: number, str: string, color: string, sim: number): Promise<[number,number,number]>{
    const resStr = await this.exec(190,x1, y1, x2, y2, str, color, sim);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async FindStrFastEx (x1: number, y1: number, x2: number, y2: number, str: string, color: string, sim: number): Promise<string>{
    return  await this.exec(191,x1, y1, x2, y2, str, color, sim);
    }
    
    async FindStrFastE (x1: number, y1: number, x2: number, y2: number, str: string, color: string, sim: number): Promise<string>{
    return  await this.exec(192,x1, y1, x2, y2, str, color, sim);
    }
    
    async EnableDisplayDebug (enable_debug: number): Promise<number>{
    return Number( await this.exec(193,enable_debug));
    }
    
    async CapturePre (file: string): Promise<number>{
    return Number( await this.exec(194,file));
    }
    
    async RegEx (code: string, Ver: string, ip: string): Promise<number>{
    return Number( await this.exec(195,code, Ver, ip));
    }
    
    async GetMachineCode (): Promise<string>{
    return  await this.exec(196);
    }
    
    async SetClipboard (data: string): Promise<number>{
    return Number( await this.exec(197,data));
    }
    
    async GetClipboard (): Promise<string>{
    return  await this.exec(198);
    }
    
    async GetNowDict (): Promise<number>{
    return Number( await this.exec(199));
    }
    
    async Is64Bit (): Promise<number>{
    return Number( await this.exec(200));
    }
    
    async GetColorNum (x1: number, y1: number, x2: number, y2: number, color: string, sim: number): Promise<number>{
    return Number( await this.exec(201,x1, y1, x2, y2, color, sim));
    }
    
    async EnumWindowByProcess (process_name: string, title: string, class_name: string, filter: number): Promise<string>{
    return  await this.exec(202,process_name, title, class_name, filter);
    }
    
    async GetDictCount (index: number): Promise<number>{
    return Number( await this.exec(203,index));
    }
    
    async GetLastError (): Promise<number>{
    return Number( await this.exec(204));
    }
    
    async GetNetTime (): Promise<string>{
    return  await this.exec(205);
    }
    
    async EnableGetColorByCapture (en: number): Promise<number>{
    return Number( await this.exec(206,en));
    }
    
    async CheckUAC (): Promise<number>{
    return Number( await this.exec(207));
    }
    
    async SetUAC (uac: number): Promise<number>{
    return Number( await this.exec(208,uac));
    }
    
    async DisableFontSmooth (): Promise<number>{
    return Number( await this.exec(209));
    }
    
    async CheckFontSmooth (): Promise<number>{
    return Number( await this.exec(210));
    }
    
    async SetDisplayAcceler (level: number): Promise<number>{
    return Number( await this.exec(211,level));
    }
    
    async FindWindowByProcess (process_name: string, class_name: string, title_name: string): Promise<number>{
    return Number( await this.exec(212,process_name, class_name, title_name));
    }
    
    async FindWindowByProcessId (process_id: number, class_name: string, title_name: string): Promise<number>{
    return Number( await this.exec(213,process_id, class_name, title_name));
    }
    
    async ReadIni (section: string, key: string, file: string): Promise<string>{
    return  await this.exec(214,section, key, file);
    }
    
    async WriteIni (section: string, key: string, v: string, file: string): Promise<number>{
    return Number( await this.exec(215,section, key, v, file));
    }
    
    async RunApp (path: string, mode: number): Promise<number>{
    return Number( await this.exec(216,path, mode));
    }
    
    async delay (mis: number): Promise<number>{
    return Number( await this.exec(217,mis));
    }
    
    async FindWindowSuper (spec1: string, flag1: number, type1: number, spec2: string, flag2: number, type2: number): Promise<number>{
    return Number( await this.exec(218,spec1, flag1, type1, spec2, flag2, type2));
    }
    
    async ExcludePos (all_pos: string, type: number, x1: number, y1: number, x2: number, y2: number): Promise<string>{
    return  await this.exec(219,all_pos, type, x1, y1, x2, y2);
    }
    
    async FindNearestPos (all_pos: string, type: number, x: number, y: number): Promise<string>{
    return  await this.exec(220,all_pos, type, x, y);
    }
    
    async SortPosDistance (all_pos: string, type: number, x: number, y: number): Promise<string>{
    return  await this.exec(221,all_pos, type, x, y);
    }
    
    async FindPicMem (x1: number, y1: number, x2: number, y2: number, pic_info: string, delta_color: string, sim: number, dir: number): Promise<[number,number,number]>{
    const resStr = await this.exec(222,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async FindPicMemEx (x1: number, y1: number, x2: number, y2: number, pic_info: string, delta_color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(223,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    }
    
    async FindPicMemE (x1: number, y1: number, x2: number, y2: number, pic_info: string, delta_color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(224,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    }
    
    async AppendPicAddr (pic_info: string, addr: number, size: number): Promise<string>{
    return  await this.exec(225,pic_info, addr, size);
    }
    
    async WriteFile (file: string, content: string): Promise<number>{
    return Number( await this.exec(226,file, content));
    }
    
    async Stop (id: number): Promise<number>{
    return Number( await this.exec(227,id));
    }
    
    async SetDictMem (index: number, addr: number, size: number): Promise<number>{
    return Number( await this.exec(228,index, addr, size));
    }
    
    async GetNetTimeSafe (): Promise<string>{
    return  await this.exec(229);
    }
    
    async ForceUnBindWindow (hwnd: number): Promise<number>{
    return Number( await this.exec(230,hwnd));
    }
    
    async ReadIniPwd (section: string, key: string, file: string, pwd: string): Promise<string>{
    return  await this.exec(231,section, key, file, pwd);
    }
    
    async WriteIniPwd (section: string, key: string, v: string, file: string, pwd: string): Promise<number>{
    return Number( await this.exec(232,section, key, v, file, pwd));
    }
    
    async DecodeFile (file: string, pwd: string): Promise<number>{
    return Number( await this.exec(233,file, pwd));
    }
    
    async KeyDownChar (key_str: string): Promise<number>{
    return Number( await this.exec(234,key_str));
    }
    
    async KeyUpChar (key_str: string): Promise<number>{
    return Number( await this.exec(235,key_str));
    }
    
    async KeyPressChar (key_str: string): Promise<number>{
    return Number( await this.exec(236,key_str));
    }
    
    async KeyPressStr (key_str: string, delay: number): Promise<number>{
    return Number( await this.exec(237,key_str, delay));
    }
    
    async EnableKeypadPatch (en: number): Promise<number>{
    return Number( await this.exec(238,en));
    }
    
    async EnableKeypadSync (en: number, time_out: number): Promise<number>{
    return Number( await this.exec(239,en, time_out));
    }
    
    async EnableMouseSync (en: number, time_out: number): Promise<number>{
    return Number( await this.exec(240,en, time_out));
    }
    
    async DmGuard (en: number, type: string): Promise<number>{
    return Number( await this.exec(241,en, type));
    }
    
    async FaqCaptureFromFile (x1: number, y1: number, x2: number, y2: number, file: string, quality: number): Promise<number>{
    return Number( await this.exec(242,x1, y1, x2, y2, file, quality));
    }
    
    async FindIntEx (hwnd: number, addr_range: string, int_value_min: number, int_value_max: number, type: number, step: number, multi_thread: number, mode: number): Promise<string>{
    return  await this.exec(243,hwnd, addr_range, int_value_min, int_value_max, type, step, multi_thread, mode);
    }
    
    async FindFloatEx (hwnd: number, addr_range: string, float_value_min: number, float_value_max: number, step: number, multi_thread: number, mode: number): Promise<string>{
    return  await this.exec(244,hwnd, addr_range, float_value_min, float_value_max, step, multi_thread, mode);
    }
    
    async FindDoubleEx (hwnd: number, addr_range: string, double_value_min: number, double_value_max: number, step: number, multi_thread: number, mode: number): Promise<string>{
    return  await this.exec(245,hwnd, addr_range, double_value_min, double_value_max, step, multi_thread, mode);
    }
    
    async FindStringEx (hwnd: number, addr_range: string, string_value: string, type: number, step: number, multi_thread: number, mode: number): Promise<string>{
    return  await this.exec(246,hwnd, addr_range, string_value, type, step, multi_thread, mode);
    }
    
    async FindDataEx (hwnd: number, addr_range: string, data: string, step: number, multi_thread: number, mode: number): Promise<string>{
    return  await this.exec(247,hwnd, addr_range, data, step, multi_thread, mode);
    }
    
    async EnableRealMouse (en: number, mousedelay: number, mousestep: number): Promise<number>{
    return Number( await this.exec(248,en, mousedelay, mousestep));
    }
    
    async EnableRealKeypad (en: number): Promise<number>{
    return Number( await this.exec(249,en));
    }
    
    async SendStringIme (str: string): Promise<number>{
    return Number( await this.exec(250,str));
    }
    
    async FoobarDrawLine (hwnd: number, x1: number, y1: number, x2: number, y2: number, color: string, style: number, width: number): Promise<number>{
    return Number( await this.exec(251,hwnd, x1, y1, x2, y2, color, style, width));
    }
    
    async FindStrEx (x1: number, y1: number, x2: number, y2: number, str: string, color: string, sim: number): Promise<string>{
    return  await this.exec(252,x1, y1, x2, y2, str, color, sim);
    }
    
    async IsBind (hwnd: number): Promise<number>{
    return Number( await this.exec(253,hwnd));
    }
    
    async SetDisplayDelay (t: number): Promise<number>{
    return Number( await this.exec(254,t));
    }
    
    async GetDmCount (): Promise<number>{
    return Number( await this.exec(255));
    }
    
    async DisableScreenSave (): Promise<number>{
    return Number( await this.exec(256));
    }
    
    async DisablePowerSave (): Promise<number>{
    return Number( await this.exec(257));
    }
    
    async SetMemoryHwndAsProcessId (en: number): Promise<number>{
    return Number( await this.exec(258,en));
    }
    
    async FindShape (x1: number, y1: number, x2: number, y2: number, offset_color: string, sim: number, dir: number): Promise<[number,number,number]>{
    const resStr = await this.exec(259,x1, y1, x2, y2, offset_color, sim, dir);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async FindShapeE (x1: number, y1: number, x2: number, y2: number, offset_color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(260,x1, y1, x2, y2, offset_color, sim, dir);
    }
    
    async FindShapeEx (x1: number, y1: number, x2: number, y2: number, offset_color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(261,x1, y1, x2, y2, offset_color, sim, dir);
    }
    
    async FindStrS (x1: number, y1: number, x2: number, y2: number, str: string, color: string, sim: number): Promise<[string,number,number]>{
    const resStr = await this.exec(262,x1, y1, x2, y2, str, color, sim);
    const resArray = resStr.split(",");
    return [resArray[0],Number(resArray[1]),Number(resArray[2])];
    }
    
    async FindStrExS (x1: number, y1: number, x2: number, y2: number, str: string, color: string, sim: number): Promise<string>{
    return  await this.exec(263,x1, y1, x2, y2, str, color, sim);
    }
    
    async FindStrFastS (x1: number, y1: number, x2: number, y2: number, str: string, color: string, sim: number): Promise<[string,number,number]>{
    const resStr = await this.exec(264,x1, y1, x2, y2, str, color, sim);
    const resArray = resStr.split(",");
    return [resArray[0],Number(resArray[1]),Number(resArray[2])];
    }
    
    async FindStrFastExS (x1: number, y1: number, x2: number, y2: number, str: string, color: string, sim: number): Promise<string>{
    return  await this.exec(265,x1, y1, x2, y2, str, color, sim);
    }
    
    async FindPicS (x1: number, y1: number, x2: number, y2: number, pic_name: string, delta_color: string, sim: number, dir: number): Promise<[string,number,number]>{
    const resStr = await this.exec(266,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    const resArray = resStr.split(",");
    return [resArray[0],Number(resArray[1]),Number(resArray[2])];
    }
    
    async FindPicExS (x1: number, y1: number, x2: number, y2: number, pic_name: string, delta_color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(267,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    async ClearDict (index: number): Promise<number>{
    return Number( await this.exec(268,index));
    }
    
    async GetMachineCodeNoMac (): Promise<string>{
    return  await this.exec(269);
    }
    
    async GetClientRect (hwnd: number): Promise<[number,number,number,number,number]>{
    const resStr = await this.exec(270,hwnd);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2]),Number(resArray[3]),Number(resArray[4])];
    }
    
    async EnableFakeActive (en: number): Promise<number>{
    return Number( await this.exec(271,en));
    }
    
    async GetScreenDataBmp (x1: number, y1: number, x2: number, y2: number): Promise<[number,number,number]>{
    const resStr = await this.exec(272,x1, y1, x2, y2);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async EncodeFile (file: string, pwd: string): Promise<number>{
    return Number( await this.exec(273,file, pwd));
    }
    
    async GetCursorShapeEx (type: number): Promise<string>{
    return  await this.exec(274,type);
    }
    
    async FaqCancel (): Promise<number>{
    return Number( await this.exec(275));
    }
    
    async IntToData (int_value: number, type: number): Promise<string>{
    return  await this.exec(276,int_value, type);
    }
    
    async FloatToData (float_value: number): Promise<string>{
    return  await this.exec(277,float_value);
    }
    
    async DoubleToData (double_value: number): Promise<string>{
    return  await this.exec(278,double_value);
    }
    
    async StringToData (string_value: string, type: number): Promise<string>{
    return  await this.exec(279,string_value, type);
    }
    
    async SetMemoryFindResultToFile (file: string): Promise<number>{
    return Number( await this.exec(280,file));
    }
    
    async EnableBind (en: number): Promise<number>{
    return Number( await this.exec(281,en));
    }
    
    async SetSimMode (mode: number): Promise<number>{
    return Number( await this.exec(282,mode));
    }
    
    async LockMouseRect (x1: number, y1: number, x2: number, y2: number): Promise<number>{
    return Number( await this.exec(283,x1, y1, x2, y2));
    }
    
    async SendPaste (hwnd: number): Promise<number>{
    return Number( await this.exec(284,hwnd));
    }
    
    async IsDisplayDead (x1: number, y1: number, x2: number, y2: number, t: number): Promise<number>{
    return Number( await this.exec(285,x1, y1, x2, y2, t));
    }
    
    async GetKeyState (vk: number): Promise<number>{
    return Number( await this.exec(286,vk));
    }
    
    async CopyFile (src_file: string, dst_file: string, over: number): Promise<number>{
    return Number( await this.exec(287,src_file, dst_file, over));
    }
    
    async IsFileExist (file: string): Promise<number>{
    return Number( await this.exec(288,file));
    }
    
    async DeleteFile (file: string): Promise<number>{
    return Number( await this.exec(289,file));
    }
    
    async MoveFile (src_file: string, dst_file: string): Promise<number>{
    return Number( await this.exec(290,src_file, dst_file));
    }
    
    async CreateFolder (folder_name: string): Promise<number>{
    return Number( await this.exec(291,folder_name));
    }
    
    async DeleteFolder (folder_name: string): Promise<number>{
    return Number( await this.exec(292,folder_name));
    }
    
    async GetFileLength (file: string): Promise<number>{
    return Number( await this.exec(293,file));
    }
    
    async ReadFile (file: string): Promise<string>{
    return  await this.exec(294,file);
    }
    
    async WaitKey (key_code: number, time_out: number): Promise<number>{
    return Number( await this.exec(295,key_code, time_out));
    }
    
    async DeleteIni (section: string, key: string, file: string): Promise<number>{
    return Number( await this.exec(296,section, key, file));
    }
    
    async DeleteIniPwd (section: string, key: string, file: string, pwd: string): Promise<number>{
    return Number( await this.exec(297,section, key, file, pwd));
    }
    
    async EnableSpeedDx (en: number): Promise<number>{
    return Number( await this.exec(298,en));
    }
    
    async EnableIme (en: number): Promise<number>{
    return Number( await this.exec(299,en));
    }
    
    async Reg (code: string, Ver: string): Promise<number>{
    return Number( await this.exec(300,code, Ver));
    }
    
    async SelectFile (): Promise<string>{
    return  await this.exec(301);
    }
    
    async SelectDirectory (): Promise<string>{
    return  await this.exec(302);
    }
    
    async LockDisplay (lock: number): Promise<number>{
    return Number( await this.exec(303,lock));
    }
    
    async FoobarSetSave (hwnd: number, file: string, en: number, header: string): Promise<number>{
    return Number( await this.exec(304,hwnd, file, en, header));
    }
    
    async EnumWindowSuper (spec1: string, flag1: number, type1: number, spec2: string, flag2: number, type2: number, sort: number): Promise<string>{
    return  await this.exec(305,spec1, flag1, type1, spec2, flag2, type2, sort);
    }
    
    async DownloadFile (url: string, save_file: string, timeout: number): Promise<number>{
    return Number( await this.exec(306,url, save_file, timeout));
    }
    
    async EnableKeypadMsg (en: number): Promise<number>{
    return Number( await this.exec(307,en));
    }
    
    async EnableMouseMsg (en: number): Promise<number>{
    return Number( await this.exec(308,en));
    }
    
    async RegNoMac (code: string, Ver: string): Promise<number>{
    return Number( await this.exec(309,code, Ver));
    }
    
    async RegExNoMac (code: string, Ver: string, ip: string): Promise<number>{
    return Number( await this.exec(310,code, Ver, ip));
    }
    
    async SetEnumWindowDelay (delay: number): Promise<number>{
    return Number( await this.exec(311,delay));
    }
    
    async FindMulColor (x1: number, y1: number, x2: number, y2: number, color: string, sim: number): Promise<number>{
    return Number( await this.exec(312,x1, y1, x2, y2, color, sim));
    }
    
    async GetDict (index: number, font_index: number): Promise<string>{
    return  await this.exec(313,index, font_index);
    }
    
    async GetBindWindow (): Promise<number>{
    return Number( await this.exec(314));
    }
    
    async FoobarStartGif (hwnd: number, x: number, y: number, pic_name: string, repeat_limit: number, delay: number): Promise<number>{
    return Number( await this.exec(315,hwnd, x, y, pic_name, repeat_limit, delay));
    }
    
    async FoobarStopGif (hwnd: number, x: number, y: number, pic_name: string): Promise<number>{
    return Number( await this.exec(316,hwnd, x, y, pic_name));
    }
    
    async FreeProcessMemory (hwnd: number): Promise<number>{
    return Number( await this.exec(317,hwnd));
    }
    
    async ReadFileData (file: string, start_pos: number, end_pos: number): Promise<string>{
    return  await this.exec(318,file, start_pos, end_pos);
    }
    
    async VirtualAllocEx (hwnd: number, addr: number, size: number, type: number): Promise<number>{
    return Number( await this.exec(319,hwnd, addr, size, type));
    }
    
    async VirtualFreeEx (hwnd: number, addr: number): Promise<number>{
    return Number( await this.exec(320,hwnd, addr));
    }
    
    async GetCommandLine (hwnd: number): Promise<string>{
    return  await this.exec(321,hwnd);
    }
    
    async TerminateProcess (pid: number): Promise<number>{
    return Number( await this.exec(322,pid));
    }
    
    async GetNetTimeByIp (ip: string): Promise<string>{
    return  await this.exec(323,ip);
    }
    
    async EnumProcess (name: string): Promise<string>{
    return  await this.exec(324,name);
    }
    
    async GetProcessInfo (pid: number): Promise<string>{
    return  await this.exec(325,pid);
    }
    
    async ReadIntAddr (hwnd: number, addr: number, type: number): Promise<number>{
    return Number( await this.exec(326,hwnd, addr, type));
    }
    
    async ReadDataAddr (hwnd: number, addr: number, len: number): Promise<string>{
    return  await this.exec(327,hwnd, addr, len);
    }
    
    async ReadDoubleAddr (hwnd: number, addr: number): Promise<number>{
    return Number( await this.exec(328,hwnd, addr));
    }
    
    async ReadFloatAddr (hwnd: number, addr: number): Promise<number>{
    return Number( await this.exec(329,hwnd, addr));
    }
    
    async ReadStringAddr (hwnd: number, addr: number, type: number, len: number): Promise<string>{
    return  await this.exec(330,hwnd, addr, type, len);
    }
    
    async WriteDataAddr (hwnd: number, addr: number, data: string): Promise<number>{
    return Number( await this.exec(331,hwnd, addr, data));
    }
    
    async WriteDoubleAddr (hwnd: number, addr: number, v: number): Promise<number>{
    return Number( await this.exec(332,hwnd, addr, v));
    }
    
    async WriteFloatAddr (hwnd: number, addr: number, v: number): Promise<number>{
    return Number( await this.exec(333,hwnd, addr, v));
    }
    
    async WriteIntAddr (hwnd: number, addr: number, type: number, v: number): Promise<number>{
    return Number( await this.exec(334,hwnd, addr, type, v));
    }
    
    async WriteStringAddr (hwnd: number, addr: number, type: number, v: string): Promise<number>{
    return Number( await this.exec(335,hwnd, addr, type, v));
    }
    
    async Delays (min_s: number, max_s: number): Promise<number>{
    return Number( await this.exec(336,min_s, max_s));
    }
    
    async FindColorBlock (x1: number, y1: number, x2: number, y2: number, color: string, sim: number, count: number, width: number, height: number): Promise<[number,number,number]>{
    const resStr = await this.exec(337,x1, y1, x2, y2, color, sim, count, width, height);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async FindColorBlockEx (x1: number, y1: number, x2: number, y2: number, color: string, sim: number, count: number, width: number, height: number): Promise<string>{
    return  await this.exec(338,x1, y1, x2, y2, color, sim, count, width, height);
    }
    
    async OpenProcess (pid: number): Promise<number>{
    return Number( await this.exec(339,pid));
    }
    
    async EnumIniSection (file: string): Promise<string>{
    return  await this.exec(340,file);
    }
    
    async EnumIniSectionPwd (file: string, pwd: string): Promise<string>{
    return  await this.exec(341,file, pwd);
    }
    
    async EnumIniKey (section: string, file: string): Promise<string>{
    return  await this.exec(342,section, file);
    }
    
    async EnumIniKeyPwd (section: string, file: string, pwd: string): Promise<string>{
    return  await this.exec(343,section, file, pwd);
    }
    
    async SwitchBindWindow (hwnd: number): Promise<number>{
    return Number( await this.exec(344,hwnd));
    }
    
    async InitCri (): Promise<number>{
    return Number( await this.exec(345));
    }
    
    async SendStringIme2 (hwnd: number, str: string, mode: number): Promise<number>{
    return Number( await this.exec(346,hwnd, str, mode));
    }
    
    async EnumWindowByProcessId (pid: number, title: string, class_name: string, filter: number): Promise<string>{
    return  await this.exec(347,pid, title, class_name, filter);
    }
    
    async GetDisplayInfo (): Promise<string>{
    return  await this.exec(348);
    }
    
    async EnableFontSmooth (): Promise<number>{
    return Number( await this.exec(349));
    }
    
    async OcrExOne (x1: number, y1: number, x2: number, y2: number, color: string, sim: number): Promise<string>{
    return  await this.exec(350,x1, y1, x2, y2, color, sim);
    }
    
    async SetAero (en: number): Promise<number>{
    return Number( await this.exec(351,en));
    }
    
    async FoobarSetTrans (hwnd: number, trans: number, color: string, sim: number): Promise<number>{
    return Number( await this.exec(352,hwnd, trans, color, sim));
    }
    
    async EnablePicCache (en: number): Promise<number>{
    return Number( await this.exec(353,en));
    }
    
    async FaqIsPosted (): Promise<number>{
    return Number( await this.exec(354));
    }
    
    async LoadPicByte (addr: number, size: number, name: string): Promise<number>{
    return Number( await this.exec(355,addr, size, name));
    }
    
    async MiddleDown (): Promise<number>{
    return Number( await this.exec(356));
    }
    
    async MiddleUp (): Promise<number>{
    return Number( await this.exec(357));
    }
    
    async FaqCaptureString (str: string): Promise<number>{
    return Number( await this.exec(358,str));
    }
    
    async VirtualProtectEx (hwnd: number, addr: number, size: number, type: number, old_protect: number): Promise<number>{
    return Number( await this.exec(359,hwnd, addr, size, type, old_protect));
    }
    
    async SetMouseSpeed (speed: number): Promise<number>{
    return Number( await this.exec(360,speed));
    }
    
    async GetMouseSpeed (): Promise<number>{
    return Number( await this.exec(361));
    }
    
    async EnableMouseAccuracy (en: number): Promise<number>{
    return Number( await this.exec(362,en));
    }
    
    async SetExcludeRegion (type: number, info: string): Promise<number>{
    return Number( await this.exec(363,type, info));
    }
    
    async EnableShareDict (en: number): Promise<number>{
    return Number( await this.exec(364,en));
    }
    
    async DisableCloseDisplayAndSleep (): Promise<number>{
    return Number( await this.exec(365));
    }
    
    async Int64ToInt32 (v: number): Promise<number>{
    return Number( await this.exec(366,v));
    }
    
    async GetLocale (): Promise<number>{
    return Number( await this.exec(367));
    }
    
    async SetLocale (): Promise<number>{
    return Number( await this.exec(368));
    }
    
    async ReadDataToBin (hwnd: number, addr: string, len: number): Promise<number>{
    return Number( await this.exec(369,hwnd, addr, len));
    }
    
    async WriteDataFromBin (hwnd: number, addr: string, data: number, len: number): Promise<number>{
    return Number( await this.exec(370,hwnd, addr, data, len));
    }
    
    async ReadDataAddrToBin (hwnd: number, addr: number, len: number): Promise<number>{
    return Number( await this.exec(371,hwnd, addr, len));
    }
    
    async WriteDataAddrFromBin (hwnd: number, addr: number, data: number, len: number): Promise<number>{
    return Number( await this.exec(372,hwnd, addr, data, len));
    }
    
    async SetParam64ToPointer (): Promise<number>{
    return Number( await this.exec(373));
    }
    
    async GetDPI (): Promise<number>{
    return Number( await this.exec(374));
    }
    
    async SetDisplayRefreshDelay (t: number): Promise<number>{
    return Number( await this.exec(375,t));
    }
    
    async IsFolderExist (folder: string): Promise<number>{
    return Number( await this.exec(376,folder));
    }
    
    async GetCpuType (): Promise<number>{
    return Number( await this.exec(377));
    }
    
    async ReleaseRef (): Promise<number>{
    return Number( await this.exec(378));
    }
    
    async SetExitThread (en: number): Promise<number>{
    return Number( await this.exec(379,en));
    }
    
    async GetFps (): Promise<number>{
    return Number( await this.exec(380));
    }
    
    async VirtualQueryEx (hwnd: number, addr: number, pmbi: number): Promise<string>{
    return  await this.exec(381,hwnd, addr, pmbi);
    }
    
    async AsmCallEx (hwnd: number, mode: number, base_addr: string): Promise<number>{
    return Number( await this.exec(382,hwnd, mode, base_addr));
    }
    
    async GetRemoteApiAddress (hwnd: number, base_addr: number, fun_name: string): Promise<number>{
    return Number( await this.exec(383,hwnd, base_addr, fun_name));
    }
    
    async ExecuteCmd (cmd: string, current_dir: string, time_out: number): Promise<string>{
    return  await this.exec(384,cmd, current_dir, time_out);
    }
    
    async SpeedNormalGraphic (en: number): Promise<number>{
    return Number( await this.exec(385,en));
    }
    
    async UnLoadDriver (): Promise<number>{
    return Number( await this.exec(386));
    }
    
    async GetOsBuildNumber (): Promise<number>{
    return Number( await this.exec(387));
    }
    
    async HackSpeed (rate: number): Promise<number>{
    return Number( await this.exec(388,rate));
    }
    
    async GetRealPath (path: string): Promise<string>{
    return  await this.exec(389,path);
    }
    
    async ShowTaskBarIcon (hwnd: number, is_show: number): Promise<number>{
    return Number( await this.exec(390,hwnd, is_show));
    }
    
    async AsmSetTimeout (time_out: number, param: number): Promise<number>{
    return Number( await this.exec(391,time_out, param));
    }
    
    async DmGuardParams (cmd: string, sub_cmd: string, param: string): Promise<string>{
    return  await this.exec(392,cmd, sub_cmd, param);
    }
    
    async GetModuleSize (hwnd: number, module_name: string): Promise<number>{
    return Number( await this.exec(393,hwnd, module_name));
    }
    
    async IsSurrpotVt (): Promise<number>{
    return Number( await this.exec(394));
    }
    
    async GetDiskModel (index: number): Promise<string>{
    return  await this.exec(395,index);
    }
    
    async GetDiskReversion (index: number): Promise<string>{
    return  await this.exec(396,index);
    }
    
    async EnableFindPicMultithread (en: number): Promise<number>{
    return Number( await this.exec(397,en));
    }
    
    async GetCpuUsage (): Promise<number>{
    return Number( await this.exec(398));
    }
    
    async GetMemoryUsage (): Promise<number>{
    return Number( await this.exec(399));
    }
    
    async Hex32 (v: number): Promise<string>{
    return  await this.exec(400,v);
    }
    
    async Hex64 (v: number): Promise<string>{
    return  await this.exec(401,v);
    }
    
    async GetWindowThreadId (hwnd: number): Promise<number>{
    return Number( await this.exec(402,hwnd));
    }
    
    async DmGuardExtract (type: string, path: string): Promise<number>{
    return Number( await this.exec(403,type, path));
    }
    
    async DmGuardLoadCustom (type: string, path: string): Promise<number>{
    return Number( await this.exec(404,type, path));
    }
    
    async SetShowAsmErrorMsg (show: number): Promise<number>{
    return Number( await this.exec(405,show));
    }
    
    async GetSystemInfo (type: string, method: number): Promise<string>{
    return  await this.exec(406,type, method);
    }
    
    async SetFindPicMultithreadCount (count: number): Promise<number>{
    return Number( await this.exec(407,count));
    }
    
    async FindPicSim (x1: number, y1: number, x2: number, y2: number, pic_name: string, delta_color: string, sim: number, dir: number): Promise<[number,number,number]>{
    const resStr = await this.exec(408,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async FindPicSimEx (x1: number, y1: number, x2: number, y2: number, pic_name: string, delta_color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(409,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    async FindPicSimMem (x1: number, y1: number, x2: number, y2: number, pic_info: string, delta_color: string, sim: number, dir: number): Promise<[number,number,number]>{
    const resStr = await this.exec(410,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    const resArray = resStr.split(",");
    return [Number(resArray[0]),Number(resArray[1]),Number(resArray[2])];
    }
    
    async FindPicSimMemEx (x1: number, y1: number, x2: number, y2: number, pic_info: string, delta_color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(411,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    }
    
    async FindPicSimE (x1: number, y1: number, x2: number, y2: number, pic_name: string, delta_color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(412,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    async FindPicSimMemE (x1: number, y1: number, x2: number, y2: number, pic_info: string, delta_color: string, sim: number, dir: number): Promise<string>{
    return  await this.exec(413,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    }
    
    async SetInputDm (input_dm: number, rx: number, ry: number): Promise<number>{
    return Number( await this.exec(414,input_dm, rx, ry));
    }
    
  }
