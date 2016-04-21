namespace Hiking.Controllers {
    export class AddEditDeleteTrailClientController {
        public trails = {};
        constructor( private trailsService: Hiking.Services.TrailsService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService ) {
            this.getNewTrail();

        }
        getNewTrail() {
            let trailId = this.$stateParams["id"];

           this.trails= this.trailsService.getOneTrail( trailId );
        };

        addNewTrail() {
            console.log( "hello" );
            console.log( this.trails );
            this.trailsService.saveOneTrail( this.trails ).then(() => {
                this.$state.go( 'home' );
            });
        }


    }
}