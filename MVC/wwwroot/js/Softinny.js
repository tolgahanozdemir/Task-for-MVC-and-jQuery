
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

