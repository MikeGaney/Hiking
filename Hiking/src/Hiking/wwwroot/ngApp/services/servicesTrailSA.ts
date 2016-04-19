namespace Hiking.Services {
    export class TrailsService {

        public trailsResource;

        constructor( $resource: ng.resource.IResourceService ) {
            this.trailsResource = $resource( '/api/AddEditDeleteTrail/:id' );         
        }

        public getAllTrails() {
            return this.trailsResource.query();
        }
        public getOneTrail(id) {
            return this.trailsResource.get();
        }
    }
}
