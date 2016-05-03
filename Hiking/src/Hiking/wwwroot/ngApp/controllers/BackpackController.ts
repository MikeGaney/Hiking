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
            //console.log("hey");
            this.completedHikes = {};
            this.delete = {};
            this.completed = {};
            this.getBackPack();
            this.getCompletedTrails();
            this.search = {};
            
            //*** PAGINATION ***
            this.backpackService.getAllTrails().then((data) => {
                this.numberTrls = data.length;
                //console.log(this.numberTrls);
            });

            //console.log(this.bkpkCurrentPage);
            //this.backpackService.gettrlshortlist(this.bkpkCurrentPage).then((data) => {
            //    this.tenTrls = data;
            //    console.log(data);
            //});
            this.bkpkNextPage()

        }

        getMyTrail()
        {
            let trailId = this.$stateParams["id"];
            //console.log(id);
            this.backpackService.getMyTrail(trailId).then((data) => 
            {
                this.backpack = data;
                //console.log(data);
            });
        }

        getBackPack()
        {
            this.backpackService.getAllTrails().then((data) =>
            {
                this.backpack = data;
                //console.log(data);
            });
        }

        deleteMyTrail(id) 
        {
            this.delete.trailId = id;
            this.delete.applicationUserId = this.accountService.getUserId();
            //console.log(this.delete);
            //console.log(id);
            this.backpackService.removeMyTrail(this.delete).then(() =>
            {
                //console.log("Need to install confirmation modal.");
                this.$state.reload();
            });
        }

        saveCompletedTrail(id, name)
        {
            //let userId = this.accountService.getUserId();
            this.completed.trailId = id;
            this.completed.applicationUserId = this.accountService.getUserId();
            this.showRateModal(id, name);
            //this.backpackService.saveCompletedTrail(this.completed).then(() =>
            //{
            //    this.getCompletedTrails();
            //    this.getBackPack();
            //});
        }

        public showRateModal(id, name)
        {
            //console.log("Showing register modal");
            this.$uibModal.open({
                templateUrl: '/ngApp/Users/Views/rateTrail.html',
                controller: Hiking.Controllers.RateTrailController,
                controllerAs: 'controller',
                //size: "sm"
                resolve: {
                    id: () => id,
                    name: () => name
                }
            }).result.then(() =>
            {
                console.log("Test");
                this.backpackService.saveCompletedTrail(this.completed).then(() =>
                {
                    this.getCompletedTrails();
                    this.getBackPack();
                });
            });
            //    (() =>
            //{
            //    this.backpackService.saveCompletedTrail(this.completed).then(() =>
            //    {
            //        //this.getCompletedTrails();
            //        //this.getBackPack();
            //        console.log("test");
            //    });
            //}).catch(() =>
            //{
            //    console.log("Canceled");
            //});
        }

        getCompletedTrails()
        {
            this.backpackService.getCompletedTrails().then((data) =>
            {
                this.completedHikes = data;
                //console.log(data);
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

        //trailSearch() {

        //    console.log(this.search);
        //    this.trailService.searchTrails(this.search).then((data) => {
        //        this.trails = data;
        //        console.log(data);
        //    });
        //};
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
            //console.log(this.rate);
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