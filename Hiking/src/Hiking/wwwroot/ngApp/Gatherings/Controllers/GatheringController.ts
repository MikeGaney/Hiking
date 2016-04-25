namespace Hiking.Controllers
{
    export class GatheringController
    {
        public gatherings;

        constructor(private gatheringService: Hiking.Services.GatheringService)
        {
            this.gatherings = this.gatheringService.GetAllGatherings();
        }
    }
}