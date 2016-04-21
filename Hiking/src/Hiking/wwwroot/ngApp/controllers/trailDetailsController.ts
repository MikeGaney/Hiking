namespace Hiking.Controllers {

    export class TrailDetailsController {
        public trail;

        constructor(private trailService: Hiking.Services.TrailService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {

            this.getTrail();

        }

        getTrail() {

            var trailId = this.$stateParams['id'];
            this.trail = this.trailService.getTrail(trailId);

        }

        }

    }

