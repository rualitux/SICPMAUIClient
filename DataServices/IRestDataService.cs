using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMauiClient2.Models;

namespace ToDoMauiClient2.DataServices
{
    public interface IRestDataService
    {
        //Procedimientos
        Task<List<Procedimiento>> GetAllToDosAsync();
        Task<List<Area>> GetAllAreasAsync();
        Task AddToDoAsync(Procedimiento toDo);
        Task AddAreaAsync(Area area);
        Task UpdateToDoAsync(Procedimiento toDo);
        Task UpdateAreaAsync(Area area);
        Task DeleteToDoAsync(int id);
        //Enumerados
        Task<List<Enumerado>> GetAllEnumeradosAsync();



    }
}
