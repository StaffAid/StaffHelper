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
    public class CompanyRoleService: ICompanyRoleService
    {
        private readonly IUnitOfWork _unitOfwork;


        public CompanyRoleService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        /// <summary>
        /// "Create CompanyRole"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> CreateCompanyRole(CreateCompanyRoleViewModel model)
        {
            var companyRole = await _unitOfwork.GetRepository<CreateCompanyRoleViewModel>().GetFirstOrDefaultAsync( x => x.CompanyId == model.CompanyId, null, null, false  );
            if (model == null)
            {
                var newCompanyrole = new CreateCompanyRoleViewModel()
                {
                    Id = Guid.NewGuid(),
                    CompanyId = model.CompanyId,
                    RoleId = model.RoleId,
                    CreatedDate = model.CreatedDate,
                };

                await _unitOfwork.GetRepository<CreateCompanyRoleViewModel>().InsertAsync(newCompanyrole);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "CompanyRole Created Successfully", Status = true };

            }
            else return new BaseResponse { Message = "CompanyRole Does Not Exist", Status = false };
        }
        /// <summary>
        /// "Get All CompanyRole"
        /// </summary>
        /// <returns></returns>
        public async Task<List<CreateCompanyRoleViewModel>> GetAll()
        {
            var companyRole =  _unitOfwork.GetRepository<CreateCompanyRoleViewModel>().GetAll().ToList();

            return companyRole;
           
        }
       
        /// <summary>
        /// "Get By CompanyId"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateCompanyRoleViewModel> GetByCompanyId(CreateCompanyRoleViewModel model)
        {
            var companyRole = await _unitOfwork.GetRepository<CreateCompanyRoleViewModel>().GetFirstOrDefaultAsync( x=> x.CompanyId == model.CompanyId, null, null, false);

            return companyRole;

        }
       
        /// <summary>
        /// "Get By RoleId"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateCompanyRoleViewModel> GetByRoleId(CreateCompanyRoleViewModel model)
        {
            var companyRole = await _unitOfwork.GetRepository<CreateCompanyRoleViewModel>().GetFirstOrDefaultAsync(x => x.RoleId == model.RoleId, null, null, false);

            return companyRole;
        }
        /// <summary>
        /// "Update CompanyRole"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UpdateCompanyRole(UpdateCompanyRoleViewModel model)
        {
            var companyRole = await _unitOfwork.GetRepository<UpdateCompanyRoleViewModel>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (model != null)
            {
                var newCompanyRole = new UpdateCompanyRoleViewModel()
                {
            
                    RoleId = model.RoleId,
                    UpdatedDate = DateTime.Now,
                };
                 _unitOfwork.GetRepository<UpdateCompanyRoleViewModel>().Update(newCompanyRole);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "CompanyRole Updated Successfully", Status = true };
            }
            else return new BaseResponse { Message = "CompanyRole Does Not Exist" , Status = false};
        }
        /// <summary>
        /// "SoftDelete CompanyRole"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> SoftDeleteCompanyRole(CreateCompanyRoleViewModel model)
        {
            var companyRole = await _unitOfwork.GetRepository<CreateCompanyRoleViewModel>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            companyRole.SoftDelete = false;
                
            await _unitOfwork.GetRepository<CreateCompanyRoleViewModel>().InsertAsync(companyRole);
             await _unitOfwork.SaveChangesAsync();

            return false;
        }
    }
}
