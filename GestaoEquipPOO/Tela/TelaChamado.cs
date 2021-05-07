using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEquipPOO.ConsoleApp.Controlador;
using GestaoEquipPOO.ConsoleApp.Dominio;

namespace GestaoEquipPOO.ConsoleApp.Tela
{
    public class TelaChamado : TelaBase
    {
        private TelaEquipamento telaEquipamento;
        private TelaSolicitante telaSolicitante;
        private ControladorChamado controladorChamado;
        

        public TelaChamado(TelaEquipamento tela, ControladorChamado controlador, 
            TelaSolicitante tela1)
        {
            telaEquipamento = tela;
            telaSolicitante = tela1;
            controladorChamado = controlador;
        }

        override public string ObterOpcao()
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para inserir novo chamado");
            Console.WriteLine("Digite 2 para visualizar chamados");
            Console.WriteLine("Digite 3 para editar um chamado");
            Console.WriteLine("Digite 4 para excluir um chamado");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        override public void Registrar(int idChamadoSelecionado)
        {
            Console.Clear();

            Console.WriteLine("Visualização dos solicitantes cadastrados...");
            Console.ReadLine();

            telaSolicitante.Visualizar();

            Console.WriteLine("Agora a visualização dos equipamentos...");
            Console.ReadLine();

            telaEquipamento.Visualizar();        


            int idEquipamentoChamado = ObterInputInt("Digite o Id do equipamento para manutenção: ");
            int idSolicitanteChamado = ObterInputInt("Digite o Id do solicitante: ");
            string titulo = ObterInputString("Digite o titulo do chamado: ");
            string descricao = ObterInputString("Digite a descricao do chamado: ");
            DateTime dataAbertura = ObterInputDateTime("Digite a data de abertura do chamado: ");

            controladorChamado.Registrar(idChamadoSelecionado, idEquipamentoChamado, idSolicitanteChamado, titulo, descricao, dataAbertura);
        }
        override public void Visualizar()
        {
            Console.Clear();

            MontarCabecalhoTabela();

            Chamado[] chamados = controladorChamado.SelecionarTodosChamados();

            foreach (Chamado chamado in chamados)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25}",
                    chamado.id, chamado.equipamento.nome, chamado.titulo, chamado.DiasEmAberto);
            }

            if (chamados.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum chamado registrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        private static void MontarCabecalhoTabela()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25}", "Id", "Equipamento", "Título", "Dias em Aberto");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        override public void Editar()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            int idSelecionado = ObterInputInt("Digite o número do chamado que deseja editar: ");

            Registrar(idSelecionado);
        }

        override public void Excluir()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            int idSelecionado = ObterInputInt("Digite o número do chamado que deseja excluir: ");

            controladorChamado.Excluir(idSelecionado);
        }
    }
}
