using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ExceptionLogging
{
    public class LogException
    {
        //private static TelemetryClient telemetryClient;

        //static LogException()
        //{
        //    TelemetryConfiguration.Active.InstrumentationKey = "29502735-045e-4be0-ac49-7e75782e5582";
        //    telemetryClient = new TelemetryClient();
        //}

        //public static void TrackInfo(string message)
        //{
        //    telemetryClient.TrackTrace(message, SeverityLevel.Information);
        //    telemetryClient.Flush();
        //}

        //public static void TrackWarning(string message)
        //{
        //    telemetryClient.TrackTrace(message, SeverityLevel.Warning);
        //    telemetryClient.Flush();
        //}
        //public static void TrackException(Exception exception)
        //{
        //    telemetryClient.TrackException(exception);
        //    telemetryClient.Flush();
        //}

        private static TelemetryClient _telemetryClient;

         public LogException(string RoleName)
        {
            TelemetryConfiguration configuration = TelemetryConfiguration.Active;
            //configuration.InstrumentationKey = "29502735-045e-4be0-ac49-7e75782e5582";

            configuration.InstrumentationKey = "c03887f2-1122-4e53-b8f1-30f6bbd96846";
            
            //configuration.TelemetryInitializers.Add(new CloudRoleNameInitializer());
            QuickPulseTelemetryProcessor processor = null;
            configuration.TelemetryProcessorChainBuilder
              .Use((next) =>
              {
                  processor = new QuickPulseTelemetryProcessor(next);
                  return processor;
              })
              .Build();

            var QuickPulse = new QuickPulseTelemetryModule();
            QuickPulse.Initialize(configuration);
            QuickPulse.RegisterTelemetryProcessor(processor);

            _telemetryClient = new TelemetryClient(configuration);
            _telemetryClient.Context.Cloud.RoleName = RoleName;
            Telemetry = _telemetryClient;
        }
        public static TelemetryClient Telemetry { get; private set; }

        public static void TrackInfo(string message)
        {
            Telemetry.TrackTrace(message, SeverityLevel.Information);
            Telemetry.Flush();
        }

        public static void TrackWarning(string message)
        {
            Telemetry.TrackTrace(message, SeverityLevel.Warning);
            Telemetry.Flush();
        }
        public static void TrackException(Exception exception)
        {
            Telemetry.TrackException(exception);
            Telemetry.Flush();
        }


        public static void SendMetrices(string MetricName, double MetricValue)
        {
            var sample = new MetricTelemetry();
            sample.Name = MetricName;
            sample.Value = MetricValue;
            Telemetry.TrackMetric(sample);
        }

        public static void TrackViewPages(string message,string Url)
        {
            Telemetry.TrackPageView(message);
        }

        //public static void CustumOperation(string OperationName)
        //{
        //    var requestActivity = new Activity("Sample: Function 1 HttpRequest");
        //    requestActivity.Start();

        //    var requestOperation = Telemetry.StartOperation<RequestTelemetry>(requestActivity);

        //    Telemetry.StopOperation(requestOperation);

        //    var dependencyActivity = new Activity("Sample: Function 1 Enqueue");
        //    dependencyActivity.SetParentId(requestActivity.Id);
        //    dependencyActivity.Start();
        //    var dependencyOperation = Telemetry.StartOperation<DependencyTelemetry>(dependencyActivity);
        //    await parentIds.AddAsync(dependencyActivity.Id);

        //    Telemetry.StopOperation(dependencyOperation);
        //}



    }
}
