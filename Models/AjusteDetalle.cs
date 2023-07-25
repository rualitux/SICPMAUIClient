using System.ComponentModel;

namespace ToDoMauiClient2.Models
{
    public class AjusteDetalle: INotifyPropertyChanged
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

        int? _areaDestinoId;

        public int? AreaDestinoId
        {
            get => _areaDestinoId;
            set
            {
                if (_areaDestinoId == value)
                    return;
                _areaDestinoId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AreaDestinoId)));
            }
        }


        int? _areaOrigenId;

        public int? AreaOrigenId
        {
            get => _areaOrigenId;
            set
            {
                if (_areaOrigenId == value)
                    return;
                _areaOrigenId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AreaOrigenId)));
            }
        }
        int? _ajusteId;

        public int? AjusteId
        {
            get => _ajusteId;
            set
            {
                if (_ajusteId == value)
                    return;
                _ajusteId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AjusteId)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
