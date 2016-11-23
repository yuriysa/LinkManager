(function () {
    angular
        .module('linkModule')
        .factory('apiService', linkService);

    linkService.$inject = ['$http'];

    function linkService($http) {
        var apiService = {
            getLinks: function() {
                return $http({
                    method: 'GET',
                    url: 'api/links'
                });
            },
            addLink: function(link) {
                return $http({
                    method: 'POST',
                    url: '/api/links',
                    data: link
                });
            },
            updateLink: function(link) {
                return $http({
                    method: 'PUT',
                    url: "/api/links",
                    data: link
                });
            },
            removeLink: function(link) {
                console.log('API DELETE ' + link.OriginalString);
                return $http({
                    method: 'DELETE',
                    url: '/api/links',
                    data: link,
                    headers: { 'Content-Type': 'application/json; charset=utf-8' }
                });
            }
        };
        return apiService;
    }
})()