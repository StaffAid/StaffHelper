using Arch.EntityFrameworkCore.UnitOfWork;
using StaffHelper.Model.Entities;
using StaffHelper.Model.ViewModels;
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

        public async Task<List<CreateCompanyViewModel>> GetAll()
        {
            var company = _unitOfwork.GetRepository<CreateCompanyViewModel>().GetAll().ToList();


            return company;
        }
        /// <summary>   
        /// "Get By RcNo"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateCompanyViewModel> GetByRcNo(CreateCompanyViewModel model)
        {
            var company = await _unitOfwork.GetRepository<CreateCompanyViewModel>().GetFirstOrDefaultAsync(x => x.RcNo == model.RcNo, null, null, false);


            return company;
        }
        /// <summary>
        /// "Get By Company Name"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateCompanyViewModel> GetByName(CreateCompanyViewModel model)
        {
            var company = await _unitOfwork.GetRepository<CreateCompanyViewModel>().GetFirstOrDefaultAsync(x => x.Name.ToUpper() == model.Name.ToUpper(),null, null, false);


            return company;
        }
        /// <summary>
        /// "Get By Company Address"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateCompanyViewModel> GetByAddress(CreateCompanyViewModel model)
        {
            var company = await _unitOfwork.GetRepository<CreateCompanyViewModel>().GetFirstOrDefaultAsync(x => x.Address == model.Address, null, null, false);


            return company;
        }
        /// <summary>
        /// "Create Company"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> CreateCompany(CreateCompanyViewModel model)
        {
            var company = await _unitOfwork.GetRepository<CreateCompanyViewModel>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (model == null)
            {
                var newCompany = new CreateCompanyViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name.ToUpper(),
                    Website = model.Website,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    RcNo = model.RcNo,
                    CreatedDate = DateTime.Now,
                };
                await _unitOfwork.GetRepository<CreateCompanyViewModel>().InsertAsync(newCompany);
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
        public async Task<BaseResponse> UpdateCompany(UpdateCompanyViewModel model)
        {
            var company = await _unitOfwork.GetRepository<UpdateCompanyViewModel>().GetFirstOrDefaultAsync(x => x.Id == model.Id,null,null,false);
            
            if (model != null)
            {

                var newCompany = new UpdateCompanyViewModel()
                {
                    Name = model.Name.ToUpper(),
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    UpdatedDate = DateTime.Now,
                };
                _unitOfwork.GetRepository<UpdateCompanyViewModel>().Update(newCompany);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = " Company Updated Successfully", Status = true };
            }
            
           else return new BaseResponse { Message = "Company Does Not Exist" , Status = false };


        }
        /// <summary>
        /// "SoftDelete Company"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> SoftDeleteCompany(CreateCompanyViewModel model)
        {
            var company = await _unitOfwork.GetRepository<CreateCompanyViewModel>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            company.SoftDelete = false;

            await _unitOfwork.GetRepository<CreateCompanyViewModel>().InsertAsync(company);
            await _unitOfwork.SaveChangesAsync();

            return false;

            
        }


    }
}
