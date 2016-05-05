namespace Hiking.Controllers
{
    export class GatheringController
    {
        public search;
        public gatherings;

        constructor(private gatheringService: Hiking.Services.GatheringService)
        {
            this.search = {};
            this.gatherings = this.gatheringService.GetAllGatherings();
        }

        trekSearch() 
        {
            this.gatheringService.searchTreks(this.search).then((data) => 
            {
                this.gatherings = data;
            });

        }
    }
}