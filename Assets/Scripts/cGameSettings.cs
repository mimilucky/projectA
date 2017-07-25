using System.Xml.Serialization;

public class cGameSettings {

	[XmlAttribute]
	public int FTeamsLimit { get; set; }					// 战斗舰队限制(舰队数量)
	[XmlAttribute]
	public int ETeamsLimit { get; set; }					// 远征舰队限制(舰队数量)
}
