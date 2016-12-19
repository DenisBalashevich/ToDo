angular.module('AppServiceModule', [])
.service('ItemServise', ['$http', function ($http) {
    return {
        getAll: function () {
            return $http.get('/api/ToDo');
        },
        save: function (data) {
            return $http.post('/api/ToDo', data);
        },
        remove: function (id) {
            return $http.delete('/api/ToDo/' + id);
        }
    }
}]);

angular.module('toDoApp', ['AppServiceModule'])
.controller('toDoCtrl', [
'$scope', '$http', 'ItemServise',
function ($scope, $http, ItemServise) {

    $scope.newItem = '';
    $scope.MyFunc = function () {
        alert("click");
    };
    $scope.addItem = function () {
        $scope.newItem = {
            id: $scope.id,
            author: $scope.author,
            name: $scope.name,
            content: $scope.content,
            createDate: new Date().toDateString()
        }
        ItemServise.save($scope.newItem);

        $scope.newImg = '';
    }

    $scope.removeItem = function (index, elem) {
        $scope.Items.splice(index, 1);

        ItemServise.remove(elem.id)
    }

    function init() {
        ItemServise.getAll().then(function (response) {
            $scope.Items = [];

            response.data.forEach(function (element, index, array) {
                $scope.Items.push({
                    id: element.Id,
                    author: element.Author,
                    content: element.Content,
                    name: element.Name,
                    createDate: element.CreateDate
                });
            })
        });
    }

    //init();
}]);