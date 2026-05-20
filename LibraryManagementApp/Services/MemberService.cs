using System.Text.RegularExpressions;
using LibraryManagementApp.Exceptions;
using LibraryManagementApp.Interfaces;
using LibraryManagementApp.Models;

namespace LibraryManagementApp.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository<int,String,Member> _memberRepository;
        public MemberService(IMemberRepository<int,String,Member> memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public void AddMember(Member member)
        {   
                _validateEmail(member.Email);
                _validateNumber(member.Phone);
                _memberRepository.CreateMember(member);
            
        }

        public List<Member>? GetAllMembers()
        {
            return _memberRepository.GetAllMembers();
        }

        public Member? GetMemberByGmail(string email)
        {
            return _memberRepository.GetMemberByEmail(email);
        }
 
        public Member? GetMemberByMemberId(int id)
        {
            return _memberRepository.GetMemberById(id);
        }

        public Member? UpdateMember(int id, Member member)
        {
            return _memberRepository.UpdateMember(member);
        }

        private void _validateEmail(string email)
        {
            string emailPattern=@"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (Regex.IsMatch(email, emailPattern))
            {
                return;
            }
            throw new InvalidInputFormatException("Invalid Email format  eg: smaplename@example.com");
        }

         private void _validateNumber(string number)
        {
            string numberPattern=@"^(\+?\d{1,3}[- ]?)?\(?\d{3}\)?[- ]?\d{3}[- ]?\d{4}$";
            if (Regex.IsMatch(number, numberPattern))
            {
                return;
            }
            throw new InvalidInputFormatException("Invalid Phone number format  eg: 0987654321 || ensure no letters involved");
        }
    }
}