using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using BuilderConstruction.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuilderConstructionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskDetailsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        Modelmessage Modelmessage;
        public TaskDetailsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            Modelmessage = new Modelmessage();
        }
        [HttpGet]
        public async Task<IEnumerable<TaskDetail>> GetAll()
        {
            IEnumerable<TaskDetail> all = new List<TaskDetail>();
            try
            {
                all = await _unitOfWork.TaskDetailRepo.GetAll();
            }
            catch (Exception ex)
            {
                all = new List<TaskDetail>();
            }
            return all;
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> PostCategory(List<TaskDetail> TaskDetail)
        {
            try
            {

                _unitOfWork.TaskDetailRepo.Add(TaskDetail);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = TaskDetail, result = Modelmessage });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(TaskDetail TaskDetail)
        {
            try
            {
                //var isExist = await _unitOfWork.TaskDetailRepo.GetAll(c => c.Id.Equals(TaskDetail.Id), null);
                ////var isExist = await _unitOfWork.TaskDetailRepo.GetAll(c => c.Name.ToLower().Equals(TaskDetail.Name.ToLower()), null);
                //if (isExist.Any())
                //{
                //    return Problem($"{TaskDetail.Id} already exist");
                //}
                _unitOfWork.TaskDetailRepo.Add(TaskDetail);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = TaskDetail, result = Modelmessage });
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
        public async Task<TaskDetail> GetById(int id)
        {
            return await _unitOfWork.TaskDetailRepo.GetById(id);
        }
        [HttpPut]
        public void PutCategory(TaskDetail TaskDetail)
        {
            _unitOfWork.TaskDetailRepo.Update(TaskDetail);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async void Delete(int id)
        {
            _unitOfWork.TaskDetailRepo.DeletebyID(x => x.Id == id);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteByEntity")]
        public void Delete(TaskDetail TaskDetail)
        {
            _unitOfWork.TaskDetailRepo.Delete(TaskDetail);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteRange")]
        public void DeleteRange(IEnumerable<TaskDetail> companies)
        {
            _unitOfWork.TaskDetailRepo.DeleteRange(companies);
            _unitOfWork.Save();
        }

    }
}
