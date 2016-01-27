using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.Redis;


namespace RedisTest
{
    class ProgramServiceStack
    {
        //static PooledRedisClientManager pooledClientManager = new PooledRedisClientManager("localhost");
        static void Main(string[] args)
        {
            
            using (var clienteRedis = new RedisClient("localhost",6379))
            //using (clienteRedis)
            {
                clienteRedis.ConnectTimeout = 5000;
                
                ServiceStack.Licensing.RegisterLicense(@"TRIAL30SANTANA - e1JlZjpUUklBTDMwU0FOVEFOQSxOYW1lOkhlbnJpcXVlIFNhbnRhbmEsVHlwZTpUcmlhbCxIYXNoOlFWR0ZSejNMcjR4NXQrS0xKYm0ySVpaaEl6OFV6c052YzY3OWRGYXdVMTBLNmNFSVpNaTdKK1VnL01jcFZrdlZxb05rUE9aaklNUFQ1R01sY29rQkZBOGtpK1ZhS1lVSDNBNHNDWUhvT0FXekhpaUpFeW9XSkJaVy9GN0I4WmVmQ1dMUTdicWpBZUFONGZXOUVFcW5UVW1IU2Q4MjROVC9VcFB3cXN0UkZ6MD0sRXhwaXJ5OjIwMTYtMDItMTB9");

                Stopwatch stopWatch = new Stopwatch();

                stopWatch.Start();
                KeyValue keyValue = new KeyValue();
                //Clientes
                IList<Locadora.Cliente> clientesList = keyValue.GetClientes;
                List<string> chavesClienteList = keyValue.GeraChaveCliente();
                List<Dictionary<string, string>> camposClienteList = keyValue.GeraCamposCliente();

                //Categoria
                IList<Locadora.Categoria> categoriaList = keyValue.GetCategorias;
                List<string> chavesCategoriaList = keyValue.GeraChaveCategoria();
                List<Dictionary<string, string>> camposCategoriaList = keyValue.GeraCamposCategorias();

                //Filmes
                IList<Locadora.Filme> filmeList = keyValue.GetFilmes;
                List<string> chavesFilmeList = keyValue.GeraChaveFilme();
                List<Dictionary<string, string>> camposFilmeList = keyValue.GeraCamposFilmes();

                //Locadoras
                IList<Locadora.Locacao> locacaoList = keyValue.GetLocacoes;
                List<string> chavesLocacaoList = keyValue.GeraChaveLocacao();
                List<Dictionary<string, string>> camposLocacaoList = keyValue.GeraCamposLocacao();

                stopWatch.Stop();
                Console.WriteLine("Criação de Objetos: {0:hh\\:mm\\:ss}", stopWatch.Elapsed);
                Console.ReadKey();

               /* stopWatch.Start();
                foreach (var item in clientesList)
                {
                    Console.WriteLine("Cod Cliente {0} | Nome {1} | Sexo {2} | Data Nascimento {3}", item.CodCliente, item.NomeCliente, item.Sexo, item.DatNascimento);
                }
                stopWatch.Stop();
                Console.WriteLine("Exibição de Objetos: {0:hh\\:mm\\:ss}", stopWatch.Elapsed);

                //Inserindo no Redis
                /*Perguntar ao professor como manipula Bytes, para podermos usar o HMset
                Porém, sua implementação é tão diferente que acho que não vale a pena.
                */


                //Cliente
                stopWatch = new Stopwatch();
                stopWatch.Start();
                int i = 0;
                foreach (var d in camposClienteList)
                {
                    foreach (var campoValor in d)
                    {
                        clienteRedis.HSet(chavesClienteList[i], campoValor.Key.ToUtf8Bytes(), campoValor.Value.ToUtf8Bytes());
                    }
                    i++;
                }
                stopWatch.Stop();
                Console.WriteLine("Inserção Cliente no Redis: {0:hh\\:mm\\:ss}", stopWatch.Elapsed);
                ////ToUtf8Bytes()

                //Categoria
                stopWatch = new Stopwatch();
                stopWatch.Start();
                i = 0;
                foreach (var dictionary in camposCategoriaList)
                {
                    foreach (var campoValor in dictionary)
                    {
                        clienteRedis.HSet(chavesCategoriaList[i], campoValor.Key.ToUtf8Bytes(), campoValor.Value.ToUtf8Bytes());
                    }
                    i++;
                }
                stopWatch.Stop();
                Console.WriteLine("Inserção Categoria no Redis: {0:hh\\:mm\\:ss}", stopWatch.Elapsed);

                //Filmes
                stopWatch = new Stopwatch();
                stopWatch.Start();
                i = 0;
                foreach (var dictionary in camposFilmeList)
                {
                    foreach (var campoValor in dictionary)
                    {
                        clienteRedis.HSet(chavesFilmeList[i], campoValor.Key.ToUtf8Bytes(), campoValor.Value.ToUtf8Bytes());
                    }
                    i++;
                }
                stopWatch.Stop();
                Console.WriteLine("Inserção Filmes no Redis: {0:hh\\:mm\\:ss}", stopWatch.Elapsed);

                //Locacao
                stopWatch = new Stopwatch();
                stopWatch.Start();
                i = 0;
                foreach (var dictionary in camposLocacaoList)
                {
                    foreach (var campoValor in dictionary)
                    {
                        clienteRedis.HSet(chavesLocacaoList[i], campoValor.Key.ToUtf8Bytes(), campoValor.Value.ToUtf8Bytes());
                    }
                    i++;
                }
                stopWatch.Stop();
                Console.WriteLine("Inserção Locação no Redis: {0:hh\\:mm\\:ss}", stopWatch.Elapsed);

                //String aux = clienteRedis.Keys("Cliente:1").ToString();
                //String aux2 = clienteRedis.HGetAll();
                Console.ReadKey();
            }

        }


    }
}
/*
<appSettings>
      <add key = "servicestack:license" value="TRIAL30SANTANA-e1JlZjpUUklBTDMwU0FOVEFOQSxOYW1lOkhlbnJpcXVlIFNhbnRhbmEsVHlwZTpUcmlhbCxIYXNoOlFWR0ZSejNMcjR4NXQrS0xKYm0ySVpaaEl6OFV6c052YzY3OWRGYXdVMTBLNmNFSVpNaTdKK1VnL01jcFZrdlZxb05rUE9aaklNUFQ1R01sY29rQkZBOGtpK1ZhS1lVSDNBNHNDWUhvT0FXekhpaUpFeW9XSkJaVy9GN0I4WmVmQ1dMUTdicWpBZUFONGZXOUVFcW5UVW1IU2Q4MjROVC9VcFB3cXN0UkZ6MD0sRXhwaXJ5OjIwMTYtMDItMTB9" />
    </appSettings>

    */