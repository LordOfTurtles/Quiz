using System.Runtime.CompilerServices;

namespace Quiz;

public class AdminTools
{
    public static List<Question> QuestionList = new List<Question>();
    public static void AddQuestion()
    {
        Console.WriteLine("Välj typ av fråga:\n1. Flervalsalternativ\n2. Fritext");
        int type = Convert.ToInt32(Console.ReadLine());
        Console.Write("Hur lyder frågan?: ");
        string q = Console.ReadLine()!;
        Console.Write("Hur många poäng är frågan värd?: ");
        int p = Convert.ToInt32(Console.ReadLine());
        switch(type)
        {
            case 1:
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
                int answer1 = Convert.ToInt32(Console.ReadLine());
                QuestionList.Add(new MultipleChoice(q, p, answer1, options));
            break;
            case 2:
                Console.Write("Vad är det korrekta svaret?: ");
                string answer2 = Console.ReadLine()!;
                QuestionList.Add(new FreeText(q, p, answer2.ToLower()));
            break;
        }
    }
}