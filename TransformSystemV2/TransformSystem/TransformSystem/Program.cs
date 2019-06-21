#region System namespace
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
#endregion

#region Custom namespace
using TransformSystem.Helper;
using FormatTrasformerInterface;
#endregion

namespace TransformSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start processing . . .");
            var userInput = Console.ReadLine();

            string[] dllFileNames = LoadDLLs(); //Load all DLLs from pre-defined Plugin path

            ICollection<Assembly> assemblies = LoadAssemblies(dllFileNames); //Load all assemblies present in the DLL

            ICollection<Type> pluginTypes = LoadPluginTypes(assemblies.ToList()); //Load only the Types with implementation of ITransformer interface

            ICollection<ITransformer> plugins = new List<ITransformer>(pluginTypes.Count);
            foreach (Type type in pluginTypes)
            {
                ITransformer plugin = (ITransformer)Activator.CreateInstance(type);
                List<BaseInputFormat> loadedInput = plugin.LoadInput();
                List<StandardFormat> standardOutput = plugin.PerformTransformation(loadedInput);

                Utility.ExportToXML(standardOutput, type.Name);
            }

            Console.WriteLine("Transformation completed successfully !!!");
            Console.ReadLine();
        }

        /// <summary>
        /// Load all DLLs from the specified plugin path
        /// </summary>
        /// <returns></returns>
        private static string[] LoadDLLs()
        {
            string pluginPath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings.Get("PluginPath");
            string[] dlls = null;
            if (Directory.Exists(pluginPath))
            {
                dlls = Directory.GetFiles(pluginPath, "*.dll");
            }
            return dlls;
        }

        /// <summary>
        /// Load all assemblies from the DLLs present in the plugin path
        /// </summary>
        /// <param name="dllFileNames"></param>
        /// <returns></returns>
        private static List<Assembly> LoadAssemblies(string[] dllFileNames)
        {
            ICollection<Assembly> assemblies = new List<Assembly>(dllFileNames.Length);
            foreach (string dllFile in dllFileNames)
            {
                try
                {
                    AssemblyName asm = AssemblyName.GetAssemblyName(dllFile);
                    Assembly assembly = Assembly.Load(asm);
                    assemblies.Add(assembly);
                }
                catch
                {
                    //Skip the DLL if there is any exception in loading it
                }
            }
            return assemblies.ToList();
        }

        /// <summary>
        /// Load only the type that has implemeted ITransformer interface
        /// </summary>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        private static List<Type> LoadPluginTypes(List<Assembly> assemblies)
        {
            Type pluginType = typeof(ITransformer);
            ICollection<Type> pluginTypes = new List<Type>();
            foreach (Assembly assembly in assemblies)
            {
                try
                {
                    if (assembly != null)
                    {
                        Type[] types = assembly.GetTypes();
                        foreach (Type type in types)
                        {
                            if (type.IsInterface || type.IsAbstract)
                            {
                                continue;
                            }
                            else
                            {
                                if (type.GetInterface(pluginType.FullName) != null)
                                {
                                    pluginTypes.Add(type);
                                }
                            }
                        }
                    }
                }
                catch
                {
                    //Skip the Type if there is any issue processing it.
                }
            }
            return pluginTypes.ToList();
        }
    }
}
