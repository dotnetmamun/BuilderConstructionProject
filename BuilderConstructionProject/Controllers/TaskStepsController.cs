using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using BuilderConstruction.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuilderConstructionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStepsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        Modelmessage Modelmessage;
        public TaskStepsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            Modelmessage = new Modelmessage();
        }
        [HttpGet]
        public async Task<IEnumerable<TaskStep>> GetAll()
        {
            IEnumerable<TaskStep> all = new List<TaskStep>();
            try
            {
                all = await _unitOfWork.TaskStepRepo.GetAll();
            }
            catch (Exception ex)
            {
                all = new List<TaskStep>();
            }
            return all;
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> PostCategory(List<TaskStep> TaskStep)
        {
            try
            {

                _unitOfWork.TaskStepRepo.Add(TaskStep);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = TaskStep, result = Modelmessage });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(TaskStep TaskStep)
        {
            try
            {
                //var isExist = await _unitOfWork.TaskStepRepo.GetAll(c => c.Name.ToLower().Equals(TaskStep.Name.ToLower()), null);
                //if (isExist.Any())
                //{
                //    return Problem($"{TaskStep.Name} already exist");
                //}
                _unitOfWork.TaskStepRepo.Add(TaskStep);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = TaskStep, result = Modelmessage });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<TaskStep> GetById(int id)
        {
            return await _unitOfWork.TaskStepRepo.GetById(id);
        }
        [HttpPut]
        public void PutCategory(TaskStep TaskStep)
        {
            _unitOfWork.TaskStepRepo.Update(TaskStep);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async void Delete(int id)
        {
            _unitOfWork.TaskStepRepo.DeletebyID(x => x.Id == id);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteByEntity")]
        public void Delete(TaskStep TaskStep)
        {
            _unitOfWork.TaskStepRepo.Delete(TaskStep);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteRange")]
        public void DeleteRange(IEnumerable<TaskStep> companies)
        {
            _unitOfWork.TaskStepRepo.DeleteRange(companies);
            _unitOfWork.Save();
        }

    }
}
