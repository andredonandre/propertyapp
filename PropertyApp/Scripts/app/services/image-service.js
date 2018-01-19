angular.module("uploader.services")
    .service("imageService", ["$q", "$http", function ($q, $http) {

        var promise = function (callback) {

            var deferred = $q.defer();

            callback(deferred);

            return deferred.promise;

        };

        return {
            getImages: function () {
                /$http.get( "image" )
                    .success(function (data) {
                        deferred.resolve(data);
                    })
                    .error(function (error) {
                        deferred.reject(error);
                    });
            },

            uploadImage: function (image) {
                // sends an image
            }
        };
    }]);