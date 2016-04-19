namespace Hiking.Controllers {

    export class TrailsController {
        public trails;

        constructor(private trailService: Hiking.Services.TrailService)
        {
            this.trails = this.trailService.getTrails();
        }
    }

}