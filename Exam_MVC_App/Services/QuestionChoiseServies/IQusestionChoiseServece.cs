using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.QuestionChoiseServies
{
    public interface IQusestionChoiseServece
    {
        List<Question_Choice> GetQuestionsCohise();
        Question_Choice? GetQuestionChoiseById(byte Id);
        Task<int> UpdateQuestionChoiseAsync(byte Id, Question_Choice qusestionChoise);
        Task<int> DeleteQuestionChoiseAsync(byte Id);
    }
}

