using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuegoSignalR.ViewModels.Utils;

namespace JuegoSignalR.ViewModels
{
    public class GamePageVM : clsVMBase
    {

        #region atributos

        private int scoreX;
        private int scoreO;
        private bool isNext = true; //Variable para determinar el siguiente turno (X o O)
        private string textoBotonClicado;

        private DelegateCommand buttonXorOCommand;
        private DelegateCommand buttonResetCommand;
        private DelegateCommand buttonNewGameCommand;
        private DelegateCommand buttonExitCommand;


        #endregion

        #region constructores
        public GamePageVM()
        {
            textoBotonClicado = string.Empty;
            buttonXorOCommand = new DelegateCommand(ButtonXorOCommand_Execute);
            buttonResetCommand = new DelegateCommand(ButtonResetCommand_Execute);
            buttonNewGameCommand = new DelegateCommand(ButtonNewGameCommand_Execute);
            buttonExitCommand = new DelegateCommand(ButtonExitCommand_Execute);
        }
        #endregion

        #region propiedades

        public int ScoreX
        {
            get { return scoreX; }
            
        }

        public int ScoreO
        {
            get { return scoreO; }
            
        }

        public string TextoBotonClicado
        {
            get { return textoBotonClicado; }
            set 
            { 
                textoBotonClicado = value;
                NotifyPropertyChanged(nameof(textoBotonClicado));
            }
        }

        public DelegateCommand ButtonXorOCommand
        {
            get { return buttonXorOCommand; }
        }

        public DelegateCommand ButtonResetCommand
        {
            get { return buttonResetCommand; }
        }
        public DelegateCommand ButtonNewGameCommand
        {
            get { return buttonNewGameCommand; }
        }

        public DelegateCommand ButtonExitCommand
        {
            get { return buttonExitCommand; }
        }

        #endregion

        #region commands

        private void ButtonXorOCommand_Execute()
        {
            if(string.IsNullOrEmpty(textoBotonClicado) )
            {
                textoBotonClicado = isNext ? "X" : "O";
                isNext = !isNext; //Cambiamos al siguiente jugador

                CheckForWin();
                NotifyPropertyChanged(nameof(textoBotonClicado));   
            }
            
        }

        /// <summary>
        /// Método que reiniciará el juego, es decir, limpiará los botones para que tengan
        /// el texto en blanco y reactivará los botones que se hayan desactivado.
        /// </summary>
        private void ButtonResetCommand_Execute()
        {
            //Como pongo en blanco todos los botones si no los clico??? 
            //PREGUNTAR A FERNANDO

            // Reiniciar el texto de los botones
            TextoBotonClicado = string.Empty;
        }

        /// <summary>
        /// Método que empezará un juego completamente nuevo, por lo que reiniciará las 
        /// puntuaciones de los jugadores, limpiará los botones para que tengan el texto en
        /// blanco y reactivará los botones que se hayan desactivado
        /// </summary>
        private void ButtonNewGameCommand_Execute()
        {

        }

        /// <summary>
        /// Método que saldrá de la aplicación. Se le mostrará al usuario un mensaje de 
        /// confirmación preguntando si está seguro de salir. La aplicación se cerrará si el 
        /// usuario lo confirma.
        /// </summary>
        private void ButtonExitCommand_Execute()
        {

        }

        #endregion

        #region metodos y funciones

        /// <summary>
        /// Método que comprueba si hay un ganador después de cada movimiento.
        /// Actualizará las puntuaciones de los jugadores si es necesario.
        /// Mostrará un mensahe de ganador, de perdedor o de empate según corresponda.
        /// </summary>
        private void CheckForWin()
        {

        }

        #endregion
    }
}
