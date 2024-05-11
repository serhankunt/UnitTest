﻿using Microsoft.AspNetCore.Mvc;
using RealWorld.WebAPI.DTOs;
using RealWorld.WebAPI.Services;

namespace RealWorld.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await userService.GetAllAsync(cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto request,CancellationToken cancellationToken)
    {
        var result = await userService.CreateAsync(request,cancellationToken);
        if (result)
        {
            return Ok("Kullanıcı kaydı başarılı");
        }
      
        return BadRequest(new { Message = "Kullanıcı kaydı sırasında bir hatayla karşılaştık" });
        
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(int id,CancellationToken cancellationToken)
    {
        var result = await userService.DeleteByIdAsync(id,cancellationToken);
        if(result)
        {
            return Ok(new { Message = "Kullanıcı başarıyla silindi" });
        }

        return BadRequest(new { Message = "Kullanıcı silerken bir hatayla karşılaştık" });
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateUserDto request,CancellationToken cancellationToken)
    {
        var result = await userService.UpdateAsync(request,cancellationToken);
        if (result)
        {
            return Ok(new { message = "Kullanıcı güncelleme işlemi başarılı" });
        }
        return BadRequest(new { Message = "Kullanıcı güncelleme işlemi sırasında bir hatayla karşılaştık" });
    }
}
