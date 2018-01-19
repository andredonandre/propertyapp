angular.
    module('PropertyApp').
    config(['$locationProvider', '$routeProvider',
        function config($locationProvider, $routeProvider) {
            $locationProvider.hashPrefix('!');
         
            $routeProvider
                .when('/', {
                    template: '<property-list></property-list>',
                })
                .when('/new', {
                    template: '<property-new></property-new>',
                })
                .when('/:id', {
                    template: '<property-details></property-details>',
                })                
                .otherwise('/');
        }
    ]);