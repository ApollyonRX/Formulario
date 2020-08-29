using FormularioProjeto.Models.ContaViewModels;
using FormularioProjeto.Models.EnviarContaViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormularioProjeto.Services.Interfaces
{
    public interface IUserAppServices
    {
        void Adicionar(RegistrarViewModel obj);
        void Atualizar(RegistrarViewModel obj);
        void Deletar(Guid id);
    }
}
