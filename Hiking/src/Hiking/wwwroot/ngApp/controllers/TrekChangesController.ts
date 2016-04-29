namespace Hiking.Controllers {
    export class TrekChangesController {
        public trek;
        public trails;
        constructor( private treksService: Hiking.Services.TreksService, private trailsService: Hiking.Services.TrailsService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService,
            private $uibModal: angular.ui.bootstrap.IModalService, private accountService: Hiking.Services.AccountService )
        {
            this.trails = trailsService.getAllTrails();
            this.trek = {};
            this.getNewTrek();

        }
        getNewTrek() {
            let trekId = this.$stateParams["id"];
            this.treksService.getOneTrek( trekId ).then(( data ) => {
                this.trek = data;
                console.log( this.trek );
            });
        };
        saveTrek() {
            // first loop thru the trails
            for ( var i = 0; i < this.trails.length; i++ ) {
                // check if the Id of the trail matches the id you were given (this.trek.trailId)
                //console.log( this.trails[i] );
                if ( this.trails[i].id == this.trek.trailId ) {
                    this.trek.trailName = this.trails[i].name;
                }

            }

            console.log( this.trek );
            this.treksService.saveOneTrek( this.trek ).then(() => {
                this.$state.go( 'gatherings' );
            });
        }
        deleteTrek() {
            let trekId = this.$stateParams["id"];
            this.$uibModal.open( {
                templateUrl: '/Dialogs/DeleteTrekModal.html',
                controller: DialogController,
                controllerAs: 'modal',
                resolve: {
                    trekId: () => trekId
                },
                size: 'sm'
            }).result.then(() => {
                this.treksService.deleteTrek( trekId ).then(() => {
                    this.$state.go( 'gatherings' );
                });
            });
        }
    }
    class DialogController {
        public ok() {
            this.$uibModalInstance.close();
        }
        public cancel() {
            this.$uibModalInstance.dismiss();
        }
        constructor( public trekId: string, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance ) { }
    }
}

