using System.Xml.Serialization;

public class cLevelA {
	[XmlAttribute("Level")]
	public int L { get; set; }
	[XmlAttribute("CurrentExp")]
	public int CE { get; set; }
	[XmlIgnore]
	public int LE { get; set; }

	public cLevelA() {
		L = 1;
		LE = ShipGirlsDatas.GetLevelExp (L);
	}

	public cLevelA(int level) {
		L = level;
		LE = ShipGirlsDatas.GetLevelExp (L);
	}
}
