using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICasualCustomerService
    {
        List<CasualCustomer> GetAllCustomers();
        Task<CasualCustomer> RegisterCasualCustomer(CasualCustomer user);
        Task<string> GetKindOfUser(object user);//check if this is working  
    }
}
