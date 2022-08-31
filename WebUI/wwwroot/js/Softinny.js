
function AcceptenceSwal(swallText,acceptButtonName,cancelButtonName, acceptFunction, cancelFunction) {
    swal(swallText, {
        buttons: {
            cancel: cancelButtonName,
            catch: {
                text: acceptButtonName,
                value: "catch",
            },
        },
        icon: "warning",
    }).then((value) => {
        switch (value) {
            case "catch":
                acceptFunction();
                break;
            default:
                cancelFunction();
                break;
        }
    });
    
}

function select2forAddProd(selectBoxClass, controllerMethodName) {
    $(selectBoxClass).select2({
        ajax: {
            url: controllerMethodName,
            type: "get",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    searchWord: params.term
                }
            },
            processResults: function (response) {

                var result = $.map(response, function (item) {

                    return {
                        id: item.id,
                        text: item.name
                    };
                })
                return {
                    results: result
                }
            },
            cache: true
        }
    });
}






