using System.Xml.Serialization;

public class cPCShipGirls {
	[XmlAttribute]
	public int Index { get; set; }
	[XmlElement]
	public cLevelA Levels { get; set; }
	[XmlArray]
	public cES[] Equips { get; set; }

	public cPCShipGirls() {	}
	public cPCShipGirls(int index) {
		Index = index;
		Levels = new cLevelA ();
		Equips = ShipGirlsDatas.GetDefaultEquips (Index);
	}
}
