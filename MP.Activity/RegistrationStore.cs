using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MP.Activity
{
    public class RegistrationStore
    {
        private static RegistrationStore _instance;
        private string _root = string.Empty;
        private const string _filelist = "registrations.xml";
        private string _filePath = string.Empty;

        private RegistrationStore(string root)
        {
            _root = root;
            _filePath = System.IO.Path.Combine(_root, _filelist);
        }

        public static RegistrationStore GetInstance(string root)
        {
            if (_instance == null)
            {
                _instance = new RegistrationStore(root);
            }
            return _instance;
        }

        //public Files GetAllFiles()
        //{
        //    Files files = Deserialize(_filePath);
        //    return files;
        //}

        public void Save(Registration registration)
        {
            Serialize(registration, _filePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void Serialize(Registration registration, string path)
        {
            using (Stream savestream = new FileStream(path, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Registration));
                serializer.Serialize(savestream, registration);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static Registration Deserialize(string path)
        {
            Registration files = null;

            using (Stream loadstream = new FileStream(path, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Registration));
                files = (Registration)serializer.Deserialize(loadstream);
            }

            return files;
        }
    }
}
