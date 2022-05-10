using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Model.Factory;
using Model.Response;
using Repository.Repository;

namespace Domain.Queries
{
    public class AuthenticateUserQuery : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public AuthenticateUserQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, string>
    {
        private readonly IAuthenticate _authenticate;
        public AuthenticateUserQueryHandler(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }
        public async Task<string> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_authenticate.Auth(request.UserName, request.Password));
        }
    }
}
