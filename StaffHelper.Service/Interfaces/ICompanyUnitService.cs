using StaffHelper.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffHelper.Service.Interfaces
{
    public interface ICompanyUnitService
    {
        Task<List<CompanyUnit>> GetAll();
        Task<BaseResponse> CreateCompanyUnit(CompanyUnit model);
        Task<CompanyUnit> GetByCompany(CompanyUnit model);
        Task<CompanyUnit> GetByCompanyId(CompanyUnit model);
        Task<CompanyUnit> GetByName(CompanyUnit model);
        Task<BaseResponse> UpdateCompanyUnit(CompanyUnit model);
        Task<BaseResponse> DeleteCompanyUnit(CompanyUnit model);

    }
}
