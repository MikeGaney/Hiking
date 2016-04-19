namespace Hiking.Controllers {

    export class ViewProfileController {
        public viewProfile;
        constructor(
            private profileService: Hiking.Services.ProfileService,
            private accountService: Hiking.Services.AccountService) {

            let id = this.accountService.getUserId();
            this.viewProfile = profileService.getProfile(id);
        }
    }
    export class EditProfileController {
        public editProfile;
        constructor(
            private profileService: Hiking.Services.ProfileService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            let profileId = this.$stateParams['id'];
            this.editProfile = this.profileService.getProfile(profileId);
        }
        save() {
            this.profileService.editProfile(this.editProfile).then(() => {
                this.$state.go('viewprofile', {'id':this.editProfile.id});
            })
        }
    }


}
