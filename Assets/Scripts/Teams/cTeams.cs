using System.Xml.Serialization;

public class cTeams {
	[XmlElement]
	public cNavis[] Fight { get; set; }
	[XmlElement]
	public cNavis[] Expedition { get; set; }

	public cTeams() {
		Fight = new cNavis[SettingsDatas.GetFTeamsLimit()];
		for (int i = 0; i < Fight.Length; i++) {
			Fight [i] = new cNavis ();
			Fight [i].Index = i;
		}

		Expedition = new cNavis[SettingsDatas.GetETeamsLimit()];
		for (int i = 0; i < Expedition.Length; i++) {
			Expedition [i] = new cNavis ();
			Expedition [i].Index = i;
		}
	}
}
