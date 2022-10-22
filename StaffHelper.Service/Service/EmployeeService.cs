using Arch.EntityFrameworkCore.UnitOfWork;
using StaffHelper.Model.Entities;
using StaffHelper.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaffHelper.Service.Service
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> CreateProfile(Employee employee)
        {
            var profile = _unitOfWork.GetRepository<Employee>().GetFirstOrDefault(x => x.Id == employee.Id, null, null, false);

            if (profile == null)
            {
                var request = new Employee();

                request.Id = Guid.NewGuid();
                request.CreatedDate = DateTime.Now;

                //request.User = employee.User;
                request.UserId = employee.UserId;
                //request.Company = employee.Company;
                request.CompanyId = employee.CompanyId;
                request.EmployeeIdentity = employee.EmployeeIdentity;
                request.OfficialMail = employee.OfficialMail;
                request.OfficialPhoneNumber = employee.OfficialPhoneNumber;
                //request.CompanyRole = employee.CompanyRole;
                request.CompanyRoleId = employee.CompanyRoleId;
                //request.CompanyUnit = employee.CompanyUnit;
                request.CompanyUnitId = employee.CompanyUnitId;
                //request.CompanyDesignation = employee.CompanyDesignation;
                request.CompanyDesignationId = employee.CompanyDesignationId;


                _unitOfWork.GetRepository<Employee>().Insert(request);
                await _unitOfWork.SaveChangesAsync();

                return new BaseResponse { Status = true, Message = "Employee profile created successfully!" };
            }
            return new BaseResponse { Status = false, Message = "Employee profile already exist!"};
        }
        public async Task<BaseResponse> DeleteProfile(Employee employee)
        {
            var profile = _unitOfWork.GetRepository<Employee>().GetFirstOrDefault(x => x.Id == employee.Id, null, null, false);

            if (profile == null)
            {

                _unitOfWork.GetRepository<Employee>().Delete(profile);
                await _unitOfWork.SaveChangesAsync();

                return new BaseResponse { Status = true, Message = "Profile deleted successfully" };
            }

            return new BaseResponse { Status = false, Message = "Profile already exist!" };
        }

        public async Task<BaseResponse> UpdateProfile(Employee employee)
        {
            var profile = _unitOfWork.GetRepository<Employee>().GetFirstOrDefault(x => x.CompanyId == employee.CompanyId, null, null, false);
            if (profile != null)
            {
                profile.UpdatedDate = DateTime.Now;
                profile.CompanyUnit = employee.CompanyUnit;
                profile.CompanyUnitId = employee.CompanyUnitId;
                profile.CompanyDesignation = employee.CompanyDesignation;
                profile.CompanyDesignationId = employee.CompanyDesignationId;

                _unitOfWork.GetRepository<Employee>().Update(profile);
                await _unitOfWork.SaveChangesAsync();

                return new BaseResponse { Status = true, Message = "Profile updated successfully" };

            }
            return new BaseResponse { Status = false, Message = "Profile does not exist!" };
        }
        public BaseResponse SearchProfile(Employee employee)
        {

            var profile = _unitOfWork.GetRepository<Employee>().GetFirstOrDefault(x => x.Id == employee.Id, null, null, false);
            if (profile != null)
            {
                 _unitOfWork.GetRepository<Employee>().Find(profile);
            }
            return new BaseResponse { Status = false, Message = "Profile does not exist!" };
        }
      

    }
}
