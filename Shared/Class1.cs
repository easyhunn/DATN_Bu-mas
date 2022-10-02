using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System;

namespace Shared
{
    public class Class1
    {
        public void GetReport()

        {

            StiReport report = new StiReport();

            report.Load("Reports/SimpleList.mrt");

            //report.Load(StiNetCoreHelper.MapPath(this, "Reports/Dashboard.mrt"));

            report.Design();

        }

    }
}
