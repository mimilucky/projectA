public class cE_Com {
}
// Rare Type
public enum eRT {
	N,
	R,
	SR,
	SSR,
	EX,
	Length
}
// Equips Type 装备类型
public enum eET {
	G_DD,
	G_CL,
	G_CA,
	G_BB,
	SG,
	Torpedo,
	AC_Fight,
	AC_Torpedo,
	AC_Bomber,
	AntiAC,
	E,
	Length
}

#region Fight Attribute Type
public enum eLockType {
	UnLock,												// 不锁定(朝正前方射击)
	Lock,													// 锁定(朝最近的目标射击)
	Length
}
public enum eAtkType {
	Direct,													// 直射
	Scatter,												// 散射
	Cross,													// 跨射
	Length
}
public enum eDmgType {
	Gun,													// 炮击
	Torpedo,												// 雷击
	AntiAirCraft,										// 防空
	AirFight,												// 空战
	Bomber,												// 轰炸
	Length
}
public enum eBulletType {
	N,															// 普通弹
	HE,														// 高爆弹
	AP,														// 穿甲弹
	Length
}
#endregion