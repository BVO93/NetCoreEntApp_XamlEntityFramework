using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private Func<FriendOrganizerDbContext> _contextCreator;

        public FriendDataService(Func<FriendOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        // Make method to return data until data base is ready.
        public async Task<List<Friend>> GetAllAsync()
        {
            // TODO: Load data from real database
            using (var ctx = _contextCreator())    //  First was new FriendOrganizerDbContext()). But using bootstrapper is possible.
             {
                return await ctx.Friends.AsNoTracking().ToListAsync();
            }
        }

    }
}
