namespace Hiking.Controllers
{
    export class GatheringController
    {
        public search;
        public gatherings;

        constructor(private gatheringService: Hiking.Services.GatheringService)
        {
            this.search = {};

            console.log("gathering controller");
            this.gatherings = this.gatheringService.GetAllGatherings();
        }

        trekSearch() {

            console.log(this.search);
            this.gatheringService.searchTreks(this.search).then((data) => {
                this.gatherings = data;
                console.log(data);
            });

        }
    }
}