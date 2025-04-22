using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using BuilderConstruction.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuilderConstructionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        Modelmessage Modelmessage;
        public ProjectsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            Modelmessage = new Modelmessage();
        }
        [HttpGet]
        public async Task<IEnumerable<Project>> GetAll()
        {
            IEnumerable<Project> all = new List<Project>();
            try
            {
                all = await _unitOfWork.ProjectRepo.GetAll();
            }
            catch (Exception ex)
            {
                all = new List<Project>();
            }
            return all;
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> PostCategory(List<Project> Project)
        {
            try
            {

                _unitOfWork.ProjectRepo.Add(Project);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = Project, result = Modelmessage });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(Project Project)
        {
            try
            {
                //var isExist = await _unitOfWork.BuildingTaskRepo.GetAll(c => c.Name.ToLower().Equals(BuildingTask.Name.ToLower()), null);
                //if (isExist.Any())
                //{
                //    return Problem($"{BuildingTask.Name} already exist");
                //}
                _unitOfWork.ProjectRepo.Add(Project);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = Project, result = Modelmessage });
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
        public async Task<Project> GetById(int id)
        {
            return await _unitOfWork.ProjectRepo.GetById(id);
        }
        [HttpPut]
        public void PutCategory(Project Project)
        {
            _unitOfWork.ProjectRepo.Update(Project);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async void Delete(int id)
        {
            _unitOfWork.ProjectRepo.DeletebyID(x => x.Id == id);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteByEntity")]
        public void Delete(Project Project)
        {
            _unitOfWork.ProjectRepo.Delete(Project);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteRange")]
        public void DeleteRange(IEnumerable<Project> projects)
        {
            _unitOfWork.ProjectRepo.DeleteRange(projects);
            _unitOfWork.Save();
        }
    }
}
