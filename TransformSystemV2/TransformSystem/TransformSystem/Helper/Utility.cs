#region System namespace
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
#endregion

namespace TransformSystem.Helper
{
    /// <summary>
    /// Utility class to provide generic functionality accross system 
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Function to export an object into a either XML or JSON format. 
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="inputData">Object to be serialized</param>
        /// <param name="format">Format (XML/JSON) to be serialized</param>
        /// <returns></returns>
        public static bool ExportToStandardFormat<T>(T inputData, string sourceObject, ExportFormat format)
        {
            bool result = false;

            switch (format)
            { 
                case ExportFormat.XML:
                    result = ExportToXML(inputData, sourceObject);
                    break;
                case ExportFormat.JSON:
                    result = ExportToJSON(inputData, sourceObject);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Function to export an object into XML format. 
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="inputData">Object to be serialized</param>
        /// <returns></returns>
        public static bool ExportToXML<T>(T inputData, string sourceObject)
        {
            bool result = false;
            XmlSerializer serializer = new XmlSerializer(inputData.GetType());
            string outputFile = AppDomain.CurrentDomain.BaseDirectory + "Generic_format_Export_For_" + sourceObject + "_" +  DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".xml";
            using (TextWriter writer = new StreamWriter(outputFile))
            {
                try
                {
                    serializer.Serialize(writer, inputData);
                    result = true;
                }
                catch (Exception ex)
                {
                    //Custom code for detail exception handling can be added here.
                    //Error loging, Alert Email, etc
                    //Error logging can be done in Log file, Event Viewer, Database, etc
                }
            }
            return result;
        }

        /// <summary>
        /// Function to export an object into JSON format. 
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="inputData">Object to be serialized</param>
        /// <returns></returns>
        public static bool ExportToJSON<T>(T inputData, string sourceObject)
        {
            bool result = false;
            JsonSerializer serializer = new JsonSerializer();
            string outputFile = AppDomain.CurrentDomain.BaseDirectory + "Generic_format_Export_" + sourceObject + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".json";
            using (StreamWriter sw = new StreamWriter(outputFile))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                try
                {
                    serializer.Serialize(writer, inputData);
                    result = true;
                }
                catch (Exception ex)
                {
                    //Custom code for detail exception handling can be added here.
                    //Error loging, Alert Email, etc
                    //Error logging can be done in Log file, Event Viewer, Database, etc
                }
            }
            return result;
        }
        /// <summary>
        /// Function to store an object into JSON format. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool SaveToDataBase<T>(T inputData)
        {
            //TODO: Impliment code to store the details in Database
            throw new NotImplementedException();
        }
    }

    public enum ExportFormat { XML, JSON }
}
