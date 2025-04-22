using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using BuilderConstruction.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuilderConstructionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTasksController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        Modelmessage Modelmessage;
        public ProjectTasksController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            Modelmessage = new Modelmessage();
        }
        [HttpGet]
        public async Task<IEnumerable<ProjectTask>> GetAll()
        {
            IEnumerable<ProjectTask> all = new List<ProjectTask>();
            try
            {
                all = await _unitOfWork.ProjectTaskRepo.GetAll();
            }
            catch (Exception ex)
            {
                all = new List<ProjectTask>();
            }
            return all;
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> PostCategory(List<ProjectTask> ProjectTask)
        {
            try
            {

                _unitOfWork.ProjectTaskRepo.Add(ProjectTask);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = ProjectTask, result = Modelmessage });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(ProjectTask ProjectTask)
        {
            try
            {
                //var isExist = await _unitOfWork.ProjectTaskRepo.GetAll(c => c.Name.ToLower().Equals(ProjectTask.Name.ToLower()), null);
                //if (isExist.Any())
                //{
                //    return Problem($"{ProjectTask.Name} already exist");
                //}
                _unitOfWork.ProjectTaskRepo.Add(ProjectTask);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = ProjectTask, result = Modelmessage });
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
        public async Task<ProjectTask> GetById(int id)
        {
            return await _unitOfWork.ProjectTaskRepo.GetById(id);
        }
        [HttpPut]
        public void PutCategory(ProjectTask ProjectTask)
        {
            _unitOfWork.ProjectTaskRepo.Update(ProjectTask);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async void Delete(int id)
        {
            _unitOfWork.ProjectTaskRepo.DeletebyID(x => x.Id == id);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteByEntity")]
        public void Delete(ProjectTask ProjectTask)
        {
            _unitOfWork.ProjectTaskRepo.Delete(ProjectTask);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteRange")]
        public void DeleteRange(IEnumerable<ProjectTask> companies)
        {
            _unitOfWork.ProjectTaskRepo.DeleteRange(companies);
            _unitOfWork.Save();
        }

    }
}
