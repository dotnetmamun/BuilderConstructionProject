using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using BuilderConstruction.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuilderConstructionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingTasksController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        Modelmessage Modelmessage;
        public BuildingTasksController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            Modelmessage = new Modelmessage();
        }
        [HttpGet]
        public async Task<IEnumerable<BuildingTask>> GetAll()
        {
            IEnumerable<BuildingTask> all = new List<BuildingTask>();
            try
            {
                all = await _unitOfWork.BuildingTaskRepo.GetAll();
            }
            catch (Exception ex)
            {
                all = new List<BuildingTask>();
            }
            return all;
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> PostCategory(List<BuildingTask> BuildingTask)
        {
            try
            {

                _unitOfWork.BuildingTaskRepo.Add(BuildingTask);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = BuildingTask, result = Modelmessage });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(BuildingTask BuildingTask)
        {
            try
            {
                //var isExist = await _unitOfWork.BuildingTaskRepo.GetAll(c => c.Name.ToLower().Equals(BuildingTask.Name.ToLower()), null);
                //if (isExist.Any())
                //{
                //    return Problem($"{BuildingTask.Name} already exist");
                //}
                _unitOfWork.BuildingTaskRepo.Add(BuildingTask);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = BuildingTask, result = Modelmessage });
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
        public async Task<BuildingTask> GetById(int id)
        {
            return await _unitOfWork.BuildingTaskRepo.GetById(id);
        }
        [HttpPut]
        public void PutCategory(BuildingTask BuildingTask)
        {
            _unitOfWork.BuildingTaskRepo.Update(BuildingTask);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async void Delete(int id)
        {
            _unitOfWork.BuildingTaskRepo.DeletebyID(x => x.Id == id);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteByEntity")]
        public void Delete(BuildingTask BuildingTask)
        {
            _unitOfWork.BuildingTaskRepo.Delete(BuildingTask);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteRange")]
        public void DeleteRange(IEnumerable<BuildingTask> companies)
        {
            _unitOfWork.BuildingTaskRepo.DeleteRange(companies);
            _unitOfWork.Save();
        }

    }
}
