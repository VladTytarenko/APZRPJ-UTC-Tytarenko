using UTC.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace UTC.ViewModels
{
    internal class SignInViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _password;
        private string _login;

        #region Commands
        private ICommand _closeCommand;
        private ICommand _signInCommand;
        private ICommand _signUpCommand;
        #endregion
        #endregion

        #region Properties
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        #region Commands

        public ICommand CloseCommand
        {
            get;         
        }

        public ICommand SignInCommand
        {
            get;               
        }

        /*public ICommand SignUpCommand
        {
            get;          
        }*/

        #endregion
        #endregion

        #region ConstructorAndInit
        internal SignInViewModel()
        {
        }
        #endregion

        /*private void SignUpExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.SingUp);
        }*/

        private void SignInExecute(object obj)
        {
            //LoaderManager.Instance.ShowLoader();
            //var result = await Task.Run(() =>
            //{
                User currentUser = new User {
                        Username = "TestName",
                        Password = "1234"
                        //ClockList = clockList
                    };
                
                
                if (currentUser == null)
                {
                    MessageBox.Show(String.Format("SignIn_UserDoesntExist", _login));
                    //return false;
                }
                
                if (currentUser.Password != _password)
                {
                    MessageBox.Show("SignIn_WrongPassword");
                        //return false;
                }
                
                    //MessageBox.Show(String.Format("SignIn_FailedToValidatePassword", Environment.NewLine,
                   //     ex.Message));
                    //return false;
               
               // StationManager.CurrentUser = currentUser;
                //return true;
           // });
            //LoaderManager.Instance.HideLoader();
            //if (result)
                //NavigationManager.Instance.Navigate(ModesEnum.Main);
        }

        private bool SignInCanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login) && !String.IsNullOrWhiteSpace(_password);
        }

        private void CloseExecute(object obj)
        {
            //StationManager.CloseApp();
        }

        #region EventsAndHandlers
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}