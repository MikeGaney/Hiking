namespace Hiking.Services {

    export class MyTrailsService {
        private MyTrailsResource;
        constructor(private $resource: ng.resource.IResourceService) {
            this.MyTrailsResource = $resource('api/mytrails/:id');
        }
        public getMyTrail(id) {
            return this.MyTrailsResource.get({ id: id }).$promise;
        }
        public removeMyTrail(trailId) { 
            let deleteProfileResource = this.$resource('/api/account/:id');
            return deleteProfileResource.delete({ id: trailId }).$promise;
        }
    }
    angular.module('Hiking').service('myTrailsService', MyTrailsService);
}