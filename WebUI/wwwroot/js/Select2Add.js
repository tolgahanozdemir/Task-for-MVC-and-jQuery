function Select2Prepare(selectBoxClass, controllerMethodName) {
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