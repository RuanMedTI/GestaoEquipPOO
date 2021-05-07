using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipPOO.ConsoleApp.Dominio
{
    public class Chamado : DominioBase
    {
        public string titulo;
        public string descricao;
        public DateTime dataAbertura;
        public Equipamento equipamento;

        public Chamado()
        {
            id = GeradorId.GerarIdChamado();
        }

        public Chamado(int id)
        {
            this.id = id;
        }

        public string DiasEmAberto
        {
            get
            {
                TimeSpan diasEmAberto = DateTime.Now - dataAbertura;

                return diasEmAberto.ToString("dd");
            }
        }

        public override bool Equals(object obj)
        {
            Chamado c = (Chamado)obj;

            if (c != null && c.id == this.id)
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
