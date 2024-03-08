using AutoMapper;
using DanderiNetwork.Core.Application.Dtos.Account;
using DanderiNetwork.Core.Application.Dtos.User;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.ViewModels.User;


namespace DanderiNetwork.Core.Application.Services
{

    public class UserService : IUserService
        {
            private readonly IAccountService _accountService;
            private readonly IMapper _mapper;
        private readonly IUserApplication _userApplication;

            public UserService(IAccountService accountService, IMapper mapper, IUserApplication userApplication)
            {
                _accountService = accountService;
                _mapper = mapper;
            _userApplication = userApplication;

            }

            public async Task<AuthenticationResponse> LoginAsync(LoginViewModel vm)
            {
                AuthenticationRequest loginRequest = _mapper.Map<AuthenticationRequest>(vm);
                AuthenticationResponse userResponse = await _accountService.AuthenticateAsync(loginRequest);
                return userResponse;
            }
            public async Task SignOutAsync()
            {
                await _accountService.SignOutAsync();
            }

            public async Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin)
            {
                RegisterRequest registerRequest = _mapper.Map<RegisterRequest>(vm);
                return await _accountService.RegisterUserAsync(registerRequest, origin);
            }

            public async Task<string> ConfirmEmailAsync(string userId, string token)
            {
                return await _accountService.ConfirmAccountAsync(userId, token);
            }

            public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel vm, string origin)
            {
                ForgotPasswordRequest forgotRequest = _mapper.Map<ForgotPasswordRequest>(vm);
                return await _accountService.ForgotPasswordAsync(forgotRequest, origin);
            }

            public async Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordViewModel vm)
            {
                 vm.Password = GeneratedPassword();
                ResetPasswordRequest resetRequest = _mapper.Map<ResetPasswordRequest>(vm);
                return await _accountService.ResetPasswordAsync(resetRequest);
            }
        public async Task<UpdateUserResponse> Update(UpdateUserViewModel vm)
        {
            UpdateUserRequest UpdateRequest = _mapper.Map<UpdateUserRequest>(vm);
            return await _userApplication.Update(UpdateRequest);
        }
        public async Task<UserResponse> GetByEmailUser(string email)
        {
            return await _userApplication.GetByEmailUser(email);
        }

        public string GeneratedPassword()
        {
			Random rdn = new Random();
			string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
			int longitud = caracteres.Length;
			char letra;
			int longitudContrasenia = 10;
			string contraseniaAleatoria = string.Empty;
			for (int i = 0; i < longitudContrasenia; i++)
			{
				letra = caracteres[rdn.Next(longitud)];
				contraseniaAleatoria += letra.ToString();
			}
            return contraseniaAleatoria;
		}

    }
    }

