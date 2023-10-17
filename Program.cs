namespace Quiz;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Console.InputEncoding = System.Text.Encoding.Unicode;
        bool isRunning = true;
        while(isRunning)
        {
            Console.WriteLine("========Välj alternativ========");
            Console.WriteLine("[S]pela frågesport\n[L]ägg till fråga\n[A]vsluta");
            Console.Write("Val: ");
            string userInput = Console.ReadLine()!;
            switch(userInput.ToLower())
            {
                case "s":
                    Game.PlayGame();
                break;
                case "l":
                    AdminTools.AddQuestion();
                break;
                case "a":
                    isRunning = false;
                break;
                default:
                    Console.WriteLine("Ogiltigt alternativ");
                break;
            }
        }
    }
}
