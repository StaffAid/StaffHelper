using StaffHelper.Model.Entities;
using StaffHelper.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffHelper.Service.Interfaces
{
    public interface ICompanyUnitService
    {
        Task<List<CreateCompanyUnitViewModel>> GetAll();
        Task<BaseResponse> CreateCompanyUnit(CreateCompanyUnitViewModel model);
        Task<CreateCompanyUnitViewModel> GetByCompanyId(CreateCompanyUnitViewModel model);
        Task<CreateCompanyUnitViewModel> GetByName(CreateCompanyUnitViewModel model);
        Task<BaseResponse> UpdateCompanyUnit(UpdateCompanyUnitViewModel model);   
        Task<bool> SoftDeleteCompanyUnit(CreateCompanyUnitViewModel model);

    }
}
