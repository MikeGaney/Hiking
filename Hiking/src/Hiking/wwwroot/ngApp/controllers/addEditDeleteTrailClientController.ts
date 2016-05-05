﻿namespace Hiking.Controllers 
{
    export class AddEditDeleteTrailClientController
    {
        public trails = {};
        constructor(private trailsService: Hiking.Services.TrailsService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService, private $uibModal: angular.ui.bootstrap.IModalService) 
        {
            this.getNewTrail();
        }

        getNewTrail()
        {
            let trailId = this.$stateParams["id"];
            this.trailsService.getOneTrail(trailId).then((data) =>
            {
                this.trails = data;
            });
        };

        addNewTrail()
        {
            this.trailsService.saveOneTrail(this.trails).then(() =>
            {
                this.$state.go('trails');
            });
        }

        deleteTrail()
        {
            let trailId = this.$stateParams["id"];
            this.$uibModal.open({
                templateUrl: '/Dialogs/DeleteTrailModal.html',
                controller: DialogController,
                controllerAs: 'modal',
                resolve: {
                    trailId: () => trailId
                },
            }).result.then(() =>
            {
                this.trailsService.deleteTrail(trailId).then(() =>
                {
                    this.$state.go('trails');
                });
            });
        }
    }


    class DialogController
    {
        public ok()
        {
            this.$uibModalInstance.close();
        }

        public cancel()
        {
            this.$uibModalInstance.dismiss();
        }

        constructor(public trailId: string, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) { }
    }

}
