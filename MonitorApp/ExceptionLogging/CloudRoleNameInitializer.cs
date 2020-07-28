using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLogging
{
   public class CloudRoleNameInitializer : ITelemetryInitializer
    {
        private readonly string _roleName;

        public CloudRoleNameInitializer(string Name)
        {
            _roleName = Name;
        }

        public void Initialize(Microsoft.ApplicationInsights.Channel.ITelemetry telemetry)
        {
            var requestTelemetry = telemetry as RequestTelemetry;
            if (requestTelemetry == null) return;

            requestTelemetry.Properties.Add("TestException", "TestProject");

            telemetry.Context.Cloud.RoleInstance = _roleName;
            telemetry.Context.Cloud.RoleName = "Test Role";
        }
    }
}
