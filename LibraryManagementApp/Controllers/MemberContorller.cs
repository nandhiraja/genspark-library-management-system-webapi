using LibraryManagementApp.Interfaces;
using LibraryManagementApp.Models;
using LibraryManagementApp.Models.DTOs;
using LibraryManagementApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.Controllers
{
   
    [ApiController]
    [Route("api/[Controller]")]
    public class MemberController : ControllerBase
    {
        private IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet("all")]
        public ActionResult<List<CreateMemberResponse>> GetAllMembers()
        {   
            List<Member>? memberList = _memberService.GetAllMembers();
            List<CreateMemberResponse> allMembers = new List<CreateMemberResponse>();

            if(memberList==null)
            {
                return Ok(allMembers);
            }

            foreach(var mem in memberList)
            {
                
                     CreateMemberResponse newMember = new CreateMemberResponse()
                                {
                                    MemberId = mem.MemberId,
                                    Name = mem.Name,
                                    Email = mem.Email,
                                    IsActive =true,
                                    Phone = mem.Phone

                                };
                        allMembers.Add(newMember);
                    
                
            }
             return Ok(allMembers);
 
        }   
        [HttpGet]
        public ActionResult GetMemberById(int id)
        {  
            
            try{
                Member? member = _memberService.GetMemberByMemberId(id);
                if (member == null)
                {
                    return BadRequest("UserNotFound");
                }
                
                CreateMemberResponse newMember = new CreateMemberResponse()
                                    {
                                        MemberId = member.MemberId,
                                        Name = member.Name,
                                        Email = member.Email,
                                        IsActive =member.IsActive,
                                        Phone = member.Phone
    
                                    };
                return Ok(newMember);
           
            }
            catch(Exception ex){
    
              return BadRequest($"User Not found {ex}");
            }
        } 
        [HttpPost]
        public ActionResult<string> AddMember(CreateMemberRequest member)
        {   
            try{
            Member newMember = new Member()
            {
                Name = member.Name,
                Email = member.Email,
                Password = member.Password,
                IsActive =true,
                Phone = member.Phone

            };
            _memberService.AddMember(newMember);

            return Created("","Member Register Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest($"Unable to create a member \n{ex}");
            }
        }

       
    }
}