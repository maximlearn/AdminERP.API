using System;
using System.Collections.Generic;

namespace Domaint.Models
{
    public class SecurityQuestionModel
    {
        public SecurityQuestionModel()
        {
            //UserSecurityAnswer = new HashSet<UserSecurityAnswer>();
        }

        public int Id { get; set; }
        public string Question { get; set; }
        public bool? IsActive { get; set; }

        //public virtual ICollection<UserSecurityAnswer> UserSecurityAnswer { get; set; }
    }
}
