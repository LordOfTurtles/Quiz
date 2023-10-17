namespace Quiz;
public class Question
{
    public string? Body{get; set;}
    public int Points{get; set;}
    public Question(string body, int points)
    {
        Body = body;
        Points = points;
    }
    public virtual void AskQuestion(out int score)
    {
        score = 0;
        Console.WriteLine(Body);
        Console.WriteLine("Poäng: " + Points);
    }
}
class MultipleChoice : Question
{
    private List<string> Options{get; set;}
    public int Answer{get; set;}
    public MultipleChoice(string body, int points, int answer, List<string> options) : base(body, points)
    {
        Answer = answer;
        Options = options;
    }
    public override void AskQuestion(out int score)
    {
        base.AskQuestion(out score);
        for(int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine($"{i+1}. {Options[i]}");
        }
        Console.Write($"Välj alternativ (1-{Options.Count}): ");
        int userInput = Convert.ToInt32(Console.ReadLine());
        if(userInput == Answer)
        {
            Console.WriteLine("Korrekt! Hurra!");
            score = Points;
        }
        else
        {
            Console.WriteLine("Fel! Fan va dålig du e");
        }
    }
}
class FreeText : Question
{
    public string Answer{get; set;}
    public FreeText(string body, int points, string answer) : base(body, points)
    {
        Answer = answer;
    }
    public override void AskQuestion(out int score)
    {
        base.AskQuestion(out score);
        Console.Write("Svar: ");
        string userInput = Console.ReadLine()!;
        if(userInput.ToLower() == Answer.ToLower())
        {
            Console.WriteLine("Korrekt! Hurra!");
            score = Points;
        }
        else
        {
            Console.WriteLine("Fel! Fan va dålig du e");
        }
    }
}
class OneToTen : Question
{
    private List<string> Options;
    public int Answer{get; set;}
    public OneToTen(string body, int points, int answer, List<string> options) : base(body, points)
    {
        Answer = answer;
        Options = options;
    }
    public override void AskQuestion(out int score)
    {
        base.AskQuestion(out score);
        for(int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{i}. {Options[i-1]}");
        }
        Console.Write($"Välj alternativ (1-10): ");
        int userInput = Convert.ToInt32(Console.ReadLine());
        if(userInput == Answer)
        {
            Console.WriteLine("Korrekt! Hurra!");
            score = Points;
        }
        else
        {
            Console.WriteLine("Fel! Fan va dålig du e");
        }
    }
}