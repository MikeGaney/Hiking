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
            this.trailService.getTrails().then((data) =>
            {
                this.numberOfAds = data.length;
            });

            
            this.getTrailListShort();
            
        }

        getTrailListShort()
        {
            console.log(this.currentPage);
            this.trailService.getTrailsShortList(this.currentPage).then((data) =>
            {
                this.trails = data;
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

            this.trails = this.trailService.getTrailsShortList(this.currentPage);

        }


    }

}