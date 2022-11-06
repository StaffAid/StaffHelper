using StaffHelper.Model.Entities;
using StaffHelper.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StaffHelper.Service.Interfaces
{
    public interface ICompanyDesignationService
    {
        Task<BaseResponse> CreateCompanyDesignation(CreateCompanyDesignationViewModel model);

        Task<List<CreateCompanyDesignationViewModel>> GetAll();

        Task<CreateCompanyDesignationViewModel> GetByCompanyId(CreateCompanyDesignationViewModel model);

        Task<BaseResponse> UpdateCompanyDesignation(UpdateCompanyDesignationViewModel model);

        Task<bool> SoftDeleteCompanyDesignation(CreateCompanyDesignationViewModel model);
    }
}
