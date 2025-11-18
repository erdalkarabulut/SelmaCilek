var kullanici = {
    Ekle: function (menuTag, url) {
        LoadingPanel.Show();
        $.ajax({
            type: "POST",
            url: url,
            data: { menuTag: menuTag },
            success: function (response) {
                var pc = ASPxClientControl.GetControlCollection().GetByName('pageControlKullanici');
                pc.SetActiveTab(pc.GetTabByName('Tab2'));
                $("#editableContainer").html(response);
            }
        }).always(function () {
            LoadingPanel.Hide();
        });
    },
    Degistir: function (gridName, menuTag, url) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var selectedRow = grid.GetSelectedKeysOnPage();
        if (selectedRow.length > 0) {
            LoadingPanel.Show();
            $.ajax({
                type: "POST",
                url: url,
                data: {
                    Id: selectedRow[0],
                    menuTag: menuTag
                },
                success: function (response) {
                    var pc = ASPxClientControl.GetControlCollection().GetByName('pageControlKullanici');
                    pc.SetActiveTab(pc.GetTabByName('Tab2'));
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
    FormKullaniciKaydet: function (menuTag, url) {
        var formList = [];
        formList.push("formKullaniciEkle");
        var model = {};
        var grid = ASPxClientControl.GetControlCollection().GetByName('gridKullanici');
        model = bpsMain.getFormModel(formList, model);
        LoadingPanel.Show();
        $.ajax({
            url: url,
            type: 'POST',
            dataType: 'JSON',
            data: {
                model: model,
                menuTag: menuTag,
                imagePath: $("#imagePath").val()
            },
            success: function (response, result) {
                BpsAlert.alertResponse(response);
                if (response.Status === 0) {
                    grid.Refresh();
                    var pc = ASPxClientControl.GetControlCollection().GetByName('pageControlKullanici');
                    pc.SetActiveTab(pc.GetTabByName('Tab1'));
                }
            }
        }).always(function () {
            LoadingPanel.Hide();
        });
    },
    FormKullaniciIptal: function () {
        var pc = ASPxClientControl.GetControlCollection().GetByName('pageControlKullanici');
        pc.SetActiveTab(pc.GetTabByName('Tab1'));
    }
}