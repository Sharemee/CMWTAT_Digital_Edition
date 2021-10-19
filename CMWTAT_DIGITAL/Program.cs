using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace CMWTAT_DIGITAL
{
    public static class Program
    {
        public static bool autoact = false;
        public static bool hiderun = false;
        public static bool expact = false;
        public static bool log2file = false;
        public static bool showhelp = false;

        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [STAThread()]
        [DebuggerNonUserCode()]
        [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        public static void Main(string[] startup_args)
        {
            //添加程序集解析事件
            var loadedAssemblies = new Dictionary<string, Assembly>();
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = $"CMWTAT_DIGITAL.Res.{new AssemblyName(args.Name).Name}.dll";

                //Must return the EXACT same assembly, do not reload from a new stream
                if (loadedAssemblies.TryGetValue(resourceName, out Assembly loadedAssembly))
                {
                    return loadedAssembly;
                }

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                    {
                        return null;
                    }
                    byte[] bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    var assembly = Assembly.Load(bytes);
                    loadedAssemblies[resourceName] = assembly;
                    return assembly;
                }
            };

            foreach (string arg in startup_args)
            {
                Console.WriteLine("arg: " + arg);
                if (arg == "-a" || arg == "--auto")
                {
                    Console.WriteLine("AUTO: True");
                    autoact = true;
                }
                if (arg == "-h" || arg == "--hide")
                {
                    Console.WriteLine("HIDE: True");
                    hiderun = true;
                }
                if (arg == "-e" || arg == "--expact")
                {
                    Console.WriteLine("EXPACT: True");
                    expact = true;
                }
                if (arg == "-l" || arg == "--log")
                {
                    Console.WriteLine("LOG: True");
                    log2file = true;
                }
                if (arg == "-?" || arg == "--help")
                {
                    Console.WriteLine("SHOWHELP: True");
                    showhelp = true;
                }
            }

            App app = new App();//WPF项目的Application实例，用来启动WPF项目的
            app.InitializeComponent();
            app.Run();
        }
    }
}
