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
        }

        public void WriteXml(XmlWriter writer)
        {
        }
        #endregion
    }
}