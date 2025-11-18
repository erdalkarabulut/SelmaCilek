$.Bps = {};
var isReload = false;

$.Bps.Notify = {
    Show: function (title, message, type) {
        if (type == "func")
            eval(message);
        else {
            $.growl({
                title: title != "" ? "<strong style='font-size:16px;'>" + title + "</h4></br>" : "",
                message: type == "funcAndMessage" ? message.split("$$")[0] : message
            },
                {
                    type: type == "funcAndMessage" ? "success" : type,
                    allow_dismiss: true,
                    label: 'Cancel',
                    className: 'btn-xs btn-inverse',
                    placement: {
                        from: 'top',
                        align: 'center'
                    },
                    delay: isReload ? 2000 : waitingSeconds,
                    animate: {
                        enter: 'animated fadeInDown',
                        exit: 'animated fadeOutUp'
                    },
                    offset: {
                        x: 0,
                        y: 0
                    },
                });
            setTimeout(function (e) {
                if (type == "success" || type == "funcAndMessage")
                    $(".modal").modal("hide");
                if (type == "funcAndMessage")
                    eval(message.split("$$")[1]);
            },
                2000)
            setTimeout(function (e) {
                if (isReload) {
                    window.location.reload();
                }
            },
                2000)
        }
    },
    Send: function (title, body) {
        if (Notification.permission !== "granted")
            Notification.requestPermission();
        else {
            notification = new Notification(title, {
                icon: '/assets/images/push.png',
                body: body,
            });

            notification.onclick = function () {
                window.open("/Dashboard");
            };

        }

    }
}

$.Bps.Server = {
    PostAsync: function (model, url, func) {
        $.ajax({
            type: "POST",
            async: true,
            url: url,
            data: JSON.stringify(model),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (response, result) {
                if (response.Status == 0) {
                    BpsAlert.success(response.Message);
                } else if (response.Status == 1) {
                    BpsAlert.error(response.Message);
                } else if (response.Status == 2) {
                    BpsAlert.warning(response.Message);
                } else if (response.Status == 3) {
                    BpsAlert.info(response.Message);
                }
            },
            error: function (xhr, errorType, exception) {
                $.ErcanAyhan.Loading.waitMe('hide');
                $("[data-btn]").removeAttr("disabled");
                $("[data-btn]").waitMe("hide");
                var rText = xhr.responseText;
                var rTextSplit = rText.split("##");
                if (xhr.statusText == "warning" || xhr.statusText == "info" ||
                    xhr.statusText == "success" || xhr.statusText == "danger" ||
                xhr.statusText == "func" || xhr.statusText == "funcAndMessage") {
                    if (xhr.statusText != "success")
                        isReload = false;
                    $.Bps.Notify.Show(rTextSplit[1], rTextSplit[0], xhr.statusText);
                }
            }
        });
    },
    Post: function (model, url, func) {
        var ad = $.ajax({
            url: url,
            type: "POST",
            data: JSON.stringify(model),
            async: false,
            dataType: 'json',
            success: function (response, result) {
                if (response.Status == 0) {
                    BpsAlert.success(response.Message);
                } else if (response.Status == 1) {
                    BpsAlert.error(response.Message);
                } else if (response.Status == 2) {
                    BpsAlert.warning(response.Message);
                } else if (response.Status == 3) {
                    BpsAlert.info(response.Message);
                }
            },
            error: function (xhr, errorType, exception) {
                var rText = xhr.responseText;
                var rTextSplit = rText.split("##");
                if (xhr.statusText == "warning" || xhr.statusText == "info" ||
                    xhr.statusText == "success" || xhr.statusText == "danger" ||
                xhr.statusText == "func" || xhr.statusText == "funcAndMessage") {
                    if (xhr.statusText != "success")
                        isReload = false;
                    $.Bps.Notify.Show(rTextSplit[1], rTextSplit[0], xhr.statusText);
                }
            }
        });
        return ad;
    },
    GetAsync: function (model, url, func) {
        $.ajax({
            type: "GET",
            async: true,
            url: url,
            data: JSON.stringify(model),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (response, result) {
                if (response.Status == 0) {
                    BpsAlert.success(response.Message);
                } else if (response.Status == 1) {
                    BpsAlert.error(response.Message);
                } else if (response.Status == 2) {
                    BpsAlert.warning(response.Message);
                } else if (response.Status == 3) {
                    BpsAlert.info(response.Message);
                }
            },
            error: function (xhr, errorType, exception) {
                if ($.ErcanAyhan.WaitMeIsShow)
                    $.ErcanAyhan.Loading.waitMe('hide');
                var rText = xhr.responseText;
                var rTextSplit = rText.split("##");
                if (xhr.statusText == "warning" || xhr.statusText == "info" ||
                    xhr.statusText == "success" || xhr.statusText == "danger" ||
                xhr.statusText == "func" || xhr.statusText == "funcAndMessage")
                    $.Bps.Notify.Show(rTextSplit[1], rTextSplit[0], xhr.statusText);
            }
        });
    },
    Get: function (model, url, func) {
        $.ajax({
            type: "GET",
            async: false,
            url: url,
            data: JSON.stringify(model),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (response, result) {
                if (response.Status == 0) {
                    BpsAlert.success(response.Message);
                } else if (response.Status == 1) {
                    BpsAlert.error(response.Message);
                } else if (response.Status == 2) {
                    BpsAlert.warning(response.Message);
                } else if (response.Status == 3) {
                    BpsAlert.info(response.Message);
                }
            },
            error: function (xhr, errorType, exception) {
                var rText = xhr.responseText;
                var rTextSplit = rText.split("##");
                if (xhr.statusText == "warning" || xhr.statusText == "info" ||
                    xhr.statusText == "success" || xhr.statusText == "danger" ||
                xhr.statusText == "func" || xhr.statusText == "funcAndMessage")
                    $.Bps.Notify.Show(rTextSplit[1], rTextSplit[0], xhr.statusText);
            }
        });
    }
};

