namespace Hiking.Services {

    export class BackPackService {
        private MyTrailsResource;

        constructor(private $resource: ng.resource.IResourceService) 
        {
            this.MyTrailsResource = $resource('/api/backpack/:id');
        }
        public getMyTrail(id)
        {
            console.log("getMyTrail in MyTrailsService");
            return this.MyTrailsResource.get({ id: id }).$promise;
        }
        public getAllTrails()
        {
            return this.MyTrailsResource.query().$promise;
        }
        //public getShortTrailList() {
        //    console.log("I'm here.");
        //    return this.MyTrailsResource.query().$promise;          
        //}
        public removeMyTrail(del) { 
            let deleteMyTrailResource = this.$resource('/api/backpack/removeMyTrail');
            return deleteMyTrailResource.delete(del).$promise;
        }
        public getCompletedTrails() {
            let trailsCompleted = this.$resource('/api/backpack/completedTrail');
            return trailsCompleted.query().$promise;
        }
        public saveCompletedTrail(id) {
            let trailResource = this.$resource('/api/backpack/saveCompletedTrail');
            return trailResource.save(id).$promise;
        }
        public addToBackpack(data)
        {
            console.log("addToBackpack(id)");
            console.log(data);
            return this.MyTrailsResource.save(data).$promise;
        }
    }
    angular.module('Hiking').service('backpackService', BackPackService);
}