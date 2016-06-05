using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Lim.Xml
{
    /// <summary>
    /// 직렬화시 텍스트 한줄이 되는 HashSet
    /// </summary>
    public class OneLineHashSet<T>
        : HashSet<T>, IXmlSerializable
    {
        #region IXmlSerializable Members
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            string valuesString = reader.ReadString();
            string[] splittedValues = valuesString.Split(',');
            foreach (string value in splittedValues)
            {
                Add((T)Convert.ChangeType(value, typeof(T)));
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            string valuesString = string.Empty;
            foreach (T value in this)
            {
                if (valuesString != string.Empty)
                {
                    valuesString += ",";
                }
                valuesString += value.ToString();
            }
            writer.WriteString(valuesString);
        }
        #endregion
    }
}