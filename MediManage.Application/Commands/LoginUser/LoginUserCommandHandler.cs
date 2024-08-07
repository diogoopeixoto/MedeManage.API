﻿using MediatR;
using MediManage.Application.Services.Interfaces;
using MediManage.Application.ViewModels;
using MediManage.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserServices _userServices;
        public LoginUserCommandHandler(IAuthService authService, IUserServices userServices)
        {
            _authService = authService;
            _userServices = userServices;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            // Buscar no meu banco de dados um User que tenha meu e-mail e minha senha em formato hash
            var user = await _userServices.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            // Se nao existir, erro no login
            if (user == null)
            {
                return null;
            }

            // Se existir, gero o token usando os dados do usuário
            var token = _authService.GenerateJwtToken(user.Email, user.TenantId, user.Role);

            return new LoginUserViewModel(user.Email, user.TenantId, token);
        }
    }
}