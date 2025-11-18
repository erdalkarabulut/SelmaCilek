scriptToolbarDev = {
    Ekle: function (divName, popupName, ekleUrl, menuTag) {
        LoadingPanel.Show();
        $.ajax({
            type: "POST",
            url: ekleUrl,
            data: {
                menuTag: menuTag
            },
            success: function (response) {
                $("#" + divName).html(response);
                eval(popupName + '.Show()');
            },
            error: function (response, status) {
                if (response.status == 900) {
                    ppLoginAjax.Show();
                } else {
                    console.log(arguments);
                    BpsAlert.error("Beklenmeyen hata oluştu!");
                }
            }
        }).always(function () {
            LoadingPanel.Hide();
        });
    },
    Degistir: function (divName, gridName, popupName, degistirUrl, menuTag) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var selectedRow = grid.GetSelectedKeysOnPage();
        if (selectedRow.length > 0) {
            LoadingPanel.Show();

            $.ajax({
                type: "POST",
                url: degistirUrl,
                data: {
                    Id: selectedRow[0],
                    menuTag: menuTag
                },
                success: function (response) {
                    $("#" + divName).html(response);
                    eval(popupName + '.Show()');
                },
                error: function (response, status) {
                    if (response.status == 900) {
                        ppLoginAjax.Show();
                    } else {
                        console.log(arguments);
                        BpsAlert.error("Beklenmeyen hata oluştu!");
                    }
                }
            }).always(function () {
                LoadingPanel.Hide();
            });

        } else {
            BpsAlert.warning('Lütfen kayıt seçiniz !');
            return;
        }
    },
    Sil: function (gridName, silUrl, menuTag, silMesajText) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var selectedRow = grid.GetSelectedKeysOnPage();
        if (selectedRow.length > 0) {
            if (silMesajText == null || silMesajText == "") {
                silMesajText = "İlgili kayıdı";
            }
            swal(
                {
                    title: "Emin Misiniz?",
                    text: silMesajText + " silmek istediğinize emin misiniz ?",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Evet !",
                    cancelButtonText: "Hayır !",
                    closeOnConfirm: true,
                    closeOnCancel: true
                },
                function (isConfirm) {
                    if (isConfirm) {
                        LoadingPanel.Show();
                        $.ajax({
                            url: silUrl,
                            type: 'POST',
                            dataType: 'json',
                            data: {
                                Id: selectedRow[0],
                                menuTag: menuTag
                            },
                            success: function (response, result) {
                                BpsAlert.alertResponse(response);
                                if (response.Status === 0) {
                                    grid.Refresh();
                                }
                                return;
                            },
                            error: function (response, status) {
                                if (response.status == 900) {
                                    ppLoginAjax.Show();
                                } else {
                                    console.log(arguments);
                                    BpsAlert.error("Beklenmeyen hata oluştu!");
                                }
                                LoadingPanel.Hide();
                            }
                        }).always(function () {
                            LoadingPanel.Hide();
                        });
                    }
                });
        } else {
            BpsAlert.warning('Lütfen kayıt seçiniz !');
            return;
        }
    },
    YerlesimWindow: function (divName, gridName, popupName, url, menuTag) {
        LoadingPanel.Show();
        $.ajax({
            type: "POST",
            url: url,
            data: {
                menuTag: menuTag,
                gridName: gridName
            },
            success: function (response) {
                $("#" + divName).html(response);
                eval(popupName + '.Show()');
            },
            error: function (response, status) {
                if (response.status == 900) {
                    ppLoginAjax.Show();
                } else {
                    console.log(arguments);
                    BpsAlert.error("Beklenmeyen hata oluştu!");
                }
                LoadingPanel.Hide();
            }
        }).always(function () {
            LoadingPanel.Hide();
        });
    },
    LayoutSave: function (gridName, url) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var gridyout = ASPxClientControl.GetControlCollection().GetByName('gridLayout');
        LoadingPanel.Show();
        $.ajax({
            url: url,
            type: "POST",
            dataType: 'json',
            data: {
                gridName: gridName,
                name: txtYerlesimTextBox.GetValue()
            },
            success: function (response) {
                gridyout.Refresh();
                BpsAlert.alertResponse(response);
            },
            error: function (response, status) {
                if (response.status == 900) {
                    ppLoginAjax.Show();
                } else {
                    console.log(arguments);
                    BpsAlert.error("Beklenmeyen hata oluştu!");
                }
                LoadingPanel.Hide();
            }
        });
        LoadingPanel.Hide();
    },
    LayoutProcess: function (gridName, name, url, type) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var gridyout = ASPxClientControl.GetControlCollection().GetByName('gridLayout');

        LoadingPanel.Show();
        $.ajax({
            url: url,
            type: "POST",
            dataType: 'json',
            data: {
                gridName: gridName,
                name: name,
                type: type
            },
            success: function (response) {
                gridyout.Refresh();
                BpsAlert.alertResponse(response);
            },
            error: function (response, status) {
                if (response.status == 900) {
                    ppLoginAjax.Show();
                } else {
                    console.log(arguments);
                    BpsAlert.error("Beklenmeyen hata oluştu!");
                }
                LoadingPanel.Hide();
            }
        });
        LoadingPanel.Hide();
    },
    BelgeAkisi: function (gridId, divName, type, menuTag, url) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridId);
        var selectedRow = grid.GetSelectedKeysOnPage();
        if (selectedRow.length > 0) {
            LoadingPanel.Show();

            $.ajax({
                type: "POST",
                url: url,
                data: {
                    Id: selectedRow[0],
                    type: type,
                    menuTag: menuTag
                },
                success: function (response) {
                    $("#" + divName).html(response);
                    ppBelgeAkis.Show();
                },
                error: function (response, status) {
                    if (response.status == 900) {
                        ppLoginAjax.Show();
                    } else {
                        console.log(arguments);
                        BpsAlert.error("Beklenmeyen hata oluştu!");
                    }
                    LoadingPanel.Hide();
                }
            }).always(function () {
                LoadingPanel.Hide();
            });
        } else {
            BpsAlert.warning('Lütfen kayıt seçiniz !');
            return;
        }
    },
    GridTopluAktarim: function (gridId, type, url, divName) {
        $.ajax({
            type: "POST",
            url: url,
            data: {
                type: type
            },
            success: function (response) {
                $("#" + divName).html(response);
                ppTopluAktar.Show();
            },
            error: function (response, status) {
                if (response.status == 900) {
                    ppLoginAjax.Show();
                } else {
                    console.log(arguments);
                    BpsAlert.error("Beklenmeyen hata oluştu!");
                }
                LoadingPanel.Hide();
            }
        }).always(function () {
            LoadingPanel.Hide();
        });

    },
    FileUploadComplete: function (response, gridName, errorText) {
        if (response != null) {
            var splitedData = response.split('/');
            var status = splitedData[0];
            if (status == 0) {
                var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
                var popup = ASPxClientControl.GetControlCollection().GetByName('ppTopluAktar');
                popup.Hide();
                grid.Refresh();
                BpsAlert.success('Aktarım başrılı bir şekilde tamamlandı');
            } else if (status == 1) {
                BpsAlert.error(splitedData[1]);
            }
        }
    },
    EkWindow: function (gridName, divName, type, menuTag, url) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var selectedRow = grid.GetSelectedKeysOnPage();
        if (selectedRow.length > 0) {
            LoadingPanel.Show();
            $.ajax({
                type: "POST",
                url: url,
                data: {
                    menuTag: menuTag,
                    tableId: selectedRow[0],
                    tableName: type
                },
                success: function (response) {
                    $("#" + divName).html(response);

                    var popup = ASPxClientControl.GetControlCollection().GetByName("ppEk");
                    popup.Show();
                },
                error: function (response, status) {
                    if (response.status == 900) {
                        ppLoginAjax.Show();
                    } else {
                        console.log(arguments);
                        BpsAlert.error("Beklenmeyen hata oluştu!");
                    }
                    LoadingPanel.Hide();
                }
            }).always(function () {
                LoadingPanel.Hide();
            });
        } else {
            BpsAlert.warning('Lütfen kayıt seçiniz !');
            return;
        }
    },
    FileManagerKaydet: function (s, e, url, tableName, tableId) {
        if (e.commandName == "btnFileManager_Save") {
            LoadingPanel.Show();
            $.ajax({
                url: url,
                type: 'POST',
                dataType: 'JSON',
                data: {
                    tableName: tableName,
                    tableId: tableId
                },
                success: function (response, result) {
                    BpsAlert.alertResponse(response);
                    if (response.Status === 0) {
                        ppEk.Hide();
                    }
                },
                error: function (response, status) {
                    if (response.status == 900) {
                        ppLoginAjax.Show();
                    } else {
                        console.log(arguments);
                        BpsAlert.error("Beklenmeyen hata oluştu!");
                    }
                    LoadingPanel.Hide();
                }
            }).always(function () {
                LoadingPanel.Hide();
            });
        }
    },
    EkleWithTab: function (menuTag, url, pcName, tabIndex) {
        LoadingPanel.Show();
        $.ajax({
            type: "POST",
            url: url,
            data: { menuTag: menuTag },
            success: function (response) {
                var pc = ASPxClientControl.GetControlCollection().GetByName(pcName);
                pc.SetActiveTabIndex(tabIndex);
                $("#editableContainer").html(response);
            },
            error: function (response, status) {
                if (response.status == 900) {
                    ppLoginAjax.Show();
                } else {
                    console.log(arguments);
                    BpsAlert.error("Beklenmeyen hata oluştu!");
                }
                LoadingPanel.Hide();
            }
        }).always(function () {
            LoadingPanel.Hide();
        });
    },
    DegistirWithTab: function (gridName, menuTag, url, pcName, tabIndex) {
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
                    var pc = ASPxClientControl.GetControlCollection().GetByName(pcName);
                    pc.SetActiveTabIndex(tabIndex);
                    $("#editableContainer").html(response);
                },
                error: function (response, status) {
                    if (response.status == 900) {
                        ppLoginAjax.Show();
                    } else {
                        console.log(arguments);
                        BpsAlert.error("Beklenmeyen hata oluştu!");
                    }
                    LoadingPanel.Hide();
                }
            }).always(function () {
                LoadingPanel.Hide();
            });
        } else {
            BpsAlert.warning('Lütfen kayıt seçiniz !');
            return;
        }
    },
    FormKaydetWithTab: function (menuTag, gridName, url, _formList, pcName, tabIndex, multiModel) {
        var model = {};
        var formList = _formList.toString().split(',');
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        if (multiModel == true) {
            model = bpsMain.getFormMultiModel(formList, model);
        } else {
            model = bpsMain.getFormModel(formList, model);
        }
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
    },
    FormIptalWithTab: function (pcName, tabIndex) {
        var pc = ASPxClientControl.GetControlCollection().GetByName(pcName);
        pc.SetActiveTabIndex(tabIndex);
    }
}


