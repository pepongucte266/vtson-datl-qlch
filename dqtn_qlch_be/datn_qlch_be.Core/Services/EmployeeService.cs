using datn_qlch_be.Core.DTOs;
using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using datn_qlch_be.Core.Interfaces.services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        readonly IEmployeeRepository _repository;
        readonly IConfiguration _configuration;
        public EmployeeService(IEmployeeRepository repository, IConfiguration configuration) : base(repository)
        {
            _repository = repository;
            _configuration = configuration;
        }

        /// <summary>
        /// Hàm mã hóa mật khẩu
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public Employee CreatePasswordHash(string password)
        {
            var employee = new Employee();
            using var hmac = new HMACSHA512();
            employee.PasswordSalt = hmac.Key;
            employee.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return employee;
        }

        public bool VerifiPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public string CreateToken(Employee employee)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,value: employee.EmployeeName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credential);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public Employee RegisterEmployee(EmployeeDto request)
        {
            Employee employee = new();
            if(!string.IsNullOrEmpty(request.Password))
            {
                employee = CreatePasswordHash(request.Password);
            }

            //Map thuộc tính từ dto
            employee.EmployeeName = request.EmployeeName;
            employee.PhoneNumber = request.PhoneNumber;
            employee.Address = request.Address;
            _repository.RegisterEmployee(employee);
            return employee;
        }

        protected override bool Validate(Enum.ValidateMode mode, Employee employee)
        {
            if (employee == null) return false;
            if (string.IsNullOrEmpty(employee.EmployeeName))
            {
                ErrorMessages.Add(Resources.vn.EmployeeResource.EmployeeNameIsRequire);
            }
            if (string.IsNullOrEmpty(employee.PhoneNumber))
            {
                ErrorMessages.Add(Resources.vn.EmployeeResource.PhoneNumberIsRequire);
            }
            else if (mode == Enum.ValidateMode.Insert && Repository.IsExistByValue("PhoneNumber", employee.PhoneNumber))
            {
                ErrorMessages.Add(Resources.vn.EmployeeResource.PhoneNumberIsExisted);
            }
            return ErrorMessages.Count > 0 ? false : true;
        }
    }
}
