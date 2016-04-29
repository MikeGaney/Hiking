namespace Hiking.Services {
    export class TreksService {
        public treksService;
        constructor( $resource: ng.resource.IResourceService ) {
            this.treksService = $resource( '/api/gathering/:id' );

        }
        public getAllTreks() {
            return this.treksService.query();
        }
        public getOneTrek( id ) {
            return this.treksService.get( { id: id }).$promise;
        }
        public saveOneTrek( treks ) {
            console.log( treks );
            return this.treksService.save( treks ).$promise;
        }
        public deleteTrek( id ) {
            return this.treksService.remove( { id: id }).$promise;
        }
    }
    angular.module( "Hiking" ).service( "treksService", TreksService );
}