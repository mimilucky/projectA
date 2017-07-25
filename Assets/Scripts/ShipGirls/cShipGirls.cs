using System.Xml.Serialization;
using UnityEngine;

public class cShipGirls {
	[XmlAttribute]
	public int Index { get; set; }
	[XmlAttribute("Types")]
	public eST ST { get; set; }								// 船只类型
	[XmlElement("Levels")]
	public cLevelA LA { get; set; }						// 等级/当前经验/升级经验
	[XmlElement("Girls")]
	public cTextInfo TI { get; set; }						// 舰娘的名字, 描述
	[XmlArray("Attributes")]
	public cSGBA[] BA { get; set; }					// 舰娘基础属性和成长
	[XmlIgnore]
	public cSGA[] TA { get; set; }						// 舰娘总属性
	[XmlArray("EquipSlots")]
	public cES[] E { get; set; }								// 舰娘装备槽(装备类型都是标配, 然后自行解锁新装备升级)

	public cShipGirls() {}
	// 指定等级
	public cShipGirls(int index, int level) {
		if (level > ShipGirlsDatas.GetLevelMax ())
			throw new UnityException ("Level out of max");
		else
			Init (index, level);
	}
	// 指定等级(当前经验), 装备 - 读取存档用
	public cShipGirls(int index, cLevelA level, cES[] equip) {
		cShipGirls _cache = ShipGirlsDatas.Get (index);
		Index = index;
		ST = _cache.ST;
		LA = level;
		TI = _cache.TI;
		BA = _cache.BA;

		TA = new cSGA[BA.Length];
		for (int i1 = 0; i1 < TA.Length; i1++) {
			TA [i1] = new cSGA ();
			TA [i1].T = BA [i1].T;
		}
		UpdateTA ();

		E = equip;

		for (int i2 = 0; i2 < E.Length; i2++) {
			E [i2].E = EquipsDatas.Get (E [i2].Index);
		}
	}

	// 初始化舰娘(指定编号)
	private void Init(int index, int level) {
		// 缓存引用
		cShipGirls _cache = ShipGirlsDatas.Get (index);

		// 初始化编号 - 赋值
		Index = index;

		// 初始化船只类型 - 赋值?
		ST = _cache.ST;

		// 初始化等级经验 - 引用(new)
		LA = new cLevelA (level);

		// 赋予名字说明 - 引用?
		TI = _cache.TI;

		// 初始化基础属性和成长 - 引用
		BA = _cache.BA;

		// 初始化总属性 - 赋值
		TA = new cSGA[BA.Length];
		for (int i1 = 0; i1 < TA.Length; i1++) {
			TA [i1] = new cSGA ();
			TA [i1].T = BA [i1].T;
		}

		// 初始化装备 - 引用
		E = _cache.E;

		/* 初始化装备 - 赋值
		int leng = _cache.E.Length;
		E = new cES[leng];
		for (int i2 = 0; i2 < E.Length; i2++) {
			E [i2] = new cES ();
			E [i2].T = _cache.E [i2].T;
			E [i2].Index = _cache.E [i2].Index;

			cEquips _e = EquipsDatas.Get (E [i2].Index);
			E [i2].E = new cEquips ();
			E [i2].E.Index = _e.Index;
			E [i2].E.R = _e.R;
			E [i2].E.ET = _e.ET;
			E [i2].E.FA = new cFA ();
			E [i2].E.FA.Dmg = _e.FA.Dmg;
			E [i2].E.FA.Count = _e.FA.Count;
			E [i2].E.FA.Speed = _e.FA.Speed;
			E [i2].E.FA.DmgType = _e.FA.DmgType;
			E [i2].E.FA.LockType = _e.FA.LockType;
			E [i2].E.FA.AtkType = _e.FA.AtkType;
			E [i2].E.FA.Range = _e.FA.Range;
			E [i2].E.FA.Angle = _e.FA.Angle;
			E [i2].E.FA.OffSet = _e.FA.OffSet;
			E [i2].E.FA.BulletType = _e.FA.BulletType;
			E [i2].E.FA.BulletValue = _e.FA.BulletValue;
		}*/
	}

	// 添加经验, 自动判断升级
	public void AddExp(int exp) {
		LA.CE += exp;
		LevelUp ();
	}
	private void LevelUp() {
		// 获取等级上限
		int i = ShipGirlsDatas.GetLevelMax();
		// 循环检测, 避免出现经验过多, 只升一次级的问题.
		while(LA.L < i && LA.CE >= LA.LE) {
			LA.CE -= LA.LE;
			LA.L++;
			// 获取下一个等级升级所需的经验值
			LA.LE = ShipGirlsDatas.GetLevelExp (LA.L);

			// 更新总属性数值(等级成长部分)
			UpdateTA();
		}
	}
	private void UpdateTA() {
		// 更新属性 - 总属性 = 基础 + 等级 * 成长
		for (int i = 0; i < BA.Length; i++)
			TA [i].V = BA [i].V + (int)(BA [i].G * LA.L + 0.5f);
	}
}
