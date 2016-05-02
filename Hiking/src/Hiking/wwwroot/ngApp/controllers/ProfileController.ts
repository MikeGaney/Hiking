namespace Hiking.Controllers 
{

    export class ViewProfileController 
    {
        public viewProfile;
        public shortbackpack;
        public completedHikes;
        public profiles;

        constructor(
            private profileService: Hiking.Services.ProfileService,
            private accountService: Hiking.Services.AccountService,
            private profileAccountService: Hiking.Services.ProfileAccountService,
            private backpackService:Hiking.Services.BackPackService) 
        {
            this.GetProfile();
            //this.shortbackpack = {};
            //this.getShortTrailList();
            this.completedHikes = {};
            this.getCompletedTrails();

            this.profiles = this.profileAccountService.getProfiles();
        }

        GetProfile() 
        {
            let id = this.accountService.getUserId();
            //console.log(id);
            this.profileService.getProfile(id).then((data) => 
            {
                this.viewProfile = data;
                if (this.viewProfile.expertise == 0) {
                    this.viewProfile.expertise = "-";
                }
                if (this.viewProfile.age == 0) {
                    this.viewProfile.age = "-";
                }
                //console.log(data);
            });
        }
        //getShortTrailList() {
        //    //debugger;
        //    this.backpackService.getShortTrailList().then((data) => {
        //        this.shortbackpack = data;
        //        console.log(data);
        //    });
        //}
        getCompletedTrails() {
            this.backpackService.getCompletedTrails().then((data) => {
                this.completedHikes = data;
                //console.log(data);
            });
        }
    }

    export class EditProfileController 
    {
        public editProfile;
        public profileToSave;
        public profileToDelete;
        constructor(
            private profileService: Hiking.Services.ProfileService,
            private accountService: Hiking.Services.AccountService,
            private $state: ng.ui.IStateService,
            //private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
            private $stateParams: ng.ui.IStateParamsService,
            private $uibModal: angular.ui.bootstrap.IModalService) 
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
            this.profileService.editProfile(this.editProfile).then(() => 
            {
                this.$state.go('viewprofile');
            })
        }

        deleteProfile() 
        {
            let profileId = this.accountService.getUserId();
            this.$uibModal.open({
                templateUrl: '/ngApp/Users/Views/deleteModal.html',
                controller: DeleteController,
                controllerAs: 'modal',
                resolve: {
                    profileId: () => profileId
                },
                //size: 'sm'
            }).result.then(() => {
                this.profileService.deleteProfile(profileId).then(() => {
                    this.$state.go('trails');
                });
            });
        };

        ForgotPasword()
        {
            this.$uibModal.open({
                templateUrl: '/ngApp/Users/Views/forgotPassword.html',
                controller: Hiking.Controllers.ForgotPasswordController,
                controllerAs: 'controller',
                resolve: {
                    
                }
            });
        }


    }
    export class DeleteController 
    {
        constructor(
            private $window: ng.IWindowService,
            private accountService: Hiking.Services.AccountService,
            private profileService: Hiking.Services.ProfileService,
            public profileId: string,
            private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) 
        {
            console.log("heythere");
        }

        public ok() {
            this.profileService.deleteProfile(this.profileId).then(() => 
            {
                this.$window.sessionStorage.clear();
                this.$uibModalInstance.close();
            });
            
        }

        public cancel() 
        {
            this.$uibModalInstance.dismiss();
        }
    }

}




