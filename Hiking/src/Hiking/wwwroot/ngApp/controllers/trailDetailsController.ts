namespace Hiking.Controllers {

    export class TrailDetailsController {
        public trail;
        public ratingStates = [
            { stateOn: 'fa fa-star', stateOff: 'fa fa-star-o' }
        ];

        constructor(private trailsService: Hiking.Services.TrailsService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {

            this.getTrail();

        }

        getTrail() {

            var trailId = this.$stateParams['id'];
            this.trailsService.getOneTrail(trailId).then((data) =>
            {
                this.trail = data;
                console.log(this.trail);
            });

        }

        }

    }

