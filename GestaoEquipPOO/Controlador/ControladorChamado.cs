using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEquipPOO.ConsoleApp.Dominio;

namespace GestaoEquipPOO.ConsoleApp.Controlador
{
    public class ControladorChamado : ControladorBase
    {

        private ControladorEquipamento controladorEquipamento;
        private ControladorSolicitante controladorSolicitante;

        public ControladorChamado(int capacidadeRegistros, ControladorEquipamento controlador) : base(capacidadeRegistros)
        {
            controladorEquipamento = controlador;
        }

        public void Registrar(int idChamadoSelecionado, int idEquipamentoChamado, int idSolicitanteChamado,
            string titulo, string descricao, DateTime dataAbertura)
        {

            Chamado chamado = null;

            int posicao = 0;

            if (idChamadoSelecionado == 0)
            {
                chamado = new Chamado();
                posicao = ObterPosicaoVazia();
            }

            else
            {
                posicao = ObterPosicaoOcupadaPorId(idChamadoSelecionado);
                chamado = (Chamado)registros[posicao];
            }

            chamado.equipamento = controladorEquipamento.SelecionarEquipamentoPorId(idEquipamentoChamado);
            chamado.titulo = titulo;
            chamado.descricao = descricao;
            chamado.dataAbertura = dataAbertura;

            registros[posicao] = chamado;

            if (idChamadoSelecionado == 0)
            {
                Historico(chamado.equipamento, chamado);
            }
           
        }

        private int ObterPosicaoOcupadaPorId(int idChamadoSelecionado)
        {
            int i = 0;

            foreach (object obj in registros)
            {
                if (obj is Chamado)
                {
                    Chamado c = (Chamado)obj;
                    if (c.id == idChamadoSelecionado)
                    {
                        return i;
                    }
                }
                i++;
            }
            return i;
        }

        private void Historico(Equipamento equipamento, Chamado novoChamado)
        {
            equipamento.historicoChamados[controladorEquipamento.PosicaoHistorico(equipamento)] = novoChamado;
        }

        public bool Excluir(int idSelecionado)
        {
            return ExcluirRegistro(new Chamado(idSelecionado));
        }

        public Chamado SelecionarChamadoPorId(int id)
        {
            return (Chamado)SelecionarRegistro(new Chamado(id));
        }

        public Chamado[] SelecionarTodosChamados()
        {
            Chamado[] aux = new Chamado[QtdRegistrosCadastrados()];
            Array.Copy(SelecionarTodosRegistros(), aux, aux.Length);
            return aux;
        }
    }
}
