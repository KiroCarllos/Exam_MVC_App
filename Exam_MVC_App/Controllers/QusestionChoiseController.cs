using Exam_MVC_App.Models;
using Exam_MVC_App.Services.QuestionChoiseServies;
using Exam_MVC_App.Services.QuestionsServices;
using Microsoft.AspNetCore.Mvc;

namespace Exam_MVC_App.Controllers
{
    public class QusestionChoiseController(IQusestionChoiseServece _QuestionChoiseServices , IQuestionsServise _questionsServise) : Controller
    {
        public IActionResult Index()
        {
            return View(_QuestionChoiseServices.GetQuestionsCohise());
        }
        [HttpGet]
        public IActionResult Edit(byte Id)
        {
            ViewBag.question = _questionsServise.GetQuestions();
            return View(_QuestionChoiseServices.GetQuestionChoiseById(Id));
        }
        [HttpPost]
        [Route("QusestionChoise/Update/{Id}")]
        public async Task<IActionResult> Update(byte Id, Question_Choice qusestionChoise)
        {
            var result = await _QuestionChoiseServices.UpdateQuestionChoiseAsync(Id, qusestionChoise);
            TempData["Message"] = result == 1 ? "answer Updated Successfully" : "answer Not Updated";
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(byte Id)
        {
            var result = await _QuestionChoiseServices.DeleteQuestionChoiseAsync(Id);
            TempData["Message"] = result == 1 ? "answer Deleted Successfully" : "can not deleted";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
        
            return View();
        }
        [HttpPost]
        [Route ("QusestionChoise/AddNew")]
        public async Task<IActionResult>AddNew(Question_Choice qusestionChoise)
        {
            var result = await _QuestionChoiseServices.AddQuestionChoiseAsync(qusestionChoise);
            TempData["Message"] = result == 1 ? "answer Added Successfully" : "answer Not Added";
            return RedirectToAction("Index");

        }
    }
}
