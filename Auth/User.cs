namespace Auth;
class User
{
    public string Username { set; get; }
    public string Firstname { set; get; }
    public string Lastname { set; get; }
    public string Password { set; get; }

    public User (string firstname, string lastname, string password)
    {
        Firstname = firstname;
        Lastname = lastname;
        Password = password;
        Username = firstname.Substring(0, 2) + lastname.Substring(0, 2);
    }

    public string getUserData()
    {
        return $"Fullname : {Firstname} {Lastname} \n" +
               $"Username : {Username}\n" +
               $"Password : {Password}\n";
    }
}
