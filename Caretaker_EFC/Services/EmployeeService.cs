using Caretaker_EFC.Contexts;
using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Caretaker_EFC.Services
{
    internal class EmployeeService
    {
        private static DataContext _context = new DataContext();

        public static async System.Threading.Tasks.Task SaveEmployeeAsync(Employee employee)
        {
            var employeeEntity = new EmployeeEntity
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
            };

            _context.Add(employeeEntity);
            await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            var _employees = new List<Employee>();

            foreach (var _employee in await _context.Employees.ToListAsync())
                _employees.Add(new Employee
                {
                    Id = _employee.Id,
                    FirstName = _employee.FirstName,
                    LastName = _employee.LastName,
                    Email = _employee.Email,
                    PhoneNumber = _employee.PhoneNumber,
                });

            return _employees;
        }

        public static async Task<Employee> GetEmployeeAsync(string email)
        {
            var _employee = await _context.Employees.FirstOrDefaultAsync(x => x.Email == email);
            if (_employee != null)
                return new Employee
                {
                    Id = _employee.Id,
                    FirstName = _employee.FirstName,
                    LastName = _employee.LastName,
                    Email = _employee.Email,
                    PhoneNumber = _employee.PhoneNumber,
                };
            else
                return null!;
        }

        public static async System.Threading.Tasks.Task UpdateEmployeeAsync(Employee employee)
        {
            var _employeeEntity = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
            if(_employeeEntity != null)
            {
                if(!string.IsNullOrEmpty(employee.FirstName))
                    _employeeEntity.FirstName = employee.FirstName;

                if(!string.IsNullOrEmpty(employee.LastName))
                    _employeeEntity.LastName = employee.LastName;

                if(!string.IsNullOrEmpty(employee.Email))
                    _employeeEntity.Email = employee.Email;

                if(!string.IsNullOrEmpty(employee.PhoneNumber))
                    _employeeEntity.PhoneNumber = employee.PhoneNumber;

                _context.Update(_employeeEntity);
                await _context.SaveChangesAsync();
            }
        }

        public static async System.Threading.Tasks.Task RemoveEmployeeAsync(string email)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
            if(employee != null)
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
