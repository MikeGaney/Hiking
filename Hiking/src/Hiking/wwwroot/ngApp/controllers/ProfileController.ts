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
            private backpackService: Hiking.Services.BackPackService,
            private $state: ng.ui.IStateService,
            private profileAccountService: Hiking.Services.ProfileAccountService) 
        {
            this.GetProfile();
            this.completedHikes = {};
            this.getCompletedTrails();
            this.profiles = this.profileAccountService.getProfiles();
        }

        getUserName()
        {
            return this.accountService.getUserName();
        }

        addAdmin(id) 
        {
            this.accountService.addAdmin(id).then(() => {
                this.$state.reload();
            });
        }

        removeAdmin(id)
        {
            this.accountService.removeAdmin(id).then(() => {
                this.$state.reload();
            });
        }

        GetProfile() 
        {
            let id = this.accountService.getUserId();
            this.profileService.getProfile(id).then((data) => 
            {
                this.viewProfile = data;
                if (this.viewProfile.expertise == 0) {
                    this.viewProfile.expertise = "-";
                }
                if (this.viewProfile.age == 0) {
                    this.viewProfile.age = "-";
                }
            });
        }
        
        getCompletedTrails() 
        {
            this.backpackService.getCompletedTrails().then((data) => {
                this.completedHikes = data;
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
            this.profileService.getProfile(id).then((data) => 
            {
                this.editProfile = data;
            });
        }

        save() 
        {
            this.profileToSave = {
                firstName: this.editProfile.firstName,
                lastName: this.editProfile.lastName,
                age: this.editProfile.age,
                profilePic: this.editProfile.profilePic,
                bio: this.editProfile.bio,
                displayName: this.editProfile.displayName,
                expertise: this.editProfile.expertise
            };

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
               
            }).result.then(() => {
                    this.$state.go('home');
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
            private $state: ng.ui.IStateService,
            public profileId: string,
            private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) 
        {
        }

        public ok() 
        {
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




