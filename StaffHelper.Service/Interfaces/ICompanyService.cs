using StaffHelper.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffHelper.Service.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAll();

        Task<Company> GetById(Company model);

        Task<Company> GetByName(Company model);
        
        Task<Company> GetByEmail(Company model);
        
        Task<BaseResponse> CreateCompany(Company model);
        
        Task<BaseResponse> UpdateCompany(Company model);
        
        Task<BaseResponse> DeleteCompany(Company model);

    }
}
