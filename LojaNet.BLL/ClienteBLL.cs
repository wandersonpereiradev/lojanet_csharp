using System;
using System.Collections.Generic;
using System.Text;
using LojaNet.Models;
using LojaNet.DAL;

namespace LojaNet.BLL
{
    // Business Logic Layer
    public class ClienteBLL : IClienteDados
    {
        private ClienteDAL dal;

        public ClienteBLL()
        {
            this.dal = new ClienteDAL();
        }
        public void Alterar(Cliente cliente)
        {
            Validar(cliente);
            if (string.IsNullOrEmpty(cliente.Id))
            {
                throw new Exception("O ID deve ser informado");
            }
            dal.Alterar(cliente);
        }

        public void Excluir(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new Exception("O ID deve ser informado");
            }
            dal.Excluir(Id);
        }

        public void Incluir(Cliente cliente)
        {
            Validar(cliente);
            if (string.IsNullOrEmpty(cliente.Id))
            {
                // Criando o ID dinamicamente
                cliente.Id = Guid.NewGuid().ToString();
            }

            dal.Incluir(cliente);
        }

        private static void Validar(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                throw new ApplicationException("O nome deve ser informado");
            }
        }

        public Cliente ObterPorEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorId(string Id)
        {
            return dal.ObterPorId(Id);
        }

        public List<Cliente> ObterTodos()
        {
            var lista = dal.ObterTodos();
            return lista;
        }
    }
}
