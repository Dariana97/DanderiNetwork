﻿using DanderiNetwork.Core.Application.Dtos.Account;

using DanderiNetwork.Core.Application.Helpers;


namespace DanderiNetworkApp.Middlewares
{

    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasUser()
        {
            AuthenticationResponse userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");

            if (userViewModel == null)
            {
                return false;
            }
            return true;
        }
    }
}
