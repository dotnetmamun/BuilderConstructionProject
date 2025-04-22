using BuilderConstruction.Infrastructure.Base;
using BuilderConstruction.Models;
using BuilderConstruction.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuilderConstructionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        Modelmessage Modelmessage;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            Modelmessage = new Modelmessage();
        }
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            IEnumerable<Employee> all = new List<Employee>();
            try
            {
                all = await _unitOfWork.EmployeeRepo.GetAll();
            }
            catch (Exception ex)
            {
                all = new List<Employee>();
            }
            return all;
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> PostCategory(List<Employee> Employee)
        {
            try
            {

                _unitOfWork.EmployeeRepo.Add(Employee);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = Employee, result = Modelmessage });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(Employee Employee)
        {
            try
            {
                var isExist = await _unitOfWork.EmployeeRepo.GetAll(c => c.Name.ToLower().Equals(Employee.Name.ToLower()), null);
                if (isExist.Any())
                {
                    return Problem($"{Employee.Name} already exist");
                }
                _unitOfWork.EmployeeRepo.Add(Employee);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = Employee, result = Modelmessage });
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
        public async Task<Employee> GetById(int id)
        {
            return await _unitOfWork.EmployeeRepo.GetById(id);
        }
        [HttpPut]
        public void PutCategory(Employee Employee)
        {
            _unitOfWork.EmployeeRepo.Update(Employee);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async void Delete(int id)
        {
            _unitOfWork.EmployeeRepo.DeletebyID(x => x.Id == id);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteByEntity")]
        public void Delete(Employee Employee)
        {
            _unitOfWork.EmployeeRepo.Delete(Employee);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteRange")]
        public void DeleteRange(IEnumerable<Employee> companies)
        {
            _unitOfWork.EmployeeRepo.DeleteRange(companies);
            _unitOfWork.Save();
        }

    }
}
