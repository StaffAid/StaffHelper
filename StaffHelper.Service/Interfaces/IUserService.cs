using StaffHelper.Model.Entities;
using StaffHelper.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StaffHelper.Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse> CreateUser(CreateUserViewModel model);

        Task<List<CreateUserViewModel>> GetAll();

        Task<CreateUserViewModel> GetByName(CreateUserViewModel model);

        Task<CreateUserViewModel> GetByAddress(CreateUserViewModel model);

        Task<BaseResponse> UpdateUser(UpdateUserViewModel model);

        Task<bool> SoftDelete(CreateUserViewModel model);
    }
}
