using System;
using System.Net;
using The_Good_Place_Library;
namespace The_Good_Place_Game_Desktop
{
    class MainClass
    {

        private static void PreFlightChecks()
        {
            var client = new WebClient();
            var newVer = "";
            try
            {
                newVer = client.DownloadString(
                    "https://raw.githubusercontent.com/danielandastro/The-Good-Place-Game/update-branch/update.txt");
            }
            catch (Exception)
            {
                Console.WriteLine("Connection Failed");
            }

            if (!newVer.Contains(Game.ver))
            {
                Console.WriteLine("Update Available " + newVer + "Show ChangeLog");
                if (Console.ReadLine().Equals("y"))
                {

                    try
                    {
                        Console.WriteLine(client.DownloadString(
                            "https://raw.githubusercontent.com/danielandastro/The-Good-Place-Game/update-branch/chnglg.txt"));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Connection Failed");
                    }

                    Console.WriteLine("Update(y/n)");
                    if (Console.ReadLine().Equals("y"))
                    {
                        try
                        {
                            client.DownloadFile(
                                "https://github.com/danielandastro/The-Good-Place-Game/blob/update-branch/lib.dll?raw=true",
                                "theGoodLibrary.dll");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Connection Failed");
                        }

                        Console.WriteLine("The Good Place Game, using story library version " + Game.ver);
                    }

                }
            }
            Console.WriteLine("The Good Place Game, using story library version " + Game.ver);
        }
            public static void Main(string[] args)
            {
            PreFlightChecks();
            Game.Start();
            }
        }
    }
