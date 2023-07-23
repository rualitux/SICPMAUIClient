﻿using System;
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
        Task<List<BienPatrimonial>> GetAllBienesAsync();
        Task<List<Inventario>> GetAllInventariosAsync();
        Task AddToDoAsync(Procedimiento toDo);
        Task AddAreaAsync(Area area);
        Task<BienPatrimonial> AddBienAsync(BienPatrimonial bienPatrimonial);
        Task<Inventario> AddInventarioAsync(Inventario inventario);
        Task<BienProcedimientoAltaRetorno> AddBienProcedimientoAlta(BienProcedimientoAlta bienProcedimientoAlta);
        Task UpdateToDoAsync(Procedimiento toDo);
        Task UpdateAreaAsync(Area area);
        Task UpdateBienAsync(BienPatrimonial bienPatrimonial);
        Task UpdateInventarioAsync(Inventario inventario);
        Task DeleteToDoAsync(int id);
        //Enumerados
        Task<List<Enumerado>> GetAllEnumeradosAsync();



    }
}
