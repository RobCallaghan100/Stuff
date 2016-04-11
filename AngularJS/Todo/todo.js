(function(){
    
    "use strict";
    
    var app = angular.module('todoApp', []);
    
    
    app.controller('todoCtrl', function($scope){
        
        $scope.todos = [];
        
        $scope.AddTodo = function(value){
            
            if (value){
                var newTodo = { 'description':value, 'completed':false };
                $scope.todos.push(newTodo);
                $scope.newTodo = '';
            }
        };

        
        
        $scope.$watch('todos', function(){
           // alert('watch');
        });
    });
    
})();