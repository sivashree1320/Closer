using Closer.Domain.Interface;
using Closer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closer.Service
{
    public class AccountService : IAccountService
    {
        private readonly string _demoUsername = "admin";
        private readonly string _demoPassword = "1234";

        public Task<bool> ValidateUserAsync(LoginViewModel model)
        {
            var isValid = model.Username == _demoUsername && model.Password == _demoPassword;
            return Task.FromResult(isValid);
        }
    }
}
