using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bryton
{
    class TrackPoint
    {
        string tijdPoint;
        double latitude;
        double longitude;
        double elevation;
        double magvar;

        public TrackPoint()
        {
            this.tijdPoint = "";
            this.latitude = 0;
            this.longitude = 0;
            this.elevation = 0;
            this.magvar = 0;
        }

        public TrackPoint(string tijdPoint, double latitude, double longitude, double elevation, double magvar)
        {
            this.tijdPoint = tijdPoint;
            this.latitude = latitude;
            this.longitude = longitude;
            this.elevation = elevation;
            this.magvar = magvar;
        }

        public string TijdPoint { get => tijdPoint; set => tijdPoint = value; }
        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        public double Elevation { get => elevation; set => elevation = value; }
        public double Magvar { get => magvar; set => magvar = value; }
    }
           
}
