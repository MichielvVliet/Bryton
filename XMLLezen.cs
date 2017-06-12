using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bryton
{
    class XMLLezen
    {

        public static RitSamenVatting LeesXMLSamenVatting(string bestand)
        {
            string element = "";
            double number = 0;
            int integer = 0;

            RitSamenVatting Rsv = new RitSamenVatting();
            try
            {
                using (FileStream fileSteam = File.OpenRead(bestand))
                {
                    using (XmlReader reader = XmlReader.Create(fileSteam))
                    {
                        reader.MoveToContent();
                        reader.ReadToDescendant("laps");
                        Rsv.BestandsNaam = bestand;

                        while (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element:
                                    element = reader.Name;
                                    for (int attInd = 0; attInd < reader.AttributeCount; attInd++)
                                    {
                                        reader.MoveToAttribute(attInd);
                                        switch (element)
                                        {
                                            case "summary":
                                                if (reader.Name == "start")
                                                {
                                                    Rsv.StartTijd = reader.Value;
                                                }
                                                if (reader.Name == "end")
                                                {
                                                    Rsv.EindTijd = reader.Value;
                                                }
                                                break;
                                            case "speed":
                                                if (reader.Name == "max")
                                                {
                                                    if (Double.TryParse(reader.Value, out number))
                                                        Rsv.SnelheidMax = number;
                                                }
                                                if (reader.Name == "avg")
                                                {
                                                    if (Double.TryParse(reader.Value, out number))
                                                        Rsv.SnelheidGem = number;
                                                }
                                                break;
                                            case "hrm":
                                                if (reader.Name == "max")
                                                {
                                                    if (int.TryParse(reader.Value, out integer))
                                                        Rsv.HartslagMax = integer;
                                                }
                                                if (reader.Name == "avg")
                                                {
                                                    if (int.TryParse(reader.Value, out integer))
                                                        Rsv.HartslagGem = integer;
                                                }
                                                break;
                                            case "cadance":
                                                if (reader.Name == "max")
                                                {
                                                    if (int.TryParse(reader.Value, out integer))
                                                        Rsv.CadanceMax = integer;
                                                }
                                                if (reader.Name == "avg")
                                                {
                                                    if (int.TryParse(reader.Value, out integer))
                                                        Rsv.CadanceGem = integer;
                                                }
                                                break;

                                        }


                                    }
                                    break;
                                case XmlNodeType.Text:
                                    switch (element)
                                    {
                                        case "distance":
                                            {
                                                if (int.TryParse(reader.Value, out integer))
                                                    Rsv.Afstand = integer;
                                            }
                                            break;
                                        case "calorie":
                                            {
                                                if (Double.TryParse(reader.Value, out number))
                                                    Rsv.Calorie = number;
                                            }
                                            break;
                                        case "altloss":
                                            {
                                                if (Double.TryParse(reader.Value, out number))
                                                    Rsv.HoogteVerlies = number;
                                            }
                                            break;
                                        case "altgain":
                                            {
                                                if (Double.TryParse(reader.Value, out number))
                                                    Rsv.HoogteWinst = number;
                                            }
                                            break;
                                        case "rtime":
                                            {
                                                if (int.TryParse(reader.Value, out integer))
                                                    Rsv.RitTijd = integer;
                                            }
                                            break;
                                        case "gainaltlen":
                                            {
                                                if (int.TryParse(reader.Value, out integer))
                                                    Rsv.AfstandBergOp = integer;
                                            }
                                            break;
                                        case "lostaltlen":
                                            {
                                                if (int.TryParse(reader.Value, out integer))
                                                    Rsv.AfstandBergAf = integer;
                                            }
                                            break;
                                        case "gainalttime":
                                            {
                                                if (int.TryParse(reader.Value, out integer))
                                                    Rsv.TijdBergOp = integer;
                                            }
                                            break;
                                        case "lostalttime":
                                            {
                                                if (int.TryParse(reader.Value, out integer))
                                                    Rsv.TijdBergAf = integer;
                                            }
                                            break;
                                    }
                                    break;
                                case XmlNodeType.EndElement:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (XmlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception object Line, pos: (" + ex.LineNumber + "," + ex.LinePosition + ")");
            }
            finally
            {
            }
            return (Rsv);
        }

        public static List<LogPoint> LeesLogPointsUitXML(string bestand)
        {
            List<LogPoint> LogPoints = new List<LogPoint>();
            string element = "";
            double number = 0;
            int integer = 0;

            string tijdLog ="";
            int hartrate = 0;
            int cadance = 0;
            double speed = 0;
            int temperature = 0;
            double barometer = 0;


            try
            {
                using (FileStream fileSteam = File.OpenRead(bestand))
                {
                    using (XmlReader reader = XmlReader.Create(fileSteam))
                    {
                        reader.MoveToContent();
                        reader.ReadToDescendant("logseg");

                        while (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element:
                                    element = reader.Name;
                                    for (int attInd = 0; attInd < reader.AttributeCount; attInd++)
                                    {
                                        reader.MoveToAttribute(attInd);
                                        if (element == "logpt" && reader.Name == "time")
                                            tijdLog = reader.Value;
                                    }
                            break;
                                case XmlNodeType.Text:
                                    switch (element)
                                    {
                                        case "hrm":
                                            {
                                                if (int.TryParse(reader.Value, out integer))
                                                    hartrate = integer;
                                            }
                                            break;
                                        case "cad":
                                            {
                                                if (int.TryParse(reader.Value, out integer))
                                                    cadance = integer;
                                            }
                                            break;
                                        case "spd":
                                            {
                                                if (Double.TryParse(reader.Value, out number))
                                                    speed = number;
                                            }
                                            break;
                                        case "tmp":
                                            {
                                                if (int.TryParse(reader.Value, out integer))
                                                    temperature = integer;
                                            }
                                            break;
                                        case "brm":
                                            {
                                                if (Double.TryParse(reader.Value, out number))
                                                    barometer = number;
                                            }
                                            break;
                                    }
                                    break;
                                case XmlNodeType.EndElement:
                                    if (reader.Name == "logpt")
                                    {
                                        LogPoint lp = new LogPoint(tijdLog, hartrate, cadance, speed / 10, temperature, barometer = 0);

                                        LogPoints.Add(lp);

                                        tijdLog = "";
                                        hartrate = 0;
                                        cadance = 0;
                                        speed = 0;
                                        temperature = 0;
                                        barometer = 0;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (XmlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception object Line, pos: (" + ex.LineNumber + "," + ex.LinePosition + ")");
            }
            finally
            {
            }
            return (LogPoints);
        }
    }
}
