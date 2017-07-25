using System.Xml.Serialization;

public class cNavis {
	[XmlAttribute]
	public int Index { get; set; }
	[XmlAttribute]
	public int MainGirl { get; set; }
	[XmlAttribute]
	public int SurppotGirl { get; set; }
}
