using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using BuilderConstruction.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuilderConstructionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        Modelmessage Modelmessage;
        public UnitsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            Modelmessage = new Modelmessage();
        }
        [HttpGet]
        public async Task<IEnumerable<Unit>> GetAll()
        {
            IEnumerable<Unit> all = new List<Unit>();
            try
            {
                all = await _unitOfWork.UnitRepo.GetAll();
            }
            catch (Exception ex)
            {
                all = new List<Unit>();
            }
            return all;
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> PostCategory(List<Unit> Unit)
        {
            try
            {

                _unitOfWork.UnitRepo.Add(Unit);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = Unit, result = Modelmessage });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(Unit Unit)
        {
            try
            {
                var isExist = await _unitOfWork.UnitRepo.GetAll(c => c.Name.ToLower().Equals(Unit.Name.ToLower()), null);
                if (isExist.Any())
                {
                    return Problem($"{Unit.Name} already exist");
                }
                _unitOfWork.UnitRepo.Add(Unit);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = Unit, result = Modelmessage });
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
        public async Task<Unit> GetById(int id)
        {
            return await _unitOfWork.UnitRepo.GetById(id);
        }
        [HttpPut]
        public void PutCategory(Unit Unit)
        {
            _unitOfWork.UnitRepo.Update(Unit);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async void Delete(int id)
        {
            _unitOfWork.UnitRepo.DeletebyID(x => x.Id == id);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteByEntity")]
        public void Delete(Unit Unit)
        {
            _unitOfWork.UnitRepo.Delete(Unit);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteRange")]
        public void DeleteRange(IEnumerable<Unit> companies)
        {
            _unitOfWork.UnitRepo.DeleteRange(companies);
            _unitOfWork.Save();
        }

    }
}
