﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shipapp.Models.ModelData
{
    /// <summary>
    /// User Roles -- ADMIN MODIFY ONLY
    /// </summary>
    class Role
    {
        /// <summary>
        /// Autogenerated ID Do not modify
        /// </summary>
        public long Role_id { get; set; }
        /// <summary>
        /// Role Title (Must be unique in database) as string
        /// </summary>
        public string Role_Title { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        public Role() { }
        public override string ToString()
        {
            return Role_Title.ToString();
        }
    }
}
