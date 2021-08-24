using Core.Models;
using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public sealed class UserViewModel
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
        /// Represents which role an user has.
        /// </summary>
        public int EducationLevelId { get; set; }

        /// <summary>
        /// Represents an user's personal identification number.
        /// </summary>
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Represents an user's first name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents an user's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Represents when an user was born.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Represents when an user was registered in the system.
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Represents the relationship between the <see cref="User"/> entity and <see cref="ContactInformation"/> entity.
        /// </summary>
        public ICollection<ContactInformation> ContactInformations { get; set; }
    }
}
