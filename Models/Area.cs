using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMauiClient2.Models
{
    public class Area : INotifyPropertyChanged
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

        string? _nombre;
        public string? Nombre
        {
            get => _nombre;
            set
            {
                if (_nombre == value)
                    return;
                _nombre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nombre)));
            }
        }

        string? _sedeString;
        public string? SedeString
        {
            get => _sedeString;
            set
            {
                if (_sedeString == value)
                    return;
                _sedeString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SedeString)));
            }
        }

        int? _sedeId;

        public int? SedeId
        {
            get => _sedeId;
            set
            {
                if (_sedeId == value)
                    return;
                _sedeId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SedeId)));
            }
        }

        string? _dependenciaString;
        public string? DependenciaString
        {
            get => _dependenciaString;
            set
            {
                if (_dependenciaString == value)
                    return;
                _dependenciaString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DependenciaString)));
            }
        }

        int? _dependenciaId;

        public int? DependenciaId
        {
            get => _dependenciaId;
            set
            {
                if (_dependenciaId == value)
                    return;
                _dependenciaId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DependenciaId)));
            }
        }

        string? _estadoAreaString;
        public string? EstadoAreaString
        {
            get => _estadoAreaString;
            set
            {
                if (_estadoAreaString == value)
                    return;
                _estadoAreaString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EstadoAreaString)));
            }
        }

        int? _estadoAreaId;

        public int? EstadoAreaId
        {
            get => _estadoAreaId;
            set
            {
                if (_estadoAreaId == value)
                    return;
                _estadoAreaId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EstadoAreaId)));
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
