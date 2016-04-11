(function(){
    
    "use strict";
    
    var app = angular.module('todoApp', ['lodash']);
    
    
    app.controller('todoCtrl', [ '$scope', '_', function($scope, _){
        
        $scope.todos = [];
        
        $scope.AddTodo = function(value){
            
            if (value){
                var newTodo = { 'description':value, 'completed':false };
                $scope.todos.push(newTodo);
                $scope.newTodo = '';
            }
        };

        //http://stackoverflow.com/questions/29768009/how-to-install-underscore-js-in-my-angular-application
        
        
        $scope.$watch('todos', function(){
           // alert('watch');
        });
    }]);
    
})();