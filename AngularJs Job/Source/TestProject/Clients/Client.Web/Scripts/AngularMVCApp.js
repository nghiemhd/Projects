var AngularMVCApp = angular.module('AngularMVCApp', []);

AngularMVCApp.controller('SigninFormController', SigninFormController);
AngularMVCApp.controller('SignupFormController', SignupFormController);
AngularMVCApp.controller('InvoiceController', InvoiceController);

AngularMVCApp.factory('LoginFactory', LoginFactory);
AngularMVCApp.factory('RegisterFactory', RegisterFactory);
AngularMVCApp.factory('InvoiceFactory', InvoiceFactory);