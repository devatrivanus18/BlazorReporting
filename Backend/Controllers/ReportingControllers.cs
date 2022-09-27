using DevExpress.AspNetCore.Reporting.QueryBuilder;
using DevExpress.AspNetCore.Reporting.QueryBuilder.Native.Services;
using DevExpress.AspNetCore.Reporting.ReportDesigner;
using DevExpress.AspNetCore.Reporting.ReportDesigner.Native.Services;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer.Native.Services;
using DevExpress.XtraReports.Web.ReportDesigner;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers {
    // ...
    public class CustomWebDocumentViewerController : WebDocumentViewerController {
        public CustomWebDocumentViewerController(IWebDocumentViewerMvcControllerService controllerService) : base(controllerService) {
        }
    }

    public class CustomReportDesignerController : ReportDesignerController {
        public CustomReportDesignerController(IReportDesignerMvcControllerService controllerService) : base(controllerService) {
        }

        [HttpPost("GetReportDesignerModel")]
        public IActionResult GetReportDesignerModel(
            [FromForm] string reportUrl,
            [FromServices] IReportDesignerClientSideModelGenerator reportDesignerClientSideModelGenerator) {

            string modelJsonScript =
                reportDesignerClientSideModelGenerator
                .GetJsonModelScript(
                    // The name of a report (reportUrl)
                    // that the Report Designer opens when the application starts.
                    reportUrl,
                    // Data sources for the Report Designer.                
                    null,
                    // The URI path of the default controller
                    // that processes requests from the Report Designer.
                    DevExpress.AspNetCore.Reporting.ReportDesigner.ReportDesignerController.DefaultUri,
                    // The URI path of the default controller
                    // that processes requests from the Web Document Viewer.
                    DevExpress.AspNetCore.Reporting.WebDocumentViewer.WebDocumentViewerController.DefaultUri,
                    // The URI path of the default controller
                    // that processes requests from the Query Builder.
                    DevExpress.AspNetCore.Reporting.QueryBuilder.QueryBuilderController.DefaultUri
                );
            return Content(modelJsonScript, "application/json");
        }

        public class CustomQueryBuilderController : QueryBuilderController {
            public CustomQueryBuilderController(IQueryBuilderMvcControllerService controllerService) : base(controllerService) {
            }
        }
    }
}
