using System.Runtime.CompilerServices;

namespace Quiz;

public class AdminTools
{
    public static List<Question> QuestionList = new List<Question>();
    public static void AddQuestion(int type, string question, int points, string stringAnswer, List<string> options)
    {
        switch(type)
        {
            case 1:
            {
                int intAnswer = Convert.ToInt32(stringAnswer);
                QuestionList.Add(new MultipleChoice(question, points, intAnswer, options));
            }
            break;
            case 2:
            {
                QuestionList.Add(new FreeText(question, points, stringAnswer));
            }
            break;
            case 3:
            {
                int intAnswer = Convert.ToInt32(stringAnswer);
                QuestionList.Add(new OneToTen(question, points, intAnswer, options));
            }
            break;
        }
    }
}