using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MP.Activity
{
    public class ActivityStore
    {
        private static ActivityStore _instance;
        private string _root = string.Empty;
        private const string _filelist = "activities.xml";
        private string _filePath = string.Empty;

        private ActivityStore(string root)
        {
            _root = root;
            _filePath = System.IO.Path.Combine(_root, _filelist);
        }

        public static ActivityStore GetInstance(string root)
        {
            if (_instance == null)
            {
                _instance = new ActivityStore(root);
            }
            return _instance;
        }

        public ActivityContainer GetContainer()
        {
            ActivityContainer container = Deserialize(_filePath);
            return container;
        }

        public void Save(ActivityContainer container)
        {
            Serialize(container, _filePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void Serialize(ActivityContainer container, string path)
        {
            using (Stream savestream = new FileStream(path, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ActivityContainer));
                serializer.Serialize(savestream, container);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static ActivityContainer Deserialize(string path)
        {
            ActivityContainer files = null;

            using (Stream loadstream = new FileStream(path, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ActivityContainer));
                files = (ActivityContainer)serializer.Deserialize(loadstream);
            }

            return files;
        }
    }
}
