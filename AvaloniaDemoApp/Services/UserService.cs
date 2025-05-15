using System;
using System.Collections.Generic;

public class UserService
{
    private readonly List<User> _users = new();
    public void AddUser(string name)
    {
        _users.Add(new User { Name = name});
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }   
}
