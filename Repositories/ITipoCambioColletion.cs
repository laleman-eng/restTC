using restTC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restTC.Repositories
{
    public interface ITipoCambioColletion
    {
        Task InsertarTipoCambio(TipoCambio tipoCambio);

        Task UpdateTipoCambio(TipoCambio tipoCambio);

        Task <List<TipoCambio>> GetAllTipoCambio();

        Task<List<TipoCambio>> GetTipoCambioByDate(string date);

        Task<TipoCambio> GetTipoCambioById(string id);

        Task<TipoCambio> GetTipoCambio(TipoCambio tipo);

        Task DeleteTipoCambio(string id);

    }
}
