using Arch.EntityFrameworkCore.UnitOfWork;
using StaffHelper.Model.Entities;
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

        public async Task<List<CompanyUnit>> GetAll()
        {
            var companyUnit = _unitOfwork.GetRepository<CompanyUnit>().GetAll().ToList();

            return companyUnit;


            // List<CompanyUnit> companyUnits = new List<CompanyUnit>();
            //foreach(var item in companyUnits)
            //{
            //  return companyUnits;
            //}

        }
        public async Task<BaseResponse> CreateCompanyUnit(CompanyUnit model)
        {
            var companyUnit = await _unitOfwork.GetRepository<CompanyUnit>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (model == null)
            {
                var newCompanyunit = new CompanyUnit()
                {
                    Id = Guid.NewGuid(),
                    Company = model.Company,
                    CompanyId = model.CompanyId,
                    Name = model.Name,
                    CreatedDate = DateTime.Now,

                };
                await _unitOfwork.GetRepository<CompanyUnit>().InsertAsync(newCompanyunit);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "CompanyUnit Created Successfully", Status = true };
            }

            else return new BaseResponse { Message = "CompanyUnit Already Exist", Status = false };
        }

        public async Task<CompanyUnit> GetByCompany(CompanyUnit model)
        {
            var companyUnit = await _unitOfwork.GetRepository<CompanyUnit>().GetFirstOrDefaultAsync(x => x.Company == model.Company, null, null, false);
            return companyUnit;

        }
        public  async Task<CompanyUnit> GetByCompanyId(CompanyUnit model)
        {
            var companyUnit = await _unitOfwork.GetRepository<CompanyUnit>().GetFirstOrDefaultAsync( x => x.CompanyId == model.CompanyId, null , null , false);
            return companyUnit;

        }
        public async Task<CompanyUnit> GetByName(CompanyUnit model)
        {
            var companyUnit = await _unitOfwork.GetRepository<CompanyUnit>().GetFirstOrDefaultAsync(x => x.Name == model.Name, null, null, false);
            return companyUnit;
        }

        public async Task<BaseResponse> UpdateCompanyUnit(CompanyUnit model)
        {
            var companyUnit = await _unitOfwork.GetRepository<CompanyUnit>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (model != null)
            {
                var newCompanyunit = new CompanyUnit()
                {
                   
                    Company = model.Company,
                    CompanyId = model.CompanyId,
                    Name = model.Name,
                    UpdatedDate = DateTime.Now,

                };
                 _unitOfwork.GetRepository<CompanyUnit>().Update(newCompanyunit);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "CompanyUnit Updated Successfully", Status = true };
            }

            else return new BaseResponse { Message = "CompanyUnit Does Not Exist", Status = false };
        }
        public async Task<BaseResponse> DeleteCompanyUnit(CompanyUnit model)
        {
            var companyUnit = await _unitOfwork.GetRepository<CompanyUnit>().GetFirstOrDefaultAsync(x => x.Id == model.Id, null, null, false);
            if (model!= null)
            {
                _unitOfwork.GetRepository<CompanyUnit>().Delete(companyUnit);
                await _unitOfwork.SaveChangesAsync();

                return new BaseResponse { Message = "CompanyUnit Deleted Successfully", Status = true };
            }

            else return new BaseResponse { Message = "CompanyUnit Does Not Exist", Status = false };
        }

    }
}
