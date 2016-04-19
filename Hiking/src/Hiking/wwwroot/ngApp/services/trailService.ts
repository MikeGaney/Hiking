﻿namespace Hiking.Services {

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

    }

    angular.module("Hiking").service("trailService", TrailService);
        
}
