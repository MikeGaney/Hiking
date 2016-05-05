namespace Hiking.Services 
{

    export class ProfileService 
    {
        private ProfileResource;
        constructor(private $resource: ng.resource.IResourceService) 
        {
            this.ProfileResource = $resource('/api/account/:id');
        }
        
        getProfile(id) 
        {
            let getProfileResource = this.$resource('/api/account/getprofile');
            return getProfileResource.get({id:id}).$promise;
        }

        editProfile(profileToEdit) 
        {
            let editProfileResource = this.$resource('/api/account/editprofile');
            return editProfileResource.save(profileToEdit).$promise;
        }

        deleteProfile(profileId) 
        {
            let deleteProfileResource = this.$resource('/api/account/:id');
            return deleteProfileResource.delete({ id: profileId }).$promise;
        }
      
    }
    angular.module('Hiking').service('profileService', ProfileService);
}