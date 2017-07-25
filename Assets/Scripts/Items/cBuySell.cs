using System.Xml.Serialization;

public class cBuySell {
	[XmlAttribute]
	public int Index { get; set; }
	[XmlElement]
	public cBuySellList[] Buy { get; set; }					// 购买
	[XmlElement]
	public cBuySellList[] Sell { get; set; }					// 出售

	public cBuySell() {
	}
}
public class cBuySellList {
	[XmlAttribute]
	public eBuySellType Type { get; set; }		// 类型
	[XmlAttribute]
	public int Price { get; set; }						// 价格

	public cBuySellList() {
		Type = eBuySellType.Oil;
	}
}
public enum eBuySellType {
	None,															// 无法购买出售
	Oil,																// 油
	Gold,															// 金钱
	Point,															// 点数(点卷)
	Length
}