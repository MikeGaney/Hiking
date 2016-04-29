namespace Hiking.Controllers
{

    export class TrailDetailsController
    {
        public trail;
        //public ratingStates = [
        //    { stateOn: 'fa fa-star', stateOff: 'fa fa-star-o' }
        //];
        public userTrail;
        public comment;

        constructor(private trailsService: Hiking.Services.TrailsService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService, private myTrailsService: Hiking.Services.MyTrailsService, private accountService: Hiking.Services.AccountService)
        {
            this.comment = {};
            this.userTrail = {};
            this.getTrail();
        }

        getTrail()
        {
            var trailId = this.$stateParams['id'];
            this.trailsService.getOneTrail(trailId).then((data) =>
            {
                this.trail = data;
                console.log(this.trail);
            });
        }

        AddToBackpack()
        {
            //console.log("AddToBackpack()");
            var trailId = this.$stateParams["id"];
            var userId = this.accountService.getUserId();
            //console.log(trailId);
            this.userTrail.ApplicationUserId = userId;
            this.userTrail.TrailId = trailId;
            this.backpackService.addToBackpack(this.userTrail).then(() =>
            {
                console.log("added to backpack");
            });
        }

        AddComment()
        {
            this.comment.userID = this.accountService.getUserId();
            this.comment.trailID = this.$stateParams["id"];
            console.log(this.comment);
            this.trailsService.AddComment(this.comment).then(() =>
            {
                this.getTrail();
            });
        }

        }

    }

