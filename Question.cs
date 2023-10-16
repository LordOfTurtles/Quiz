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
    public virtual void AskQuestion()
    {
        Console.WriteLine(Body);
        Console.WriteLine("Poäng: " + Points);
    }
}
class MultipleChoice : Question
{
    public List<string> Options{get; set;}
    public int Answer{get; set;}
    public MultipleChoice(string body, int points, int answer, List<string> options) : base(body, points)
    {
        Answer = answer;
        Options = options;
    }
    public override void AskQuestion()
    {
        base.AskQuestion();
        for(int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine($"{i+1}. {Options[i]}");
        }
        Console.Write($"Välj alternativ (1-{Options.Count}): ");
        int userInput = Convert.ToInt32(Console.ReadLine());
        if(userInput == Answer)
        {
            Console.WriteLine("Korrekt! Hurra!");
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
    public override void AskQuestion()
    {
        base.AskQuestion();
        Console.Write("Svar: ");
        string userInput = Console.ReadLine()!;
        if(userInput.ToLower() == Answer)
        {
            Console.WriteLine("Korrekt! Hurra!");
        }
        else
        {
            Console.WriteLine("Fel! Fan va dålig du e");
        }
    }
}