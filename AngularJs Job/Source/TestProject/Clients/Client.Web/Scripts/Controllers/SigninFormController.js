var SigninFormController = function ($scope, LoginFactory) {
    $scope.user = {
        email: '',
        password: '',
        rememberMe: false
    };

    $scope.authError = false;

    $scope.login = function () {
        $('#loader').show();
        var result = LoginFactory($scope.user.email, $scope.user.password, $scope.user.rememberMe);
        result.then(function (result) {
            if (!result.success) {
                $scope.authError = true;
            }
            else {
                window.location.href = '/';
            }
            $('#loader').hide();
        });
    }
}

SigninFormController.$inject = ['$scope', 'LoginFactory'];