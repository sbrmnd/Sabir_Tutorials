using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml;
using System.IO;

namespace TestSampleConsoleApp
{
    public class XmlOperations
    {
        private XmlDocument xmlDoc;
        private string generatedTemplatePath;

        public XmlOperations(string templateFilePath, string AzureTentantTemplate)
        {
            generatedTemplatePath = AzureTentantTemplate;
            xmlDoc = new XmlDocument();

            xmlDoc.Load(templateFilePath);

            if(File.Exists(AzureTentantTemplate))
            {
                File.Delete(AzureTentantTemplate);
            }
            xmlDoc.Save(AzureTentantTemplate);
            //Load the new tanent template.
            xmlDoc.Load(AzureTentantTemplate);

        }
        ~XmlOperations()
        {
            if (File.Exists(generatedTemplatePath))
            {
                File.Delete(generatedTemplatePath);
            }

        }

        public void UpdateWorkFlowName(string workFlowid, string tempFilePath)
        {
            xmlDoc.SelectSingleNode("Workflow").Attributes["Name"].Value = xmlDoc.SelectSingleNode("Workflow").Attributes["Name"].Value + "_" + workFlowid;
            xmlDoc.Save(tempFilePath);
        }
        public void UpdateWorkflowSteps(string AzureDomainName, string tempFilePath)
        {

            string xpath = $"Workflow/Steps/Step";
            XmlNodeList steps = xmlDoc.SelectNodes(xpath);
            foreach (XmlNode step in steps)
            {
                string stepName = step.Attributes["Name"].Value  + "_" + AzureDomainName;
                step.Attributes["Name"].Value = stepName;
            }
            xmlDoc.Save(tempFilePath);
        }
        public void UpdateConnectionName(string AzureDomainName, string tempFilePath)
        {
            string xpath = $"Workflow/Connections/Connection";
            XmlNodeList connections = xmlDoc.SelectNodes(xpath);

            foreach (XmlNode connection in connections)
            {
                string stepName = connection.Attributes["Name"].Value + "_" + AzureDomainName;
                connection.Attributes["Name"].Value = stepName; 
            }
            xmlDoc.Save(tempFilePath);
        }

    }
}
