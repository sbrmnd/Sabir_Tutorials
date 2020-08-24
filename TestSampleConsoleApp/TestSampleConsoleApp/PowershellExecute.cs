using System;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace TestSampleConsoleApp
{
    public class PowershellExecute
    {
        public enum AuthenticationScheme
        {
            Basic = 0,
            Modern = 1
        }
        private Runspace runspace;

        public void Run(string command, Dictionary<string, object> parameters)
        {
            if (parameters != null)
            {
                var res = Execute(command, parameters);
            }
            else
            {
                var val = "trua";

                if(bool.Parse(val.ToUpper()))
                {
                    bool v = bool.Parse(val);
                }
                var results = ExecuteScript(command);
                List<string> Module = new List<string>();
                foreach(var result in results)
                {
                    Module.Add(result.ToString());
                }

                if(Module.Count > 0)
                {

                }
            }
        }

        public PowershellExecute()
        {
            runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
        }
        ~PowershellExecute()
        {
            runspace.Close();
            runspace.Dispose();
        }

        private Collection<PSObject> ExecuteScript(string command)
        {
            try
            {
                //using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    //runspace.Open();
                    using (var pipeline = runspace.CreatePipeline())
                    {
                        pipeline.Commands.AddScript(command);

                        var psResults = pipeline.Invoke();


                        if (pipeline.Error != null && pipeline.Error.Count > 0)
                        {
                            //LogPSError(pipeline);
                        }
                        return psResults;
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private Collection<PSObject> Execute(string command, Dictionary<string, object> parameters)
        {
            string logStr = "";
            var psCommand = new Command(command);
            if (parameters != null)
            {
                foreach (var par in parameters)
                {
                    if (!string.IsNullOrEmpty(logStr))
                    {
                        logStr += ",";
                    }
                    logStr += par.Key;
                    //if (log.IsDebugEnabled)
                    {
                       // if (!par.Key.Contains("pass"))
                        {
                       //     logStr += string.Format(":({0})", ValueDumper.ToLogString(par.Value));
                        }
                    }
                    psCommand.Parameters.Add(par.Key, par.Value);
                }
            }

            //log.Debug("[PoSh Execute: {0}({1})", command, logStr);

            try
            {
                using (var pipeline = runspace.CreatePipeline())
                {
                    pipeline.Commands.Add(psCommand);
                    var psResults = pipeline.Invoke();

                   // log.Debug(".PoSh Execute: {0}({1}) returns {2} objects.", command, logStr, psResults.Count);

                    if (pipeline.Error != null)
                    {
                        if (pipeline.Error.Count > 0)
                        {
                            // HACK: Workaround .ReadToEnd(), which doesn't work for remote runspaces
                            // var errors = pipeline.Error.ReadToEnd();
                            var errors = new List<object>();
                            while (pipeline.Error.Count > 0)
                            {
                                errors.Add(pipeline.Error.Read());
                            }

                            // logging all errors
                            foreach (var err in errors)
                            {
                               // log.Error(err.ToString());
                            }
                            // Take the last error only
                            string errMessage = errors[0].ToString();
                            PSObject errPSObj = errors[0] as PSObject;
                            if (errPSObj != null)
                            {
                                ErrorRecord errRecord = errPSObj.BaseObject as ErrorRecord;
                                if (errRecord != null)
                                {
                                   // log.Error(errRecord.ToString());
                                    if (!string.IsNullOrWhiteSpace(errMessage))
                                    {
                                        //log.Error(errMessage);
                                    }

                                    throw new Exception("errRecord");
                                }
                            }
                            //log.Error(errMessage);
                            throw new Exception("errMessage");
                        }
                    }

                   // log.Debug("]PoSh Execute finished: {0}", command);
                    return psResults;
                }
            }
            catch (Exception e)
            {
                //string paramString = parameters == null ? "" : string.Join(", ", parameters.Select(par =>
                    //    string.Format("{0}:{1}", par.Key, par.Key.Contains("pass") ? "***" : ValueDumper.ToLogString(par.Value))));

                //log.Error("PoSh Execute failed: {0}({1}) - {2}. {3}", command, paramString, e.Message, Environment.NewLine + new StackTrace(1, true));

                throw;
            }
        }
    }
}
