using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class UserSecurityAnswer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SecurityQuestionId { get; set; }
        public string Answer { get; set; }

        public virtual SecurityQuestion SecurityQuestion { get; set; }
        public virtual User User { get; set; }
    }
}
