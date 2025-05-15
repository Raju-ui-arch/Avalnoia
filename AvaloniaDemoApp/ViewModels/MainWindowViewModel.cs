using System;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;

namespace AvaloniaDemoApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly UserService _userService = new();
        private string _userName = string.Empty; // Initialize to avoid CS8618

        public MainWindowViewModel()
        {
            AddUserCommand = ReactiveCommand.Create(
                AddUser,
                outputScheduler: RxApp.MainThreadScheduler  // marshal notifications to UI thread
            );
        }

        public string UserName
        {
            get => _userName;
            set => this.RaiseAndSetIfChanged(ref _userName, value);
        }

        public ObservableCollection<string> UserNames { get; } = new();
        public ReactiveCommand<Unit, Unit> AddUserCommand { get; }

        private void AddUser()
        {
            _userService.AddUser(UserName);

            UserNames.Clear();
            foreach (var user in _userService.GetAllUsers())
            {
                UserNames.Add(user.Name);
            }
            UserName = string.Empty;
        }
    }
}
