using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;
using HMS.Implementation.Interface;
using HMS.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HMS.Implementation.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseResponse> CreateCustomer(CreateCustomer request)
        {
            try
            {
                if (request != null)
                {
                    var existingCustomer = _dbContext.Customers.FirstOrDefault(x =>
                   // x.Id == request.Id &&
                    x.UserName == request.UserName &&
                    x.Email == request.Email);

                    if (existingCustomer != null)
                    {
                        return new BaseResponse
                        {
                            Success = true,
                            Message = $"Customer {request.UserName} already exists.",
                            Hasherror = true
                        };
                    }

                    var customer = new Customer
                    {
                      //  Id = request.Id,
                        UserName = request.UserName,
                        Email = request.Email,
                        Address = request.Address,
                        Age = request.Age,
                        Gender = request.Gender,
                        Name = request.Name,
                        Password = request.Password,
                        PhoneNumber = request.PhoneNumber,
                    };
                    _dbContext.Customers.Add(customer);
                }
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse
                    {
                        Success = true,
                        Message = $"Registration Successful, Congratulations {request.UserName}",
                    };
                }
                else
                {
                    return new BaseResponse
                    {
                        Message = "Failed"
                    };
                }


            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = $"Registration Failed, Unable to register {request.UserName}",
                    Hasherror = true

                };
            }
        }


        public async Task<BaseResponse> DeleteCustomerAsync(int Id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == Id);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
            }
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = $"Customer {Id} has Been deleted Succesfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = $"Failed to delete Customer with {Id}.The room may not exist or there was an error in the deletion process.",
                    Hasherror = true
                };
            }
        }



        public async Task<CustomerResponseDto> GetCustomerByIdAsync(int Id)
        {
            var customer = await _dbContext.Customers
                .Where(x => x.Id == Id)
                .Select(x => new CustomerDto
                {
                    Address = x.Address,
                    Age = x.Age,
                    Email = x.Email,
                    Gender = x.Gender,
                    Id = x.Id,
                    Name = x.Name,
                    Password = x.Password,
                    PhoneNumber = x.PhoneNumber,
                    UserName = x.UserName,
                }).ToListAsync();
            if (customer != null)
            {
                return new CustomerResponseDto
                {
                    Success = true,
                    Message = $"Customer with ID {Id} retrieved successfully.",
                    Data = customer
                };
            }
            else
            {
                return new CustomerResponseDto
                {
                    Success = false,
                    Message = $"Failed to retrieve customer with ID {Id}.The customer may not exist or there was an error in the retrieval process.",
                
                Hasherror = true
                };
            }
        }

        public async Task<CustomerResponseDto> GetAllCustomerCreatedAsync()
        {
            var customer = await _dbContext.Customers
               .Select(x => new CustomerDto
               {
                   Address = x.Address,
                   Age = x.Age,
                   Email = x.Email,
                   Gender = x.Gender,
                   Id = x.Id,
                   Name = x.Name,
                   Password = x.Password,
                   PhoneNumber = x.PhoneNumber,
                   UserName = x.UserName,
               }).ToListAsync();
            if (customer != null)
            {
                return new CustomerResponseDto
                {
                    Success = true,
                    Message = $"Customer  retrieved successfully.",
                    Data = customer
                };
            }
            else
            {
                return new CustomerResponseDto
                {
                    Success = false,
                    Message = $"Failed to retrieve customer there was an error in the retrieval process.",
                    Hasherror = true
                };
            }
        }

        public async Task<BaseResponse> UpdateCustomer (int Id , UpdateCustomer request)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == Id);
            if (customer != null)
            {
                request.Id = request.Id;
                request.Address = request.Address;
                request.PhoneNumber = request.PhoneNumber;
                request.UserName = request.UserName;
                request.Age = request.Age;
                request.Email = request.Email;
                request.Gender = request.Gender;
                request.Password = request.Password;
            }
             _dbContext.Customers.Update(customer);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = $"Customer with ID {Id} Updated successfully."
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = $"Failed to Update customer {request.UserName} ,there was an error in the updating process.",
                    Hasherror = true
                };
            }
        }
    }
    
}
