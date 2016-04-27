namespace Hiking.Controllers {
    export class MyTrailsController {
        public myTrails;

        constructor(
            private myTrailsService: Hiking.Services.MyTrailsService,
            private trailsService: Hiking.Services.TrailService,
            private $stateParams: ng.ui.IStateParamsService) {
            this.getMyTrail();
        }
        getMyTrail() {
            let trailId = this.$stateParams["id"];
            //console.log(id);
            this.myTrailsService.getMyTrail(trailId).then((data) => {
                this.myTrails = data;
                //console.log(data);
            });
        }
        deleteMyTrail() {
                let myTrailToDelete = this.$stateParams["id"];
                this.myTrailsService.removeMyTrail(myTrailToDelete).then(() => {
                    console.log("Need to install confirmation modal.");
                });
        }

    }
} 