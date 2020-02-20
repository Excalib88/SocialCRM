using System;
using System.Collections.Generic;
using System.Text;

namespace SocialCRM.DAL.Entities
{
    public class EmployeeEntity: BaseEntity
    {
        public PersonEntity Person { get; set; }
        
        public string Position { get; set; }
        public DateTime EmploymentDate { get; set; }
    }
}
