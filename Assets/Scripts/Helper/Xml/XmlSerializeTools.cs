using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

public sealed class XmlSerializeTools {
	public static void SerializeXml(string fileName, Object Datas) {
		FileStream fs = new FileStream (fileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
		XmlSerializer xs = new XmlSerializer (Datas.GetType ());
		XmlWriterSettings settings = new XmlWriterSettings();
		settings.OmitXmlDeclaration = true;
		settings.Indent = true;
		settings.NewLineChars = "\r\n";
		settings.Encoding = Encoding.UTF8;
		XmlWriter xWriter = XmlWriter.Create(fs, settings);
		XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
		ns.Add("", "");
		xs.Serialize (xWriter, Datas, ns);
		xWriter.Close();
		xs = null;
		fs.Flush ();
		fs.Close ();
	}

	public static object DeserializeXml(string filePath, Type type) {
		object Datas;
		FileStream fs = new FileStream (filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		XmlSerializer xs = new XmlSerializer (type);
		Datas = xs.Deserialize (fs);
		xs = null;
		fs.Close ();
		return Datas;
	}
}
