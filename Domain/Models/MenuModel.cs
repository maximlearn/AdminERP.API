using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class MenuModel
    {
        public MenuModel()
        {
            //RoleMenu = new HashSet<RoleMenu>();
        }

        public short Id { get; set; }
        public string MenuTitle { get; set; }
        public short? ParentMenuId { get; set; }
        public string MenuLink { get; set; }
        public string TemplateUrl { get; set; }
        public string Controller { get; set; }
        public string ControllerAs { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsStateRequired { get; set; }
        public short DisplayOrder { get; set; }
        public string Tag { get; set; }

        //public virtual ICollection<RoleMenu> RoleMenu { get; set; }
    }
}
