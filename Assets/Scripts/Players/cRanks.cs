using System.Xml.Serialization;

public class cRanks {
	[XmlAttribute]
	public eRankType Type { get; set; }
	[XmlAttribute]
	public string Name { get; set; }
}
