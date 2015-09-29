﻿var SignupFormController = function ($scope, $location, RegisterFactory) {
    $scope.user = {
        email: '',
        password: '',
        confirmPassword: ''
    };

    $scope.authError = false;
    $scope.errors = [];

    $scope.signup = function () {
        var result = RegisterFactory($scope.user.email, $scope.user.password, $scope.user.confirmPassword);
        result.then(function (result) {
            if (result.success) {
                $location.path('');
            }
            else {
                $scope.authError = true;
                $scope.errors = result.errors;
            }
        });
    }
}

SignupFormController.$inject = ['$scope', '$location', 'RegisterFactory'];