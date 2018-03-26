﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shipapp.Models.ModelData;

namespace shipapp.Connections.DataConnections.Classes
{
    class BuildingConnClass : DatabaseConnection
    {
        public BuildingConnClass():base() { }
        public async void GetBuildingList()
        {
            DataConnectionClass.DataLists.BuildingNames = await Task.Run(()=> Get_Building_List());
        }
        public void WriteBuilding(BuildingClass building)
        {
            Write(building);
        }
        public void RemoveBuilding(BuildingClass building)
        {
            Delete(building);
        }
    }
}
