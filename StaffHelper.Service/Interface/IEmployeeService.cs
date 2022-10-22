using StaffHelper.Model.Entities;
using System.Threading.Tasks;

namespace StaffHelper.Service.Interface
{
    public interface IEmployeeService
    {
        Task<BaseResponse> CreateProfile(Employee employee);
        Task<BaseResponse> DeleteProfile(Employee employee);
        Task<BaseResponse> UpdateProfile(Employee employee);
        BaseResponse SearchProfile(Employee employee);
    }
}
