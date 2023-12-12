using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.ViewModels.Utilidades
{
    public abstract class clsVMBase : INotifyPropertyChanged
    {
        private bool cargando;

        public bool Cargando
        {
            get { return cargando; }
            set
            {
                cargando = value;
                NotifyPropertyChanged(nameof(Cargando));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
