using Lim.Xml;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using System;

public class ListParseDictionaryTest
{
    public class ItemInfo : IDictionaryKeyHaving<ItemId>
    {
        [XmlElement("itemId")]
        public ItemId ItemId { get; set; }
        [XmlElement("cost")]
        public int Cost { get; set; }

        public ItemId DictionaryKey
        {
            get { return ItemId; }
        }
    }

    [XmlRoot("root")]
    public class ItemDatabase
    {
        [XmlElement("items")]
        public ListParseDictionary<ItemId, ItemInfo> Items { get; set; }
    }

    [Test]
    public static void ReadTest()
    {
        const string xmlString = @"<root>
  <items>
    <itemInfo>
      <itemId>1000</itemId>
      <cost>1</cost>
    </itemInfo>
    <itemInfo>
      <itemId>2000</itemId>
      <cost>2</cost>
    </itemInfo>
  </items>
</root>";

        ItemDatabase itemDatabase = XmlUtil.LoadXmlFromString<ItemDatabase>(xmlString);
        Assert.AreEqual(2, itemDatabase.Items.Count);
        ItemInfo info;
        Assert.IsTrue(itemDatabase.Items.TryGetValue(new ItemId(2000), out info));
        Assert.AreEqual(new ItemId(2000), info.ItemId);
        Assert.AreEqual(2, info.Cost);
    }
}