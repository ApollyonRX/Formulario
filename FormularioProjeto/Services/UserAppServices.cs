using AutoMapper;
using FormularioProjeto.Models;
using FormularioProjeto.Models.ContaViewModels;
using FormularioProjeto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormularioProjeto.Services
{
    public class UserAppServices : IUserAppServices
    {
        private readonly IUserAppServices _userAppServices;
        private readonly IMapper _mapper;

        public UserAppServices(IUserAppServices userAppServices, IMapper mapper)
        {
            _userAppServices = userAppServices;
            _mapper = mapper;
        }

        public void Adicionar(RegistrarViewModel obj)
        {
            _userAppServices.Adicionar(_mapper.Map<RegistrarViewModel>(obj));
        }

        public void Atualizar(RegistrarViewModel obj)
        {
            _userAppServices.Atualizar(_mapper.Map<RegistrarViewModel>(obj));
        }

        public void Deletar(Guid id)
        {
            _userAppServices.Deletar(id);
        }
    }
}
