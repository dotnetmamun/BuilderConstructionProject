using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using BuilderConstruction.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuilderConstructionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCostDetailsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        Modelmessage Modelmessage;
        public ProjectCostDetailsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            Modelmessage = new Modelmessage();
        }
        [HttpGet]
        public async Task<IEnumerable<ProjectCostDetail>> GetAll()
        {
            IEnumerable<ProjectCostDetail> all = new List<ProjectCostDetail>();
            try
            {
                all = await _unitOfWork.ProjectCostDetailRepo.GetAll();
            }
            catch (Exception ex)
            {
                all = new List<ProjectCostDetail>();
            }
            return all;
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> PostCategory(List<ProjectCostDetail> ProjectCostDetail)
        {
            try
            {

                _unitOfWork.ProjectCostDetailRepo.Add(ProjectCostDetail);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = ProjectCostDetail, result = Modelmessage });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(ProjectCostDetail ProjectCostDetail)
        {
            try
            {
                //var isExist = await _unitOfWork.ProjectCostDetailRepo.GetAll(c => c.Name.ToLower().Equals(ProjectCostDetail.Name.ToLower()), null);
                //if (isExist.Any())
                //{
                //    return Problem($"{ProjectCostDetail.Name} already exist");
                //}
                _unitOfWork.ProjectCostDetailRepo.Add(ProjectCostDetail);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = ProjectCostDetail, result = Modelmessage });
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
        public async Task<ProjectCostDetail> GetById(int id)
        {
            return await _unitOfWork.ProjectCostDetailRepo.GetById(id);
        }
        [HttpPut]
        public void PutCategory(ProjectCostDetail ProjectCostDetail)
        {
            _unitOfWork.ProjectCostDetailRepo.Update(ProjectCostDetail);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async void Delete(int id)
        {
            _unitOfWork.ProjectCostDetailRepo.DeletebyID(x => x.Id == id);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteByEntity")]
        public void Delete(ProjectCostDetail ProjectCostDetail)
        {
            _unitOfWork.ProjectCostDetailRepo.Delete(ProjectCostDetail);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteRange")]
        public void DeleteRange(IEnumerable<ProjectCostDetail> companies)
        {
            _unitOfWork.ProjectCostDetailRepo.DeleteRange(companies);
            _unitOfWork.Save();
        }

    }
}
