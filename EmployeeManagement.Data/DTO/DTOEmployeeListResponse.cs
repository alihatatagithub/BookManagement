using EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.DTO
{
    public class DTOEmployeeListResponse
    {
        public List<DTOEmployeeList> EmployeeList { get; set; }
        public int Count { get; set; }
    }
    public class DTOEmployeeList
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public DateTime? DateOfJoining { get; set; }
    }
}
