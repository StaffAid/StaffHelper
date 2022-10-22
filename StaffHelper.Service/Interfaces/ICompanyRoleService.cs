using StaffHelper.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffHelper.Service.Interfaces
{
    public interface ICompanyRoleService
    {
        Task<BaseResponse> CreateCompanyRole(CompanyRole model);
        
        Task<List<CompanyRole>> GetAll();

        Task<CompanyRole> GetByCompany(CompanyRole model);
        
        Task<CompanyRole> GetByCompanyId(CompanyRole model);
        
        Task<CompanyRole> GetByRole(CompanyRole model);
        
        Task<CompanyRole> GetByRoleId(CompanyRole model);

        Task<BaseResponse> UpdateCompanyRole(CompanyRole model);

        Task<BaseResponse> DeleteCompanyRole(CompanyRole model);
    }
}
