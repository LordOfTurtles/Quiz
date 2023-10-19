namespace Quiz;

class ConsoleUI
{
    public static List<Question> QuestionList = new List<Question>();
    public static void UIMenu()
    {
        Console.OutputEncoding = Console.InputEncoding = System.Text.Encoding.Unicode;
        bool isRunning = true;
        while(isRunning)
        {
            Console.Clear();
            Console.WriteLine("========Välj alternativ========");
            Console.WriteLine("[S]pela quiz\n[L]ägg till fråga\n[A]vsluta");
            Console.Write("Val: ");
            string choice = Console.ReadLine()!;
            switch(choice.ToLower())
            {
                case "s":
                    PlayGame();
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
    static void PlayGame()
    {
        Random random = new Random();
        int totalScore = 0;
        List<Question> questions = QuestionList;
        questions.Add(new MultipleChoice("Vad är störst?", 10, 2, new List<string>{"månen", "solen"}));
        questions.Add(new FreeText("Vad heter Krister i efternamn?", 15, "Trangius"));
        Console.Clear();
        while(questions.Count > 0)
        {
            int num = random.Next(0, questions.Count);
            Console.WriteLine(questions[num]);
            Console.Write("svar: ");
            string userInput = Console.ReadLine()!;
            if(questions[num].CheckAnswer(userInput) == true)
            {
                Console.WriteLine("Korrekt! Bra jobbat!");
                totalScore += questions[num].Points;
            }
            else
            {
                Console.WriteLine($"Fel! Tyvärr.");
            }
            questions.RemoveAt(num);
            if(questions.Count > 0)
            {
                Console.WriteLine("Fortsätt spela? [J]a [N]ej");
                userInput = Console.ReadLine()!;
                if(userInput.ToLower() == "n")
                    break;
                else
                    Console.Clear();
            }
        }
        Console.WriteLine($"Spelet är slut, din poängtotal blev: {totalScore}");
        Console.WriteLine("Tryck på valfri tangent för att gå tillbaks till menyn");
        Console.ReadKey();
    }
    static void UIQuestionInput()
    {
        Console.Clear();
        Console.WriteLine("Välj typ av fråga:\n1. Flervalsalternativ\n2. Fritext\n3. 1-10\n4. Gissa årtal\n5. 1,X,2");
        int type = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
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
                int answer = Convert.ToInt32(Console.ReadLine());
                AddQuestion(new MultipleChoice(q, p, answer, options));
            }
            break;
            case 2:
            {
                Console.Write("Vad är det korrekta svaret?: ");
                string answer = Console.ReadLine()!;
                AddQuestion(new FreeText(q, p, answer));
            }
            break;
            case 3:
            {
                List<string> options = new List<string>();
                Console.WriteLine("Skriv in svarsalternativ.");
                for(int i = 1; i <= 10; i++)
                {
                    Console.Write($"Alternativ {i}: ");
                    string userInput = Console.ReadLine()!;
                    options.Add(userInput);
                }
                Console.Write("Vilket alternativ är rätt?: ");
                int answer = Convert.ToInt32(Console.ReadLine());
                AddQuestion(new OneToTen(q, p, answer, options));
            }
            break;
            case 4:
            {
                Console.Write("Vad är det korrekta svaret?: ");
                int answer = Convert.ToInt32(Console.ReadLine());
                AddQuestion(new GuessYear(q, p, answer));
            }
            break;
            case 5:
            {
                List<string> options = new List<string>();
                Console.WriteLine("Skriv in svarsalternativ.");
                for(int i = 0; i < 3; i++)
                {
                    switch(i)
                    {
                        case 0:
                            Console.Write($"Alternativ 1: ");
                        break;
                        case 1:
                            Console.Write($"Alternativ X: ");
                        break;
                        case 2:
                            Console.Write($"Alternativ 2: ");
                        break;
                    }
                    string userInput = Console.ReadLine()!;
                    options.Add(userInput);
                }
                Console.Write("Vilket alternativ är rätt?: ");
                string answer = Console.ReadLine()!;
                AddQuestion(new OneXTwo(q, p, answer, options));
            }
            break;
        }
    }
    public static void AddQuestion(Question question)
    {
        QuestionList.Add(question);
    }
}