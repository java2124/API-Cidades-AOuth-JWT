using Projeto2WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto2WebAPI.Services
{
    public class FuncionariosAutenticacao //classe responsável pela autenticação dos usuários
    {
        public static FuncionariosSistema Login(String login, string senha)
        {
            /*using (meuBanco db = new meuBanco())   //retorna booleano
            {
                return db.funcionarios.Any(user => user.Login.Equals(login, StringComparison.OrdinalIgnoreCase) && user.Senha == senha); //validando login, se há login e senha compátiveis no banco
            }*/

            using (meuBanco db = new meuBanco()) //retorna objeto
            {
                return db.funcionarios.FirstOrDefault(user => user.Login.Equals(login, StringComparison.OrdinalIgnoreCase) && user.Senha == senha); //validando login, se há login e senha compátiveis no banco
            }
        }

    }
}