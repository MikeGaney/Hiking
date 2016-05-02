namespace Hiking.Controllers {

    export class TrailsController
    {
        public search;
        public trails;

        constructor(private trailService: Hiking.Services.TrailService)
        {
            this.search = {};
            console.log("trails controller");
            this.trails = this.trailService.getTrails();
        }


        trailSearch() {

            console.log(this.search);
            this.trailService.searchTrails(this.search).then((data) => {
                this.trails = data;
                console.log(data);
            });

        }
    }

}