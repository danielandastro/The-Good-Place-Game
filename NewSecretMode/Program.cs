using System;

namespace NewSecretMode
{
    class MainClass
    {
        public static void Main(string[] args)
        {
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
        }
    }
}
