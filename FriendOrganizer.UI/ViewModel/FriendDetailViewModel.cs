using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private IFriendDataService _dataService;
        private IEventAggregator _eventAggregator;

        public FriendDetailViewModel(IFriendDataService dataService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
                .Subscribe(OnOpenFriendDetailView);

            // #8 Declaration of save command 
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        // #8 Icommand declaration
        public ICommand SaveCommand { get; }

        private bool OnSaveCanExecute()
        {
            // Is runned at startup 
            return true;
        }

        // #8  Method on save command 
        private async  void OnSaveExecute()
        {
            await _dataService.SaveAsync(Friend);
            // #8 After we have saved the update we have to notify the navigationVm 
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(
                new AfterFriendSavedEventArgs
                {
                    Id = Friend.Id,
                    DisplayMember = $"{Friend.Firstname} {Friend.LastName}"
                });
       
        }

        public async Task LoadAsync(int friendId)
        {
            Friend = await _dataService.GetByIdAsync(friendId);
        }

        private Friend _friend;
        public Friend Friend
        {
            get { return _friend; }
            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }
    
        private async void OnOpenFriendDetailView(int friendId) 
        {
            await LoadAsync(friendId);
        }



    }
}
