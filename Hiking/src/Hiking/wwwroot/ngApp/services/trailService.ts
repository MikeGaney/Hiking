namespace Hiking.Services {

    export class TrailService {
        public trailResource;


        constructor(private $resource: ng.resource.IResourceService)
        {
            this.trailResource = $resource('/api/trails/:id');
        }

        public getTrails()
        {
            console.log("getting list of trails from server");
            return this.trailResource.query();
        }

       public getTrail(id) {
            return this.trailResource.get({ id: id });

        }

       public searchTrails(data) {
           let searchResource = this.$resource('/api/trails/search');

           //var test = { name: "falls", location: "a", diffivultyLevel: 3, camping: true, biking: true, fishing: true, horses: true, waterfalls: true, rivers: true, lakes: true, lookouts: true, rating: 4 };
           console.log("getting search from server");
           console.log(data);
           return searchResource.query(data).$promise;

       }

    }

    angular.module("Hiking").service("trailService", TrailService);

}
