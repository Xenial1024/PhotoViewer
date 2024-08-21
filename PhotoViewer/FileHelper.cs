using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PhotoViewer
{
    internal class FileHelper
    {
        static readonly string _txtFileWithlastPhotoPath = Path.Combine(Environment.CurrentDirectory, "LastPhotoPath.txt");
        static protected internal string TxtFileWithLastPhotoPath
        {
            get { return _txtFileWithlastPhotoPath; }
        }
        protected internal static void SerializeToFile(string photoPath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(string));

                using (StreamWriter streamWriter = new StreamWriter(_txtFileWithlastPhotoPath))
                {
                    serializer.Serialize(streamWriter, photoPath);
                }
            }
            catch 
            {
                System.Windows.Forms.MessageBox.Show("Nieudany zapis do pliku.");
            }
        }
        internal static string DeserializeFromFile()
        {
            if (!File.Exists(_txtFileWithlastPhotoPath))
                return null;

            XmlSerializer serializer = new XmlSerializer(typeof(string));
            using (StreamReader streamReader = new StreamReader(_txtFileWithlastPhotoPath))
            {
                return (string)serializer.Deserialize(streamReader);
            }
        }
    }
}
