﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var newUser = await _userService.PostUser(user);
            return Ok(newUser);
        }

        [HttpPut]
        public IActionResult Put(string novoNome)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(string nome)
        {
            var removedUser = _userService.DeleteUser(nome);
            return Ok(removedUser);
        }

        [HttpPost]
        [Route("verificaEmail")]
        public async Task<IActionResult> Verifica(string login, string userEmail, string guid)
        {
            await _userService.VerificaUser(login, userEmail, guid);
            return Ok();
        }

    }
}
