using BLL.DTOs;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System;

[RoutePrefix("api/user")]
public class UserController : ApiController
{
    [HttpPost]
    [Route("register")]
    public HttpResponseMessage Register(UserDTO user)
    {
        var success = UserService.Register(user);
        if (success)
            return Request.CreateResponse(HttpStatusCode.OK, "Registration successful.");
        return Request.CreateResponse(HttpStatusCode.BadRequest, "Registration failed.");
    }

    [HttpPost]
    [Route("login")]
    public HttpResponseMessage Login(string username, string password)
    {
        var user = UserService.Login(username, password);
        if (user != null)
            return Request.CreateResponse(HttpStatusCode.OK, user);
        return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid username or password.");
    }

    [HttpGet]
    [Route("all")]
    public HttpResponseMessage GetAllUsers()
    {
        try
        {
            List<UserDTO> users = UserService.Get(); // Fetch all users
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }
        catch (Exception ex)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
