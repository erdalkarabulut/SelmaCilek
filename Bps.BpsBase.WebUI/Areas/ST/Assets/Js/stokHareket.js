var stokHareket = {
    StokHareketAra: function (menuTag) {
        var gridStokHareket = ASPxClientControl.GetControlCollection().GetByName('gridStokHareket');
        var fisTip = cmb_StokKartHrk_FisTip.GetValue();
        if (fisTip == "" || fisTip == null) {
            BpsAlert.warning('Lütfen fiş tipi seçiniz!');
            return;
        }
        gridStokHareket.PerformCallback({
            menuTag: menuTag,
            fisTipNo: fisTip
        });
        pageControlStokHareket.SetActiveTabIndex(1);
    },
    Ekle: function (menuTag, url) {
        var cmbStokKartHrkFisTip = cmb_StokKartHrk_FisTip;
        LoadingPanel.Show();
        $.ajax({
            type: "POST",
            url: url,
            data: {
                menuTag: menuTag,
                fisTipNo: cmbStokKartHrkFisTip.GetValue()
            },
            success: function (response) {
                pageControlStokHareket.SetActiveTabIndex(2);
                $("#editableContainer").html(response);
            }
        }).always(function () {
            LoadingPanel.Hide();
        });
    },
    FormStokHareketIptal: function () {
        pageControlStokHareket.SetActiveTabIndex(1);
    },
}