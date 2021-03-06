﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using ygl.Models;
using ygl.Models.Forms;
using ygl.Models.RestfulData;
using ygl.Utils;
using yglAPI.DbHelper.ModelDao;
using yglAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yglAPI.Controllers
{
    /// <summary>
    /// 登录管理
    /// </summary>
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        /// <summary>
        /// 登陆获取token测试
        /// </summary> 
        [HttpPost]
        [SwaggerResponse(200, "登陆成功", typeof(TokenObj))]
        [SwaggerResponse(400, null, typeof(RestfulData))]
        public async Task<ActionResult> Sigin([FromBody, BindRequired] SigninForm signinForm)
        {
            var result = new RestfulData<TokenObj>();
            //验证用户名和密码
            var userInfo = new UserDao().GetUser(signinForm.username, signinForm.password);
            if (userInfo != null)
            {
                var claims = new Claim[]
                {
                   new Claim(ClaimTypes.Sid,userInfo.Id.ToString()), 
                   new Claim(ClaimTypes.Name,userInfo.Nickname??""),
                   new Claim(ClaimTypes.Role,userInfo.Role),
                   new Claim(ClaimTypes.NameIdentifier,userInfo.Username),
                };    
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(ConfigHelper.GetValueByKey("SecurityKey")));
                var expires = DateTime.Now.AddDays(30);//
                var token = new JwtSecurityToken(
                            issuer: ConfigHelper.GetValueByKey("issuer"),
                            audience: ConfigHelper.GetValueByKey("audience"),
                            claims: claims,
                            notBefore: DateTime.Now,
                            expires: expires,
                            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
                //生成Token
                string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                result.data = new TokenObj() { token = jwtToken, expires = expires.ToFileTimeUtc() };
                result.message = "授权成功！";
                return Ok(result);
            }
            else
            {
                result.message = "账号或密码错误";
                result.code = 400;
                return BadRequest(result);
            }

        }

        /// <summary>
        /// 退出登录
        /// </summary> 
        [HttpPost("logout")]
        [SwaggerResponse(200, "登陆成功", typeof(RestfulData))]
        public RestfulData Logout()
        {
            var claims = new Claim[] { };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(ConfigHelper.GetValueByKey("SecurityKey")));
            var expires = DateTime.Now.AddSeconds(2);//
            var token = new JwtSecurityToken(
                        issuer: ConfigHelper.GetValueByKey("issuer"),
                        audience: ConfigHelper.GetValueByKey("audience"),
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: expires,
                        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            return new RestfulData() { message = "退出登录成功" };
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        [Authorize]
        [HttpGet("user")]
        [SwaggerResponse(200, "退出登录", typeof(UserInfo))]
        public RestfulData<UserInfo> GetUserInfo()
           
        {
            var res=new RestfulData<UserInfo>();
            var info = new UserInfo();
            var cUser = Helper.GetCurrentUser(HttpContext);
            string[] Roles = new string[] { cUser.Role };
            //Roles[1] = cUser.Role;
            res.data = new UserInfo()
            {
                Name = cUser.Nickname,
                Roles = Roles,
            };
            return res;
        }

    }
}
