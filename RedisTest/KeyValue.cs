using System;
using System.Collections.Generic;
using System.Linq;

namespace RedisTest
{
    class KeyValue
    {
        private Dictionary<string, string> mapCampos;
        private List<string> chavesList;
        private List<Dictionary<string, string>> indexadorList;

        readonly IList<Locadora.Cliente> clientesList;
        private readonly Locadora.Cliente Cliente;

    
        readonly IList<Locadora.Filme> filmesList;
        private readonly Locadora.Filme Filme;

        readonly IList<Locadora.Categoria>  categoriasList;
        private readonly Locadora.Categoria Categoria;

        readonly IList<Locadora.Locacao> locacaoList;
        private readonly Locadora.Locacao Locacao;

        //Construtor
        public KeyValue()
        {

            this.mapCampos = new Dictionary<string, string>();

            this.Cliente = new Locadora.Cliente();
            this.clientesList = Cliente.SeedCliente();

            this.Categoria = new Locadora.Categoria();
            this.categoriasList = Categoria.SeedCategoria();

            this.Filme = new Locadora.Filme();
            this.filmesList = Filme.SeedFilme();

            this.Locacao = new Locadora.Locacao();
            this.locacaoList = this.Locacao.SeedLocacao();

        }

        //CLIENTES

        public IList<Locadora.Cliente> GetClientes
        {
            get { return clientesList; }
        }


        public List<string> GeraChaveCliente()
        {
            return clientesList.Select(c => String.Format("Cliente:{0}", c.CodCliente)).ToList();
        }

       

        public List<Dictionary<string, string>> GeraCamposCliente()
        {
            indexadorList = new List<Dictionary<string, string>>();
            foreach (var cliente in this.clientesList)
            {
                mapCampos["Cliente:"] = cliente.NomeCliente;
                mapCampos["Data Nascimento:"] = cliente.DatNascimento;
                mapCampos["Sexo:"] = cliente.Sexo.ToString();
                indexadorList.Add(mapCampos);
                mapCampos = new Dictionary<string, string>();
            }
            return indexadorList;
        }

        //FILMES

        public IList<Locadora.Filme> GetFilmes
        {
            get{return filmesList;}
        }

        public List<Dictionary<string,string>> GeraCamposFilmes(){
            indexadorList = new List<Dictionary<string, string>>();
            foreach (var filme in this.filmesList)
            {
                mapCampos["Filme:"] = filme.NomeFilme;
                mapCampos["Data Compra:"] = filme.DataCompra;
                mapCampos["Valor Filme:"] = filme.ValorFilme.ToString();
                mapCampos["Indicacao Pais:"] = filme.IndPais.ToString();
                indexadorList.Add(mapCampos);
                mapCampos = new Dictionary<string, string>();
            }
            return indexadorList;
        }

        public List<string> GeraChaveFilme()
        {
            return filmesList.Select(f => String.Format("Filme:{0}", f.CodFilme)).ToList();
        }

        //CATEGORIA
        public IList<Locadora.Categoria> GetCategorias
        {
            get { return categoriasList; }
        }

        public List<Dictionary<string, string>> GeraCamposCategorias()
        {
            indexadorList = new List<Dictionary<string, string>>();
            foreach (var categoria in this.categoriasList)
            {
                mapCampos["Descricao:"] = categoria.DescricaoCategoria;
                mapCampos["Valor Categoria:"] = categoria.ValorCategoria.ToString();
                indexadorList.Add(mapCampos);
                mapCampos = new Dictionary<string, string>();
            }
            return indexadorList;
        }

        public List<string> GeraChaveCategoria()
        {
            return categoriasList.Select(c => String.Format("Categoria:{0}", c.CodCategoria)).ToList();
        }

        //Locação
        public IList<Locadora.Locacao> GetLocacoes
        {
            get { return locacaoList; }
        }

        public List<Dictionary<string, string>> GeraCamposLocacao()
        {
            indexadorList = new List<Dictionary<string, string>>();
            foreach (var locacao in locacaoList)
            {
                mapCampos["Data Inicio:"] = locacao.DatInLocacao;
                mapCampos["Data Fim:"] = locacao.DatFimLocacao;
                mapCampos["Multa:"] = locacao.ValorMulta.ToString();
                mapCampos["Cliente:"] = locacao.CodCliente.ToString();
                mapCampos["Filme:"] = locacao.CodFilme.ToString();
                indexadorList.Add(mapCampos);
                mapCampos = new Dictionary<string, string>();
            }
            return indexadorList;
        }

        public List<string> GeraChaveLocacao()
        {
            return locacaoList.Select(c => String.Format("Locacao:{0}", c.CodLocacao)).ToList();
        }

    }
}
