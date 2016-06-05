using Lim.Xml;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;

public class XmlUtilTest
{
    [XmlRoot("root")]
    public class XmlTestInfo
    {
        [XmlElement("intVal")]
        public int IntVal { get; set; }
    }

	[Test]
	public void LoadXmlFromFileTest()
	{
        XmlTestInfo info = XmlUtil.LoadXmlFromFile<XmlTestInfo>("XmlTestInfo");
        Assert.NotNull(info);
        Assert.AreEqual(100, info.IntVal);
	}

    [Test]
    public void LoadXmlFromStringTest()
    {
        string xmlString = @"<root>
    <intVal>100</intVal>
</root>";
        XmlTestInfo info = XmlUtil.LoadXmlFromString<XmlTestInfo>(xmlString);
        Assert.NotNull(info);
        Assert.AreEqual(100, info.IntVal);
    }

    [Test]
    public void SaveXmlToStringTest()
    {
        XmlTestInfo info = new XmlTestInfo();
        info.IntVal = 100;

        const string expectedXmlString = @"<root>
  <intVal>100</intVal>
</root>";

        XmlWriterSettings settings = new XmlWriterSettings();
        settings.OmitXmlDeclaration = true;
        settings.Indent = true;

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add("", "");

        string xmlString = XmlUtil.SaveXmlToString(info, settings, namespaces);
        Assert.AreEqual(expectedXmlString, xmlString);
    }
}