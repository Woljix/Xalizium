using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API;

namespace Xalizium.Managers
{
    public static class PluginManager
    {
        // *Insert some 2012 meme here*
        public static void LoadAllTheFiles()
        {
            string PluginFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

            if (!Directory.Exists(PluginFolder))
                Directory.CreateDirectory(PluginFolder);

            foreach (string Folder in Directory.GetDirectories(PluginFolder))
            {
                string pluginInfoFile = Path.Combine(Folder, "Setup.json");
                if (File.Exists(pluginInfoFile))
                {
                    try
                    {
                        PluginInfo info = JsonConvert.DeserializeObject<PluginInfo>(File.ReadAllText(pluginInfoFile));

                        var DLL = Assembly.LoadFile(Path.Combine(Folder, info.AssemblyFile));

                        Type type = DLL.GetExportedTypes().Where(x => x.FullName == info.Function).FirstOrDefault();

                        if (type.BaseType == typeof(Plugin))
                        {
                            dynamic c = Activator.CreateInstance(type);
                            c.Initialize();
                            Debug.WriteLine("Loaded Plugin: " + info.Name, "PLUGINMANAGER");
                        }
                    }
                    catch { Debug.WriteLine(string.Format("'{0}' Failed!", pluginInfoFile)); }
                }
            }
        }
        public static void CreateTemplateFile(string Filename)
        {
            PluginInfo info = new PluginInfo();

            info.Name = "Template Name";
            info.Description = "Template Description";
            info.AssemblyFile = "PluginFile.dll";
            info.Function = "Namespace.Class";

            File.WriteAllText(Filename, JsonConvert.SerializeObject(info, Formatting.Indented));
        }
    }

    [Serializable]
    public class PluginInfo
    {
        /// <summary>
        /// The Name of the plugin
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The Description of the plugin
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Example: "TestPlugin.dll"
        /// </summary>
        public string AssemblyFile { get; set; }

        /// <summary>
        /// Example: "TestPlugin.Program" (The class that inherits from the Plugin class)
        /// </summary>
        public string Function { get; set; }

        public PluginInfo() { }
    }
}
