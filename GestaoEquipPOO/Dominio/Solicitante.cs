using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipPOO.ConsoleApp.Dominio
{
    public class Solicitante : DominioBase
    {
        public string nomeSolicitante;
        public string emailSolicitante;
        public double numeroTel;
        
        public Solicitante()
        {
            id = GeradorId.GerarIdSolicitante();
        }

        public Solicitante(int id)
        {
            this.id = id;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nomeSolicitante))
                resultadoValidacao += "O campo Nome é obrigatório \n";

            if (nomeSolicitante.Length < 6)
                resultadoValidacao += "O campo Nome não pode ter menos de 6 letras \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "SOLICITANTE_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Solicitante c = (Solicitante)obj;

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
