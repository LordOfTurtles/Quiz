namespace Quiz;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Console.InputEncoding = System.Text.Encoding.Unicode;
        bool isRunning = true;
        while(isRunning)
        {
            AdminTools.AddQuestion();
            foreach(Question q in AdminTools.QuestionList)
            {
                q.AskQuestion();
            }
        }
    }
}
