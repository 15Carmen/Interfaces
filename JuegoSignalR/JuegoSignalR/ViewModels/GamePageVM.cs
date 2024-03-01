using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuegoSignalR.ViewModels.Utils;
using JuegoSignalR.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace JuegoSignalR.ViewModels
{
    public partial class GamePageVM : clsVMBase
    {

        #region atributos
        private int playerTurn = 0;

        List<int[]> WinPossibilities = new List<int[]>();
       

        #endregion

        #region constructores
        public GamePageVM()
        {
            SetUpGameInfo();
            
        }
        #endregion

        #region propiedades

        public ObservableCollection<TicTacToeModel> TicTacList { get; set; } = new ObservableCollection<TicTacToeModel>();



        #endregion

        #region commands

        public void SelectedItem(TicTacToeModel selectedItem)
        {
            if(playerTurn == 0)
            {
                selectedItem.SelectedText = "X"; //Player 1
            }
            else
            {
                selectedItem.SelectedText = "O"; //Player 2
            }

            // Por default el jugador es nulo, lo que significa que el jugador no ha
            // elegido ninguna casilla
            selectedItem.Player = playerTurn;


            //Cambiar el turno de los jugadores
            playerTurn = playerTurn == 0 ? 1 : 0;

            NotifyPropertyChanged(nameof(SelectedItem));

            CheckForWin();
        }

        #endregion

        #region metodos y funciones
        private void SetUpGameInfo()
        {
            //Añadimos las posibles combinaciones ganadoras

            //Combinaciones horizontales
            WinPossibilities.Add(new[] { 0, 1, 2 });
            WinPossibilities.Add(new[] { 3, 4, 5 });
            WinPossibilities.Add(new[] { 6, 7, 8 });

            //Combinaciones verticales
            WinPossibilities.Add(new[] { 0, 3, 6 });
            WinPossibilities.Add(new[] { 1, 4, 7 });
            WinPossibilities.Add(new[] { 2, 5, 8 });

            //Combinaciones diagonales
            WinPossibilities.Add(new[] { 0, 4, 8 });
            WinPossibilities.Add(new[] { 2, 4, 6 });

            TicTacList.Clear();
            TicTacList.Add(new TicTacToeModel(0));
            TicTacList.Add(new TicTacToeModel(1));
            TicTacList.Add(new TicTacToeModel(2));
            TicTacList.Add(new TicTacToeModel(3));
            TicTacList.Add(new TicTacToeModel(4));
            TicTacList.Add(new TicTacToeModel(5));
            TicTacList.Add(new TicTacToeModel(6));
            TicTacList.Add(new TicTacToeModel(7));
            TicTacList.Add(new TicTacToeModel(8));


        }

        private void CheckForWin()
        {
            var player1IndexList = TicTacList.Where(f => f.Player == 0).Select(f => f.Index);
            var player2IndexList = TicTacList.Where(f => f.Player == 1).Select(f => f.Index);


            //Comprobamos que el player index coincide con las posibilidades de ganar o no
            //if(player1IndexList.Count > 2 || player2IndexList > 2)
            //{
            //    foreach(var winPossibility in WinPossibilities)
            //    {
            //        int player1Count = 0;
            //        int player2Count = 0;

            //        foreach(var index in playerIndexList)
            //        {

            //        }
            //    }
            //}
        }


        #endregion
    }
}
