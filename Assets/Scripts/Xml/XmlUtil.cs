using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace Lim.Xml
{
    public static class XmlUtil
    {
        /// <summary>
        /// XML 파일로부터 클래스 인스턴스를 생성한다.
        /// </summary>
        public static T LoadXmlFromFile<T>(string filePath)
            where T : class
        {
            TextAsset textAsset = Resources.Load<TextAsset>(filePath);
            if (textAsset == null)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var s = new MemoryStream(textAsset.bytes))
            {
                return serializer.Deserialize(s) as T;
            }
        }
    }
}