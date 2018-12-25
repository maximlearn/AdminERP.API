using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class User
    {
        public User()
        {
            AssetCategoryCreatedByNavigation = new HashSet<AssetCategory>();
            AssetCategoryModifiedByNavigation = new HashSet<AssetCategory>();
            AssetCreatedByNavigation = new HashSet<Asset>();
            AssetGatePassCreatedByNavigation = new HashSet<AssetGatePass>();
            AssetGatePassModifiedByNavigation = new HashSet<AssetGatePass>();
            AssetGatePassReceivedByNavigation = new HashSet<AssetGatePass>();
            AssetModifiedByNavigation = new HashSet<Asset>();
            CompanyCreatedByNavigation = new HashSet<Company>();
            CompanyModifiedByNavigation = new HashSet<Company>();
            DepartmentCreatedByNavigation = new HashSet<Department>();
            DepartmentModifiedByNavigation = new HashSet<Department>();
            UserCredential = new HashSet<UserCredential>();
            UserRole = new HashSet<UserRole>();
            UserSecurityAnswer = new HashSet<UserSecurityAnswer>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmpId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? DeptId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<AssetCategory> AssetCategoryCreatedByNavigation { get; set; }
        public virtual ICollection<AssetCategory> AssetCategoryModifiedByNavigation { get; set; }
        public virtual ICollection<Asset> AssetCreatedByNavigation { get; set; }
        public virtual ICollection<AssetGatePass> AssetGatePassCreatedByNavigation { get; set; }
        public virtual ICollection<AssetGatePass> AssetGatePassModifiedByNavigation { get; set; }
        public virtual ICollection<AssetGatePass> AssetGatePassReceivedByNavigation { get; set; }
        public virtual ICollection<Asset> AssetModifiedByNavigation { get; set; }
        public virtual ICollection<Company> CompanyCreatedByNavigation { get; set; }
        public virtual ICollection<Company> CompanyModifiedByNavigation { get; set; }
        public virtual ICollection<Department> DepartmentCreatedByNavigation { get; set; }
        public virtual ICollection<Department> DepartmentModifiedByNavigation { get; set; }
        public virtual ICollection<UserCredential> UserCredential { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
        public virtual ICollection<UserSecurityAnswer> UserSecurityAnswer { get; set; }
    }
}
