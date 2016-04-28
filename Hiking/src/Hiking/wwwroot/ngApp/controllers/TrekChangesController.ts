namespace Hiking.Controllers {
    export class TrekChangesController {
        public treks = {};
        constructor( private treksService: Hiking.Services.TreksService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService, private $uiModal: angular.ui.bootstrap.IModalService ) {
            this.getNewTrek();

        }
        getNewTrek() {
            let trekId = this.$stateParams["id"];
            this.treksService.getOneTrek( trekId ).then(( data ) => {
                this.treks = data;
            });
        };
        addNewTrek() {
            console.log( this.treks );
            this.treksService.saveOneTrek( this.treks ).then(() => {
                this.$state.go( 'home' );
            });
        }
        deleteTrek() {
            let trekId = this.$stateParams["id"];
            this.$uiModal.open( {
                templateUrl: '/Dialogs/DeleteTrekModal.html',
                controller: DialogController,
                controllerAs: 'modal',
                resolve: {
                    trekId: () => trekId
                },
                size: 'sm'
            }).result.then(() => {
                this.treksService.deleteTrek( trekId ).then(() => {
                    this.$state.go( 'home' );
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

