using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipPOO.ConsoleApp.Controlador
{
    public class ControladorBase
    {

        protected object[] registros = null;

        public ControladorBase(int n)
        {
            registros = new object[n];
        }

        protected bool ExcluirRegistro(object obj)
        {
            bool conseguiu = false;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj))
                {
                    registros[i] = null;
                    conseguiu = true;
                    break;
                }
            }

            return conseguiu;
        }

        protected object SelecionarRegistro(object obj)
        {
            foreach (var item in registros)
            {
                if (item.Equals(obj))
                {
                    return item;
                }
            }
            return null;
        }

        protected object[] SelecionarTodosRegistros()
        {
            return registros;
        }

        protected int QtdRegistrosCadastrados()
        {
            int numeroRegistrosCadastrados = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    numeroRegistrosCadastrados++;
                }
            }
            return numeroRegistrosCadastrados;
        }

        protected int ObterPosicaoVazia()
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                {
                    return i;
                }
            }
            return 0;
        }

        protected int ObterPosicaoOcupada(object obj)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == obj)
                {
                    return i;
                }
            }
            return 0;
        }



    }
}
