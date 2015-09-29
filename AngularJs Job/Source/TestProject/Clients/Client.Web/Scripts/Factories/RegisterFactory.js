var RegisterFactory = function ($http, $q) {
    return function (email, password, confirmPassword) {
        var deferredObject = $q.defer();

        $http.post(
            '/Account/SignUp', {
                Email: email,
                Password: password,
                ConfirmPassword: confirmPassword
            }
        )
        .success(function (data) {
            if (data.errors === undefined || data.errors.length == 0) {
                deferredObject.resolve({ success: true });
            }
            else {
                deferredObject.resolve({ success: false, errors: data.errors });
            }
        })
        .error(function () {
            deferredObject.resolve({ success: false });
        });

        return deferredObject.promise;
    }
}

RegisterFactory.$inject = ['$http', '$q'];