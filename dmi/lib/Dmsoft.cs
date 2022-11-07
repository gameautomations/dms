
using System.Net.Sockets;
using System.Text;

namespace gas.GaEngine;
public class Dmsoft {
    private static string host = "localhost";
    private static int port = 13000;
    private TcpClient _client;
    private NetworkStream _stream;

    public Dmsoft()
    {
        _client = new TcpClient(host, port);
        _stream = _client.GetStream();
    }

    ~Dmsoft()
    {
        Release();
    }

    public void Release()
    {
        if (_stream != null) _stream.Close();
        if (_client != null) _client.Close();
    }
    // 发送消息
    public string Call(params object[] list)
    {
        string cmd = "";
        for (int i = 0; i < list.Length; i++)
        {
            cmd += list[i] + (i == list.Length - 1 ? "" : "\n");
        }

        cmd += "\0";

        byte[] reqBuffer = Encoding.UTF8.GetBytes(cmd);

        _stream.Write(reqBuffer);

        byte[] resBuffer = new byte[256];
        _stream.Read(resBuffer, 0, resBuffer.Length);
        string res = Encoding.UTF8.GetString(resBuffer).Split("\0")[0];
        var result = res.Split("\n");
        var code = result[0];
        if(code == "0")
        {
            return result[1];
        }
        throw new Exception(result[1]);
    }

        public string Ver (){
    return  Call(0);
    }
    
    public int SetPath (string path){
    return int.Parse( Call(1,path));
    }
    
    public string Ocr (int x1, int y1, int x2, int y2, string color, double sim){
    return  Call(2,x1, y1, x2, y2, color, sim);
    }
    
