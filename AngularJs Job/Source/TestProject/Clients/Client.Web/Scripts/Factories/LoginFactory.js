var LoginFactory = function ($http, $q) {
    return function (email, password, rememberMe) {
        var deferredObject = $q.defer();

        $http.post(
            '/Account/SignIn', {
                Email: email,
                Password: password,
                RememberMe: rememberMe
            }
        )
        .success(function (data) {
            if (data == "true") {
                deferredObject.resolve({ success: true });
            }
            else {
                deferredObject.resolve({ success: false });
            }
        })
        .error(function () {
            deferredObject.resolve({ success: false });
        });

        return deferredObject.promise;
    }
}

LoginFactory.$inject = ['$http', '$q'];