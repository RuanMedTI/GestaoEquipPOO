using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEquipPOO.ConsoleApp.Dominio;

namespace GestaoEquipPOO.ConsoleApp.Controlador
{
    public class ControladorEquipamento : ControladorBase
    {
        public ControladorEquipamento(int capacidade_registros) : base(capacidade_registros) { }

        public string Registrar(int id, string nome, double preco,
            string numeroSerie, DateTime dataFabricacao, string fabricante)
        {
            Equipamento equipamento = null;

            int posicao = 0;

            if (id == 0)
            {
                equipamento = new Equipamento();
                posicao = ObterPosicaoVazia();
            }

            else
            {
                posicao = ObterPosicaoOcupadaPorId(id);
                equipamento = (Equipamento)registros[posicao];
            }

            equipamento.nome = nome;
            equipamento.preco = preco;
            equipamento.numeroSerie = numeroSerie;
            equipamento.dataFabricacao = dataFabricacao;
            equipamento.fabricante = fabricante;



            string resultadoValidacao = equipamento.Validar();

            if (resultadoValidacao == "EQUIPAMENTO_VALIDO")
                registros[posicao] = equipamento;

            return resultadoValidacao;
        }

        public bool Excluir(int idSelecionado)
        {
            return ExcluirRegistro(new Equipamento(idSelecionado));
        }

        public Equipamento SelecionarEquipamentoPorId(int id)
        {
            return (Equipamento)SelecionarRegistro(new Equipamento(id));
        }

        public Equipamento[] SelecionarTodosEquipamentos()
        {
            Equipamento[] aux = new Equipamento[QtdRegistrosCadastrados()];
            Array.Copy(SelecionarTodosRegistros(), aux, aux.Length);
            return aux;
        }

        public int PosicaoHistorico(Equipamento equipamento)
        {
            int i = 0;

            foreach (object obj in registros)
            {
                if (obj is Equipamento)
                {
                    Equipamento e = (Equipamento)obj;
                    if (e.id == equipamento.id)
                    {
                        while (e.historicoChamados[i] != null)
                        {
                            i++;
                        }
                    }
                }
            }
            return i;
        }

        protected int ObterPosicaoOcupadaPorId(int id)
        {
            int i = 0;

            foreach (object obj in registros)
            {
                if (obj is Equipamento)
                {
                    Equipamento e = (Equipamento)obj;
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
