using System.ComponentModel;

namespace Quiz;
public class Question
{
    public string Body{get; set;}
    public int Points{get; set;}
    public Question(string body, int points)
    {
        Body = body;
        Points = points;
    }
    public override string ToString()
    {
        return $"Fråga: {Body}\nPoäng: {Points}";
    }
    public virtual bool CheckAnswer(string userInput)
    {
        return false;
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
    public override string ToString()
    {
        string optionList = "\nSvarsalternativ:";
        for(int i = 0; i < Options.Count; i++)
        {
            optionList += $"\n{i+1}. {Options[i]}";
        }
        return base.ToString() + optionList;
    }
    public override bool CheckAnswer(string userInput)
    {
        int intAnswer = Convert.ToInt32(userInput);
        if(intAnswer == Answer)
            return true;
        else
            return false;
    }
}
class FreeText : Question
{
    public string Answer{get; set;}
    public FreeText(string body, int points, string answer) : base(body, points)
    {
        Answer = answer;
    }
    public override bool CheckAnswer(string userInput)
    {
        if(userInput.ToLower() == Answer.ToLower())
            return true;
        else
            return false;
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
    public override string ToString()
    {
        string optionList = "\nSvarsalternativ:";
        for(int i = 1; i <= 10; i++)
        {
            optionList += $"\n{i}. {Options[i-1]}";
        }
        return base.ToString() + optionList;
    }
    public override bool CheckAnswer(string userInput)
    {
        int intAnswer = Convert.ToInt32(userInput);
        if(intAnswer == Answer)
            return true;
        else
            return false;
    }
}
class GuessYear : Question
{
    public int Answer{get; set;}
    public GuessYear(string body, int points, int answer) : base(body, points)
    {
        Answer = answer;
    }
    public override bool CheckAnswer(string userInput)
    {
        int intAnswer = Convert.ToInt32(userInput);
        if(intAnswer == Answer)
            return true;
        else
            return false;
    }
}
class OneXTwo : Question
{
    private List<string> Options;
    public string Answer{get; set;}
    public OneXTwo(string body, int points, string answer, List<string> options) : base(body, points)
    {
        Answer = answer;
        Options = options;
    }
    public override string ToString()
    {
        string optionList = "\nSvarsalternativ:";
        for(int i = 0; i < 3; i++)
        {
            switch(i)
            {
                case 0:
                    optionList += $"\n1. {Options[i]}";
                break;
                case 1:
                    optionList += $"\nX. {Options[i]}";
                break;
                case 2:
                    optionList += $"\n2. {Options[i]}";
                break;
            }
        }
        return base.ToString() + optionList;
    }
    public override bool CheckAnswer(string userInput)
    {
        if(userInput == Answer)
            return true;
        else
            return false;
    }
}