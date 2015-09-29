var AngularMVCApp = angular.module('AngularMVCApp', []);

AngularMVCApp.controller('SigninFormController', SigninFormController);
AngularMVCApp.controller('SignupFormController', SignupFormController);

AngularMVCApp.factory('LoginFactory', LoginFactory);
AngularMVCApp.factory('RegisterFactory', RegisterFactory);