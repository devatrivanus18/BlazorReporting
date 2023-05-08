var ko = require('knockout');
require('devexpress-reporting/dx-reportdesigner');
import "./style.css";

window.JsFunctions = {
    _viewerOptions: {
        reportUrl: ko.observable("CobaReport"),
        requestOptions: {
            host: "https://localhost:7261",
            invokeAction: "/DXXRDV"
        }
    },
    _designerOptions: {        
        reportUrl: ko.observable("CobaReport"),
        requestOptions: {
            host: "https://localhost:7261",
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


