namespace Hiking.Controllers
{

    export class TrailDetailsController
    {
        public trail;
        public userTrail;
        public comment;
        public backpack;
        public weather;
        public userName = [];

        constructor(private trailsService: Hiking.Services.TrailsService, private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService, private backpackService: Hiking.Services.BackPackService, private accountService: Hiking.Services.AccountService, private $uibModal: ng.ui.bootstrap.IModalService)
        {
            this.comment = {};
            this.userTrail = {};
            this.backpack = {};
            this.weather = {};
            this.checkBackpack();
            this.getTrail();
        }

        getWeather(lat, long)
        {
            var urlString = "http://api.openweathermap.org/data/2.5/forecast/daily?lat=" + lat + "&lon=" + long + "&appid=15304baae341183b29f7fd47ef7b2cf1";

            $.getJSON(urlString, function (result)
            {
            }).then((result) =>
            {
                this.weather = result;
            });

        }

        public showWeatherModal()
        {
            this.$uibModal.open({
                templateUrl: '/ngApp/Trails/Views/TrailWeatherModal.html',
                controller: Hiking.Controllers.TrailWeatherController,
                controllerAs: 'controller',
                size: "sm",
                resolve: {
                    name: () => this.trail.name,
                    weather: () => this.weather
                }
            });
        }

        checkBackpack()
        {
            var trailId = this.$stateParams['id'];
            this.trailsService.checkBackpack(trailId).then((data) =>
            {
                this.backpack = data;
            });
        }

        getUserName()
        {
            return this.accountService.getUserName();
        }

        getTrail()
        {
            var trailId = this.$stateParams['id'];
            this.trailsService.getOneTrail(trailId).then((data) =>
            {
                this.trail = data;
                this.getWeather(this.trail.latitude, this.trail.longitude);
            });
        }

        AddToBackpack()
        {
            var trailId = this.$stateParams["id"];
            var userId = this.accountService.getUserId();
            this.userTrail.ApplicationUserId = userId;
            this.userTrail.TrailId = trailId;
            this.backpackService.addToBackpack(this.userTrail).then(() =>
            {
                this.$state.reload();
            });
        }

        AddComment()
        {
            this.comment.userID = this.accountService.getUserId();
            this.comment.trailID = this.$stateParams["id"];
            this.trailsService.AddComment(this.comment).then(() =>
            {
                this.getTrail();
            });
        }

    }

    export class TrailWeatherController
    {
        public weatherIcon = "http://openweathermap.org/img/w/";
        public days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
        public sky = [];

        constructor(private $location: ng.ILocationService, private name, private weather,
            private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private $state: ng.ui.IStateService)
        {
            var date = new Date();
            var day = date.getDay();
            for (var i = 0; i < this.days.length; i++)
            {
                this.sky[i] = { day: this.days[(i + day) % 7], weather: weather.list[i] };
            }
        }

        getDegrees(num)
        {
            return (num * 9 / 5 - 459.67);
        }

        public OK()
        {
            this.$uibModalInstance.close();
        }

    }
}

