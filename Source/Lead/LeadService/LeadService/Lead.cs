using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadService
{
    public class Lead
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string TypeId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int VehicleId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
