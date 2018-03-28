﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shipapp.Models;
using shipapp.Models.ModelData;
using System.Windows.Forms;
using shipapp.Connections.HelperClasses;

namespace shipapp.Connections.DataConnections.Classes
{
    class EmployeeConnClass:DatabaseConnection
    {
        object Sender { get; set; }
        public EmployeeConnClass() : base() { }

        public Faculty GetFaculty(long id)
        {
            return Get_Faculty(id);
        }
        /// <summary>
        /// Adds new faculty to the database
        /// </summary>
        /// <param name="f">Faculty object</param>
        public void AddFaculty(Faculty f)
        {
            Write(f);
        }
        /// <summary>
        /// Updates currect faculty in the database, DO NOT MODIFY OR CHANGE THE IDS OR PERSION ID!!!
        /// </summary>
        /// <param name="f">Modified faculty object</param>
        public void UpdateFaculty(Faculty f)
        {
            Update(f);
        }
        public async void GetAllAfaculty(object sender = null)
        {
            Sender = sender;
            SortableBindingList<Faculty> users = await Task.Run(() => Get_Faculty_List());
            if (!((Manage)Sender is null))
            {
                Manage t = (Manage)Sender;
                DataConnectionClass.DataLists.FacultyList = users;
                BindingSource bs = new BindingSource
                {
                    DataSource = DataConnectionClass.DataLists.FacultyList
                };
                t.dataGridView1.DataSource = bs;
            }
        }
        public void DeleteFaculty(Faculty f)
        {
            Delete(f);
        }
    }
}
