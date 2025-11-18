var doviz = {
    DovizKaydet: function (menuTag, gridName, url, _formList, pcName, tabIndex, manual) {
        var model = {};
        var formList = _formList.toString().split(',');
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);

        model = bpsMain.getFormModel(formList, model);
        model.MANUEL = manual;

        LoadingPanel.Show();
        $.ajax({
            url: url,
            type: 'POST',
            dataType: 'JSON',
            data: {
                model: model,
                menuTag: menuTag
            },
            success: function (response, result) {
                BpsAlert.alertResponse(response);
                if (response.Status === 0) {
                    grid.Refresh();
                    var pc = ASPxClientControl.GetControlCollection().GetByName(pcName);
                    pc.SetActiveTabIndex(tabIndex);
                }
            }
        }).always(function () {
            LoadingPanel.Hide();
        });
    }
}