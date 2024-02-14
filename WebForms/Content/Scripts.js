/// <reference path="jquery.min.js"/>
(function() {
    window.updateRatingLabels = function(ratingControl) {
        var prefix = ratingControl.cpLabelPrefix || "";
        if (ratingControl.cpLeftLabelID) {
            $("#" + ratingControl.cpLeftLabelID).html(prefix + ratingControl.GetPositionStart());
            $("#" + ratingControl.cpRightLabelID).html(prefix + ratingControl.GetPositionEnd());
        }
        else
            $("#" + ratingControl.cpRightLabelID).html(prefix + ratingControl.GetPosition());
    };
    window.onRoomsNavBarExpandedChanged = function(s, e) {
	    ASPxClientControl.GetControlCollection().AdjustControls(s.GetMainElement());
	};
    window.onRoomImageNavItemClick = function(roomID, pictureName) {
        setTimeout(function() {
            ImagePopupControl.PerformCallback(roomID + "|" + pictureName);
            ImagePopupControl.ShowAtElementByID("MainCallbackPanel_ContentPane");
        }, 500);
    };
    window.closeWidget = function(index) {
        var panel = window["dpw" + index];
        panel.Hide();
        if(!dpw1.IsVisible() && !dpw2.IsVisible() && !dpw3.IsVisible())
            $(".widgets").addClass("hide-panel");
    };
    window.onDataViewEndCallback = function(s, e) {
        $('html, body').animate({
            scrollTop: $(s.GetMainElement()).offset().top
        }, 300);
    };
    window.onInvoiceButtonClick = function(s, e) {
        ReportPopupControl.Show();
    };
    Date.prototype.addDays = function(days) {
        var dat = new Date(this.valueOf());
        dat.setDate(dat.getDate() + days);
        return dat;
    }
})();