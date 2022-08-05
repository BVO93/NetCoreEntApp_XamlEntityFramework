using FriendOrganizer.Model;
using System.Collections.Generic;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        // Make method to return data until data base is ready.
        public IEnumerable<Friend> GetAll()
        {
            // TODO: Load data from real database
            yield return new Friend { Firstname = "Thomas", LastName = "Huber" };
            yield return new Friend { Firstname = "Andreas", LastName = "Boehler" };
            yield return new Friend { Firstname = "Julia", LastName = "Huber" };
            yield return new Friend { Firstname = "Chrissi", LastName = "Egin" };
        }

    }
}
