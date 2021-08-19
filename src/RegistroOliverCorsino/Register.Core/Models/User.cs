using System;
using System.Collections.Generic;

namespace Register.Core.Models
{
    /// <summary>
    /// Represents who can use the system and perform some action base on its role.
    /// </summary>
    public sealed class User
    {
        /// <summary>
        /// Represents the entity identification or PK.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents which role an user has.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Represents an user's first name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents an user's first lastname.
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Represents an user's personal identification number.
        /// </summary>
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Represents when an user was born.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Represents when an user was registered in the system.
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Represents the relationship between the <see cref="User"/> entity and <see cref="Role"/> entity.
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Represents the relationship between the <see cref="User"/> entity and <see cref="ContactInformation"/> entity.
        /// </summary>
        public ICollection<ContactInformation> ContactInformations { get; set; }
    }
}
