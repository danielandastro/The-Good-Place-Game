using Android.App;
using Android.Widget;
using Android.OS;
using System;
namespace TheGoodPlaceGame
{
    [Activity(Label = "The Good Place Game", MainLauncher = true, Icon = "@mipmap/icon")]
    public class Scoring
    {
        public static int tortureLevel, safetyChoices, tortureChoices, turns;
        public static void ChangeTorturePoints(bool add)
        {
            if (add)
                tortureLevel++;
            else tortureLevel--;
        }
        public static void TrackChoices(bool wasChoiceSafe)
        {
            if (wasChoiceSafe)

                safetyChoices++;

            else
                tortureChoices++;
        }

        public static bool IsCritical()
        {
            var r = new System.Random();
            if (r.Next(1, 5) < Scoring.tortureLevel)
            {
                return true;
            }
            else
                return false;
        }
        public static bool CaughtByShawn()
        {
            if (tortureLevel < -1)
                return true;
            else
                return false;
        }
    }
        public static class Dialog
        {

            public static string option()
            {
                var possibilties = new string[10];
                possibilties[0] = "Chidi complains about an ethics dillema" + System.Environment.NewLine + "Do you help him, or intentionally confuse him";
                possibilties[1] = "Tahani's party was a failure, because nobody showed up" + System.Environment.NewLine + "Do you make ammends and reschedule, or leave her to her sadness";
                possibilties[2] = "Eleanor seems freaked out and scared" + System.Environment.NewLine + "Do you calm her down, or subtly hint that she doesn't belong";
                possibilties[3] = "Jason hates his new soulmate" + System.Environment.NewLine + "Do you give him advice, or tell his so-called soulmate to be more intense";
                possibilties[4] = "Eleanor hates her clown house" + System.Environment.NewLine + "Do you reduce the clowns, or conjure a circus in the town square";
                possibilties[5] = "Tahani seems concerned about Jianyu/Jason" + System.Environment.NewLine + "Do you put her at ease, or mess with her emotions";
                possibilties[6] = "Chidi starts teaching Eleanor and Jason ethics" + System.Environment.NewLine + "Do you ignore this, or plan events to disrupt their schedule";
                //possibilties[7] = "Chidi complains about ethics dillema" + System.Environment.NewLine + "Do you solve it, or intentionally confuse him";
                //possibilties[8] = "Chidi complains about ethics dillema" + System.Environment.NewLine + "Do you solve it, or intentionally confuse him";
                //possibilties[9] = "Chidi complains about ethics dillema" + System.Environment.NewLine + "Do you solve it, or intentionally confuse him";
                var r = new System.Random();
                return possibilties[r.Next(0, 6)];
            }

        }
    [Activity(MainLauncher = true, Icon = "@mipmap/icon")]
        public class MainActivity : Activity
    {
            protected override void OnCreate(Bundle savedInstanceState)
            {
            base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.Main);
                Button Safetybutton = FindViewById<Button>(Resource.Id.btnSafe);
                Button Torturebutton = FindViewById<Button>(Resource.Id.btnTorture);
                Button restart = FindViewById<Button>(Resource.Id.btnRestart);
                TextView text = FindViewById<TextView>(Resource.Id.textView);
                while (true)
                {
                    restart.Click += delegate {Recreate();};
                    text.Text += System.Environment.NewLine + Dialog.option();
                    if (Safetybutton.Activated)
                    {
                        Scoring.ChangeTorturePoints(false);
                        Scoring.TrackChoices(true);
                        Scoring.turns++;
                        if (Scoring.CaughtByShawn())
                            text.Text += System.Environment.NewLine + "Sorry, you were caught by Shawn for being a bad demon, you were retired.";
                        break;
                    }
                        else if(Torturebutton.Activated){
                            Scoring.ChangeTorturePoints(true);
                            Scoring.TrackChoices(false);
                            Scoring.turns++;
                            if (Scoring.IsCritical())
                            {
                            text.Text += "Sorry you were caught, you survived " + Scoring.turns + " turns" + System.Environment.NewLine + "You had " +
                                Scoring.tortureChoices + " torture choices and " + Scoring.safetyChoices + " safe choices" + System.Environment.NewLine +
                                "This gave you a score of " + Scoring.tortureLevel * Scoring.turns;
                            break;
                            }
                    }

                    restart.Click += delegate { Recreate(); };
                }
                text.Text += System.Environment.NewLine+"Please click restart to begin again";
            }
        }
    }
