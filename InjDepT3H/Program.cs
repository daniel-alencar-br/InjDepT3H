using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjDepT3H
{
    // S(ingle Responsability)   OLID

    public interface IBanco   // definições de um BANCO
    {
        string Agencia { get; set; }
        string Conta { get; set; }
        void Conectar();
    }

    public interface IBancoTokenGov   
    {
        string TokenGov { get; set; }
    }

    public class BancodoBrasil : IBanco, IBancoTokenGov
    {
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string TokenGov { get; set; }
        public void Conectar()
        {
            //
        }
    }

    public class Bradesco : IBanco
    {
        public Bradesco(string Age)
        {
            this.Agencia = Age;
        }

        public Bradesco(string Age, string Cnt)
        {
            this.Agencia = Age;
            this.Conta = Cnt;
        }

        public string Agencia { get; set; }
        public string Conta { get; set; }
        public void Conectar()
        {
            //
        }
    }

    public class Santander : IBanco
    {
        public Santander(string Age, string Cnt)
        {
            this.Agencia = Age;
            this.Conta = Cnt;
        }

        public string Agencia { get; set; }
        public string Conta { get; set; }
        public void Conectar()
        {
            //
        }
    }

    public class ModuloPagamento
    {
        private IBanco MeuBanco;

        public ModuloPagamento(IBanco InfoBanco)
        {
            MeuBanco = InfoBanco;
        }

        public void EnviarPix(string Chave, double valor)
        {
            if (MeuBanco is IBancoTokenGov)
            {
                ((IBancoTokenGov)MeuBanco).TokenGov = "123sdf";
            }

            MeuBanco.Conectar();

            Console.WriteLine("Pix enviado...");
        }
    }

    class Program
    {        
        static void Main(string[] args)
        {
            Bradesco Meubanco = new Bradesco("123", "45456");

            Bradesco MeuBanco2 = new Bradesco("123");
            MeuBanco2.Conta = "32324";

            ModuloPagamento Pagar = new ModuloPagamento(Meubanco);
            Pagar.EnviarPix("sdsdsdf", 100);

        }

    }
}



