using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Lim.Xml
{
    /// <summary>
    /// 리스트 형태를 파싱하여 만드는 딕셔너리
    /// </summary>
    public class ListParseDictionary<TKey, TValue>
        : Dictionary<TKey, TValue>, IXmlSerializable
        where TValue : IDictionaryKeyHaving<TKey>
    {
        #region IXmlSerializable Members
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty)
            {
                return;
            }

            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                TValue value = (TValue)valueSerializer.Deserialize(reader);
                Add(value.DictionaryKey, value);
            }
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            XmlSerializerNamespaces namespaces = XmlUtil.GetEmptyNamespaces();

            foreach(var value in Values)
            {
                valueSerializer.Serialize(writer, value, namespaces);
            }
        }
        #endregion
    }
}