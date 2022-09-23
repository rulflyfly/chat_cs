﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using chat.domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public class Config
        {
            public string Text { get; set; }
        }
        // PUT api/user/5295/change/username
        [HttpPut("{userId}/change/userName")]
        public void Put(int userId, [FromBody] Config config)
        {
            var userName = config.Text;
            _userService.EditUserName(userId, userName);
        }

        // PUT api/user/5295/
        [HttpPut("{userId}/change/userdate")]
        public void PutNewDate(int userId, [FromBody] Config config)
        {
            var newDate = config.Text;
            _userService.EditUserBDay(userId, newDate);
        }
    }
}

