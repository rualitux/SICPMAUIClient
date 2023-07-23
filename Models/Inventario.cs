using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMauiClient2.Models
{
    public class Inventario : INotifyPropertyChanged
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

        string? _bienPatrimonialString;
        public string? BienPatrimonialString
        {
            get => _bienPatrimonialString;
            set
            {
                if (_bienPatrimonialString == value)
                    return;
                _bienPatrimonialString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BienPatrimonialString)));
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

        string? _anexoTipoString;
        public string? AnexoTipoString
        {
            get => _anexoTipoString;
            set
            {
                if (_anexoTipoString == value)
                    return;
                _anexoTipoString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnexoTipoString)));
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

        string? _estadoCondicionString;
        public string? EstadoCondicionString
        {
            get => _estadoCondicionString;
            set
            {
                if (_estadoCondicionString == value)
                    return;
                _estadoCondicionString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EstadoCondicionString)));
            }
        }

        int? _estadoBienId;

        public int? EstadoBienId
        {
            get => _estadoBienId;
            set
            {
                if (_estadoBienId == value)
                    return;
                _estadoBienId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EstadoBienId)));
            }
        }

        string? _estadoBienString;
        public string? EstadoBienString
        {
            get => _estadoBienString;
            set
            {
                if (_estadoBienString == value)
                    return;
                _estadoBienString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EstadoBienString)));
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

        string? _areaString;
        public string? AreaString
        {
            get => _areaString;
            set
            {
                if (_areaString == value)
                    return;
                _areaString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AreaString)));
            }
        }

        int? _procedimientoId;

        public int? ProcedimientoId
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
