using Exam_MVC_App.Data;
using Exam_MVC_App.Models;
using Exam_MVC_App.Services.BranchServices;
using Exam_MVC_App.Services.QuestionsServices;
using Microsoft.AspNetCore.Mvc;

namespace Exam_MVC_App.Controllers
{
    public class QuestionsController(IQuestionsServise _QuestionServices, IQuestionsServise _IQuestions) : Controller
    {
        public IActionResult Index()
        {
            return View(_QuestionServices.GetQuestions());
        }
        [HttpGet]
        public IActionResult Edit(byte Id)
        {
            ViewBag.Managers = _QuestionServices.GetQuestions();

            return View(_QuestionServices.GetQuestionById(Id));

        }
        [HttpPost]
        [Route("Questions/Update/{Id}")]
        public async Task<IActionResult> Update(byte Id, Question questionRequest)
        {
            var result = await _QuestionServices.UpdateQuestionAsync(Id, questionRequest);
            TempData["Message"] = result == 1 ? "Question Updated Successfully" : "Question Not updated";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(byte Id)
        {
            var result = await _QuestionServices.DeleteQuestionAsync(Id);
            TempData["Message"] = result == 1 ? "Question Deleted Successfully" : "To Delete Question Must Delete Ref tables First";
            return RedirectToAction("Index");
        }
    }
}
