var personel = {
    Ekle: function (menuTag, url) {
        $.ajax({
            type: "POST",
            url: url,
            data: { menuTag: menuTag },
            success: function (response) {
                var pc = ASPxClientControl.GetControlCollection().GetByName('pageControlPersonel');
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
                    var pc = ASPxClientControl.GetControlCollection().GetByName('pageControlPersonel');
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
    FormPersonelKaydet: function (menuTag, url) {
        var formList = [];
        formList.push("formPersonel_Temel");
        formList.push("formPersonel_CalismaDurum");
        formList.push("formPersonel_Iletisim");
        var model = {};
        var grid = ASPxClientControl.GetControlCollection().GetByName('gridPersonel');

        model = bpsMain.getFormModel(formList, model);
        $.ajax({
            url: url,
            type: 'POST',
            dataType: 'JSON',
            data: {
                model: model,
                menuTag: menuTag,
                imagePath: $("#imagePath").val(),
                imageName: $("#imageName").val()
            },
            success: function(response, result) {
                cilekAlert.alertResponse(response);
                if (response.Status === 0) {
                    var pc = ASPxClientControl.GetControlCollection().GetByName('pageControlPersonel');
                    grid.Refresh();
                    pc.GetTabByName('Tab1').SetVisible(1);
                    pc.GetTabByName('Tab2').SetVisible(0);
                }
                return;
            }
        });
    },
    FormPersonelIptal: function () {
        var pc = ASPxClientControl.GetControlCollection().GetByName('pageControlPersonel');
        pc.GetTabByName('Tab1').SetVisible(1);
        pc.GetTabByName('Tab2').SetVisible(0);
    }
}