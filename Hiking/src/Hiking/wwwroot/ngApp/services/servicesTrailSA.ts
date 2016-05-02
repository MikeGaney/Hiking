namespace Hiking.Services {
    export class TrailsService {

        public trailsResource;

        constructor(private $resource: ng.resource.IResourceService) 
        {
            this.trailsResource = $resource( '/api/AddEditDeleteTrail/:id' );         
        }

        public getAllTrails() 
        {
            return this.trailsResource.query();
        }

        public getMapTrails()
        {
            let mapResource = this.$resource('/api/AddEditDeleteTrail/map');
            return mapResource.query().$promise;
        }

        public getSearchMapTrails(area)
        {
            let searchResource = this.$resource('/api/AddEditDeleteTrail/searchMap');
            return searchResource.query({ area: area }).$promise;
        }

        public getOneTrail(id) 
        {
            return this.trailsResource.get( { id: id }).$promise;
        }

        public saveOneTrail(trails) 
        {
            console.log( trails );
            return this.trailsResource.save( trails ).$promise;

        }

        public deleteTrail(id) 
        {
            return this.trailsResource.remove( { id: id }).$promise;
        }

        public AddComment(data)
        {
            let commentResource = this.$resource('/api/AddEditDeleteTrail/addComment');
            return commentResource.save(data).$promise;
        }
    }
    angular.module( "Hiking" ).service( "trailsService", TrailsService );
}
