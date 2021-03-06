﻿using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string WebSiteUrl { get; set; }
        public string CompanyLogoId { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DocumentModel companyLogo { get; set; }

        //public virtual User CreatedByNavigation { get; set; }
        //public virtual User ModifiedByNavigation { get; set; }
    }
}
