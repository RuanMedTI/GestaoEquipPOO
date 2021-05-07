using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEquipPOO.ConsoleApp.Controlador;
using GestaoEquipPOO.ConsoleApp.Dominio;

namespace GestaoEquipPOO.ConsoleApp.Tela
{
    public class TelaSolicitante : TelaBase
    {
        private ControladorSolicitante controladorSolicitante;

        public TelaSolicitante(ControladorSolicitante controlador)
        {
            controladorSolicitante = controlador;
        }
        override public string ObterOpcao()
        {
            //apresenta as opções
            Console.Clear();
            Console.WriteLine("Digite 1 para inserir novo solicitante");
            Console.WriteLine("Digite 2 para visualizar os solicitantes");
            Console.WriteLine("Digite 3 para editar um solicitante");
            Console.WriteLine("Digite 4 para excluir um solicitante");

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
                string nomeSolicitante = ObterInputString("Digite o nome do solicitante: ");

                string email = ObterInputString("Digite o e-mail do solicitante: ");

                double numeroTel = ObterInputDouble("Digite um número de telefone: ");

                resultadoValidacao = controladorSolicitante.Registrar(
                    id, nomeSolicitante, email, numeroTel);

                if (resultadoValidacao != "SOLICITANTE_VALIDO")
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

            } while (resultadoValidacao != "SOLICITANTE_VALIDO");
        }

        override public void Visualizar()
        {
            Console.Clear();

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35} | {3, -15}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Solicitante[] solicitantes = controladorSolicitante.SelecionarTodosSolicitantes();

            for (int i = 0; i < solicitantes.Length; i++)
            {
                Console.Write(configuracaColunasTabela,
                   solicitantes[i].id, solicitantes[i].nomeSolicitante, solicitantes[i].emailSolicitante,
                   solicitantes[i].numeroTel);

                Console.WriteLine();
            }

            if (solicitantes.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum solicitante cadastrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        override public void Editar()
        {
            //visualiza os solicitantes
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual solicitante irá atualizar
            int idSelecionado = ObterInputInt("Digite o número do solicitante que deseja editar: ");

            //atualiza o solicitante
            Registrar(idSelecionado);
        }

        override public void Excluir()
        {
            //visualização dos solicitantes
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual solicitante excluir
            int idSelecionado = ObterInputInt("Digite o número do equipamento que deseja excluir: ");

            bool conseguiuExcluir = controladorSolicitante.Excluir(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Registro excluído com sucesso");
                Console.ReadLine();
            }
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome", "E-mail", "Telefone");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

    }
}
