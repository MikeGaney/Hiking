namespace Hiking.Services {
    export class TrailsService {

        public trailsResource;
        public accountResource;

        constructor(private $resource: ng.resource.IResourceService) 
        {
            this.trailsResource = this.$resource('/api/AddEditDeleteTrail/:id', null, { searchMap: { url: "/api/AddEditDeleteTrail/searchMap/:area", isArray: true }, backpack: { url: "/api/AddEditDeleteTrail/backpack/:id", isArray: false } });
        }

        public getUserName(id)
        {
            return this.accountResource.getDisplayName({ id: id });
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
            return this.trailsResource.searchMap({ area: area }).$promise;
        }

        public checkBackpack(id)
        {
            return this.trailsResource.backpack({ id: id }).$promise;
        }

        public getOneTrail(id) 
        {
            return this.trailsResource.get( { id: id }).$promise;
        }

        public saveOneTrail(trails) 
        {
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
    angular.module("Hiking").service("trailsService", TrailsService);
}
