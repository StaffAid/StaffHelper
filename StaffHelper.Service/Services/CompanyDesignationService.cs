using Arch.EntityFrameworkCore.UnitOfWork;
using StaffHelper.Model.Entities;
using StaffHelper.Model.ViewModels;
using StaffHelper.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffHelper.Service.Services
{
    public class CompanyDesignationService: ICompanyDesignationService
    {
        private readonly IUnitOfWork _unitOfwork;

        public CompanyDesignationService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        /// <summary>
        /// "Create CompanyDesignation "
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> CreateCompanyDesignation(CreateCompanyDesignationViewModel model)
        {
            var companyDesignation = await _unitOfwork.GetRepository<CreateCompanyDesignationViewModel>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (model == null)
            {
                var newCompanyDesignation = new CreateCompanyDesignationViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    CompanyId = model.CompanyId,
                    CreatedDate = DateTime.Now,
                };
                await _unitOfwork.GetRepository<CreateCompanyDesignationViewModel>().InsertAsync(newCompanyDesignation);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "CompanyDesignation Created Successfully", Status = true };
            }
            else return new BaseResponse {  Message = "", Status = false};
        }
        /// <summary>
        /// "Get All"
        /// </summary>
        /// <returns></returns>
        public async Task<List<CreateCompanyDesignationViewModel>> GetAll()
        {
            var companyDesignation = _unitOfwork.GetRepository<CreateCompanyDesignationViewModel>().GetAll().ToList();

            return companyDesignation;
        }
        /// <summary>
        /// "Get By CompanyId"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateCompanyDesignationViewModel> GetByCompanyId(CreateCompanyDesignationViewModel model)
        {
            var companyDesignation = await _unitOfwork.GetRepository<CreateCompanyDesignationViewModel>().GetFirstOrDefaultAsync( x => x.CompanyId == model.CompanyId, null , null , false);

            return companyDesignation;
        }   
        /// <summary>
        /// "Update CompanyDesignation"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UpdateCompanyDesignation(UpdateCompanyDesignationViewModel model)
        {
            var companyDesignation = await _unitOfwork.GetRepository<UpdateCompanyDesignationViewModel>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (model != null)
            {
                var newCompanyDesignation = new UpdateCompanyDesignationViewModel()
                {
                    Name = model.Name,
                    UpdatedDate = DateTime.Now,
                };
                _unitOfwork.GetRepository<UpdateCompanyDesignationViewModel>().Update(newCompanyDesignation);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "CompanyDesignation Updated Successfully", Status = true };
            }
            else return new BaseResponse { Message = "CompanyDesignation Not Found", Status = false };
        }
        /// <summary>
        /// "SoftDelete CompanyDesignation"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> SoftDeleteCompanyDesignation(CreateCompanyDesignationViewModel model)
        {
            var companyDesignation = await _unitOfwork.GetRepository<CreateCompanyDesignationViewModel>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            companyDesignation.SoftDelete = false;

            await _unitOfwork.GetRepository<CreateCompanyDesignationViewModel>().InsertAsync(companyDesignation);
            await _unitOfwork.SaveChangesAsync();


            return false;

        }
    }
}
