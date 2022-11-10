
using System.Net.Sockets;
using System.Text;
namespace gacs.Dm;

public class Dmsoft
{
    private static string host = "localhost";
    private static int port = 13000;
    private TcpClient _client = null!;
    private NetworkStream _stream = null!;

    public Dmsoft()
    {
        _client = new TcpClient();
    }

    public async void Connect()
    {
        await _client.ConnectAsync(host, port);
        _stream = _client.GetStream();
    }

    ~Dmsoft()
    {
        Release();
    }

    public async Task Release()
    {
        if (_stream != null)
        {
            await _stream.DisposeAsync();
            _stream.Close();
        }
        if (_client != null)
        {
            _client.Dispose();
            _client.Close();
        }
    }

    // 发送消息
    public async Task<string> Call(params object[] list)
    {
        string cmd = "";
        for (int i = 0; i < list.Length; i++)
        {
            cmd += list[i] + (i == list.Length - 1 ? "" : "\n");
        }

        cmd += "\0";

        byte[] reqBuffer = Encoding.UTF8.GetBytes(cmd);

        await _stream.WriteAsync(reqBuffer);

        byte[] resBuffer = new byte[256];
        await _stream.ReadAsync(resBuffer, 0, resBuffer.Length);
        string res = Encoding.UTF8.GetString(resBuffer).Split("\0")[0];
        var code = res.Substring(0, 1);
        if (code == "0")
        {
            return res.Substring(2);
        }
        throw new Exception(res);
    }

        public async Task<string> Ver (){
    return  await Call(0);
    }
    
    public async Task<int> SetPath (string path){
    return int.Parse( await Call(1,path));
    }
    
    public async Task<string> Ocr (int x1, int y1, int x2, int y2, string color, double sim){
    return  await Call(2,x1, y1, x2, y2, color, sim);
    }
    
