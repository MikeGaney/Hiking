namespace Hiking.Controllers
{

    export class TrailDetailsController
    {
        public trail;
        //public ratingStates = [
        //    { stateOn: 'fa fa-star', stateOff: 'fa fa-star-o' }
        //];
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

        //getGatherUserName(id)
        //{
        //    console.log(id);
        //    //return this.accountService.getUserNameID(id);
        //}

        getWeather(lat, long)
        {
            var urlString = "http://api.openweathermap.org/data/2.5/forecast/daily?lat=" + lat + "&lon=" + long + "&appid=15304baae341183b29f7fd47ef7b2cf1";
            //this.weather = this.$http.get(urlString);
            //this.$http.get(urlString).then((data:any) =>
            //{
            //    this.weather = data;
            //    console.log(data);
            //});

            //this.weather = 'http://api.openweathermap.org/data/2.5/forecast/daily?lat=47.6493&lon=-121.6456&appid=15304baae341183b29f7fd47ef7b2cf1';
            //$.ajax({
            //    dataType: "jsonp",
            //    url: this.weather,
            //});
            //console.log(this.weather);

            //http://openweathermap.org/img/w/10d.png

            //$(document).ready(function ()
            //{
                $.getJSON(urlString, function (result)
                {
                    console.log("City: " + result.city.name);
                    console.log("Weather: " + result.list[0].weather[0].description);
                    console.log(result);
                }).then((result) =>
                {
                    this.weather = result;
                    console.log("weather");
                    console.log(this.weather);
                    //this.setWeather(result);
                });
            //});
            
        }

        //setWeather(data)
        //{
        //    this.weather = data;
        //    console.log("set weather");
        //    console.log(this.weather);
        //}

        public showWeatherModal()
        {
            console.log(this.weather);
            //console.log("Showing weather modal");
            this.$uibModal.open({
                templateUrl: '/ngApp/Trails/Views/TrailWeatherModal.html',
                controller: Hiking.Controllers.TrailWeatherController,
                controllerAs: 'controller',
                //size: "sm"
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
            console.log("getTrail()");
            var trailId = this.$stateParams['id'];
            this.trailsService.getOneTrail(trailId).then((data) =>
            {
                this.trail = data;
                this.getWeather(this.trail.latitude, this.trail.longitude);
                console.log(this.trail);
            });
        }

        AddToBackpack()
        {
            //console.log("AddToBackpack()");
            var trailId = this.$stateParams["id"];
            var userId = this.accountService.getUserId();
            //console.log(trailId);
            this.userTrail.ApplicationUserId = userId;
            this.userTrail.TrailId = trailId;
            this.backpackService.addToBackpack(this.userTrail).then(() =>
            {
                console.log("added to backpack");
            });
        }

        AddComment()
        {
            this.comment.userID = this.accountService.getUserId();
            this.comment.trailID = this.$stateParams["id"];
            console.log(this.comment);
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
            console.log(name);
            console.log(weather);
            var date = new Date();
            var day = date.getDay();
            console.log(day);
            for (var i = 0; i < this.days.length; i++)
            {
                //for (var j = 0; j < weather.length; j++)
                //{
                    this.sky[i] = { day: this.days[(i + day) % 7], weather: weather.list[i] };
                //}
            }
            console.log(this.sky);
        }

        getDegrees(num)
        {
            return (num * 9 / 5 - 459.67);
            //return num - 273.15;
        }

        public OK()
        {
            this.$uibModalInstance.close();
        }

    }
}

