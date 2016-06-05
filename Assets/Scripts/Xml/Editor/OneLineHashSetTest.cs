using Lim.Xml;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;

public class OneLineHashSetTest
{
    [XmlRoot("root")]
    public class ItemInfo
    {
        [XmlElement("items")]
        public OneLineHashSet<int> Items { get; set; }
    }

    [Test]
    public static void ReadTest()
    {
        const string xmlString = @"<root>
  <items>10,20,30</items>
</root>";

        ItemInfo info = XmlUtil.LoadXmlFromString<ItemInfo>(xmlString);
        Assert.AreEqual(3, info.Items.Count);
        Assert.IsTrue(info.Items.Contains(10));
    }

    [Test]
    public static void WriteTest()
    {
        ItemInfo info = new ItemInfo();
        info.Items = new OneLineHashSet<int>();
        info.Items.Add(10);
        info.Items.Add(20);
        info.Items.Add(30);

        const string expectedXmlString = @"<root>
  <items>10,20,30</items>
</root>";
        string xmlString = XmlUtil.SaveXmlToString(info);
        Assert.AreEqual(expectedXmlString, xmlString);
    }
}