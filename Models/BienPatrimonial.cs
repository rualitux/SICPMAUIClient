using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMauiClient2.Models
{
    public class BienPatrimonial : INotifyPropertyChanged
    {
        int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id == value)
                    return;
                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        string? _denominacion;
        public string? Denominacion
        {
            get => _denominacion;
            set
            {
                if (_denominacion == value)
                    return;
                _denominacion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Denominacion)));
            }
        }

        string? _codigoSBN;
        public string? CodigoSBN
        {
            get => _codigoSBN;
            set
            {
                if (_codigoSBN == value)
                    return;
                _codigoSBN = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CodigoSBN)));
            }
        }

        string? _marca;
        public string? Marca
        {
            get => _marca;
            set
            {
                if (_marca == value)
                    return;
                _marca = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Marca)));
            }
        }

        string? _modelo;
        public string? Modelo
        {
            get => _modelo;
            set
            {
                if (_modelo == value)
                    return;
                _modelo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Modelo)));
            }
        }

        string? _serie;
        public string? Serie
        {
            get => _serie;
            set
            {
                if (_serie == value)
                    return;
                _serie = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Serie)));
            }
        }

        string? _color;
        public string? Color
        {
            get => _color;
            set
            {
                if (_color == value)
                    return;
                _color = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }

        string? _observacion;
        public string? Observacion
        {
            get => _observacion;
            set
            {
                if (_observacion == value)
                    return;
                _observacion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Observacion)));
            }
        }

        
        int _categoriaId;
        public int CategoriaId
        {
            get => _categoriaId;
            set
            {
                if (_categoriaId == value)
                    return;
                _categoriaId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CategoriaId)));
            }
        }

        string? _categoriaString;
        public string? CategoriaString
        {
            get => _categoriaString;
            set
            {
                if (_categoriaString == value)
                    return;
                _categoriaString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CategoriaString)));
            }
        }

        int _procedimientoId;
        public int ProcedimientoId
        {
            get => _procedimientoId;
            set
            {
                if (_procedimientoId == value)
                    return;
                _procedimientoId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProcedimientoId)));
            }
        }

        string? _procedimientoString;
        public string? ProcedimientoString
        {
            get => _procedimientoString;
            set
            {
                if (_procedimientoString == value)
                    return;
                _procedimientoString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProcedimientoString)));
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;
    }
}
