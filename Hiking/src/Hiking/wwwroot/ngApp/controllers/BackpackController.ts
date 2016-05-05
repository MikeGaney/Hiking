namespace Hiking.Controllers
{
    export class BackPackController
    {
        public backpack;
        public delete;
        public completed;
        public completedHikes;
        public search;
        public trails;
        public tenTrls;
        public bkpkCurrentPage = 1;
        public maxSize = 3;
        public numberTrls = 0;


        constructor(
            private backpackService: Hiking.Services.BackPackService,
            private trailsService: Hiking.Services.TrailService,
            private $stateParams: ng.ui.IStateParamsService,
            private accountService: Hiking.Services.AccountService,
            private $state: ng.ui.IStateService,
            private $uibModal: ng.ui.bootstrap.IModalService,
            private trailService: Hiking.Services.TrailService) 
        {
            this.completedHikes = {};
            this.delete = {};
            this.completed = {};
            this.getBackPack();
            this.getCompletedTrails();
            this.search = {};
            
            //*** PAGINATION ***
            this.backpackService.getAllTrails().then((data) => {
                this.numberTrls = data.length;
            });

            this.bkpkNextPage()
        }

        getMyTrail()
        {
            let trailId = this.$stateParams["id"];
            this.backpackService.getMyTrail(trailId).then((data) => 
            {
                this.backpack = data;
            });
        }

        getBackPack()
        {
            this.backpackService.getAllTrails().then((data) =>
            {
                this.backpack = data;
            });
        }

        deleteMyTrail(id) 
        {
            this.delete.trailId = id;
            this.delete.applicationUserId = this.accountService.getUserId();
            this.backpackService.removeMyTrail(this.delete).then(() =>
            {
                this.$state.reload();
            });
        }

        saveCompletedTrail(id, name)
        {
            this.completed.trailId = id;
            this.completed.applicationUserId = this.accountService.getUserId();
            this.showRateModal(id, name);
        }

        public showRateModal(id, name)
        {
            this.$uibModal.open({
                templateUrl: '/ngApp/Users/Views/rateTrail.html',
                controller: Hiking.Controllers.RateTrailController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,
                    name: () => name
                }
            }).result.then(() =>
            {
                this.backpackService.saveCompletedTrail(this.completed).then(() =>
                {
                    this.getCompletedTrails();
                    this.getBackPack();
                });
            });
        }

        getCompletedTrails()
        {
            this.backpackService.getCompletedTrails().then((data) =>
            {
                this.completedHikes = data;
            });
        };


        //*** PAGINATION
        setPage(pageNo) {
            this.bkpkCurrentPage = pageNo;
        }

        bkpkNextPage() {
            this.backpackService.gettrlshortlist(this.bkpkCurrentPage).then((data) => {
                this.tenTrls = data;
            });
        }
        //*** END PAGINATION

    }

    export class RateTrailController
    {
        public trailId;
        public trailName;
        public rate;
        public max = 5;

        constructor(private id, private name, private backpackService: Hiking.Services.BackPackService,
                    private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private $state: ng.ui.IStateService)
        {
            this.trailId = id;
            this.trailName = name;
            this.rate = {};
        }

        public OK()
        {
            this.rate.trailId = this.trailId;
            this.backpackService.RateTrails(this.rate).then(() =>
            {
                this.$uibModalInstance.close();
            });
        }

        public Cancel()
        {
            this.$uibModalInstance.dismiss(null);
        }


    }
} 