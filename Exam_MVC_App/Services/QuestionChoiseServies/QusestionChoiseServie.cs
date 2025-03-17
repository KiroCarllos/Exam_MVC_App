using Exam_MVC_App.Data;
using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.QuestionChoiseServies
{
    public class QusestionChoiseServie(AppDBContext _db, IAppDBContextProcedures _sp) : IQusestionChoiseServece
    {
        public Task<int> DeleteQuestionChoiseAsync(byte Id)
        {
            return _sp.sp_delete_choiceAsync(Id);
        }
        public Question_Choice? GetQuestionChoiseById(byte Id)
        {
            return _db.Question_Choices.Where(q => q.Id == Id).FirstOrDefault();
        }
        public List<Question_Choice> GetQuestionsCohise()
        {
            return _db.Question_Choices.ToList();
        }
        public Task<int> UpdateQuestionChoiseAsync(byte Id, Question_Choice qusestionChoise)
        {
            return _sp.sp_update_choiceAsync(
                Id,
                qusestionChoise.Choice,
                qusestionChoise.Choice_Type,
                qusestionChoise.Question_Id);
        }
    }
}
