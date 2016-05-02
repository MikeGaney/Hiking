namespace Hiking.Services {

    export class ProfileAccountService {
        private ProfileAccountResource;
        constructor(private $resource: ng.resource.IResourceService) {
            this.ProfileAccountResource = $resource('/api/profiles/:id');
        }

        getProfiles() {
            return this.ProfileAccountResource.query();
        }

        getProfile(id) {
            let getProfileResource = this.$resource('/api/account/getprofile');
            return getProfileResource.get({ id: id }).$promise;
        }

        editProfile(profileToEdit) {
            let editProfileResource = this.$resource('/api/account/editprofile');
            return editProfileResource.save(profileToEdit).$promise;
        }
        deleteProfile(profileId) { //MH
            let deleteProfileResource = this.$resource('/api/account/:id');
            return deleteProfileResource.delete({ id: profileId }).$promise;
        }

    }
    angular.module('Hiking').service('profileAccountService', ProfileAccountService);
}