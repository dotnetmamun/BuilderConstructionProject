using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using BuilderConstruction.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuilderConstructionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        Modelmessage Modelmessage;
        public PicturesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            Modelmessage = new Modelmessage();
        }
        [HttpGet]
        public async Task<IEnumerable<Picture>> GetAll()
        {
            IEnumerable<Picture> all = new List<Picture>();
            try
            {
                all = await _unitOfWork.PictureRepo.GetAll();
            }
            catch (Exception ex)
            {
                all = new List<Picture>();
            }
            return all;
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> PostCategory(List<Picture> Picture)
        {
            try
            {

                _unitOfWork.PictureRepo.Add(Picture);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = Picture, result = Modelmessage });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(Picture Picture)
        {
            try
            {
                var isExist = await _unitOfWork.PictureRepo.GetAll(c => c.Name.ToLower().Equals(Picture.Name.ToLower()), null);
                if (isExist.Any())
                {
                    return Problem($"{Picture.Name} already exist");
                }
                _unitOfWork.PictureRepo.Add(Picture);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = Picture, result = Modelmessage });
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
        public async Task<Picture> GetById(int id)
        {
            return await _unitOfWork.PictureRepo.GetById(id);
        }
        [HttpPut]
        public void PutCategory(Picture Picture)
        {
            _unitOfWork.PictureRepo.Update(Picture);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async void Delete(int id)
        {
            _unitOfWork.PictureRepo.DeletebyID(x => x.Id == id);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteByEntity")]
        public void Delete(Picture Picture)
        {
            _unitOfWork.PictureRepo.Delete(Picture);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteRange")]
        public void DeleteRange(IEnumerable<Picture> companies)
        {
            _unitOfWork.PictureRepo.DeleteRange(companies);
            _unitOfWork.Save();
        }

    }
}
