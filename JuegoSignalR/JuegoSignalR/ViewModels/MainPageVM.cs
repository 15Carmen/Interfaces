using JuegoSignalR.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using JuegoSignalR.Views;
using System.Xml.Linq;

namespace JuegoSignalR.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        //private clsPlayer player;
        //private DelegateCommand startGameCommand; 

        //public MainPageVM(clsPlayer player)
        //{
        //    this.player = player;
        //    StartGameCommand = new DelegateCommand(StartGameCommand_Execute, StartGameCommand_CanExecute);
        //}

        //public clsPlayer Player
        //{
        //    get { return player; }
        //    set 
        //    { 
        //        player = value;
        //        NotifyPropertyChanged(nameof(Player));
        //    }
        //}

        //public DelegateCommand StartGameCommand
        //{
        //    get { return startGameCommand; }
        //}

        //private async void StartGameCommand_Execute()
        //{ 
        //    player = new clsPlayer();
        //    //Navegamos a la página de juego
        //    await Shell.Current.Navigation.PushAsync(new GamePage());
        //}

        //private bool StartGameCommand_CanExecute()
        //{
        //    bool canStart = false;
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        canStart = true;
        //    }
        //    return canStart;
        //}

    }

}
