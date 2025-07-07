using Closer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closer.Domain.Interface
{
    public interface IAccountService
    {
        Task<bool> ValidateUserAsync(LoginViewModel model);
    }
}
