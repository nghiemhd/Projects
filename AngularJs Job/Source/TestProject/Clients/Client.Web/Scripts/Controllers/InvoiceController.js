var InvoiceController = function ($scope, InvoiceFactory) {
    $scope.invoice = {};
    $scope.deleteIds = [];

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

    $scope.updateInvoice = function () {
        $('#loader').show();
        var result = InvoiceFactory.updateInvoice($scope.invoice.InvoiceDetails, $scope.deleteIds);
        result.then(function (result) { 
            if(result.success) {
                toastr.success('Update successfully');
            }
            else {
                toastr.options = {
                    closeButton: true,
                    positionClass: "toast-top-full-width",
                    timeOut: 0,
                    extendedTimeOut: 0
                };
                toastr.error(result.error);
                console.log(result.error);
            }
        });
        
        $('#loader').hide();
    }

    $scope.delete = function () {
        //$('#invoiceDetails input[type=checkbox]:checked').each(function () {
        //    var detailId = $(this).val();
        //    $scope.deleteIds.push(detailId);
        //    $scope.invoice.InvoiceDetails = $.grep($scope.invoice.InvoiceDetails, function (e) {
        //        return e.Id != detailId;
        //    });
        //});
        var counter = 0;
        var indexes = [];
        $('#invoiceDetails input[type=checkbox]').each(function () {
            if ($(this).is(":checked")) {
                indexes.push(counter);
                counter++;
            }
            else {
                counter++;
            }
        });

        $.each(indexes, function (i, value) {
            var detailId = $scope.invoice.InvoiceDetails[value].Id;
            $scope.deleteIds.push(detailId);            
        });

        counter = 0;
        $.each(indexes, function (i, value) {
            if (counter > 0) {
                value = value - counter;
            }
            $scope.invoice.InvoiceDetails.splice(value, 1);
            counter++;
        });
    }

    $scope.addItem = function () {
        var detail = {
            Id: 0,
            InvoiceId: $scope.invoice.Id,
            Description: '',
            Quantity: 0,
            Price: 0
        };

        $scope.invoice.InvoiceDetails.push(detail);
    }
}

InvoiceController.$inject = ['$scope', 'InvoiceFactory'];