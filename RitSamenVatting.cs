using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bryton
{
    class RitSamenVatting
    {
        string bestandsNaam;
        string startTijd;
        string eindTijd;
        int afstand;
        double calorie;
        double hoogteVerlies;
        double hoogteWinst;
        double snelheidMax;
        double snelheidGem;
        int hartslagMax;
        int hartslagGem;
        int cadanceMax;
        int cadanceGem;
        int powerMax;
        int powerGem;
        int ritTijd;
        int afstandBergOp;
        int afstandBergAf;
        int tijdBergOp;
        int tijdBergAf;

        public RitSamenVatting()
        {
            this.bestandsNaam = "";
            this.startTijd = "";
            this.eindTijd = "";
            this.afstand = 0;
            this.calorie = 0;
            this.hoogteVerlies = 0;
            this.hoogteWinst = 0;
            this.snelheidMax = 0;
            this.snelheidGem = 0;
            this.hartslagMax = 0;
            this.hartslagGem = 0; 
            this.cadanceMax = 0;
            this.cadanceGem = 0;
            this.powerMax = 0;
            this.powerGem = 0;
            this.ritTijd = 0;
            this.afstandBergOp = 0;
            this.afstandBergAf = 0;
            this.tijdBergOp = 0;
            this.tijdBergAf = 0;
        }

        public RitSamenVatting(string bestandsNaam, string startTijd, string eindTijd, int afstand, double calorie, double hoogteVerlies, double hoogteWinst, double snelheidMax, double snelheidGem, int hartslagMax, int hartslagGem, int cadanceMax, int cadanceGem, int powerMax, int powerGem, int ritTijd, int afstandBergOp, int afstandBergAf, int tijdBergOp, int tijdBergAf)
        {
            this.bestandsNaam = bestandsNaam;
            this.startTijd = startTijd;
            this.eindTijd = eindTijd;
            this.afstand = afstand;
            this.calorie = calorie;
            this.hoogteVerlies = hoogteVerlies;
            this.hoogteWinst = hoogteWinst;
            this.snelheidMax = snelheidMax;
            this.snelheidGem = snelheidGem;
            this.hartslagMax = hartslagMax;
            this.hartslagGem = hartslagGem;
            this.cadanceMax = cadanceMax;
            this.cadanceGem = cadanceGem;
            this.powerMax = powerMax;
            this.powerGem = powerGem;
            this.ritTijd = ritTijd;
            this.afstandBergOp = afstandBergOp;
            this.afstandBergAf = afstandBergAf;
            this.tijdBergOp = tijdBergOp;
            this.tijdBergAf = tijdBergAf;
        }

        public string BestandsNaam { get => bestandsNaam; set => bestandsNaam = value; }
        public string StartTijd { get => startTijd; set => startTijd = value; }
        public string EindTijd { get => eindTijd; set => eindTijd = value; }
        public int Afstand { get => afstand; set => afstand = value; }
        public double Calorie { get => calorie; set => calorie = value; }
        public double HoogteVerlies { get => hoogteVerlies; set => hoogteVerlies = value; }
        public double HoogteWinst { get => hoogteWinst; set => hoogteWinst = value; }
        public double SnelheidMax { get => snelheidMax; set => snelheidMax = value; }
        public double SnelheidGem { get => snelheidGem; set => snelheidGem = value; }
        public int HartslagMax { get => hartslagMax; set => hartslagMax = value; }
        public int HartslagGem { get => hartslagGem; set => hartslagGem = value; }
        public int CadanceMax { get => cadanceMax; set => cadanceMax = value; }
        public int CadanceGem { get => cadanceGem; set => cadanceGem = value; }
        public int PowerMax { get => powerMax; set => powerMax = value; }
        public int PowerGem { get => powerGem; set => powerGem = value; }
        public int RitTijd { get => ritTijd; set => ritTijd = value; }
        public int AfstandBergOp { get => afstandBergOp; set => afstandBergOp = value; }
        public int AfstandBergAf { get => afstandBergAf; set => afstandBergAf = value; }
        public int TijdBergOp { get => tijdBergOp; set => tijdBergOp = value; }
        public int TijdBergAf { get => tijdBergAf; set => tijdBergAf = value; }
    }
}
