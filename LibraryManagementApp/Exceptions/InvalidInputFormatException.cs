namespace LibraryManagementApp.Exceptions
{
    [System.Serializable]
    public class InvalidInputFormatException : System.Exception
    {
        public InvalidInputFormatException() { }
        public InvalidInputFormatException(string message) : base(message) { }
     
    }
}