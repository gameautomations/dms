using System.Runtime.InteropServices;


namespace dm;

class Dmsoft
{
    private static bool Registered = false;
    private bool Released = false;
    public Idmsoft DM;

    // 动态注册插件
    [DllImport("DLL/DmReg.dll")]
    private static extern int SetDllPathA(string path, int mode);

    public Dmsoft()
    {
        if (!Registered)
        {
            if (SetDllPathA("DLL/dm.dll", 1) != 0)
            {
                Registered = true;
            }
        }
        var type = Type.GetTypeFromProgID("dm.dmsoft")!;
        DM = (Idmsoft?)Activator.CreateInstance(type)!;
    }

    ~Dmsoft()
    {
        Rlease();
    }
    public void Rlease()
    {
        if (Released) return;
        DM.ReleaseRef();
        Marshal.ReleaseComObject(DM);
        Released = true;
    }
}
