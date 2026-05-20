using LibraryManagementApp.Models;

namespace LibraryManagementApp.Interfaces
{
    public interface IMemberService
    {
        public void AddMember(Member member);
        public Member? GetMemberByMemberId(int id);
        public Member? GetMemberByGmail(string email);
        public List<Member>? GetAllMembers();
        public Member? UpdateMember(int id , Member member);

    }
}