function GetValue(e) {
    if (e.type == "text" || e.type == "email" || e.type == "password" || e.type == "date" || e.type == "datetime" || e.type == "datetime-local") {
        return e.value.trim();
    } else if (e.type == "file") {
        return e.files;
    }
    else if (e.type == "checkbox")
        return e.checked;
    else if (e.className == "g-recaptcha")
        return grecaptcha.getResponse();
    else if (e.className.indexOf("percent") != -1)
        return parseInt(e.noUiSlider.get());
    else if (e.id == "tinymce")
        return tinyMCE.activeEditor.getContent();
    else if (e.tagName.toLowerCase() == "select" && e.attributes["multiple"] != undefined) {
        var data = [];
        for (var i = 0; i < e.selectedOptions.length; i++) {
            data.push(e.selectedOptions[i].value);
        }
        return data;
    }
    else if (e.nodeName == "TR") {
        return e.dataset.value;
    }
    else if (e.nodeName == "TD") {
        return e.dataset.value;
    }
    else if (e.nodeName == "A") {
        return e.innerHTML;
    }
    else
        return e.value.trim();
}

function SetValue(v) {
    var e = $("[data-attribute]");
    for (var i = 0; i < e.length; i++) {
        if (e[i].className.indexOf("select2-offscreen") != -1)
            $("[data-attribute]:eq(" + i + ")").select2("val", v);
        else
            if (e[i].type == "text" || e[i].type == "email" || e[i].type == "password" || e[i].type == "date" || e[i].type == "datetime" || e[i].type == "datetime-local") {
                e[i].value = v;
            }
            else if (e[i].type == "checkbox")
                e[i].checked = false;
            else if (e[i].id == "tinymce")
                tinyMCe[i].activeEditor.setContent(v);
            else if (e[i].tagName[i].toLowerCase() == "select" && e[i].attributes["multiple"] != undefined) {
                e[i].selectedOptions[i].value = v;
            }
            else
                e[i].value = v;
    }
}

function formGetModel(e) {
    var model = {};
    var modelId = $("[data-id='" + e.id + "'] [name]");
    $("[data-btn]").attr("disabled");
    var trimByIpnuts = $("[data-id='" + e.id + "'] input");
    for (var c = 0; c < trimByIpnuts.length; c++) {
        if (trimByIpnuts[c].type == "text") {
            trimByIpnuts[c].value = trimByIpnuts[c].value.trim();
        }
    }
    for (var i = 0; i < modelId.length; i++) {
        if (modelId[i].attributes["id"] != undefined)
            model[modelId[i].attributes["name"].value] = GetValue(modelId[i]);
    }

    return model;
}

