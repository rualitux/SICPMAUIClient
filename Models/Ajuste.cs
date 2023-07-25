using System.ComponentModel;

namespace ToDoMauiClient2.Models
{
    public class Ajuste: INotifyPropertyChanged
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

        int? _ajusteTipoId;

        public int? AjusteTipoId
        {
            get => _ajusteTipoId;
            set
            {
                if (_ajusteTipoId == value)
                    return;
                _ajusteTipoId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AjusteTipoId)));
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

        string? _ajusteTipoString;
        public string? AjusteTipoString
        {
            get => _ajusteTipoString;
            set
            {
                if (_ajusteTipoString == value)
                    return;
                _ajusteTipoString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AjusteTipoString)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
