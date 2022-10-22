using Arch.EntityFrameworkCore.UnitOfWork;
using StaffHelper.Model.Entities;
using StaffHelper.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffHelper.Service.Services
{
    public class CompanyService: ICompanyService
    {
        private readonly IUnitOfWork _unitOfwork;


        public CompanyService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        /// <summary>
        /// "Get All"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public async Task<List<Company>> GetAll()
        {
            var company = _unitOfwork.GetRepository<Company>().GetAll().ToList();


            return company;
        }
        /// <summary>
        /// "Get By Id"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Company> GetById(Company model)
        {
            var company = await _unitOfwork.GetRepository<Company>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);


            return company;
        }
        /// <summary>
        /// "Get By Company Name"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Company> GetByName(Company model)
        {
            var company = await _unitOfwork.GetRepository<Company>().GetFirstOrDefaultAsync(x => x.Name.ToUpper() == model.Name.ToUpper(),null, null, false);


            return company;
        }
        /// <summary>
        /// "Get By Company Email"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Company> GetByEmail(Company model)
        {
            var company = await _unitOfwork.GetRepository<Company>().GetFirstOrDefaultAsync(x => x.Mail == model.Mail, null, null, false);


            return company;
        }
        /// <summary>
        /// "Create Company"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> CreateCompany(Company model)
        {
            var company = await _unitOfwork.GetRepository<Company>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (model == null)
            {
                var newCompany = new Company()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name.ToUpper(),
                    Website = model.Website,
                    Mail = model.Mail,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    RcNo = model.RcNo,
                    CreatedDate = DateTime.Now,
                };
                await _unitOfwork.GetRepository<Company>().InsertAsync(newCompany);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "Company Created Successfully", Status = true};

            }

            else return new BaseResponse { Message = "Company Already Exist", Status = false };
            
        } 
        /// <summary>
        /// "Update Company"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UpdateCompany(Company model)
        {
            var company = await _unitOfwork.GetRepository<Company>().GetFirstOrDefaultAsync(x => x.Id == model.Id,null,null,false);
            
            if (model != null)
            {

                var newCompany = new Company()
                {
                    Name = model.Name.ToUpper(),
                    Website = model.Website,
                    Mail = model.Mail,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    RcNo = model.RcNo,
                    UpdatedDate = DateTime.Now,
                };
                _unitOfwork.GetRepository<Company>().Update(newCompany);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = " Company Updated Successfully", Status = true };
            }
            
           else return new BaseResponse { Message = "Company Does Not Exist" , Status = false };


        }
        /// <summary>
        /// "Delete Company"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> DeleteCompany(Company model)
        {
            var company = await _unitOfwork.GetRepository<Company>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (model!= null)
            {
                 _unitOfwork.GetRepository<Company>().Delete(company);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = " Company Deleted Successfully", Status = true };
            }


            else return new BaseResponse { Message = "Company Does Not Exist", Status = false };
        }


    }
}
