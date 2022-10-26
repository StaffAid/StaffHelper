using Arch.EntityFrameworkCore.UnitOfWork;
using StaffHelper.Model.Entities;
using StaffHelper.Model.ViewModels;
using StaffHelper.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffHelper.Service.Services
{
    public class CompanyUnitService: ICompanyUnitService
    {
        private readonly IUnitOfWork _unitOfwork;


        public CompanyUnitService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        /// <summary>
        /// "Get All"
        /// </summary>
        /// <returns></returns>
        public async Task<List<CreateCompanyUnitViewModel>> GetAll()
        {
            var companyUnit = _unitOfwork.GetRepository<CreateCompanyUnitViewModel>().GetAll().ToList();

            return companyUnit;


            // List<CompanyUnit> companyUnits = new List<CompanyUnit>();
            //foreach(var item in companyUnits)
            //{
            //  return companyUnits;
            //}

        }
        /// <summary>
        /// "Create CompanyUnit"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> CreateCompanyUnit(CreateCompanyUnitViewModel model)
        {
            var companyUnit = await _unitOfwork.GetRepository<CreateCompanyUnitViewModel>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (model == null)
            {
                var newCompanyunit = new CreateCompanyUnitViewModel()
                {

                    Id = Guid.NewGuid(),
                    CompanyId = model.CompanyId,
                    Name = model.Name,
                    CreatedDate = DateTime.Now,

                };
                await _unitOfwork.GetRepository<CreateCompanyUnitViewModel>().InsertAsync(newCompanyunit);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "CompanyUnit Created Successfully", Status = true };
            }

            else return new BaseResponse { Message = "CompanyUnit Already Exist", Status = false };
        }
        /// <summary>
        /// "Get By CompanyId"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateCompanyUnitViewModel> GetByCompanyId(CreateCompanyUnitViewModel model)
        {
            var companyUnit = await _unitOfwork.GetRepository<CreateCompanyUnitViewModel>().GetFirstOrDefaultAsync( x => x.CompanyId == model.CompanyId, null , null , false);
            return companyUnit;

        }
        /// <summary>
        /// "Get By CompanyUnit Name"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateCompanyUnitViewModel> GetByName(CreateCompanyUnitViewModel model)
        {
            var companyUnit = await _unitOfwork.GetRepository<CreateCompanyUnitViewModel>().GetFirstOrDefaultAsync(x => x.Name == model.Name, null, null, false);
            return companyUnit;
        }
        /// <summary>
        /// "Update CompanyUnit"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UpdateCompanyUnit(UpdateCompanyUnitViewModel model)
        {
            var companyUnit = await _unitOfwork.GetRepository<UpdateCompanyUnitViewModel>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (model != null)
            {
                var newCompanyunit = new UpdateCompanyUnitViewModel()
                {
                  
                    Name = model.Name,
                    UpdatedDate = DateTime.Now,

                };
                 _unitOfwork.GetRepository<UpdateCompanyUnitViewModel>().Update(newCompanyunit);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "CompanyUnit Updated Successfully", Status = true };
            }

            else return new BaseResponse { Message = "CompanyUnit Does Not Exist", Status = false };
        }
        /// <summary>
        /// "SoftDelete CompanyUnit"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> SoftDeleteCompanyUnit(CreateCompanyUnitViewModel model)
        {
            var company = await _unitOfwork.GetRepository<CreateCompanyUnitViewModel>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            company.SoftDelete = false;

            await _unitOfwork.GetRepository<CreateCompanyUnitViewModel>().InsertAsync(company);
            await _unitOfwork.SaveChangesAsync();

            return false;


        }

    }
}
