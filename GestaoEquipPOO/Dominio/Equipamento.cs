using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipPOO.ConsoleApp.Dominio
{
    public class Equipamento : DominioBase
    {
        public string nome;
        public double preco;
        public string numeroSerie;
        public DateTime dataFabricacao;
        public string fabricante;
        public Chamado[] historicoChamados;

        public Equipamento()
        {
            id = GeradorId.GerarIdEquipamento();
            historicoChamados = new Chamado[10];
        }

        public Equipamento(int id)
        {
            this.id = id;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "O campo Nome é obrigatório \n";

            if (nome.Length < 6)
                resultadoValidacao += "O campo Nome não pode ter menos de 6 letras \n";

            if (dataFabricacao == DateTime.MinValue)
                resultadoValidacao += "O campo Data de Fabricação está inválido \n";

            if (dataFabricacao > DateTime.Now)
                resultadoValidacao += "O campo Data de Fabricação não pode ser no futuro \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "EQUIPAMENTO_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Equipamento e = (Equipamento)obj;

            if (e != null && e.id == this.id)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
