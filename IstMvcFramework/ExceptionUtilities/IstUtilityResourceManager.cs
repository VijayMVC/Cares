using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Linq;

namespace IstMvcFramework.ExceptionUtilities
{
    public class IstUtilityResourceManager
    {

        private XmlReader Reader;
        private string SectionName;
        private string ModuleName;
        public string GetConfigMessage(string ModuleName)
        {
            return string.Empty;
        }

        public IstUtilityResourceManager(string ModuleName)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            this.ModuleName = ModuleName;
            Reader = XmlReader.Create(HostingEnvironment.MapPath("~/Resources/" + ModuleName + ".xml"), settings);
            // string test  =  ConfigurationManager.AppSettings.Get("CaresUser");
        }

        //Function will take key name as parameter and will return Error message
        public string GetValueByKey(string key)
        {
            bool foundElement = false;
            try
            {
                while (Reader.Read())
                {
                    switch (Reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (Reader.Name == key)
                                foundElement = true;
                            break;
                        case XmlNodeType.Text:
                            string message = string.Empty;
                            if (foundElement == true)
                            {
                                message = Reader.Value;
                                Reader.Close();
                                return message;
                            }
                            break;
                    }
                }
                Reader.Close();
                throw new Exception("Key Not found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Tag> IstUtilityTagReader()
        {

            try
            {
                IEnumerable<XElement> xElements = XDocument.Load(HostingEnvironment.MapPath("~/Resources/" + ModuleName + ".xml")).Root.Elements("TemplateTag");
                List<Tag> employeeList =
                (
                    from e in xElements
                    select new Tag
                    {
                        StatusId = (int)e.Element("ID"),
                        Key = (int)e.Element("TemplateKey"),
                        Name = (string)e.Element("TemplateValue")
                    }).ToList();
                return employeeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Reader.Close();
            }
        }
    }
}