var InvoiceController = function ($scope, InvoiceFactory) {
    $scope.invoice = {};

    $scope.load = function () {
        InvoiceFactory.getInvoice()
        .success(function (data) {
            if (data.success && data.invoice !== null) {
                $scope.invoice = data.invoice;
                $scope.invoice.InvoiceDate = toDateFormat(data.invoice.InvoiceDate, 'dS mmm yyyy');
                //$.each($scope.invoice.InvoiceDetails, function(index, item){
                //    item.Price = item.Price.toFixed(2);
                //});
            }
            else {
                console.log(data.error);
            }
        })
        .error(function (error) {
            console.log(error);
        });
    }

    $scope.subtotal = function () {
        var total = 0.00;
        $($scope.invoice.InvoiceDetails).each(function (index, item) {
            var x = item.Quantity * item.Price;
            total += x;
        });
        return total;
    }

    $scope.grandTotal = function () {
        var total = 0.00;
        return $scope.subtotal() + $scope.invoice.ShippingFee + $scope.invoice.VAT;
    }

    $scope.load();

    function getDateTimeValue(date) {
        date = date.replace('/Date(', '');
        date = date.replace(')/', '');
        return Number(date);
    }

    function toDateFormat(date, format) {
        var dateValue = getDateTimeValue(date);
        return dateFormat(new Date(dateValue), format);
    }
}

InvoiceController.$inject = ['$scope', 'InvoiceFactory'];