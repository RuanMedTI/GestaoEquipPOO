using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEquipPOO.ConsoleApp.Tela;
using GestaoEquipPOO.ConsoleApp.Controlador;

namespace GestaoEquipPOO.ConsoleApp
{
    class Program
    {
        const int CAPACIDADE_REGISTROS = 100;

        static void Main(string[] args)
        {
            /*ControladorEquipamento controladorEquipamento = new ControladorEquipamento();
            TelaEquipamento telaEquipamento = new TelaEquipamento(controladorEquipamento);
            ControladorChamado controladorChamado = new ControladorChamado(CAPACIDADE_REGISTROS, controladorEquipamento);
            TelaChamado telaChamado = new TelaChamado(telaEquipamento, controladorChamado);*/

            TelaBase telaBase = new TelaBase();

            Console.Clear();

            while (true)
            {

                TelaBase tela = (TelaBase)telaBase.ObterTela();


                if (tela == null)
                {
                    break;
                }

                string opcao = tela.ObterOpcao();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;

                Console.Clear();

                if (opcao == "1")
                    tela.Registrar(0);

                else if (opcao == "2")
                    tela.Visualizar();

                else if (opcao == "3")
                    tela.Editar();

                else if (opcao == "4")
                    tela.Excluir();

                else if (opcao == "5")
                    tela.Historico();

                Console.Clear();
            }
        }
    }
}


