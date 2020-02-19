using MVCAuto.Library.Models;
using MVCAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuto.ModelView
{
    public class VehicleViews
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }

        public Vehicle SelVehicle { get; set; }

    }
}