namespace Quiz;

class Program
{
    static void Main(string[] args)
    {
        List<Question> q = new List<Question>();
        List<string> options = new List<string>
        {
            "29", "22", "12"      
        };
        MultipleChoice a = new MultipleChoice("hur gammal är jag?", 40, "29", options);
        Console.WriteLine($"{a.Body} {a.Points} {a.Answer}");
        for(int i = 0; i < a.Options.Count; i++)
        {
            Console.WriteLine(a.Options[i]);
        }
        q.Add(a);
    }
}
