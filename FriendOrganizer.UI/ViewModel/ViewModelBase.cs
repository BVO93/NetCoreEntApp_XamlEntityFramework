using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FriendOrganizer.UI.ViewModel
{
 
        public class ViewModelBase: INotifyPropertyChanged
        {


            // Interface of propertyChanged 
            public event PropertyChangedEventHandler PropertyChanged;

            // Normal you would pass to OnPropertyChanged using Name 
            // private void OnPropertyChanged(string propertyName )
            // Called by :   OnPropertyChanged(nameof(SelectedFriend));
            // Different approach is to make property optional. WHne this is adjusted it will at runtime automatically provide the name

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }


        }
    
}
