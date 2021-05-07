using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEquipPOO.ConsoleApp.Dominio;

namespace GestaoEquipPOO.ConsoleApp.Controlador
{
    public class ControladorSolicitante : ControladorBase
    {
        public ControladorSolicitante(int capacidade_registros) : base(capacidade_registros) { }

        public string Registrar(int id, string nomeSolicitante, string  emailSolicitante, double numeroTel)
        {
            Solicitante solicitante = null;

            int posicao = 0;

            if (id == 0)
            {
                solicitante = new Solicitante();
                posicao = ObterPosicaoVazia();
            }

            else
            {
                posicao = ObterPosicaoOcupadaPorId(id);
                solicitante = (Solicitante)registros[posicao];
            }

            solicitante.nomeSolicitante = nomeSolicitante;
            solicitante.emailSolicitante = emailSolicitante;
            solicitante.numeroTel = numeroTel;

            string resultadoValidacao = solicitante.Validar();

            if (resultadoValidacao == "SOLICITANTE_VALIDO")
                registros[posicao] = solicitante;

            return resultadoValidacao;
        }

        public bool Excluir(int idSelecionado)
        {
            return ExcluirRegistro(new Solicitante(idSelecionado));
        }

        public Solicitante SelecionarSolicitantePorId(int id)
        {
            return (Solicitante)SelecionarRegistro(new Solicitante(id));
        }

        public Solicitante[] SelecionarTodosSolicitantes()
        {
            Solicitante[] aux = new Solicitante[QtdRegistrosCadastrados()];
            Array.Copy(SelecionarTodosRegistros(), aux, aux.Length);
            return aux;
        }

        protected int ObterPosicaoOcupadaPorId(int id)
        {
            int i = 0;

            foreach (object obj in registros)
            {
                if (obj is Solicitante)
                {
                    Solicitante e = (Solicitante)obj;
                    if (e.id == id)
                    {
                        return i;
                    }
                }
                i++;
            }
            return i;
        }
    }
}
