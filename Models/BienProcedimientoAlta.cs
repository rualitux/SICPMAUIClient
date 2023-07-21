using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMauiClient2.Models
{
    public class BienProcedimientoAlta : INotifyPropertyChanged
    {
        string? _nombrereferencial;
        public string? NombreReferencial
        {
            get => _nombrereferencial;
            set
            {
                if (_nombrereferencial == value)
                    return;
                _nombrereferencial = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NombreReferencial)));
            }
        }
      
        string? _numerodocumento;
        public string? NumeroDocumento
        {
            get => _numerodocumento;
            set
            {
                if (_numerodocumento == value)
                    return;
                _numerodocumento = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumeroDocumento)));
            }
        }
        string? _numeroguia;
        public string? NumeroGuia
        {
            get => _numeroguia;
            set
            {
                if (_numeroguia == value)
                    return;
                _numeroguia = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumeroGuia)));
            }
        }
        DateTime? _fechadocumento;
        public DateTime? FechaDocumento
        {
            get => _fechadocumento;
            set
            {
                if (_fechadocumento == value)
                    return;
                _fechadocumento = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FechaDocumento)));
            }
        }

        DateTime? _fechaRegistro;
        public DateTime? FechaRegistro
        {
            get => _fechaRegistro;
            set
            {
                if (_fechaRegistro == value)
                    return;
                _fechaRegistro = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FechaRegistro)));
            }
        }       

        int? _causalId;

        public int? CausalId
        {
            get => _causalId;
            set
            {
                if (_causalId == value)
                    return;
                _causalId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CausalId)));
            }
        }

        int? _procedimientoTipoId;

        public int? ProcedimientoTipoId
        {
            get => _procedimientoTipoId;
            set
            {
                if (_procedimientoTipoId == value)
                    return;
                _procedimientoTipoId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProcedimientoTipoId)));
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
