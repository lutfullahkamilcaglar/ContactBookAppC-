using System.Collections;

namespace MyProject;

class UserManagerImpl : IUserManager
{
        private readonly INputManager _inputManager = new InputManagerImpl();
        private int _currentUserId = 0;
        // ask professor about should this implementation in interface and call it from there?
        private List<User> userList = new();

        public void Login()
        {
            var username = _inputManager.GetStringWithDescription(Resources.EnterUsername);
            var password = _inputManager.GetStringWithDescription(Resources.EnterPassword);
            User userInput = new User(username, password);
            var loginSuccessful = false;
            
                foreach (var user in userList)
                {
                    if (user.CheckCredentials(userInput))
                    {
                        loginSuccessful = true;
                        _currentUserId = user.id;
                        break;
                    }
                }
                if (!loginSuccessful)
                {
                    Console.WriteLine(Resources.LoginFailed);
                }
        }

       public void Register()
       {
           var username = _inputManager.GetStringWithDescription(Resources.EnterUsername);
           var password = _inputManager.GetStringWithDescription(Resources.EnterPassword);

           User newUser = new User(username, password);
           userList.Add(newUser);
           _currentUserId = newUser.id;

       }

        public void Logout()
        {
            _currentUserId = 0;
        }

        public bool GetIsAuthenticated()
        {
            return _currentUserId != 0;
        }

        public User GetUser()
        {
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].id == _currentUserId)
                {
                    return userList[i];
                }
            }
            return null!;
        }

    }
