using Lim.Xml;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;

public class ItemIdTest
{
    [XmlRoot("root")]
    public class ItemInfo
    {
        [XmlElement("itemId")]
        public ItemId itemId;
    }

    [Test]
    public void ReadXmlTest()
    {
        const string xmlString = @"<root>
  <itemId>1000</itemId>
</root>";

        ItemInfo info = XmlUtil.LoadXmlFromString<ItemInfo>(xmlString);
        Assert.AreEqual(1000, info.itemId.ToUInt32());
    }

    [Test]
    public void WriteXmlTest()
    {
        ItemInfo info = new ItemInfo();
        info.itemId = new ItemId(1000);

        const string expectedXmlString = @"<root>
  <itemId>1000</itemId>
</root>";

        string xmlString = XmlUtil.SaveXmlToString(info);
        Assert.AreEqual(expectedXmlString, xmlString);
    }
}