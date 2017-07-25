using System.Collections.Generic;
using System.Xml.Serialization;

public class cPlayers {
	[XmlAttribute]
	public int Index { get; set; }
	[XmlAttribute]
	public string Name { get; set; }
	[XmlAttribute]
	public eRankType Rank { get; set; }
	[XmlElement("Levels")]
	public cLevelA Level { get; set; }									// 等级/当前经验/升级经验
	[XmlElement]
	public cMoneys Moneys { get; set; }
	[XmlElement]
	public cTeams Teams { get; set; }								// 舰队(战斗和远征)
	[XmlArray("Girls")]
	public List<cPCShipGirls> GirlsSaves { get; set; }
	[XmlIgnore]
	public List<cShipGirls> Girls { get; set; }
	[XmlArray]
	public List<int> Items { get; set; }
	[XmlArray]
	public List<int> Equips { get; set; }

	public cPlayers() {
		Name = "WhoAmI";
		Rank = eRankType.L;
		Level = new cLevelA ();
		Moneys = new cMoneys ();
		Teams = new cTeams ();
		GirlsSaves = new List<cPCShipGirls> ();
		Girls = new List<cShipGirls> ();
		Items = new List<int> ();
		Equips = new List<int> ();
	}

	public void AddGirls(int index) {
		Girls.Add (new cShipGirls (index, 0));
	}
	public void AddGirls(int index, int level) {
		Girls.Add (new cShipGirls (index, level));
	}
	public void AddGirls(cPCShipGirls pcShipGirls) {
		Girls.Add (new cShipGirls (pcShipGirls.Index, pcShipGirls.Levels, pcShipGirls.Equips));
	}
}
