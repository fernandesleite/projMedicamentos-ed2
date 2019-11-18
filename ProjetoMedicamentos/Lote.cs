using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamentos
{
    class Lote
    {
        private int id;
        private int qtde;
        private DateTime venc;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Qtde
        {
            get { return qtde; }
            set { qtde = value; }
        }

        public DateTime Venc
        {
            get { return venc; }
            set { venc = value; }
        }
        public Lote()
        {
        }
        public Lote(int id, int qtde, DateTime venc)
        {
            this.id = id;
            this.qtde = qtde;
            this.venc = venc;
        }
        public override string ToString()
        {
            return this.id.ToString() + " " +
                this.qtde.ToString() + " " +
                this.venc.ToShortDateString();
        }
    }
}
