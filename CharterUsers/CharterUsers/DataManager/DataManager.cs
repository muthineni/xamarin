using System;
using Foundation;
using System.Collections.Generic;
using CharterUsers.Model;
using Newtonsoft.Json;

namespace CharterUsers
{
    public class DataManager
    {
        private static readonly DataManager instance = new DataManager();
        private List<User> usersList = new List<User>();
        public const string UsersListKey = "SaveUsersListKey";
        private DataManager()
        {
            LoadUsers();
        }
        public static DataManager Instance
        {
            get
            {
                return instance;
            }
        }

        public List<User> UsersList { get => usersList; set => usersList = value; }


        public void SaveUser(User user,int editingIndex)
        {
            //New User
            if (editingIndex == -1)
            {
                this.UsersList.Add(user);
            }
            else
            {
                this.UsersList.RemoveAt(editingIndex);
                this.UsersList.Insert(editingIndex, user);
            }
            var stringUserList = JsonConvert.SerializeObject(UsersList);
            var userDefaults = NSUserDefaults.StandardUserDefaults;

            userDefaults.SetString(stringUserList, UsersListKey);
            userDefaults.Synchronize();
        }

        private void LoadUsers()
        {
            var userDefaults = NSUserDefaults.StandardUserDefaults;

            var stringUserList = userDefaults.StringForKey(UsersListKey);
            if (!string.IsNullOrEmpty(stringUserList))
            {
                this.usersList = JsonConvert.DeserializeObject<List<User>>(stringUserList);
            }
        }
    }
}
