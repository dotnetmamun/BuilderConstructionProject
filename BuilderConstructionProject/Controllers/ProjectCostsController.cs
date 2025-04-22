using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using BuilderConstruction.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuilderConstructionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCostsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        Modelmessage Modelmessage;
        public ProjectCostsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            Modelmessage = new Modelmessage();
        }
        [HttpGet]
        public async Task<IEnumerable<ProjectCost>> GetAll()
        {
            IEnumerable<ProjectCost> all = new List<ProjectCost>();
            try
            {
                all = await _unitOfWork.ProjectCostRepo.GetAll();
            }
            catch (Exception ex)
            {
                all = new List<ProjectCost>();
            }
            return all;
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> PostCategory(List<ProjectCost> ProjectCost)
        {
            try
            {

                _unitOfWork.ProjectCostRepo.Add(ProjectCost);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = ProjectCost, result = Modelmessage });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(ProjectCost ProjectCost)
        {
            try
            {
                //var isExist = await _unitOfWork.ProjectCostRepo.GetAll(c => c.Name.ToLower().Equals(ProjectCost.Name.ToLower()), null);
                //if (isExist.Any())
                //{
                //    return Problem($"{ProjectCost.Name} already exist");
                //}
                _unitOfWork.ProjectCostRepo.Add(ProjectCost);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = ProjectCost, result = Modelmessage });
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
        public async Task<ProjectCost> GetById(int id)
        {
            return await _unitOfWork.ProjectCostRepo.GetById(id);
        }
        [HttpPut]
        public void PutCategory(ProjectCost ProjectCost)
        {
            _unitOfWork.ProjectCostRepo.Update(ProjectCost);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async void Delete(int id)
        {
            _unitOfWork.ProjectCostRepo.DeletebyID(x => x.Id == id);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteByEntity")]
        public void Delete(ProjectCost ProjectCost)
        {
            _unitOfWork.ProjectCostRepo.Delete(ProjectCost);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteRange")]
        public void DeleteRange(IEnumerable<ProjectCost> companies)
        {
            _unitOfWork.ProjectCostRepo.DeleteRange(companies);
            _unitOfWork.Save();
        }

    }
}
