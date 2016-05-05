namespace Hiking.Services {

    export class BackPackService {
        private MyTrailsResource;

        constructor(private $resource: ng.resource.IResourceService) 
        {
            this.MyTrailsResource = $resource('/api/backpack/:id');
        }

        public getMyTrail(id)
        {
            return this.MyTrailsResource.get({ id: id }).$promise;
        }

        public getAllTrails()
        {
            return this.MyTrailsResource.query().$promise;
        }

        public removeMyTrail(del)
        { 
            let deleteMyTrailResource = this.$resource('/api/backpack/removeMyTrail');
            return deleteMyTrailResource.delete(del).$promise;
        }

        public getCompletedTrails()
        {
            let trailsCompleted = this.$resource('/api/backpack/completedTrail');
            return trailsCompleted.query().$promise;
        }

        public saveCompletedTrail(id)
        {
            let trailResource = this.$resource('/api/backpack/saveCompletedTrail');
            return trailResource.save(id).$promise;
        }

        public addToBackpack(data)
        {
            return this.MyTrailsResource.save(data).$promise;
        }

        public RateTrails(data)
        {
            let rateResource = this.$resource('/api/backpack/rateTrails');
            return rateResource.save(data).$promise;
        }

        // *** PAGINATION***

        public gettrlshortlist(num) 
        {
            let randomresource = this.$resource('/api/backpack/bkpkpage');
            return randomresource.query({ num: num }).$promise;
        }
    }
    angular.module('Hiking').service('backpackService', BackPackService);
}