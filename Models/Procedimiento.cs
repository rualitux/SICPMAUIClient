using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMauiClient2.Models
{
    public class Procedimiento: INotifyPropertyChanged
    {
        int _id;
        public int Id 
        { 
            get => _id;
            set {
                if (_id == value)
                    return;
                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
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
        string? _procedimientotipostring;
        public string? ProcedimientoTipoString
        {
            get => _procedimientotipostring;
            set
            {
                if (_procedimientotipostring == value)
                    return;
                _procedimientotipostring = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProcedimientoTipoString)));
            }
        }
        string? _numerodocumento;
        public string? NumeroDocumento {
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
        public string? NumeroGuia {
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
        public DateTime? FechaDocumento {
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

        string? _causalString;
        public string? CausalString
        {
            get => _causalString;
            set
            {
                if (_causalString == value)
                    return;
                _causalString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CausalString)));
            }
        }

        int? _causalId;

        public int? CausalId {
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


        //string _todoname;
        //public string ToDoName { 
        //    get => _todoname;
        //    set
        //    {
        //        if (_todoname == value)
        //            return;
        //        _todoname = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ToDoName)));
        //    }


        //}

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
