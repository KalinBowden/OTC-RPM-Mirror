﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shipapp.Models.ModelData;

namespace shipapp.Models
{
    /// <summary>
    /// Faculty Model Class
    /// </summary>
    class Faculty
    {
        /// <summary>
        /// Autogenerated Id Do not modify
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Identifyer in supplement tables, as string, max value 1000 bits and MUST be unique across all primary models
        /// </summary>
        public string Faculty_PersonId { get; set; }
        /// <summary>
        /// Faculty First Name as string
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Faculty Last Name as string
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Faculty Notes as List of Note
        /// </summary>
        public List<Note> Notes { get; set; }
        /// <summary>
        /// Faculty Phone as List of PhoneNumber
        /// </summary>
        public List<PhoneNumber> Phone { get; set; }
        /// <summary>
        /// Faculty Email as List of EmailAddress
        /// </summary>
        public List<EmailAddress> Email { get; set; }
        /// <summary>
        /// Faculty Address as List of PhysicalAddress
        /// </summary>
        public List<PhysicalAddress> Address { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        public Faculty()
        {
            Notes = new List<Note>() { };
            Phone = new List<PhoneNumber>() { };
            Email = new List<EmailAddress>() { };
            Address = new List<PhysicalAddress>() { };
        }

        public Faculty(long id, string Faculty_PersonId, string firstName, string lastName)
        {
            this.Id = id;
            this.Faculty_PersonId = Faculty_PersonId;
            this.FirstName = firstName;
            this.LastName = lastName;
            Notes = new List<Note>() { };
            Phone = new List<PhoneNumber>() { };
            Email = new List<EmailAddress>() { };
            Address = new List<PhysicalAddress>() { };
        }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
