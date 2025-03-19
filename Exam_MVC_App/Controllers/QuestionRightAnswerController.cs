using Exam_MVC_App.Models;
using Exam_MVC_App.Services.QuestionRightAnswerServices;
using Exam_MVC_App.Services.QuestionsServices;
using Microsoft.AspNetCore.Mvc;

namespace Exam_MVC_App.Controllers
{
    public class QuestionRightAnswerController (IQuestionRightAnswerservice _questionRightAnswerservice, IQuestionsServise _question) : Controller
    {
        public IActionResult Index()
        {
           ViewBag.Question= _question.GetQuestions();
            return View(_questionRightAnswerservice.GetQuestionRightAnswer());
        }
        [HttpGet]
        public IActionResult Edit(byte Id)
        {
            ViewBag.Question = _question.GetQuestions();

            return View(_questionRightAnswerservice.GetQuestionRightAnswerById(Id));

        }
        [HttpPost]
        [Route("QuestionRightAnswer/Update/{Id}")]
        public async Task<IActionResult> Update(byte Id, Question_Right_Answer _Right_Answer)
        {
            var result = await _questionRightAnswerservice.UpdateQuestionRightAnswerAsync(Id, _Right_Answer);
            TempData["Message"] = result == 1 ? "Question Updated Successfully" : "Question Not updated";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(byte Id)
        {
            var result = await _questionRightAnswerservice.DeleteQuestionRightAnswerAsync(Id);
            TempData["Message"] = result == 1 ? "answer Deleted Successfully" : "can not deleted";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        [Route("QuestionRightAnswer/AddNew")]
        public async Task<IActionResult> AddNew(Question_Right_Answer qusestionRightChoise)
        {
            var result = await _questionRightAnswerservice.AddQuestionRightAnswerAsync(qusestionRightChoise);
            TempData["Message"] = result == 1 ? "answer Added Successfully" : "answer Not Added";
            return RedirectToAction("Index");

        }



    }
}
