using Lim.Xml;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;

public class LineParseHashSetTest
{
    [XmlRoot("root")]
    public class ItemInfo
    {
        public enum ItemType
        {
            Weapon, Equip, Consume,
        }

        [XmlElement("items")]
        public LineParseHashSet<int> Items { get; set; }
        [XmlElement("itemIds")]
        public LineParseHashSet<ItemId> ItemIds { get; set; }
        [XmlElement("itemTypes")]
        public LineParseHashSet<ItemType> ItemTypes { get; set; }
    }

    [Test]
    public static void ReadTest()
    {
        const string xmlString = @"<root>
  <items>10,20,30</items>
  <itemIds>1000,2000</itemIds>
  <itemTypes>Equip,Consume</itemTypes>
</root>";

        ItemInfo info = XmlUtil.LoadXmlFromString<ItemInfo>(xmlString);
        Assert.AreEqual(3, info.Items.Count);
        Assert.IsTrue(info.Items.Contains(10));
        Assert.IsTrue(info.ItemIds.Contains(new ItemId(1000)));
        Assert.IsTrue(info.ItemTypes.Contains(ItemInfo.ItemType.Equip));
    }

    [Test]
    public static void WriteTest()
    {
        ItemInfo info = new ItemInfo();

        info.Items = new LineParseHashSet<int>();
        info.Items.Add(10);
        info.Items.Add(20);
        info.Items.Add(30);

        info.ItemIds = new LineParseHashSet<ItemId>();
        info.ItemIds.Add(new ItemId(1000));
        info.ItemIds.Add(new ItemId(2000));

        info.ItemTypes = new LineParseHashSet<ItemInfo.ItemType>();
        info.ItemTypes.Add(ItemInfo.ItemType.Equip);
        info.ItemTypes.Add(ItemInfo.ItemType.Consume);

        const string expectedXmlString = @"<root>
  <items>10,20,30</items>
  <itemIds>1000,2000</itemIds>
  <itemTypes>Equip,Consume</itemTypes>
</root>";

        string xmlString = XmlUtil.SaveXmlToString(info);
        Assert.AreEqual(expectedXmlString, xmlString);
    }
}