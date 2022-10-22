using Arch.EntityFrameworkCore.UnitOfWork;
using StaffHelper.Model.Entities;
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
        public async Task<BaseResponse> CreateCompanyRole(CompanyRole model)
        {
            var companyRole = await _unitOfwork.GetRepository<CompanyRole>().GetFirstOrDefaultAsync( x => x.CompanyId == model.CompanyId, null, null, false  );
            if (model == null)
            {
                var newCompanyrole = new CompanyRole()
                {
                    Id = Guid.NewGuid(),
                    Company = model.Company,
                    CompanyId = model.CompanyId,
                    Role = model.Role,
                    RoleId = model.RoleId,
                    CreatedDate = model.CreatedDate,
                };

                await _unitOfwork.GetRepository<CompanyRole>().InsertAsync(newCompanyrole);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "CompanyRole Created Successfully", Status = true };

            }
            else return new BaseResponse { Message = "CompanyRole Does Not Exist", Status = false };
        }
        /// <summary>
        /// "Get All CompanyRole"
        /// </summary>
        /// <returns></returns>
        public async Task<List<CompanyRole>> GetAll()
        {
            var companyRole =  _unitOfwork.GetRepository<CompanyRole>().GetAll().ToList();

            return companyRole;
           
        }
        /// <summary>
        /// "Get By Company"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CompanyRole> GetByCompany(CompanyRole model)
        {
            var companyRole = await _unitOfwork.GetRepository<CompanyRole>().GetFirstOrDefaultAsync(x => x.Company == model.Company, null, null, false);

            return companyRole;
        }
        /// <summary>
        /// "Get By CompanyId"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CompanyRole> GetByCompanyId(CompanyRole model)
        {
            var companyRole = await _unitOfwork.GetRepository<CompanyRole>().GetFirstOrDefaultAsync( x=> x.CompanyId == model.CompanyId, null, null, false);

            return companyRole;

        }
        /// <summary>
        /// "Get By Role"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CompanyRole> GetByRole(CompanyRole model)
        {
            var companyRole = await _unitOfwork.GetRepository<CompanyRole>().GetFirstOrDefaultAsync(x => x.Role == model.Role, null, null, false);

            return companyRole;
        }
        /// <summary>
        /// "Get By RoleId"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CompanyRole> GetByRoleId(CompanyRole model)
        {
            var companyRole = await _unitOfwork.GetRepository<CompanyRole>().GetFirstOrDefaultAsync(x => x.RoleId == model.RoleId, null, null, false);

            return companyRole;
        }
        /// <summary>
        /// "Update CompanyRole"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UpdateCompanyRole(CompanyRole model)
        {
            var companyRole = await _unitOfwork.GetRepository<CompanyRole>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (model != null)
            {
                var newCompanyRole = new CompanyRole()
                {
                    Company = model.Company,
                    CompanyId = model.CompanyId,
                    Role = model.Role,
                    RoleId = model.RoleId,
                    UpdatedDate = DateTime.Now,
                };
                 _unitOfwork.GetRepository<CompanyRole>().Update(newCompanyRole);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "CompanyRole Updated Successfully", Status = true };
            }
            else return new BaseResponse { Message = "CompanyRole Does Not Exist" , Status = false};
        }
        /// <summary>
        /// "Delete CompanyRole"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> DeleteCompanyRole(CompanyRole model)
        {
            var companyRole = await _unitOfwork.GetRepository<CompanyRole>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (model != null)
            {
                 _unitOfwork.GetRepository<CompanyRole>().Delete(companyRole);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "CompanyRole Deleted Successfully", Status = true };
            }
            else return new BaseResponse { Message = "CompanyRole Does Not Exist", Status = false };
        }
    }
}
