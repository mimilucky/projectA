using System.Xml.Serialization;

public class cTextInfo {
	[XmlAttribute]
	public string Name { get; set; }
	[XmlAttribute]
	public string Descript { get; set; }

	public cTextInfo() {}
	public cTextInfo(string name, string descript) {
		Name = name;
		Descript = descript;
	}
}
