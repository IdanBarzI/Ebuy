using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClubMemberService
    {
        Task<List<ClubMember>> GetAllClubMembers();
        Task<ClubMember> RegisterClubMembers(ClubMember user);//TODO: להחזיר משתמש 
        Task<ClubMember> LoginClubMembers(string userName, string password);//TODO: להחזיר משתמש 
        Task<ClubMember> GetOneClubMemberByName(string userName);
        Task<List<Product>> GetBogoProducts(ClubMember user);

    }
}
