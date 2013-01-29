using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;


namespace RankMe.Utilities
{
	public static class TemplateManager
	{

		private static XDocument _TemplateDocument;
		private static string _Pattern = "(<%=)({0})(%>)";

		static TemplateManager()
		{
			
			string path = Path.Combine(
								HttpContext.Current.Server.MapPath(
									ConfigurationManager.AppSettings["DefaultTemplate"]
								)
							);
			string content = string.Empty;

			_TemplateDocument = XDocument.Load(path);
		}


		public static string WriteText(string id,List<KeyValuePair<string,string>> cKeyValue)
		{

			var dest = _TemplateDocument.Root.Elements("template").FirstOrDefault(f => f.Attribute("id").Value == id);
			StringBuilder content = new StringBuilder(dest.Value);


			foreach (var i in cKeyValue)
			{
				string iReplace = string.Format("<%={0}%>",i.Key);
				content.Replace(iReplace, i.Value);
			}


			return content.ToString();
		}

	}
}