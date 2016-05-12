//create module
var topSpots = angular.module('topSpots',[]);
//create controller 
topSpots.controller('tController', ['$scope', '$http', function($scope, $http){
	
	activate();
//grab json file and drop into scope
	function activate () {
		$http({
			method: 'get',
			url:'http://localhost:53483/api/TopSpots',
		}).then(function(response){

			$scope.topspots= response.data;
			
		});
	}

	$scope.newSpot = function (addSpot) {
			addSpot.location = [ Number (addSpot.longitude), Number(addSpot.latitude)];
		$http({
			method: 'post',
			url:'http://localhost:53483/api/TopSpots',
			data: $scope.addSpot
		}).then(function(){
			$scope.topspots.push(addSpot);
			$scope.addSpot= {};
			
		});
	}

}]);	




