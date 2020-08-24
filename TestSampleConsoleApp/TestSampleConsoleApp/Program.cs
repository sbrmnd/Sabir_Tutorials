using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Xml;


namespace TestSampleConsoleApp
{
    class Program
    {
      
       
        static void Main(string[] args)
        {
            string str = "SOSOSOSOSDSDSKWOSDOSDOASDOASDFAFJDFDOSOSOWNSOSOSNDSKDDOSOSOSJDSDSOOSOSDSDOSASSOASDSAOSOSODSDSOASDWS";
           // int length = str.Length;
            int noOfMsg = str.Length / 3;

            List<string> sos = new List<string>();

            int count = 0;
            int n = 3;
            for (int i = 0; i < str.Length; i = i + n)
            {
                sos.Add(str.Substring(i, n));
                //if (!string.Equals("SOS", str.Substring(i, n), StringComparison.OrdinalIgnoreCase))
                //{
                //    count++;
                //}
            }

            Console.WriteLine("Count " + sos.Count());

            //LNode head = null;
            //LinkList lnode = new LinkList();

            //int T = Int32.Parse(Console.ReadLine());
            //while (T-- > 0)
            //{
            //    int data = Int32.Parse(Console.ReadLine());
            //    head = lnode.insert(head, data);
            //}
            //head = lnode.removeDuplicates(head);
            //lnode.display(head);
            //==============================================================
            ////For Binary Tree.
            //Node root = null;
            //BinaryTree tree = new BinaryTree();
            //int T = Int32.Parse(Console.ReadLine());
            //while (T-- > 0)
            //{
            //    int data = Int32.Parse(Console.ReadLine());

            //    root = tree.Insert(root, data);
            //}
            //tree.levelOrder(root);
            //========================================================================================

            //string script = "((Get-ChildItem -Path $($env:LOCALAPPDATA+\"\\Apps\\2.0\\\") -Filter CreateExoPSSession.ps1 -Recurse ).FullName | Select-Object -Last 1) ";
            //PowershellExecute powershellExecute = new PowershellExecute();

            //powershellExecute.Run(script, null);

            //FileOperation fileOperation = new FileOperation("D:\\temp\\", "DeletegatesAndEvents.txt");
            //fileOperation.DisplayWordsCount();
            //string AzureUserName = "DevAdmin@ActiveRoles7dot4Test.onmicrosoft.com";


            // if (AzureUserName.IndexOf('@') != -1)
            //{
            // int position1 = AzureUserName.IndexOf('@');

            //}
            // if (AzureUserName.IndexOf('.') != -1)
            // {
            //  int position2 = AzureUserName.IndexOf('.');
            //}

            // string val = AzureUserName.Substring(position1 + 1,((position2 - position1)-1));

            //string res = new string(AzureUserName.SkipWhile(c => c != '@')
            //               .Skip(1)
            //               .TakeWhile(c => c != '.')
            //               .ToArray()).Trim();


            //string Templatepath = @"D:\Temp\BacksyncAzureAutomationTemplate.xml";
            //string Templatepath_Tenant = @"D:\Temp\BacksyncAzureAutomationTemplate_ActiveRoles7dot4Test.xml";
            //XmlOperations xmlOperations = new XmlOperations(Templatepath, Templatepath_Tenant);

            //xmlOperations.UpdateWorkFlowName("ActiveRoles7dot4Test", Templatepath_Tenant);
            //xmlOperations.UpdateConnectionName("ActiveRoles7dot4Test", Templatepath_Tenant);
            //xmlOperations.UpdateWorkflowSteps("ActiveRoles7dot4Test", Templatepath_Tenant);



            Console.ReadKey();

        }
    }
}
