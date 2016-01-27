using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceStack;

namespace RedisTest
{
    class SerializationJson
    {
        KeyValue keyValue;


        List<string> chavesClienteList;
        //List<Dictionary<string, string>> camposClienteList;
        //Lista de objetos sem tratamento (separaçao de chave - Valor)
        IList<Locadora.Cliente> clientesList;
        IList<Locadora.Categoria> categoriasList;
        IList<Locadora.Filme> filmesList;
        IList<Locadora.Locacao> locacaoList;

        public SerializationJson(KeyValue KeyValue)
        {
            this.keyValue = KeyValue;

            this.clientesList = keyValue.GetClientes;
            this.categoriasList = KeyValue.GetCategorias;
            this.filmesList = KeyValue.GetFilmes;
            this.locacaoList = KeyValue.GetLocacoes;


        }

        public void ConvertJson()
        {
            
            //Clientes
            string clientes = JsonConvert.SerializeObject(clientesList, Formatting.Indented);
            using (Stream arquivo = File.Open(@"C:\Users\henri\OneDrive\Documentos\Visual Studio 2015\Projects\RedisTest\RedisTest\Arquivos\clientes.txt", FileMode.Open))
            {
                StreamWriter escritor = new StreamWriter(arquivo);
                escritor.WriteLine(clientes);
            }

            //Categoria
            string categorias = JsonConvert.SerializeObject(categoriasList, Formatting.Indented);
            Stream saida = File.Open(@"C:\Users\henri\OneDrive\Documentos\Visual Studio 2015\Projects\RedisTest\RedisTest\Arquivos\categorias.txt", FileMode.OpenOrCreate);
            StreamWriter pepeca = new StreamWriter(saida);
            pepeca.WriteLine(categorias);
            pepeca.Close();
            saida.Close();

            //Filmes
            string filmes = JsonConvert.SerializeObject(filmesList, Formatting.Indented);
            using (Stream arquivo = File.Open(@"C:\Users\henri\OneDrive\Documentos\Visual Studio 2015\Projects\RedisTest\RedisTest\Arquivos\filmes.txt", FileMode.Open))
            {
                StreamWriter escritor = new StreamWriter(arquivo);
                escritor.WriteLine(filmes);
            }

            //Locação
            string locacoes = JsonConvert.SerializeObject(locacaoList, Formatting.Indented);
            using (Stream arquivo = File.Open(@"C:\Users\henri\OneDrive\Documentos\Visual Studio 2015\Projects\RedisTest\RedisTest\Arquivos\locacoes.txt", FileMode.Open))
            {
                StreamWriter escritor = new StreamWriter(arquivo);
                escritor.WriteLine(locacoes);
            }
        }

        public void ConvertString()
        {
            //string clientes = "";
            //string filmes = "";
            //string categorias = "";
            //string locacoes = "";

            //Clientes
            Stream saida = File.Open(@"C:\Users\henri\OneDrive\Documentos\Visual Studio 2015\Projects\RedisTest\RedisTest\Arquivos\clientes.csv", FileMode.OpenOrCreate);
            StreamWriter escritor = new StreamWriter(saida);
            foreach (var item in clientesList)
            {
                escritor.Write(item.CodCliente + "," + item.DatNascimento + "," + item.NomeCliente + "," + item.Sexo + "\r\n");
            }
            //GravaArquivo("clientes.csv", clientes);
            escritor.Close();
            saida.Close();

            //Categoria
            saida = File.Open(@"C:\Users\henri\OneDrive\Documentos\Visual Studio 2015\Projects\RedisTest\RedisTest\Arquivos\categorias.csv", FileMode.OpenOrCreate);
            escritor = new StreamWriter(saida);
            foreach (var item in categoriasList)
            {
                escritor.Write(item.CodCategoria + "," + item.DescricaoCategoria + "," + item.ValorCategoria + "\r\n");
            }
            //GravaArquivo("categorias.csv", categorias);
            escritor.Close();
            saida.Close();

            //Filmes
            saida = File.Open(@"C:\Users\henri\OneDrive\Documentos\Visual Studio 2015\Projects\RedisTest\RedisTest\Arquivos\filmes.csv", FileMode.OpenOrCreate);
            escritor = new StreamWriter(saida);
            foreach (var item in filmesList)
            {
                escritor.Write(item.CodFilme + "," + item.NomeFilme + "," + item.DataCompra + "," + item.ValorFilme + "," + item.IndPais + "," + item.CodCategoria + "\r\n");
            }
            //GravaArquivo("filmes.csv", filmes);
            escritor.Close();
            saida.Close();

            //Locacoes
            saida = File.Open(@"C:\Users\henri\OneDrive\Documentos\Visual Studio 2015\Projects\RedisTest\RedisTest\Arquivos\locacoes.csv", FileMode.OpenOrCreate);
            escritor = new StreamWriter(saida);
            foreach (var item in locacaoList)
            {
                escritor.Write(item.CodLocacao + "," + item.DatInLocacao + "," + item.DatFimLocacao + "," + item.ValorMulta + "," + item.CodCliente + "," + item.CodFilme + "\r\n");
            }
            //GravaArquivo("locacoes.csv", locacoes);
            escritor.Close();
            saida.Close();

            //string.Join(" ", item.CodFilmes.ToArray()
        }
        private void GravaArquivo(string arquivo, string info)
        {
            //Ou@"C:\Users\henri\OneDrive\Documentos\Visual Studio 2015\Projects\RedisTest\RedisTest\Arquivos string.Join(" ", item.CodFilmes)
            string endereco = @"C:\Users\henri\OneDrive\Documentos\Visual Studio 2015\Projects\RedisTest\RedisTest\Arquivos\";
            string destinoArquivo = System.IO.Path.Combine(endereco, arquivo);  

            Stream saida = File.Open(destinoArquivo, FileMode.OpenOrCreate);
            StreamWriter escritor = new StreamWriter(saida);
            escritor.WriteLine(info);
            escritor.Close();
            saida.Close();
        }

    }
}
