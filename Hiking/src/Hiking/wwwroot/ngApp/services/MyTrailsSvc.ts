namespace Hiking.Services {

    export class MyTrailsService {
        private MyTrailsResource;
        constructor(private $resource: ng.resource.IResourceService) {
            this.MyTrailsResource = $resource('api/mytrails/:id');
        }

    }
}