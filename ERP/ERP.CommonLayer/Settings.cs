using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace ERP.CommonLayer
{
	public class Settings
	{

		public static void SaveSettingFile(Dictionary<string, string> textValues)
		{
			string appSettingDirectory = Common.GetAllUserPath();
			
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Path.Combine(appSettingDirectory, "Settings.xml"));
			XmlNodeList userNodes = xmlDoc.SelectNodes("//AppSettings/ServerName");
			foreach (XmlNode userNode in userNodes)
			{
				userNode.InnerText = textValues["ServerName"].ToString();
			}

			userNodes = xmlDoc.SelectNodes("//AppSettings/DatabaseName");
			foreach (XmlNode userNode in userNodes)
			{
				userNode.InnerText = textValues["DatabaseName"].ToString();
			}

			userNodes = xmlDoc.SelectNodes("//AppSettings/AuthenticationType");
			foreach (XmlNode userNode in userNodes)
			{
				userNode.InnerText = textValues["AuthenticationType"].ToString();
			}

			userNodes = xmlDoc.SelectNodes("//AppSettings/DBUserName");
			foreach (XmlNode userNode in userNodes)
			{
				userNode.InnerText = textValues["DBUserName"].ToString();
			}

			userNodes = xmlDoc.SelectNodes("//AppSettings/DBPassword");
			foreach (XmlNode userNode in userNodes)
			{
				userNode.InnerText = textValues["DBPassword"].ToString();
			}

			xmlDoc.Save(Path.Combine(appSettingDirectory, "Settings.xml")); 
		}

		public static void CreateSettingFile()
		{
			string appSettingDirectory = Common.GetAllUserPath();

			if (!Directory.Exists(appSettingDirectory))
				Directory.CreateDirectory(appSettingDirectory);

			if (!File.Exists(Path.Combine(appSettingDirectory, "Settings.xml")))
			{
				XmlTextWriter textWriter = new XmlTextWriter(Path.Combine(appSettingDirectory, "Settings.xml"), System.Text.Encoding.UTF8);
				//creating XmlTestWriter, and passing file name and encoding type as argument
				textWriter.Formatting = Formatting.Indented;
				//setting XmlWriter formating to be indented
				//textWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
				
				// Opens the document  
				textWriter.WriteStartDocument();
				// Write comments  
				textWriter.WriteComment("Setting Files, Don't change this document text");
				// Write first element  
				textWriter.WriteStartElement("AppSettings");

				textWriter.WriteStartElement("Version", "");
				textWriter.WriteString("1.0.0");
				textWriter.WriteEndElement();

				textWriter.WriteStartElement("ServerName", "");
				textWriter.WriteString("./sqlexpress");
				textWriter.WriteEndElement();

				textWriter.WriteStartElement("DatabaseName", "");
				textWriter.WriteString("Default");
				textWriter.WriteEndElement();

				textWriter.WriteStartElement("AuthenticationType", "");
				textWriter.WriteString("Windows");
				textWriter.WriteEndElement();
				
				textWriter.WriteStartElement("DBUserName", "");
				textWriter.WriteString("sa");
				textWriter.WriteEndElement();

				textWriter.WriteStartElement("DBPassword", "");
				textWriter.WriteString("Password1");
				textWriter.WriteEndElement();

				textWriter.WriteStartElement("ProductExpiredDays", "");
				textWriter.WriteString("30");
				textWriter.WriteEndElement();

				textWriter.WriteStartElement("InstalledDate", "");
				textWriter.WriteString(DateTime.Now.ToString());
				textWriter.WriteEndElement();

				textWriter.WriteStartElement("CurrentDate", "");
				textWriter.WriteString(DateTime.Now.ToString());
				textWriter.WriteEndElement();

				//// WriteChars  
				//char[] ch = new char[6];
				//ch[0] = 's';
				//ch[1] = 'a';
				//ch[2] = 'm';
				//textWriter.WriteStartElement("Text");
				//textWriter.WriteChars(ch, 0, ch.Length);
				//textWriter.WriteEndElement();
				textWriter.WriteEndElement();

				//// Ends the document.  
				textWriter.WriteEndDocument();
				// close writer  
				textWriter.Close();
			}
		}

		public static Dictionary<string, string> ReadSettingFiles()
		{
			string appSettingDirectory = Common.GetAllUserPath();
			Dictionary<string, string> textValues = new Dictionary<string, string>();
			XmlTextReader textReader = new XmlTextReader(Path.Combine(appSettingDirectory, "Settings.xml"));
			textReader.Read();
			string elementValue = string.Empty;
			while (textReader.Read())
			{
				switch (textReader.NodeType)
				{
					case XmlNodeType.Element:
						elementValue = textReader.Name;
						break;
					case XmlNodeType.Text:
						switch (elementValue)
						{
							case "ServerName":
								textValues.Add(elementValue, textReader.Value);
								break;
							case "DatabaseName":
								textValues.Add(elementValue, textReader.Value);
								break;
							case "AuthenticationType":
								textValues.Add(elementValue, textReader.Value);
								break;
							case "DBUserName":
								textValues.Add(elementValue, textReader.Value);
								break;
							case "DBPassword":
								textValues.Add(elementValue, textReader.Value);
								break;
							case "ProductExpiredDays":
								textValues.Add(elementValue, textReader.Value);
								break;
							case "InstalledDate":
								textValues.Add(elementValue, textReader.Value);
								break;
							case "CurrentDate":
								textValues.Add(elementValue, textReader.Value);
								break;
						}
						break;
				}
			}
			textReader.Close();
			return textValues;
		}
}
}
