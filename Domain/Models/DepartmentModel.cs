using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        //public virtual User CreatedByNavigation { get; set; }
        //public virtual User ModifiedByNavigation { get; set; }
    }
}
