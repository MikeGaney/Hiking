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
            this.trailService.getTrails().then((data) =>
            {
                this.numberOfAds = data.length;
            });
            this.getTrailListShort();
        }

        getTrailListShort()
        {
            this.trailService.getTrailsShortList(this.currentPage).then((data) =>
            {
                this.tenTrails = data;
            });
        }


        trailSearch() 
        {
            this.trailService.searchTrails(this.search).then((data) => {
                this.tenTrails = data;
            });
        }

        setPage(pageNo) 
        {
            this.currentPage = pageNo;
        }

        nextPage() 
        {
            this.trailService.getTrailsShortList(this.currentPage).then((data) =>
            {
                this.tenTrails = data;
            });
        }
    }
}