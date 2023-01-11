using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
   public class NavigationItemViewModel : ViewModelBase
    {
        // #8 We make this navigationItemViewModel because we inherent from VMBase and use OnPropertyChanged
        // The original lookupitem did not inherent from base and does not have  onpropertyachanged

        private string _displayMember;

        public NavigationItemViewModel(int id, string displayMember)
        {
            Id = id;
            DisplayMember = displayMember;
        }

        public int Id { get;  }

        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                // #8 Have 
                OnPropertyChanged();

            }
        }

    }
}
