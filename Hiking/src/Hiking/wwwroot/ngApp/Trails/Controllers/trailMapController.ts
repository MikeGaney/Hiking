namespace Hiking.Controllers
{
    export class TrailMapController
    {
        public trails;
        public center = { latitude: 47.6000, longitude: -120.9800 };
        public zoom = 7;
        public location;
        public numOfTrails;
        public locCenter = {
            CW: { latitude: 47.4000, longitude: -120.9800 },
            EW: { latitude: 48.0000, longitude: -120.2000 },
            NC: { latitude: 48.0000, longitude: -120.9800 },
            MR: { latitude: 48.0000, longitude: -120.9800 },
            PS: { latitude: 48.0000, longitude: -120.9800 },
            OP: { latitude: 48.0000, longitude: -120.9800 },
            SR: { latitude: 48.0000, longitude: -120.9800 },
            SC: { latitude: 48.0000, longitude: -120.9800 },
            CC: { latitude: 48.0000, longitude: -120.9800 },
            IA: { latitude: 48.0000, longitude: -120.9800 },
            SW: { latitude: 48.0000, longitude: -120.9800 },
            ALL: { latitude: 48.0000, longitude: -120.9800 }
        };
        public windowOption;

        constructor(private trailsService: Hiking.Services.TrailsService)
        {
            this.trails = {};
            this.windowOption = {visible: false};
            this.GetTrails();
        }

        GetTrails()
        {
            this.trailsService.getMapTrails().then((data) =>
            {
                this.trails = data;
                this.numOfTrails = data.length;
            });
        }

        Search()
        {
            this.trailsService.getSearchMapTrails(this.location).then((data) =>
            {
                switch (this.location)
                {
                    case "Central Washington":
                        this.center = this.locCenter.CW;
                        this.zoom = 8;
                        break;
                    case "Eastern Washington":
                        this.center = this.locCenter.EW;
                        this.zoom = 8;
                        break;
                    case "North Cascades":
                        this.center = this.locCenter.NC;
                        this.zoom = 8;
                        break;
                    case "Mount Rainer Area":
                        this.center = this.locCenter.MR;
                        this.zoom = 8;
                        break;
                    case "Puget Sound and Islands":
                        this.center = this.locCenter.PS;
                        this.zoom = 8;
                        break;
                    case "Olympic Peninsula":
                        this.center = this.locCenter.OP;
                        this.zoom = 8;
                        break;
                    case "Snoqualmie Region":
                        this.center = this.locCenter.SR;
                        this.zoom = 8;
                        break;
                    case "South Cascades":
                        this.center = this.locCenter.SC;
                        this.zoom = 8;
                        break;
                    case "Central Cascades":
                        this.center = this.locCenter.CC;
                        this.zoom = 8;
                        break;
                    case "Issaquah Alps":
                        this.center = this.locCenter.IA;
                        this.zoom = 8;
                        break;
                    case "Southwest Washington":
                        this.center = this.locCenter.SW;
                        this.zoom = 8;
                        break;
                    case "default":
                        this.center = this.locCenter.ALL;
                        this.zoom = 8;
                        break;
                }
                this.trails = data;
                this.numOfTrails = data.length;
            });

            
        }

        onClick()
        {
            this.windowOption.visible = !this.windowOption.visible;
        }

        closeClick()
        {
            this.windowOption.visible = false;
        }
    }
}