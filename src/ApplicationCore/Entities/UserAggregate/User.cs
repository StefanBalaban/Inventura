using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Inventura.ApplicationCore.Interfaces;
using Inventura.ApplicationCore.Extensions;

namespace Inventura.ApplicationCore.Entities.UserAggregate
{
    public class User : BaseEntity, IAggregateRoot
    {
        private readonly List<UserContactInfo> _userContactInfos = new List<UserContactInfo>();
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IReadOnlyList<UserContactInfo> UserContactInfos => _userContactInfos.AsReadOnly();

        public User()
        {
        }

        public User(string firstName, string lastName, string contact)
        {
            Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
            Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
            AddUserContactInfo(contact);
        }

        public void AddUserContactInfo(string contact)
        {
            Guard.Against.DuplicateContactInfo(contact, _userContactInfos);

            _userContactInfos.Add(new UserContactInfo(contact));
        }

        public void RemoveUserContactInfo(string contact)
        {
            Guard.Against.NullOrWhiteSpace(contact, nameof(contact));

            var userContactInfoForRemoval = _userContactInfos.SingleOrDefault(x => x.Contact == contact);
            if (userContactInfoForRemoval != null) _userContactInfos.Remove(userContactInfoForRemoval);
        }
    }
}