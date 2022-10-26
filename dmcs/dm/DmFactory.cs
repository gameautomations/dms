using System.Runtime.InteropServices;


namespace dm;

class DmFactory
{
    // 动态注册插件
    [DllImport("DLL/DmReg.dll")]
    private static extern int SetDllPathA(string path, int mode);

    // 动态注册
    public static bool Register()
    {
        var setDllPathResult = SetDllPathA("DLL/dm.dll", 1);
        if (setDllPathResult == 0)
        {
            return false;
        }

        return true;
    }

    // 创建大漠实例
    public static Idmsoft Create()
    {
        var type = Type.GetTypeFromProgID("dm.dmsoft")!;
        return (Idmsoft?)Activator.CreateInstance(type)!;
    }

    // 销毁大漠实例
    public static bool Release(Idmsoft? dm)
    {
        if (dm != null)
        {
            Marshal.ReleaseComObject(dm);
        }
        return true;
    }
}
