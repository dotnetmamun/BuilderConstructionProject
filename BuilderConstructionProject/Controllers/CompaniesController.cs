using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using BuilderConstruction.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuilderConstructionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        Modelmessage Modelmessage;
        public CompaniesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            Modelmessage = new Modelmessage();
        }
        [HttpGet]
        public async Task<IEnumerable<Company>> GetAll()
        {
            IEnumerable<Company> all = new List<Company>();
            try
            {
                all = await _unitOfWork.CopmanyRepo.GetAll();
            }
            catch (Exception ex)
            {
                all = new List<Company>();
            }
            return all;
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> PostCategory(List<Company> Company)
        {
            try
            {

                _unitOfWork.CopmanyRepo.Add(Company);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = Company, result = Modelmessage });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(Company Company)
        {
            try
            {
                var isExist = await _unitOfWork.CopmanyRepo.GetAll(c => c.Name.ToLower().Equals(Company.Name.ToLower()), null);
                if (isExist.Any())
                {
                    return Problem($"{Company.Name} already exist");
                }
                _unitOfWork.CopmanyRepo.Add(Company);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = Company, result = Modelmessage });
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
        public async Task<Company> GetById(int id)
        {
            return await _unitOfWork.CopmanyRepo.GetById(id);
        }
        [HttpPut]
        public void PutCategory(Company Company)
        {
            _unitOfWork.CopmanyRepo.Update(Company);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async void Delete(int id)
        {
            _unitOfWork.CopmanyRepo.DeletebyID(x => x.Id == id);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteByEntity")]
        public void Delete(Company Company)
        {
            _unitOfWork.CopmanyRepo.Delete(Company);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteRange")]
        public void DeleteRange(IEnumerable<Company> companies)
        {
            _unitOfWork.CopmanyRepo.DeleteRange(companies);
            _unitOfWork.Save();
        }

    }
}
