using System.IO;
using System.Xml;
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

        /// <summary>
        /// XML 문자열로부터 클래스 인스턴스를 생성한다.
        /// </summary>
        public static T LoadXmlFromString<T>(string xmlString)
            where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(xmlString))
            {
                return serializer.Deserialize(reader) as T;
            }
        }

        /// <summary>
        /// 인스턴스를 XML 문자열로 변경한다.
        /// </summary>
        public static string SaveXmlToString<T>(T obj, XmlWriterSettings settings, XmlSerializerNamespaces namespaces)
        {
            using (var stringWriter = new StringWriter())
            using (var writer = XmlWriter.Create(stringWriter, settings))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj, namespaces);
                return stringWriter.ToString();
            }
        }

        public static string SaveXmlToString<T>(T obj)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;

            return SaveXmlToString(obj, settings, GetEmptyNamespaces());
        }

        public static XmlSerializerNamespaces GetEmptyNamespaces()
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            return namespaces;
        }
    }
}