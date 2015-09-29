var SigninFormController = function ($scope, LoginFactory) {
    $scope.user = {
        email: '',
        password: '',
        rememberMe: false
    };

    $scope.authError = false;

    $scope.login = function () {
        var result = LoginFactory($scope.user.email, $scope.user.password, $scope.user.rememberMe);
        result.then(function (result) {
            if (!result.success) {
                $scope.authError = true;
            }
        });
    }
}

SigninFormController.$inject = ['$scope', 'LoginFactory'];