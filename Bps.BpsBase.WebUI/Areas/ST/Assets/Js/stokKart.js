var stokKart = {
    Ekle: function (menuTag, url) {
        var cmbMalTur = cmb_StokKart_MalTur;
        var sekmeKod = cmbMalTur.GetItem(cmbMalTur.GetSelectedIndex()).texts[2];
        LoadingPanel.Show();
        $.ajax({
            type: "POST",
            url: url,
            data: {
                menuTag: menuTag,
                sekmeKod: sekmeKod,
                malTur: cmbMalTur.GetValue()
            },
            success: function (response) {
                pageControlStokKart.SetActiveTab(pageControlStokKart.GetTabByName('stokKartTab3'));
                $("#editableContainer").html(response);
            }
        }).always(function () {
            LoadingPanel.Hide();
        });
    },
    Degistir: function(gridName, menuTag, url) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var cmbMalTur = cmb_StokKart_MalTur;
        var sekmeKod = cmbMalTur.GetItem(cmbMalTur.GetSelectedIndex()).texts[2];
        var selectedRow = grid.GetSelectedKeysOnPage();
        if (selectedRow.length > 0) {
            LoadingPanel.Show();
            $.ajax({
                type: "POST",
                url: url,
                data: {
                    Id: selectedRow[0],
                    menuTag: menuTag,
                    sekmeKod:sekmeKod,
                    malTur: cmbMalTur.GetValue()
                },
                success: function(response) {
                    pageControlStokKart.SetActiveTab(pageControlStokKart.GetTabByName('stokKartTab3'));
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
    FormStokKartKaydet: function (menuTag, url) {
        var formList = [];
        formList.push({
            'formName':"formGv",
            'Sekme':'A'
        });
        //formList.push({
        //    'formName':"formStokDepo",
        //    'Sekme':'H'
        //});
        var genelModel = {};
        var model = {};
                
        genelModel.StokKart={};
        genelModel.SatinAlmaDegerAnahtar={};
        genelModel.Stname="";
        var grid = ASPxClientControl.GetControlCollection().GetByName('gridStokKart');
        var gridStDilTanim = ASPxClientControl.GetControlCollection().GetByName('gridStDilTanim');
        var gridStDepo = ASPxClientControl.GetControlCollection().GetByName('gridStDepo');
        var gridStMuhasebe = ASPxClientControl.GetControlCollection().GetByName('gridStMuhasebe');
        var gridStSale = ASPxClientControl.GetControlCollection().GetByName('gridStSale');
        formList.forEach(function (formId) {
            var formName = formId.formName;
            var sekme = formId.Sekme;
            var modelName = "";
            var form = ASPxClientControl.GetControlCollection().GetByName(formName);
            form.rootItem.items.forEach(function (item) {
                item.items.forEach(function (data) {
                    if (data.name != null && data.name != "") {
                        var splitedData = data.name.split('.');
                        modelName = splitedData[0];
                        var fieldName = splitedData[1];
                        var fieldNameWithSekme = fieldName + "_" + sekme;
                        var control = ASPxClientControl.GetControlCollection().GetByName(fieldNameWithSekme);

                        if (control instanceof ASPxClientDateEdit) {
                            if (control.GetValue() == null) {
                                eval("genelModel." + modelName + "['" + fieldName + "'] = null;");
                            } else {
                                eval("genelModel." + modelName + "['" + fieldName + "'] = control.GetValue().toLocaleDateString();");
                            }
                        } else {
                            eval("genelModel." + modelName + "['" + fieldName + "'] = control.GetValueString();");
                        }

                    }
                });
            });
        });
        if(gridStDilTanim.GetVisibleRowsOnPage() < 1){
            BpsAlert.error('Lütfen stok dil tanımı giriniz!');
            return;
        }
        if (gridStDilTanim.batchEditApi.HasChanges()) {
            if (!gridStDilTanim.batchEditApi.ValidateRows()) {
                BpsAlert.error('Dil Tanımlama bölümündeki alanları kontrol ediniz!');
                return;
            }
            var updatedValues = batchEditing.GetValues('gridStDilTanim');
            genelModel.DilUpdateValues = updatedValues;
        }

        if (gridStDepo.batchEditApi.HasChanges()) {
            if (!gridStDepo.batchEditApi.ValidateRows()) {
                BpsAlert.error('Depo Tanımlama bölümündeki alanları kontrol ediniz!');
                return;
            }
            var stokDepoUpdatedValues = batchEditing.GetValues('gridStDepo');
            genelModel.StokDepoUpdateValues = stokDepoUpdatedValues;
        }

        if (gridStMuhasebe.batchEditApi.HasChanges()) {
            if (!gridStMuhasebe.batchEditApi.ValidateRows()) {
                BpsAlert.error('Muhasebe Tanımlama bölümündeki alanları kontrol ediniz!');
                return;
            }
            var stokMuhasebeUpdatedValues = batchEditing.GetValues('gridStMuhasebe');
            genelModel.StokMuhasebeUpdateValues = stokMuhasebeUpdatedValues;
        }

        if (gridStSale.batchEditApi.HasChanges()) {
            if (!gridStSale.batchEditApi.ValidateRows()) {
                BpsAlert.error('Satış bölümündeki alanları kontrol ediniz!');
                return;
            }
            var stokSaleUpdatedValues = batchEditing.GetValues('gridStSale');
            genelModel.StokSatisUpdateValues = stokSaleUpdatedValues;
        }

        LoadingPanel.Show();
        $.ajax({
            url: url,
            type: 'POST',
            dataType: 'JSON',
            data: {
                model: genelModel,
                menuTag: menuTag
            },
            success: function(response, result) {
                BpsAlert.alertResponse(response);
                if (response.Status === 0) {
                    grid.Refresh();
                    pageControlStokKart.SetActiveTabIndex(1);
                }
                return;
            }
        }).always(function () {
            LoadingPanel.Hide();
        });
    },
    FormStokKartIptal: function () {
        pageControlStokKart.SetActiveTabIndex(1);
    },
    StokKartAra : function (menuTag) {
        var gridYetki = ASPxClientControl.GetControlCollection().GetByName('gridStokKart');
        
        var malzemeTur = cmb_StokKart_MalTur.GetValue();
        if (malzemeTur == "" || malzemeTur == null) {
            BpsAlert.warning('Lütfen malzeme türü seçiniz!');
            return;
        }
        gridYetki.PerformCallback({
            menuTag: menuTag,
            malzemeTur: malzemeTur
        });
        pageControlStokKart.SetActiveTabIndex(1);
    },
    ActiveTabChanged: function (s, e) {
        //if (e.tab.name == "stokKartTab2") {
        //    pageControlStokKart.GetTabByName('stokKartTab1').SetVisible(1);
        //    pageControlStokKart.GetTabByName('stokKartTab3').SetVisible(0);
        //}
    }
}