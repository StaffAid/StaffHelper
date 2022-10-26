using StaffHelper.Model.Entities;
using StaffHelper.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffHelper.Service.Interfaces
{
    public interface ICompanyRoleService
    {
        Task<BaseResponse> CreateCompanyRole(CreateCompanyRoleViewModel model);
        
        Task<List<CreateCompanyRoleViewModel>> GetAll();

       
        
        Task<CreateCompanyRoleViewModel> GetByCompanyId(CreateCompanyRoleViewModel model);
        
       
        
        Task<CreateCompanyRoleViewModel> GetByRoleId(CreateCompanyRoleViewModel model);

        Task<BaseResponse> UpdateCompanyRole(UpdateCompanyRoleViewModel model);

        Task<bool> DeleteCompanyRole(CreateCompanyRoleViewModel model);
    }
}