var FocusedCellColumnIndex = 0;
var FocusedCellRowIndex = 0;
var FocusedRowKey = 0;
var rowIndex = -222222;
scriptToolbarBatch = {
    Ekle: function (gridName) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        if (grid.batchEditApi.ValidateRows() != false) {
            grid.AddNewRow();
        }
    },
    SelectEditGrid: function (model) {
        var slcGridProperty = model.EditFileds[model.SelectedIndex];
        var grid = ASPxClientControl.GetControlCollection().GetByName(slcGridProperty.SelectionGridName);
        var selectedRow = grid.GetSelectedKeysOnPage();
        if (selectedRow.length > 0) {
            ppEditWindow.Hide();
            var baseGrid = ASPxClientControl.GetControlCollection().GetByName(model.BaseGridName);
            // true kaldırıp dene
            baseGrid.batchEditApi.SetCellValue(model.FocusedCellRowIndex, model.FocusedCellColumnIndex, selectedRow[0], selectedRow[0], true);
        } else {
            BpsAlert.warning('Lütfen seçmek istediğiniz kaydı seçiniz!');
        }
    },
    OnInit: function (s, e, model) {
        ASPxClientUtils.AttachEventToElement(s.GetMainElement(), "keydown", function (evt) {
            var array = s.batchEditApi.GetRowVisibleIndices();
            //if (evt.keyCode === ASPxClientUtils.StringToShortcutCode("UP"))
            //    scriptToolbarBatch.UpPressed(s);
            //else if (evt.keyCode === ASPxClientUtils.StringToShortcutCode("DOWN"))
            //    scriptToolbarBatch.DownPressed(s);
            //else if (evt.keyCode === ASPxClientUtils.StringToShortcutCode("RIGHT"))
            //    scriptToolbarBatch.RightPressed(s);
            //else if (evt.keyCode === ASPxClientUtils.StringToShortcutCode("LEFT"))
            //    scriptToolbarBatch.LeftPressed(s);
            var lastIndex = s.batchEditApi.GetRowVisibleIndices()[s.batchEditApi
                    .GetRowVisibleIndices().length - 1];
            if (evt.keyCode === 113) {
                if (model != null) {
                    model.FocusedCellColumnIndex = FocusedCellColumnIndex;
                    model.FocusedCellRowIndex = FocusedCellRowIndex;
                    model.FocusedRowKey = FocusedRowKey;
                    var editFields = model.EditFileds;

                    var selectedIndex = 0;
                    editFields.forEach(function (item) {
                        var column = s.GetColumn(FocusedCellColumnIndex);
                        if (column.fieldName == item.FieldName) {
                            model.SelectedIndex = selectedIndex;
                            LoadingPanel.Show();
                            $.ajax({
                                type: 'POST',
                                url: '../../Main/EditWindow',
                                data: model,
                                success: function (response) {
                                    $('#editKatilimciPopup').html(response);
                                }
                            }).always(function () {
                                LoadingPanel.Hide();
                            });
                            return;
                        } else {
                            selectedIndex++;
                        }
                    });
                }
            }
            if (evt.keyCode === 13) {
                var visibleIndex = -2222;
                var i = 0;
                var devam = true;

                array.forEach(function (item) {
                    i++;
                    if (item == FocusedCellRowIndex && devam) {
                        devam = false;
                        visibleIndex = i;
                    }
                });

                var nextIndex = array[visibleIndex];
                if (lastIndex == FocusedCellRowIndex && s.GetVisibleColumnIndices().length == FocusedCellColumnIndex) {

                    if (s.batchEditApi.ValidateRow(FocusedCellRowIndex) != false) {
                        s.AddNewRow();
                    }
                }
                else if (nextIndex != null && s.GetVisibleColumnIndices().length == FocusedCellColumnIndex) {
                    s.batchEditApi.StartEdit(nextIndex, 1);
                }
                else if (FocusedCellRowIndex < 0) {
                    if (s.GetVisibleColumnIndices().length != FocusedCellColumnIndex) {
                        s.batchEditApi.StartEdit(FocusedCellRowIndex, FocusedCellColumnIndex + 1);
                    }
                }
                else {
                    if (s.GetVisibleColumnIndices().length != FocusedCellColumnIndex) {
                        s.batchEditApi.StartEdit(FocusedCellRowIndex, FocusedCellColumnIndex + 1);
                    }
                }
            }

        });
    },
    OnSelectionChanged: function (s, e) {
        rowIndex = e.visibleIndex;
    },
    OnEndEditCell: function (s, e) {
        if (s.batchEditApi.ValidateRow(FocusedCellRowIndex) != false) {
            FocusedCellColumnIndex = 0;
            FocusedCellRowIndex = 0;
            FocusedRowKey = 0;
        }
    },
    OnCellValidate: function (s, e) {
        var itemCode = s.GetColumnByField("STKODU");
        var cellValidationInfo = e.validationInfo[itemCode.index];
        if (cellValidationInfo.value == null) {
            cellValidationInfo.isValid = false;
            cellValidationInfo.errorText = "Item Code is required";
        }
    },
    OnStartEditCell: function (s, e) {
        FocusedCellColumnIndex = e.focusedColumn.index;
        FocusedRowKey = e.key;
        FocusedCellRowIndex = e.visibleIndex;
    },
    UpPressed: function (grid) {
        if (FocusedCellRowIndex > grid.GetTopVisibleIndex())
            grid.batchEditApi.StartEdit(FocusedCellRowIndex - 1, FocusedCellColumnIndex);

    },
    DownPressed: function (grid) {
        var bottomRowIndex = grid.GetVisibleRowsOnPage() + grid.GetTopVisibleIndex() - 1;
        if (FocusedCellRowIndex < bottomRowIndex)
            grid.batchEditApi.StartEdit(FocusedCellRowIndex + 1, FocusedCellColumnIndex);
    },
    RightPressed: function (grid) {
        if (FocusedCellColumnIndex < grid.GetColumnCount() - 1)
            grid.batchEditApi.StartEdit(FocusedCellRowIndex, FocusedCellColumnIndex + 1);
        //else if (FocusedCellColumnIndex == grid.GetColumnCount() - 1) {
        //    FocusedCellColumnIndex = 0;
        //    grid.batchEditApi.StartEdit(FocusedCellRowIndex + 1, FocusedCellColumnIndex);
        //}
    },
    LeftPressed: function (grid) {
        if (FocusedCellColumnIndex > 0)
            grid.batchEditApi.StartEdit(FocusedCellRowIndex, FocusedCellColumnIndex - 1);
    },
    Sil: function (gridName) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var selectedRowInfo = grid.GetCellFocusHelper().focusedCellInfo;
        if (selectedRowInfo != null) {
            var selectedRowKey = selectedRowInfo.recordKey;
            grid.DeleteRowByKey(selectedRowKey);
        }
    },
    OnToolbarPreparing: function (e) {
        var toolbarItems = e.toolbarOptions.items;
        $.each(toolbarItems, function (_, item) {
            if (item.name === 'saveButton') {
                item.visible = false;
            }
        });

    },
    OnRowValidating: function (e) {
        if (e.isValid && e.newData.Login === "Administrator") {
            e.isValid = false;
            e.errorText = "Your cannot log in as Administrator";
        }
    },
    OnRowInserting: function (e) {

    }
}