using System.Xml.Serialization;

public class cMoneys {
	[XmlAttribute("Oil")]
	public int O { get; set; }						// 油
	[XmlAttribute("Bullet")]
	public int B { get; set; }						// 弹
	[XmlAttribute("Steel")]
	public int S { get; set; }						// 钢
	[XmlAttribute("Aluminum")]
	public int A { get; set; }						// 铝

	public cMoneys() {
		O = 100;
		B = 100;
		S = 100;
		A = 100;
	}
}
