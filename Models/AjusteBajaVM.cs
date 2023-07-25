using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMauiClient2.Models
{
    public class AjusteBajaVM: INotifyPropertyChanged
    {
  
        string? _justificacion;
        public string? Justificacion
        {
            get => _justificacion;
            set
            {
                if (_justificacion == value)
                    return;
                _justificacion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Justificacion)));
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
        int? _cantidadAfectada;

        public int? CantidadAfectada
        {
            get => _cantidadAfectada;
            set
            {
                if (_cantidadAfectada == value)
                    return;
                _cantidadAfectada = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CantidadAfectada)));
            }
        }

        int? _inventarioId;

        public int? InventarioId
        {
            get => _inventarioId;
            set
            {
                if (_inventarioId == value)
                    return;
                _inventarioId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InventarioId)));
            }
        }
        int? _cantidad;
        public int? Cantidad
        {
            get => _cantidad;
            set
            {
                if (_cantidad == value)
                    return;
                _cantidad = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Cantidad)));
            }
        }
        int? _bienPatrimonialId;

        public int? BienPatrimonialId
        {
            get => _bienPatrimonialId;
            set
            {
                if (_bienPatrimonialId == value)
                    return;
                _bienPatrimonialId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BienPatrimonialId)));
            }
        }
        int? _anexoTipoId;

        public int? AnexoTipoId
        {
            get => _anexoTipoId;
            set
            {
                if (_anexoTipoId == value)
                    return;
                _anexoTipoId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnexoTipoId)));
            }
        }
        int? _estadoCondicionId;

        public int? EstadoCondicionId
        {
            get => _estadoCondicionId;
            set
            {
                if (_estadoCondicionId == value)
                    return;
                _estadoCondicionId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EstadoCondicionId)));
            }
        }
        int? _areaId;

        public int? AreaId
        {
            get => _areaId;
            set
            {
                if (_areaId == value)
                    return;
                _areaId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AreaId)));
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
