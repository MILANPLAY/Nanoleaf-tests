using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using NanoleafSpace;
class Program
{

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);


    static async Task Main(string[] args)
    {
        AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        Console.CancelKeyPress += OnProcessExit;


        Nanoleaf Shapes = new Nanoleaf("192.168.68.52");
        await Shapes.Setup();
        Console.WriteLine(Shapes);
    }


    static void OnProcessExit(object sender, EventArgs e)
    {
        Console.WriteLine("ProcessExit event triggered. Performing cleanup...");
        //MessageBox(IntPtr.Zero,"Exiting","", 0x00000030 | 0x00000040);
    }

}
