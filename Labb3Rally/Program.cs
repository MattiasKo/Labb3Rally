//Mattias Kokkonen SUT21
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;


namespace Labb3Rally
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] Logbook = new string[5];

            Bil B1 = new Bil("Lighting", 200, 100000);
            Bil B2 = new Bil("Turbo", 200, 100000);
            Bil B3 = new Bil("Slayer", 200, 100000);
            Bil B4 = new Bil("Geopard", 200, 100000);
            Bil B5 = new Bil("FastFury", 200, 100000);

            Thread T1 = new Thread(() => Rally(B1, Logbook));
            Thread T2 = new Thread(() => Rally(B2, Logbook));
            Thread T3 = new Thread(() => Rally(B3, Logbook));
            Thread T4 = new Thread(() => Rally(B4, Logbook));
            Thread T5 = new Thread(() => Rally(B5, Logbook));

            Console.WriteLine("----tryck en knapp för att starta racet----");
            Console.ReadKey();
            T1.Start();
            T2.Start();
            T3.Start();
            T4.Start();
            T5.Start();
            Console.WriteLine("----------Nu startar Tävlingen!------------");
        }
        public static void Rally(Bil obj, string[] Logbook)
        {
            ConsoleKeyInfo CheckKey;
            int EventTimer = 0;
            int number=0;
                for (int i = 20000; i >= 0; i--)
                {

                    obj.Sträcka = obj.Sträcka - obj.Hastighet/3.6;
                    LogBook(obj, Logbook);
                    Thread.Sleep(100);
                    EventTimer ++;

                    if (EventTimer >= 300)
                        {
                            Random RndEvent = new Random();
                            number = RndEvent.Next(0, 50);
                            EventTimer = 0;
                        }
                   
                    if (obj.Sträcka <= 0)
                    {
                        Console.WriteLine("-------------Mål! för " + obj.BilNamn + "---------------");
                        break;
                    }
                    if (number == 1)
                    {
                        Console.WriteLine("Slut på bensin " + obj.BilNamn + " Behöver tanka");
                        Thread.Sleep(1000);
                        number = 0;
                    }
                    if (number >= 2 && number <= 3)
                    {
                        Console.WriteLine(obj.BilNamn + " behöver byta däck ");
                        Thread.Sleep(2000);
                        number = 0;

                    }
                    if (number >= 4 && number <= 8)
                    {
                        Console.WriteLine("Behöver tvätta vindrutan " + obj.BilNamn);
                        number = 0;
                        Thread.Sleep(1000);

                    }
                    if (number >= 8 && number <= 18)
                    {
                        Console.WriteLine("Motorfel hos " + obj.BilNamn);
                        obj.Hastighet = obj.Hastighet - 1;
                        number = 0;
                        if (obj.Hastighet == 0)
                        {
                            Console.WriteLine(obj.BilNamn + " Bil är sönder!");
                            break;
                        }

                    }
                if (Console.KeyAvailable == true)
                {
                    CheckKey = Console.ReadKey(true);
                    Console.WriteLine(Logbook[0]+"\n"+ Logbook[1] + "\n"+ Logbook[2] + "\n"+ Logbook[3] + "\n"+ Logbook[4] + "\n");
                }
                }

        }
        public static void LogBook(Bil obj, string[] Logbook)
        {
            
            if(obj.BilNamn== "Lighting")
            {
                Logbook[0] = obj.BilNamn + " km:" + obj.Hastighet + " Sträcka:"+ String.Format("{0:0.00}", obj.Sträcka);
            }
            if (obj.BilNamn == "Turbo")
            {
                Logbook[1] = obj.BilNamn + " km:" + obj.Hastighet + " Sträcka:" + String.Format("{0:0.00}", obj.Sträcka);
            }
            if (obj.BilNamn == "Slayer")
            {
                Logbook[2] = obj.BilNamn + " km:" + obj.Hastighet + " Sträcka:" + String.Format("{0:0.00}", obj.Sträcka);
            }
            if (obj.BilNamn == "Geopard")
            {
                Logbook[3] = obj.BilNamn + " km:" + obj.Hastighet + " Sträcka:" + String.Format("{0:0.00}", obj.Sträcka);
            }
            if (obj.BilNamn == "FastFury")
            {
                Logbook[4] = obj.BilNamn + " km:" + obj.Hastighet + " Sträcka:" + String.Format("{0:0.00}", obj.Sträcka);
            }
        }


        }

    }

