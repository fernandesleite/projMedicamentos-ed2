using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamentos
{
    class Program
    {
        public static Medicamentos medicamento = new Medicamentos();
        private static Medicamento medicamentoConsulta = new Medicamento();

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                mostrarMenu();
                opcao = int.Parse(Console.ReadLine());
                if(opcao > 6)
                {
                    Console.WriteLine("Opcao invalida!\n");
                }
                    try
                    {
                        switch (opcao)
                        {
                            case 0:
                                break;
                            case 1:
                                cadastrarMedicamento();
                                break;
                            case 2:
                                consultarSintetico();
                                break;
                            case 3:
                                consultarAnalitico();
                                break;
                            case 4:
                                comprarMedicamento();
                                break;
                            case 5:
                                venderMedicamento();
                                break;
                            case 6:
                                listarMedicamento();
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERRO: {0}", e);
                    }

            } while (opcao != 0);
        }
        private static void mostrarMenu()
        {
            Console.WriteLine("*---------------------------------------*");
            Console.WriteLine("0. Finalizar processo");
            Console.WriteLine("1. Cadastrar medicamento ");
            Console.WriteLine("2. Consultar medicamento (Sintetico) ");
            Console.WriteLine("3. Consultar medicamento (analítico)");
            Console.WriteLine("4. Comprar medicamento");
            Console.WriteLine("5. Vender medicamento");
            Console.WriteLine("6. Listar medicamentos");
            Console.WriteLine("*---------------------------------------*");
            Console.Write("Opção: ");
        }
        private static void cadastrarMedicamento()
        {
            Console.Write("Digite o ID: ");
            int medicamentoId = int.Parse(Console.ReadLine());
            Console.Write("Nome do medicamento: ");
            String medicamentoNome = Console.ReadLine();
            Console.Write("Nome do laboratório: ");
            String medicamentoLab = Console.ReadLine();
            Medicamento m1 = new Medicamento(medicamentoId, medicamentoNome, medicamentoLab);
            medicamento.adicionar(m1);
            Console.WriteLine("\n**Dados Inseridos**\n");
        }
        private static void consultarSintetico()
        {
            Console.Write("Digite o ID: ");
            medicamentoConsulta = pesquisar(int.Parse(Console.ReadLine()));
            if (medicamentoConsulta.Id == 0)
            {
                Console.WriteLine("Medicamento não encontrado");
            }
            else
            {
                Console.WriteLine(medicamentoConsulta.ToString());
            }
        }
        private static void consultarAnalitico()
        {
            Console.Write("Digite o ID: ");
            medicamentoConsulta = pesquisar(int.Parse(Console.ReadLine()));
            if (medicamentoConsulta.Id == 0)
            {
                Console.WriteLine("Medicamento não encontrado");
            }
            else
            {
                Console.WriteLine(medicamentoConsulta.ToString());
            }
            foreach (Lote lote in medicamentoConsulta.Lotes)
            {
                Console.WriteLine(lote.ToString());
            }
        }
        private static void comprarMedicamento()
        {
           int loteId = 0, quantidade = 0;
            DateTime venc = DateTime.Now;
            Console.Write("Digite o ID: ");
            medicamentoConsulta = pesquisar(int.Parse(Console.ReadLine()));
            if (medicamentoConsulta.Id == 0)
                Console.WriteLine("medicamento não encontrado: ");
            else
            {
                Console.WriteLine("Informações do lote ");

                Console.WriteLine("ID do Lote: ");
                loteId = int.Parse(Console.ReadLine());
                do
                {
                    Console.WriteLine("Quantidade de Medicamentos: ");
                    quantidade = int.Parse(Console.ReadLine());
                } while (loteId < 0);
                Console.WriteLine("data de vencimento (DD/MM/AAAA)");
                venc = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("\n**Compra realizada com sucesso!!!**\n");
            }

            Lote nLote = new Lote(loteId, quantidade, venc);
            medicamentoConsulta.comprar(nLote);
        }
        private static void venderMedicamento()
        {
            int loteId = 0, quantidade = 0;
            Console.Write("Digite o Id: ");
            medicamentoConsulta = pesquisar(int.Parse(Console.ReadLine()));
            if (medicamentoConsulta.Id == 0)
                Console.WriteLine("Medicamento não encontrado");
            else
            {
                do
                {
                    Console.Write("Quantidade de medicamentos: ");
                    quantidade = int.Parse(Console.ReadLine());
                    if (loteId < 0)
                        Console.WriteLine("A quantidade precisa ser numeros positivos");
                } while (loteId < 0);
                medicamentoConsulta.vender(quantidade);
                Console.WriteLine("\n**Medicamento vendido!!**\n");
            }
        }
        private static void listarMedicamento()
        {
            foreach (Medicamento m in medicamento.ListaMedicamentos)
            {
                Console.WriteLine(m.ToString());
            }
        }
        private static Medicamento pesquisar(int medicamentoId)
        {
            Medicamento medicamentoPesquisa = new Medicamento();
            medicamentoPesquisa.Id = medicamentoId;
            return medicamento.pesquisar(medicamentoPesquisa);
        }
    }
}
