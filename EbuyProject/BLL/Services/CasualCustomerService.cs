using BLL.Interfaces;
using Models;
using SqlData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CasualCustomerService : ICasualCustomerService
    {
        private _1044_EEK1Context _context;

        public CasualCustomerService(_1044_EEK1Context context)
        {
            _context = context;
        }
        public List<CasualCustomer> GetAllCustomers()
        {
            List<CasualCustomer> casualCustomerList = new List<CasualCustomer>();
            List<Customer> customerList = _context.Customers.ToList();
            foreach (var item in customerList)
            {
                if (!item.IsClubMember) casualCustomerList.Add((CasualCustomer)item);
            }
            return casualCustomerList;
        }

        public async Task<CasualCustomer> RegisterCasualCustomer(CasualCustomer user)
        {
            if (user.LoginName == null) return null;
            _context.Customers.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void AddCookie(CasualCustomer user)
        {
            //HttpContext.Response.Cookies.Append("userFName", user.FirstName, new CookieOptions() { Expires = DateTime.Now.AddDays(3) });
        }

        //public async Task<bool> LoginCasualCustomer(CasualCustomer user)
        //{
        //    List<CasualCustomer> clubMembersList = GetAllCasualCustomer();
        //    foreach (CasualCustomer casualCustomer in clubMembersList)
        //    {
        //        if (casualCustomer.CustomerId == user.CustomerId) return true;
        //    }
        //    return false;
        //}

        public async Task<string> GetKindOfUser(object user)//check if this is working
        {
            var typeOfUser = user.GetType();
            if (typeOfUser == typeof(Models.CasualCustomer)) return "ClubMember";
            else return "CasualCustomer";
        }

    }
}