    public (int,int,int) FindStr (int x1, int y1, int x2, int y2, string str, string color, double sim){
    string resStr = Call(3,x1, y1, x2, y2, str, color, sim);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public int GetResultCount (string str){
    return int.Parse( Call(4,str));
    }
    
    public (int,int,int) GetResultPos (string str, int index){
    string resStr = Call(5,str, index);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public int StrStr (string s, string str){
    return int.Parse( Call(6,s, str));
    }
    
    public int SendCommand (string cmd){
    return int.Parse( Call(7,cmd));
    }
    
    public int UseDict (int index){
    return int.Parse( Call(8,index));
    }
    
    public string GetBasePath (){
    return  Call(9);
    }
    
    public int SetDictPwd (string pwd){
    return int.Parse( Call(10,pwd));
    }
    
    public string OcrInFile (int x1, int y1, int x2, int y2, string pic_name, string color, double sim){
    return  Call(11,x1, y1, x2, y2, pic_name, color, sim);
    }
    
    public int Capture (int x1, int y1, int x2, int y2, string file){
    return int.Parse( Call(12,x1, y1, x2, y2, file));
    }
    
    public int KeyPress (int vk){
    return int.Parse( Call(13,vk));
    }
    
    public int KeyDown (int vk){
    return int.Parse( Call(14,vk));
    }
    
    public int KeyUp (int vk){
    return int.Parse( Call(15,vk));
    }
    
    public int LeftClick (){
    return int.Parse( Call(16));
    }
    
    public int RightClick (){
    return int.Parse( Call(17));
    }
    
    public int MiddleClick (){
    return int.Parse( Call(18));
    }
    
    public int LeftDoubleClick (){
    return int.Parse( Call(19));
    }
    
    public int LeftDown (){
    return int.Parse( Call(20));
    }
    
    public int LeftUp (){
    return int.Parse( Call(21));
    }
    
    public int RightDown (){
    return int.Parse( Call(22));
    }
    
    public int RightUp (){
    return int.Parse( Call(23));
    }
    
    public int MoveTo (int x, int y){
    return int.Parse( Call(24,x, y));
    }
    
    public int MoveR (int rx, int ry){
    return int.Parse( Call(25,rx, ry));
    }
    
    public string GetColor (int x, int y){
    return  Call(26,x, y);
    }
    
    public string GetColorBGR (int x, int y){
    return  Call(27,x, y);
    }
    
    public string RGB2BGR (string rgb_color){
    return  Call(28,rgb_color);
    }
    
    public string BGR2RGB (string bgr_color){
    return  Call(29,bgr_color);
    }
    
    public int UnBindWindow (){
    return int.Parse( Call(30));
    }
    
    public int CmpColor (int x, int y, string color, double sim){
    return int.Parse( Call(31,x, y, color, sim));
    }
    
    public (int,int,int) ClientToScreen (int hwnd){
    string resStr = Call(32,hwnd);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public (int,int,int) ScreenToClient (int hwnd){
    string resStr = Call(33,hwnd);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public int ShowScrMsg (int x1, int y1, int x2, int y2, string msg, string color){
    return int.Parse( Call(34,x1, y1, x2, y2, msg, color));
    }
    
    public int SetMinRowGap (int row_gap){
    return int.Parse( Call(35,row_gap));
    }
    
    public int SetMinColGap (int col_gap){
    return int.Parse( Call(36,col_gap));
    }
    
    public (int,int,int) FindColor (int x1, int y1, int x2, int y2, string color, double sim, int dir){
    string resStr = Call(37,x1, y1, x2, y2, color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindColorEx (int x1, int y1, int x2, int y2, string color, double sim, int dir){
    return  Call(38,x1, y1, x2, y2, color, sim, dir);
    }
    
    public int SetWordLineHeight (int line_height){
    return int.Parse( Call(39,line_height));
    }
    
    public int SetWordGap (int word_gap){
    return int.Parse( Call(40,word_gap));
    }
    
    public int SetRowGapNoDict (int row_gap){
    return int.Parse( Call(41,row_gap));
    }
    
    public int SetColGapNoDict (int col_gap){
    return int.Parse( Call(42,col_gap));
    }
    
    public int SetWordLineHeightNoDict (int line_height){
    return int.Parse( Call(43,line_height));
    }
    
    public int SetWordGapNoDict (int word_gap){
    return int.Parse( Call(44,word_gap));
    }
    
    public int GetWordResultCount (string str){
    return int.Parse( Call(45,str));
    }
    
    public (int,int,int) GetWordResultPos (string str, int index){
    string resStr = Call(46,str, index);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string GetWordResultStr (string str, int index){
    return  Call(47,str, index);
    }
    
    public string GetWords (int x1, int y1, int x2, int y2, string color, double sim){
    return  Call(48,x1, y1, x2, y2, color, sim);
    }
    
    public string GetWordsNoDict (int x1, int y1, int x2, int y2, string color){
    return  Call(49,x1, y1, x2, y2, color);
    }
    
    public int SetShowErrorMsg (int show){
    return int.Parse( Call(50,show));
    }
    
    public (int,int,int) GetClientSize (int hwnd){
    string resStr = Call(51,hwnd);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public int MoveWindow (int hwnd, int x, int y){
    return int.Parse( Call(52,hwnd, x, y));
    }
    
    public string GetColorHSV (int x, int y){
    return  Call(53,x, y);
    }
    
    public string GetAveRGB (int x1, int y1, int x2, int y2){
    return  Call(54,x1, y1, x2, y2);
    }
    
    public string GetAveHSV (int x1, int y1, int x2, int y2){
    return  Call(55,x1, y1, x2, y2);
    }
    
    public int GetForegroundWindow (){
    return int.Parse( Call(56));
    }
    
    public int GetForegroundFocus (){
    return int.Parse( Call(57));
    }
    
    public int GetMousePointWindow (){
    return int.Parse( Call(58));
    }
    
    public int GetPointWindow (int x, int y){
    return int.Parse( Call(59,x, y));
    }
    
    public string EnumWindow (int parent, string title, string class_name, int filter){
    return  Call(60,parent, title, class_name, filter);
    }
    
    public int GetWindowState (int hwnd, int flag){
    return int.Parse( Call(61,hwnd, flag));
    }
    
    public int GetWindow (int hwnd, int flag){
    return int.Parse( Call(62,hwnd, flag));
    }
    
    public int GetSpecialWindow (int flag){
    return int.Parse( Call(63,flag));
    }
    
    public int SetWindowText (int hwnd, string text){
    return int.Parse( Call(64,hwnd, text));
    }
    
    public int SetWindowSize (int hwnd, int width, int height){
    return int.Parse( Call(65,hwnd, width, height));
    }
    
    public (int,int,int,int,int) GetWindowRect (int hwnd){
    string resStr = Call(66,hwnd);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]),int.Parse(resArray[3]),int.Parse(resArray[4]));
    }
    
    public string GetWindowTitle (int hwnd){
    return  Call(67,hwnd);
    }
    
    public string GetWindowClass (int hwnd){
    return  Call(68,hwnd);
    }
    
    public int SetWindowState (int hwnd, int flag){
    return int.Parse( Call(69,hwnd, flag));
    }
    
    public int CreateFoobarRect (int hwnd, int x, int y, int w, int h){
    return int.Parse( Call(70,hwnd, x, y, w, h));
    }
    
    public int CreateFoobarRoundRect (int hwnd, int x, int y, int w, int h, int rw, int rh){
    return int.Parse( Call(71,hwnd, x, y, w, h, rw, rh));
    }
    
    public int CreateFoobarEllipse (int hwnd, int x, int y, int w, int h){
    return int.Parse( Call(72,hwnd, x, y, w, h));
    }
    
    public int CreateFoobarCustom (int hwnd, int x, int y, string pic, string trans_color, double sim){
    return int.Parse( Call(73,hwnd, x, y, pic, trans_color, sim));
    }
    
    public int FoobarFillRect (int hwnd, int x1, int y1, int x2, int y2, string color){
    return int.Parse( Call(74,hwnd, x1, y1, x2, y2, color));
    }
    
    public int FoobarDrawText (int hwnd, int x, int y, int w, int h, string text, string color, int align){
    return int.Parse( Call(75,hwnd, x, y, w, h, text, color, align));
    }
    
    public int FoobarDrawPic (int hwnd, int x, int y, string pic, string trans_color){
    return int.Parse( Call(76,hwnd, x, y, pic, trans_color));
    }
    
    public int FoobarUpdate (int hwnd){
    return int.Parse( Call(77,hwnd));
    }
    
    public int FoobarLock (int hwnd){
    return int.Parse( Call(78,hwnd));
    }
    
    public int FoobarUnlock (int hwnd){
    return int.Parse( Call(79,hwnd));
    }
    
    public int FoobarSetFont (int hwnd, string font_name, int size, int flag){
    return int.Parse( Call(80,hwnd, font_name, size, flag));
    }
    
    public int FoobarTextRect (int hwnd, int x, int y, int w, int h){
    return int.Parse( Call(81,hwnd, x, y, w, h));
    }
    
    public int FoobarPrintText (int hwnd, string text, string color){
    return int.Parse( Call(82,hwnd, text, color));
    }
    
    public int FoobarClearText (int hwnd){
    return int.Parse( Call(83,hwnd));
    }
    
    public int FoobarTextLineGap (int hwnd, int gap){
    return int.Parse( Call(84,hwnd, gap));
    }
    
    public int Play (string file){
    return int.Parse( Call(85,file));
    }
    
    public int FaqCapture (int x1, int y1, int x2, int y2, int quality, int delay, int time){
    return int.Parse( Call(86,x1, y1, x2, y2, quality, delay, time));
    }
    
    public int FaqRelease (int handle){
    return int.Parse( Call(87,handle));
    }
    
    public string FaqSend (string server, int handle, int request_type, int time_out){
    return  Call(88,server, handle, request_type, time_out);
    }
    
    public int Beep (int fre, int delay){
    return int.Parse( Call(89,fre, delay));
    }
    
    public int FoobarClose (int hwnd){
    return int.Parse( Call(90,hwnd));
    }
    
    public int MoveDD (int dx, int dy){
    return int.Parse( Call(91,dx, dy));
    }
    
    public int FaqGetSize (int handle){
    return int.Parse( Call(92,handle));
    }
    
    public int LoadPic (string pic_name){
    return int.Parse( Call(93,pic_name));
    }
    
    public int FreePic (string pic_name){
    return int.Parse( Call(94,pic_name));
    }
    
    public int GetScreenData (int x1, int y1, int x2, int y2){
    return int.Parse( Call(95,x1, y1, x2, y2));
    }
    
    public int FreeScreenData (int handle){
    return int.Parse( Call(96,handle));
    }
    
    public int WheelUp (){
    return int.Parse( Call(97));
    }
    
    public int WheelDown (){
    return int.Parse( Call(98));
    }
    
    public int SetMouseDelay (string type, int delay){
    return int.Parse( Call(99,type, delay));
    }
    
    public int SetKeypadDelay (string type, int delay){
    return int.Parse( Call(100,type, delay));
    }
    
    public string GetEnv (int index, string name){
    return  Call(101,index, name);
    }
    
    public int SetEnv (int index, string name, string value){
    return int.Parse( Call(102,index, name, value));
    }
    
    public int SendString (int hwnd, string str){
    return int.Parse( Call(103,hwnd, str));
    }
    
    public int DelEnv (int index, string name){
    return int.Parse( Call(104,index, name));
    }
    
    public string GetPath (){
    return  Call(105);
    }
    
    public int SetDict (int index, string dict_name){
    return int.Parse( Call(106,index, dict_name));
    }
    
    public (int,int,int) FindPic (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    string resStr = Call(107,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindPicEx (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    return  Call(108,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    public int SetClientSize (int hwnd, int width, int height){
    return int.Parse( Call(109,hwnd, width, height));
    }
    
    public long ReadInt (int hwnd, string addr, int type){
    return int.Parse( Call(110,hwnd, addr, type));
    }
    
    public float ReadFloat (int hwnd, string addr){
    return int.Parse( Call(111,hwnd, addr));
    }
    
    public double ReadDouble (int hwnd, string addr){
    return int.Parse( Call(112,hwnd, addr));
    }
    
    public string FindInt (int hwnd, string addr_range, long int_value_min, long int_value_max, int type){
    return  Call(113,hwnd, addr_range, int_value_min, int_value_max, type);
    }
    
    public string FindFloat (int hwnd, string addr_range, float float_value_min, float float_value_max){
    return  Call(114,hwnd, addr_range, float_value_min, float_value_max);
    }
    
    public string FindDouble (int hwnd, string addr_range, double double_value_min, double double_value_max){
    return  Call(115,hwnd, addr_range, double_value_min, double_value_max);
    }
    
    public string FindString (int hwnd, string addr_range, string string_value, int type){
    return  Call(116,hwnd, addr_range, string_value, type);
    }
    
    public long GetModuleBaseAddr (int hwnd, string module_name){
    return int.Parse( Call(117,hwnd, module_name));
    }
    
    public string MoveToEx (int x, int y, int w, int h){
    return  Call(118,x, y, w, h);
    }
    
    public string MatchPicName (string pic_name){
    return  Call(119,pic_name);
    }
    
    public int AddDict (int index, string dict_info){
    return int.Parse( Call(120,index, dict_info));
    }
    
    public int EnterCri (){
    return int.Parse( Call(121));
    }
    
    public int LeaveCri (){
    return int.Parse( Call(122));
    }
    
    public int WriteInt (int hwnd, string addr, int type, long v){
    return int.Parse( Call(123,hwnd, addr, type, v));
    }
    
    public int WriteFloat (int hwnd, string addr, float v){
    return int.Parse( Call(124,hwnd, addr, v));
    }
    
    public int WriteDouble (int hwnd, string addr, double v){
    return int.Parse( Call(125,hwnd, addr, v));
    }
    
    public int WriteString (int hwnd, string addr, int type, string v){
    return int.Parse( Call(126,hwnd, addr, type, v));
    }
    
    public int AsmAdd (string asm_ins){
    return int.Parse( Call(127,asm_ins));
    }
    
    public int AsmClear (){
    return int.Parse( Call(128));
    }
    
    public long AsmCall (int hwnd, int mode){
    return int.Parse( Call(129,hwnd, mode));
    }
    
    public (int,int,int) FindMultiColor (int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir){
    string resStr = Call(130,x1, y1, x2, y2, first_color, offset_color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindMultiColorEx (int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir){
    return  Call(131,x1, y1, x2, y2, first_color, offset_color, sim, dir);
    }
    
    public string Assemble (long base_addr, int is_64bit){
    return  Call(132,base_addr, is_64bit);
    }
    
    public string DisAssemble (string asm_code, long base_addr, int is_64bit){
    return  Call(133,asm_code, base_addr, is_64bit);
    }
    
    public int SetWindowTransparent (int hwnd, int v){
    return int.Parse( Call(134,hwnd, v));
    }
    
    public string ReadData (int hwnd, string addr, int len){
    return  Call(135,hwnd, addr, len);
    }
    
    public int WriteData (int hwnd, string addr, string data){
    return int.Parse( Call(136,hwnd, addr, data));
    }
    
    public string FindData (int hwnd, string addr_range, string data){
    return  Call(137,hwnd, addr_range, data);
    }
    
    public int SetPicPwd (string pwd){
    return int.Parse( Call(138,pwd));
    }
    
    public int Log (string info){
    return int.Parse( Call(139,info));
    }
    
    public string FindStrE (int x1, int y1, int x2, int y2, string str, string color, double sim){
    return  Call(140,x1, y1, x2, y2, str, color, sim);
    }
    
    public string FindColorE (int x1, int y1, int x2, int y2, string color, double sim, int dir){
    return  Call(141,x1, y1, x2, y2, color, sim, dir);
    }
    
    public string FindPicE (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    return  Call(142,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    public string FindMultiColorE (int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir){
    return  Call(143,x1, y1, x2, y2, first_color, offset_color, sim, dir);
    }
    
    public int SetExactOcr (int exact_ocr){
    return int.Parse( Call(144,exact_ocr));
    }
    
    public string ReadString (int hwnd, string addr, int type, int len){
    return  Call(145,hwnd, addr, type, len);
    }
    
    public int FoobarTextPrintDir (int hwnd, int dir){
    return int.Parse( Call(146,hwnd, dir));
    }
    
    public string OcrEx (int x1, int y1, int x2, int y2, string color, double sim){
    return  Call(147,x1, y1, x2, y2, color, sim);
    }
    
    public int SetDisplayInput (string mode){
    return int.Parse( Call(148,mode));
    }
    
    public int GetTime (){
    return int.Parse( Call(149));
    }
    
    public int GetScreenWidth (){
    return int.Parse( Call(150));
    }
    
    public int GetScreenHeight (){
    return int.Parse( Call(151));
    }
    
    public int BindWindowEx (int hwnd, string display, string mouse, string keypad, string public_desc, int mode){
    return int.Parse( Call(152,hwnd, display, mouse, keypad, public_desc, mode));
    }
    
    public string GetDiskSerial (int index){
    return  Call(153,index);
    }
    
    public string Md5 (string str){
    return  Call(154,str);
    }
    
    public string GetMac (){
    return  Call(155);
    }
    
    public int ActiveInputMethod (int hwnd, string id){
    return int.Parse( Call(156,hwnd, id));
    }
    
    public int CheckInputMethod (int hwnd, string id){
    return int.Parse( Call(157,hwnd, id));
    }
    
    public int FindInputMethod (string id){
    return int.Parse( Call(158,id));
    }
    
    public (int,int,int) GetCursorPos (){
    string resStr = Call(159);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public int BindWindow (int hwnd, string display, string mouse, string keypad, int mode){
    return int.Parse( Call(160,hwnd, display, mouse, keypad, mode));
    }
    
    public int FindWindow (string class_name, string title_name){
    return int.Parse( Call(161,class_name, title_name));
    }
    
    public int GetScreenDepth (){
    return int.Parse( Call(162));
    }
    
    public int SetScreen (int width, int height, int depth){
    return int.Parse( Call(163,width, height, depth));
    }
    
    public int ExitOs (int type){
    return int.Parse( Call(164,type));
    }
    
    public string GetDir (int type){
    return  Call(165,type);
    }
    
    public int GetOsType (){
    return int.Parse( Call(166));
    }
    
    public int FindWindowEx (int parent, string class_name, string title_name){
    return int.Parse( Call(167,parent, class_name, title_name));
    }
    
    public int SetExportDict (int index, string dict_name){
    return int.Parse( Call(168,index, dict_name));
    }
    
    public string GetCursorShape (){
    return  Call(169);
    }
    
    public int DownCpu (int type, int rate){
    return int.Parse( Call(170,type, rate));
    }
    
    public string GetCursorSpot (){
    return  Call(171);
    }
    
    public int SendString2 (int hwnd, string str){
    return int.Parse( Call(172,hwnd, str));
    }
    
    public int FaqPost (string server, int handle, int request_type, int time_out){
    return int.Parse( Call(173,server, handle, request_type, time_out));
    }
    
    public string FaqFetch (){
    return  Call(174);
    }
    
    public string FetchWord (int x1, int y1, int x2, int y2, string color, string word){
    return  Call(175,x1, y1, x2, y2, color, word);
    }
    
    public int CaptureJpg (int x1, int y1, int x2, int y2, string file, int quality){
    return int.Parse( Call(176,x1, y1, x2, y2, file, quality));
    }
    
    public (int,int,int) FindStrWithFont (int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag){
    string resStr = Call(177,x1, y1, x2, y2, str, color, sim, font_name, font_size, flag);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindStrWithFontE (int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag){
    return  Call(178,x1, y1, x2, y2, str, color, sim, font_name, font_size, flag);
    }
    
    public string FindStrWithFontEx (int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag){
    return  Call(179,x1, y1, x2, y2, str, color, sim, font_name, font_size, flag);
    }
    
    public string GetDictInfo (string str, string font_name, int font_size, int flag){
    return  Call(180,str, font_name, font_size, flag);
    }
    
    public int SaveDict (int index, string file){
    return int.Parse( Call(181,index, file));
    }
    
    public int GetWindowProcessId (int hwnd){
    return int.Parse( Call(182,hwnd));
    }
    
    public string GetWindowProcessPath (int hwnd){
    return  Call(183,hwnd);
    }
    
    public int LockInput (int _lock){
    return int.Parse( Call(184,_lock));
    }
    
    public string GetPicSize (string pic_name){
    return  Call(185,pic_name);
    }
    
    public int GetID (){
    return int.Parse( Call(186));
    }
    
    public int CapturePng (int x1, int y1, int x2, int y2, string file){
    return int.Parse( Call(187,x1, y1, x2, y2, file));
    }
    
    public int CaptureGif (int x1, int y1, int x2, int y2, string file, int delay, int time){
    return int.Parse( Call(188,x1, y1, x2, y2, file, delay, time));
    }
    
    public int ImageToBmp (string pic_name, string bmp_name){
    return int.Parse( Call(189,pic_name, bmp_name));
    }
    
    public (int,int,int) FindStrFast (int x1, int y1, int x2, int y2, string str, string color, double sim){
    string resStr = Call(190,x1, y1, x2, y2, str, color, sim);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindStrFastEx (int x1, int y1, int x2, int y2, string str, string color, double sim){
    return  Call(191,x1, y1, x2, y2, str, color, sim);
    }
    
    public string FindStrFastE (int x1, int y1, int x2, int y2, string str, string color, double sim){
    return  Call(192,x1, y1, x2, y2, str, color, sim);
    }
    
    public int EnableDisplayDebug (int enable_debug){
    return int.Parse( Call(193,enable_debug));
    }
    
    public int CapturePre (string file){
    return int.Parse( Call(194,file));
    }
    
    public int RegEx (string code, string Ver, string ip){
    return int.Parse( Call(195,code, Ver, ip));
    }
    
    public string GetMachineCode (){
    return  Call(196);
    }
    
    public int SetClipboard (string data){
    return int.Parse( Call(197,data));
    }
    
    public string GetClipboard (){
    return  Call(198);
    }
    
    public int GetNowDict (){
    return int.Parse( Call(199));
    }
    
    public int Is64Bit (){
    return int.Parse( Call(200));
    }
    
    public int GetColorNum (int x1, int y1, int x2, int y2, string color, double sim){
    return int.Parse( Call(201,x1, y1, x2, y2, color, sim));
    }
    
    public string EnumWindowByProcess (string process_name, string title, string class_name, int filter){
    return  Call(202,process_name, title, class_name, filter);
    }
    
    public int GetDictCount (int index){
    return int.Parse( Call(203,index));
    }
    
    public int GetLastError (){
    return int.Parse( Call(204));
    }
    
    public string GetNetTime (){
    return  Call(205);
    }
    
    public int EnableGetColorByCapture (int en){
    return int.Parse( Call(206,en));
    }
    
    public int CheckUAC (){
    return int.Parse( Call(207));
    }
    
    public int SetUAC (int uac){
    return int.Parse( Call(208,uac));
    }
    
    public int DisableFontSmooth (){
    return int.Parse( Call(209));
    }
    
    public int CheckFontSmooth (){
    return int.Parse( Call(210));
    }
    
    public int SetDisplayAcceler (int level){
    return int.Parse( Call(211,level));
    }
    
    public int FindWindowByProcess (string process_name, string class_name, string title_name){
    return int.Parse( Call(212,process_name, class_name, title_name));
    }
    
    public int FindWindowByProcessId (int process_id, string class_name, string title_name){
    return int.Parse( Call(213,process_id, class_name, title_name));
    }
    
    public string ReadIni (string section, string key, string file){
    return  Call(214,section, key, file);
    }
    
    public int WriteIni (string section, string key, string v, string file){
    return int.Parse( Call(215,section, key, v, file));
    }
    
    public int RunApp (string path, int mode){
    return int.Parse( Call(216,path, mode));
    }
    
    public int delay (int mis){
    return int.Parse( Call(217,mis));
    }
    
    public int FindWindowSuper (string spec1, int flag1, int type1, string spec2, int flag2, int type2){
    return int.Parse( Call(218,spec1, flag1, type1, spec2, flag2, type2));
    }
    
    public string ExcludePos (string all_pos, int type, int x1, int y1, int x2, int y2){
    return  Call(219,all_pos, type, x1, y1, x2, y2);
    }
    
    public string FindNearestPos (string all_pos, int type, int x, int y){
    return  Call(220,all_pos, type, x, y);
    }
    
    public string SortPosDistance (string all_pos, int type, int x, int y){
    return  Call(221,all_pos, type, x, y);
    }
    
    public (int,int,int) FindPicMem (int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir){
    string resStr = Call(222,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindPicMemEx (int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir){
    return  Call(223,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    }
    
    public string FindPicMemE (int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir){
    return  Call(224,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    }
    
    public string AppendPicAddr (string pic_info, int addr, int size){
    return  Call(225,pic_info, addr, size);
    }
    
    public int WriteFile (string file, string content){
    return int.Parse( Call(226,file, content));
    }
    
    public int Stop (int id){
    return int.Parse( Call(227,id));
    }
    
    public int SetDictMem (int index, int addr, int size){
    return int.Parse( Call(228,index, addr, size));
    }
    
    public string GetNetTimeSafe (){
    return  Call(229);
    }
    
    public int ForceUnBindWindow (int hwnd){
    return int.Parse( Call(230,hwnd));
    }
    
    public string ReadIniPwd (string section, string key, string file, string pwd){
    return  Call(231,section, key, file, pwd);
    }
    
    public int WriteIniPwd (string section, string key, string v, string file, string pwd){
    return int.Parse( Call(232,section, key, v, file, pwd));
    }
    
    public int DecodeFile (string file, string pwd){
    return int.Parse( Call(233,file, pwd));
    }
    
    public int KeyDownChar (string key_str){
    return int.Parse( Call(234,key_str));
    }
    
    public int KeyUpChar (string key_str){
    return int.Parse( Call(235,key_str));
    }
    
    public int KeyPressChar (string key_str){
    return int.Parse( Call(236,key_str));
    }
    
    public int KeyPressStr (string key_str, int delay){
    return int.Parse( Call(237,key_str, delay));
    }
    
    public int EnableKeypadPatch (int en){
    return int.Parse( Call(238,en));
    }
    
    public int EnableKeypadSync (int en, int time_out){
    return int.Parse( Call(239,en, time_out));
    }
    
    public int EnableMouseSync (int en, int time_out){
    return int.Parse( Call(240,en, time_out));
    }
    
    public int DmGuard (int en, string type){
    return int.Parse( Call(241,en, type));
    }
    
    public int FaqCaptureFromFile (int x1, int y1, int x2, int y2, string file, int quality){
    return int.Parse( Call(242,x1, y1, x2, y2, file, quality));
    }
    
    public string FindIntEx (int hwnd, string addr_range, long int_value_min, long int_value_max, int type, int step, int multi_thread, int mode){
    return  Call(243,hwnd, addr_range, int_value_min, int_value_max, type, step, multi_thread, mode);
    }
    
    public string FindFloatEx (int hwnd, string addr_range, float float_value_min, float float_value_max, int step, int multi_thread, int mode){
    return  Call(244,hwnd, addr_range, float_value_min, float_value_max, step, multi_thread, mode);
    }
    
    public string FindDoubleEx (int hwnd, string addr_range, double double_value_min, double double_value_max, int step, int multi_thread, int mode){
    return  Call(245,hwnd, addr_range, double_value_min, double_value_max, step, multi_thread, mode);
    }
    
    public string FindStringEx (int hwnd, string addr_range, string string_value, int type, int step, int multi_thread, int mode){
    return  Call(246,hwnd, addr_range, string_value, type, step, multi_thread, mode);
    }
    
    public string FindDataEx (int hwnd, string addr_range, string data, int step, int multi_thread, int mode){
    return  Call(247,hwnd, addr_range, data, step, multi_thread, mode);
    }
    
    public int EnableRealMouse (int en, int mousedelay, int mousestep){
    return int.Parse( Call(248,en, mousedelay, mousestep));
    }
    
    public int EnableRealKeypad (int en){
    return int.Parse( Call(249,en));
    }
    
    public int SendStringIme (string str){
    return int.Parse( Call(250,str));
    }
    
    public int FoobarDrawLine (int hwnd, int x1, int y1, int x2, int y2, string color, int style, int width){
    return int.Parse( Call(251,hwnd, x1, y1, x2, y2, color, style, width));
    }
    
    public string FindStrEx (int x1, int y1, int x2, int y2, string str, string color, double sim){
    return  Call(252,x1, y1, x2, y2, str, color, sim);
    }
    
    public int IsBind (int hwnd){
    return int.Parse( Call(253,hwnd));
    }
    
    public int SetDisplayDelay (int t){
    return int.Parse( Call(254,t));
    }
    
    public int GetDmCount (){
    return int.Parse( Call(255));
    }
    
    public int DisableScreenSave (){
    return int.Parse( Call(256));
    }
    
    public int DisablePowerSave (){
    return int.Parse( Call(257));
    }
    
    public int SetMemoryHwndAsProcessId (int en){
    return int.Parse( Call(258,en));
    }
    
    public (int,int,int) FindShape (int x1, int y1, int x2, int y2, string offset_color, double sim, int dir){
    string resStr = Call(259,x1, y1, x2, y2, offset_color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindShapeE (int x1, int y1, int x2, int y2, string offset_color, double sim, int dir){
    return  Call(260,x1, y1, x2, y2, offset_color, sim, dir);
    }
    
    public string FindShapeEx (int x1, int y1, int x2, int y2, string offset_color, double sim, int dir){
    return  Call(261,x1, y1, x2, y2, offset_color, sim, dir);
    }
    
    public (string,int,int) FindStrS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    string resStr = Call(262,x1, y1, x2, y2, str, color, sim);
    string[] resArray = resStr.Split("\n");
    return (resArray[0],int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindStrExS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    return  Call(263,x1, y1, x2, y2, str, color, sim);
    }
    
    public (string,int,int) FindStrFastS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    string resStr = Call(264,x1, y1, x2, y2, str, color, sim);
    string[] resArray = resStr.Split("\n");
    return (resArray[0],int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindStrFastExS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    return  Call(265,x1, y1, x2, y2, str, color, sim);
    }
    
    public (string,int,int) FindPicS (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    string resStr = Call(266,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (resArray[0],int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindPicExS (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    return  Call(267,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    public int ClearDict (int index){
    return int.Parse( Call(268,index));
    }
    
    public string GetMachineCodeNoMac (){
    return  Call(269);
    }
    
    public (int,int,int,int,int) GetClientRect (int hwnd){
    string resStr = Call(270,hwnd);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]),int.Parse(resArray[3]),int.Parse(resArray[4]));
    }
    
    public int EnableFakeActive (int en){
    return int.Parse( Call(271,en));
    }
    
    public (int,int,int) GetScreenDataBmp (int x1, int y1, int x2, int y2){
    string resStr = Call(272,x1, y1, x2, y2);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public int EncodeFile (string file, string pwd){
    return int.Parse( Call(273,file, pwd));
    }
    
    public string GetCursorShapeEx (int type){
    return  Call(274,type);
    }
    
    public int FaqCancel (){
    return int.Parse( Call(275));
    }
    
    public string IntToData (long int_value, int type){
    return  Call(276,int_value, type);
    }
    
    public string FloatToData (float float_value){
    return  Call(277,float_value);
    }
    
    public string DoubleToData (double double_value){
    return  Call(278,double_value);
    }
    
    public string StringToData (string string_value, int type){
    return  Call(279,string_value, type);
    }
    
    public int SetMemoryFindResultToFile (string file){
    return int.Parse( Call(280,file));
    }
    
    public int EnableBind (int en){
    return int.Parse( Call(281,en));
    }
    
    public int SetSimMode (int mode){
    return int.Parse( Call(282,mode));
    }
    
    public int LockMouseRect (int x1, int y1, int x2, int y2){
    return int.Parse( Call(283,x1, y1, x2, y2));
    }
    
    public int SendPaste (int hwnd){
    return int.Parse( Call(284,hwnd));
    }
    
    public int IsDisplayDead (int x1, int y1, int x2, int y2, int t){
    return int.Parse( Call(285,x1, y1, x2, y2, t));
    }
    
    public int GetKeyState (int vk){
    return int.Parse( Call(286,vk));
    }
    
    public int CopyFile (string src_file, string dst_file, int over){
    return int.Parse( Call(287,src_file, dst_file, over));
    }
    
    public int IsFileExist (string file){
    return int.Parse( Call(288,file));
    }
    
    public int DeleteFile (string file){
    return int.Parse( Call(289,file));
    }
    
    public int MoveFile (string src_file, string dst_file){
    return int.Parse( Call(290,src_file, dst_file));
    }
    
    public int CreateFolder (string folder_name){
    return int.Parse( Call(291,folder_name));
    }
    
    public int DeleteFolder (string folder_name){
    return int.Parse( Call(292,folder_name));
    }
    
    public int GetFileLength (string file){
    return int.Parse( Call(293,file));
    }
    
    public string ReadFile (string file){
    return  Call(294,file);
    }
    
    public int WaitKey (int key_code, int time_out){
    return int.Parse( Call(295,key_code, time_out));
    }
    
    public int DeleteIni (string section, string key, string file){
    return int.Parse( Call(296,section, key, file));
    }
    
    public int DeleteIniPwd (string section, string key, string file, string pwd){
    return int.Parse( Call(297,section, key, file, pwd));
    }
    
    public int EnableSpeedDx (int en){
    return int.Parse( Call(298,en));
    }
    
    public int EnableIme (int en){
    return int.Parse( Call(299,en));
    }
    
    public int Reg (string code, string Ver){
    return int.Parse( Call(300,code, Ver));
    }
    
    public string SelectFile (){
    return  Call(301);
    }
    
    public string SelectDirectory (){
    return  Call(302);
    }
    
    public int LockDisplay (int _lock){
    return int.Parse( Call(303,_lock));
    }
    
    public int FoobarSetSave (int hwnd, string file, int en, string header){
    return int.Parse( Call(304,hwnd, file, en, header));
    }
    
    public string EnumWindowSuper (string spec1, int flag1, int type1, string spec2, int flag2, int type2, int sort){
    return  Call(305,spec1, flag1, type1, spec2, flag2, type2, sort);
    }
    
    public int DownloadFile (string url, string save_file, int timeout){
    return int.Parse( Call(306,url, save_file, timeout));
    }
    
    public int EnableKeypadMsg (int en){
    return int.Parse( Call(307,en));
    }
    
    public int EnableMouseMsg (int en){
    return int.Parse( Call(308,en));
    }
    
    public int RegNoMac (string code, string Ver){
    return int.Parse( Call(309,code, Ver));
    }
    
    public int RegExNoMac (string code, string Ver, string ip){
    return int.Parse( Call(310,code, Ver, ip));
    }
    
    public int SetEnumWindowDelay (int delay){
    return int.Parse( Call(311,delay));
    }
    
    public int FindMulColor (int x1, int y1, int x2, int y2, string color, double sim){
    return int.Parse( Call(312,x1, y1, x2, y2, color, sim));
    }
    
    public string GetDict (int index, int font_index){
    return  Call(313,index, font_index);
    }
    
    public int GetBindWindow (){
    return int.Parse( Call(314));
    }
    
    public int FoobarStartGif (int hwnd, int x, int y, string pic_name, int repeat_limit, int delay){
    return int.Parse( Call(315,hwnd, x, y, pic_name, repeat_limit, delay));
    }
    
    public int FoobarStopGif (int hwnd, int x, int y, string pic_name){
    return int.Parse( Call(316,hwnd, x, y, pic_name));
    }
    
    public int FreeProcessMemory (int hwnd){
    return int.Parse( Call(317,hwnd));
    }
    
    public string ReadFileData (string file, int start_pos, int end_pos){
    return  Call(318,file, start_pos, end_pos);
    }
    
    public long VirtualAllocEx (int hwnd, long addr, int size, int type){
    return int.Parse( Call(319,hwnd, addr, size, type));
    }
    
    public int VirtualFreeEx (int hwnd, long addr){
    return int.Parse( Call(320,hwnd, addr));
    }
    
    public string GetCommandLine (int hwnd){
    return  Call(321,hwnd);
    }
    
    public int TerminateProcess (int pid){
    return int.Parse( Call(322,pid));
    }
    
    public string GetNetTimeByIp (string ip){
    return  Call(323,ip);
    }
    
    public string EnumProcess (string name){
    return  Call(324,name);
    }
    
    public string GetProcessInfo (int pid){
    return  Call(325,pid);
    }
    
    public long ReadIntAddr (int hwnd, long addr, int type){
    return int.Parse( Call(326,hwnd, addr, type));
    }
    
    public string ReadDataAddr (int hwnd, long addr, int len){
    return  Call(327,hwnd, addr, len);
    }
    
    public double ReadDoubleAddr (int hwnd, long addr){
    return int.Parse( Call(328,hwnd, addr));
    }
    
    public float ReadFloatAddr (int hwnd, long addr){
    return int.Parse( Call(329,hwnd, addr));
    }
    
    public string ReadStringAddr (int hwnd, long addr, int type, int len){
    return  Call(330,hwnd, addr, type, len);
    }
    
    public int WriteDataAddr (int hwnd, long addr, string data){
    return int.Parse( Call(331,hwnd, addr, data));
    }
    
    public int WriteDoubleAddr (int hwnd, long addr, double v){
    return int.Parse( Call(332,hwnd, addr, v));
    }
    
    public int WriteFloatAddr (int hwnd, long addr, float v){
    return int.Parse( Call(333,hwnd, addr, v));
    }
    
    public int WriteIntAddr (int hwnd, long addr, int type, long v){
    return int.Parse( Call(334,hwnd, addr, type, v));
    }
    
    public int WriteStringAddr (int hwnd, long addr, int type, string v){
    return int.Parse( Call(335,hwnd, addr, type, v));
    }
    
    public int Delays (int min_s, int max_s){
    return int.Parse( Call(336,min_s, max_s));
    }
    
    public (int,int,int) FindColorBlock (int x1, int y1, int x2, int y2, string color, double sim, int count, int width, int height){
    string resStr = Call(337,x1, y1, x2, y2, color, sim, count, width, height);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindColorBlockEx (int x1, int y1, int x2, int y2, string color, double sim, int count, int width, int height){
    return  Call(338,x1, y1, x2, y2, color, sim, count, width, height);
    }
    
    public int OpenProcess (int pid){
    return int.Parse( Call(339,pid));
    }
    
    public string EnumIniSection (string file){
    return  Call(340,file);
    }
    
    public string EnumIniSectionPwd (string file, string pwd){
    return  Call(341,file, pwd);
    }
    
    public string EnumIniKey (string section, string file){
    return  Call(342,section, file);
    }
    
    public string EnumIniKeyPwd (string section, string file, string pwd){
    return  Call(343,section, file, pwd);
    }
    
    public int SwitchBindWindow (int hwnd){
    return int.Parse( Call(344,hwnd));
    }
    
    public int InitCri (){
    return int.Parse( Call(345));
    }
    
    public int SendStringIme2 (int hwnd, string str, int mode){
    return int.Parse( Call(346,hwnd, str, mode));
    }
    
    public string EnumWindowByProcessId (int pid, string title, string class_name, int filter){
    return  Call(347,pid, title, class_name, filter);
    }
    
    public string GetDisplayInfo (){
    return  Call(348);
    }
    
    public int EnableFontSmooth (){
    return int.Parse( Call(349));
    }
    
    public string OcrExOne (int x1, int y1, int x2, int y2, string color, double sim){
    return  Call(350,x1, y1, x2, y2, color, sim);
    }
    
    public int SetAero (int en){
    return int.Parse( Call(351,en));
    }
    
    public int FoobarSetTrans (int hwnd, int trans, string color, double sim){
    return int.Parse( Call(352,hwnd, trans, color, sim));
    }
    
    public int EnablePicCache (int en){
    return int.Parse( Call(353,en));
    }
    
    public int FaqIsPosted (){
    return int.Parse( Call(354));
    }
    
    public int LoadPicByte (int addr, int size, string name){
    return int.Parse( Call(355,addr, size, name));
    }
    
    public int MiddleDown (){
    return int.Parse( Call(356));
    }
    
    public int MiddleUp (){
    return int.Parse( Call(357));
    }
    
    public int FaqCaptureString (string str){
    return int.Parse( Call(358,str));
    }
    
    public int VirtualProtectEx (int hwnd, long addr, int size, int type, int old_protect){
    return int.Parse( Call(359,hwnd, addr, size, type, old_protect));
    }
    
    public int SetMouseSpeed (int speed){
    return int.Parse( Call(360,speed));
    }
    
    public int GetMouseSpeed (){
    return int.Parse( Call(361));
    }
    
    public int EnableMouseAccuracy (int en){
    return int.Parse( Call(362,en));
    }
    
    public int SetExcludeRegion (int type, string info){
    return int.Parse( Call(363,type, info));
    }
    
    public int EnableShareDict (int en){
    return int.Parse( Call(364,en));
    }
    
    public int DisableCloseDisplayAndSleep (){
    return int.Parse( Call(365));
    }
    
    public int Int64ToInt32 (long v){
    return int.Parse( Call(366,v));
    }
    
    public int GetLocale (){
    return int.Parse( Call(367));
    }
    
    public int SetLocale (){
    return int.Parse( Call(368));
    }
    
    public int ReadDataToBin (int hwnd, string addr, int len){
    return int.Parse( Call(369,hwnd, addr, len));
    }
    
    public int WriteDataFromBin (int hwnd, string addr, int data, int len){
    return int.Parse( Call(370,hwnd, addr, data, len));
    }
    
    public int ReadDataAddrToBin (int hwnd, long addr, int len){
    return int.Parse( Call(371,hwnd, addr, len));
    }
    
    public int WriteDataAddrFromBin (int hwnd, long addr, int data, int len){
    return int.Parse( Call(372,hwnd, addr, data, len));
    }
    
    public int SetParam64ToPointer (){
    return int.Parse( Call(373));
    }
    
    public int GetDPI (){
    return int.Parse( Call(374));
    }
    
    public int SetDisplayRefreshDelay (int t){
    return int.Parse( Call(375,t));
    }
    
    public int IsFolderExist (string folder){
    return int.Parse( Call(376,folder));
    }
    
    public int GetCpuType (){
    return int.Parse( Call(377));
    }
    
    public int ReleaseRef (){
    return int.Parse( Call(378));
    }
    
    public int SetExitThread (int en){
    return int.Parse( Call(379,en));
    }
    
    public int GetFps (){
    return int.Parse( Call(380));
    }
    
    public string VirtualQueryEx (int hwnd, long addr, int pmbi){
    return  Call(381,hwnd, addr, pmbi);
    }
    
    public long AsmCallEx (int hwnd, int mode, string base_addr){
    return int.Parse( Call(382,hwnd, mode, base_addr));
    }
    
    public long GetRemoteApiAddress (int hwnd, long base_addr, string fun_name){
    return int.Parse( Call(383,hwnd, base_addr, fun_name));
    }
    
    public string ExecuteCmd (string cmd, string current_dir, int time_out){
    return  Call(384,cmd, current_dir, time_out);
    }
    
    public int SpeedNormalGraphic (int en){
    return int.Parse( Call(385,en));
    }
    
    public int UnLoadDriver (){
    return int.Parse( Call(386));
    }
    
    public int GetOsBuildNumber (){
    return int.Parse( Call(387));
    }
    
    public int HackSpeed (double rate){
    return int.Parse( Call(388,rate));
    }
    
    public string GetRealPath (string path){
    return  Call(389,path);
    }
    
    public int ShowTaskBarIcon (int hwnd, int is_show){
    return int.Parse( Call(390,hwnd, is_show));
    }
    
    public int AsmSetTimeout (int time_out, int param){
    return int.Parse( Call(391,time_out, param));
    }
    
    public string DmGuardParams (string cmd, string sub_cmd, string param){
    return  Call(392,cmd, sub_cmd, param);
    }
    
    public int GetModuleSize (int hwnd, string module_name){
    return int.Parse( Call(393,hwnd, module_name));
    }
    
    public int IsSurrpotVt (){
    return int.Parse( Call(394));
    }
    
    public string GetDiskModel (int index){
    return  Call(395,index);
    }
    
    public string GetDiskReversion (int index){
    return  Call(396,index);
    }
    
    public int EnableFindPicMultithread (int en){
    return int.Parse( Call(397,en));
    }
    
    public int GetCpuUsage (){
    return int.Parse( Call(398));
    }
    
    public int GetMemoryUsage (){
    return int.Parse( Call(399));
    }
    
    public string Hex32 (int v){
    return  Call(400,v);
    }
    
    public string Hex64 (long v){
    return  Call(401,v);
    }
    
    public int GetWindowThreadId (int hwnd){
    return int.Parse( Call(402,hwnd));
    }
    
    public int DmGuardExtract (string type, string path){
    return int.Parse( Call(403,type, path));
    }
    
    public int DmGuardLoadCustom (string type, string path){
    return int.Parse( Call(404,type, path));
    }
    
    public int SetShowAsmErrorMsg (int show){
    return int.Parse( Call(405,show));
    }
    
    public string GetSystemInfo (string type, int method){
    return  Call(406,type, method);
    }
    
    public int SetFindPicMultithreadCount (int count){
    return int.Parse( Call(407,count));
    }
    
    public (int,int,int) FindPicSim (int x1, int y1, int x2, int y2, string pic_name, string delta_color, int sim, int dir){
    string resStr = Call(408,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindPicSimEx (int x1, int y1, int x2, int y2, string pic_name, string delta_color, int sim, int dir){
    return  Call(409,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    public (int,int,int) FindPicSimMem (int x1, int y1, int x2, int y2, string pic_info, string delta_color, int sim, int dir){
    string resStr = Call(410,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindPicSimMemEx (int x1, int y1, int x2, int y2, string pic_info, string delta_color, int sim, int dir){
    return  Call(411,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    }
    
    public string FindPicSimE (int x1, int y1, int x2, int y2, string pic_name, string delta_color, int sim, int dir){
    return  Call(412,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    public string FindPicSimMemE (int x1, int y1, int x2, int y2, string pic_info, string delta_color, int sim, int dir){
    return  Call(413,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    }
    
    public int SetInputDm (int input_dm, int rx, int ry){
    return int.Parse( Call(414,input_dm, rx, ry));
    }
    
}

