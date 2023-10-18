namespace Quiz;

class ConsoleUI
{
    public static void UIMenu()
    {
        Console.OutputEncoding = Console.InputEncoding = System.Text.Encoding.Unicode;
        bool isRunning = true;
        while(isRunning)
        {
            Console.WriteLine("========Välj alternativ========");
            Console.WriteLine("[S]pela frågesport\n[L]ägg till fråga\n[A]vsluta");
            Console.Write("Val: ");
            string choice = Console.ReadLine()!;
            switch(choice.ToLower())
            {
                case "s":
                    Game.PlayGame();
                break;
                case "l":
                    UIQuestionInput();
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
    static void UIQuestionInput()
    {
        Console.WriteLine("Välj typ av fråga:\n1. Flervalsalternativ\n2. Fritext\n3. 1-10");
        int type = Convert.ToInt32(Console.ReadLine());
        Console.Write("Hur lyder frågan?: ");
        string q = Console.ReadLine()!;
        Console.Write("Hur många poäng är frågan värd?: ");
        int p = Convert.ToInt32(Console.ReadLine());
        switch(type)
        {
            case 1:
            {
                List<string> options = new List<string>();
                Console.WriteLine("Skriv in svarsalternativ. Skriv 'stop' för att avsluta");
                bool isRunning = true;
                while(isRunning)
                {
                    Console.Write($"Alternativ {options.Count+1}: ");
                    string userInput = Console.ReadLine()!;
                    if(userInput.ToLower() == "stop")
                    {   
                        isRunning = false;
                    }
                    else
                    {
                        options.Add(userInput);
                    }
                }
                for(int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {options[i]}");
                }
                Console.Write("Vilket alternativ är rätt?: ");
                string answer = Console.ReadLine()!;
                AdminTools.AddQuestion(type, q, p, answer, options);
            }
            break;
            case 2:
            {
                Console.Write("Vad är det korrekta svaret?: ");
                string answer = Console.ReadLine()!;
                AdminTools.AddQuestion(type, q, p, answer, null!);
            }
            break;
            case 3:
            {
                List<string> options = new List<string>();
                Console.WriteLine("Skriv in svarsalternativ.");
                for(int i = 1; i <= 10; i++)
                {
                    Console.Write($"svar {i}: ");
                    string userInput = Console.ReadLine()!;
                    options.Add(userInput);
                }
                Console.Write("Vilket alternativ är rätt?: ");
                string answer = Console.ReadLine()!;
                AdminTools.AddQuestion(type, q, p, answer, options);
            }
            break;
        }
    }
}