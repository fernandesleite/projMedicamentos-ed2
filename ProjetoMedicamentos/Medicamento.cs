using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamentos
{
    class Medicamento
    {
        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Laboratorio
        {
            get { return laboratorio; }
            set { laboratorio = value; }
        }

        public Queue<Lote> Lotes
        {
            get { return lotes; }
            set { lotes = value; }
        }

        public Medicamento()
        {
            Lotes = new Queue<Lote>();
        }
        public Medicamento(int id, string nome, string laboratorio)
        {
            this.Id = id;
            this.Laboratorio = laboratorio;
            this.Nome = nome;
            Lotes = new Queue<Lote>();
        }
        public int qtdeDisponivel()
        {
            int dispon = 0;
            foreach (Lote lote in Lotes)
            {
                dispon += lote.Qtde;
            }
            return dispon;

        }
        public void comprar(Lote lote)
        {
            Lotes.Enqueue(lote);
        }
        public bool vender(int qtde)
        {

            if (qtdeDisponivel() >= qtde)
            {
                
                while (qtde > 0)
                {
                    if(qtde > lotes.Peek().Qtde)
                    {
                        qtde -= lotes.Peek().Qtde;
                        lotes.Dequeue();
                    }
                    else
                    {
                        lotes.Peek().Qtde -= qtde;
                        break;
                    }
                }
                return true;
            }
            return false;

        }
        public override string ToString()
        {
            return "ID:" + id + " \nNome: " + nome + " \nLaboratorio: " + laboratorio + " \nQuantidade: " + qtdeDisponivel();
        }
        public override bool Equals(object obj)
        {
            return ((Medicamento)obj).id.Equals(this.id);
        }
    }
}
