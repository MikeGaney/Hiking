namespace Hiking.Controllers {

    export class ViewProfileController {
        public viewProfile;
        constructor(
            private profileService: Hiking.Services.ProfileService,
            private accountService: Hiking.Services.AccountService) {
            this.GetProfile();
            
        }

        GetProfile()
        {
            let id = this.accountService.getUserId();
            //console.log(id);
            this.profileService.getProfile(id).then((data) =>
            {
                this.viewProfile = data;
                //console.log(data);
            });
        }
    }
    export class EditProfileController {
        public editProfile;
        constructor(
            private profileService: Hiking.Services.ProfileService,
            private accountService: Hiking.Services.AccountService,
            private $state: ng.ui.IStateService) {
            this.GetProfile();
        }

        GetProfile()
        {
            let id = this.accountService.getUserId();
            //console.log(id);
            this.profileService.getProfile(id).then((data) =>
            {
                this.editProfile = data;
                //console.log(data);
            });
        }

        save() {
            this.profileService.editProfile(this.editProfile).then(() => {
                this.$state.go('viewprofile');
            })
        }
    }


}
