using System.Xml.Serialization;

public class cES {
	[XmlAttribute("TypeLimit")]
	public eET T { get; set; }
	[XmlAttribute("Index")]	
	public int Index { get; set; }
	[XmlIgnore]
	public cEquips E { get; set; }
}
