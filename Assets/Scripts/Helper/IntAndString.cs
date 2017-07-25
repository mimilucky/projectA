using System.Xml.Serialization;

public class IntAndString {
	[XmlAttribute]
	public int Index { get; set; }
	[XmlAttribute]
	public string Value { get; set; }

	public IntAndString() {
	}
}
