namespace Hiking.Controllers
{
    export class GatheringDetailsController
    {
        public gather;
        public data;
        public userInGather;

        constructor(private gatheringService: Hiking.Services.GatheringService, private $stateParams: ng.ui.IStateParamsService,
                    private accountService: Hiking.Services.AccountService, private $state: ng.ui.IStateService)
        {
            this.gather = {};
            this.data = {};
            this.GetGather();
            this.userInGather = false;
            this.IsUserInGathering();
        }

        GetGather()
        {
            let id = this.$stateParams["id"];
            this.gather = this.gatheringService.GetOneGathering(id);
        }

        IsUserInGathering()
        {
            let user = this.accountService.getUserId();
            this.data.userID = user;
            this.data.gatherID = this.$stateParams["id"];
            this.gatheringService.IsUserInGathering(this.data).then((data) =>
            {
                //console.log(data);
                this.userInGather = data.check;
                //console.log(this.userInGather);
            });
        }

        IsLoggedIn()
        {
            //console.log(this.accountService.isLoggedIn());
            return this.accountService.isLoggedIn();
        }

        AddToGathering()
        {
            let user = this.accountService.getUserId();
            this.data.userID = user;
            this.data.gatherID = this.$stateParams["id"];
            this.gatheringService.AddToGathering(this.data).then(() =>
            {
                this.$state.reload();
            });
        }

        RemoveFromGathering()
        {
            let user = this.accountService.getUserId();
            this.data.userID = user;
            this.data.gatherID = this.$stateParams["id"];
            this.gatheringService.RemoveFromGathering(this.data).then(() =>
            {
                this.$state.reload();
            });
        }
    }
}