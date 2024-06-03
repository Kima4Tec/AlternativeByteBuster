using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AlternativeByteBuster //Et program kodet af Kim Massesson
{            
     internal class Program
    {
        static void Main(string[] args)
        {
            Grafik Pos = new Grafik();

            int antalRigtige = 0;
            int antalForkerte = 0;

            //Grafikken sættes op bl.a. ved at hente metoder, som jeg har lavet, fra anden klasse. Men først vælger jeg tekst- og baggrundsfarve
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            Pos.ByteBusterLogo(12, 1);
            Pos.Rammer();
            Console.ResetColor();

            string valg = "";
            int maks = 25;
            DateTime a = DateTime.Now;
            DateTime dato = DateTime.Today;
            DayOfWeek ugedag = a.DayOfWeek;
            int time = a.Hour;
            int minut = a.Minute;
            int ugedagNr = (int)ugedag;
            string[] ugedage = { "", "mandag", "tirsdag", "onsdag", "torsdag", "fredag", "lørdag", "søndag", };
            string navn = "noname";

            List<string> hiscore = new List<string> { };
            Stopwatch stopwatch = new Stopwatch(); //instans, der skal registrere tiden, som spiller bruger på at gætte. Denne er grundlaget for HiScore
            var nyTid = stopwatch.Elapsed;

            while (valg != "q")
            {
            
            do //jeg vælger en do-while løkke til min menu
            {
                    Pos.Skriv(34, 11, $"Det er {ugedage[ugedagNr]} d. {dato.Day}-{dato.Month}-{dato.Year} og klokken er {time:D2}:{minut:D2} ");
                    Pos.Skriv(34, 13, "VELKOMMEN TIL BYTEBUSTER by Christian Mørk I/S");
                    Pos.Skriv(34, 14, "I spillet skal du omregne fra binære tal til decimale tal");
                    Pos.Skriv(34, 15, "Du har fem forsøg til at gætte rigtigt tre gange på tid");
                    Pos.Skriv(46, 17, "Tryk O for at oprette spiller ");
                    Pos.Skriv(46, 18, "Tryk S for at spille         ");
                    Pos.Skriv(46, 19, "Tryk H for at se highscore   ");
                    Pos.Skriv(46, 20, "Tryk Q for at afslutte       ");
                    Pos.Skriv(46, 22, "Indtast dit valg: ");
                    valg = Console.ReadLine().ToLower(); //alle tegn i valget bliver lavet om til lower
            }
            while (valg != "o" && valg != "s" && valg != "h" && valg != "q");
            { 
                switch (valg)
                {
                    case "o":
                        {
                                Pos.EmptyBox(13, 11);
                                Pos.Skriv(46, 22, "Indtast et brugernavn: ");
                                navn = Console.ReadLine();
                                //spiller.Add(navn);
                                //tiden[0] = "00:00";
                                //Console.Clear();
                                //Console.WriteLine(spiller[spiller.Count-1]);
                                //Console.ReadLine();
                                Pos.EmptyBox(13, 11);
                                break;
                        }
                    case "s":
                            {
                                for (int i = 1; i < 6; i++)                                               //loop, der tæller forsøgene. Der må max være fem forsøg
                                {
                                    Random RandomObj = new Random();                                       //her laver prog en ny instans så der kan findes en tilfældig byte
                                    int nummer = RandomObj.Next(1, maks);
                                    string bin = Convert.ToString(nummer, 2).PadLeft(8, '0');
                                    string nr = Convert.ToString(nummer);
                                    string svar;                                                           //svar får en værdi
                                    var tid = stopwatch.Elapsed;

                                    Pos.EmptyBox(13, 11);
                                    Pos.Skriv(32, 11, $"Spiller: {navn}");
                                    Pos.Skriv(55, 11, $"Tid: {tid:mm\\:ss}");
                                    Pos.Skriv(32, 22, $"Antal rigtige svar: {antalRigtige}");
                                    Pos.Skriv(55, 22, $"Antal forkerte svar: {antalForkerte}");

                                    Pos.Skriv(32, 15, $"Forsøg nr: {i}: ");
                                    Pos.Skriv(32, 16, "Omskriv det nedenstående binære tal til et decimaltal.");
                                    Pos.Skriv(32, 17, $"{bin}");                                //det binære tal bliver fyldt ud med nuller pga D8 (Fra Microsoft:"The precision specifier indicates the minimum number of digits desired in the resulting string. If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier")
                                    Pos.Skriv(32, 18, "Indtast dit svar: ");                        //brugerindtastning
                                    stopwatch.Start();
                                    svar = Console.ReadLine();                                      //{svar}s type skal gerne passe til {nummer}s type. Her er de string

                                    if (svar == nr)                                                       //sandt eller falsk
                                    {
                                        antalRigtige++;                                                 //hvis sandt lægges der en værdi til i variablen antalRigtige

                                        if (antalRigtige >= 3)                                          //undersøg om bruger har haft tre vellykkede forsøg
                                        {
                                            Pos.EmptyBox(13, 11);
                                            nyTid = stopwatch.Elapsed;
                                            string theList = $"{nyTid:mm\\:ss} : {navn}";
                                            hiscore.Add( theList );
                                            Pos.Skriv(32, 22, $"Tillykke {navn}! Du gennemførte på tid: {nyTid:mm\\:ss}");
                                            Console.ReadKey();
                                            Pos.EmptyBox(13, 11);
                                            stopwatch.Stop();
                                            stopwatch.Reset();
                                            antalForkerte = 0;
                                            antalRigtige = 0;
                                            break;
                                        }

                                    }
                                    else
                                    {
                                        antalForkerte++;
                                        if (antalForkerte >= 3)
                                        {
                                            stopwatch.Stop();
                                            Pos.EmptyBox(13, 11);
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Pos.Skriv(32, 15 + 1, $"Du ramte rigtigt {antalRigtige} gange og mangler derfor {3 - antalRigtige} rigtige");
                                            Pos.Skriv(32, 15 + 2, "svar for at vinde. Tak fordi du spillede med. Vil du ");
                                            Pos.Skriv(32, 15 + 3, "prøve igen (j/n)?: ");
                                            string fortsaet = Console.ReadLine().ToLower();
                                            Console.ResetColor();

                                                if (fortsaet == "j")
                                                {
                                                antalForkerte = 0;
                                                antalRigtige= 0;
                                                stopwatch.Reset();
                                                Pos.EmptyBox(13, 11);
                                                i=0;
                                            }
                                                else
                                                {
                                                antalForkerte = 0;
                                                antalRigtige = 0;
                                                stopwatch.Reset();
                                                Pos.EmptyBox(13, 11);
                                                break;
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }
                                }
                                break;
                            }
                    case "h":
                        {
                            Pos.EmptyBox(13, 11);
                            Pos.Skriv(52, 12, "HIGHSCORE");
                                hiscore.Sort();
                                int ypos = 13;
                                foreach (string item in hiscore)
                                {
                                    ypos++;
                                    Pos.Skriv(52, ypos, $"{item} ");
                                }
                                string text = "";
                                foreach (string item in hiscore)
                                {
                                    text += item + "\n";
                                }
                                //System.IO.File.AppendAllText(@"C:\temp\hiscore.txt", text);
                                //text = System.IO.File.ReadAllText(@"C:\temp\hiscore.txt");
                                // Display the file contents to the console.Variable text is a string.
                                //Pos.Skriv(52, 14, $"{System.IO.File.ReadAllText(@"C:\temp\hiscore.txt")}");
                                string[] tidsArr = { text };
                                Pos.Skriv(52, 14, $"{text}");
                                Console.ReadKey();
                            Pos.EmptyBox(13, 11);
                            break;
                        }
                    case "q":
                        {
                            Pos.EmptyBox(13, 11);
                            break;
                        }

                    default:
                        {
                            Pos.Skriv(46, 22, "Indtast venligst dit valg: ");
                            break;
                        }
                }
            }
           
            }
        }
    }
}
