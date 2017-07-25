using System.Xml.Serialization;

// Ship Girl Base Attributes
public class cSGA {
	[XmlAttribute("Type")]
	public eSG_AT T { get; set; }					// Type 舰娘属性类型
	[XmlAttribute("Value")]
	public int V { get; set; }								// Value 值
}