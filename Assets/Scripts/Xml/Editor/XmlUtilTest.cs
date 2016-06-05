using Lim.Xml;
using NUnit.Framework;
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
}