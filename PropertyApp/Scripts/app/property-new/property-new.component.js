angular.module('propertyNew')
    .component('propertyNew', {
        templateUrl: 'Property/PropertyNew',
        controller: function PropertyNewController($scope, $http, $routeParams) {

            $scope.files = [];
            $scope.Urls = [];
            $scope.selectedFiles = 0;

            $scope.SelectImage = function (elem) {
                if (elem.files && elem.files[0]) {
                    let fileToUpload = elem.files[0];
                    $scope.$apply(function () {
                        $scope.files.push(fileToUpload);
                        $scope.Urls.push(elem.value);
                        $scope.selectedFiles = $scope.files.length;
                    });
                }
            }
            

            $scope.SaveProperty = function () {
                if ($scope.selectedFiles >= 4) {
                    $scope.NewProperty = {};
                    $scope.NewProperty.id = '';
                    $scope.NewProperty.Title = $scope.Title;
                    $scope.NewProperty.Address = $scope.Address;
                    $scope.NewProperty.Country = $scope.Country;
                    $scope.NewProperty.Landlord = $scope.LandlordName;
                    $scope.NewProperty.Description = $scope.Description;
                    $scope.NewProperty.ImagePaths = $scope.Urls;

                    $http({
                        url: "/Property/New",
                        method: "POST",
                        data: JSON.stringify($scope.NewProperty),
                    }).then(function (response) {
                        alert("New Property Added");
                        $scope.Title = "";
                        $scope.Address = "";
                        $scope.Country = "";
                        $scope.LandlordName = "";
                        $scope.Description = "";
                        $scope.NewProperty.ImagePaths = [];
                        window.location = "/";
                    });
                }
                else {
                    alert("You are required to Upload atleast 4 images");
                }
            }
        }
    });