var AngularMVCApp = angular.module('AngularMVCApp', []).directive('contenteditable', function () {
    return {
        require: 'ngModel',
        link: function (scope, elm, attrs, ctrl) {
            // view -> model
            elm.bind('keyup change', function () {
                scope.$apply(function () {
                    ctrl.$setViewValue(elm.html());
                });
            });

            // model -> view
            ctrl.$render = function () {
                elm.html(ctrl.$viewValue);
            };
        }
    };
});

AngularMVCApp.controller('SigninFormController', SigninFormController);
AngularMVCApp.controller('SignupFormController', SignupFormController);
AngularMVCApp.controller('InvoiceController', InvoiceController);

AngularMVCApp.factory('LoginFactory', LoginFactory);
AngularMVCApp.factory('RegisterFactory', RegisterFactory);
AngularMVCApp.factory('InvoiceFactory', InvoiceFactory);