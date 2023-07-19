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
        Task AddToDoAsync(Procedimiento toDo);
        Task UpdateToDoAsync(Procedimiento toDo);
        Task DeleteToDoAsync(int id);
        //Enumerados
        Task<List<Enumerado>> GetAllEnumeradosAsync();



    }
}
