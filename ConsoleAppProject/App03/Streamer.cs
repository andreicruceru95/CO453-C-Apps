using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleAppProject.App03
{
    public static class Streamer
    {
        public static string SerializationFile = Path.Combine(@"C:\Users\andre\source\repos\andreicruceru95\CO453-C-Apps\ConsoleAppProject\App03", "Student.bin");

        public static void SaveFile(List<Student> Students)
        {
            using (Stream stream = File.Open(SerializationFile, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, Students);
            }
        }

        public static List<Student> ReadFile()
        {
            using (Stream stream = File.Open(SerializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                return (List<Student>)bformatter.Deserialize(stream);
            }
        }
    }
}
