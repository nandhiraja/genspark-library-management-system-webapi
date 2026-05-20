namespace LibraryManagementApp.Models
{
       public class Member
    {
         public int MemberId { get; set; }
         public string Name { get; set; } = null!;
         public string Email { get; set; }= null!;
         public string Phone { get; set; }= null!;
         public string Password { get; set; }= null!;
         public bool IsActive { get; set; }

         public Member()
         {

         }

    }
}   