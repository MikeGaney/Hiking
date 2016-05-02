namespace Hiking.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public center = { latitude: 47.671853, longitude: -122.121328 };
        public zoom = 15;


        public center1 = { latitude: 37.09024, longitude: -100.712891 };
        public zoom1 = 3;
        public markers = [
            {
                id: 0,
                options: {
                    title: 'Seattle Coder Camps',
                },
                //title: 'Seattle Coder Camps',
                //icon: '/coder-camps-logo.png',
                latitude: 47.671853,
                longitude: -122.121328,
            },
            {
                id: 1,
                options: {
                    title: 'Houston Coder Camps',
                },
                latitude: 29.552561,
                longitude: -95.395219
            },
            {
                id: 3,
                options: {
                    title: 'San Francisco Coder Camps',
                },
                latitude: 37.809499,
                longitude: -122.253665
            }
        ];

        //$(function() { });

        //$('div').click(function()
        //{
        //    $(this).animate({ height: '300' })
        //});

        public trails = false;
        public blogs = false;
        public gears = false;
        public treks = false;


        Trails()
        {
            console.log("Clicked trails");
            //$(this).animate({
            //    height: '300px',
            //    opacity: '0.4'
            //}, "slow");
        }

        Blogs()
        {
            console.log("Clicked blogs");

        }

        Gears()
        {
            console.log("Clicked gears");

        }

        Treks()
        {
            console.log("Clicked treks");

        }
    }

}
