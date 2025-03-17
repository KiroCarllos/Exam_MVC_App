using Exam_MVC_App.Data;
using Exam_MVC_App.Dtos.BranchDtos;
using Exam_MVC_App.Models;
using Microsoft.EntityFrameworkCore;
using Exam_MVC_App.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Exam_MVC_App.Services.QuestionsServices
{
    public class QuestionsService(AppDBContext _db, IAppDBContextProcedures _sp) : IQuestionsServise
    {
        public Task<int> DeleteQuestionAsync(byte Id)
        {
            return _sp.sp_DeleteQuestionAsync(Id);
        }
        public Question? GetQuestionById(byte Id)
        {
            return _db.Questions.Where(q => q.Id == Id).FirstOrDefault();
        }
        public List<Question> GetQuestions()
        {
            return _db.Questions.ToList();
        }
        public Question GeteditQuestio(string Name)
        {
            return _db.Questions.Where(q => q.Name == Name).FirstOrDefault();
        }
        [HttpPost]
        [Route("Questions/Update/{Id}")]

        public async Task<int> UpdateQuestionAsync(byte Id, Question qusRequest)
        {
            return await _sp.sp_UpdateQuestionAsync(
               Id,
                qusRequest.Name,
                qusRequest.Type
                , qusRequest.Type_Difficult,
                qusRequest.Mark,
                qusRequest.Type_Multi_Single,
                qusRequest.Course_Id);
        }
        [HttpGet]
        [Route("Questions/delete/{Id}")]
        public async Task<int> DeleteQuestionAsync(byte Id, Question qusRequest)
        {
            return await _sp.sp_DeleteQuestionAsync(
               Id);
              
        }


    }
}
