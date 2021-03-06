﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Knit
{
    public class StepExecuteProgram : Step
    {
        // Properties
        [XmlAttribute("executable")]
        public string Executable { get; set; } = string.Empty;

        [XmlElement("arguments")]
        public string Arguments { get; set; } = string.Empty;

        [XmlElement("percentageRegex")]
        public string PercentageRegex { get; set; } = string.Empty;

        [XmlAttribute("startMessage")]
        public string StartMessage { get; set; } = string.Empty;

        [XmlAttribute("endMessage")]
        public string EndMessage { get; set; } = string.Empty;

        [XmlAttribute("errorMessage")]
        public string ErrorMessage { get; set; } = string.Empty;

        [XmlAttribute("outDirectory")]
        public string OutDirectory { get; set; } = string.Empty;

        [XmlArray("stop-on-text")]
        [XmlArrayItem("text")]
        public List<string> StopOnText { get; set; } = new List<string>();

        [XmlAttribute("stopOnStdErr")]
        public bool StopOnStdErr { get; set; } = true;

        // Methods
        public override async Task<StepResults> Perform(Dictionary<string, object> variableCache, IProgress<ProgressReport> progress)
        {
            var progressReport = new ProgressReport();
            var stepResults = new StepResults { Status = StepStatus.Success };

            progress.Report(new ProgressReport { Message = Common.ProcessVariableTokens(StartMessage, variableCache), NewLine = false });
            var arguments = Common.ProcessVariableTokens(Arguments, variableCache);
            var error = false;

            var startInfo = new ProcessStartInfo()
            {
                FileName = Path.Combine(WorkingDirectory, Executable),
                WorkingDirectory = WorkingDirectory,
                Arguments = arguments
            };

            var rpa = new RunProcessAsync();
            rpa.OutputDataReceived += (sender, e) =>
            {
                var dr = (DataReceivedEventArgs)e;
                if (dr.Data == null) return;

                if (PercentageRegex != string.Empty)
                {
                    double.TryParse(Regex.Match(dr.Data, PercentageRegex, RegexOptions.IgnoreCase).Value, out var percentage);
                    progress.Report(new ProgressReport { Message = string.Empty, Percentage = percentage / Weight * 100 });
                }
                else
                    progress.Report(new ProgressReport { Message = dr.Data });

                foreach (var sot in StopOnText)
                    if (!string.IsNullOrWhiteSpace(sot) && dr.Data.Contains(sot))
                        error = true;
            };

            rpa.ErrorDataReceived += (sender, e) =>
            {
                var dr = (DataReceivedEventArgs)e;
                if (dr.Data == null) return;

                if (StopOnStdErr)
                    error = true;
                foreach (var sot in StopOnText)
                    if (!string.IsNullOrWhiteSpace(sot) && dr.Data.Contains(sot))
                        error = true;

                progress.Report(new ProgressReport { Message = dr.Data });
            };

            rpa.Exited += (sender, args) =>
            {
                progress.Report(new ProgressReport { Message = Common.ProcessVariableTokens(!error ? EndMessage : ErrorMessage, variableCache) });
            };

            if (OutDirectory != string.Empty && !Directory.Exists(Common.ProcessVariableTokens(OutDirectory, variableCache)))
                Directory.CreateDirectory(Common.ProcessVariableTokens(OutDirectory, variableCache));

            await rpa.StartAsync(startInfo);

            if (!error)
                progressReport.Percentage = Weight;
            else
                stepResults.Status = StepStatus.Failure;

            progress.Report(progressReport);
            return stepResults;
        }
    }
}
