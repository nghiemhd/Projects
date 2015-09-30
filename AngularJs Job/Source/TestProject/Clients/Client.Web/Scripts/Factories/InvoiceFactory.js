var InvoiceFactory = function ($http, $q) {
    var InvoiceService = {};

    InvoiceService.getInvoice = function () {
        return $http.get('/Invoice/GetInvoice');
    }

    InvoiceService.updateInvoice = function (invoiceDetails, deleteIds) {
        var deferredObject = $q.defer();

        var data = {
            UpdatedInvoiceDetails: invoiceDetails,
            DeletedInvoiceDetails: deleteIds
        };

        $http.post('/Invoice/UpdateInvoice', data)
        .success(function (data) {
            if (data.success) {
                deferredObject.resolve({ success: true });
            }
            else {
                deferredObject.resolve({ success: false, error: data.error });
            }
        })
        .error(function (error) {
            deferredObject.resolve({ success: false, error: error });
        });

        return deferredObject.promise;
    }

    return InvoiceService;
}

InvoiceFactory.$inject = ['$http', '$q'];