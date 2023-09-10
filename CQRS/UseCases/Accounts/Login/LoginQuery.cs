using CQRS.Entities;
using MediatR;
namespace CQRS.UseCases.Accounts.Login
{
    public class LoginQuery: IRequest<Account>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
