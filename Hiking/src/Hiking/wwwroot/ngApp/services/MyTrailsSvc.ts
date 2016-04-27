namespace Hiking.Services {

    export class MyTrailsService {
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
        public removeMyTrail(trailId) { 
            let deleteProfileResource = this.$resource('/api/account/:id');
            return deleteProfileResource.delete({ id: trailId }).$promise;
        }
    }
    angular.module('Hiking').service('myTrailsService', MyTrailsService);
}