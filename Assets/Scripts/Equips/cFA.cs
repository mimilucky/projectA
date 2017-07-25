using System.Xml.Serialization;

// Equips Fight Attribute
public class cFA {
	[XmlAttribute]
	public int Dmg { get; set; }							// 单发伤害
	[XmlAttribute]
	public int Count { get; set; }							// 一轮发射数量
	[XmlAttribute]
	public float Speed { get; set; }						// 攻击间隔
	[XmlAttribute]
	public eDmgType DmgType { get; set; }		// 伤害类型, 炮/雷/防空/空战/轰炸
	[XmlAttribute]
	public eLockType LockType { get; set; }		// 锁定方式, 锁/不锁
	[XmlAttribute]
	public eAtkType AtkType { get; set; }			// 攻击方式, 直/散/跨
	[XmlAttribute]
	public int Range { get; set; }							// 攻击距离
	[XmlAttribute]
	public int OffSet { get; set; }							// 偏移范围(弹道)
}
