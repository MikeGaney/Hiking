namespace Hiking.Controllers {

    export class TrailsController
    {
        public search;
        public trails;
        public tenTrails;
        public currentPage = 1;
        public maxSize = 3;
        public numberOfAds = 0;

        constructor(private trailService: Hiking.Services.TrailService)
        {
            this.search = {};
            console.log("trails controller");
            this.trails = this.trailService.getTrails();

            console.log(this.currentPage);
            this.trailService.getTrailsShortList(this.currentPage).$promise.then((data) => {

                this.numberOfAds = this.trails.length;
                this.tenTrails = data;
                console.log(this.numberOfAds);
            });

            
        }


        trailSearch() {

            console.log(this.search);
            this.trailService.searchTrails(this.search).then((data) => {
                this.trails = data;
                console.log(data);
            });

        }

        setPage(pageNo) {

            this.currentPage = pageNo;

        }

        nextPage() {

            this.tenTrails = this.trailService.getTrailsShortList(this.currentPage);

        }


    }

}