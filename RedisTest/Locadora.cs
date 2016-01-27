using System;
using System.Collections.Generic;
using System.Data.Entity;
using FizzWare.NBuilder;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RedisTest
{
    public class Locadora
    {
        //Constante de teste
        private const int Tamanho = 100000;
        private const int Relacoes = 1500000;
        private static long CodCategoriaStatico;
        //100 mil
        public class Cliente
        {
            public long CodCliente { get; set; }
            public string NomeCliente { get; set; }
            public string DatNascimento { get; set; }
            public char Sexo { get; set; }

            public IList<Cliente> SeedCliente()
            {
                var dayRandom = new RandomGenerator();
                var sexoRandom = new Random();

                DateTime min = new DateTime(1940, 1, 1);
                DateTime max = new DateTime(2000, 12, 28);
                char[] sexo = { 'F', 'M' };

                var clientes = Builder<Cliente>.CreateListOfSize(Tamanho).All()
                            .With(c => c.DatNascimento = dayRandom.Next(min, max).ToString("dd-MM-yyyy"))
                            .With(c => c.NomeCliente = Faker.Name.FullName())
                            .With(c => c.Sexo = sexo[sexoRandom.Next(sexo.Length)]).Build();

                return clientes;
            }
        }
        //1.5 Milhoes de relções entre Cliente e Filme
        public class Locacao
        {
            public long CodLocacao { get; set; }
            public string DatInLocacao { get; set; }
            public string DatFimLocacao { get; set; }
            public float ValorMulta { get; set; }
            //"Relação" das tabelas
            public int CodCliente { get; set; }
            public int CodFilme { get; set; }
            //public int[] CodFilme { get; set; }
            public IList<Locacao> SeedLocacao()
            {
                var dayRandom = new RandomGenerator();
                Random valorRandom = new Random();
                
                DateTime min = new DateTime(2015, 1, 1);
                DateTime max = new DateTime(2015, 1, 28);

                var locacoes = Builder<Locacao>.CreateListOfSize(Relacoes).All()
                    .With(l => l.DatInLocacao = dayRandom.Next(min, max).ToString("dd-MM-yyyy"))
                    .With(l => l.DatFimLocacao = dayRandom.Next(min, max).ToString("dd-MM-yyyy"))
                    .With(l => l.ValorMulta = valorRandom.Next(0, 28))
                    .With(l => l.CodCliente = valorRandom.Next(1,Tamanho))
                    .With(l => l.CodFilme = valorRandom.Next(1,Tamanho)).Build();
                return locacoes;
            }
        }
        //100 mil registros
        public class Filme
        {
            public long CodFilme { get; set; }
            public string NomeFilme { get; set; }
            public string DataCompra { get; set; }
            public int ValorFilme { get; set; }
            public int IndPais { get; set; }
            public long CodCategoria { get; set; }


            public IList<Filme> SeedFilme()
            {
                var dayRandom = new RandomGenerator();
                Random valorRandom = new Random();
                DateTime min = new DateTime(1998, 1, 1);
                DateTime max = new DateTime(2015, 12, 28);

                var filmesList = Builder<Filme>.CreateListOfSize(Tamanho).All()
                          .With(f => f.NomeFilme = Faker.Lorem.Sentence())
                          .With(f => f.DataCompra = dayRandom.Next(min, max).ToString("dd-MM-yyyy"))
                          .With(f => f.ValorFilme = (valorRandom.Next(10,90)))
                          .With(f => f.IndPais = valorRandom.Next(1, 3))
                          .With(f => f.CodCategoria = dayRandom.Next(0,CodCategoriaStatico)).Build();
                return filmesList;

            }
        }
        //10 categorias
        public class Categoria
        {
            public long CodCategoria { get; set; }
            public string DescricaoCategoria { get; set; }
            public int ValorCategoria { get; set; }

            public IList<Categoria> SeedCategoria()
            {
                long cod = 0;
                string[] categorias = { "bronze", "bronze2", "prata", "prata2", "ouro", "ouro2", "lancamento", "lancamento2", "Super lancamento", "Super Lancamento2" };
                Random valorRandom = new Random();
                Categoria categoria = new Categoria();

                List<Categoria> categoriaList = new List<Categoria>();

                //var categoriaList = Builder<Categoria>.CreateListOfSize(10)
                foreach (var item in categorias)
                {
                    categoria.CodCategoria = cod;
                    categoria.DescricaoCategoria = item;
                    categoria.ValorCategoria = (valorRandom.Next(3,15));
                    cod++;
                    categoriaList.Add(categoria);
                    categoria = new Categoria();
                }
                CodCategoriaStatico = cod-1;
                return categoriaList;
            }
        }

        public class ApplicationDbContext : IdentityDbContext
        {
            public virtual IDbSet<Cliente> Clientes { get; set; }
            public virtual IDbSet<Locacao> Locacoes { get; set; }
            public virtual IDbSet<Filme> Filmes { get; set; }
            public virtual IDbSet<Categoria> Categorias { get; set; }

            //public ApplicationDbContext(): base("DefaultConnection", false) {}

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

        }

        
        
        

    }
}