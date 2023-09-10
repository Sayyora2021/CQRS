using CQRS.Data;
using CQRS.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.UseCases.Accounts.Register
{
    public class RegisterCommandHandler
        : IRequestHandler<RegisterCommand>
    {
        private AppDbContext Context { get; }

        public RegisterCommandHandler(
            AppDbContext context)
        {
            Context = context;
        }

        public async Task<Unit> Handle(
            RegisterCommand request, CancellationToken cancellationToken)
        {
            await Context.Accounts.AddAsync(
                new Account
                {
                    Id = Guid.NewGuid(),
                    Email = request.Email,
                    Username = request.Username,
                    Password = request.Password
                });
            await Context.SaveChangesAsync();
            return Unit.Value;
        }

        Task IRequestHandler<RegisterCommand>.Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}