function formSendModel(e) {
    var model = {};
    var modelId = $("[data-id='" + e.id + "'] [name]");
    $("[data-btn]").attr("disabled");
    var trimByIpnuts = $("[data-id='" + e.id + "'] input");
    for (var c = 0; c < trimByIpnuts.length; c++) {
        if (trimByIpnuts[c].type == "text") {
            trimByIpnuts[c].value = trimByIpnuts[c].value.trim();
        }
    }
    for (var i = 0; i < modelId.length; i++) {
        if (modelId[i].attributes["id"] != undefined)
            model[modelId[i].attributes["name"].value] = GetValue(modelId[i]);
    }
    var dataId = $("[data-id='" + e.id + "']")[0].dataset;
    var ajaxType = dataId.ajaxType;
    var url = dataId.modelUrl;
    var func = dataId.ajaxFunction;

    isReload = isReload ? true : (dataId.reload === "true");
    var a = $.Bps.Server.Post(model, url, eval(func));
    var rText = a.responseText;
    var rTextSplit = rText.split("##");

    if (a.statusText == "warning" ||
        a.statusText == "info" ||
        a.statusText == "success" ||
        a.statusText == "danger" ||
        a.statusText == "func" ||
        a.statusText == "funcAndMessage") {
        if (a.statusText != "success") {
            $("[data-btn]").removeAttr("disabled");
            return rTextSplit[1];
        };
    }
    $("[data-btn]").removeAttr("disabled");

};

var BpsAlert = {
    success: function (message) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr["success"](message);
    },
    error: function (message, fnc) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr["error"](message);
    },
    warning: function (message) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr["warning"](message);
    },
    info: function (message) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr["info"](message);
    },
    evalScript: function (response) {
        if (response != null && response.startsWith("\{\"script\":")) {
            var scriptStr = "\"{\"script\":\"";
            var scriptIndex = response.indexOf(scriptStr);
            var script = response.substr(scriptIndex + scriptStr.length,
                response.indexOf("\"\}", scriptIndex + scriptStr.length) - (scriptIndex + scriptStr.length));
            script = script.replace("\\", "").replace("\\", "");
            eval(script);
        } else {
            BpsAlert.error("Beklenmeyen hata oluştu!");
        }
    },
    alertResponse: function (response) {
        if (response.Status === 0) {
            if (response.Message !== null && response.Message !== '') {
                BpsAlert.success(response.Message);
            }
        }
        else if (response.Status === 1) {
            BpsAlert.error(response.Message);
        }
        else if (response.Status === 2) {
            BpsAlert.warning(response.Message);
        }
        else if (response.Status === 3) {
            BpsAlert.info(response.Message);
        }
    }
}

