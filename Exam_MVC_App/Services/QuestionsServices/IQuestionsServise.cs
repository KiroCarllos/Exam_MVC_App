using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.QuestionsServices
{
    public interface IQuestionsServise
    {
        List <Question> GetQuestions();
        Question? GetQuestionById(byte Id);
        Task<int> UpdateQuestionAsync(byte Id, Question questionRequest);
        Task<int> DeleteQuestionAsync(byte Id);
    }
}
