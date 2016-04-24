namespace Hiking.Services {
    export class TrailsService {

        public trailsResource;

        constructor( $resource: ng.resource.IResourceService ) {
            this.trailsResource = $resource( '/api/AddEditDeleteTrail/:id' );         
        }

        public getAllTrails() {
            return this.trailsResource.query();
        }
        public getOneTrail( id ) {
            return this.trailsResource.get( { id: id }).$promise;
        }
        public saveOneTrail( trails ) {
            console.log( trails );
            return this.trailsResource.save( trails ).$promise;

        }
        public deleteTrail( id ) {
            return this.trailsResource.remove( { id: id }).$promise;
        }
    }
    angular.module( "Hiking" ).service( "trailsService", TrailsService );
}
