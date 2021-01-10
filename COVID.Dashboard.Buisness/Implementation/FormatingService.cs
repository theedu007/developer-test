using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using COVID.Dashboard.Models.Auxiliary;
using Newtonsoft.Json;
using Encoding = System.Text.Encoding;

namespace COVID.Dashboard.Buisness.Implementation
{
    public static class FormatingService
    {
        public static byte[] GeJsonBytes<T>(T data)
        {
            var json = JsonConvert.SerializeObject(data);
            var bytes = Encoding.UTF8.GetBytes(json);
            return bytes;
        }

        public static byte[] GetCvsBytes<T>(T data) where T : Dictionary<string, CasesDeathModel>
        {
            var dictionary = data;
            var csv = string.Join(Environment.NewLine, dictionary.Select(d => $"{d.Key},{d.Value.Cases},{d.Value.Deaths}"));
            var bytes = Encoding.UTF8.GetBytes(csv);
            return bytes;
        }

        public static byte[] GetXmlBytes<T>(T data, string rootName) where T : Dictionary<string, CasesDeathModel>
        {
            var xmlRoot = new XElement(rootName);
            foreach (var item in data)
            {
                var xmlParentNode = new XElement(Regex.Replace(item.Key, @"\s+", ""));
                var xmlCasesNode = new XElement("Cases", item.Value.Cases);
                var xmlDeathNode = new XElement("Deaths", item.Value.Deaths);

                xmlParentNode.Add(xmlCasesNode);
                xmlParentNode.Add(xmlDeathNode);
                xmlRoot.Add(xmlParentNode);
            }

            var xml = new XDocument(xmlRoot);

            return Encoding.UTF8.GetBytes(xml.ToString());
        }
    }
}
