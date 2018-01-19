angular.module('propertyList')
    .component('propertyList', {
        templateUrl: 'Property/PropertyList',
        controller: function PropertyListController($http, $routeParams) {
            var self = this;
            this.orderProp = "Title"          
            $http.get('Property/Properties').then(function (response) {               
                self.properties = response.data;   
                console.log(self.properties);
            });
        }
    });