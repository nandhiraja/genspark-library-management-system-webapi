
namespace LibraryManagementApp.Interfaces
{
    public interface IMemberRepository<K,S,T> where T : class
    {
        public T? CreateMember(T t);
        public List<T>?  GetAllMembers();
        public T? GetMemberById(K id);
        public T? GetMemberByEmail(S id);

        public T UpdateMember(T t);
        public T DeleteMember(T t);


    }
}