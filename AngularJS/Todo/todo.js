(function () {
    
    "use strict";
    
    var app = angular.module('todoApp', [])
        .constant('_', window._)
        .run(function ($rootScope) {
            $rootScope._ = window._;
        });
    
    
    app.controller('todoCtrl', [ '$scope', '_', function ($scope, _) {
        
        $scope.todos = [];
        
        $scope.AddTodo = function (value) {
            
            if (value) {
                var newTodo = { 'description': value, 'completed': false };
                $scope.todos.push(newTodo);
                $scope.newTodo = '';
            }
        };

        //http://stackoverflow.com/questions/29768009/how-to-install-underscore-js-in-my-angular-application
        
        $scope.removeTodo = function(todo){
           _.remove($scope.todos, function(t){
               return t.description == todo.description;
           });
        };
        
        
        $scope.$watch('todos', function () {
           // alert('watch');
        });
    }]);
    
})();