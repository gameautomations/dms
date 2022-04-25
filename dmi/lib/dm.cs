using System.Runtime.InteropServices;

namespace gadmnet.dm;

public class GaDm
{
    public Idmsoft Dm;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public GaDm()
    {
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CA1416 // Validate platform compatibility
        Dm = Activator.CreateInstance(Type.GetTypeFromProgID("dm.dmsoft")!) as Idmsoft;
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning restore CS8601 // Possible null reference assignment.
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    // 调用此接口进行com对象释放
    private void ReleaseObj()
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (Dm == null)
        {
            return;
        }
#pragma warning disable CA1416 // Validate platform compatibility
        _ = Marshal.ReleaseComObject(Dm);
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Dm = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    ~GaDm()
    {
        ReleaseObj();
    }

    [DllImport("dll/DmReg.dll", CharSet = CharSet.Ansi)]
    private static extern int SetDllPathA(string path, int mode);

    // 免注册调用大漠插件
    public static bool Register()
    {
        var setDllPathResult = SetDllPathA("dll/dm.dll", 1);
        if (setDllPathResult == 0)
        {
            // 加载 dm.dll 失败
            throw new Exception("插件加载失败，程序无法运行");
        }

        return true;
    }

    // 大漠实例方法

        public string Ver (){
    var ret = Dm.Ver();
    return ret;
    }
    
    public int SetPath (string path){
    var ret = Dm.SetPath( path);
    return ret;
    }
    
    public string Ocr (int x1, int y1, int x2, int y2, string color, double sim){
    var ret = Dm.Ocr( x1,  y1,  x2,  y2,  color,  sim);
    return ret;
    }
    
    public (int, int,int) FindStr (int x1, int y1, int x2, int y2, string str, string color, double sim){
    var ret = Dm.FindStr( x1,  y1,  x2,  y2,  str,  color,  sim, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public int GetResultCount (string str){
    var ret = Dm.GetResultCount( str);
    return ret;
    }
    
    public (int, int,int) GetResultPos (string str, int index){
    var ret = Dm.GetResultPos( str,  index, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public int StrStr (string s, string str){
    var ret = Dm.StrStr( s,  str);
    return ret;
    }
    
    public int SendCommand (string cmd){
    var ret = Dm.SendCommand( cmd);
    return ret;
    }
    
    public int UseDict (int index){
    var ret = Dm.UseDict( index);
    return ret;
    }
    
    public string GetBasePath (){
    var ret = Dm.GetBasePath();
    return ret;
    }
    
    public int SetDictPwd (string pwd){
    var ret = Dm.SetDictPwd( pwd);
    return ret;
    }
    
    public string OcrInFile (int x1, int y1, int x2, int y2, string pic_name, string color, double sim){
    var ret = Dm.OcrInFile( x1,  y1,  x2,  y2,  pic_name,  color,  sim);
    return ret;
    }
    
    public int Capture (int x1, int y1, int x2, int y2, string file){
    var ret = Dm.Capture( x1,  y1,  x2,  y2,  file);
    return ret;
    }
    
    public int KeyPress (int vk){
    var ret = Dm.KeyPress( vk);
    return ret;
    }
    
    public int KeyDown (int vk){
    var ret = Dm.KeyDown( vk);
    return ret;
    }
    
    public int KeyUp (int vk){
    var ret = Dm.KeyUp( vk);
    return ret;
    }
    
    public int LeftClick (){
    var ret = Dm.LeftClick();
    return ret;
    }
    
    public int RightClick (){
    var ret = Dm.RightClick();
    return ret;
    }
    
    public int MiddleClick (){
    var ret = Dm.MiddleClick();
    return ret;
    }
    
    public int LeftDoubleClick (){
    var ret = Dm.LeftDoubleClick();
    return ret;
    }
    
    public int LeftDown (){
    var ret = Dm.LeftDown();
    return ret;
    }
    
    public int LeftUp (){
    var ret = Dm.LeftUp();
    return ret;
    }
    
    public int RightDown (){
    var ret = Dm.RightDown();
    return ret;
    }
    
    public int RightUp (){
    var ret = Dm.RightUp();
    return ret;
    }
    
    public int MoveTo (int x, int y){
    var ret = Dm.MoveTo( x,  y);
    return ret;
    }
    
    public int MoveR (int rx, int ry){
    var ret = Dm.MoveR( rx,  ry);
    return ret;
    }
    
    public string GetColor (int x, int y){
    var ret = Dm.GetColor( x,  y);
    return ret;
    }
    
    public string GetColorBGR (int x, int y){
    var ret = Dm.GetColorBGR( x,  y);
    return ret;
    }
    
    public string RGB2BGR (string rgb_color){
    var ret = Dm.RGB2BGR( rgb_color);
    return ret;
    }
    
    public string BGR2RGB (string bgr_color){
    var ret = Dm.BGR2RGB( bgr_color);
    return ret;
    }
    
    public int UnBindWindow (){
    var ret = Dm.UnBindWindow();
    return ret;
    }
    
    public int CmpColor (int x, int y, string color, double sim){
    var ret = Dm.CmpColor( x,  y,  color,  sim);
    return ret;
    }
    
    public (int, int,int) ClientToScreen (int hwnd){
    var ret = Dm.ClientToScreen( hwnd, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public (int, int,int) ScreenToClient (int hwnd){
    var ret = Dm.ScreenToClient( hwnd, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public int ShowScrMsg (int x1, int y1, int x2, int y2, string msg, string color){
    var ret = Dm.ShowScrMsg( x1,  y1,  x2,  y2,  msg,  color);
    return ret;
    }
    
    public int SetMinRowGap (int row_gap){
    var ret = Dm.SetMinRowGap( row_gap);
    return ret;
    }
    
    public int SetMinColGap (int col_gap){
    var ret = Dm.SetMinColGap( col_gap);
    return ret;
    }
    
    public (int, int,int) FindColor (int x1, int y1, int x2, int y2, string color, double sim, int dir){
    var ret = Dm.FindColor( x1,  y1,  x2,  y2,  color,  sim,  dir, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public string FindColorEx (int x1, int y1, int x2, int y2, string color, double sim, int dir){
    var ret = Dm.FindColorEx( x1,  y1,  x2,  y2,  color,  sim,  dir);
    return ret;
    }
    
    public int SetWordLineHeight (int line_height){
    var ret = Dm.SetWordLineHeight( line_height);
    return ret;
    }
    
    public int SetWordGap (int word_gap){
    var ret = Dm.SetWordGap( word_gap);
    return ret;
    }
    
    public int SetRowGapNoDict (int row_gap){
    var ret = Dm.SetRowGapNoDict( row_gap);
    return ret;
    }
    
    public int SetColGapNoDict (int col_gap){
    var ret = Dm.SetColGapNoDict( col_gap);
    return ret;
    }
    
    public int SetWordLineHeightNoDict (int line_height){
    var ret = Dm.SetWordLineHeightNoDict( line_height);
    return ret;
    }
    
    public int SetWordGapNoDict (int word_gap){
    var ret = Dm.SetWordGapNoDict( word_gap);
    return ret;
    }
    
    public int GetWordResultCount (string str){
    var ret = Dm.GetWordResultCount( str);
    return ret;
    }
    
    public (int, int,int) GetWordResultPos (string str, int index){
    var ret = Dm.GetWordResultPos( str,  index, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public string GetWordResultStr (string str, int index){
    var ret = Dm.GetWordResultStr( str,  index);
    return ret;
    }
    
    public string GetWords (int x1, int y1, int x2, int y2, string color, double sim){
    var ret = Dm.GetWords( x1,  y1,  x2,  y2,  color,  sim);
    return ret;
    }
    
    public string GetWordsNoDict (int x1, int y1, int x2, int y2, string color){
    var ret = Dm.GetWordsNoDict( x1,  y1,  x2,  y2,  color);
    return ret;
    }
    
    public int SetShowErrorMsg (int show){
    var ret = Dm.SetShowErrorMsg( show);
    return ret;
    }
    
    public (int, int,int) GetClientSize (int hwnd){
    var ret = Dm.GetClientSize( hwnd, out object width, out object height);
    return (ret, (int)width,(int)height);
    }
    
    public int MoveWindow (int hwnd, int x, int y){
    var ret = Dm.MoveWindow( hwnd,  x,  y);
    return ret;
    }
    
    public string GetColorHSV (int x, int y){
    var ret = Dm.GetColorHSV( x,  y);
    return ret;
    }
    
    public string GetAveRGB (int x1, int y1, int x2, int y2){
    var ret = Dm.GetAveRGB( x1,  y1,  x2,  y2);
    return ret;
    }
    
    public string GetAveHSV (int x1, int y1, int x2, int y2){
    var ret = Dm.GetAveHSV( x1,  y1,  x2,  y2);
    return ret;
    }
    
    public int GetForegroundWindow (){
    var ret = Dm.GetForegroundWindow();
    return ret;
    }
    
    public int GetForegroundFocus (){
    var ret = Dm.GetForegroundFocus();
    return ret;
    }
    
    public int GetMousePointWindow (){
    var ret = Dm.GetMousePointWindow();
    return ret;
    }
    
    public int GetPointWindow (int x, int y){
    var ret = Dm.GetPointWindow( x,  y);
    return ret;
    }
    
    public string EnumWindow (int parent, string title, string class_name, int filter){
    var ret = Dm.EnumWindow( parent,  title,  class_name,  filter);
    return ret;
    }
    
    public int GetWindowState (int hwnd, int flag){
    var ret = Dm.GetWindowState( hwnd,  flag);
    return ret;
    }
    
    public int GetWindow (int hwnd, int flag){
    var ret = Dm.GetWindow( hwnd,  flag);
    return ret;
    }
    
    public int GetSpecialWindow (int flag){
    var ret = Dm.GetSpecialWindow( flag);
    return ret;
    }
    
    public int SetWindowText (int hwnd, string text){
    var ret = Dm.SetWindowText( hwnd,  text);
    return ret;
    }
    
    public int SetWindowSize (int hwnd, int width, int height){
    var ret = Dm.SetWindowSize( hwnd,  width,  height);
    return ret;
    }
    
    public (int, int,int,int,int) GetWindowRect (int hwnd){
    var ret = Dm.GetWindowRect( hwnd, out object x1, out object y1, out object x2, out object y2);
    return (ret, (int)x1,(int)y1,(int)x2,(int)y2);
    }
    
    public string GetWindowTitle (int hwnd){
    var ret = Dm.GetWindowTitle( hwnd);
    return ret;
    }
    
    public string GetWindowClass (int hwnd){
    var ret = Dm.GetWindowClass( hwnd);
    return ret;
    }
    
    public int SetWindowState (int hwnd, int flag){
    var ret = Dm.SetWindowState( hwnd,  flag);
    return ret;
    }
    
    public int CreateFoobarRect (int hwnd, int x, int y, int w, int h){
    var ret = Dm.CreateFoobarRect( hwnd,  x,  y,  w,  h);
    return ret;
    }
    
    public int CreateFoobarRoundRect (int hwnd, int x, int y, int w, int h, int rw, int rh){
    var ret = Dm.CreateFoobarRoundRect( hwnd,  x,  y,  w,  h,  rw,  rh);
    return ret;
    }
    
    public int CreateFoobarEllipse (int hwnd, int x, int y, int w, int h){
    var ret = Dm.CreateFoobarEllipse( hwnd,  x,  y,  w,  h);
    return ret;
    }
    
    public int CreateFoobarCustom (int hwnd, int x, int y, string pic, string trans_color, double sim){
    var ret = Dm.CreateFoobarCustom( hwnd,  x,  y,  pic,  trans_color,  sim);
    return ret;
    }
    
    public int FoobarFillRect (int hwnd, int x1, int y1, int x2, int y2, string color){
    var ret = Dm.FoobarFillRect( hwnd,  x1,  y1,  x2,  y2,  color);
    return ret;
    }
    
    public int FoobarDrawText (int hwnd, int x, int y, int w, int h, string text, string color, int align){
    var ret = Dm.FoobarDrawText( hwnd,  x,  y,  w,  h,  text,  color,  align);
    return ret;
    }
    
    public int FoobarDrawPic (int hwnd, int x, int y, string pic, string trans_color){
    var ret = Dm.FoobarDrawPic( hwnd,  x,  y,  pic,  trans_color);
    return ret;
    }
    
    public int FoobarUpdate (int hwnd){
    var ret = Dm.FoobarUpdate( hwnd);
    return ret;
    }
    
    public int FoobarLock (int hwnd){
    var ret = Dm.FoobarLock( hwnd);
    return ret;
    }
    
    public int FoobarUnlock (int hwnd){
    var ret = Dm.FoobarUnlock( hwnd);
    return ret;
    }
    
    public int FoobarSetFont (int hwnd, string font_name, int size, int flag){
    var ret = Dm.FoobarSetFont( hwnd,  font_name,  size,  flag);
    return ret;
    }
    
    public int FoobarTextRect (int hwnd, int x, int y, int w, int h){
    var ret = Dm.FoobarTextRect( hwnd,  x,  y,  w,  h);
    return ret;
    }
    
    public int FoobarPrintText (int hwnd, string text, string color){
    var ret = Dm.FoobarPrintText( hwnd,  text,  color);
    return ret;
    }
    
    public int FoobarClearText (int hwnd){
    var ret = Dm.FoobarClearText( hwnd);
    return ret;
    }
    
    public int FoobarTextLineGap (int hwnd, int gap){
    var ret = Dm.FoobarTextLineGap( hwnd,  gap);
    return ret;
    }
    
    public int Play (string file){
    var ret = Dm.Play( file);
    return ret;
    }
    
    public int FaqCapture (int x1, int y1, int x2, int y2, int quality, int delay, int time){
    var ret = Dm.FaqCapture( x1,  y1,  x2,  y2,  quality,  delay,  time);
    return ret;
    }
    
    public int FaqRelease (int handle){
    var ret = Dm.FaqRelease( handle);
    return ret;
    }
    
    public string FaqSend (string server, int handle, int request_type, int time_out){
    var ret = Dm.FaqSend( server,  handle,  request_type,  time_out);
    return ret;
    }
    
    public int Beep (int fre, int delay){
    var ret = Dm.Beep( fre,  delay);
    return ret;
    }
    
    public int FoobarClose (int hwnd){
    var ret = Dm.FoobarClose( hwnd);
    return ret;
    }
    
    public int MoveDD (int dx, int dy){
    var ret = Dm.MoveDD( dx,  dy);
    return ret;
    }
    
    public int FaqGetSize (int handle){
    var ret = Dm.FaqGetSize( handle);
    return ret;
    }
    
    public int LoadPic (string pic_name){
    var ret = Dm.LoadPic( pic_name);
    return ret;
    }
    
    public int FreePic (string pic_name){
    var ret = Dm.FreePic( pic_name);
    return ret;
    }
    
    public int GetScreenData (int x1, int y1, int x2, int y2){
    var ret = Dm.GetScreenData( x1,  y1,  x2,  y2);
    return ret;
    }
    
    public int FreeScreenData (int handle){
    var ret = Dm.FreeScreenData( handle);
    return ret;
    }
    
    public int WheelUp (){
    var ret = Dm.WheelUp();
    return ret;
    }
    
    public int WheelDown (){
    var ret = Dm.WheelDown();
    return ret;
    }
    
    public int SetMouseDelay (string type, int delay){
    var ret = Dm.SetMouseDelay( type,  delay);
    return ret;
    }
    
    public int SetKeypadDelay (string type, int delay){
    var ret = Dm.SetKeypadDelay( type,  delay);
    return ret;
    }
    
    public string GetEnv (int index, string name){
    var ret = Dm.GetEnv( index,  name);
    return ret;
    }
    
    public int SetEnv (int index, string name, string value){
    var ret = Dm.SetEnv( index,  name,  value);
    return ret;
    }
    
    public int SendString (int hwnd, string str){
    var ret = Dm.SendString( hwnd,  str);
    return ret;
    }
    
    public int DelEnv (int index, string name){
    var ret = Dm.DelEnv( index,  name);
    return ret;
    }
    
    public string GetPath (){
    var ret = Dm.GetPath();
    return ret;
    }
    
    public int SetDict (int index, string dict_name){
    var ret = Dm.SetDict( index,  dict_name);
    return ret;
    }
    
    public (int, int,int) FindPic (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    var ret = Dm.FindPic( x1,  y1,  x2,  y2,  pic_name,  delta_color,  sim,  dir, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public string FindPicEx (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    var ret = Dm.FindPicEx( x1,  y1,  x2,  y2,  pic_name,  delta_color,  sim,  dir);
    return ret;
    }
    
    public int SetClientSize (int hwnd, int width, int height){
    var ret = Dm.SetClientSize( hwnd,  width,  height);
    return ret;
    }
    
    public long ReadInt (int hwnd, string addr, int type){
    var ret = Dm.ReadInt( hwnd,  addr,  type);
    return ret;
    }
    
    public float ReadFloat (int hwnd, string addr){
    var ret = Dm.ReadFloat( hwnd,  addr);
    return ret;
    }
    
    public double ReadDouble (int hwnd, string addr){
    var ret = Dm.ReadDouble( hwnd,  addr);
    return ret;
    }
    
    public string FindInt (int hwnd, string addr_range, long int_value_min, long int_value_max, int type){
    var ret = Dm.FindInt( hwnd,  addr_range,  int_value_min,  int_value_max,  type);
    return ret;
    }
    
    public string FindFloat (int hwnd, string addr_range, float float_value_min, float float_value_max){
    var ret = Dm.FindFloat( hwnd,  addr_range,  float_value_min,  float_value_max);
    return ret;
    }
    
    public string FindDouble (int hwnd, string addr_range, double double_value_min, double double_value_max){
    var ret = Dm.FindDouble( hwnd,  addr_range,  double_value_min,  double_value_max);
    return ret;
    }
    
    public string FindString (int hwnd, string addr_range, string string_value, int type){
    var ret = Dm.FindString( hwnd,  addr_range,  string_value,  type);
    return ret;
    }
    
    public long GetModuleBaseAddr (int hwnd, string module_name){
    var ret = Dm.GetModuleBaseAddr( hwnd,  module_name);
    return ret;
    }
    
    public string MoveToEx (int x, int y, int w, int h){
    var ret = Dm.MoveToEx( x,  y,  w,  h);
    return ret;
    }
    
    public string MatchPicName (string pic_name){
    var ret = Dm.MatchPicName( pic_name);
    return ret;
    }
    
    public int AddDict (int index, string dict_info){
    var ret = Dm.AddDict( index,  dict_info);
    return ret;
    }
    
    public int EnterCri (){
    var ret = Dm.EnterCri();
    return ret;
    }
    
    public int LeaveCri (){
    var ret = Dm.LeaveCri();
    return ret;
    }
    
    public int WriteInt (int hwnd, string addr, int type, long v){
    var ret = Dm.WriteInt( hwnd,  addr,  type,  v);
    return ret;
    }
    
    public int WriteFloat (int hwnd, string addr, float v){
    var ret = Dm.WriteFloat( hwnd,  addr,  v);
    return ret;
    }
    
    public int WriteDouble (int hwnd, string addr, double v){
    var ret = Dm.WriteDouble( hwnd,  addr,  v);
    return ret;
    }
    
    public int WriteString (int hwnd, string addr, int type, string v){
    var ret = Dm.WriteString( hwnd,  addr,  type,  v);
    return ret;
    }
    
    public int AsmAdd (string asm_ins){
    var ret = Dm.AsmAdd( asm_ins);
    return ret;
    }
    
    public int AsmClear (){
    var ret = Dm.AsmClear();
    return ret;
    }
    
    public long AsmCall (int hwnd, int mode){
    var ret = Dm.AsmCall( hwnd,  mode);
    return ret;
    }
    
    public (int, int,int) FindMultiColor (int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir){
    var ret = Dm.FindMultiColor( x1,  y1,  x2,  y2,  first_color,  offset_color,  sim,  dir, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public string FindMultiColorEx (int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir){
    var ret = Dm.FindMultiColorEx( x1,  y1,  x2,  y2,  first_color,  offset_color,  sim,  dir);
    return ret;
    }
    
    public string Assemble (long base_addr, int is_64bit){
    var ret = Dm.Assemble( base_addr,  is_64bit);
    return ret;
    }
    
    public string DisAssemble (string asm_code, long base_addr, int is_64bit){
    var ret = Dm.DisAssemble( asm_code,  base_addr,  is_64bit);
    return ret;
    }
    
    public int SetWindowTransparent (int hwnd, int v){
    var ret = Dm.SetWindowTransparent( hwnd,  v);
    return ret;
    }
    
    public string ReadData (int hwnd, string addr, int len){
    var ret = Dm.ReadData( hwnd,  addr,  len);
    return ret;
    }
    
    public int WriteData (int hwnd, string addr, string data){
    var ret = Dm.WriteData( hwnd,  addr,  data);
    return ret;
    }
    
    public string FindData (int hwnd, string addr_range, string data){
    var ret = Dm.FindData( hwnd,  addr_range,  data);
    return ret;
    }
    
    public int SetPicPwd (string pwd){
    var ret = Dm.SetPicPwd( pwd);
    return ret;
    }
    
    public int Log (string info){
    var ret = Dm.Log( info);
    return ret;
    }
    
    public string FindStrE (int x1, int y1, int x2, int y2, string str, string color, double sim){
    var ret = Dm.FindStrE( x1,  y1,  x2,  y2,  str,  color,  sim);
    return ret;
    }
    
    public string FindColorE (int x1, int y1, int x2, int y2, string color, double sim, int dir){
    var ret = Dm.FindColorE( x1,  y1,  x2,  y2,  color,  sim,  dir);
    return ret;
    }
    
    public string FindPicE (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    var ret = Dm.FindPicE( x1,  y1,  x2,  y2,  pic_name,  delta_color,  sim,  dir);
    return ret;
    }
    
    public string FindMultiColorE (int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir){
    var ret = Dm.FindMultiColorE( x1,  y1,  x2,  y2,  first_color,  offset_color,  sim,  dir);
    return ret;
    }
    
    public int SetExactOcr (int exact_ocr){
    var ret = Dm.SetExactOcr( exact_ocr);
    return ret;
    }
    
    public string ReadString (int hwnd, string addr, int type, int len){
    var ret = Dm.ReadString( hwnd,  addr,  type,  len);
    return ret;
    }
    
    public int FoobarTextPrintDir (int hwnd, int dir){
    var ret = Dm.FoobarTextPrintDir( hwnd,  dir);
    return ret;
    }
    
    public string OcrEx (int x1, int y1, int x2, int y2, string color, double sim){
    var ret = Dm.OcrEx( x1,  y1,  x2,  y2,  color,  sim);
    return ret;
    }
    
    public int SetDisplayInput (string mode){
    var ret = Dm.SetDisplayInput( mode);
    return ret;
    }
    
    public int GetTime (){
    var ret = Dm.GetTime();
    return ret;
    }
    
    public int GetScreenWidth (){
    var ret = Dm.GetScreenWidth();
    return ret;
    }
    
    public int GetScreenHeight (){
    var ret = Dm.GetScreenHeight();
    return ret;
    }
    
    public int BindWindowEx (int hwnd, string display, string mouse, string keypad, string public_desc, int mode){
    var ret = Dm.BindWindowEx( hwnd,  display,  mouse,  keypad,  public_desc,  mode);
    return ret;
    }
    
    public string GetDiskSerial (int index){
    var ret = Dm.GetDiskSerial( index);
    return ret;
    }
    
    public string Md5 (string str){
    var ret = Dm.Md5( str);
    return ret;
    }
    
    public string GetMac (){
    var ret = Dm.GetMac();
    return ret;
    }
    
    public int ActiveInputMethod (int hwnd, string id){
    var ret = Dm.ActiveInputMethod( hwnd,  id);
    return ret;
    }
    
    public int CheckInputMethod (int hwnd, string id){
    var ret = Dm.CheckInputMethod( hwnd,  id);
    return ret;
    }
    
    public int FindInputMethod (string id){
    var ret = Dm.FindInputMethod( id);
    return ret;
    }
    
    public (int, int,int) GetCursorPos (){
    var ret = Dm.GetCursorPos(out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public int BindWindow (int hwnd, string display, string mouse, string keypad, int mode){
    var ret = Dm.BindWindow( hwnd,  display,  mouse,  keypad,  mode);
    return ret;
    }
    
    public int FindWindow (string class_name, string title_name){
    var ret = Dm.FindWindow( class_name,  title_name);
    return ret;
    }
    
    public int GetScreenDepth (){
    var ret = Dm.GetScreenDepth();
    return ret;
    }
    
    public int SetScreen (int width, int height, int depth){
    var ret = Dm.SetScreen( width,  height,  depth);
    return ret;
    }
    
    public int ExitOs (int type){
    var ret = Dm.ExitOs( type);
    return ret;
    }
    
    public string GetDir (int type){
    var ret = Dm.GetDir( type);
    return ret;
    }
    
    public int GetOsType (){
    var ret = Dm.GetOsType();
    return ret;
    }
    
    public int FindWindowEx (int parent, string class_name, string title_name){
    var ret = Dm.FindWindowEx( parent,  class_name,  title_name);
    return ret;
    }
    
    public int SetExportDict (int index, string dict_name){
    var ret = Dm.SetExportDict( index,  dict_name);
    return ret;
    }
    
    public string GetCursorShape (){
    var ret = Dm.GetCursorShape();
    return ret;
    }
    
    public int DownCpu (int type, int rate){
    var ret = Dm.DownCpu( type,  rate);
    return ret;
    }
    
    public string GetCursorSpot (){
    var ret = Dm.GetCursorSpot();
    return ret;
    }
    
    public int SendString2 (int hwnd, string str){
    var ret = Dm.SendString2( hwnd,  str);
    return ret;
    }
    
    public int FaqPost (string server, int handle, int request_type, int time_out){
    var ret = Dm.FaqPost( server,  handle,  request_type,  time_out);
    return ret;
    }
    
    public string FaqFetch (){
    var ret = Dm.FaqFetch();
    return ret;
    }
    
    public string FetchWord (int x1, int y1, int x2, int y2, string color, string word){
    var ret = Dm.FetchWord( x1,  y1,  x2,  y2,  color,  word);
    return ret;
    }
    
    public int CaptureJpg (int x1, int y1, int x2, int y2, string file, int quality){
    var ret = Dm.CaptureJpg( x1,  y1,  x2,  y2,  file,  quality);
    return ret;
    }
    
    public (int, int,int) FindStrWithFont (int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag){
    var ret = Dm.FindStrWithFont( x1,  y1,  x2,  y2,  str,  color,  sim,  font_name,  font_size,  flag, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public string FindStrWithFontE (int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag){
    var ret = Dm.FindStrWithFontE( x1,  y1,  x2,  y2,  str,  color,  sim,  font_name,  font_size,  flag);
    return ret;
    }
    
    public string FindStrWithFontEx (int x1, int y1, int x2, int y2, string str, string color, double sim, string font_name, int font_size, int flag){
    var ret = Dm.FindStrWithFontEx( x1,  y1,  x2,  y2,  str,  color,  sim,  font_name,  font_size,  flag);
    return ret;
    }
    
    public string GetDictInfo (string str, string font_name, int font_size, int flag){
    var ret = Dm.GetDictInfo( str,  font_name,  font_size,  flag);
    return ret;
    }
    
    public int SaveDict (int index, string file){
    var ret = Dm.SaveDict( index,  file);
    return ret;
    }
    
    public int GetWindowProcessId (int hwnd){
    var ret = Dm.GetWindowProcessId( hwnd);
    return ret;
    }
    
    public string GetWindowProcessPath (int hwnd){
    var ret = Dm.GetWindowProcessPath( hwnd);
    return ret;
    }
    
    public int LockInput (int locks){
    var ret = Dm.LockInput( locks);
    return ret;
    }
    
    public string GetPicSize (string pic_name){
    var ret = Dm.GetPicSize( pic_name);
    return ret;
    }
    
    public int GetID (){
    var ret = Dm.GetID();
    return ret;
    }
    
    public int CapturePng (int x1, int y1, int x2, int y2, string file){
    var ret = Dm.CapturePng( x1,  y1,  x2,  y2,  file);
    return ret;
    }
    
    public int CaptureGif (int x1, int y1, int x2, int y2, string file, int delay, int time){
    var ret = Dm.CaptureGif( x1,  y1,  x2,  y2,  file,  delay,  time);
    return ret;
    }
    
    public int ImageToBmp (string pic_name, string bmp_name){
    var ret = Dm.ImageToBmp( pic_name,  bmp_name);
    return ret;
    }
    
    public (int, int,int) FindStrFast (int x1, int y1, int x2, int y2, string str, string color, double sim){
    var ret = Dm.FindStrFast( x1,  y1,  x2,  y2,  str,  color,  sim, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public string FindStrFastEx (int x1, int y1, int x2, int y2, string str, string color, double sim){
    var ret = Dm.FindStrFastEx( x1,  y1,  x2,  y2,  str,  color,  sim);
    return ret;
    }
    
    public string FindStrFastE (int x1, int y1, int x2, int y2, string str, string color, double sim){
    var ret = Dm.FindStrFastE( x1,  y1,  x2,  y2,  str,  color,  sim);
    return ret;
    }
    
    public int EnableDisplayDebug (int enable_debug){
    var ret = Dm.EnableDisplayDebug( enable_debug);
    return ret;
    }
    
    public int CapturePre (string file){
    var ret = Dm.CapturePre( file);
    return ret;
    }
    
    public int RegEx (string code, string Ver, string ip){
    var ret = Dm.RegEx( code,  Ver,  ip);
    return ret;
    }
    
    public string GetMachineCode (){
    var ret = Dm.GetMachineCode();
    return ret;
    }
    
    public int SetClipboard (string data){
    var ret = Dm.SetClipboard( data);
    return ret;
    }
    
    public string GetClipboard (){
    var ret = Dm.GetClipboard();
    return ret;
    }
    
    public int GetNowDict (){
    var ret = Dm.GetNowDict();
    return ret;
    }
    
    public int Is64Bit (){
    var ret = Dm.Is64Bit();
    return ret;
    }
    
    public int GetColorNum (int x1, int y1, int x2, int y2, string color, double sim){
    var ret = Dm.GetColorNum( x1,  y1,  x2,  y2,  color,  sim);
    return ret;
    }
    
    public string EnumWindowByProcess (string process_name, string title, string class_name, int filter){
    var ret = Dm.EnumWindowByProcess( process_name,  title,  class_name,  filter);
    return ret;
    }
    
    public int GetDictCount (int index){
    var ret = Dm.GetDictCount( index);
    return ret;
    }
    
    public int GetLastError (){
    var ret = Dm.GetLastError();
    return ret;
    }
    
    public string GetNetTime (){
    var ret = Dm.GetNetTime();
    return ret;
    }
    
    public int EnableGetColorByCapture (int en){
    var ret = Dm.EnableGetColorByCapture( en);
    return ret;
    }
    
    public int CheckUAC (){
    var ret = Dm.CheckUAC();
    return ret;
    }
    
    public int SetUAC (int uac){
    var ret = Dm.SetUAC( uac);
    return ret;
    }
    
    public int DisableFontSmooth (){
    var ret = Dm.DisableFontSmooth();
    return ret;
    }
    
    public int CheckFontSmooth (){
    var ret = Dm.CheckFontSmooth();
    return ret;
    }
    
    public int SetDisplayAcceler (int level){
    var ret = Dm.SetDisplayAcceler( level);
    return ret;
    }
    
    public int FindWindowByProcess (string process_name, string class_name, string title_name){
    var ret = Dm.FindWindowByProcess( process_name,  class_name,  title_name);
    return ret;
    }
    
    public int FindWindowByProcessId (int process_id, string class_name, string title_name){
    var ret = Dm.FindWindowByProcessId( process_id,  class_name,  title_name);
    return ret;
    }
    
    public string ReadIni (string section, string key, string file){
    var ret = Dm.ReadIni( section,  key,  file);
    return ret;
    }
    
    public int WriteIni (string section, string key, string v, string file){
    var ret = Dm.WriteIni( section,  key,  v,  file);
    return ret;
    }
    
    public int RunApp (string path, int mode){
    var ret = Dm.RunApp( path,  mode);
    return ret;
    }
    
    public int delay (int mis){
    var ret = Dm.delay( mis);
    return ret;
    }
    
    public int FindWindowSuper (string spec1, int flag1, int type1, string spec2, int flag2, int type2){
    var ret = Dm.FindWindowSuper( spec1,  flag1,  type1,  spec2,  flag2,  type2);
    return ret;
    }
    
    public string ExcludePos (string all_pos, int type, int x1, int y1, int x2, int y2){
    var ret = Dm.ExcludePos( all_pos,  type,  x1,  y1,  x2,  y2);
    return ret;
    }
    
    public string FindNearestPos (string all_pos, int type, int x, int y){
    var ret = Dm.FindNearestPos( all_pos,  type,  x,  y);
    return ret;
    }
    
    public string SortPosDistance (string all_pos, int type, int x, int y){
    var ret = Dm.SortPosDistance( all_pos,  type,  x,  y);
    return ret;
    }
    
    public (int, int,int) FindPicMem (int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir){
    var ret = Dm.FindPicMem( x1,  y1,  x2,  y2,  pic_info,  delta_color,  sim,  dir, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public string FindPicMemEx (int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir){
    var ret = Dm.FindPicMemEx( x1,  y1,  x2,  y2,  pic_info,  delta_color,  sim,  dir);
    return ret;
    }
    
    public string FindPicMemE (int x1, int y1, int x2, int y2, string pic_info, string delta_color, double sim, int dir){
    var ret = Dm.FindPicMemE( x1,  y1,  x2,  y2,  pic_info,  delta_color,  sim,  dir);
    return ret;
    }
    
    public string AppendPicAddr (string pic_info, int addr, int size){
    var ret = Dm.AppendPicAddr( pic_info,  addr,  size);
    return ret;
    }
    
    public int WriteFile (string file, string content){
    var ret = Dm.WriteFile( file,  content);
    return ret;
    }
    
    public int Stop (int id){
    var ret = Dm.Stop( id);
    return ret;
    }
    
    public int SetDictMem (int index, int addr, int size){
    var ret = Dm.SetDictMem( index,  addr,  size);
    return ret;
    }
    
    public string GetNetTimeSafe (){
    var ret = Dm.GetNetTimeSafe();
    return ret;
    }
    
    public int ForceUnBindWindow (int hwnd){
    var ret = Dm.ForceUnBindWindow( hwnd);
    return ret;
    }
    
    public string ReadIniPwd (string section, string key, string file, string pwd){
    var ret = Dm.ReadIniPwd( section,  key,  file,  pwd);
    return ret;
    }
    
    public int WriteIniPwd (string section, string key, string v, string file, string pwd){
    var ret = Dm.WriteIniPwd( section,  key,  v,  file,  pwd);
    return ret;
    }
    
    public int DecodeFile (string file, string pwd){
    var ret = Dm.DecodeFile( file,  pwd);
    return ret;
    }
    
    public int KeyDownChar (string key_str){
    var ret = Dm.KeyDownChar( key_str);
    return ret;
    }
    
    public int KeyUpChar (string key_str){
    var ret = Dm.KeyUpChar( key_str);
    return ret;
    }
    
    public int KeyPressChar (string key_str){
    var ret = Dm.KeyPressChar( key_str);
    return ret;
    }
    
    public int KeyPressStr (string key_str, int delay){
    var ret = Dm.KeyPressStr( key_str,  delay);
    return ret;
    }
    
    public int EnableKeypadPatch (int en){
    var ret = Dm.EnableKeypadPatch( en);
    return ret;
    }
    
    public int EnableKeypadSync (int en, int time_out){
    var ret = Dm.EnableKeypadSync( en,  time_out);
    return ret;
    }
    
    public int EnableMouseSync (int en, int time_out){
    var ret = Dm.EnableMouseSync( en,  time_out);
    return ret;
    }
    
    public int DmGuard (int en, string type){
    var ret = Dm.DmGuard( en,  type);
    return ret;
    }
    
    public int FaqCaptureFromFile (int x1, int y1, int x2, int y2, string file, int quality){
    var ret = Dm.FaqCaptureFromFile( x1,  y1,  x2,  y2,  file,  quality);
    return ret;
    }
    
    public string FindIntEx (int hwnd, string addr_range, long int_value_min, long int_value_max, int type, int step, int multi_thread, int mode){
    var ret = Dm.FindIntEx( hwnd,  addr_range,  int_value_min,  int_value_max,  type,  step,  multi_thread,  mode);
    return ret;
    }
    
    public string FindFloatEx (int hwnd, string addr_range, float float_value_min, float float_value_max, int step, int multi_thread, int mode){
    var ret = Dm.FindFloatEx( hwnd,  addr_range,  float_value_min,  float_value_max,  step,  multi_thread,  mode);
    return ret;
    }
    
    public string FindDoubleEx (int hwnd, string addr_range, double double_value_min, double double_value_max, int step, int multi_thread, int mode){
    var ret = Dm.FindDoubleEx( hwnd,  addr_range,  double_value_min,  double_value_max,  step,  multi_thread,  mode);
    return ret;
    }
    
    public string FindStringEx (int hwnd, string addr_range, string string_value, int type, int step, int multi_thread, int mode){
    var ret = Dm.FindStringEx( hwnd,  addr_range,  string_value,  type,  step,  multi_thread,  mode);
    return ret;
    }
    
    public string FindDataEx (int hwnd, string addr_range, string data, int step, int multi_thread, int mode){
    var ret = Dm.FindDataEx( hwnd,  addr_range,  data,  step,  multi_thread,  mode);
    return ret;
    }
    
    public int EnableRealMouse (int en, int mousedelay, int mousestep){
    var ret = Dm.EnableRealMouse( en,  mousedelay,  mousestep);
    return ret;
    }
    
    public int EnableRealKeypad (int en){
    var ret = Dm.EnableRealKeypad( en);
    return ret;
    }
    
    public int SendStringIme (string str){
    var ret = Dm.SendStringIme( str);
    return ret;
    }
    
    public int FoobarDrawLine (int hwnd, int x1, int y1, int x2, int y2, string color, int style, int width){
    var ret = Dm.FoobarDrawLine( hwnd,  x1,  y1,  x2,  y2,  color,  style,  width);
    return ret;
    }
    
    public string FindStrEx (int x1, int y1, int x2, int y2, string str, string color, double sim){
    var ret = Dm.FindStrEx( x1,  y1,  x2,  y2,  str,  color,  sim);
    return ret;
    }
    
    public int IsBind (int hwnd){
    var ret = Dm.IsBind( hwnd);
    return ret;
    }
    
    public int SetDisplayDelay (int t){
    var ret = Dm.SetDisplayDelay( t);
    return ret;
    }
    
    public int GetDmCount (){
    var ret = Dm.GetDmCount();
    return ret;
    }
    
    public int DisableScreenSave (){
    var ret = Dm.DisableScreenSave();
    return ret;
    }
    
    public int DisablePowerSave (){
    var ret = Dm.DisablePowerSave();
    return ret;
    }
    
    public int SetMemoryHwndAsProcessId (int en){
    var ret = Dm.SetMemoryHwndAsProcessId( en);
    return ret;
    }
    
    public (int, int,int) FindShape (int x1, int y1, int x2, int y2, string offset_color, double sim, int dir){
    var ret = Dm.FindShape( x1,  y1,  x2,  y2,  offset_color,  sim,  dir, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public string FindShapeE (int x1, int y1, int x2, int y2, string offset_color, double sim, int dir){
    var ret = Dm.FindShapeE( x1,  y1,  x2,  y2,  offset_color,  sim,  dir);
    return ret;
    }
    
    public string FindShapeEx (int x1, int y1, int x2, int y2, string offset_color, double sim, int dir){
    var ret = Dm.FindShapeEx( x1,  y1,  x2,  y2,  offset_color,  sim,  dir);
    return ret;
    }
    
    public (string, int,int) FindStrS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    var ret = Dm.FindStrS( x1,  y1,  x2,  y2,  str,  color,  sim, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public string FindStrExS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    var ret = Dm.FindStrExS( x1,  y1,  x2,  y2,  str,  color,  sim);
    return ret;
    }
    
    public (string, int,int) FindStrFastS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    var ret = Dm.FindStrFastS( x1,  y1,  x2,  y2,  str,  color,  sim, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public string FindStrFastExS (int x1, int y1, int x2, int y2, string str, string color, double sim){
    var ret = Dm.FindStrFastExS( x1,  y1,  x2,  y2,  str,  color,  sim);
    return ret;
    }
    
    public (string, int,int) FindPicS (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    var ret = Dm.FindPicS( x1,  y1,  x2,  y2,  pic_name,  delta_color,  sim,  dir, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public string FindPicExS (int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir){
    var ret = Dm.FindPicExS( x1,  y1,  x2,  y2,  pic_name,  delta_color,  sim,  dir);
    return ret;
    }
    
    public int ClearDict (int index){
    var ret = Dm.ClearDict( index);
    return ret;
    }
    
    public string GetMachineCodeNoMac (){
    var ret = Dm.GetMachineCodeNoMac();
    return ret;
    }
    
    public (int, int,int,int,int) GetClientRect (int hwnd){
    var ret = Dm.GetClientRect( hwnd, out object x1, out object y1, out object x2, out object y2);
    return (ret, (int)x1,(int)y1,(int)x2,(int)y2);
    }
    
    public int EnableFakeActive (int en){
    var ret = Dm.EnableFakeActive( en);
    return ret;
    }
    
    public (int, int,int) GetScreenDataBmp (int x1, int y1, int x2, int y2){
    var ret = Dm.GetScreenDataBmp( x1,  y1,  x2,  y2, out object data, out object size);
    return (ret, (int)data,(int)size);
    }
    
    public int EncodeFile (string file, string pwd){
    var ret = Dm.EncodeFile( file,  pwd);
    return ret;
    }
    
    public string GetCursorShapeEx (int type){
    var ret = Dm.GetCursorShapeEx( type);
    return ret;
    }
    
    public int FaqCancel (){
    var ret = Dm.FaqCancel();
    return ret;
    }
    
    public string IntToData (long int_value, int type){
    var ret = Dm.IntToData( int_value,  type);
    return ret;
    }
    
    public string FloatToData (float float_value){
    var ret = Dm.FloatToData( float_value);
    return ret;
    }
    
    public string DoubleToData (double double_value){
    var ret = Dm.DoubleToData( double_value);
    return ret;
    }
    
    public string StringToData (string string_value, int type){
    var ret = Dm.StringToData( string_value,  type);
    return ret;
    }
    
    public int SetMemoryFindResultToFile (string file){
    var ret = Dm.SetMemoryFindResultToFile( file);
    return ret;
    }
    
    public int EnableBind (int en){
    var ret = Dm.EnableBind( en);
    return ret;
    }
    
    public int SetSimMode (int mode){
    var ret = Dm.SetSimMode( mode);
    return ret;
    }
    
    public int LockMouseRect (int x1, int y1, int x2, int y2){
    var ret = Dm.LockMouseRect( x1,  y1,  x2,  y2);
    return ret;
    }
    
    public int SendPaste (int hwnd){
    var ret = Dm.SendPaste( hwnd);
    return ret;
    }
    
    public int IsDisplayDead (int x1, int y1, int x2, int y2, int t){
    var ret = Dm.IsDisplayDead( x1,  y1,  x2,  y2,  t);
    return ret;
    }
    
    public int GetKeyState (int vk){
    var ret = Dm.GetKeyState( vk);
    return ret;
    }
    
    public int CopyFile (string src_file, string dst_file, int over){
    var ret = Dm.CopyFile( src_file,  dst_file,  over);
    return ret;
    }
    
    public int IsFileExist (string file){
    var ret = Dm.IsFileExist( file);
    return ret;
    }
    
    public int DeleteFile (string file){
    var ret = Dm.DeleteFile( file);
    return ret;
    }
    
    public int MoveFile (string src_file, string dst_file){
    var ret = Dm.MoveFile( src_file,  dst_file);
    return ret;
    }
    
    public int CreateFolder (string folder_name){
    var ret = Dm.CreateFolder( folder_name);
    return ret;
    }
    
    public int DeleteFolder (string folder_name){
    var ret = Dm.DeleteFolder( folder_name);
    return ret;
    }
    
    public int GetFileLength (string file){
    var ret = Dm.GetFileLength( file);
    return ret;
    }
    
    public string ReadFile (string file){
    var ret = Dm.ReadFile( file);
    return ret;
    }
    
    public int WaitKey (int key_code, int time_out){
    var ret = Dm.WaitKey( key_code,  time_out);
    return ret;
    }
    
    public int DeleteIni (string section, string key, string file){
    var ret = Dm.DeleteIni( section,  key,  file);
    return ret;
    }
    
    public int DeleteIniPwd (string section, string key, string file, string pwd){
    var ret = Dm.DeleteIniPwd( section,  key,  file,  pwd);
    return ret;
    }
    
    public int EnableSpeedDx (int en){
    var ret = Dm.EnableSpeedDx( en);
    return ret;
    }
    
    public int EnableIme (int en){
    var ret = Dm.EnableIme( en);
    return ret;
    }
    
    public int Reg (string code, string Ver){
    var ret = Dm.Reg( code,  Ver);
    return ret;
    }
    
    public string SelectFile (){
    var ret = Dm.SelectFile();
    return ret;
    }
    
    public string SelectDirectory (){
    var ret = Dm.SelectDirectory();
    return ret;
    }
    
    public int LockDisplay (int locks){
    var ret = Dm.LockDisplay( locks);
    return ret;
    }
    
    public int FoobarSetSave (int hwnd, string file, int en, string header){
    var ret = Dm.FoobarSetSave( hwnd,  file,  en,  header);
    return ret;
    }
    
    public string EnumWindowSuper (string spec1, int flag1, int type1, string spec2, int flag2, int type2, int sort){
    var ret = Dm.EnumWindowSuper( spec1,  flag1,  type1,  spec2,  flag2,  type2,  sort);
    return ret;
    }
    
    public int DownloadFile (string url, string save_file, int timeout){
    var ret = Dm.DownloadFile( url,  save_file,  timeout);
    return ret;
    }
    
    public int EnableKeypadMsg (int en){
    var ret = Dm.EnableKeypadMsg( en);
    return ret;
    }
    
    public int EnableMouseMsg (int en){
    var ret = Dm.EnableMouseMsg( en);
    return ret;
    }
    
    public int RegNoMac (string code, string Ver){
    var ret = Dm.RegNoMac( code,  Ver);
    return ret;
    }
    
    public int RegExNoMac (string code, string Ver, string ip){
    var ret = Dm.RegExNoMac( code,  Ver,  ip);
    return ret;
    }
    
    public int SetEnumWindowDelay (int delay){
    var ret = Dm.SetEnumWindowDelay( delay);
    return ret;
    }
    
    public int FindMulColor (int x1, int y1, int x2, int y2, string color, double sim){
    var ret = Dm.FindMulColor( x1,  y1,  x2,  y2,  color,  sim);
    return ret;
    }
    
    public string GetDict (int index, int font_index){
    var ret = Dm.GetDict( index,  font_index);
    return ret;
    }
    
    public int GetBindWindow (){
    var ret = Dm.GetBindWindow();
    return ret;
    }
    
    public int FoobarStartGif (int hwnd, int x, int y, string pic_name, int repeat_limit, int delay){
    var ret = Dm.FoobarStartGif( hwnd,  x,  y,  pic_name,  repeat_limit,  delay);
    return ret;
    }
    
    public int FoobarStopGif (int hwnd, int x, int y, string pic_name){
    var ret = Dm.FoobarStopGif( hwnd,  x,  y,  pic_name);
    return ret;
    }
    
    public int FreeProcessMemory (int hwnd){
    var ret = Dm.FreeProcessMemory( hwnd);
    return ret;
    }
    
    public string ReadFileData (string file, int start_pos, int end_pos){
    var ret = Dm.ReadFileData( file,  start_pos,  end_pos);
    return ret;
    }
    
    public long VirtualAllocEx (int hwnd, long addr, int size, int type){
    var ret = Dm.VirtualAllocEx( hwnd,  addr,  size,  type);
    return ret;
    }
    
    public int VirtualFreeEx (int hwnd, long addr){
    var ret = Dm.VirtualFreeEx( hwnd,  addr);
    return ret;
    }
    
    public string GetCommandLine (int hwnd){
    var ret = Dm.GetCommandLine( hwnd);
    return ret;
    }
    
    public int TerminateProcess (int pid){
    var ret = Dm.TerminateProcess( pid);
    return ret;
    }
    
    public string GetNetTimeByIp (string ip){
    var ret = Dm.GetNetTimeByIp( ip);
    return ret;
    }
    
    public string EnumProcess (string name){
    var ret = Dm.EnumProcess( name);
    return ret;
    }
    
    public string GetProcessInfo (int pid){
    var ret = Dm.GetProcessInfo( pid);
    return ret;
    }
    
    public long ReadIntAddr (int hwnd, long addr, int type){
    var ret = Dm.ReadIntAddr( hwnd,  addr,  type);
    return ret;
    }
    
    public string ReadDataAddr (int hwnd, long addr, int len){
    var ret = Dm.ReadDataAddr( hwnd,  addr,  len);
    return ret;
    }
    
    public double ReadDoubleAddr (int hwnd, long addr){
    var ret = Dm.ReadDoubleAddr( hwnd,  addr);
    return ret;
    }
    
    public float ReadFloatAddr (int hwnd, long addr){
    var ret = Dm.ReadFloatAddr( hwnd,  addr);
    return ret;
    }
    
    public string ReadStringAddr (int hwnd, long addr, int type, int len){
    var ret = Dm.ReadStringAddr( hwnd,  addr,  type,  len);
    return ret;
    }
    
    public int WriteDataAddr (int hwnd, long addr, string data){
    var ret = Dm.WriteDataAddr( hwnd,  addr,  data);
    return ret;
    }
    
    public int WriteDoubleAddr (int hwnd, long addr, double v){
    var ret = Dm.WriteDoubleAddr( hwnd,  addr,  v);
    return ret;
    }
    
    public int WriteFloatAddr (int hwnd, long addr, float v){
    var ret = Dm.WriteFloatAddr( hwnd,  addr,  v);
    return ret;
    }
    
    public int WriteIntAddr (int hwnd, long addr, int type, long v){
    var ret = Dm.WriteIntAddr( hwnd,  addr,  type,  v);
    return ret;
    }
    
    public int WriteStringAddr (int hwnd, long addr, int type, string v){
    var ret = Dm.WriteStringAddr( hwnd,  addr,  type,  v);
    return ret;
    }
    
    public int Delays (int min_s, int max_s){
    var ret = Dm.Delays( min_s,  max_s);
    return ret;
    }
    
    public (int, int,int) FindColorBlock (int x1, int y1, int x2, int y2, string color, double sim, int count, int width, int height){
    var ret = Dm.FindColorBlock( x1,  y1,  x2,  y2,  color,  sim,  count,  width,  height, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public string FindColorBlockEx (int x1, int y1, int x2, int y2, string color, double sim, int count, int width, int height){
    var ret = Dm.FindColorBlockEx( x1,  y1,  x2,  y2,  color,  sim,  count,  width,  height);
    return ret;
    }
    
    public int OpenProcess (int pid){
    var ret = Dm.OpenProcess( pid);
    return ret;
    }
    
    public string EnumIniSection (string file){
    var ret = Dm.EnumIniSection( file);
    return ret;
    }
    
    public string EnumIniSectionPwd (string file, string pwd){
    var ret = Dm.EnumIniSectionPwd( file,  pwd);
    return ret;
    }
    
    public string EnumIniKey (string section, string file){
    var ret = Dm.EnumIniKey( section,  file);
    return ret;
    }
    
    public string EnumIniKeyPwd (string section, string file, string pwd){
    var ret = Dm.EnumIniKeyPwd( section,  file,  pwd);
    return ret;
    }
    
    public int SwitchBindWindow (int hwnd){
    var ret = Dm.SwitchBindWindow( hwnd);
    return ret;
    }
    
    public int InitCri (){
    var ret = Dm.InitCri();
    return ret;
    }
    
    public int SendStringIme2 (int hwnd, string str, int mode){
    var ret = Dm.SendStringIme2( hwnd,  str,  mode);
    return ret;
    }
    
    public string EnumWindowByProcessId (int pid, string title, string class_name, int filter){
    var ret = Dm.EnumWindowByProcessId( pid,  title,  class_name,  filter);
    return ret;
    }
    
    public string GetDisplayInfo (){
    var ret = Dm.GetDisplayInfo();
    return ret;
    }
    
    public int EnableFontSmooth (){
    var ret = Dm.EnableFontSmooth();
    return ret;
    }
    
    public string OcrExOne (int x1, int y1, int x2, int y2, string color, double sim){
    var ret = Dm.OcrExOne( x1,  y1,  x2,  y2,  color,  sim);
    return ret;
    }
    
    public int SetAero (int en){
    var ret = Dm.SetAero( en);
    return ret;
    }
    
    public int FoobarSetTrans (int hwnd, int trans, string color, double sim){
    var ret = Dm.FoobarSetTrans( hwnd,  trans,  color,  sim);
    return ret;
    }
    
    public int EnablePicCache (int en){
    var ret = Dm.EnablePicCache( en);
    return ret;
    }
    
    public int FaqIsPosted (){
    var ret = Dm.FaqIsPosted();
    return ret;
    }
    
    public int LoadPicByte (int addr, int size, string name){
    var ret = Dm.LoadPicByte( addr,  size,  name);
    return ret;
    }
    
    public int MiddleDown (){
    var ret = Dm.MiddleDown();
    return ret;
    }
    
    public int MiddleUp (){
    var ret = Dm.MiddleUp();
    return ret;
    }
    
    public int FaqCaptureString (string str){
    var ret = Dm.FaqCaptureString( str);
    return ret;
    }
    
    public int VirtualProtectEx (int hwnd, long addr, int size, int type, int old_protect){
    var ret = Dm.VirtualProtectEx( hwnd,  addr,  size,  type,  old_protect);
    return ret;
    }
    
    public int SetMouseSpeed (int speed){
    var ret = Dm.SetMouseSpeed( speed);
    return ret;
    }
    
    public int GetMouseSpeed (){
    var ret = Dm.GetMouseSpeed();
    return ret;
    }
    
    public int EnableMouseAccuracy (int en){
    var ret = Dm.EnableMouseAccuracy( en);
    return ret;
    }
    
    public int SetExcludeRegion (int type, string info){
    var ret = Dm.SetExcludeRegion( type,  info);
    return ret;
    }
    
    public int EnableShareDict (int en){
    var ret = Dm.EnableShareDict( en);
    return ret;
    }
    
    public int DisableCloseDisplayAndSleep (){
    var ret = Dm.DisableCloseDisplayAndSleep();
    return ret;
    }
    
    public int Int64ToInt32 (long v){
    var ret = Dm.Int64ToInt32( v);
    return ret;
    }
    
    public int GetLocale (){
    var ret = Dm.GetLocale();
    return ret;
    }
    
    public int SetLocale (){
    var ret = Dm.SetLocale();
    return ret;
    }
    
    public int ReadDataToBin (int hwnd, string addr, int len){
    var ret = Dm.ReadDataToBin( hwnd,  addr,  len);
    return ret;
    }
    
    public int WriteDataFromBin (int hwnd, string addr, int data, int len){
    var ret = Dm.WriteDataFromBin( hwnd,  addr,  data,  len);
    return ret;
    }
    
    public int ReadDataAddrToBin (int hwnd, long addr, int len){
    var ret = Dm.ReadDataAddrToBin( hwnd,  addr,  len);
    return ret;
    }
    
    public int WriteDataAddrFromBin (int hwnd, long addr, int data, int len){
    var ret = Dm.WriteDataAddrFromBin( hwnd,  addr,  data,  len);
    return ret;
    }
    
    public int SetParam64ToPointer (){
    var ret = Dm.SetParam64ToPointer();
    return ret;
    }
    
    public int GetDPI (){
    var ret = Dm.GetDPI();
    return ret;
    }
    
    public int SetDisplayRefreshDelay (int t){
    var ret = Dm.SetDisplayRefreshDelay( t);
    return ret;
    }
    
    public int IsFolderExist (string folder){
    var ret = Dm.IsFolderExist( folder);
    return ret;
    }
    
    public int GetCpuType (){
    var ret = Dm.GetCpuType();
    return ret;
    }
    
    public int ReleaseRef (){
    var ret = Dm.ReleaseRef();
    return ret;
    }
    
    public int SetExitThread (int en){
    var ret = Dm.SetExitThread( en);
    return ret;
    }
    
    public int GetFps (){
    var ret = Dm.GetFps();
    return ret;
    }
    
    public string VirtualQueryEx (int hwnd, long addr, int pmbi){
    var ret = Dm.VirtualQueryEx( hwnd,  addr,  pmbi);
    return ret;
    }
    
    public long AsmCallEx (int hwnd, int mode, string base_addr){
    var ret = Dm.AsmCallEx( hwnd,  mode,  base_addr);
    return ret;
    }
    
    public long GetRemoteApiAddress (int hwnd, long base_addr, string fun_name){
    var ret = Dm.GetRemoteApiAddress( hwnd,  base_addr,  fun_name);
    return ret;
    }
    
    public string ExecuteCmd (string cmd, string current_dir, int time_out){
    var ret = Dm.ExecuteCmd( cmd,  current_dir,  time_out);
    return ret;
    }
    
    public int SpeedNormalGraphic (int en){
    var ret = Dm.SpeedNormalGraphic( en);
    return ret;
    }
    
    public int UnLoadDriver (){
    var ret = Dm.UnLoadDriver();
    return ret;
    }
    
    public int GetOsBuildNumber (){
    var ret = Dm.GetOsBuildNumber();
    return ret;
    }
    
    public int HackSpeed (double rate){
    var ret = Dm.HackSpeed( rate);
    return ret;
    }
    
    public string GetRealPath (string path){
    var ret = Dm.GetRealPath( path);
    return ret;
    }
    
    public int ShowTaskBarIcon (int hwnd, int is_show){
    var ret = Dm.ShowTaskBarIcon( hwnd,  is_show);
    return ret;
    }
    
    public int AsmSetTimeout (int time_out, int param){
    var ret = Dm.AsmSetTimeout( time_out,  param);
    return ret;
    }
    
    public string DmGuardParams (string cmd, string sub_cmd, string param){
    var ret = Dm.DmGuardParams( cmd,  sub_cmd,  param);
    return ret;
    }
    
    public int GetModuleSize (int hwnd, string module_name){
    var ret = Dm.GetModuleSize( hwnd,  module_name);
    return ret;
    }
    
    public int IsSurrpotVt (){
    var ret = Dm.IsSurrpotVt();
    return ret;
    }
    
    public string GetDiskModel (int index){
    var ret = Dm.GetDiskModel( index);
    return ret;
    }
    
    public string GetDiskReversion (int index){
    var ret = Dm.GetDiskReversion( index);
    return ret;
    }
    
    public int EnableFindPicMultithread (int en){
    var ret = Dm.EnableFindPicMultithread( en);
    return ret;
    }
    
    public int GetCpuUsage (){
    var ret = Dm.GetCpuUsage();
    return ret;
    }
    
    public int GetMemoryUsage (){
    var ret = Dm.GetMemoryUsage();
    return ret;
    }
    
    public string Hex32 (int v){
    var ret = Dm.Hex32( v);
    return ret;
    }
    
    public string Hex64 (long v){
    var ret = Dm.Hex64( v);
    return ret;
    }
    
    public int GetWindowThreadId (int hwnd){
    var ret = Dm.GetWindowThreadId( hwnd);
    return ret;
    }
    
    public int DmGuardExtract (string type, string path){
    var ret = Dm.DmGuardExtract( type,  path);
    return ret;
    }
    
    public int DmGuardLoadCustom (string type, string path){
    var ret = Dm.DmGuardLoadCustom( type,  path);
    return ret;
    }
    
    public int SetShowAsmErrorMsg (int show){
    var ret = Dm.SetShowAsmErrorMsg( show);
    return ret;
    }
    
    public string GetSystemInfo (string type, int method){
    var ret = Dm.GetSystemInfo( type,  method);
    return ret;
    }
    
    public int SetFindPicMultithreadCount (int count){
    var ret = Dm.SetFindPicMultithreadCount( count);
    return ret;
    }
    
    public (int, int,int) FindPicSim (int x1, int y1, int x2, int y2, string pic_name, string delta_color, int sim, int dir){
    var ret = Dm.FindPicSim( x1,  y1,  x2,  y2,  pic_name,  delta_color,  sim,  dir, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public string FindPicSimEx (int x1, int y1, int x2, int y2, string pic_name, string delta_color, int sim, int dir){
    var ret = Dm.FindPicSimEx( x1,  y1,  x2,  y2,  pic_name,  delta_color,  sim,  dir);
    return ret;
    }
    
    public (int, int,int) FindPicSimMem (int x1, int y1, int x2, int y2, string pic_info, string delta_color, int sim, int dir){
    var ret = Dm.FindPicSimMem( x1,  y1,  x2,  y2,  pic_info,  delta_color,  sim,  dir, out object x, out object y);
    return (ret, (int)x,(int)y);
    }
    
    public string FindPicSimMemEx (int x1, int y1, int x2, int y2, string pic_info, string delta_color, int sim, int dir){
    var ret = Dm.FindPicSimMemEx( x1,  y1,  x2,  y2,  pic_info,  delta_color,  sim,  dir);
    return ret;
    }
    
    public string FindPicSimE (int x1, int y1, int x2, int y2, string pic_name, string delta_color, int sim, int dir){
    var ret = Dm.FindPicSimE( x1,  y1,  x2,  y2,  pic_name,  delta_color,  sim,  dir);
    return ret;
    }
    
    public string FindPicSimMemE (int x1, int y1, int x2, int y2, string pic_info, string delta_color, int sim, int dir){
    var ret = Dm.FindPicSimMemE( x1,  y1,  x2,  y2,  pic_info,  delta_color,  sim,  dir);
    return ret;
    }
    
    public int SetInputDm (int input_dm, int rx, int ry){
    var ret = Dm.SetInputDm( input_dm,  rx,  ry);
    return ret;
    }
    
}
