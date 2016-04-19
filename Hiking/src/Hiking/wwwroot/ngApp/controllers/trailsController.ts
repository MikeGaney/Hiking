namespace Hiking.Controllers {

    export class TrailsController {
        public trails;

        constructor(private trailService: Hiking.Services.TrailService)
        {
            console.log("trails controller");
            this.trails = this.trailService.getTrails();
        }
    }

}