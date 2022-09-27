var ko = require('knockout');
require('devexpress-reporting/dx-reportdesigner');
import "./style.css";

window.JsFunctions = {
    _viewerOptions: {
        reportUrl: ko.observable("SampleReport"),
        requestOptions: {
            host: "http://localhost:5261",
            invokeAction: "/DXXRDV"
        }
    },
    _designerOptions: {        
        reportUrl: ko.observable("SampleReport"),
        requestOptions: {
            host: "http://localhost:5261",
            getDesignerModelAction: "/DXXRD/GetReportDesignerModel"
        }
    },
    InitWebDocumentViewer: function () {
        ko.applyBindings(this._viewerOptions, document.getElementById("viewer"));
    },
    InitReportDesigner: function () {
        ko.applyBindings(this._designerOptions, document.getElementById("designer"));
    },
    Dispose: function (elementId) {
        var element = document.getElementById(elementId);
        element && ko.cleanNode(element);
    }
}


