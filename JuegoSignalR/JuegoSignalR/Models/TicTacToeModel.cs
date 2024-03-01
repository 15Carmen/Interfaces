using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSignalR.Models
{
    public partial class TicTacToeModel : ObservableObject
    {
        [ObservableProperty]
        private string selectedText;

        public TicTacToeModel(int index) 
        {
            this.Index = index;
        }

        public int Index { get; set; }

        //PlayerX igual a 0 y PlayerO igual a 1 
        //Null significa que no ha sido selccionado por un Player
        public int? Player {  get; set; }

    }
}
