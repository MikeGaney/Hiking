namespace Hiking.Services
{
    export class GatheringService
    {
        private gatherResource;

        constructor(private $resource: ng.resource.IResourceService)
        {
            this.gatherResource = $resource("/api/gathering/:id");
        }

        public GetAllGatherings()
        {
            return this.gatherResource.query();
        }

        public GetOneGathering(id)
        {
            return this.gatherResource.get({ id: id });
        }

        public SaveGathering(data)
        {
            return this.gatherResource.save(data).$promise;
        }

        public DeleteGathering(id)
        {
            return this.gatherResource.delete({ id: id }).$promise;
        }

        public AddToGathering(data)
        {
            let addResource = this.$resource("/api/gathering/addToGathering");
            return addResource.save(data).$promise;
        }

        public IsUserInGathering(data)
        {
            //console.log("IsUserInGathering");
            //console.log(data);
            let getResource = this.$resource("/api/gathering/isUserInGathering");
            return getResource.get(data).$promise;
        }

        public RemoveFromGathering(data)
        {
            let removeResource = this.$resource("/api/gathering/removeUserFromGathering");
            return removeResource.delete(data).$promise;
        }

        public searchTreks(data) {
            let searchResource = this.$resource('/api/gathering/search');

            console.log("getting trek search from server");
            console.log(data);
            return searchResource.query(data).$promise;

        }

    }
    angular.module("Hiking").service("gatheringService", GatheringService);
}