    public async Task<(int,int,int)> FindStr (int x1, int y1, int x2, int y2, string str, string color, double sim){
    string resStr = await Call(3,x1, y1, x2, y2, str, color, sim);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<int> GetResultCount (string str){
    return int.Parse( await Call(4,str));
    }
    
    public async Task<(int,int,int)> GetResultPos (string str, int index){
    string resStr = await Call(5,str, index);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<int> StrStr (string s, string str){
    return int.Parse( await Call(6,s, str));
    }
    
    public async Task<int> SendCommand (string cmd){
    return int.Parse( await Call(7,cmd));
    }
    
    public async Task<int> UseDict (int index){
    return int.Parse( await Call(8,index));
    }
    
    public async Task<string> GetBasePath (){
    return  await Call(9);
    }
    
    public async Task<int> SetDictPwd (string pwd){
    return int.Parse( await Call(10,pwd));
    }
    
    public async Task<string> OcrInFile (int x1, int y1, int x2, int y2, string pic_name, string color, double sim){
    return  await Call(11,x1, y1, x2, y2, pic_name, color, sim);
    }
    
    public async Task<int> Capture (int x1, int y1, int x2, int y2, string file){
    return int.Parse( await Call(12,x1, y1, x2, y2, file));
    }
    
    public async Task<int> KeyPress (int vk){
    return int.Parse( await Call(13,vk));
    }
    
    public async Task<int> KeyDown (int vk){
    return int.Parse( await Call(14,vk));
    }
    
    public async Task<int> KeyUp (int vk){
    return int.Parse( await Call(15,vk));
    }
    
    public async Task<int> LeftClick (){
    return int.Parse( await Call(16));
    }
    
    public async Task<int> RightClick (){
    return int.Parse( await Call(17));
    }
    
    public async Task<int> MiddleClick (){
    return int.Parse( await Call(18));
    }
    
    public async Task<int> LeftDoubleClick (){
    return int.Parse( await Call(19));
    }
    
    public async Task<int> LeftDown (){
    return int.Parse( await Call(20));
    }
    
    public async Task<int> LeftUp (){
    return int.Parse( await Call(21));
    }
    
    public async Task<int> RightDown (){
    return int.Parse( await Call(22));
    }
    
    public async Task<int> RightUp (){
    return int.Parse( await Call(23));
    }
    
    public async Task<int> MoveTo (int x, int y){
    return int.Parse( await Call(24,x, y));
    }
    
    public async Task<int> MoveR (int rx, int ry){
    return int.Parse( await Call(25,rx, ry));
    }
    
    public async Task<string> GetColor (int x, int y){
    return  await Call(26,x, y);
    }
    
    public async Task<string> GetColorBGR (int x, int y){
    return  await Call(27,x, y);
    }
    
    public async Task<string> RGB2BGR (string rgb_color){
    return  await Call(28,rgb_color);
    }
    
    public async Task<string> BGR2RGB (string bgr_color){
    return  await Call(29,bgr_color);
    }
    
    public async Task<int> UnBindWindow (){
    return int.Parse( await Call(30));
    }
    
    public async Task<int> CmpColor (int x, int y, string color, double sim){
    return int.Parse( await Call(31,x, y, color, sim));
    }
    
    public async Task<(int,int,int)> ClientToScreen (int hwnd){
    string resStr = await Call(32,hwnd);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<(int,int,int)> ScreenToClient (int hwnd){
    string resStr = await Call(33,hwnd);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<int> ShowScrMsg (int x1, int y1, int x2, int y2, string msg, string color){
    return int.Parse( await Call(34,x1, y1, x2, y2, msg, color));
    }
    
    public async Task<int> SetMinRowGap (int row_gap){
    return int.Parse( await Call(35,row_gap));
    }
    
    public async Task<int> SetMinColGap (int col_gap){
    return int.Parse( await Call(36,col_gap));
    }
    
    public async Task<(int,int,int)> FindColor (int x1, int y1, int x2, int y2, string color, double sim, int dir){
    string resStr = await Call(37,x1, y1, x2, y2, color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<string> FindColorEx (int x1, int y1, int x2, int y2, string color, double sim, int dir){
    return  await Call(38,x1, y1, x2, y2, color, sim, dir);
    }
    
    public async Task<int> SetWordLineHeight (int line_height){
    return int.Parse( await Call(39,line_height));
    }
    
    public async Task<int> SetWordGap (int word_gap){
    return int.Parse( await Call(40,word_gap));
    }
    
    public async Task<int> SetRowGapNoDict (int row_gap){
    return int.Parse( await Call(41,row_gap));
    }
    
    public async Task<int> SetColGapNoDict (int col_gap){
    return int.Parse( await Call(42,col_gap));
    }
    
    public async Task<int> SetWordLineHeightNoDict (int line_height){
    return int.Parse( await Call(43,line_height));
    }
    
    public async Task<int> SetWordGapNoDict (int word_gap){
    return int.Parse( await Call(44,word_gap));
    }
    
    public async Task<int> GetWordResultCount (string str){
    return int.Parse( await Call(45,str));
    }
    
    public async Task<(int,int,int)> GetWordResultPos (string str, int index){
    string resStr = await Call(46,str, index);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<string> GetWordResultStr (string str, int index){
    return  await Call(47,str, index);
    }
    
    public async Task<string> GetWords (int x1, int y1, int x2, int y2, string color, double sim){
    return  await Call(48,x1, y1, x2, y2, color, sim);
    }
    
    public async Task<string> GetWordsNoDict (int x1, int y1, int x2, int y2, string color){
    return  await Call(49,x1, y1, x2, y2, color);
    }
    
    public async Task<int> SetShowErrorMsg (int show){
    return int.Parse( await Call(50,show));
    }
    
    public async Task<(int,int,int)> GetClientSize (int hwnd){
    string resStr = await Call(51,hwnd);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<int> MoveWindow (int hwnd, int x, int y){
    return int.Parse( await Call(52,hwnd, x, y));
    }
    
    public async Task<string> GetColorHSV (int x, int y){
    return  await Call(53,x, y);
    }
    
    public async Task<string> GetAveRGB (int x1, int y1, int x2, int y2){
    return  await Call(54,x1, y1, x2, y2);
    }
    
    public async Task<string> GetAveHSV (int x1, int y1, int x2, int y2){
    return  await Call(55,x1, y1, x2, y2);
    }
    
    public async Task<int> GetForegroundWindow (){
    return int.Parse( await Call(56));
    }
    
    public async Task<int> GetForegroundFocus (){
    return int.Parse( await Call(57));
    }
    
    public async Task<int> GetMousePointWindow (){
    return int.Parse( await Call(58));
    }
    
    public async Task<int> GetPointWindow (int x, int y){
    return int.Parse( await Call(59,x, y));
    }
    
    public async Task<string> EnumWindow (int parent, string title, string class_name, int filter){
    return  await Call(60,parent, title, class_name, filter);
    }
    
    public async Task<int> GetWindowState (int hwnd, int flag){
    return int.Parse( await Call(61,hwnd, flag));
    }
    
    public async Task<int> GetWindow (int hwnd, int flag){
    return int.Parse( await Call(62,hwnd, flag));
    }
    
    public async Task<int> GetSpecialWindow (int flag){
    return int.Parse( await Call(63,flag));
    }
    
    public async Task<int> SetWindowText (int hwnd, string text){
    return int.Parse( await Call(64,hwnd, text));
    }
    
    public async Task<int> SetWindowSize (int hwnd, int width, int height){
    return int.Parse( await Call(65,hwnd, width, height));
    }
    
    public async Task<(int,int,int,int,int)> GetWindowRect (int hwnd){
    string resStr = await Call(66,hwnd);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]),int.Parse(resArray[3]),int.Parse(resArray[4]));
    }
    
    public async Task<string> GetWindowTitle (int hwnd){
    return  await Call(67,hwnd);
    }
    
    public async Task<string> GetWindowClass (int hwnd){
    return  await Call(68,hwnd);
    }
    
    public async Task<int> SetWindowState (int hwnd, int flag){
    return int.Parse( await Call(69,hwnd, flag));
    }
    
    public async Task<int> CreateFoobarRect (int hwnd, int x, int y, int w, int h){
    return int.Parse( await Call(70,hwnd, x, y, w, h));
    }
    
    public async Task<int> CreateFoobarRoundRect (int hwnd, int x, int y, int w, int h, int rw, int rh){
    return int.Parse( await Call(71,hwnd, x, y, w, h, rw, rh));
    }
    
    public async Task<int> CreateFoobarEllipse (int hwnd, int x, int y, int w, int h){
    return int.Parse( await Call(72,hwnd, x, y, w, h));
    }
    
    public async Task<int> CreateFoobarCustom (int hwnd, int x, int y, string pic, string trans_color, double sim){
    return int.Parse( await Call(73,hwnd, x, y, pic, trans_color, sim));
    }
    
    public async Task<int> FoobarFillRect (int hwnd, int x1, int y1, int x2, int y2, string color){
    return int.Parse( await Call(74,hwnd, x1, y1, x2, y2, color));
    }
    
    public async Task<int> FoobarDrawText (int hwnd, int x, int y, int w, int h, string text, string color, int align){
    return int.Parse( await Call(75,hwnd, x, y, w, h, text, color, align));
    }
    
    public async Task<int> FoobarDrawPic (int hwnd, int x, int y, string pic, string trans_color){
    return int.Parse( await Call(76,hwnd, x, y, pic, trans_color));
    }
    
    public async Task<int> FoobarUpdate (int hwnd){
    return int.Parse( await Call(77,hwnd));
    }
    
    public async Task<int> FoobarLock (int hwnd){
    return int.Parse( await Call(78,hwnd));
    }
    
    public async Task<int> FoobarUnlock (int hwnd){
    return int.Parse( await Call(79,hwnd));
    }
    
    public async Task<int> FoobarSetFont (int hwnd, string font_name, int size, int flag){
    return int.Parse( await Call(80,hwnd, font_name, size, flag));
    }
    
    public async Task<int> FoobarTextRect (int hwnd, int x, int y, int w, int h){
    return int.Parse( await Call(81,hwnd, x, y, w, h));
    }
    
    public async Task<int> FoobarPrintText (int hwnd, string text, string color){
    return int.Parse( await Call(82,hwnd, text, color));
    }
    
    public async Task<int> FoobarClearText (int hwnd){
    return int.Parse( await Call(83,hwnd));
    }
    
    public async Task<int> FoobarTextLineGap (int hwnd, int gap){
    return int.Parse( await Call(84,hwnd, gap));
    }
    
    public async Task<int> Play (string file){
    return int.Parse( await Call(85,file));
    }
    
    public async Task<int> FaqCapture (int x1, int y1, int x2, int y2, int quality, int delay, int time){
    return int.Parse( await Call(86,x1, y1, x2, y2, quality, delay, time));
    }
    
    public async Task<int> FaqRelease (int handle){
    return int.Parse( await Call(87,handle));
    }
    
    public async Task<string> FaqSend (string server, int handle, int request_type, int time_out){
    return  await Call(88,server, handle, request_type, time_out);
    }
    
    public async Task<int> Beep (int fre, int delay){
    return int.Parse( await Call(89,fre, delay));
    }
    
    public async Task<int> FoobarClose (int hwnd){
    return int.Parse( await Call(90,hwnd));
    }
    
    public async Task<int> MoveDD (int dx, int dy){
    return int.Parse( await Call(91,dx, dy));
    }
    
    public async Task<int> FaqGetSize (int handle){
    return int.Parse( await Call(92,handle));
    }
    
    public async Task<int> LoadPic (string pic_name){
    return int.Parse( await Call(93,pic_name));
    }
    
    public async Task<int> FreePic (string pic_name){
    return int.Parse( await Call(94,pic_name));
    }
    
    public async Task<int> GetScreenData (int x1, int y1, int x2, int y2){
    return int.Parse( await Call(95,x1, y1, x2, y2));
    }
    
    public async Task<int> FreeScreenData (int handle){
    return int.Parse( await Call(96,handle));
    }
    
    public async Task<int> WheelUp (){
    return int.Parse( await Call(97));
    }
    
    public async Task<int> WheelDown (){
    return int.Parse( await Call(98));
    }
    
    public async Task<int> SetMouseDelay (string type, int delay){
    return int.Parse( await Call(99,type, delay));
    }
    
    public async Task<int> SetKeypadDelay (string type, int delay){
    return int.Parse( await Call(100,type, delay));
    }
    
    public async Task<string> GetEnv (int index, string name){
    return  await Call(101,index, name);
    }
    
    public async Task<int> SetEnv (int index, string name, string value){
    return int.Parse( await Call(102,index, name, value));
    }
    
    public async Task<int> SendString (int hwnd, string str){
    return int.Parse( await Call(103,hwnd, str));
    }
    
    public async Task<int> DelEnv (int index, string name){
    return int.Parse( await Call(104,index, name));
    }
    
    public async Task<string> GetPath (){
    return  await Call(105);
    }
    
    public async Task<int> SetDict (int index, string dict_name){
    return int.Parse( await Call(106,index, dict_name));
    }
    
    public async Task<(int,int,int)> FindPic (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    string resStr = await Call(107,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<string> FindPicEx (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    return  await Call(108,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    public async Task<int> SetClientSize (int hwnd, int width, int height){
    return int.Parse( await Call(109,hwnd, width, height));
    }
    
    public async Task<long> ReadInt (int hwnd, string addr, int type){
    return int.Parse( await Call(110,hwnd, addr, type));
    }
    
    public async Task<float> ReadFloat (int hwnd, string addr){
    return int.Parse( await Call(111,hwnd, addr));
    }
    
    public async Task<double> ReadDouble (int hwnd, string addr){
    return int.Parse( await Call(112,hwnd, addr));
    }
    
    public async Task<string> FindInt (int hwnd, string addr_range, long int_value_min, long int_value_max, int type){
    return  await Call(113,hwnd, addr_range, int_value_min, int_value_max, type);
    }
    
    public async Task<string> FindFloat (int hwnd, string addr_range, float float_value_min, float float_value_max){
    return  await Call(114,hwnd, addr_range, float_value_min, float_value_max);
    }
    
    public async Task<string> FindDouble (int hwnd, string addr_range, double double_value_min, double double_value_max){
    return  await Call(115,hwnd, addr_range, double_value_min, double_value_max);
    }
    
    public async Task<string> FindString (int hwnd, string addr_range, string string_value, int type){
    return  await Call(116,hwnd, addr_range, string_value, type);
    }
    
    public async Task<long> GetModuleBaseAddr (int hwnd, string module_name){
    return int.Parse( await Call(117,hwnd, module_name));
    }
    
    public async Task<string> MoveToEx (int x, int y, int w, int h){
    return  await Call(118,x, y, w, h);
    }
    
    public async Task<string> MatchPicName (string pic_name){
    return  await Call(119,pic_name);
    }
    
    public async Task<int> AddDict (int index, string dict_info){
    return int.Parse( await Call(120,index, dict_info));
    }
    
    public async Task<int> EnterCri (){
    return int.Parse( await Call(121));
    }
    
    public async Task<int> LeaveCri (){
    return int.Parse( await Call(122));
    }
    
    public async Task<int> WriteInt (int hwnd, string addr, int type, long v){
    return int.Parse( await Call(123,hwnd, addr, type, v));
    }
    
    public async Task<int> WriteFloat (int hwnd, string addr, float v){
    return int.Parse( await Call(124,hwnd, addr, v));
    }
    
    public async Task<int> WriteDouble (int hwnd, string addr, double v){
    return int.Parse( await Call(125,hwnd, addr, v));
    }
    
    public async Task<int> WriteString (int hwnd, string addr, int type, string v){
    return int.Parse( await Call(126,hwnd, addr, type, v));
    }
    
    public async Task<int> AsmAdd (string asm_ins){
    return int.Parse( await Call(127,asm_ins));
    }
    
    public async Task<int> AsmClear (){
    return int.Parse( await Call(128));
    }
    
    public async Task<long> AsmCall (int hwnd, int mode){
    return int.Parse( await Call(129,hwnd, mode));
    }
    
    public async Task<(int,int,int)> FindMultiColor (int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir){
    string resStr = await Call(130,x1, y1, x2, y2, first_color, offset_color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<string> FindMultiColorEx (int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir){
    return  await Call(131,x1, y1, x2, y2, first_color, offset_color, sim, dir);
    }
    
    public async Task<string> Assemble (long base_addr, int is_64bit){
    return  await Call(132,base_addr, is_64bit);
    }
    
    public async Task<string> DisAssemble (string asm_code, long base_addr, int is_64bit){
    return  await Call(133,asm_code, base_addr, is_64bit);
    }
    
    public async Task<int> SetWindowTransparent (int hwnd, int v){
    return int.Parse( await Call(134,hwnd, v));
    }
    
    public async Task<string> ReadData (int hwnd, string addr, int len){
    return  await Call(135,hwnd, addr, len);
    }
    
    public async Task<int> WriteData (int hwnd, string addr, string data){
    return int.Parse( await Call(136,hwnd, addr, data));
    }
    
    public async Task<string> FindData (int hwnd, string addr_range, string data){
    return  await Call(137,hwnd, addr_range, data);
    }
    
    public async Task<int> SetPicPwd (string pwd){
    return int.Parse( await Call(138,pwd));
    }
    
    public async Task<int> Log (string info){
    return int.Parse( await Call(139,info));
    }
    
    public async Task<string> FindStrE (int x1, int y1, int x2, int y2, string str, string color, double sim){
    return  await Call(140,x1, y1, x2, y2, str, color, sim);
    }
    
    public async Task<string> FindColorE (int x1, int y1, int x2, int y2, string color, double sim, int dir){
    return  await Call(141,x1, y1, x2, y2, color, sim, dir);
    }
    
    public async Task<string> FindPicE (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    return  await Call(142,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    public async Task<string> FindMultiColorE (int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir){
    return  await Call(143,x1, y1, x2, y2, first_color, offset_color, sim, dir);
    }
    
    public async Task<int> SetExactOcr (int exact_ocr){
    return int.Parse( await Call(144,exact_ocr));
    }
    
    public async Task<string> ReadString (int hwnd, string addr, int type, int len){
    return  await Call(145,hwnd, addr, type, len);
    }
    
    public async Task<int> FoobarTextPrintDir (int hwnd, int dir){
    return int.Parse( await Call(146,hwnd, dir));
    }
    
    public async Task<string> OcrEx (int x1, int y1, int x2, int y2, string color, double sim){
    return  await Call(147,x1, y1, x2, y2, color, sim);
    }
    
    public async Task<int> SetDisplayInput (string mode){
    return int.Parse( await Call(148,mode));
    }
    
    public async Task<int> GetTime (){
    return int.Parse( await Call(149));
    }
    
    public async Task<int> GetScreenWidth (){
    return int.Parse( await Call(150));
    }
    
    public async Task<int> GetScreenHeight (){
    return int.Parse( await Call(151));
    }
    
    public async Task<int> BindWindowEx (int hwnd, string display, string mouse, string keypad, string public_desc, int mode){
    return int.Parse( await Call(152,hwnd, display, mouse, keypad, public_desc, mode));
    }
    
    public async Task<string> GetDiskSerial (int index){
    return  await Call(153,index);
    }
    
    public async Task<string> Md5 (string str){
    return  await Call(154,str);
    }
    
    public async Task<string> GetMac (){
    return  await Call(155);
    }
    
    public async Task<int> ActiveInputMethod (int hwnd, string id){
    return int.Parse( await Call(156,hwnd, id));
    }
    
    public async Task<int> CheckInputMethod (int hwnd, string id){
    return int.Parse( await Call(157,hwnd, id));
    }
    
    public async Task<int> FindInputMethod (string id){
    return int.Parse( await Call(158,id));
    }
    
    public async Task<(int,int,int)> GetCursorPos (){
    string resStr = await Call(159);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<int> BindWindow (int hwnd, string display, string mouse, string keypad, int mode){
    return int.Parse( await Call(160,hwnd, display, mouse, keypad, mode));
    }
    
    public async Task<int> FindWindow (string class_name, string title_name){
    return int.Parse( await Call(161,class_name, title_name));
    }
    
    public async Task<int> GetScreenDepth (){
    return int.Parse( await Call(162));
    }
    
    public async Task<int> SetScreen (int width, int height, int depth){
    return int.Parse( await Call(163,width, height, depth));
    }
    
    public async Task<int> ExitOs (int type){
    return int.Parse( await Call(164,type));
    }
    
    public async Task<string> GetDir (int type){
    return  await Call(165,type);
    }
    
    public async Task<int> GetOsType (){
    return int.Parse( await Call(166));
    }
    
    public async Task<int> FindWindowEx (int parent, string class_name, string title_name){
    return int.Parse( await Call(167,parent, class_name, title_name));
    }
    
    public async Task<int> SetExportDict (int index, string dict_name){
    return int.Parse( await Call(168,index, dict_name));
    }
    
    public async Task<string> GetCursorShape (){
    return  await Call(169);
    }
    
    public async Task<int> DownCpu (int type, int rate){
    return int.Parse( await Call(170,type, rate));
    }
    
    public async Task<string> GetCursorSpot (){
    return  await Call(171);
    }
    
    public async Task<int> SendString2 (int hwnd, string str){
    return int.Parse( await Call(172,hwnd, str));
    }
    
    public async Task<int> FaqPost (string server, int handle, int request_type, int time_out){
    return int.Parse( await Call(173,server, handle, request_type, time_out));
    }
    
    public async Task<string> FaqFetch (){
    return  await Call(174);
    }
    
    public async Task<string> FetchWord (int x1, int y1, int x2, int y2, string color, string word){
    return  await Call(175,x1, y1, x2, y2, color, word);
    }
    
    public async Task<int> CaptureJpg (int x1, int y1, int x2, int y2, string file, int quality){
    return int.Parse( await Call(176,x1, y1, x2, y2, file, quality));
    }
    
    public async Task<(int,int,int)> FindStrWithFont (int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag){
    string resStr = await Call(177,x1, y1, x2, y2, str, color, sim, font_name, font_size, flag);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<string> FindStrWithFontE (int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag){
    return  await Call(178,x1, y1, x2, y2, str, color, sim, font_name, font_size, flag);
    }
    
    public async Task<string> FindStrWithFontEx (int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag){
    return  await Call(179,x1, y1, x2, y2, str, color, sim, font_name, font_size, flag);
    }
    
    public async Task<string> GetDictInfo (string str, string font_name, int font_size, int flag){
    return  await Call(180,str, font_name, font_size, flag);
    }
    
    public async Task<int> SaveDict (int index, string file){
    return int.Parse( await Call(181,index, file));
    }
    
    public async Task<int> GetWindowProcessId (int hwnd){
    return int.Parse( await Call(182,hwnd));
    }
    
    public async Task<string> GetWindowProcessPath (int hwnd){
    return  await Call(183,hwnd);
    }
    
    public async Task<int> LockInput (int _lock){
    return int.Parse( await Call(184,_lock));
    }
    
    public async Task<string> GetPicSize (string pic_name){
    return  await Call(185,pic_name);
    }
    
    public async Task<int> GetID (){
    return int.Parse( await Call(186));
    }
    
    public async Task<int> CapturePng (int x1, int y1, int x2, int y2, string file){
    return int.Parse( await Call(187,x1, y1, x2, y2, file));
    }
    
    public async Task<int> CaptureGif (int x1, int y1, int x2, int y2, string file, int delay, int time){
    return int.Parse( await Call(188,x1, y1, x2, y2, file, delay, time));
    }
    
    public async Task<int> ImageToBmp (string pic_name, string bmp_name){
    return int.Parse( await Call(189,pic_name, bmp_name));
    }
    
    public async Task<(int,int,int)> FindStrFast (int x1, int y1, int x2, int y2, string str, string color, double sim){
    string resStr = await Call(190,x1, y1, x2, y2, str, color, sim);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<string> FindStrFastEx (int x1, int y1, int x2, int y2, string str, string color, double sim){
    return  await Call(191,x1, y1, x2, y2, str, color, sim);
    }
    
    public async Task<string> FindStrFastE (int x1, int y1, int x2, int y2, string str, string color, double sim){
    return  await Call(192,x1, y1, x2, y2, str, color, sim);
    }
    
    public async Task<int> EnableDisplayDebug (int enable_debug){
    return int.Parse( await Call(193,enable_debug));
    }
    
    public async Task<int> CapturePre (string file){
    return int.Parse( await Call(194,file));
    }
    
    public async Task<int> RegEx (string code, string Ver, string ip){
    return int.Parse( await Call(195,code, Ver, ip));
    }
    
    public async Task<string> GetMachineCode (){
    return  await Call(196);
    }
    
    public async Task<int> SetClipboard (string data){
    return int.Parse( await Call(197,data));
    }
    
    public async Task<string> GetClipboard (){
    return  await Call(198);
    }
    
    public async Task<int> GetNowDict (){
    return int.Parse( await Call(199));
    }
    
    public async Task<int> Is64Bit (){
    return int.Parse( await Call(200));
    }
    
    public async Task<int> GetColorNum (int x1, int y1, int x2, int y2, string color, double sim){
    return int.Parse( await Call(201,x1, y1, x2, y2, color, sim));
    }
    
    public async Task<string> EnumWindowByProcess (string process_name, string title, string class_name, int filter){
    return  await Call(202,process_name, title, class_name, filter);
    }
    
    public async Task<int> GetDictCount (int index){
    return int.Parse( await Call(203,index));
    }
    
    public async Task<int> GetLastError (){
    return int.Parse( await Call(204));
    }
    
    public async Task<string> GetNetTime (){
    return  await Call(205);
    }
    
    public async Task<int> EnableGetColorByCapture (int en){
    return int.Parse( await Call(206,en));
    }
    
    public async Task<int> CheckUAC (){
    return int.Parse( await Call(207));
    }
    
    public async Task<int> SetUAC (int uac){
    return int.Parse( await Call(208,uac));
    }
    
    public async Task<int> DisableFontSmooth (){
    return int.Parse( await Call(209));
    }
    
    public async Task<int> CheckFontSmooth (){
    return int.Parse( await Call(210));
    }
    
    public async Task<int> SetDisplayAcceler (int level){
    return int.Parse( await Call(211,level));
    }
    
    public async Task<int> FindWindowByProcess (string process_name, string class_name, string title_name){
    return int.Parse( await Call(212,process_name, class_name, title_name));
    }
    
    public async Task<int> FindWindowByProcessId (int process_id, string class_name, string title_name){
    return int.Parse( await Call(213,process_id, class_name, title_name));
    }
    
    public async Task<string> ReadIni (string section, string key, string file){
    return  await Call(214,section, key, file);
    }
    
    public async Task<int> WriteIni (string section, string key, string v, string file){
    return int.Parse( await Call(215,section, key, v, file));
    }
    
    public async Task<int> RunApp (string path, int mode){
    return int.Parse( await Call(216,path, mode));
    }
    
    public async Task<int> delay (int mis){
    return int.Parse( await Call(217,mis));
    }
    
    public async Task<int> FindWindowSuper (string spec1, int flag1, int type1, string spec2, int flag2, int type2){
    return int.Parse( await Call(218,spec1, flag1, type1, spec2, flag2, type2));
    }
    
    public async Task<string> ExcludePos (string all_pos, int type, int x1, int y1, int x2, int y2){
    return  await Call(219,all_pos, type, x1, y1, x2, y2);
    }
    
    public async Task<string> FindNearestPos (string all_pos, int type, int x, int y){
    return  await Call(220,all_pos, type, x, y);
    }
    
    public async Task<string> SortPosDistance (string all_pos, int type, int x, int y){
    return  await Call(221,all_pos, type, x, y);
    }
    
    public async Task<(int,int,int)> FindPicMem (int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir){
    string resStr = await Call(222,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<string> FindPicMemEx (int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir){
    return  await Call(223,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    }
    
    public async Task<string> FindPicMemE (int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir){
    return  await Call(224,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    }
    
    public async Task<string> AppendPicAddr (string pic_info, int addr, int size){
    return  await Call(225,pic_info, addr, size);
    }
    
    public async Task<int> WriteFile (string file, string content){
    return int.Parse( await Call(226,file, content));
    }
    
    public async Task<int> Stop (int id){
    return int.Parse( await Call(227,id));
    }
    
    public async Task<int> SetDictMem (int index, int addr, int size){
    return int.Parse( await Call(228,index, addr, size));
    }
    
    public async Task<string> GetNetTimeSafe (){
    return  await Call(229);
    }
    
    public async Task<int> ForceUnBindWindow (int hwnd){
    return int.Parse( await Call(230,hwnd));
    }
    
    public async Task<string> ReadIniPwd (string section, string key, string file, string pwd){
    return  await Call(231,section, key, file, pwd);
    }
    
    public async Task<int> WriteIniPwd (string section, string key, string v, string file, string pwd){
    return int.Parse( await Call(232,section, key, v, file, pwd));
    }
    
    public async Task<int> DecodeFile (string file, string pwd){
    return int.Parse( await Call(233,file, pwd));
    }
    
    public async Task<int> KeyDownChar (string key_str){
    return int.Parse( await Call(234,key_str));
    }
    
    public async Task<int> KeyUpChar (string key_str){
    return int.Parse( await Call(235,key_str));
    }
    
    public async Task<int> KeyPressChar (string key_str){
    return int.Parse( await Call(236,key_str));
    }
    
    public async Task<int> KeyPressStr (string key_str, int delay){
    return int.Parse( await Call(237,key_str, delay));
    }
    
    public async Task<int> EnableKeypadPatch (int en){
    return int.Parse( await Call(238,en));
    }
    
    public async Task<int> EnableKeypadSync (int en, int time_out){
    return int.Parse( await Call(239,en, time_out));
    }
    
    public async Task<int> EnableMouseSync (int en, int time_out){
    return int.Parse( await Call(240,en, time_out));
    }
    
    public async Task<int> DmGuard (int en, string type){
    return int.Parse( await Call(241,en, type));
    }
    
    public async Task<int> FaqCaptureFromFile (int x1, int y1, int x2, int y2, string file, int quality){
    return int.Parse( await Call(242,x1, y1, x2, y2, file, quality));
    }
    
    public async Task<string> FindIntEx (int hwnd, string addr_range, long int_value_min, long int_value_max, int type, int step, int multi_thread, int mode){
    return  await Call(243,hwnd, addr_range, int_value_min, int_value_max, type, step, multi_thread, mode);
    }
    
    public async Task<string> FindFloatEx (int hwnd, string addr_range, float float_value_min, float float_value_max, int step, int multi_thread, int mode){
    return  await Call(244,hwnd, addr_range, float_value_min, float_value_max, step, multi_thread, mode);
    }
    
    public async Task<string> FindDoubleEx (int hwnd, string addr_range, double double_value_min, double double_value_max, int step, int multi_thread, int mode){
    return  await Call(245,hwnd, addr_range, double_value_min, double_value_max, step, multi_thread, mode);
    }
    
    public async Task<string> FindStringEx (int hwnd, string addr_range, string string_value, int type, int step, int multi_thread, int mode){
    return  await Call(246,hwnd, addr_range, string_value, type, step, multi_thread, mode);
    }
    
    public async Task<string> FindDataEx (int hwnd, string addr_range, string data, int step, int multi_thread, int mode){
    return  await Call(247,hwnd, addr_range, data, step, multi_thread, mode);
    }
    
    public async Task<int> EnableRealMouse (int en, int mousedelay, int mousestep){
    return int.Parse( await Call(248,en, mousedelay, mousestep));
    }
    
    public async Task<int> EnableRealKeypad (int en){
    return int.Parse( await Call(249,en));
    }
    
    public async Task<int> SendStringIme (string str){
    return int.Parse( await Call(250,str));
    }
    
    public async Task<int> FoobarDrawLine (int hwnd, int x1, int y1, int x2, int y2, string color, int style, int width){
    return int.Parse( await Call(251,hwnd, x1, y1, x2, y2, color, style, width));
    }
    
    public async Task<string> FindStrEx (int x1, int y1, int x2, int y2, string str, string color, double sim){
    return  await Call(252,x1, y1, x2, y2, str, color, sim);
    }
    
    public async Task<int> IsBind (int hwnd){
    return int.Parse( await Call(253,hwnd));
    }
    
    public async Task<int> SetDisplayDelay (int t){
    return int.Parse( await Call(254,t));
    }
    
    public async Task<int> GetDmCount (){
    return int.Parse( await Call(255));
    }
    
    public async Task<int> DisableScreenSave (){
    return int.Parse( await Call(256));
    }
    
    public async Task<int> DisablePowerSave (){
    return int.Parse( await Call(257));
    }
    
    public async Task<int> SetMemoryHwndAsProcessId (int en){
    return int.Parse( await Call(258,en));
    }
    
    public async Task<(int,int,int)> FindShape (int x1, int y1, int x2, int y2, string offset_color, double sim, int dir){
    string resStr = await Call(259,x1, y1, x2, y2, offset_color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<string> FindShapeE (int x1, int y1, int x2, int y2, string offset_color, double sim, int dir){
    return  await Call(260,x1, y1, x2, y2, offset_color, sim, dir);
    }
    
    public async Task<string> FindShapeEx (int x1, int y1, int x2, int y2, string offset_color, double sim, int dir){
    return  await Call(261,x1, y1, x2, y2, offset_color, sim, dir);
    }
    
    public async Task<(string,int,int)> FindStrS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    string resStr = await Call(262,x1, y1, x2, y2, str, color, sim);
    string[] resArray = resStr.Split("\n");
    return (resArray[0],int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<string> FindStrExS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    return  await Call(263,x1, y1, x2, y2, str, color, sim);
    }
    
    public async Task<(string,int,int)> FindStrFastS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    string resStr = await Call(264,x1, y1, x2, y2, str, color, sim);
    string[] resArray = resStr.Split("\n");
    return (resArray[0],int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<string> FindStrFastExS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    return  await Call(265,x1, y1, x2, y2, str, color, sim);
    }
    
    public async Task<(string,int,int)> FindPicS (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    string resStr = await Call(266,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (resArray[0],int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<string> FindPicExS (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    return  await Call(267,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    public async Task<int> ClearDict (int index){
    return int.Parse( await Call(268,index));
    }
    
    public async Task<string> GetMachineCodeNoMac (){
    return  await Call(269);
    }
    
    public async Task<(int,int,int,int,int)> GetClientRect (int hwnd){
    string resStr = await Call(270,hwnd);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]),int.Parse(resArray[3]),int.Parse(resArray[4]));
    }
    
    public async Task<int> EnableFakeActive (int en){
    return int.Parse( await Call(271,en));
    }
    
    public async Task<(int,int,int)> GetScreenDataBmp (int x1, int y1, int x2, int y2){
    string resStr = await Call(272,x1, y1, x2, y2);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<int> EncodeFile (string file, string pwd){
    return int.Parse( await Call(273,file, pwd));
    }
    
    public async Task<string> GetCursorShapeEx (int type){
    return  await Call(274,type);
    }
    
    public async Task<int> FaqCancel (){
    return int.Parse( await Call(275));
    }
    
    public async Task<string> IntToData (long int_value, int type){
    return  await Call(276,int_value, type);
    }
    
    public async Task<string> FloatToData (float float_value){
    return  await Call(277,float_value);
    }
    
    public async Task<string> DoubleToData (double double_value){
    return  await Call(278,double_value);
    }
    
    public async Task<string> StringToData (string string_value, int type){
    return  await Call(279,string_value, type);
    }
    
    public async Task<int> SetMemoryFindResultToFile (string file){
    return int.Parse( await Call(280,file));
    }
    
    public async Task<int> EnableBind (int en){
    return int.Parse( await Call(281,en));
    }
    
    public async Task<int> SetSimMode (int mode){
    return int.Parse( await Call(282,mode));
    }
    
    public async Task<int> LockMouseRect (int x1, int y1, int x2, int y2){
    return int.Parse( await Call(283,x1, y1, x2, y2));
    }
    
    public async Task<int> SendPaste (int hwnd){
    return int.Parse( await Call(284,hwnd));
    }
    
    public async Task<int> IsDisplayDead (int x1, int y1, int x2, int y2, int t){
    return int.Parse( await Call(285,x1, y1, x2, y2, t));
    }
    
    public async Task<int> GetKeyState (int vk){
    return int.Parse( await Call(286,vk));
    }
    
    public async Task<int> CopyFile (string src_file, string dst_file, int over){
    return int.Parse( await Call(287,src_file, dst_file, over));
    }
    
    public async Task<int> IsFileExist (string file){
    return int.Parse( await Call(288,file));
    }
    
    public async Task<int> DeleteFile (string file){
    return int.Parse( await Call(289,file));
    }
    
    public async Task<int> MoveFile (string src_file, string dst_file){
    return int.Parse( await Call(290,src_file, dst_file));
    }
    
    public async Task<int> CreateFolder (string folder_name){
    return int.Parse( await Call(291,folder_name));
    }
    
    public async Task<int> DeleteFolder (string folder_name){
    return int.Parse( await Call(292,folder_name));
    }
    
    public async Task<int> GetFileLength (string file){
    return int.Parse( await Call(293,file));
    }
    
    public async Task<string> ReadFile (string file){
    return  await Call(294,file);
    }
    
    public async Task<int> WaitKey (int key_code, int time_out){
    return int.Parse( await Call(295,key_code, time_out));
    }
    
    public async Task<int> DeleteIni (string section, string key, string file){
    return int.Parse( await Call(296,section, key, file));
    }
    
    public async Task<int> DeleteIniPwd (string section, string key, string file, string pwd){
    return int.Parse( await Call(297,section, key, file, pwd));
    }
    
    public async Task<int> EnableSpeedDx (int en){
    return int.Parse( await Call(298,en));
    }
    
    public async Task<int> EnableIme (int en){
    return int.Parse( await Call(299,en));
    }
    
    public async Task<int> Reg (string code, string Ver){
    return int.Parse( await Call(300,code, Ver));
    }
    
    public async Task<string> SelectFile (){
    return  await Call(301);
    }
    
    public async Task<string> SelectDirectory (){
    return  await Call(302);
    }
    
    public async Task<int> LockDisplay (int _lock){
    return int.Parse( await Call(303,_lock));
    }
    
    public async Task<int> FoobarSetSave (int hwnd, string file, int en, string header){
    return int.Parse( await Call(304,hwnd, file, en, header));
    }
    
    public async Task<string> EnumWindowSuper (string spec1, int flag1, int type1, string spec2, int flag2, int type2, int sort){
    return  await Call(305,spec1, flag1, type1, spec2, flag2, type2, sort);
    }
    
    public async Task<int> DownloadFile (string url, string save_file, int timeout){
    return int.Parse( await Call(306,url, save_file, timeout));
    }
    
    public async Task<int> EnableKeypadMsg (int en){
    return int.Parse( await Call(307,en));
    }
    
    public async Task<int> EnableMouseMsg (int en){
    return int.Parse( await Call(308,en));
    }
    
    public async Task<int> RegNoMac (string code, string Ver){
    return int.Parse( await Call(309,code, Ver));
    }
    
    public async Task<int> RegExNoMac (string code, string Ver, string ip){
    return int.Parse( await Call(310,code, Ver, ip));
    }
    
    public async Task<int> SetEnumWindowDelay (int delay){
    return int.Parse( await Call(311,delay));
    }
    
    public async Task<int> FindMulColor (int x1, int y1, int x2, int y2, string color, double sim){
    return int.Parse( await Call(312,x1, y1, x2, y2, color, sim));
    }
    
    public async Task<string> GetDict (int index, int font_index){
    return  await Call(313,index, font_index);
    }
    
    public async Task<int> GetBindWindow (){
    return int.Parse( await Call(314));
    }
    
    public async Task<int> FoobarStartGif (int hwnd, int x, int y, string pic_name, int repeat_limit, int delay){
    return int.Parse( await Call(315,hwnd, x, y, pic_name, repeat_limit, delay));
    }
    
    public async Task<int> FoobarStopGif (int hwnd, int x, int y, string pic_name){
    return int.Parse( await Call(316,hwnd, x, y, pic_name));
    }
    
    public async Task<int> FreeProcessMemory (int hwnd){
    return int.Parse( await Call(317,hwnd));
    }
    
    public async Task<string> ReadFileData (string file, int start_pos, int end_pos){
    return  await Call(318,file, start_pos, end_pos);
    }
    
    public async Task<long> VirtualAllocEx (int hwnd, long addr, int size, int type){
    return int.Parse( await Call(319,hwnd, addr, size, type));
    }
    
    public async Task<int> VirtualFreeEx (int hwnd, long addr){
    return int.Parse( await Call(320,hwnd, addr));
    }
    
    public async Task<string> GetCommandLine (int hwnd){
    return  await Call(321,hwnd);
    }
    
    public async Task<int> TerminateProcess (int pid){
    return int.Parse( await Call(322,pid));
    }
    
    public async Task<string> GetNetTimeByIp (string ip){
    return  await Call(323,ip);
    }
    
    public async Task<string> EnumProcess (string name){
    return  await Call(324,name);
    }
    
    public async Task<string> GetProcessInfo (int pid){
    return  await Call(325,pid);
    }
    
    public async Task<long> ReadIntAddr (int hwnd, long addr, int type){
    return int.Parse( await Call(326,hwnd, addr, type));
    }
    
    public async Task<string> ReadDataAddr (int hwnd, long addr, int len){
    return  await Call(327,hwnd, addr, len);
    }
    
    public async Task<double> ReadDoubleAddr (int hwnd, long addr){
    return int.Parse( await Call(328,hwnd, addr));
    }
    
    public async Task<float> ReadFloatAddr (int hwnd, long addr){
    return int.Parse( await Call(329,hwnd, addr));
    }
    
    public async Task<string> ReadStringAddr (int hwnd, long addr, int type, int len){
    return  await Call(330,hwnd, addr, type, len);
    }
    
    public async Task<int> WriteDataAddr (int hwnd, long addr, string data){
    return int.Parse( await Call(331,hwnd, addr, data));
    }
    
    public async Task<int> WriteDoubleAddr (int hwnd, long addr, double v){
    return int.Parse( await Call(332,hwnd, addr, v));
    }
    
    public async Task<int> WriteFloatAddr (int hwnd, long addr, float v){
    return int.Parse( await Call(333,hwnd, addr, v));
    }
    
    public async Task<int> WriteIntAddr (int hwnd, long addr, int type, long v){
    return int.Parse( await Call(334,hwnd, addr, type, v));
    }
    
    public async Task<int> WriteStringAddr (int hwnd, long addr, int type, string v){
    return int.Parse( await Call(335,hwnd, addr, type, v));
    }
    
    public async Task<int> Delays (int min_s, int max_s){
    return int.Parse( await Call(336,min_s, max_s));
    }
    
    public async Task<(int,int,int)> FindColorBlock (int x1, int y1, int x2, int y2, string color, double sim, int count, int width, int height){
    string resStr = await Call(337,x1, y1, x2, y2, color, sim, count, width, height);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<string> FindColorBlockEx (int x1, int y1, int x2, int y2, string color, double sim, int count, int width, int height){
    return  await Call(338,x1, y1, x2, y2, color, sim, count, width, height);
    }
    
    public async Task<int> OpenProcess (int pid){
    return int.Parse( await Call(339,pid));
    }
    
    public async Task<string> EnumIniSection (string file){
    return  await Call(340,file);
    }
    
    public async Task<string> EnumIniSectionPwd (string file, string pwd){
    return  await Call(341,file, pwd);
    }
    
    public async Task<string> EnumIniKey (string section, string file){
    return  await Call(342,section, file);
    }
    
    public async Task<string> EnumIniKeyPwd (string section, string file, string pwd){
    return  await Call(343,section, file, pwd);
    }
    
    public async Task<int> SwitchBindWindow (int hwnd){
    return int.Parse( await Call(344,hwnd));
    }
    
    public async Task<int> InitCri (){
    return int.Parse( await Call(345));
    }
    
    public async Task<int> SendStringIme2 (int hwnd, string str, int mode){
    return int.Parse( await Call(346,hwnd, str, mode));
    }
    
    public async Task<string> EnumWindowByProcessId (int pid, string title, string class_name, int filter){
    return  await Call(347,pid, title, class_name, filter);
    }
    
    public async Task<string> GetDisplayInfo (){
    return  await Call(348);
    }
    
    public async Task<int> EnableFontSmooth (){
    return int.Parse( await Call(349));
    }
    
    public async Task<string> OcrExOne (int x1, int y1, int x2, int y2, string color, double sim){
    return  await Call(350,x1, y1, x2, y2, color, sim);
    }
    
    public async Task<int> SetAero (int en){
    return int.Parse( await Call(351,en));
    }
    
    public async Task<int> FoobarSetTrans (int hwnd, int trans, string color, double sim){
    return int.Parse( await Call(352,hwnd, trans, color, sim));
    }
    
    public async Task<int> EnablePicCache (int en){
    return int.Parse( await Call(353,en));
    }
    
    public async Task<int> FaqIsPosted (){
    return int.Parse( await Call(354));
    }
    
    public async Task<int> LoadPicByte (int addr, int size, string name){
    return int.Parse( await Call(355,addr, size, name));
    }
    
    public async Task<int> MiddleDown (){
    return int.Parse( await Call(356));
    }
    
    public async Task<int> MiddleUp (){
    return int.Parse( await Call(357));
    }
    
    public async Task<int> FaqCaptureString (string str){
    return int.Parse( await Call(358,str));
    }
    
    public async Task<int> VirtualProtectEx (int hwnd, long addr, int size, int type, int old_protect){
    return int.Parse( await Call(359,hwnd, addr, size, type, old_protect));
    }
    
    public async Task<int> SetMouseSpeed (int speed){
    return int.Parse( await Call(360,speed));
    }
    
    public async Task<int> GetMouseSpeed (){
    return int.Parse( await Call(361));
    }
    
    public async Task<int> EnableMouseAccuracy (int en){
    return int.Parse( await Call(362,en));
    }
    
    public async Task<int> SetExcludeRegion (int type, string info){
    return int.Parse( await Call(363,type, info));
    }
    
    public async Task<int> EnableShareDict (int en){
    return int.Parse( await Call(364,en));
    }
    
    public async Task<int> DisableCloseDisplayAndSleep (){
    return int.Parse( await Call(365));
    }
    
    public async Task<int> Int64ToInt32 (long v){
    return int.Parse( await Call(366,v));
    }
    
    public async Task<int> GetLocale (){
    return int.Parse( await Call(367));
    }
    
    public async Task<int> SetLocale (){
    return int.Parse( await Call(368));
    }
    
    public async Task<int> ReadDataToBin (int hwnd, string addr, int len){
    return int.Parse( await Call(369,hwnd, addr, len));
    }
    
    public async Task<int> WriteDataFromBin (int hwnd, string addr, int data, int len){
    return int.Parse( await Call(370,hwnd, addr, data, len));
    }
    
    public async Task<int> ReadDataAddrToBin (int hwnd, long addr, int len){
    return int.Parse( await Call(371,hwnd, addr, len));
    }
    
    public async Task<int> WriteDataAddrFromBin (int hwnd, long addr, int data, int len){
    return int.Parse( await Call(372,hwnd, addr, data, len));
    }
    
    public async Task<int> SetParam64ToPointer (){
    return int.Parse( await Call(373));
    }
    
    public async Task<int> GetDPI (){
    return int.Parse( await Call(374));
    }
    
    public async Task<int> SetDisplayRefreshDelay (int t){
    return int.Parse( await Call(375,t));
    }
    
    public async Task<int> IsFolderExist (string folder){
    return int.Parse( await Call(376,folder));
    }
    
    public async Task<int> GetCpuType (){
    return int.Parse( await Call(377));
    }
    
    public async Task<int> ReleaseRef (){
    return int.Parse( await Call(378));
    }
    
    public async Task<int> SetExitThread (int en){
    return int.Parse( await Call(379,en));
    }
    
    public async Task<int> GetFps (){
    return int.Parse( await Call(380));
    }
    
    public async Task<string> VirtualQueryEx (int hwnd, long addr, int pmbi){
    return  await Call(381,hwnd, addr, pmbi);
    }
    
    public async Task<long> AsmCallEx (int hwnd, int mode, string base_addr){
    return int.Parse( await Call(382,hwnd, mode, base_addr));
    }
    
    public async Task<long> GetRemoteApiAddress (int hwnd, long base_addr, string fun_name){
    return int.Parse( await Call(383,hwnd, base_addr, fun_name));
    }
    
    public async Task<string> ExecuteCmd (string cmd, string current_dir, int time_out){
    return  await Call(384,cmd, current_dir, time_out);
    }
    
    public async Task<int> SpeedNormalGraphic (int en){
    return int.Parse( await Call(385,en));
    }
    
    public async Task<int> UnLoadDriver (){
    return int.Parse( await Call(386));
    }
    
    public async Task<int> GetOsBuildNumber (){
    return int.Parse( await Call(387));
    }
    
    public async Task<int> HackSpeed (double rate){
    return int.Parse( await Call(388,rate));
    }
    
    public async Task<string> GetRealPath (string path){
    return  await Call(389,path);
    }
    
    public async Task<int> ShowTaskBarIcon (int hwnd, int is_show){
    return int.Parse( await Call(390,hwnd, is_show));
    }
    
    public async Task<int> AsmSetTimeout (int time_out, int param){
    return int.Parse( await Call(391,time_out, param));
    }
    
    public async Task<string> DmGuardParams (string cmd, string sub_cmd, string param){
    return  await Call(392,cmd, sub_cmd, param);
    }
    
    public async Task<int> GetModuleSize (int hwnd, string module_name){
    return int.Parse( await Call(393,hwnd, module_name));
    }
    
    public async Task<int> IsSurrpotVt (){
    return int.Parse( await Call(394));
    }
    
    public async Task<string> GetDiskModel (int index){
    return  await Call(395,index);
    }
    
    public async Task<string> GetDiskReversion (int index){
    return  await Call(396,index);
    }
    
    public async Task<int> EnableFindPicMultithread (int en){
    return int.Parse( await Call(397,en));
    }
    
    public async Task<int> GetCpuUsage (){
    return int.Parse( await Call(398));
    }
    
    public async Task<int> GetMemoryUsage (){
    return int.Parse( await Call(399));
    }
    
    public async Task<string> Hex32 (int v){
    return  await Call(400,v);
    }
    
    public async Task<string> Hex64 (long v){
    return  await Call(401,v);
    }
    
    public async Task<int> GetWindowThreadId (int hwnd){
    return int.Parse( await Call(402,hwnd));
    }
    
    public async Task<int> DmGuardExtract (string type, string path){
    return int.Parse( await Call(403,type, path));
    }
    
    public async Task<int> DmGuardLoadCustom (string type, string path){
    return int.Parse( await Call(404,type, path));
    }
    
    public async Task<int> SetShowAsmErrorMsg (int show){
    return int.Parse( await Call(405,show));
    }
    
    public async Task<string> GetSystemInfo (string type, int method){
    return  await Call(406,type, method);
    }
    
    public async Task<int> SetFindPicMultithreadCount (int count){
    return int.Parse( await Call(407,count));
    }
    
    public async Task<(int,int,int)> FindPicSim (int x1, int y1, int x2, int y2, string pic_name, string delta_color, int sim, int dir){
    string resStr = await Call(408,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<string> FindPicSimEx (int x1, int y1, int x2, int y2, string pic_name, string delta_color, int sim, int dir){
    return  await Call(409,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    public async Task<(int,int,int)> FindPicSimMem (int x1, int y1, int x2, int y2, string pic_info, string delta_color, int sim, int dir){
    string resStr = await Call(410,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    string[] resArray = resStr.Split("\n");
    return (int.Parse(resArray[0]),int.Parse(resArray[1]),int.Parse(resArray[2]));
    }
    
    public async Task<string> FindPicSimMemEx (int x1, int y1, int x2, int y2, string pic_info, string delta_color, int sim, int dir){
    return  await Call(411,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    }
    
    public async Task<string> FindPicSimE (int x1, int y1, int x2, int y2, string pic_name, string delta_color, int sim, int dir){
    return  await Call(412,x1, y1, x2, y2, pic_name, delta_color, sim, dir);
    }
    
    public async Task<string> FindPicSimMemE (int x1, int y1, int x2, int y2, string pic_info, string delta_color, int sim, int dir){
    return  await Call(413,x1, y1, x2, y2, pic_info, delta_color, sim, dir);
    }
    
    public async Task<int> SetInputDm (int input_dm, int rx, int ry){
    return int.Parse( await Call(414,input_dm, rx, ry));
    }
    
}

