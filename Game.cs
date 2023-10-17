namespace Quiz;

class Game
{
    public static void PlayGame()
    {
        Random random = new Random();
        int totalScore = 0;
        List<Question> questions = AdminTools.QuestionList;
        questions.Add(new MultipleChoice("Vad är störst?", 10, 2, new List<string>{"månen", "solen"}));
        questions.Add(new FreeText("Vad heter Krister i efternamn?", 15, "Trangius"));
        while(questions.Count > 0)
        {
            int num = random.Next(0, questions.Count);
            questions[num].AskQuestion(out int score);
            totalScore += score;
            questions.RemoveAt(num);
        }
        Console.WriteLine($"Poängtotal: {totalScore}");
    }
}