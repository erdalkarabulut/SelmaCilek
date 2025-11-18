var takvim = {
    Ekle: function (menuTag, url) {
        $.ajax({
            type: "POST",
            url: url,
            data: { menuTag: menuTag },
            success: function (response) {
                var pc = ASPxClientControl.GetControlCollection().GetByName('pageControlTakvim');
                pc.GetTabByName('Tab1').SetVisible(0);
                pc.GetTabByName('Tab2').SetVisible(1);
                pc.SetActiveTab(pc.GetTabByName('Tab2'));
                $("#editableContainer").html(response);
            }
        });
    },
    Degistir: function (gridName, menuTag, url) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var selectedRow = grid.GetSelectedKeysOnPage();
        if (selectedRow.length > 0) {
            $.ajax({
                type: "POST",
                url: url,
                data: {
                    Id: selectedRow[0],
                    menuTag: menuTag
                },
                success: function (response) {
                    var pc = ASPxClientControl.GetControlCollection().GetByName('pageControlTakvim');
                    pc.GetTabByName('Tab1').SetVisible(0);
                    pc.GetTabByName('Tab2').SetVisible(1);
                    pc.SetActiveTab(pc.GetTabByName('Tab2'));
                    $("#editableContainer").html(response);
                }
            });
        } else {
            cilekAlert.warning('Lütfen kayıt seçiniz !');
            return;
        }
    },
    FormTakvimKaydet: function (menuTag, url) {
        var formList = [];
        formList.push("formTakvim_Temel");

        var genelModel = {};
        genelModel.Takvim = {};
        genelModel.Kisitlamalar = [];
        genelModel.UpdateValues = [];
        var gridKisitlama = ASPxClientControl.GetControlCollection().GetByName('gridKisitlama');

        if (gridKisitlama.batchEditApi.HasChanges()) {
            if (!gridKisitlama.batchEditApi.ValidateRows()) {
                cilekAlert.error('Kısıtlama bölümündeki alanları kontrol ediniz!');
                return;
            }
            var updatedValues = batchEditing.GetValues('gridKisitlama');
            genelModel.UpdateValues = updatedValues;
        }
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
                cilekAlert.alertResponse(response);
                if (response.Status === 0) {
                    window.location.reload();
                }
            }
        }).always(function () {
            LoadingPanel.Hide();
        });
    },
    FormTakvimIptal: function () {
        var pc = ASPxClientControl.GetControlCollection().GetByName('pageControlTakvim');
        pc.GetTabByName('Tab1').SetVisible(1);
        pc.GetTabByName('Tab2').SetVisible(0);
    }
}