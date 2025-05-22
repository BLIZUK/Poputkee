using Poputkee.Core.Models;
using System.Collections.Generic;


namespace Poputkee.Core.Services
{
    public interface ITripService
    {
        List<Trip> GetCompletedTrips();

        //List<Trip> PushCompletedTrips();

        void UpdateTrip(Trip trip);
    }
}