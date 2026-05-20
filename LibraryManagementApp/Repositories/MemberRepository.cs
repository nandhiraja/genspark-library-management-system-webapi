using LibraryManagementApp.Contexts;
using LibraryManagementApp.Interfaces;
using LibraryManagementApp.Models;

namespace LibraryManagementApp.Repositories
{
    public class MemberRepository : IMemberRepository<int,string,Member>
    {

        private  LibraryDbContext _context;

        public MemberRepository(LibraryDbContext context)
        {
            _context =context;
        }
        public Member? CreateMember(Member member)
        {
             _context.members.Add(member);
             _context.SaveChanges();
             return GetMemberByEmail(member.Email);

        }

        public List<Member>? GetAllMembers()
        {
            return _context.members.ToList();
        }

        public Member? GetMemberByEmail(string email)
        {
            return _context.members.FirstOrDefault(m=>m.Email==email);
        }

        public Member? GetMemberById(int id)
        {
            return _context.members.Find(id);
        }


        public Member UpdateMember(Member updateMember)
        {
            Member? member = GetMemberById(updateMember.MemberId);
            if (member == null)
            {
                throw new Exception($"Member not exist {updateMember.MemberId}");
            }
            member.Name= updateMember.Name;
            member.Email = updateMember.Email;
            member.Phone = updateMember.Phone;
            member.Password = updateMember.Password;
            _context.SaveChanges();
            return member;
        }

         public Member DeleteMember(Member deleteMember)
        {
             Member? member = GetMemberById(deleteMember.MemberId);
            if (member == null)
            {
                throw new Exception($"Member not exist {deleteMember.MemberId}");
            }
            _context.members.Remove(member);
            _context.SaveChanges();
            return member;
        }

    }
}