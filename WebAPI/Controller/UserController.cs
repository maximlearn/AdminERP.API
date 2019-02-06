using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    //[Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        [Route("GetRoleList")]
        [Produces(typeof(IEnumerable<RoleModel>))]
        public ActionResult GetRoleList()
        {
            var result = this.userService.GetRoleList();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetDepartmentList")]
        [Produces(typeof(IEnumerable<DepartmentModel>))]
        public ActionResult GetDepartmentList()
        {
            var result = this.userService.GetDepartmentList();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllUser")]
        [Produces(typeof(IEnumerable<UserModel>))]
        public ActionResult GetAllUser()
        {
            var result = this.userService.GetUserList();
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteUser")]
        [Produces(typeof(ResponseModel))]
        public ActionResult DeleteUser(int userId)
        {
            var result = this.userService.DeleteUser(userId);
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveUser")]
        [Produces(typeof(ResponseModel))]
        public ActionResult SaveUser(UserModel user)
        {
            var result = this.userService.SaveUser(user);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetUserDetailById")]
        [Produces(typeof(ResponseModel))]
        public ActionResult GetUserDetailById(int userId)
        {
            var result = this.userService.GetUserDetailById(userId);
            return Ok(result);
        }

    }
}