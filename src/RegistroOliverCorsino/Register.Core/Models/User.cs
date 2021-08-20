﻿using System;
using System.Collections.Generic;

namespace Core.Models
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
        /// Represents the relationship between the <see cref="User"/> entity and <see cref="Models.Role"/> entity.
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Represents the relationship between the <see cref="User"/> entity and <see cref="Models.EducationLevel"/> entity.
        /// </summary>
        public EducationLevel EducationLevel { get; set; }

        /// <summary>
        /// Represents the relationship between the <see cref="User"/> entity and <see cref="Models.ContactInformation"/> entity.
        /// </summary>
        public ICollection<ContactInformation> ContactInformation { get; set; }
    }
}
