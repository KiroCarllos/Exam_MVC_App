using Exam_MVC_App.Controllers;
using Exam_MVC_App.Data;
using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.QuestionRightAnswerServices
{
    public class QuestionRightAnswerService (AppDBContext _db, IAppDBContextProcedures _sp) : IQuestionRightAnswerservice
    {
        public Task<int> DeleteQuestionRightAnswerAsync(byte Id)
        {
            return _sp.sp_DeleteRightAnswerAsync(Id);
        }

        public List<Question_Right_Answer> GetQuestionRightAnswer()
        {
            return _db.Question_Right_Answers.ToList();
        }

        public Question_Right_Answer? GetQuestionRightAnswerById(byte Id)
        {
            return _db.Question_Right_Answers.Where(q => q.Id == Id).FirstOrDefault();

        }

        public Task<int> UpdateQuestionRightAnswerAsync(byte Id, Question_Right_Answer questionRightAnswerRequest)
        {
            return _sp.sp_UpdateRightAnswerAsync(Id, questionRightAnswerRequest.Right_Answer, questionRightAnswerRequest.Question_Id);
        }       }
}
