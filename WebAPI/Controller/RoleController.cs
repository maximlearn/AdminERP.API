using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controller
{
    [Authorize]
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public readonly IRoleService roleService;

        public RoleController(IRoleService _roleService)
        {
            this.roleService = _roleService;
        }

        [HttpGet]
        [Route("UserRoleMenuFunction")]
        [Produces(typeof(UserRoleModel))]
        public IActionResult GetUserRoleMenuFunctions(int roleId)
        {
            var userRole = roleService.GetUserRoleMenuFunctionList(roleId);
            return Ok(userRole);
        }

        [HttpGet]
        [Route("GetAll")]
        [Produces(typeof(IEnumerable<RoleModel>))]
        public ActionResult GetAllRole()
        {
            var result = this.roleService.GetAllRole();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetBlankRoleMenu")]
        [Produces(typeof(RoleMenuModel))]
        public ActionResult GetBlankRoleMenu()
        {
            var roleMenuModel = new RoleMenuModel()
            {
                Id = 0,
                RoleId = 0,
                ParentMenuId = 0,
                MenuId = 0
               
            };
            return Ok(roleMenuModel);
        }

        [HttpGet]
        [Route("GetRoleMenu")]
        [Produces(typeof(IEnumerable<MenuModel>))]
        public ActionResult GetRoleMenuList(int roleId)
        {
            var result = this.roleService.GetRoleMenuList(roleId);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetRoleFunction")]
        [Produces(typeof(IEnumerable<FunctionModel>))]
        public ActionResult GetRoleFunctionList(int roleId)
        {
            var result = this.roleService.GetRoleFunctionList(roleId);

            return Ok(result);
        }

        [HttpPost]
        [Route("AddRole")]
        [Produces(typeof(ResponseModel))]
        public ActionResult SaveRole(RoleModel roleModel)
        {
            ResponseModel oResponse = null;
            try
            {             
                oResponse = this.roleService.IsExist(roleModel);
                if (!oResponse.IsExist)
                {
                    oResponse = this.roleService.SaveRole(roleModel);
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = "There is problem with the service. We are notified. Please try again later...";
                return BadRequest(oResponse);

                // throw; log the error;
            }
            return Ok(oResponse);
        }

        

        [HttpGet]
        [Route("GetRole")]
        [Produces(typeof(RoleModel))]
        public ActionResult GetRoleById(int roleId)
        {
            var result = this.roleService.GetRoleById(roleId);

            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteRole")]
        [Produces(typeof(ResponseModel))]
        public ActionResult DeleteRole(int roleId)
        {
            var result = this.roleService.DeleteRole(roleId);

            return Ok(result);
        }

    }
}