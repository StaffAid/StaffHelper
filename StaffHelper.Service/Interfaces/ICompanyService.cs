using StaffHelper.Model.Entities;
using StaffHelper.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffHelper.Service.Interfaces
{
    public interface ICompanyService
    {
        Task<List<CreateCompanyViewModel>> GetAll();

        Task<CreateCompanyViewModel> GetByRcNo(CreateCompanyViewModel model);

        Task<CreateCompanyViewModel> GetByName(CreateCompanyViewModel model);
        
        Task<CreateCompanyViewModel> GetByAddress(CreateCompanyViewModel model);
        
        Task<BaseResponse> CreateCompany(CreateCompanyViewModel model);
        
        Task<BaseResponse> UpdateCompany(UpdateCompanyViewModel model);

        Task<bool> SoftDeleteCompany(CreateCompanyViewModel model);

    }
}
