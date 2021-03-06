
using System.IO.MemoryMappedFiles;
using System.Text;

namespace gacs.Dm;
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
        _stream.Close();
        _client.Close();
    }
    // 发送消息
    public string Call(params object[] list) {
        string cmd = "";
        for (int i = 0; i < list.Length; i++) {
            cmd += list[i] + (i == list.Length - 1 ? "" : ",");
        }

        byte[] reqBuffer = Encoding.UTF8.GetBytes(_id + "," + cmd + ' ');
        _mmfAccessor.WriteArray(0, reqBuffer, 0, reqBuffer.Length);
        _dmmmfReqSignal.Release();
        _dmmmfResSignal.WaitOne();
        byte[] resBuffer = new byte[BUFF_SIZE];
        _mmfAccessor.ReadArray(0, resBuffer, 0, resBuffer.Length);
        string res = Encoding.UTF8.GetString(resBuffer);
        return res.Split(" ")[0];
    }

        public string Ver (){
    try {
    return  Call(0);
    } catch (Exception e) {}
    }
    
    public int SetPath (string path){
    try {
    return int.Parse( Call(1,path));
    } catch (Exception e) {}
    }
    
    public string Ocr (int x1, int y1, int x2, int y2, string color, double sim){
    try {
    return  Call(2,x1, y1, x2, y2, color, sim);
    } catch (Exception e) {}
    }
    
    public (int,int,int) FindStr (int x1, int y1, int x2, int y2, string str, string color, double sim){
    try {
    string resStr = Call(3,x1, y1, x2, y2, str, color, sim);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public int GetResultCount (string str){
    try {
    return int.Parse( Call(4,str));
    } catch (Exception e) {}
    }
    
    public (int,int,int) GetResultPos (string str, int index){
    try {
    string resStr = Call(5,str, index);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public int StrStr (string s, string str){
    try {
    return int.Parse( Call(6,s, str));
    } catch (Exception e) {}
    }
    
    public int SendCommand (string cmd){
    try {
    return int.Parse( Call(7,cmd));
    } catch (Exception e) {}
    }
    
    public int UseDict (int index){
    try {
    return int.Parse( Call(8,index));
    } catch (Exception e) {}
    }
    
    public string GetBasePath (){
    try {
    return  Call(9);
    } catch (Exception e) {}
    }
    
    public int SetDictPwd (string pwd){
    try {
    return int.Parse( Call(10,pwd));
    } catch (Exception e) {}
    }
    
    public string OcrInFile (int x1, int y1, int x2, int y2, string pic_name, string color, double sim){
    try {
    return  Call(11,x1, y1, x2, y2, pic_name, color, sim);
    } catch (Exception e) {}
    }
    
    public int Capture (int x1, int y1, int x2, int y2, string file){
    try {
    return int.Parse( Call(12,x1, y1, x2, y2, file));
    } catch (Exception e) {}
    }
    
    public int KeyPress (int vk){
    try {
    return int.Parse( Call(13,vk));
    } catch (Exception e) {}
    }
    
    public int KeyDown (int vk){
    try {
    return int.Parse( Call(14,vk));
    } catch (Exception e) {}
    }
    
    public int KeyUp (int vk){
    try {
    return int.Parse( Call(15,vk));
    } catch (Exception e) {}
    }
    
    public int LeftClick (){
    try {
    return int.Parse( Call(16));
    } catch (Exception e) {}
    }
    
    public int RightClick (){
    try {
    return int.Parse( Call(17));
    } catch (Exception e) {}
    }
    
    public int MiddleClick (){
    try {
    return int.Parse( Call(18));
    } catch (Exception e) {}
    }
    
    public int LeftDoubleClick (){
    try {
    return int.Parse( Call(19));
    } catch (Exception e) {}
    }
    
    public int LeftDown (){
    try {
    return int.Parse( Call(20));
    } catch (Exception e) {}
    }
    
    public int LeftUp (){
    try {
    return int.Parse( Call(21));
    } catch (Exception e) {}
    }
    
    public int RightDown (){
    try {
    return int.Parse( Call(22));
    } catch (Exception e) {}
    }
    
    public int RightUp (){
    try {
    return int.Parse( Call(23));
    } catch (Exception e) {}
    }
    
    public int MoveTo (int x, int y){
    try {
    return int.Parse( Call(24,x, y));
    } catch (Exception e) {}
    }
    
    public int MoveR (int rx, int ry){
    try {
    return int.Parse( Call(25,rx, ry));
    } catch (Exception e) {}
    }
    
    public string GetColor (int x, int y){
    try {
    return  Call(26,x, y);
    } catch (Exception e) {}
    }
    
    public string GetColorBGR (int x, int y){
    try {
    return  Call(27,x, y);
    } catch (Exception e) {}
    }
    
    public string RGB2BGR (string rgb_color){
    try {
    return  Call(28,rgb_color);
    } catch (Exception e) {}
    }
    
    public string BGR2RGB (string bgr_color){
    try {
    return  Call(29,bgr_color);
    } catch (Exception e) {}
    }
    
    public int UnBindWindow (){
    try {
    return int.Parse( Call(30));
    } catch (Exception e) {}
    }
    
    public int CmpColor (int x, int y, string color, double sim){
    try {
    return int.Parse( Call(31,x, y, color, sim));
    } catch (Exception e) {}
    }
    
    public (int,int,int) ClientToScreen (int hwnd){
    try {
    string resStr = Call(32,hwnd);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public (int,int,int) ScreenToClient (int hwnd){
    try {
    string resStr = Call(33,hwnd);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public int ShowScrMsg (int x1, int y1, int x2, int y2, string msg, string color){
    try {
    return int.Parse( Call(34,x1, y1, x2, y2, msg, color));
    } catch (Exception e) {}
    }
    
    public int SetMinRowGap (int row_gap){
    try {
    return int.Parse( Call(35,row_gap));
    } catch (Exception e) {}
    }
    
    public int SetMinColGap (int col_gap){
    try {
    return int.Parse( Call(36,col_gap));
    } catch (Exception e) {}
    }
    
    public (int,int,int) FindColor (int x1, int y1, int x2, int y2, string color, double sim, int dir){
    try {
    string resStr = Call(37,x1, y1, x2, y2, color, sim, dir);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindColorEx (int x1, int y1, int x2, int y2, string color, double sim, int dir){
    try {
    return  Call(38,x1, y1, x2, y2, color, sim, dir);
    } catch (Exception e) {}
    }
    
    public int SetWordLineHeight (int line_height){
    try {
    return int.Parse( Call(39,line_height));
    } catch (Exception e) {}
    }
    
    public int SetWordGap (int word_gap){
    try {
    return int.Parse( Call(40,word_gap));
    } catch (Exception e) {}
    }
    
    public int SetRowGapNoDict (int row_gap){
    try {
    return int.Parse( Call(41,row_gap));
    } catch (Exception e) {}
    }
    
    public int SetColGapNoDict (int col_gap){
    try {
    return int.Parse( Call(42,col_gap));
    } catch (Exception e) {}
    }
    
    public int SetWordLineHeightNoDict (int line_height){
    try {
    return int.Parse( Call(43,line_height));
    } catch (Exception e) {}
    }
    
    public int SetWordGapNoDict (int word_gap){
    try {
    return int.Parse( Call(44,word_gap));
    } catch (Exception e) {}
    }
    
    public int GetWordResultCount (string str){
    try {
    return int.Parse( Call(45,str));
    } catch (Exception e) {}
    }
    
    public (int,int,int) GetWordResultPos (string str, int index){
    try {
    string resStr = Call(46,str, index);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string GetWordResultStr (string str, int index){
    try {
    return  Call(47,str, index);
    } catch (Exception e) {}
    }
    
    public string GetWords (int x1, int y1, int x2, int y2, string color, double sim){
    try {
    return  Call(48,x1, y1, x2, y2, color, sim);
    } catch (Exception e) {}
    }
    
    public string GetWordsNoDict (int x1, int y1, int x2, int y2, string color){
    try {
    return  Call(49,x1, y1, x2, y2, color);
    } catch (Exception e) {}
    }
    
    public int SetShowErrorMsg (int show){
    try {
    return int.Parse( Call(50,show));
    } catch (Exception e) {}
    }
    
    public (int,int,int) GetClientSize (int hwnd){
    try {
    string resStr = Call(51,hwnd);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public int MoveWindow (int hwnd, int x, int y){
    try {
    return int.Parse( Call(52,hwnd, x, y));
    } catch (Exception e) {}
    }
    
    public string GetColorHSV (int x, int y){
    try {
    return  Call(53,x, y);
    } catch (Exception e) {}
    }
    
    public string GetAveRGB (int x1, int y1, int x2, int y2){
    try {
    return  Call(54,x1, y1, x2, y2);
    } catch (Exception e) {}
    }
    
    public string GetAveHSV (int x1, int y1, int x2, int y2){
    try {
    return  Call(55,x1, y1, x2, y2);
    } catch (Exception e) {}
    }
    
    public int GetForegroundWindow (){
    try {
    return int.Parse( Call(56));
    } catch (Exception e) {}
    }
    
    public int GetForegroundFocus (){
    try {
    return int.Parse( Call(57));
    } catch (Exception e) {}
    }
    
    public int GetMousePointWindow (){
    try {
    return int.Parse( Call(58));
    } catch (Exception e) {}
    }
    
    public int GetPointWindow (int x, int y){
    try {
    return int.Parse( Call(59,x, y));
    } catch (Exception e) {}
    }
    
    public string EnumWindow (int parent, string title, string class_name, int filter){
    try {
    return  Call(60,parent, title, class_name, filter);
    } catch (Exception e) {}
    }
    
    public int GetWindowState (int hwnd, int flag){
    try {
    return int.Parse( Call(61,hwnd, flag));
    } catch (Exception e) {}
    }
    
    public int GetWindow (int hwnd, int flag){
    try {
    return int.Parse( Call(62,hwnd, flag));
    } catch (Exception e) {}
    }
    
    public int GetSpecialWindow (int flag){
    try {
    return int.Parse( Call(63,flag));
    } catch (Exception e) {}
    }
    
    public int SetWindowText (int hwnd, string text){
    try {
    return int.Parse( Call(64,hwnd, text));
    } catch (Exception e) {}
    }
    
    public int SetWindowSize (int hwnd, int width, int height){
    try {
    return int.Parse( Call(65,hwnd, width, height));
    } catch (Exception e) {}
    }
    
    public (int,int,int,int,int) GetWindowRect (int hwnd){
    try {
    string resStr = Call(66,hwnd);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]),int.Parse(resArray[3]),int.Parse(resArray[4]));
    }
    
    public string GetWindowTitle (int hwnd){
    try {
    return  Call(67,hwnd);
    } catch (Exception e) {}
    }
    
    public string GetWindowClass (int hwnd){
    try {
    return  Call(68,hwnd);
    } catch (Exception e) {}
    }
    
    public int SetWindowState (int hwnd, int flag){
    try {
    return int.Parse( Call(69,hwnd, flag));
    } catch (Exception e) {}
    }
    
    public int CreateFoobarRect (int hwnd, int x, int y, int w, int h){
    try {
    return int.Parse( Call(70,hwnd, x, y, w, h));
    } catch (Exception e) {}
    }
    
    public int CreateFoobarRoundRect (int hwnd, int x, int y, int w, int h, int rw, int rh){
    try {
    return int.Parse( Call(71,hwnd, x, y, w, h, rw, rh));
    } catch (Exception e) {}
    }
    
    public int CreateFoobarEllipse (int hwnd, int x, int y, int w, int h){
    try {
    return int.Parse( Call(72,hwnd, x, y, w, h));
    } catch (Exception e) {}
    }
    
    public int CreateFoobarCustom (int hwnd, int x, int y, string pic, string trans_color, double sim){
    try {
    return int.Parse( Call(73,hwnd, x, y, pic, trans_color, sim));
    } catch (Exception e) {}
    }
    
    public int FoobarFillRect (int hwnd, int x1, int y1, int x2, int y2, string color){
    try {
    return int.Parse( Call(74,hwnd, x1, y1, x2, y2, color));
    } catch (Exception e) {}
    }
    
    public int FoobarDrawText (int hwnd, int x, int y, int w, int h, string text, string color, int align){
    try {
    return int.Parse( Call(75,hwnd, x, y, w, h, text, color, align));
    } catch (Exception e) {}
    }
    
    public int FoobarDrawPic (int hwnd, int x, int y, string pic, string trans_color){
    try {
    return int.Parse( Call(76,hwnd, x, y, pic, trans_color));
    } catch (Exception e) {}
    }
    
    public int FoobarUpdate (int hwnd){
    try {
    return int.Parse( Call(77,hwnd));
    } catch (Exception e) {}
    }
    
    public int FoobarLock (int hwnd){
    try {
    return int.Parse( Call(78,hwnd));
    } catch (Exception e) {}
    }
    
    public int FoobarUnlock (int hwnd){
    try {
    return int.Parse( Call(79,hwnd));
    } catch (Exception e) {}
    }
    
    public int FoobarSetFont (int hwnd, string font_name, int size, int flag){
    try {
    return int.Parse( Call(80,hwnd, font_name, size, flag));
    } catch (Exception e) {}
    }
    
    public int FoobarTextRect (int hwnd, int x, int y, int w, int h){
    try {
    return int.Parse( Call(81,hwnd, x, y, w, h));
    } catch (Exception e) {}
    }
    
    public int FoobarPrintText (int hwnd, string text, string color){
    try {
    return int.Parse( Call(82,hwnd, text, color));
    } catch (Exception e) {}
    }
    
    public int FoobarClearText (int hwnd){
    try {
    return int.Parse( Call(83,hwnd));
    } catch (Exception e) {}
    }
    
    public int FoobarTextLineGap (int hwnd, int gap){
    try {
    return int.Parse( Call(84,hwnd, gap));
    } catch (Exception e) {}
    }
    
    public int Play (string file){
    try {
    return int.Parse( Call(85,file));
    } catch (Exception e) {}
    }
    
    public int FaqCapture (int x1, int y1, int x2, int y2, int quality, int delay, int time){
    try {
    return int.Parse( Call(86,x1, y1, x2, y2, quality, delay, time));
    } catch (Exception e) {}
    }
    
    public int FaqRelease (int handle){
    try {
    return int.Parse( Call(87,handle));
    } catch (Exception e) {}
    }
    
    public string FaqSend (string server, int handle, int request_type, int time_out){
    try {
    return  Call(88,server, handle, request_type, time_out);
    } catch (Exception e) {}
    }
    
    public int Beep (int fre, int delay){
    try {
    return int.Parse( Call(89,fre, delay));
    } catch (Exception e) {}
    }
    
    public int FoobarClose (int hwnd){
    try {
    return int.Parse( Call(90,hwnd));
    } catch (Exception e) {}
    }
    
    public int MoveDD (int dx, int dy){
    try {
    return int.Parse( Call(91,dx, dy));
    } catch (Exception e) {}
    }
    
    public int FaqGetSize (int handle){
    try {
    return int.Parse( Call(92,handle));
    } catch (Exception e) {}
    }
    
    public int LoadPic (string pic_name){
    try {
    return int.Parse( Call(93,pic_name));
    } catch (Exception e) {}
    }
    
    public int FreePic (string pic_name){
    try {
    return int.Parse( Call(94,pic_name));
    } catch (Exception e) {}
    }
    
    public int GetScreenData (int x1, int y1, int x2, int y2){
    try {
    return int.Parse( Call(95,x1, y1, x2, y2));
    } catch (Exception e) {}
    }
    
    public int FreeScreenData (int handle){
    try {
    return int.Parse( Call(96,handle));
    } catch (Exception e) {}
    }
    
    public int WheelUp (){
    try {
    return int.Parse( Call(97));
    } catch (Exception e) {}
    }
    
    public int WheelDown (){
    try {
    return int.Parse( Call(98));
    } catch (Exception e) {}
    }
    
    public int SetMouseDelay (string type, int delay){
    try {
    return int.Parse( Call(99,type, delay));
    } catch (Exception e) {}
    }
    
    public int SetKeypadDelay (string type, int delay){
    try {
    return int.Parse( Call(100,type, delay));
    } catch (Exception e) {}
    }
    
    public string GetEnv (int index, string name){
    try {
    return  Call(101,index, name);
    } catch (Exception e) {}
    }
    
    public int SetEnv (int index, string name, string value){
    try {
    return int.Parse( Call(102,index, name, value));
    } catch (Exception e) {}
    }
    
    public int SendString (int hwnd, string str){
    try {
    return int.Parse( Call(103,hwnd, str));
    } catch (Exception e) {}
    }
    
    public int DelEnv (int index, string name){
    try {
    return int.Parse( Call(104,index, name));
    } catch (Exception e) {}
    }
    
    public string GetPath (){
    try {
    return  Call(105);
    } catch (Exception e) {}
    }
    
    public int SetDict (int index, string dict_name){
    try {
    return int.Parse( Call(106,index, dict_name));
    } catch (Exception e) {}
    }
    
    public (int,int,int) FindPic (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    try {
    string resStr = Call(107,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindPicEx (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    try {
    return  Call(108,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    } catch (Exception e) {}
    }
    
    public int SetClientSize (int hwnd, int width, int height){
    try {
    return int.Parse( Call(109,hwnd, width, height));
    } catch (Exception e) {}
    }
    
    public long ReadInt (int hwnd, string addr, int type){
    try {
    return int.Parse( Call(110,hwnd, addr, type));
    } catch (Exception e) {}
    }
    
    public float ReadFloat (int hwnd, string addr){
    try {
    return int.Parse( Call(111,hwnd, addr));
    } catch (Exception e) {}
    }
    
    public double ReadDouble (int hwnd, string addr){
    try {
    return int.Parse( Call(112,hwnd, addr));
    } catch (Exception e) {}
    }
    
    public string FindInt (int hwnd, string addr_range, long int_value_min, long int_value_max, int type){
    try {
    return  Call(113,hwnd, addr_range, int_value_min, int_value_max, type);
    } catch (Exception e) {}
    }
    
    public string FindFloat (int hwnd, string addr_range, float float_value_min, float float_value_max){
    try {
    return  Call(114,hwnd, addr_range, float_value_min, float_value_max);
    } catch (Exception e) {}
    }
    
    public string FindDouble (int hwnd, string addr_range, double double_value_min, double double_value_max){
    try {
    return  Call(115,hwnd, addr_range, double_value_min, double_value_max);
    } catch (Exception e) {}
    }
    
    public string FindString (int hwnd, string addr_range, string string_value, int type){
    try {
    return  Call(116,hwnd, addr_range, string_value, type);
    } catch (Exception e) {}
    }
    
    public long GetModuleBaseAddr (int hwnd, string module_name){
    try {
    return int.Parse( Call(117,hwnd, module_name));
    } catch (Exception e) {}
    }
    
    public string MoveToEx (int x, int y, int w, int h){
    try {
    return  Call(118,x, y, w, h);
    } catch (Exception e) {}
    }
    
    public string MatchPicName (string pic_name){
    try {
    return  Call(119,pic_name);
    } catch (Exception e) {}
    }
    
    public int AddDict (int index, string dict_info){
    try {
    return int.Parse( Call(120,index, dict_info));
    } catch (Exception e) {}
    }
    
    public int EnterCri (){
    try {
    return int.Parse( Call(121));
    } catch (Exception e) {}
    }
    
    public int LeaveCri (){
    try {
    return int.Parse( Call(122));
    } catch (Exception e) {}
    }
    
    public int WriteInt (int hwnd, string addr, int type, long v){
    try {
    return int.Parse( Call(123,hwnd, addr, type, v));
    } catch (Exception e) {}
    }
    
    public int WriteFloat (int hwnd, string addr, float v){
    try {
    return int.Parse( Call(124,hwnd, addr, v));
    } catch (Exception e) {}
    }
    
    public int WriteDouble (int hwnd, string addr, double v){
    try {
    return int.Parse( Call(125,hwnd, addr, v));
    } catch (Exception e) {}
    }
    
    public int WriteString (int hwnd, string addr, int type, string v){
    try {
    return int.Parse( Call(126,hwnd, addr, type, v));
    } catch (Exception e) {}
    }
    
    public int AsmAdd (string asm_ins){
    try {
    return int.Parse( Call(127,asm_ins));
    } catch (Exception e) {}
    }
    
    public int AsmClear (){
    try {
    return int.Parse( Call(128));
    } catch (Exception e) {}
    }
    
    public long AsmCall (int hwnd, int mode){
    try {
    return int.Parse( Call(129,hwnd, mode));
    } catch (Exception e) {}
    }
    
    public (int,int,int) FindMultiColor (int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir){
    try {
    string resStr = Call(130,x1, y1, x2, y2, first_color, offset_color, sim, dir);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindMultiColorEx (int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir){
    try {
    return  Call(131,x1, y1, x2, y2, first_color, offset_color, sim, dir);
    } catch (Exception e) {}
    }
    
    public string Assemble (long base_addr, int is_64bit){
    try {
    return  Call(132,base_addr, is_64bit);
    } catch (Exception e) {}
    }
    
    public string DisAssemble (string asm_code, long base_addr, int is_64bit){
    try {
    return  Call(133,asm_code, base_addr, is_64bit);
    } catch (Exception e) {}
    }
    
    public int SetWindowTransparent (int hwnd, int v){
    try {
    return int.Parse( Call(134,hwnd, v));
    } catch (Exception e) {}
    }
    
    public string ReadData (int hwnd, string addr, int len){
    try {
    return  Call(135,hwnd, addr, len);
    } catch (Exception e) {}
    }
    
    public int WriteData (int hwnd, string addr, string data){
    try {
    return int.Parse( Call(136,hwnd, addr, data));
    } catch (Exception e) {}
    }
    
    public string FindData (int hwnd, string addr_range, string data){
    try {
    return  Call(137,hwnd, addr_range, data);
    } catch (Exception e) {}
    }
    
    public int SetPicPwd (string pwd){
    try {
    return int.Parse( Call(138,pwd));
    } catch (Exception e) {}
    }
    
    public int Log (string info){
    try {
    return int.Parse( Call(139,info));
    } catch (Exception e) {}
    }
    
    public string FindStrE (int x1, int y1, int x2, int y2, string str, string color, double sim){
    try {
    return  Call(140,x1, y1, x2, y2, str, color, sim);
    } catch (Exception e) {}
    }
    
    public string FindColorE (int x1, int y1, int x2, int y2, string color, double sim, int dir){
    try {
    return  Call(141,x1, y1, x2, y2, color, sim, dir);
    } catch (Exception e) {}
    }
    
    public string FindPicE (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    try {
    return  Call(142,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    } catch (Exception e) {}
    }
    
    public string FindMultiColorE (int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir){
    try {
    return  Call(143,x1, y1, x2, y2, first_color, offset_color, sim, dir);
    } catch (Exception e) {}
    }
    
    public int SetExactOcr (int exact_ocr){
    try {
    return int.Parse( Call(144,exact_ocr));
    } catch (Exception e) {}
    }
    
    public string ReadString (int hwnd, string addr, int type, int len){
    try {
    return  Call(145,hwnd, addr, type, len);
    } catch (Exception e) {}
    }
    
    public int FoobarTextPrintDir (int hwnd, int dir){
    try {
    return int.Parse( Call(146,hwnd, dir));
    } catch (Exception e) {}
    }
    
    public string OcrEx (int x1, int y1, int x2, int y2, string color, double sim){
    try {
    return  Call(147,x1, y1, x2, y2, color, sim);
    } catch (Exception e) {}
    }
    
    public int SetDisplayInput (string mode){
    try {
    return int.Parse( Call(148,mode));
    } catch (Exception e) {}
    }
    
    public int GetTime (){
    try {
    return int.Parse( Call(149));
    } catch (Exception e) {}
    }
    
    public int GetScreenWidth (){
    try {
    return int.Parse( Call(150));
    } catch (Exception e) {}
    }
    
    public int GetScreenHeight (){
    try {
    return int.Parse( Call(151));
    } catch (Exception e) {}
    }
    
    public int BindWindowEx (int hwnd, string display, string mouse, string keypad, string public_desc, int mode){
    try {
    return int.Parse( Call(152,hwnd, display, mouse, keypad, public_desc, mode));
    } catch (Exception e) {}
    }
    
    public string GetDiskSerial (int index){
    try {
    return  Call(153,index);
    } catch (Exception e) {}
    }
    
    public string Md5 (string str){
    try {
    return  Call(154,str);
    } catch (Exception e) {}
    }
    
    public string GetMac (){
    try {
    return  Call(155);
    } catch (Exception e) {}
    }
    
    public int ActiveInputMethod (int hwnd, string id){
    try {
    return int.Parse( Call(156,hwnd, id));
    } catch (Exception e) {}
    }
    
    public int CheckInputMethod (int hwnd, string id){
    try {
    return int.Parse( Call(157,hwnd, id));
    } catch (Exception e) {}
    }
    
    public int FindInputMethod (string id){
    try {
    return int.Parse( Call(158,id));
    } catch (Exception e) {}
    }
    
    public (int,int,int) GetCursorPos (){
    try {
    string resStr = Call(159);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public int BindWindow (int hwnd, string display, string mouse, string keypad, int mode){
    try {
    return int.Parse( Call(160,hwnd, display, mouse, keypad, mode));
    } catch (Exception e) {}
    }
    
    public int FindWindow (string class_name, string title_name){
    try {
    return int.Parse( Call(161,class_name, title_name));
    } catch (Exception e) {}
    }
    
    public int GetScreenDepth (){
    try {
    return int.Parse( Call(162));
    } catch (Exception e) {}
    }
    
    public int SetScreen (int width, int height, int depth){
    try {
    return int.Parse( Call(163,width, height, depth));
    } catch (Exception e) {}
    }
    
    public int ExitOs (int type){
    try {
    return int.Parse( Call(164,type));
    } catch (Exception e) {}
    }
    
    public string GetDir (int type){
    try {
    return  Call(165,type);
    } catch (Exception e) {}
    }
    
    public int GetOsType (){
    try {
    return int.Parse( Call(166));
    } catch (Exception e) {}
    }
    
    public int FindWindowEx (int parent, string class_name, string title_name){
    try {
    return int.Parse( Call(167,parent, class_name, title_name));
    } catch (Exception e) {}
    }
    
    public int SetExportDict (int index, string dict_name){
    try {
    return int.Parse( Call(168,index, dict_name));
    } catch (Exception e) {}
    }
    
    public string GetCursorShape (){
    try {
    return  Call(169);
    } catch (Exception e) {}
    }
    
    public int DownCpu (int type, int rate){
    try {
    return int.Parse( Call(170,type, rate));
    } catch (Exception e) {}
    }
    
    public string GetCursorSpot (){
    try {
    return  Call(171);
    } catch (Exception e) {}
    }
    
    public int SendString2 (int hwnd, string str){
    try {
    return int.Parse( Call(172,hwnd, str));
    } catch (Exception e) {}
    }
    
    public int FaqPost (string server, int handle, int request_type, int time_out){
    try {
    return int.Parse( Call(173,server, handle, request_type, time_out));
    } catch (Exception e) {}
    }
    
    public string FaqFetch (){
    try {
    return  Call(174);
    } catch (Exception e) {}
    }
    
    public string FetchWord (int x1, int y1, int x2, int y2, string color, string word){
    try {
    return  Call(175,x1, y1, x2, y2, color, word);
    } catch (Exception e) {}
    }
    
    public int CaptureJpg (int x1, int y1, int x2, int y2, string file, int quality){
    try {
    return int.Parse( Call(176,x1, y1, x2, y2, file, quality));
    } catch (Exception e) {}
    }
    
    public (int,int,int) FindStrWithFont (int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag){
    try {
    string resStr = Call(177,x1, y1, x2, y2, str, color, sim, font_name, font_size, flag);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindStrWithFontE (int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag){
    try {
    return  Call(178,x1, y1, x2, y2, str, color, sim, font_name, font_size, flag);
    } catch (Exception e) {}
    }
    
    public string FindStrWithFontEx (int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag){
    try {
    return  Call(179,x1, y1, x2, y2, str, color, sim, font_name, font_size, flag);
    } catch (Exception e) {}
    }
    
    public string GetDictInfo (string str, string font_name, int font_size, int flag){
    try {
    return  Call(180,str, font_name, font_size, flag);
    } catch (Exception e) {}
    }
    
    public int SaveDict (int index, string file){
    try {
    return int.Parse( Call(181,index, file));
    } catch (Exception e) {}
    }
    
    public int GetWindowProcessId (int hwnd){
    try {
    return int.Parse( Call(182,hwnd));
    } catch (Exception e) {}
    }
    
    public string GetWindowProcessPath (int hwnd){
    try {
    return  Call(183,hwnd);
    } catch (Exception e) {}
    }
    
    public int LockInput (int _lock){
    try {
    return int.Parse( Call(184,_lock));
    } catch (Exception e) {}
    }
    
    public string GetPicSize (string pic_name){
    try {
    return  Call(185,pic_name);
    } catch (Exception e) {}
    }
    
    public int GetID (){
    try {
    return int.Parse( Call(186));
    } catch (Exception e) {}
    }
    
    public int CapturePng (int x1, int y1, int x2, int y2, string file){
    try {
    return int.Parse( Call(187,x1, y1, x2, y2, file));
    } catch (Exception e) {}
    }
    
    public int CaptureGif (int x1, int y1, int x2, int y2, string file, int delay, int time){
    try {
    return int.Parse( Call(188,x1, y1, x2, y2, file, delay, time));
    } catch (Exception e) {}
    }
    
    public int ImageToBmp (string pic_name, string bmp_name){
    try {
    return int.Parse( Call(189,pic_name, bmp_name));
    } catch (Exception e) {}
    }
    
    public (int,int,int) FindStrFast (int x1, int y1, int x2, int y2, string str, string color, double sim){
    try {
    string resStr = Call(190,x1, y1, x2, y2, str, color, sim);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindStrFastEx (int x1, int y1, int x2, int y2, string str, string color, double sim){
    try {
    return  Call(191,x1, y1, x2, y2, str, color, sim);
    } catch (Exception e) {}
    }
    
    public string FindStrFastE (int x1, int y1, int x2, int y2, string str, string color, double sim){
    try {
    return  Call(192,x1, y1, x2, y2, str, color, sim);
    } catch (Exception e) {}
    }
    
    public int EnableDisplayDebug (int enable_debug){
    try {
    return int.Parse( Call(193,enable_debug));
    } catch (Exception e) {}
    }
    
    public int CapturePre (string file){
    try {
    return int.Parse( Call(194,file));
    } catch (Exception e) {}
    }
    
    public int RegEx (string code, string Ver, string ip){
    try {
    return int.Parse( Call(195,code, Ver, ip));
    } catch (Exception e) {}
    }
    
    public string GetMachineCode (){
    try {
    return  Call(196);
    } catch (Exception e) {}
    }
    
    public int SetClipboard (string data){
    try {
    return int.Parse( Call(197,data));
    } catch (Exception e) {}
    }
    
    public string GetClipboard (){
    try {
    return  Call(198);
    } catch (Exception e) {}
    }
    
    public int GetNowDict (){
    try {
    return int.Parse( Call(199));
    } catch (Exception e) {}
    }
    
    public int Is64Bit (){
    try {
    return int.Parse( Call(200));
    } catch (Exception e) {}
    }
    
    public int GetColorNum (int x1, int y1, int x2, int y2, string color, double sim){
    try {
    return int.Parse( Call(201,x1, y1, x2, y2, color, sim));
    } catch (Exception e) {}
    }
    
    public string EnumWindowByProcess (string process_name, string title, string class_name, int filter){
    try {
    return  Call(202,process_name, title, class_name, filter);
    } catch (Exception e) {}
    }
    
    public int GetDictCount (int index){
    try {
    return int.Parse( Call(203,index));
    } catch (Exception e) {}
    }
    
    public int GetLastError (){
    try {
    return int.Parse( Call(204));
    } catch (Exception e) {}
    }
    
    public string GetNetTime (){
    try {
    return  Call(205);
    } catch (Exception e) {}
    }
    
    public int EnableGetColorByCapture (int en){
    try {
    return int.Parse( Call(206,en));
    } catch (Exception e) {}
    }
    
    public int CheckUAC (){
    try {
    return int.Parse( Call(207));
    } catch (Exception e) {}
    }
    
    public int SetUAC (int uac){
    try {
    return int.Parse( Call(208,uac));
    } catch (Exception e) {}
    }
    
    public int DisableFontSmooth (){
    try {
    return int.Parse( Call(209));
    } catch (Exception e) {}
    }
    
    public int CheckFontSmooth (){
    try {
    return int.Parse( Call(210));
    } catch (Exception e) {}
    }
    
    public int SetDisplayAcceler (int level){
    try {
    return int.Parse( Call(211,level));
    } catch (Exception e) {}
    }
    
    public int FindWindowByProcess (string process_name, string class_name, string title_name){
    try {
    return int.Parse( Call(212,process_name, class_name, title_name));
    } catch (Exception e) {}
    }
    
    public int FindWindowByProcessId (int process_id, string class_name, string title_name){
    try {
    return int.Parse( Call(213,process_id, class_name, title_name));
    } catch (Exception e) {}
    }
    
    public string ReadIni (string section, string key, string file){
    try {
    return  Call(214,section, key, file);
    } catch (Exception e) {}
    }
    
    public int WriteIni (string section, string key, string v, string file){
    try {
    return int.Parse( Call(215,section, key, v, file));
    } catch (Exception e) {}
    }
    
    public int RunApp (string path, int mode){
    try {
    return int.Parse( Call(216,path, mode));
    } catch (Exception e) {}
    }
    
    public int delay (int mis){
    try {
    return int.Parse( Call(217,mis));
    } catch (Exception e) {}
    }
    
    public int FindWindowSuper (string spec1, int flag1, int type1, string spec2, int flag2, int type2){
    try {
    return int.Parse( Call(218,spec1, flag1, type1, spec2, flag2, type2));
    } catch (Exception e) {}
    }
    
    public string ExcludePos (string all_pos, int type, int x1, int y1, int x2, int y2){
    try {
    return  Call(219,all_pos, type, x1, y1, x2, y2);
    } catch (Exception e) {}
    }
    
    public string FindNearestPos (string all_pos, int type, int x, int y){
    try {
    return  Call(220,all_pos, type, x, y);
    } catch (Exception e) {}
    }
    
    public string SortPosDistance (string all_pos, int type, int x, int y){
    try {
    return  Call(221,all_pos, type, x, y);
    } catch (Exception e) {}
    }
    
    public (int,int,int) FindPicMem (int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir){
    try {
    string resStr = Call(222,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindPicMemEx (int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir){
    try {
    return  Call(223,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    } catch (Exception e) {}
    }
    
    public string FindPicMemE (int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir){
    try {
    return  Call(224,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    } catch (Exception e) {}
    }
    
    public string AppendPicAddr (string pic_info, int addr, int size){
    try {
    return  Call(225,pic_info, addr, size);
    } catch (Exception e) {}
    }
    
    public int WriteFile (string file, string content){
    try {
    return int.Parse( Call(226,file, content));
    } catch (Exception e) {}
    }
    
    public int Stop (int id){
    try {
    return int.Parse( Call(227,id));
    } catch (Exception e) {}
    }
    
    public int SetDictMem (int index, int addr, int size){
    try {
    return int.Parse( Call(228,index, addr, size));
    } catch (Exception e) {}
    }
    
    public string GetNetTimeSafe (){
    try {
    return  Call(229);
    } catch (Exception e) {}
    }
    
    public int ForceUnBindWindow (int hwnd){
    try {
    return int.Parse( Call(230,hwnd));
    } catch (Exception e) {}
    }
    
    public string ReadIniPwd (string section, string key, string file, string pwd){
    try {
    return  Call(231,section, key, file, pwd);
    } catch (Exception e) {}
    }
    
    public int WriteIniPwd (string section, string key, string v, string file, string pwd){
    try {
    return int.Parse( Call(232,section, key, v, file, pwd));
    } catch (Exception e) {}
    }
    
    public int DecodeFile (string file, string pwd){
    try {
    return int.Parse( Call(233,file, pwd));
    } catch (Exception e) {}
    }
    
    public int KeyDownChar (string key_str){
    try {
    return int.Parse( Call(234,key_str));
    } catch (Exception e) {}
    }
    
    public int KeyUpChar (string key_str){
    try {
    return int.Parse( Call(235,key_str));
    } catch (Exception e) {}
    }
    
    public int KeyPressChar (string key_str){
    try {
    return int.Parse( Call(236,key_str));
    } catch (Exception e) {}
    }
    
    public int KeyPressStr (string key_str, int delay){
    try {
    return int.Parse( Call(237,key_str, delay));
    } catch (Exception e) {}
    }
    
    public int EnableKeypadPatch (int en){
    try {
    return int.Parse( Call(238,en));
    } catch (Exception e) {}
    }
    
    public int EnableKeypadSync (int en, int time_out){
    try {
    return int.Parse( Call(239,en, time_out));
    } catch (Exception e) {}
    }
    
    public int EnableMouseSync (int en, int time_out){
    try {
    return int.Parse( Call(240,en, time_out));
    } catch (Exception e) {}
    }
    
    public int DmGuard (int en, string type){
    try {
    return int.Parse( Call(241,en, type));
    } catch (Exception e) {}
    }
    
    public int FaqCaptureFromFile (int x1, int y1, int x2, int y2, string file, int quality){
    try {
    return int.Parse( Call(242,x1, y1, x2, y2, file, quality));
    } catch (Exception e) {}
    }
    
    public string FindIntEx (int hwnd, string addr_range, long int_value_min, long int_value_max, int type, int step, int multi_thread, int mode){
    try {
    return  Call(243,hwnd, addr_range, int_value_min, int_value_max, type, step, multi_thread, mode);
    } catch (Exception e) {}
    }
    
    public string FindFloatEx (int hwnd, string addr_range, float float_value_min, float float_value_max, int step, int multi_thread, int mode){
    try {
    return  Call(244,hwnd, addr_range, float_value_min, float_value_max, step, multi_thread, mode);
    } catch (Exception e) {}
    }
    
    public string FindDoubleEx (int hwnd, string addr_range, double double_value_min, double double_value_max, int step, int multi_thread, int mode){
    try {
    return  Call(245,hwnd, addr_range, double_value_min, double_value_max, step, multi_thread, mode);
    } catch (Exception e) {}
    }
    
    public string FindStringEx (int hwnd, string addr_range, string string_value, int type, int step, int multi_thread, int mode){
    try {
    return  Call(246,hwnd, addr_range, string_value, type, step, multi_thread, mode);
    } catch (Exception e) {}
    }
    
    public string FindDataEx (int hwnd, string addr_range, string data, int step, int multi_thread, int mode){
    try {
    return  Call(247,hwnd, addr_range, data, step, multi_thread, mode);
    } catch (Exception e) {}
    }
    
    public int EnableRealMouse (int en, int mousedelay, int mousestep){
    try {
    return int.Parse( Call(248,en, mousedelay, mousestep));
    } catch (Exception e) {}
    }
    
    public int EnableRealKeypad (int en){
    try {
    return int.Parse( Call(249,en));
    } catch (Exception e) {}
    }
    
    public int SendStringIme (string str){
    try {
    return int.Parse( Call(250,str));
    } catch (Exception e) {}
    }
    
    public int FoobarDrawLine (int hwnd, int x1, int y1, int x2, int y2, string color, int style, int width){
    try {
    return int.Parse( Call(251,hwnd, x1, y1, x2, y2, color, style, width));
    } catch (Exception e) {}
    }
    
    public string FindStrEx (int x1, int y1, int x2, int y2, string str, string color, double sim){
    try {
    return  Call(252,x1, y1, x2, y2, str, color, sim);
    } catch (Exception e) {}
    }
    
    public int IsBind (int hwnd){
    try {
    return int.Parse( Call(253,hwnd));
    } catch (Exception e) {}
    }
    
    public int SetDisplayDelay (int t){
    try {
    return int.Parse( Call(254,t));
    } catch (Exception e) {}
    }
    
    public int GetDmCount (){
    try {
    return int.Parse( Call(255));
    } catch (Exception e) {}
    }
    
    public int DisableScreenSave (){
    try {
    return int.Parse( Call(256));
    } catch (Exception e) {}
    }
    
    public int DisablePowerSave (){
    try {
    return int.Parse( Call(257));
    } catch (Exception e) {}
    }
    
    public int SetMemoryHwndAsProcessId (int en){
    try {
    return int.Parse( Call(258,en));
    } catch (Exception e) {}
    }
    
    public (int,int,int) FindShape (int x1, int y1, int x2, int y2, string offset_color, double sim, int dir){
    try {
    string resStr = Call(259,x1, y1, x2, y2, offset_color, sim, dir);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindShapeE (int x1, int y1, int x2, int y2, string offset_color, double sim, int dir){
    try {
    return  Call(260,x1, y1, x2, y2, offset_color, sim, dir);
    } catch (Exception e) {}
    }
    
    public string FindShapeEx (int x1, int y1, int x2, int y2, string offset_color, double sim, int dir){
    try {
    return  Call(261,x1, y1, x2, y2, offset_color, sim, dir);
    } catch (Exception e) {}
    }
    
    public (string,int,int) FindStrS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    try {
    string resStr = Call(262,x1, y1, x2, y2, str, color, sim);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (resArray[0],int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindStrExS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    try {
    return  Call(263,x1, y1, x2, y2, str, color, sim);
    } catch (Exception e) {}
    }
    
    public (string,int,int) FindStrFastS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    try {
    string resStr = Call(264,x1, y1, x2, y2, str, color, sim);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (resArray[0],int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindStrFastExS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    try {
    return  Call(265,x1, y1, x2, y2, str, color, sim);
    } catch (Exception e) {}
    }
    
    public (string,int,int) FindPicS (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    try {
    string resStr = Call(266,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (resArray[0],int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindPicExS (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    try {
    return  Call(267,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    } catch (Exception e) {}
    }
    
    public int ClearDict (int index){
    try {
    return int.Parse( Call(268,index));
    } catch (Exception e) {}
    }
    
    public string GetMachineCodeNoMac (){
    try {
    return  Call(269);
    } catch (Exception e) {}
    }
    
    public (int,int,int,int,int) GetClientRect (int hwnd){
    try {
    string resStr = Call(270,hwnd);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]),int.Parse(resArray[3]),int.Parse(resArray[4]));
    }
    
    public int EnableFakeActive (int en){
    try {
    return int.Parse( Call(271,en));
    } catch (Exception e) {}
    }
    
    public (int,int,int) GetScreenDataBmp (int x1, int y1, int x2, int y2){
    try {
    string resStr = Call(272,x1, y1, x2, y2);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public int EncodeFile (string file, string pwd){
    try {
    return int.Parse( Call(273,file, pwd));
    } catch (Exception e) {}
    }
    
    public string GetCursorShapeEx (int type){
    try {
    return  Call(274,type);
    } catch (Exception e) {}
    }
    
    public int FaqCancel (){
    try {
    return int.Parse( Call(275));
    } catch (Exception e) {}
    }
    
    public string IntToData (long int_value, int type){
    try {
    return  Call(276,int_value, type);
    } catch (Exception e) {}
    }
    
    public string FloatToData (float float_value){
    try {
    return  Call(277,float_value);
    } catch (Exception e) {}
    }
    
    public string DoubleToData (double double_value){
    try {
    return  Call(278,double_value);
    } catch (Exception e) {}
    }
    
    public string StringToData (string string_value, int type){
    try {
    return  Call(279,string_value, type);
    } catch (Exception e) {}
    }
    
    public int SetMemoryFindResultToFile (string file){
    try {
    return int.Parse( Call(280,file));
    } catch (Exception e) {}
    }
    
    public int EnableBind (int en){
    try {
    return int.Parse( Call(281,en));
    } catch (Exception e) {}
    }
    
    public int SetSimMode (int mode){
    try {
    return int.Parse( Call(282,mode));
    } catch (Exception e) {}
    }
    
    public int LockMouseRect (int x1, int y1, int x2, int y2){
    try {
    return int.Parse( Call(283,x1, y1, x2, y2));
    } catch (Exception e) {}
    }
    
    public int SendPaste (int hwnd){
    try {
    return int.Parse( Call(284,hwnd));
    } catch (Exception e) {}
    }
    
    public int IsDisplayDead (int x1, int y1, int x2, int y2, int t){
    try {
    return int.Parse( Call(285,x1, y1, x2, y2, t));
    } catch (Exception e) {}
    }
    
    public int GetKeyState (int vk){
    try {
    return int.Parse( Call(286,vk));
    } catch (Exception e) {}
    }
    
    public int CopyFile (string src_file, string dst_file, int over){
    try {
    return int.Parse( Call(287,src_file, dst_file, over));
    } catch (Exception e) {}
    }
    
    public int IsFileExist (string file){
    try {
    return int.Parse( Call(288,file));
    } catch (Exception e) {}
    }
    
    public int DeleteFile (string file){
    try {
    return int.Parse( Call(289,file));
    } catch (Exception e) {}
    }
    
    public int MoveFile (string src_file, string dst_file){
    try {
    return int.Parse( Call(290,src_file, dst_file));
    } catch (Exception e) {}
    }
    
    public int CreateFolder (string folder_name){
    try {
    return int.Parse( Call(291,folder_name));
    } catch (Exception e) {}
    }
    
    public int DeleteFolder (string folder_name){
    try {
    return int.Parse( Call(292,folder_name));
    } catch (Exception e) {}
    }
    
    public int GetFileLength (string file){
    try {
    return int.Parse( Call(293,file));
    } catch (Exception e) {}
    }
    
    public string ReadFile (string file){
    try {
    return  Call(294,file);
    } catch (Exception e) {}
    }
    
    public int WaitKey (int key_code, int time_out){
    try {
    return int.Parse( Call(295,key_code, time_out));
    } catch (Exception e) {}
    }
    
    public int DeleteIni (string section, string key, string file){
    try {
    return int.Parse( Call(296,section, key, file));
    } catch (Exception e) {}
    }
    
    public int DeleteIniPwd (string section, string key, string file, string pwd){
    try {
    return int.Parse( Call(297,section, key, file, pwd));
    } catch (Exception e) {}
    }
    
    public int EnableSpeedDx (int en){
    try {
    return int.Parse( Call(298,en));
    } catch (Exception e) {}
    }
    
    public int EnableIme (int en){
    try {
    return int.Parse( Call(299,en));
    } catch (Exception e) {}
    }
    
    public int Reg (string code, string Ver){
    try {
    return int.Parse( Call(300,code, Ver));
    } catch (Exception e) {}
    }
    
    public string SelectFile (){
    try {
    return  Call(301);
    } catch (Exception e) {}
    }
    
    public string SelectDirectory (){
    try {
    return  Call(302);
    } catch (Exception e) {}
    }
    
    public int LockDisplay (int _lock){
    try {
    return int.Parse( Call(303,_lock));
    } catch (Exception e) {}
    }
    
    public int FoobarSetSave (int hwnd, string file, int en, string header){
    try {
    return int.Parse( Call(304,hwnd, file, en, header));
    } catch (Exception e) {}
    }
    
    public string EnumWindowSuper (string spec1, int flag1, int type1, string spec2, int flag2, int type2, int sort){
    try {
    return  Call(305,spec1, flag1, type1, spec2, flag2, type2, sort);
    } catch (Exception e) {}
    }
    
    public int DownloadFile (string url, string save_file, int timeout){
    try {
    return int.Parse( Call(306,url, save_file, timeout));
    } catch (Exception e) {}
    }
    
    public int EnableKeypadMsg (int en){
    try {
    return int.Parse( Call(307,en));
    } catch (Exception e) {}
    }
    
    public int EnableMouseMsg (int en){
    try {
    return int.Parse( Call(308,en));
    } catch (Exception e) {}
    }
    
    public int RegNoMac (string code, string Ver){
    try {
    return int.Parse( Call(309,code, Ver));
    } catch (Exception e) {}
    }
    
    public int RegExNoMac (string code, string Ver, string ip){
    try {
    return int.Parse( Call(310,code, Ver, ip));
    } catch (Exception e) {}
    }
    
    public int SetEnumWindowDelay (int delay){
    try {
    return int.Parse( Call(311,delay));
    } catch (Exception e) {}
    }
    
    public int FindMulColor (int x1, int y1, int x2, int y2, string color, double sim){
    try {
    return int.Parse( Call(312,x1, y1, x2, y2, color, sim));
    } catch (Exception e) {}
    }
    
    public string GetDict (int index, int font_index){
    try {
    return  Call(313,index, font_index);
    } catch (Exception e) {}
    }
    
    public int GetBindWindow (){
    try {
    return int.Parse( Call(314));
    } catch (Exception e) {}
    }
    
    public int FoobarStartGif (int hwnd, int x, int y, string pic_name, int repeat_limit, int delay){
    try {
    return int.Parse( Call(315,hwnd, x, y, pic_name, repeat_limit, delay));
    } catch (Exception e) {}
    }
    
    public int FoobarStopGif (int hwnd, int x, int y, string pic_name){
    try {
    return int.Parse( Call(316,hwnd, x, y, pic_name));
    } catch (Exception e) {}
    }
    
    public int FreeProcessMemory (int hwnd){
    try {
    return int.Parse( Call(317,hwnd));
    } catch (Exception e) {}
    }
    
    public string ReadFileData (string file, int start_pos, int end_pos){
    try {
    return  Call(318,file, start_pos, end_pos);
    } catch (Exception e) {}
    }
    
    public long VirtualAllocEx (int hwnd, long addr, int size, int type){
    try {
    return int.Parse( Call(319,hwnd, addr, size, type));
    } catch (Exception e) {}
    }
    
    public int VirtualFreeEx (int hwnd, long addr){
    try {
    return int.Parse( Call(320,hwnd, addr));
    } catch (Exception e) {}
    }
    
    public string GetCommandLine (int hwnd){
    try {
    return  Call(321,hwnd);
    } catch (Exception e) {}
    }
    
    public int TerminateProcess (int pid){
    try {
    return int.Parse( Call(322,pid));
    } catch (Exception e) {}
    }
    
    public string GetNetTimeByIp (string ip){
    try {
    return  Call(323,ip);
    } catch (Exception e) {}
    }
    
    public string EnumProcess (string name){
    try {
    return  Call(324,name);
    } catch (Exception e) {}
    }
    
    public string GetProcessInfo (int pid){
    try {
    return  Call(325,pid);
    } catch (Exception e) {}
    }
    
    public long ReadIntAddr (int hwnd, long addr, int type){
    try {
    return int.Parse( Call(326,hwnd, addr, type));
    } catch (Exception e) {}
    }
    
    public string ReadDataAddr (int hwnd, long addr, int len){
    try {
    return  Call(327,hwnd, addr, len);
    } catch (Exception e) {}
    }
    
    public double ReadDoubleAddr (int hwnd, long addr){
    try {
    return int.Parse( Call(328,hwnd, addr));
    } catch (Exception e) {}
    }
    
    public float ReadFloatAddr (int hwnd, long addr){
    try {
    return int.Parse( Call(329,hwnd, addr));
    } catch (Exception e) {}
    }
    
    public string ReadStringAddr (int hwnd, long addr, int type, int len){
    try {
    return  Call(330,hwnd, addr, type, len);
    } catch (Exception e) {}
    }
    
    public int WriteDataAddr (int hwnd, long addr, string data){
    try {
    return int.Parse( Call(331,hwnd, addr, data));
    } catch (Exception e) {}
    }
    
    public int WriteDoubleAddr (int hwnd, long addr, double v){
    try {
    return int.Parse( Call(332,hwnd, addr, v));
    } catch (Exception e) {}
    }
    
    public int WriteFloatAddr (int hwnd, long addr, float v){
    try {
    return int.Parse( Call(333,hwnd, addr, v));
    } catch (Exception e) {}
    }
    
    public int WriteIntAddr (int hwnd, long addr, int type, long v){
    try {
    return int.Parse( Call(334,hwnd, addr, type, v));
    } catch (Exception e) {}
    }
    
    public int WriteStringAddr (int hwnd, long addr, int type, string v){
    try {
    return int.Parse( Call(335,hwnd, addr, type, v));
    } catch (Exception e) {}
    }
    
    public int Delays (int min_s, int max_s){
    try {
    return int.Parse( Call(336,min_s, max_s));
    } catch (Exception e) {}
    }
    
    public (int,int,int) FindColorBlock (int x1, int y1, int x2, int y2, string color, double sim, int count, int width, int height){
    try {
    string resStr = Call(337,x1, y1, x2, y2, color, sim, count, width, height);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindColorBlockEx (int x1, int y1, int x2, int y2, string color, double sim, int count, int width, int height){
    try {
    return  Call(338,x1, y1, x2, y2, color, sim, count, width, height);
    } catch (Exception e) {}
    }
    
    public int OpenProcess (int pid){
    try {
    return int.Parse( Call(339,pid));
    } catch (Exception e) {}
    }
    
    public string EnumIniSection (string file){
    try {
    return  Call(340,file);
    } catch (Exception e) {}
    }
    
    public string EnumIniSectionPwd (string file, string pwd){
    try {
    return  Call(341,file, pwd);
    } catch (Exception e) {}
    }
    
    public string EnumIniKey (string section, string file){
    try {
    return  Call(342,section, file);
    } catch (Exception e) {}
    }
    
    public string EnumIniKeyPwd (string section, string file, string pwd){
    try {
    return  Call(343,section, file, pwd);
    } catch (Exception e) {}
    }
    
    public int SwitchBindWindow (int hwnd){
    try {
    return int.Parse( Call(344,hwnd));
    } catch (Exception e) {}
    }
    
    public int InitCri (){
    try {
    return int.Parse( Call(345));
    } catch (Exception e) {}
    }
    
    public int SendStringIme2 (int hwnd, string str, int mode){
    try {
    return int.Parse( Call(346,hwnd, str, mode));
    } catch (Exception e) {}
    }
    
    public string EnumWindowByProcessId (int pid, string title, string class_name, int filter){
    try {
    return  Call(347,pid, title, class_name, filter);
    } catch (Exception e) {}
    }
    
    public string GetDisplayInfo (){
    try {
    return  Call(348);
    } catch (Exception e) {}
    }
    
    public int EnableFontSmooth (){
    try {
    return int.Parse( Call(349));
    } catch (Exception e) {}
    }
    
    public string OcrExOne (int x1, int y1, int x2, int y2, string color, double sim){
    try {
    return  Call(350,x1, y1, x2, y2, color, sim);
    } catch (Exception e) {}
    }
    
    public int SetAero (int en){
    try {
    return int.Parse( Call(351,en));
    } catch (Exception e) {}
    }
    
    public int FoobarSetTrans (int hwnd, int trans, string color, double sim){
    try {
    return int.Parse( Call(352,hwnd, trans, color, sim));
    } catch (Exception e) {}
    }
    
    public int EnablePicCache (int en){
    try {
    return int.Parse( Call(353,en));
    } catch (Exception e) {}
    }
    
    public int FaqIsPosted (){
    try {
    return int.Parse( Call(354));
    } catch (Exception e) {}
    }
    
    public int LoadPicByte (int addr, int size, string name){
    try {
    return int.Parse( Call(355,addr, size, name));
    } catch (Exception e) {}
    }
    
    public int MiddleDown (){
    try {
    return int.Parse( Call(356));
    } catch (Exception e) {}
    }
    
    public int MiddleUp (){
    try {
    return int.Parse( Call(357));
    } catch (Exception e) {}
    }
    
    public int FaqCaptureString (string str){
    try {
    return int.Parse( Call(358,str));
    } catch (Exception e) {}
    }
    
    public int VirtualProtectEx (int hwnd, long addr, int size, int type, int old_protect){
    try {
    return int.Parse( Call(359,hwnd, addr, size, type, old_protect));
    } catch (Exception e) {}
    }
    
    public int SetMouseSpeed (int speed){
    try {
    return int.Parse( Call(360,speed));
    } catch (Exception e) {}
    }
    
    public int GetMouseSpeed (){
    try {
    return int.Parse( Call(361));
    } catch (Exception e) {}
    }
    
    public int EnableMouseAccuracy (int en){
    try {
    return int.Parse( Call(362,en));
    } catch (Exception e) {}
    }
    
    public int SetExcludeRegion (int type, string info){
    try {
    return int.Parse( Call(363,type, info));
    } catch (Exception e) {}
    }
    
    public int EnableShareDict (int en){
    try {
    return int.Parse( Call(364,en));
    } catch (Exception e) {}
    }
    
    public int DisableCloseDisplayAndSleep (){
    try {
    return int.Parse( Call(365));
    } catch (Exception e) {}
    }
    
    public int Int64ToInt32 (long v){
    try {
    return int.Parse( Call(366,v));
    } catch (Exception e) {}
    }
    
    public int GetLocale (){
    try {
    return int.Parse( Call(367));
    } catch (Exception e) {}
    }
    
    public int SetLocale (){
    try {
    return int.Parse( Call(368));
    } catch (Exception e) {}
    }
    
    public int ReadDataToBin (int hwnd, string addr, int len){
    try {
    return int.Parse( Call(369,hwnd, addr, len));
    } catch (Exception e) {}
    }
    
    public int WriteDataFromBin (int hwnd, string addr, int data, int len){
    try {
    return int.Parse( Call(370,hwnd, addr, data, len));
    } catch (Exception e) {}
    }
    
    public int ReadDataAddrToBin (int hwnd, long addr, int len){
    try {
    return int.Parse( Call(371,hwnd, addr, len));
    } catch (Exception e) {}
    }
    
    public int WriteDataAddrFromBin (int hwnd, long addr, int data, int len){
    try {
    return int.Parse( Call(372,hwnd, addr, data, len));
    } catch (Exception e) {}
    }
    
    public int SetParam64ToPointer (){
    try {
    return int.Parse( Call(373));
    } catch (Exception e) {}
    }
    
    public int GetDPI (){
    try {
    return int.Parse( Call(374));
    } catch (Exception e) {}
    }
    
    public int SetDisplayRefreshDelay (int t){
    try {
    return int.Parse( Call(375,t));
    } catch (Exception e) {}
    }
    
    public int IsFolderExist (string folder){
    try {
    return int.Parse( Call(376,folder));
    } catch (Exception e) {}
    }
    
    public int GetCpuType (){
    try {
    return int.Parse( Call(377));
    } catch (Exception e) {}
    }
    
    public int ReleaseRef (){
    try {
    return int.Parse( Call(378));
    } catch (Exception e) {}
    }
    
    public int SetExitThread (int en){
    try {
    return int.Parse( Call(379,en));
    } catch (Exception e) {}
    }
    
    public int GetFps (){
    try {
    return int.Parse( Call(380));
    } catch (Exception e) {}
    }
    
    public string VirtualQueryEx (int hwnd, long addr, int pmbi){
    try {
    return  Call(381,hwnd, addr, pmbi);
    } catch (Exception e) {}
    }
    
    public long AsmCallEx (int hwnd, int mode, string base_addr){
    try {
    return int.Parse( Call(382,hwnd, mode, base_addr));
    } catch (Exception e) {}
    }
    
    public long GetRemoteApiAddress (int hwnd, long base_addr, string fun_name){
    try {
    return int.Parse( Call(383,hwnd, base_addr, fun_name));
    } catch (Exception e) {}
    }
    
    public string ExecuteCmd (string cmd, string current_dir, int time_out){
    try {
    return  Call(384,cmd, current_dir, time_out);
    } catch (Exception e) {}
    }
    
    public int SpeedNormalGraphic (int en){
    try {
    return int.Parse( Call(385,en));
    } catch (Exception e) {}
    }
    
    public int UnLoadDriver (){
    try {
    return int.Parse( Call(386));
    } catch (Exception e) {}
    }
    
    public int GetOsBuildNumber (){
    try {
    return int.Parse( Call(387));
    } catch (Exception e) {}
    }
    
    public int HackSpeed (double rate){
    try {
    return int.Parse( Call(388,rate));
    } catch (Exception e) {}
    }
    
    public string GetRealPath (string path){
    try {
    return  Call(389,path);
    } catch (Exception e) {}
    }
    
    public int ShowTaskBarIcon (int hwnd, int is_show){
    try {
    return int.Parse( Call(390,hwnd, is_show));
    } catch (Exception e) {}
    }
    
    public int AsmSetTimeout (int time_out, int param){
    try {
    return int.Parse( Call(391,time_out, param));
    } catch (Exception e) {}
    }
    
    public string DmGuardParams (string cmd, string sub_cmd, string param){
    try {
    return  Call(392,cmd, sub_cmd, param);
    } catch (Exception e) {}
    }
    
    public int GetModuleSize (int hwnd, string module_name){
    try {
    return int.Parse( Call(393,hwnd, module_name));
    } catch (Exception e) {}
    }
    
    public int IsSurrpotVt (){
    try {
    return int.Parse( Call(394));
    } catch (Exception e) {}
    }
    
    public string GetDiskModel (int index){
    try {
    return  Call(395,index);
    } catch (Exception e) {}
    }
    
    public string GetDiskReversion (int index){
    try {
    return  Call(396,index);
    } catch (Exception e) {}
    }
    
    public int EnableFindPicMultithread (int en){
    try {
    return int.Parse( Call(397,en));
    } catch (Exception e) {}
    }
    
    public int GetCpuUsage (){
    try {
    return int.Parse( Call(398));
    } catch (Exception e) {}
    }
    
    public int GetMemoryUsage (){
    try {
    return int.Parse( Call(399));
    } catch (Exception e) {}
    }
    
    public string Hex32 (int v){
    try {
    return  Call(400,v);
    } catch (Exception e) {}
    }
    
    public string Hex64 (long v){
    try {
    return  Call(401,v);
    } catch (Exception e) {}
    }
    
    public int GetWindowThreadId (int hwnd){
    try {
    return int.Parse( Call(402,hwnd));
    } catch (Exception e) {}
    }
    
    public int DmGuardExtract (string type, string path){
    try {
    return int.Parse( Call(403,type, path));
    } catch (Exception e) {}
    }
    
    public int DmGuardLoadCustom (string type, string path){
    try {
    return int.Parse( Call(404,type, path));
    } catch (Exception e) {}
    }
    
    public int SetShowAsmErrorMsg (int show){
    try {
    return int.Parse( Call(405,show));
    } catch (Exception e) {}
    }
    
    public string GetSystemInfo (string type, int method){
    try {
    return  Call(406,type, method);
    } catch (Exception e) {}
    }
    
    public int SetFindPicMultithreadCount (int count){
    try {
    return int.Parse( Call(407,count));
    } catch (Exception e) {}
    }
    
    public (int,int,int) FindPicSim (int x1, int y1, int x2, int y2, string pic_name, string delta_color, int sim, int dir){
    try {
    string resStr = Call(408,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindPicSimEx (int x1, int y1, int x2, int y2, string pic_name, string delta_color, int sim, int dir){
    try {
    return  Call(409,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    } catch (Exception e) {}
    }
    
    public (int,int,int) FindPicSimMem (int x1, int y1, int x2, int y2, string pic_info, string delta_color, int sim, int dir){
    try {
    string resStr = Call(410,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    } catch (Exception e) {}
    string[] resArray = resStr.Split(",");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public string FindPicSimMemEx (int x1, int y1, int x2, int y2, string pic_info, string delta_color, int sim, int dir){
    try {
    return  Call(411,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    } catch (Exception e) {}
    }
    
    public string FindPicSimE (int x1, int y1, int x2, int y2, string pic_name, string delta_color, int sim, int dir){
    try {
    return  Call(412,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    } catch (Exception e) {}
    }
    
    public string FindPicSimMemE (int x1, int y1, int x2, int y2, string pic_info, string delta_color, int sim, int dir){
    try {
    return  Call(413,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    } catch (Exception e) {}
    }
    
    public int SetInputDm (int input_dm, int rx, int ry){
    try {
    return int.Parse( Call(414,input_dm, rx, ry));
    } catch (Exception e) {}
    }
    
}

