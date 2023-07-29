using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RAP.Extensions
{
    public class RAPControllerBase : ControllerBase
    {
        public string token => Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
    }
}
