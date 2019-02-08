﻿using System;

namespace The_Good_Place_Game
{
    public class Scoring
    {
        public static int tortureLevel, safetyChoices, tortureChoices, turns;
        static void ChangeTorturePoints(bool add)
        {
            if (add)
                tortureLevel++;
            else tortureLevel--;
        }
        static void TrackChoices(bool wasChoiceSafe)
        {
            if (wasChoiceSafe)

                safetyChoices++;

            else
                tortureChoices++;
        }

        private static bool isCritical()
        {
            var r = new Random();
            if (r.Next(1, 5) < Scoring.tortureLevel)
            {
                return true;
            }
            else
                return false;
        }
        public static bool caughtByShawn()
        {
            if (tortureLevel < -1)
                return true;
            else
                return false;
        }
        public static class Dialog
        {

            public static string option()
            {
                var possibilties = new string[10];
                possibilties[0] = "Chidi complains about an ethics dillema" + Environment.NewLine + "Do you help him, or intentionally confuse him";
                possibilties[1] = "Tahani's party was a failure, because nobody showed up" + Environment.NewLine + "Do you make ammends and reschedule, or leave her to her sadness";
                possibilties[2] = "Eleanor seems freaked out and scared" + Environment.NewLine + "Do you calm her down, or subtly hint that she doesn't belong";
                possibilties[3] = "Jason hates his new soulmate" + Environment.NewLine + "Do you give him advice, or tell his so-called soulmate to be more intense";
                possibilties[4] = "Eleanor hates her clown house" + Environment.NewLine + "Do you reduce the clowns, or conjure a circus in the town square";
                possibilties[5] = "Tahani seems concerned about Jianyu/Jason" + Environment.NewLine + "Do you put her at ease, or mess with her emotions";
                possibilties[6] = "Chidi starts teaching Eleanor and Jason ethics" + Environment.NewLine + "Do you ignore this, or plan events to disrupt their schedule";
                //possibilties[7] = "Chidi complains about ethics dillema" + Environment.NewLine + "Do you solve it, or intentionally confuse him";
                //possibilties[8] = "Chidi complains about ethics dillema" + Environment.NewLine + "Do you solve it, or intentionally confuse him";
                //possibilties[9] = "Chidi complains about ethics dillema" + Environment.NewLine + "Do you solve it, or intentionally confuse him";
                var r = new Random();
                return possibilties[r.Next(0, 6)];
            }

        }
        class Program
        {
            public static void NewMode(){
                Console.WriteLine("Eleanor Shellstrop finds herself in a waiting room, with the words Welcome!Everything Is Fine. written on the wall. "
                              + Environment.NewLine + "She then enters a room where a man named Michael awaits her.");
                Console.WriteLine("He informs her that she is dead, killed after a line of shopping carts in the parking lot of a supermarket pushed her into the oncoming path of a truck which was advertising marital aid pills, " +
                                  Environment.NewLine + "and the space they are in is a Heaven-like utopia called The Good Place." + Environment.NewLine);
                Console.WriteLine("Also, every person in the Good Place has a soulmate, a person to spend their eternal life together." + Environment.NewLine);
                Console.WriteLine("Your soulmate, Eleanor, is an ethics professor, his name is Chidi" + Environment.NewLine);
                Console.WriteLine("You are shown to your house, it is a modern, clown-themed, tailored to your preferences" + Environment.NewLine);
                Console.WriteLine("You utterly hate clowns, do you; 1) Complain to Micheal, or 2) Do nothing" + Environment.NewLine);
                var input = Console.ReadLine();
                if (input.Equals("1"))
                {
                    Console.WriteLine("Micheal: This is very strange, the system must have been wrong, but the system is never wrong...");
                }
                else
                    Console.WriteLine("Smart, don't give him a reason to doubt you");
                Console.ReadLine();
                return;
            }
            static void Main(string[] args)
            {
                Console.WriteLine("1) Play the classic mode, or 2) play the new experimental story");
                var input = Console.ReadLine();
                if (input.Equals("2"))
                { NewMode();
                    return;
            }
                Console.WriteLine("Welcome Michael.");
                while (true)
                {

                    Console.WriteLine(Dialog.option());
                    var response = Console.ReadLine();
                    if (response.Equals("1"))
                    {
                        Scoring.ChangeTorturePoints(false);
                        Scoring.TrackChoices(true);
                        Scoring.turns++;
                        if (caughtByShawn())
                        {
                            Console.WriteLine("Sorry, you were caught by Shawn for being a bad demon, you were retired.");
                            Console.ReadKey();
                            return;
                        }

                    }
                    else if (response.Equals("why"))
                        Console.WriteLine("Because I'm a naughty b**ch");
                    else
                    {
                        Scoring.ChangeTorturePoints(true);
                        Scoring.TrackChoices(false);
                        Scoring.turns++;
                        if (isCritical())
                        {
                            Console.WriteLine("Sorry, they figured it out, " + Environment.NewLine + " you had " + Scoring.safetyChoices + " safe choices and " + Scoring.tortureChoices + " torture choices");
                            Console.WriteLine("You survived " + Scoring.turns + " turns, with " + Scoring.tortureLevel + " torture points");
                            Console.WriteLine("Thus giving you a score of " + Scoring.tortureLevel * Scoring.turns);
                            Console.ReadKey();
                            return;
                        }
                    }
                }
            }
        }
    }
}
