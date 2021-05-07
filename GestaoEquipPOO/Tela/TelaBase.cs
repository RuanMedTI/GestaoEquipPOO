using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEquipPOO.ConsoleApp.Tela;
using GestaoEquipPOO.ConsoleApp.Controlador;

namespace GestaoEquipPOO.ConsoleApp.Tela
{
    public class TelaBase
    {
        const int CAPACIDADE_REGISTROS = 100;

        static ControladorEquipamento controladorEquipamento = new ControladorEquipamento(CAPACIDADE_REGISTROS);
        static ControladorSolicitante controladorSolicitante = new ControladorSolicitante(CAPACIDADE_REGISTROS);
        static TelaEquipamento telaEquipamento = new TelaEquipamento(controladorEquipamento);
        static TelaSolicitante telaSolicitante = new TelaSolicitante(controladorSolicitante);
        static ControladorChamado controladorChamado = new ControladorChamado(CAPACIDADE_REGISTROS, controladorEquipamento);
        static TelaChamado telaChamado = new TelaChamado(telaEquipamento, controladorChamado, telaSolicitante);

        public virtual object ObterTela()
        {
            string opcao = "";
            do
            {
                Console.Clear();
                //CRUD (Create, Retrieve, Update, Delete)
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("Digite 1 para o Cadastro de Equipamentos");
                Console.WriteLine("Digite 2 para o Controle de Chamados");
                Console.WriteLine("Digite 3 para o Cadastro de Solicitantes");

                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    TelaEquipamento tela = telaEquipamento;
                    return tela;
                }

                if (opcao == "2")
                {
                    TelaChamado tela = telaChamado;
                    return tela;
                }
                if (opcao == "3")
                {
                    TelaSolicitante tela = telaSolicitante;
                    return tela;
                }

            } while (OpcaoInvalida(opcao));

            return null;
        }

        private bool OpcaoInvalida(string opcao)
        {
            if (opcao == "s" || opcao == "S" || opcao == "1" || opcao == "2" || opcao == "3")
            {
                return false;
            }
            return true;
        }

        public virtual void Historico()
        {

        }

        public virtual string ObterOpcao()
        {
            return "";
        }

        public int ObterInputInt(string mensagem)
        {
            int n;
            Console.Write(mensagem);
            Int32.TryParse(Console.ReadLine(), out n);
            return n;
        }

        public string ObterInputString(string mensagem)
        {
            string s;
            Console.Write(mensagem);
            s = Console.ReadLine();
            return s;
        }

        public double ObterInputDouble(string mensagem)
        {
            double d;
            Console.Write(mensagem);
            double.TryParse(Console.ReadLine(), out d);
            return d;

        }

        public DateTime ObterInputDateTime(string mensagem)
        {
            DateTime d = new DateTime();
            Console.Write(mensagem);
            DateTime.TryParse(Console.ReadLine(), out d);
            return d;
        }

        public virtual void Registrar(int id)
        {

        }

        public virtual void Excluir()
        {

        }

        public virtual void Visualizar()
        {

        }

        public virtual void Editar()
        {

        }
    }

}
