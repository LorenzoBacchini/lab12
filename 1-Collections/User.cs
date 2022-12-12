using System;
using NUnit.Framework;

namespace Collections
{
    public class User : IUser
    {
        public User(string fullName, string username, uint? age)
        {
            Username = username ?? throw new ArgumentNullException("The username cannot be null");
            FullName = fullName;
            Age = age;
        }

        public uint? Age { get; }

        public string FullName { get; }

        public string Username { get; }

        public bool IsAgeDefined => Age.HasValue;

        public override string ToString()
        {
            return $"Age: {Age}, FullName: {FullName}, Username: {Username}";
        }

        private bool Equals(IUser other)
        {
            return Age == other.Age && FullName == other.FullName && Username == other.Username;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((User)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Age, FullName, Username);
        }
    }
}
