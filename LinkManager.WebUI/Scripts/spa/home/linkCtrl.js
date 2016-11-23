(function() {
    angular
        .module("linkModule")
        .controller("linkController", linkController);

    linkController.$inject = ["$scope", "apiService"];

    function linkController($scope, apiService) {

        var controller = this;
        controller.linksData = [];
        controller.linkModel = {
            LinkID: "",
            OriginalString: "",
            CreatedDate: ""
        };
        controller.isAddMode = false;
        controller.isEditMode = false;
        controller.modalTitle = "";
        controller.canSave = false;

        // Fething records from the factory
        apiService.getLinks()
            .then(function successCallback(response) {
                    controller.linksData = response.data;
                },
                function errorCallback(response) {
                    console.log("[LinkController] GET - Fail", arguments);
                });

        controller.isValidLinkString = function() {
            return (angular.isString(controller.linkModel.OriginalString) &&
                controller.linkModel.OriginalString.length >= 1 &&
                controller.linkModel.OriginalString.length <= 3000);
        };

        controller.editMode = function(data) {
            if (controller.modalTitle === "Add") {
                addNew(data);
            } else if (controller.modalTitle === "Edit") {
                editLink(data);
            }
        };
        var addNew = function(data) {
            var link = {
                LinkID: null,
                OriginalString: data.OriginalString,
                CreatedDate: Date.now()
            };
            apiService
                .addLink(link)
                .then(function successCallback(response) {
                        clear();
                    },
                    function errorCallback(response) {
                        console.log("[LinkController] POST - Fail", arguments);
                    });
        };
        var editLink = function (data) {
            var link = data;
            apiService
                .updateLink(link)
                .then(function successCallback(response) {
                        clear();
                    },
                    function errorCallback(response) {
                        console.log("[LinkController] PUT - Fail", arguments);
                    });

        };
        var clear = function() {
            controller.linkModel = {
                LinkID: "",
                OriginalString: "",
                CreatedDate: ""
            };
            controller.linkModelString = "";
            controller.canSave = false;
            controller.isAddMode = false;
        };
        controller.cancelClick = function() {
            clear();
        }
        controller.openAddView = function() {
            controller.isAddMode = true;
            controller.modalTitle = "Add";
        };
        controller.openEditView = function(link) {
            controller.isAddMode = true;
            controller.modalTitle = "Edit";
            controller.linkModel = link;
            controller.canSave = false;
        };
        controller.removeLink = function(link) {
            console.log(link.OriginalString);
            apiService
                .removeLink(link)
                .then(function successCallback(response) {
                        console.log("DELETE Success");
                        angular.forEach(controller.linksData,
                            function(item, index) {
                                if (item.LinkID === response.data.LinkID) {
                                    controller.linksData.splice(index, 1);
                                }
                            });
                    },
                    function errorCallback(response) {
                        console.log("DELETE Fail");
                    });
        };
        $("#text-input")
            .on("propertychange change keyup paste input",
                function() {
                    if (controller.isValidLinkString()) {
                        controller.canSave = true;
                    }
                });
    }
})()