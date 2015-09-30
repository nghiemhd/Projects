var InvoiceFactory = function ($http) {
    var InvoiceService = {};

    InvoiceService.getInvoice = function () {
        return $http.get('/Invoice/GetInvoice');
    }

    return InvoiceService;
}

InvoiceFactory.$inject = ['$http'];