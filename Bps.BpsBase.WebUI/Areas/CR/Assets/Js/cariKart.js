var cariKart = {
    Ekle: function (menuTag, url, cmbName, pcName) {
        var comboBox = ASPxClientControl.GetControlCollection().GetByName(cmbName);
        var pc = ASPxClientControl.GetControlCollection().GetByName(pcName);
        LoadingPanel.Show();
        $.ajax({
            type: "POST",
            url: url,
            data: {
                menuTag: menuTag,
                value: comboBox.GetValue()
            },
            success: function (response) {
                pc.SetActiveTabIndex(2);
                $("#editableContainer").html(response);
            }
        }).always(function () {
            LoadingPanel.Hide();
        });
    },
    Degistir: function (gridName, menuTag, url, cmbName, pcName) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var comboBox = ASPxClientControl.GetControlCollection().GetByName(cmbName);
        var pc = ASPxClientControl.GetControlCollection().GetByName(pcName);
        var selectedRow = grid.GetSelectedKeysOnPage();
        if (selectedRow.length > 0) {
            LoadingPanel.Show();
            $.ajax({
                type: "POST",
                url: url,
                data: {
                    Id: selectedRow[0],
                    menuTag: menuTag,
                    value: comboBox.GetValue()
                },
                success: function (response) {
                    pc.SetActiveTabIndex(2);
                    $("#editableContainer").html(response);
                }
            }).always(function () {
                LoadingPanel.Hide();
            });
        } else {
            BpsAlert.warning('Lütfen kayıt seçiniz !');
            return;
        }
    },
    CariKartAra: function (menuTag) {
        var gridCariKart = ASPxClientControl.GetControlCollection().GetByName('gridCariKart');
        var cariTipKod = cmb_CariKart_Tip.GetValue();
        if (cariTipKod == "" || cariTipKod == null) {
            BpsAlert.warning('Lütfen cari tipi seçiniz!');
            return;
        }
        gridCariKart.PerformCallback({
            menuTag: menuTag,
            cariTipKod: cariTipKod
        });
        pageControlCariKart.SetActiveTabIndex(1);
    },
    FormCariKartKaydet: function (menuTag, url) {
        var formList = [];
        formList.push('formCariKart');
        var genelModel = {};
        genelModel.CariKart = {};
        var model = {};
        var gridCariKart = ASPxClientControl.GetControlCollection().GetByName('gridCariKart');

        genelModel = bpsMain.getFormMultiModel(formList, genelModel);

        LoadingPanel.Show();
        $.ajax({
            url: url,
            type: 'POST',
            dataType: 'JSON',
            data: {
                model: genelModel,
                menuTag: menuTag
            },
            success: function (response, result) {
                BpsAlert.alertResponse(response);
                if (response.Status === 0) {
                    gridCariKart.Refresh();
                    pageControlCariKart.SetActiveTabIndex(1);
                }
                return;
            }
        }).always(function () {
            LoadingPanel.Hide();
        });
    }

}

var cariAdres= {
    CariAdresAra: function (menuTag) {
        var gridCariKart = ASPxClientControl.GetControlCollection().GetByName('gridCariAdres');
        var cariKartKod = cmbCariAdres_CariKart.GetValue();
        if (cariKartKod == "" || cariKartKod == null) {
            BpsAlert.warning('Lütfen Cari Kart seçiniz!');
            return;
        }
        gridCariKart.PerformCallback({
            menuTag: menuTag,
            cariKartKod: cariKartKod
        });
        pageControlCariAdres.SetActiveTabIndex(1);
    },
    FormCariAdresKaydet: function (menuTag, url) {
        var formList = [];
        formList.push('formCariAdres');
        var model = {};
        var gridCariAdres = ASPxClientControl.GetControlCollection().GetByName('gridCariAdres');

        model = bpsMain.getFormModel(formList, model);
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
                    gridCariAdres.Refresh();
                    pageControlCariAdres.SetActiveTabIndex(1);
                }
                return;
            }
        }).always(function () {
            LoadingPanel.Hide();
        });
    }
}