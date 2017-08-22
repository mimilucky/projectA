


using System.Xml.Serialization;
public class cEquips {
	[XmlAttribute]
	public int Index { get; set; }
	[XmlAttribute("Rare")]
	public eRT R { get; set; }								// Rare Type 物品稀有度(名字颜色显示 or 背景颜色区分)
	[XmlAttribute("Type")]
	public eET ET { get; set; }								// Equips Type 装备类型
	[XmlElement("FightAttribute")]
	public cFA FA { get; set; }							// 基础战斗属性
	[XmlElement("Equips")]
	public cTextInfo TI { get; set; }						// 名字/说明

	public cEquips() {}
}