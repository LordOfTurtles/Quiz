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
}
class MultipleChoice : Question
{
        public List<string> Options{get; set;}
        public string Answer{get; set;}
        public MultipleChoice(string body, int points, string answer, List<string> options) : base(body, points)
        {
            Body = body;
            Points = points;
            Answer = answer;
            Options = options;
        }
}