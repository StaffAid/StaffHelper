using Arch.EntityFrameworkCore.UnitOfWork;
using StaffHelper.Model.Entities;
using StaffHelper.Model.ViewModels;
using StaffHelper.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffHelper.Service.Services
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork _unitOfwork;

        public UserService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        /// <summary>
        /// "Create User"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> CreateUser(CreateUserViewModel model)
        {
            var user = await _unitOfwork.GetRepository<CreateUserViewModel>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (user == null)
            {
                var newUser = new CreateUserViewModel()
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName.ToUpper(),
                    LastName = model.LastName.ToUpper(),
                    Gender = model.Gender,
                    PrimaryEmail = model.PrimaryEmail,
                    PrimaryPhoneNumber = model.PrimaryPhoneNumber,
                    DOB = model.DOB,
                    Address = model.Address.ToUpper(),
                    StateOfOrigin = model.StateOfOrigin,
                    CreatedDate = DateTime.Now,

                };
                await _unitOfwork.GetRepository<CreateUserViewModel>().InsertAsync(newUser);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "User Created Successfully", Status = true };
            }

            else return new BaseResponse { Message = "User Already Exist", Status = false };
        }
        /// <summary>
        /// "GetAll"
        /// </summary>
        /// <returns></returns>
        public async Task<List<CreateUserViewModel>> GetAll()
        {
            var user = _unitOfwork.GetRepository<CreateUserViewModel>().GetAll().ToList();

            return user;
        }
        /// <summary>
        /// "Get By Name"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateUserViewModel> GetByName(CreateUserViewModel model)
        {
            var user = await _unitOfwork.GetRepository<CreateUserViewModel>().GetFirstOrDefaultAsync(x => x.FirstName == model.FirstName, null, null, false);

            return user;
        }
        /// <summary>
        /// "Get By Address"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateUserViewModel> GetByAddress(CreateUserViewModel model)
        {
            var user = await _unitOfwork.GetRepository<CreateUserViewModel>().GetFirstOrDefaultAsync(x => x.Address == model.Address, null, null, false);

            return user;
        }
        /// <summary>
        /// "Update User"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UpdateUser(UpdateUserViewModel model)
        {
            var user = await _unitOfwork.GetRepository<UpdateUserViewModel>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (user != null)
            {
                var newUser = new UpdateUserViewModel()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    PrimaryEmail = model.PrimaryEmail,
                    PrimaryPhoneNumber = model.PrimaryPhoneNumber,
                    DOB = model.DOB,
                    Address = model.Address,
                    StateOfOrigin = model.StateOfOrigin,
                    UpdatedDate = DateTime.Now,
                };

                _unitOfwork.GetRepository<UpdateUserViewModel>().Update(newUser);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "User Updated Successfully", Status = true };
            }

            else return new BaseResponse { Message = "", Status = false };
        }
        /// <summary>
        /// "SoftDelete User"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> SoftDelete(CreateUserViewModel model)
        {
            var user = await _unitOfwork.GetRepository<CreateUserViewModel>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            user.SoftDelete = false;

            await _unitOfwork.GetRepository<CreateUserViewModel>().InsertAsync(user);
            await _unitOfwork.SaveChangesAsync();

            return false;
        }
    }
}
