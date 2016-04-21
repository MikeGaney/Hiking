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
        public profileToSave;
        constructor(
            private profileService: Hiking.Services.ProfileService,
            private accountService: Hiking.Services.AccountService,
            private $state: ng.ui.IStateService)
        {
            this.editProfile = {};
            this.profileToSave = {};
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

        save()
        {
            console.log(this.editProfile);
            this.profileToSave = {
                firstName: this.editProfile.firstName,
                lastName: this.editProfile.lastName,
                age: this.editProfile.age,
                profilePic: this.editProfile.profilePic,
                bio: this.editProfile.bio,
                displayName: this.editProfile.displayName,
                expertise: this.editProfile.expertise
            };
            console.log(this.profileToSave);
            this.profileService.editProfile(this.editProfile).then(() => {
                this.$state.go('viewprofile');
            })
        }
    }


}
