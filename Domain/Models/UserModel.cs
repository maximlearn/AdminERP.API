using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class LoginDetails
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }

    public class UserModel
    {
        public UserModel()
        {
            //AssetCategoryCreatedByNavigation = new HashSet<AssetCategory>();
            //AssetCategoryModifiedByNavigation = new HashSet<AssetCategory>();
            //AssetCreatedByNavigation = new HashSet<Asset>();
            //AssetGatePassCreatedByNavigation = new HashSet<AssetGatePass>();
            //AssetGatePassModifiedByNavigation = new HashSet<AssetGatePass>();
            //AssetGatePassReceivedByNavigation = new HashSet<AssetGatePass>();
            //AssetModifiedByNavigation = new HashSet<Asset>();
            //CompanyCreatedByNavigation = new HashSet<Company>();
            //CompanyModifiedByNavigation = new HashSet<Company>();
            //DepartmentCreatedByNavigation = new HashSet<Department>();
            //DepartmentModifiedByNavigation = new HashSet<Department>();
            //RoleCreatedByNavigation = new HashSet<Role>();
            //RoleModifiedByNavigation = new HashSet<Role>();
            //UserCredential = new HashSet<UserCredential>();
            //UserRole = new HashSet<UserRole>();
            //UserSecurityAnswer = new HashSet<UserSecurityAnswer>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmpId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? DeptId { get; set; }
        public int RoleId { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Token { get; set; }


        public virtual ICollection<UserCredentialModel> UserCredential { get; set; }
      
        public virtual ICollection<UserSecurityAnswerModel> UserSecurityAnswer { get; set; }
    }

}
