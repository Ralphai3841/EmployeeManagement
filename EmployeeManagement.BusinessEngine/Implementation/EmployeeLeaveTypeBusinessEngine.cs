﻿using AutoMapper;
using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.BusinessEngine.ResultModels;
using EmployeeManagement.Common.ConstantsModels;
using EmployeeManagement.Common.VModels;
using EmployeeManagement.Data.Contacts;
using EmployeeManagement.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BusinessEngine.Implementation
{
    public class EmployeeLeaveTypeBusinessEngine : IEmployeeLeaveTypeBusinessEngine
    {
        #region Variable
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public EmployeeLeaveTypeBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

      



        #endregion


        #region CustomMethods
        public Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeLeaveTypes()
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.GetAll(e => e.IsActive == true).ToList();


            #region Yöntem 1

            /*
            if (data != null)
            {
                List<EmployeeLeaveType> returnData = new List<EmployeeLeaveType>();
                foreach (var item in data)
                {
                    returnData.Add(new EmployeeLeaveType()
                    {
                        Id = item.Id,
                        DateCreated = item.DateCreated,
                        DefaultDays = item.DefaultDays,
                        Name = item.Name
                    });

                }
                return new Result<List<EmployeeLeaveTypeVM>>(true, ResultConstant.RecordFound, returnData);

            }
            else
                return new Result<List<EmployeeLeaveTypeVM>>(false, ResultConstant.RecordNotFound); 
            */
            #endregion




            #region Yöntem 2

            var leaveTypes = _mapper.Map<List<EmployeeLeaveType>, List<EmployeeLeaveTypeVM>>(data);
            return new Result<List<EmployeeLeaveTypeVM>>(true, ResultConstant.RecordFound, leaveTypes);

            #endregion



        }

        /// <summary>
        /// New Employee Leave Type  Create method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Result<EmployeeLeaveTypeVM> CreateEmployeeLeaveType(EmployeeLeaveTypeVM model)
        {
            if (model != null)
            {
                try
                {
                    var leaveType = _mapper.Map<EmployeeLeaveTypeVM, EmployeeLeaveType>(model);
                    leaveType.DateCreated = DateTime.Now;
                    leaveType.IsActive = true;
                    _unitOfWork.employeeLeaveTypeRepository.Add(leaveType);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordCreateSuccessfully);
                }
                catch (Exception ex)
                {

                    return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateNotSuccessfully + "->" + ex.Message.ToString());
                }
            }
            else
                return new Result<EmployeeLeaveTypeVM>(false, "Parametre Olarak Geçilen Data Boş Olamaz");
        }

        public Result<EmployeeLeaveTypeVM> GetAllEmployeeLeaveTypes(int id)
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.Get(id);
            if (data != null)
            {
                var leaveType = _mapper.Map<EmployeeLeaveType, EmployeeLeaveTypeVM>(data);
                return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordFound, leaveType);

            }
            else
                return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordNotFound);
        }


        public Result<EmployeeLeaveTypeVM> EditEmployeeLeaveType(EmployeeLeaveTypeVM model)
        {
            if (model != null)
            {
                try
                {
                    var leaveType = _mapper.Map<EmployeeLeaveTypeVM, EmployeeLeaveType>(model);

                    _unitOfWork.employeeLeaveTypeRepository.Update(leaveType);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordCreateSuccessfully);
                }
                catch (Exception ex)
                {

                    return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateNotSuccessfully + "->" + ex.Message.ToString());
                }
            }
            else
                return new Result<EmployeeLeaveTypeVM>(false, "Parametre Olarak Geçilen Data Boş Olamaz");
        }

        public object GetAllEmployeeLeaveType()
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.GetAll().ToList();

            var leaveTypes = _mapper.Map<List<EmployeeLeaveType>, List<EmployeeLeaveTypeVM>>(data);
            return new Result<List<EmployeeLeaveTypeVM>>(true, ResultConstant.RecordFound, leaveTypes);
        }

        public Result<EmployeeLeaveTypeVM> RemoveEmployeeLeaveType(int id)
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.Get(id);
            if (data != null)
            {
                data.IsActive = false;
                _unitOfWork.employeeLeaveTypeRepository.Update(data);
                _unitOfWork.Save();
                return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordCreateSuccessfully);
            }
            else
                return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateNotSuccessfully);
        }




        #endregion


        




    }
}