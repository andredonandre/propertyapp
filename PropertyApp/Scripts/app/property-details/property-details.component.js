angular.module('propertyDetails')
    .component('propertyDetails', {
        templateUrl: 'Property/PropertyDetails',
        controller: function PropertyDetailsController($http, $routeParams,$scope) {
            var self = this;          
            $http.get('Property/Property/' + $routeParams.id ).then(function (response) {               
                self.property = response.data;   
                console.log(self.property);
            });

            $scope.Delete = function () {
                $http.post('Property/Delete/' + $routeParams.id).then(function (response) {
                    alert("Property has been deleted");
                    window.location = "/";
                });
            }
        }
    });