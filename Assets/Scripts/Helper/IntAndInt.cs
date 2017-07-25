using System.Xml.Serialization;

public class IntAndInt {
	[XmlAttribute]
	public int Index1 { get; set; }
	[XmlAttribute]
	public int Index2 { get; set; }

	public IntAndInt() {
	}
}
