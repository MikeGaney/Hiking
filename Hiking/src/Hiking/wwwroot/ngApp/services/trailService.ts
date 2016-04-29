namespace Hiking.Services
{

    export class TrailService
    {
        public trailResource;


        constructor(private $resource: ng.resource.IResourceService)
        {
            this.trailResource = $resource('/api/trails/:id');
        }

        public getTrails()
        {
            //console.log("getting list of trails from server");
            return this.trailResource.query();
        }

        public getTrail(id) 
        {
            return this.trailResource.get({ id: id }).$promise;
        }

        public searchTrails(data) 
        {
            let searchResource = this.$resource('/api/trails/search');

            //console.log("getting search from server");
            //console.log(data);
            return searchResource.query(data).$promise;

        }

        public AddComment(data)
        {
            return this.trailResource.save(data).$promise;
        }

    }

    angular.module("Hiking").service("trailService", TrailService);

}
