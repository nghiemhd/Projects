var AwesomeAngularMVCApp = angular.module('AwesomeAngularMVCApp', ['ngRoute']);

AwesomeAngularMVCApp.controller('LandingPageController', LandingPageController);
AwesomeAngularMVCApp.controller('LoginController', LoginController);
AwesomeAngularMVCApp.controller('RegisterController', RegisterController);

AwesomeAngularMVCApp.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
AwesomeAngularMVCApp.factory('LoginFactory', LoginFactory);
AwesomeAngularMVCApp.factory('RegisterFactory', RegisterFactory);

var configFunction = function ($routeProvider, $httpProvider, $locationProvider) {
    //$locationProvider.hashPrefix('!').html5Mode(true);

    $routeProvider
        .when('/routeOne', {
            templateUrl: 'routesDemo/one'
        })
        .when('/routeTwo/:donuts', {
            templateUrl: function (params) {
                return '/routesDemo/two?donuts=' + params.donuts;
            }
        })
        .when('/routeThree', {
            templateUrl: 'routesDemo/three'
        })
        .when('/login', {
            templateUrl: 'Account/Login',
            controller: LoginController
        })
        .when('/register', {
            templateUrl: 'Account/Register',
            controller: RegisterController
        });

    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}

configFunction.$inject = ['$routeProvider', '$httpProvider', '$locationProvider'];

AwesomeAngularMVCApp.config(configFunction);