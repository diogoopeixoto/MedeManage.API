using MediatR;
using MediManage.Application.Queries.GetUser;
using MediManage.Application.Services.Interfaces;
using MediManage.Application.ViewModels;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
{
    private readonly IUserServices _userServices;

    public GetUserQueryHandler(IUserServices userServices)
    {
        _userServices = userServices;
    }

    public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userServices.GetByIdAsync(request.Id, request.TenantId);

        if (user == null)
        {
            return null;
        }

        return new UserViewModel(
            user.FullName,
            user.Email,
            user.BirthDate,
            user.CreatedAt,
            user.Active,
            user.Role,
            user.TenantId
        );
    }
}