var bpsMain = {
    dilSec: function (dilKodu) {
        var seciliDil = document.getElementById("dilKod").classList[4];
        document.getElementById("dilKod").classList.remove(seciliDil);
        document.getElementById("dilKod").classList.add(dilKodu);
        window.location = "../User/ChangeLanguage?langkd=" + dilKodu;
    },
    projeSec: function (projeKod, url) {
        $.ajax({
            url: url,
            type: 'POST',
            dataType: 'JSON',
            data: {
                projeKod: projeKod
            },
            success: function (response, result) {
                BpsAlert.alertResponse(response);
                if (response.Status === 0) {
                    window.location = '../../Main/Index?projeKodu=' + projeKod;
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
        });
    },
    loadUserInfos: function () {
        $.ajax({
            url: "../../../User/GetUserInfos",
            type: "POST",
            dataType: 'json',
            success: function (data) {
                if (data.ResimVarMi) {
                    //    document.getElementById('userImg1').src = '../../Assets/Images/users/' + data.UserKod + '.jpg';
                    //    document.getElementById('userImg2').src = '../../Assets/Images/users/' + data.UserKod + '.jpg';
                    document.getElementById('userImg1').src = data.UserImgPath;
                    document.getElementById('userImg2').src = data.UserImgPath;
                } else document.getElementById('userImg1').src = '../../Assets/Images/users/default.png';
                document.getElementById("userName").innerHTML = data.FirstName + ' ' + data.LastName;
                document.getElementById("userName2").innerHTML = data.FirstName + ' ' + data.LastName;

                var seciliDil = document.getElementById("dilKod").classList[4];
                document.getElementById("dilKod").classList.remove(seciliDil);
                document.getElementById("dilKod").classList.add(data.DilKod);
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
    },
    submitForm: function (formName, gridName, popupName, url, menuTag) {
        console.log(arguments);
        var model = {};
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var popup = ASPxClientControl.GetControlCollection().GetByName(popupName);
        var formList = [];
        var model = {};
        formList.push(formName);
        bpsMain.getFormModel(formList, model);
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
                    popup.Hide();
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
        });
    },
    getFormMultiModel: function (formList, model) {
        formList.forEach(function (formName) {
            var modelName = "";
            var form = ASPxClientControl.GetControlCollection().GetByName(formName);
            form.rootItem.items.forEach(function (item) {
                item.items.forEach(function (data) {
                    if (data.name != null && data.name != "") {
                        var splitedData = data.name.split('.');
                        modelName = splitedData[0];
                        var fieldName = splitedData[1];
                        var control = ASPxClientControl.GetControlCollection().GetByName(fieldName);
                        if (control != null) {
                            if (control instanceof ASPxClientDateEdit) {
                                if (control.GetValue() == null) {
                                    eval("model." + modelName + "['" + fieldName + "'] = null;");
                                } else {
                                    eval("model." + modelName + "['" + fieldName + "'] = control.GetValue().toLocaleString();");
                                }
                            } else {
                                eval("model." + modelName + "['" + fieldName + "'] = control.GetValueString();");
                            }
                        }
                    }
                });
            });
        });
        return model;
    },
    getFormModel: function (formList, model) {
        formList.forEach(function (formName) {
            var form = ASPxClientControl.GetControlCollection().GetByName(formName);
            form.rootItem.items.forEach(function (item) {
                item.items.forEach(function (data) {
                    if (data.name != null && data.name != "") {
                        var control = ASPxClientControl.GetControlCollection().GetByName(data.name);
                        if (control != null) {
                            if (control instanceof ASPxClientDateEdit) {
                                if (control.GetValue() == null) {
                                    eval("model['" + data.name + "'] = null;");
                                } else {
                                    eval("model['" + data.name + "'] = control.GetValue().toLocaleString();");
                                }
                            } else {
                                eval("model['" + data.name + "'] = control.GetValueString();");
                            }
                        }
                    }
                });
            });
        });
        return model;
    },
    submitFormWithTab: function (formList, gridName, url, menuTag, tab1, tab2) {
        var model = {};
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        formList.forEach(function (formName) {
            var form = ASPxClientControl.GetControlCollection().GetByName(formName);
            form.rootItem.items.forEach(function (item) {
                item.items.forEach(function (data) {
                    var control = ASPxClientControl.GetControlCollection().GetByName(data.name);
                    if (control != null) {
                        model[data.name] = control.GetValueString();
                    }
                });
            });
        });

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
                    pageControlPersonel.GetTabByName(tab1).SetVisible(1);
                    pageControlPersonel.GetTabByName(tab2).SetVisible(0);
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
        });
    },
    sessionBreak: function (url) {
        $.ajax({
            url: url,
            type: 'POST',
            dataType: 'JSON',
            success: function (response, result) {
                BpsAlert.alertResponse(response);
                return;
            },
            error: function (response, status) {
                if (response.status == 900) {
                    ppLoginAjax.Show();
                } else {
                    console.log(arguments);
                    BpsAlert.error("Beklenmeyen hata oluştu!");
                }
            }
        });
    },
    loginAjax: function (url) {
        var model = {};
        var pass = winLoginAjax_Password.GetValue();
        var kulkod = winLoginAjax_Kulkod.GetValue();
        var sirket = winLoginAjax_Sirket.GetValue();
        var dilKod = document.getElementById("dilKod").classList[4]

        model.SIRKID = sirket;
        model.KULKOD = kulkod;
        model.PASSWD = pass;
        model.DilKod = dilKod;

        $.ajax({
            url: url,
            type: 'POST',
            dataType: 'JSON',
            data: model,
            success: function (response, result) {
                BpsAlert.alertResponse(response);
                if (response.Status === 0) {
                    ppLoginAjax.Hide();
                    BpsAlert.success('Başarılı bir şekilde giriş yapıldı.');
                }
                return;
            },
            error: function (response, status) {
                console.log(arguments);
                BpsAlert.error("Beklenmeyen hata oluştu!");
            }
        });

    }
}

var batchEditing = {
    GetUpdatedValues: function (gridName) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var updatedValues = grid.batchEditHelper.updatedValues;
        var keys = [];
        for (var key in updatedValues) {
            keys.push(key);
        }
        var result = GetValues(keys, grid);
        return result;
    },
    GetInsertedValues: function (gridName) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var insertedValues = grid.batchEditHelper.insertedValues;
        var keys = [];
        for (var key in insertedValues) {
            keys.push(key);
        }
        var result = GetValues(keys, grid);
        return result;
    },
    GetDeletedKeys: function (gridName) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var deletedKeys = grid.batchEditHelper.deletedItemKeys;
        var keys = [];
        for (var key in deletedKeys) {
            keys.push(deletedKeys[key]);
        }
        var result = GetValues(keys, grid);
        return result;
    },
    GetValues: function (gridName) {
        var grid = ASPxClientControl.GetControlCollection().GetByName(gridName);
        var th = grid.batchEditHelper;
        var api = grid.batchEditApi;
        var insertedValues = grid.batchEditHelper.insertedValues;
        var updatedValues = grid.batchEditHelper.updatedValues;
        var deletedKeys = grid.batchEditHelper.deletedItemKeys;
        var itemKeys = [];
        for (var key in insertedValues) {
            itemKeys.push({
                'key': parseInt(key),
                'type': 0
            });
        }
        for (var key in updatedValues) {
            itemKeys.push({
                'key': parseInt(key),
                'type': 1
            });
        }
        for (var key in deletedKeys) {
            itemKeys.push({
                'key': deletedKeys[key],
                'type': 2
            });
        }
        var inserted = [];
        for (var i = 0; i < itemKeys.length; i++) {
            var result = {};
            var recordKey = itemKeys[i].key;
            var type = itemKeys[i].type;

            if (type == 2 && api.IsDeletedRowByKey(recordKey) == false) continue;
            if (type == 1 && api.IsDeletedRowByKey(recordKey) == true) continue;
            if (type == 0 && api.IsNewRow(recordKey) == true && api.IsDeletedRowByKey(recordKey) == true) continue;
            if (type == 2 && api.IsNewRow(recordKey) == true && api.IsDeletedRowByKey(recordKey) == true) continue;

            var itemValues = th.GetRecordValues(recordKey);
            for (var columnKey in itemValues) {
                if (!itemValues.hasOwnProperty(columnKey)) continue;
                var column = grid.columns.find(function (element) {
                    return element.index == columnKey;
                });
                if (itemValues[columnKey].value == null) {
                    result[column.fieldName] = null;
                    continue;
                }
                if (typeof itemValues[columnKey].value.getMonth === 'function') {
                    console.log(column.fieldName);
                    result[column.fieldName] = itemValues[columnKey].value.toLocaleString();
                    continue;
                }
                result[column.fieldName] = itemValues[columnKey].value;
            }
            result['Id'] = recordKey;
            result['BatchType'] = type;
            inserted.push(result);
        }
        return inserted;
    },
    GetValues2: function (itemKeys, grid) {
        var th = grid.batchEditHelper;
        var changes = [];
        for (var i = 0; i < itemKeys.length; i++) {
            var result = {};
            var recordKey = itemKeys[i];
            var itemValues = th.GetRecordValues(recordKey);
            for (var columnKey in itemValues) {
                if (!itemValues.hasOwnProperty(columnKey)) continue;
                var column = grid.columns.find(function (element) {
                    return element.index == columnKey;
                });
                if (itemValues[columnKey].value.toLocaleString == undefined)
                    result[column.fieldName] = itemValues[columnKey].value;
                else
                    result[column.fieldName] = itemValues[columnKey].value.toLocaleString();
            }
            changes.push(result);
        }
        return changes;
    }
}

function UpdateGridHeight(gridname, extraHeight) {
    var containerHeight = ASPxClientUtils.GetDocumentClientHeight();

    if (document.body.scrollHeight > containerHeight)
        containerHeight = document.body.scrollHeight;
    if (extraHeight != null) containerHeight = containerHeight - extraHeight;

    //grid.SetHeight(containerHeight - (40 + 60 + 10));
    return containerHeight - (40 + 60 + 4);
    // Default çıkarılması gereken yükseklikler ;
    // 40 => temanın olduğu panelin yüksekliği
    // 60 => topPanel yüksekliği
}