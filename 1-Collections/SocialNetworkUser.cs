using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {

        private Dictionary<string, List<TUser>> _followed = new();
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            var value = new List<TUser>();
            if (_followed.ContainsKey(group))
            {
                value = _followed[group];
                if (value.Contains(user)) return false;
                value.Add(user);
                return true;
            }
            value.Add(user);
            _followed.Add(group, value);
            return true;
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                var totalUser = new List<TUser>();
                foreach (var list in _followed.Values)
                {
                    totalUser.AddRange(list);
                }

                return totalUser;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            if (!_followed.ContainsKey(group)) return new List<TUser>();
            var value = _followed[group];
            return value;

        }
    }
}
