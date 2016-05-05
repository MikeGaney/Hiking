namespace Hiking.Controllers {

    export class AccountController {
        public externalLogins;

        public getUserName() {
            return this.accountService.getUserName();
        }

        public getUserID()
        {
            return this.accountService.getUserId();
        }

        public getFirstName()
        {
            let name = this.accountService.getFirstName();
            if (name == "null")
            {
                name = "";
            }
            return name;
        }

        public getName()
        {
            let name = this.accountService.getFirstName();
            if (name == "null")
            {
                name = this.accountService.getDisplayName();
            }
            return name;
        }

        public getClaim(type) {
            return this.accountService.getClaim(type);
        }

        public isLoggedIn() {
            return this.accountService.isLoggedIn();
        }

        public logout() {
            this.accountService.logout();

            this.$location.path('/');
        }

        public getExternalLogins() {
            return this.accountService.getExternalLogins();
        }

        public showRegisterModal()
        {
            console.log("Showing register modal");
            this.$uibModal.open({
                templateUrl: '/ngApp/Users/views/register.html',
                controller: Hiking.Controllers.RegisterController,
                controllerAs: 'controller',
                //size: "sm"
                resolve: {
                //    //size: 'sm'
                }
            });
        }

        public showLoginModal()
        {
            //debugger;
            console.log("Showing login modal");
            this.$uibModal.open({
                templateUrl: '/ngApp/Users/views/login.html',
                controller: Hiking.Controllers.LoginController,
                controllerAs: 'controller',
                //size: "sm"
                resolve: {
                //size: 'sm'
                }
            });
        }

        constructor(private accountService: Hiking.Services.AccountService, private $location: ng.ILocationService,
            private $uibModal: ng.ui.bootstrap.IModalService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            this.getExternalLogins().then((results) => {
                this.externalLogins = results;
            });
                //console.log("account controller");
        }
    }

    angular.module('Hiking').controller('accountController', AccountController);


    export class LoginController {
        public loginUser;
        public validationMessages;

        public login() {
            this.accountService.login(this.loginUser).then(() => {
                //this.$location.path('/');
                this.$state.reload();
            }).catch((results) => {
                this.validationMessages = results;
                });
            this.OK();
        }

        public OK()
        {
            this.$uibModalInstance.close();
        }

        public ForgotPasword()
        {
            this.showForgotPasswordModal();
            this.OK();
        }

        public showForgotPasswordModal()
        {
            //debugger;
            console.log("Showing forgotPassword modal");
            this.$uibModal.open({
                templateUrl: '/ngApp/Users/Views/forgotPassword.html',
                controller: Hiking.Controllers.ForgotPasswordController,
                controllerAs: 'controller',
                //size: "sm"
                resolve: {
                    //    //size: 'sm'
                }
            });
        }

        constructor(private accountService: Hiking.Services.AccountService, private $location: ng.ILocationService,
            private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private $state: ng.ui.IStateService,
            private $uibModal: ng.ui.bootstrap.IModalService) { }
    }

    export class ForgotPasswordController
    {
        public password;

        public OK()
        {
            this.$uibModalInstance.close();
        }

        public ChangePassword()
        {
            this.accountService.ChangePassword(this.password);
        }

        constructor(private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private accountService: Hiking.Services.AccountService)
        {
            this.password = {};
        }
    }

    export class RegisterController {
        public registerUser;
        public validationMessages;

        public register() {
            this.accountService.register(this.registerUser).then(() => {
                //this.$location.path('/');
                this.$state.go('viewprofile');
            }).catch((results) => {
                this.validationMessages = results;
                });
            this.OK();
        }

        public OK()
        {
            this.$uibModalInstance.close();
        }

        constructor(private accountService: Hiking.Services.AccountService, private $location: ng.ILocationService,
                    private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private $state: ng.ui.IStateService) { }
    }





    export class ExternalRegisterController {
        public registerUser;
        public validationMessages;

        public register() {
            this.accountService.registerExternal(this.registerUser.email)
                .then((result) => {
                    this.$location.path('/');
                }).catch((result) => {
                    this.validationMessages = result;
                });
        }

        constructor(private accountService: Hiking.Services.AccountService, private $location: ng.ILocationService) {}

    }

    export class ConfirmEmailController {
        public validationMessages;

        constructor(
            private accountService: Hiking.Services.AccountService,
            private $http: ng.IHttpService,
            private $stateParams: ng.ui.IStateParamsService,
            private $location: ng.ILocationService
        ) {
            let userId = $stateParams['userId'];
            let code = $stateParams['code'];
            accountService.confirmEmail(userId, code)
                .then((result) => {
                    this.$location.path('/');
                }).catch((result) => {
                    this.validationMessages = result;
                });
        }
    }

}
