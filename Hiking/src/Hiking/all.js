var Hiking;
(function (Hiking) {
    angular.module('Hiking', ['ui.router', 'ngResource', 'ui.bootstrap']).config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
        // Define routes
        $stateProvider
            .state('home', {
            url: '/',
            templateUrl: '/ngApp/views/home.html',
            controller: Hiking.Controllers.HomeController,
            controllerAs: 'controller'
        })
            .state('secret', {
            url: '/secret',
            templateUrl: '/ngApp/views/secret.html',
            controller: Hiking.Controllers.SecretController,
            controllerAs: 'controller'
        })
            .state('login', {
            url: '/login',
            templateUrl: '/ngApp/views/login.html',
            controller: Hiking.Controllers.LoginController,
            controllerAs: 'controller'
        })
            .state('register', {
            url: '/register',
            templateUrl: '/ngApp/views/register.html',
            controller: Hiking.Controllers.RegisterController,
            controllerAs: 'controller'
        })
            .state('externalRegister', {
            url: '/externalRegister',
            templateUrl: '/ngApp/views/externalRegister.html',
            controller: Hiking.Controllers.ExternalRegisterController,
            controllerAs: 'controller'
        })
            .state('about', {
            url: '/about',
            templateUrl: '/ngApp/views/about.html',
            controller: Hiking.Controllers.AboutController,
            controllerAs: 'controller'
        })
            .state('viewprofile', {
            url: '/viewprofile',
            templateUrl: '/ngApp/Users/views/viewprofile.html',
            controller: Hiking.Controllers.ViewProfileController,
            controllerAs: 'controller'
        })
            .state('editprofile', {
            url: '/editprofile',
            templateUrl: '/ngApp/Users/views/EditProfile.html',
            controller: Hiking.Controllers.EditProfileController,
            controllerAs: 'controller'
        })
            .state('notFound', {
            url: '/notFound',
            templateUrl: '/ngApp/views/notFound.html'
        });
        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');
        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });
    angular.module('Hiking').factory('authInterceptor', function ($q, $window, $location) {
        return ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        });
    });
    angular.module('Hiking').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });
})(Hiking || (Hiking = {}));
/// <reference path="wwwroot/ngapp/app.ts" />
var Hiking;
(function (Hiking) {
    var Services;
    (function (Services) {
        var AccountService = (function () {
            function AccountService($q, $http, $window) {
                this.$q = $q;
                this.$http = $http;
                this.$window = $window;
                // in case we are redirected from a social provider
                // we need to check if we are authenticated.
                this.checkAuthentication();
            }
            // Store access token and claims in browser session storage
            AccountService.prototype.storeUserInfo = function (userInfo) {
                // store user name
                this.$window.sessionStorage.setItem('userName', userInfo.userName);
                this.$window.sessionStorage.setItem('displayName', userInfo.displayName);
                this.$window.sessionStorage.setItem('firstName', userInfo.firstName);
                this.$window.sessionStorage.setItem('lastName', userInfo.lastName);
                this.$window.sessionStorage.setItem('userId', userInfo.userId);
                // store claims
                this.$window.sessionStorage.setItem('claims', JSON.stringify(userInfo.claims));
            };
            AccountService.prototype.getUserName = function () {
                return this.$window.sessionStorage.getItem('userName');
            };
            AccountService.prototype.getUserId = function () {
                return this.$window.sessionStorage.getItem('userId');
            };
            AccountService.prototype.getClaim = function (type) {
                var allClaims = JSON.parse(this.$window.sessionStorage.getItem('claims'));
                return allClaims ? allClaims[type] : null;
            };
            AccountService.prototype.login = function (loginUser) {
                var _this = this;
                return this.$q(function (resolve, reject) {
                    _this.$http.post('/api/account/login', loginUser).then(function (result) {
                        _this.storeUserInfo(result.data);
                        resolve();
                    }).catch(function (result) {
                        var messages = _this.flattenValidation(result.data);
                        reject(messages);
                    });
                });
            };
            AccountService.prototype.register = function (userLogin) {
                var _this = this;
                return this.$q(function (resolve, reject) {
                    _this.$http.post('/api/account/register', userLogin)
                        .then(function (result) {
                        _this.storeUserInfo(result.data);
                        resolve(result);
                    })
                        .catch(function (result) {
                        var messages = _this.flattenValidation(result.data);
                        reject(messages);
                    });
                });
            };
            AccountService.prototype.logout = function () {
                // clear all of session storage (including claims)
                this.$window.sessionStorage.clear();
                // logout on the server
                return this.$http.post('/api/account/logout', null);
            };
            AccountService.prototype.isLoggedIn = function () {
                return this.$window.sessionStorage.getItem('userName');
            };
            // associate external login (e.g., Twitter) with local user account
            AccountService.prototype.registerExternal = function (email) {
                var _this = this;
                return this.$q(function (resolve, reject) {
                    _this.$http.post('/api/account/externalLoginConfirmation', { email: email })
                        .then(function (result) {
                        _this.storeUserInfo(result.data);
                        resolve(result);
                    })
                        .catch(function (result) {
                        // flatten error messages
                        var messages = _this.flattenValidation(result.data);
                        reject(messages);
                    });
                });
            };
            AccountService.prototype.getExternalLogins = function () {
                var _this = this;
                return this.$q(function (resolve, reject) {
                    var url = "api/Account/getExternalLogins?returnUrl=%2FexternalLogin&generateState=true";
                    _this.$http.get(url).then(function (result) {
                        resolve(result.data);
                    }).catch(function (result) {
                        reject(result);
                    });
                });
            };
            // checks whether the current user is authenticated on the server and returns user info
            AccountService.prototype.checkAuthentication = function () {
                var _this = this;
                this.$http.get('/api/account/checkAuthentication')
                    .then(function (result) {
                    if (result.data) {
                        _this.storeUserInfo(result.data);
                    }
                });
            };
            AccountService.prototype.confirmEmail = function (userId, code) {
                var _this = this;
                return this.$q(function (resolve, reject) {
                    var data = {
                        userId: userId,
                        code: code
                    };
                    _this.$http.post('/api/account/confirmEmail', data).then(function (result) {
                        resolve(result.data);
                    }).catch(function (result) {
                        reject(result);
                    });
                });
            };
            // extract access token from response
            AccountService.prototype.parseOAuthResponse = function (token) {
                var results = {};
                token.split('&').forEach(function (item) {
                    var pair = item.split('=');
                    results[pair[0]] = pair[1];
                });
                return results;
            };
            AccountService.prototype.flattenValidation = function (modelState) {
                var messages = [];
                for (var prop in modelState) {
                    messages = messages.concat(modelState[prop]);
                }
                return messages;
            };
            return AccountService;
        }());
        Services.AccountService = AccountService;
        angular.module('Hiking').service('accountService', AccountService);
    })(Services = Hiking.Services || (Hiking.Services = {}));
})(Hiking || (Hiking = {}));
var Hiking;
(function (Hiking) {
    var Services;
    (function (Services) {
        var ProfileService = (function () {
            function ProfileService($resource) {
                this.$resource = $resource;
                this.ProfileResource = $resource('/api/account/:id');
            }
            ProfileService.prototype.getProfile = function (id) {
                var getProfileResource = this.$resource('/api/account/getprofile');
                return getProfileResource.get({ id: id }).$promise;
            };
            ProfileService.prototype.editProfile = function (profileToEdit) {
                var editProfileResource = this.$resource('/api/account/editprofile');
                return editProfileResource.save(profileToEdit).$promise;
            };
            return ProfileService;
        }());
        Services.ProfileService = ProfileService;
        angular.module('Hiking').service('profileService', ProfileService);
    })(Services = Hiking.Services || (Hiking.Services = {}));
})(Hiking || (Hiking = {}));
var Hiking;
(function (Hiking) {
    var Controllers;
    (function (Controllers) {
        var AccountController = (function () {
            function AccountController(accountService, $location, $uibModal, $stateParams) {
                var _this = this;
                this.accountService = accountService;
                this.$location = $location;
                this.$uibModal = $uibModal;
                this.$stateParams = $stateParams;
                this.getExternalLogins().then(function (results) {
                    _this.externalLogins = results;
                });
                console.log("account controller");
            }
            AccountController.prototype.getUserName = function () {
                return this.accountService.getUserName();
            };
            AccountController.prototype.getUserID = function () {
                return this.accountService.getUserId();
            };
            AccountController.prototype.getClaim = function (type) {
                return this.accountService.getClaim(type);
            };
            AccountController.prototype.isLoggedIn = function () {
                return this.accountService.isLoggedIn();
            };
            AccountController.prototype.logout = function () {
                this.accountService.logout();
                this.$location.path('/');
            };
            AccountController.prototype.getExternalLogins = function () {
                return this.accountService.getExternalLogins();
            };
            AccountController.prototype.showRegisterModal = function () {
                console.log("Showing register modal");
                this.$uibModal.open({
                    templateUrl: '/ngApp/Users/views/register.html',
                    controller: Hiking.Controllers.RegisterController,
                    controllerAs: 'controller',
                    //size: "sm"
                    resolve: {}
                });
            };
            AccountController.prototype.showLoginModal = function () {
                //debugger;
                console.log("Showing login modal");
                this.$uibModal.open({
                    templateUrl: '/ngApp/Users/views/login.html',
                    controller: Hiking.Controllers.LoginController,
                    controllerAs: 'controller',
                    //size: "sm"
                    resolve: {}
                });
            };
            return AccountController;
        }());
        Controllers.AccountController = AccountController;
        angular.module('Hiking').controller('accountController', AccountController);
        var LoginController = (function () {
            function LoginController(accountService, $location, $uibModalInstance) {
                this.accountService = accountService;
                this.$location = $location;
                this.$uibModalInstance = $uibModalInstance;
            }
            LoginController.prototype.login = function () {
                var _this = this;
                this.accountService.login(this.loginUser).then(function () {
                    _this.$location.path('/');
                }).catch(function (results) {
                    _this.validationMessages = results;
                });
                this.OK();
            };
            LoginController.prototype.OK = function () {
                this.$uibModalInstance.close();
            };
            return LoginController;
        }());
        Controllers.LoginController = LoginController;
        var RegisterController = (function () {
            function RegisterController(accountService, $location, $uibModalInstance) {
                this.accountService = accountService;
                this.$location = $location;
                this.$uibModalInstance = $uibModalInstance;
            }
            RegisterController.prototype.register = function () {
                var _this = this;
                this.accountService.register(this.registerUser).then(function () {
                    _this.$location.path('/');
                }).catch(function (results) {
                    _this.validationMessages = results;
                });
                this.OK();
            };
            RegisterController.prototype.OK = function () {
                this.$uibModalInstance.close();
            };
            return RegisterController;
        }());
        Controllers.RegisterController = RegisterController;
        var ExternalRegisterController = (function () {
            function ExternalRegisterController(accountService, $location) {
                this.accountService = accountService;
                this.$location = $location;
            }
            ExternalRegisterController.prototype.register = function () {
                var _this = this;
                this.accountService.registerExternal(this.registerUser.email)
                    .then(function (result) {
                    _this.$location.path('/');
                }).catch(function (result) {
                    _this.validationMessages = result;
                });
            };
            return ExternalRegisterController;
        }());
        Controllers.ExternalRegisterController = ExternalRegisterController;
        var ConfirmEmailController = (function () {
            function ConfirmEmailController(accountService, $http, $stateParams, $location) {
                var _this = this;
                this.accountService = accountService;
                this.$http = $http;
                this.$stateParams = $stateParams;
                this.$location = $location;
                var userId = $stateParams['userId'];
                var code = $stateParams['code'];
                accountService.confirmEmail(userId, code)
                    .then(function (result) {
                    _this.$location.path('/');
                }).catch(function (result) {
                    _this.validationMessages = result;
                });
            }
            return ConfirmEmailController;
        }());
        Controllers.ConfirmEmailController = ConfirmEmailController;
    })(Controllers = Hiking.Controllers || (Hiking.Controllers = {}));
})(Hiking || (Hiking = {}));
var Hiking;
(function (Hiking) {
    var Controllers;
    (function (Controllers) {
        var HomeController = (function () {
            function HomeController() {
                this.message = 'Hello from the home page!';
            }
            return HomeController;
        }());
        Controllers.HomeController = HomeController;
        var SecretController = (function () {
            function SecretController($http) {
                var _this = this;
                $http.get('/api/secrets').then(function (results) {
                    _this.secrets = results.data;
                });
            }
            return SecretController;
        }());
        Controllers.SecretController = SecretController;
        var AboutController = (function () {
            function AboutController() {
                this.message = 'Hello from the about page!';
            }
            return AboutController;
        }());
        Controllers.AboutController = AboutController;
    })(Controllers = Hiking.Controllers || (Hiking.Controllers = {}));
})(Hiking || (Hiking = {}));
var Hiking;
(function (Hiking) {
    var Controllers;
    (function (Controllers) {
        var ViewProfileController = (function () {
            function ViewProfileController(profileService, accountService) {
                this.profileService = profileService;
                this.accountService = accountService;
                this.GetProfile();
            }
            ViewProfileController.prototype.GetProfile = function () {
                var _this = this;
                var id = this.accountService.getUserId();
                //console.log(id);
                this.profileService.getProfile(id).then(function (data) {
                    _this.viewProfile = data;
                    //console.log(data);
                });
            };
            return ViewProfileController;
        }());
        Controllers.ViewProfileController = ViewProfileController;
        var EditProfileController = (function () {
            function EditProfileController(profileService, accountService, $state) {
                this.profileService = profileService;
                this.accountService = accountService;
                this.$state = $state;
                this.editProfile = {};
                this.profileToSave = {};
                this.GetProfile();
            }
            EditProfileController.prototype.GetProfile = function () {
                var _this = this;
                var id = this.accountService.getUserId();
                //console.log(id);
                this.profileService.getProfile(id).then(function (data) {
                    _this.editProfile = data;
                    //console.log(data);
                });
            };
            EditProfileController.prototype.save = function () {
                var _this = this;
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
                this.profileService.editProfile(this.editProfile).then(function () {
                    _this.$state.go('viewprofile');
                });
            };
            return EditProfileController;
        }());
        Controllers.EditProfileController = EditProfileController;
    })(Controllers = Hiking.Controllers || (Hiking.Controllers = {}));
})(Hiking || (Hiking = {}));
//# sourceMappingURL=all.js.map