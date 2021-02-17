using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleAppProject.App03
{
    public static class Streamer
    {
        public static string SerializationFile = Path.Combine(@"C:\Users\andre\source\repos\andreicruceru95\CO453-C-Apps\ConsoleAppProject\App03", "Student.bin");

        /// <summary>
        /// save a given list to binary format
        /// </summary>
        /// <param name="Students">A given list</param>
        public static void SaveFile(List<Student> Students)
        {
            using (Stream stream = File.Open(SerializationFile, FileMode.Create))
            {
                var Bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                Bformatter.Serialize(stream, Students);
            }
        }

        /// <summary>
        /// read file and return it as a list
        /// </summary>
        /// <returns>a list of data</returns>
        public static List<Student> ReadFile()
        {
            using (Stream stream = File.Open(SerializationFile, FileMode.Open))
            {
                var Bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                return (List<Student>)Bformatter.Deserialize(stream);
            }
        }
    }
}
