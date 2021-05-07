using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEquipPOO.ConsoleApp.Controlador;
using GestaoEquipPOO.ConsoleApp.Dominio;

namespace GestaoEquipPOO.ConsoleApp.Tela
{
    public class TelaEquipamento : TelaBase
    {
        private ControladorEquipamento controladorEquipamento;

        public TelaEquipamento(ControladorEquipamento controlador)
        {
            controladorEquipamento = controlador;
        }
        override public string ObterOpcao()
        {
            //apresenta as opções
            Console.Clear();
            Console.WriteLine("Digite 1 para inserir novo equipamento");
            Console.WriteLine("Digite 2 para visualizar equipamentos");
            Console.WriteLine("Digite 3 para editar um equipamento");
            Console.WriteLine("Digite 4 para excluir um equipamento");
            Console.WriteLine("Digite 5 para mostrar um historico de chamados");

            Console.WriteLine("Digite S para sair");

            //solicita qual opção
            string opcao = Console.ReadLine();

            return opcao;
        }

        override public void Registrar(int id)
        {
            Console.Clear();

            string resultadoValidacao = "";

            do
            {
                string nome = ObterInputString("Digite o nome do equipamento: ");

                double preco = ObterInputDouble("Digite o preço do equipamento: ");

                string numeroSerie = ObterInputString("Digite o número do equipamento: ");

                DateTime dataFabricacao = ObterInputDateTime("Digite a data de fabricação do equipamento: ");

                string fabricante = ObterInputString("Digite o fabricante do equipamento: ");

                resultadoValidacao = controladorEquipamento.Registrar(
                    id, nome, preco, numeroSerie, dataFabricacao, fabricante);

                if (resultadoValidacao != "EQUIPAMENTO_VALIDO")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(resultadoValidacao);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Registro gravado com sucesso!");
                }

                Console.ReadLine();
                Console.Clear();
                Console.ResetColor();

            } while (resultadoValidacao != "EQUIPAMENTO_VALIDO");
        }

        override public void Visualizar()
        {
            Console.Clear();

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Equipamento[] equipamentos = controladorEquipamento.SelecionarTodosEquipamentos();

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Console.Write(configuracaColunasTabela,
                   equipamentos[i].id, equipamentos[i].nome, equipamentos[i].fabricante);

                Console.WriteLine();
            }

            if (equipamentos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum equipamento cadastrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        override public void Editar()
        {
            //visualiza os equipamentos
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual equipamento atualizar
            int idSelecionado = ObterInputInt("Digite o número do equipamento que deseja editar: ");

            //atualiza o equipamento
            Registrar(idSelecionado);
        }

        override public void Excluir()
        {
            //visualização dos equipamentos
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual equipamento excluir
            int idSelecionado = ObterInputInt("Digite o número do equipamento que deseja excluir: ");

            bool conseguiuExcluir = controladorEquipamento.Excluir(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Registro excluído com sucesso");
                Console.ReadLine();
            }
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome", "Fabricante");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        override public void Historico()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual equipamento excluir
            int idSelecionado = ObterInputInt("Digite o número do equipamento: ");

            for (int i = 0; i < 10; i++)
            {
                if (controladorEquipamento.SelecionarEquipamentoPorId(idSelecionado).historicoChamados[i] != null)
                {
                    Console.WriteLine(controladorEquipamento.SelecionarEquipamentoPorId(idSelecionado).historicoChamados[i].id);
                    Console.WriteLine(controladorEquipamento.SelecionarEquipamentoPorId(idSelecionado).historicoChamados[i].titulo);
                    Console.WriteLine("---------------------------------------");
                }
            }

            Console.ReadLine();
        }

    }
}
