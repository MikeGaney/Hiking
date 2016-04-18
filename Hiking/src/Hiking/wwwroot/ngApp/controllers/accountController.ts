namespace Hiking.Controllers {

    export class AccountController {
        public externalLogins;

        public getUserName() {
            return this.accountService.getUserName();
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
                //    //size: 'sm'
                }
            });
        }

        constructor(private accountService: Hiking.Services.AccountService, private $location: ng.ILocationService,
            private $uibModal: ng.ui.bootstrap.IModalService, private $stateParams: ng.ui.IStateParamsService) {
            this.getExternalLogins().then((results) => {
                this.externalLogins = results;
            });
                console.log("account controller");
        }
    }

    angular.module('Hiking').controller('AccountController', AccountController);


    export class LoginController {
        public loginUser;
        public validationMessages;

        public login() {
            this.accountService.login(this.loginUser).then(() => {
                this.$location.path('/');
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
                    private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) { }
    }


    export class RegisterController {
        public registerUser;
        public validationMessages;

        public register() {
            this.accountService.register(this.registerUser).then(() => {
                this.$location.path('/');
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
                    private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) { }
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
