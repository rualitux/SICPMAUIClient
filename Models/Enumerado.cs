using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMauiClient2.Models
{
    public class Enumerado: INotifyPropertyChanged
    {
        int _id;
        public int Id {
            get => _id;
            set
            {
                if (_id == value)
                    return;
                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }
        string? _descripcion;
        public string? Descripcion {
            get => _descripcion;
            set
            {
                if (_descripcion == value)
                    return;
                _descripcion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Descripcion)));
            }
        }
        string? _valor;
        public string? Valor {
            get => _valor;
            set
            {
                if (_valor == value)
                    return;
                _valor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Valor)));
            }
        }
        int? _padre;

        public int? Padre {
            get => _padre;
            set
            {
                if (_padre == value)
                    return;
                _padre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Padre)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
