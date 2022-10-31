namespace MyProject;

public class User
{
    public int id;

    private String username;

    private String password;


    public User(String username, String password)
    {
        this.username = username;
        this.password = password;
        this.id = generateId();
    }

    public int generateId()
    {
        Random random = new Random();
        return random.Next(1000 - 100) + 100;
    }

    public bool CheckCredentials(User user)
    {
        return user.username.Equals(this.username) && user.password.Equals(this.password);
    }
    

}