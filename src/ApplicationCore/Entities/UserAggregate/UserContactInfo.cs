using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace Inventura.ApplicationCore.Entities.UserAggregate
{
    // TODO: Expand this to have Contact Type
    public class UserContactInfo : BaseEntity
    {
        public string Contact { get; private set; }

        public UserContactInfo()
        {
        }

        public UserContactInfo(string contact)
        {
            Guard.Against.NullOrWhiteSpace(contact, nameof(contact));

            Contact = contact;
        }
    }
}