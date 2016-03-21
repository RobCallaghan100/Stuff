'use strict';

/**
 * @ngdoc service
 * @name stockDogApp.WatchlistService
 * @description
 * # WatchlistService
 * Service in the stockDogApp.
 */
angular.module('stockDogApp')
  .service('WatchlistService', function WatchlistService() {
    // AngularJS will instantiate a singleton by calling "new" on this function

    // Helper: load watchlists from localstorage
        var loadModel = function(){
            var model = {
                watchlists: localStorage['StockDog.watchlists'] ? JSON.parse(localStorage['StockDog.watchlists']) : [],
                nextId: localStorage['StockDog.nextId'] ? parseInt(localStorage['StockDog.nextId']) : 0
            };

            return model;
        };

        // Helper: Save watchlists to localStorage
        var saveModel = function(){
          localStorage['StockDog.watchlists'] = JSON.stringify(Model.watchlists);
            localStorage['StockDog.nextId'] = Model.nextId;
        };

        // Helper: use lodash to find a watchlist with give Id
        var findById = function(listId){
          return _.find(Model.watchlists, function(watchlist){
            return watchlist.id == parseInt(listId);
          });
        };

        // Return all watchlists or find by given id
        this.query = function(listId){

            if (listId){
                return findById(listId);
            } else {
                return Model.watchlists;
            }
        };

        // Save a new watchlist to watchlists model
        this.save = function(watchlist){
          watchlist.id = Model.nextId++;
            Model.watchlists.push(watchlist);
            saveModel();
        };

        // Remove given watchlist from watchlist model
        this.remove = function(watchlist){
            _.remove(Model.watchlists, function(list){
                return list.id === watchlist.id;
            });
            saveModel();
        };

        var Model = loadModel();
  });
