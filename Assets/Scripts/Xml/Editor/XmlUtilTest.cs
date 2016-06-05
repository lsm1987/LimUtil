﻿using Lim.Xml;
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
}