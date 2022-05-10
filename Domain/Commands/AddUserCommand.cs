using Entity.Entities;
using MediatR;
using Model.Constant;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class AddUserCommand : IRequest<(Entity.Entities.User, string)>
    {
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public AddUserCommand(string name,
            string userName,
            string password
            )
        {
            Name = name;
            UserName = userName;
            Password = password;
        }
    }

    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, (Entity.Entities.User, string)>
    {
        private readonly IAuthenticate _authenticate;
        public AddUserCommandHandler(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }
        public async Task<(Entity.Entities.User, string)> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            User newEntry = new User
            {
                Name = request.Name,
                Username = request.UserName,
                Password = _authenticate.EncodePasswordToBase64(request.Password)
            };
            var response = await _authenticate.AddUser(newEntry);
            return await Task.FromResult((response, AuthMessages.Success));
        }
    }
}
