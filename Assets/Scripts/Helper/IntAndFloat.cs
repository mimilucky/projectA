using System.Xml.Serialization;

public class IntAndFloat {
	[XmlAttribute]
	public int Index { get; set; }
	[XmlAttribute]
	public float Value { get; set; }

	public IntAndFloat() {
	}
}
