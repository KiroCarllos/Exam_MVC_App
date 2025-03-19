using Exam_MVC_App.Controllers;
using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.QuestionRightAnswerServices
{
    public interface IQuestionRightAnswerservice
    {
            List<Question_Right_Answer> GetQuestionRightAnswer();
        Question_Right_Answer? GetQuestionRightAnswerById(byte Id);
            Task<int> UpdateQuestionRightAnswerAsync(byte Id, Question_Right_Answer questionRightAnswerRequest);
            Task<int> DeleteQuestionRightAnswerAsync(byte Id);
        Task<int> AddQuestionRightAnswerAsync(Question_Right_Answer questionRightAnswerRequest);
    }
    }



