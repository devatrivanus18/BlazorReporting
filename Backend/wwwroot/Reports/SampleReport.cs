using System;
using DevExpress.XtraReports.UI;

namespace Backend.Reports
{
    public partial class SampleReport
    {
        List<People> peoples;
        public SampleReport()
        {
            InitializeComponent();
            SampleReport report = new SampleReport();
            peoples = new List<People>();
            peoples.Add(new People { Name="Deva Trivanus", Age="25"});
            peoples.Add(new People { Name="Deva Trivanus", Age="25"});
            peoples.Add(new People { Name="Deva Trivanus", Age="25"});
            report.DataSource = peoples;
        }

        protected override void BeforeReportPrint()
        {
            base.BeforeReportPrint();
        }

    }


    public class People
    {
        public string Name { get; set; }= string.Empty;
        public string Age { get; set; }= string.Empty;
    }
}
