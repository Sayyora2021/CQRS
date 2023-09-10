using CQRS.Data;
using CQRS.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.UseCases.Accounts.Login
{
    public class LoginQueryHandler 
        : IRequestHandler<LoginQuery,Account>
    {
        private AppDbContext Context { get; }
        public LoginQueryHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<Account> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return await Context.Accounts.SingleOrDefaultAsync(a=> a.Email == request.Email
            && a.Password == request.Password);
        }
    }
}
