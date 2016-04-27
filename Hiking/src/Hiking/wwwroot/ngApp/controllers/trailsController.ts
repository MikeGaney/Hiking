namespace Hiking.Controllers {

    export class TrailsController {
        public search;
        public trails;

        constructor(private trailService: Hiking.Services.TrailService)
        {
            this.search = {};


            console.log("trails controller");
            this.trails = this.trailService.getTrails();
        }


        trailSearch() {

            //if (this.search.name == null) {
            //    this.search.name = "";
            //}

            //if (this.search.location == "Include All Areas") {
            //    this.search.location = "";
            //}
            //console.log(this.search.rating);

            //if (this.search.rating == "") {
            //    this.search.rating = 1 ;
            //}

            //console.log(this.search.difficultyLevel);


            //if (this.search.difficultyLevel == "") {
            //    this.search.difficultyLevel = 5 ;
            //}

            //if (this.search.camping != true) {
            //    this.search.camping = false;
            //}

            //if (this.search.fishing != true) {
            //    this.search.fishing = false;
            //}

            //if (this.search.biking != true) {
            //    this.search.biking = false;
            //}

            //if (this.search.horses != true) 
            //{
            //    this.search.horses = false;
            //}

            //if (this.search.lakes != true) {
            //    this.search.lakes = false;
            //}

            //if (this.search.rivers != true) {
            //    this.search.rivers = false;
            //}

            //if (this.search.waterfalls != true) {
            //    this.search.waterfalls = false;
            //}

            //if (this.search.lookouts != true) {
            //    this.search.lookouts = false;
            //}

            console.log(this.search);
            this.trailService.searchTrails(this.search).then((data) => {
                this.trails = data;
                console.log(data);
            });

        }
    }

}