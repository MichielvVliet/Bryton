using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bryton
{
    class LogPoint
    {
        string tijdLog;
        int hartrate;
        int cadance;
        double speed;
        int temperature;
        double barometer;

        public LogPoint()
        {
            this.tijdLog = "";
            this.hartrate = 0;
            this.cadance = 0;
            this.speed = 0;
            this.temperature = 0;
            this.barometer = 0;
        }

        public LogPoint(string tijdLog, int hartrate, int cadance, double speed, int temperature, double barometer)
        {
            this.tijdLog = tijdLog;
            this.hartrate = hartrate;
            this.cadance = cadance;
            this.speed = speed;
            this.temperature = temperature;
            this.barometer = barometer;
        }

        public string TijdLog { get => tijdLog; set => tijdLog = value; }
        public int Hartrate { get => hartrate; set => hartrate = value; }
        public int Cadance { get => cadance; set => cadance = value; }
        public double Speed { get => speed; set => speed = value; }
        public int Temperature { get => temperature; set => temperature = value; }
        public double Barometer { get => barometer; set => barometer = value; }
    }
}
