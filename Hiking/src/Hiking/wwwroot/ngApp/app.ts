namespace Hiking {

    angular.module('Hiking', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: Hiking.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('trails', {
                url: '/trails',
                templateUrl: '/ngApp/views/trails.html',
                controller: Hiking.Controllers.TrailsController,
                controllerAs: 'controller'
            })
            .state('trailDetail', {
                url: '/trailDetail/:id',
                templateUrl: '/ngApp/views/trailDetail.html',
                controller: Hiking.Controllers.TrailDetailsController,
                controllerAs: 'controller'
            })
            .state( 'changes', {
                url: '/changes/:id?',
                templateUrl: '/ngApp/views/AddEditDeleteTrail.html',
                controller: Hiking.Controllers.AddEditDeleteTrailClientController,
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
                url: '/editprofile/:id',
                templateUrl: '/ngApp/Users/views/EditProfile.html',
                controller: Hiking.Controllers.EditProfileController,
                controllerAs: 'controller'
            })
            .state('mytrails', {
                url: '/mytrails/:id',
                templateUrl: '/ngApp/Users/views/myTrails.html',
                controller: Hiking.Controllers.MyTrailsController,
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

    
    angular.module('Hiking').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
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
        })
    );

    angular.module('Hiking').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
