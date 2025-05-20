using Poputkee.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public interface ITripService
    {
        List<Trip> GetCompletedTrips();
 }
