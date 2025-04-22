using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using BuilderConstruction.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuilderConstructionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        Modelmessage Modelmessage;
        public MaterialsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            Modelmessage = new Modelmessage();
        }
        [HttpGet]
        public async Task<IEnumerable<Material>> GetAll()
        {
            IEnumerable<Material> all = new List<Material>();
            try
            {
                all = await _unitOfWork.MaterialRepo.GetAll();
            }
            catch (Exception ex)
            {
                all = new List<Material>();
            }
            return all;
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> PostCategory(List<Material> Material)
        {
            try
            {

                _unitOfWork.MaterialRepo.Add(Material);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = Material, result = Modelmessage });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(Material Material)
        {
            try
            {
                var isExist = await _unitOfWork.MaterialRepo.GetAll(c => c.Name.ToLower().Equals(Material.Name.ToLower()), null);
                if (isExist.Any())
                {
                    return Problem($"{Material.Name} already exist");
                }
                _unitOfWork.MaterialRepo.Add(Material);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = Material, result = Modelmessage });
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
        public async Task<Material> GetById(int id)
        {
            return await _unitOfWork.MaterialRepo.GetById(id);
        }
        [HttpPut]
        public void PutCategory(Material Material)
        {
            _unitOfWork.MaterialRepo.Update(Material);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async void Delete(int id)
        {
            _unitOfWork.MaterialRepo.DeletebyID(x => x.Id == id);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteByEntity")]
        public void Delete(Material Material)
        {
            _unitOfWork.MaterialRepo.Delete(Material);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteRange")]
        public void DeleteRange(IEnumerable<Material> companies)
        {
            _unitOfWork.MaterialRepo.DeleteRange(companies);
            _unitOfWork.Save();
        }

    }
}
