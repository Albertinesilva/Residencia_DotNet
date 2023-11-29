using System;
using System.Collections.Generic;
using System.IO;

namespace P003
{
    public class EstoqueService : EstoqueRepository
    {
        private List<(int Id, int Codigo, string Nome, int Quantidade, double Preco)> ListaDeTuplas { get; set; }

        public EstoqueService()
        {
            // Inicializa a lista no construtor padrão
            ListaDeTuplas = new List<(int Id, int Codigo, string Nome, int Quantidade, double Preco)>();
        }

        public void AdcionarTupla((int, int, string, int, double) tupla)
        {
            ListaDeTuplas.Add(tupla);
        }

        public void Cadastrar(){
            Console.WriteLine("\n\t========== CADASTRAR PRODUTO ==========");
            int codigo;

            do
            {
                codigo = ValidarEntradaInt("\n\tInforme o Código do Produto");

            } while (IsCodigoIgual(codigo));

            Console.Write("\n\tInforme o nome do Produto: ");
            string nome = Console.ReadLine()!;
            nome = convertePrimeiraLetraParaMaiuscula(nome);

            int quantidade = ValidarEntradaInt("\n\tInforme a quantidade do Produto");

            double preco = ValidarEntradaDouble("\n\tInforme o preço do Produto");

            AdcionarTupla(new Estoque(codigo, nome, quantidade, preco).DadosEstoque);

            App.LimparTela();
            Listar();
            Console.WriteLine("\n\tProduto cadastrado com sucesso!");
            App.Pause();

        }

        public void Listar(){
            Console.WriteLine("\n\t========== LISTAR PRODUTOS ==========");

            if (ListaDeTuplas.Count == 0)
            {
                Console.WriteLine("\n\tNão há produtos cadastrados.");
                App.Pause();
                return;
            }

            foreach (var item in ListaDeTuplas)
            {
                Console.WriteLine($"\tID: {item.Id}");
                Console.WriteLine($"\tCódigo: {item.Codigo}");
                Console.WriteLine($"\tNome: {item.Nome}");
                Console.WriteLine($"\tQuantidade: {item.Quantidade}");
                Console.WriteLine($"\tPreço: R$ {item.Preco:F2}");
                Console.WriteLine("\t======================================");
            }

        }

        public void Editar(){
            int codigo = ValidarEntradaInt("\n\tInforme o CÓDIGO do Produto");

            // Encontre o índice da tupla a ser editada
            int indiceParaEdicao = ListaDeTuplas.FindIndex(item => item.Codigo == codigo);

            if (indiceParaEdicao != -1)
            {
                var itemParaEdicao = ListaDeTuplas[indiceParaEdicao];

                App.LimparTela();
                Console.WriteLine("\n\t           EDITAR PRODUTO           ");
                Console.WriteLine("\n\t========== DADOS DO PRODUTO ==========");
                Console.WriteLine($"\tID: {itemParaEdicao.Id}");
                Console.WriteLine($"\tCódigo: {itemParaEdicao.Codigo}");
                Console.WriteLine($"\tNome: {itemParaEdicao.Nome}");
                Console.WriteLine($"\tQuantidade: {itemParaEdicao.Quantidade}");
                Console.WriteLine($"\tPreço: {itemParaEdicao.Preco}");
                Console.WriteLine("\t======================================");

                Console.WriteLine("\n\tInforme os novos dados do Produto");
                App.Pause();
                App.LimparTela();

                int novoCodigo = ValidarEntradaInt("\n\tInforme o Código do Produto");

                Console.Write("\n\tInforme o nome do Produto: ");
                string novoNome = Console.ReadLine()!;
                novoNome = convertePrimeiraLetraParaMaiuscula(novoNome);

                int novaQuantidade = ValidarEntradaInt("\n\tInforme a quantidade do Produto");

                double novoPreco = ValidarEntradaDouble("\n\tInforme o preço do Produto");

                // // Crie uma nova tupla com os dados atualizados
                // var novaTupla = (itemParaEdicao.Id, novoCodigo, novoNome, novaQuantidade, novoPreco);

                // // Substitua a tupla antiga pela nova na lista
                // ListaDeTuplas[indiceParaEdicao] = novaTupla;

                //Outra forma de fazer: Usando o LINQ para criar uma nova lista com a tupla substituída
                ListaDeTuplas = ListaDeTuplas
                    .Select((item, index) => index == indiceParaEdicao
                        ? (itemParaEdicao.Id, novoCodigo, novoNome, novaQuantidade, novoPreco)
                        : item)
                    .ToList();

                App.LimparTela();
                Listar();
                Console.WriteLine("\n\tProduto editado com sucesso!");

            }
            else
            {
                Console.WriteLine("\n\tOps, não há produtos cadastrados com esse código.");
            }

        }

        public void Excluir()
        {
            string userInput;
            int codigo = ValidarEntradaInt("\n\tInforme o CÓDIGO do Produto");

            // Encontra o índice da tupla a ser excluída
            int indiceParaExclusao = ListaDeTuplas.FindIndex(item => item.Codigo == codigo);

            if (indiceParaExclusao != -1)
            {
                var itemParaExclusao = ListaDeTuplas[indiceParaExclusao];

                App.LimparTela();
                Console.WriteLine("\n\t           EXCLUIR PRODUTO           ");
                Console.WriteLine("\n\t========== DADOS DO PRODUTO ==========");
                Console.WriteLine($"\tID: {itemParaExclusao.Id}");
                Console.WriteLine($"\tCódigo: {itemParaExclusao.Codigo}");
                Console.WriteLine($"\tNome: {itemParaExclusao.Nome}");
                Console.WriteLine($"\tQuantidade: {itemParaExclusao.Quantidade}");
                Console.WriteLine($"\tPreço: {itemParaExclusao.Preco}");
                Console.WriteLine("\t======================================");

                do
                {
                    Console.WriteLine("\n\tDeseja realmente excluir esse produto?");
                    Console.WriteLine("\n\t[1] - SIM");
                    Console.WriteLine("\t[2] - NÃO");
                    Console.Write("\tENTRADA -> ");
                    userInput = Console.ReadLine()!;

                    if (!string.IsNullOrEmpty(userInput) && Int32.TryParse(userInput, out int opcao))
                    {
                        // A conversão foi bem-sucedida
                        if (opcao == 1)
                        {
                            // Remova a tupla da lista
                            ListaDeTuplas.RemoveAt(indiceParaExclusao);

                            App.LimparTela();
                            Listar();
                            Console.WriteLine("\n\tProduto excluído com sucesso!");

                        }
                        else if (opcao == 2)
                        {
                            App.LimparTela();
                            Listar();
                            Console.WriteLine("\n\tProduto não foi excluído.");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\n\tOpção inválida. Por favor, escolha uma opção de 1 a 2.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                    }

                } while (userInput != "1" && userInput != "2");

            }
            else
            {
                Console.WriteLine("\n\tOps, não há produtos cadastrados com esse código.");
            }

            App.Pause();
        }

        public void Pesquisar()
        {
            Console.WriteLine("\n\t========== PESQUISAR PRODUTO ==========");

            if (ListaDeTuplas.Count == 0)
            {
                Console.WriteLine("\n\tNão há produtos cadastrados.");
                App.Pause();
                return;
            }

            int codigo = ValidarEntradaInt("\n\tInforme o Código do Produto");

            // Encontre o índice da tupla a ser pesquisada
            int indiceParaPesquisa = ListaDeTuplas.FindIndex(item => item.Codigo == codigo);

            try
            {
                if (indiceParaPesquisa != -1)
                {
                    var itemParaPesquisa = ListaDeTuplas[indiceParaPesquisa];

                    App.LimparTela();
                    Console.WriteLine("\n\t           PESQUISAR PRODUTO           ");
                    Console.WriteLine("\n\t========== DADOS DO PRODUTO ==========");
                    Console.WriteLine($"\tID: {itemParaPesquisa.Id}");
                    Console.WriteLine($"\tCódigo: {itemParaPesquisa.Codigo}");
                    Console.WriteLine($"\tNome: {itemParaPesquisa.Nome}");
                    Console.WriteLine($"\tQuantidade: {itemParaPesquisa.Quantidade}");
                    Console.WriteLine($"\tPreço: {itemParaPesquisa.Preco}");
                    Console.WriteLine("\t======================================");
                }
                else
                {
                    throw new ProdutoNaoEncontradoException();
                }

                App.Pause();
            }
            catch (ProdutoNaoEncontradoException ex)
            {
                Console.WriteLine($"\tOps, {ex.Message}");
                App.Pause();
            }
        }

        public void AtualizarEstoque()
        {

            if (ListaDeTuplas.Count == 0)
            {
                Console.WriteLine("\n\tNão há produtos cadastrados.");
                App.Pause();
                return;
            }

            do
            {
                App.LimparTela();
                Console.WriteLine("\n\t========== ATUALIZAR ESTOQUE ==========");
                Console.WriteLine("\t[1] - ATUALIZAR PRODUTO");
                Console.WriteLine("\t[0] - MENU PRINCIPAL");
                Console.Write("\tENTRADA -> ");
                int atualizarOuMenu;

                // Tenta converter a entrada do usuário para um número inteiro
                if (int.TryParse(Console.ReadLine(), out atualizarOuMenu))
                {
                    if (atualizarOuMenu == 0)
                    {
                        Console.WriteLine("\n\tVoltando ao Menu Principal...");
                        App.Pause();
                        return;
                    }
                    else
                    {
                        if (atualizarOuMenu == 1)
                        {

                            int codigo = ValidarEntradaInt("\n\tCódigo -> ");
                            int indiceParaAtualizacao = ListaDeTuplas.FindIndex(item => item.Codigo == codigo);
                            bool atualizarOutroProduto = true;

                            if (indiceParaAtualizacao != -1)
                            {

                                do
                                {
                                    var itemParaAtualizacao = ListaDeTuplas[indiceParaAtualizacao];
                                    ExibirDadosDoProduto(itemParaAtualizacao);

                                    Console.WriteLine("\n\tDeseja dar entrada ou saída no estoque?");
                                    Console.WriteLine("\n\t[1] - ENTRADA");
                                    Console.WriteLine("\t[2] - SAÍDA");
                                    Console.WriteLine("\t[3] - ESCOLHER OUTRO PRODUTO ");
                                    Console.WriteLine("\t[4] - MENU PRINCIPAL");
                                    Console.Write("\tENTRADA -> ");

                                    string userInput = Console.ReadLine() ?? "";

                                    switch (userInput)
                                    {
                                        case "1":
                                            AtualizarQuantidadeEstoque(indiceParaAtualizacao, true);
                                            break;

                                        case "2":
                                            AtualizarQuantidadeEstoque(indiceParaAtualizacao, false);
                                            break;

                                        case "3":
                                            atualizarOutroProduto = true;
                                            break;

                                        case "4":
                                            Console.WriteLine("\n\tVoltando ao Menu Principal...");
                                            App.Pause();
                                            return;

                                        default:
                                            Console.WriteLine("\n\tOpção inválida. Por favor, escolha uma opção de 1 a 3.");
                                            break;
                                    }

                                } while (!atualizarOutroProduto);
                            }
                            else
                            {
                                Console.WriteLine("\n\tOps, não há produtos cadastrados com esse código.");
                                App.Pause();
                            }

                        }
                        else
                        {
                            Console.WriteLine("\n\tOpção inválida. Por favor, escolha uma opção de 0 a 1.");
                            App.Pause();
                        }

                    }
                }
                else
                {
                    Console.WriteLine("\n\tPor favor, insira um valor numérico válido.");
                }

            } while (true);

        }

        public void AtualizarQuantidadeEstoque(int indice, bool isEntrada)
        {
            try
            {
                int novaQuantidade = ValidarEntradaInt($"\n\tInforme a {(isEntrada ? "entrada" : "saída")} da quantidade do produto: ");

                if (isEntrada && ListaDeTuplas.Any(item => (item.Quantidade + novaQuantidade) < 0))
                {
                    throw new QuantidadeInvalidaException("A entrada não pode ser maior que a quantidade atual do produto.");
                }

                if (!isEntrada && (ListaDeTuplas[indice].Quantidade - novaQuantidade) < 0)
                {
                    throw new QuantidadeInvalidaException("A saída não pode ser maior que a quantidade atual do produto.");
                }

                var produto = ListaDeTuplas[indice];
                novaQuantidade = isEntrada ? (produto.Quantidade + novaQuantidade) : (produto.Quantidade - novaQuantidade);
                novaQuantidade = Math.Max(0, novaQuantidade);

                ListaDeTuplas[indice] = (produto.Id, produto.Codigo, produto.Nome, novaQuantidade, produto.Preco);

                App.LimparTela();
                ExibirDadosDoProduto(ListaDeTuplas[indice]);
                Console.WriteLine($"\n\tEstoque {(isEntrada ? "atualizado com entrada" : "atualizado com saída")} de sucesso!");
                App.Pause();
            }
            catch (QuantidadeInvalidaException ex)
            {
                Console.WriteLine($"\tOps, {ex.Message}");
                App.Pause();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tOps, {ex.Message}");
                App.Pause();
            }
        }

        public void ExibirDadosDoProduto((int Id, int Codigo, string Nome, int Quantidade, double Preco) produto)
        {
            App.LimparTela();
            Console.WriteLine("\n\t           ATUALIZAR ESTOQUE           ");
            Console.WriteLine("\n\t========== DADOS DO PRODUTO ==========");
            Console.WriteLine($"\tID: {produto.Id}");
            Console.WriteLine($"\tCódigo: {produto.Codigo}");
            Console.WriteLine($"\tNome: {produto.Nome}");
            Console.WriteLine($"\tQuantidade: {produto.Quantidade}");
            Console.WriteLine($"\tPreço: R$ {produto.Preco:F2}");
            Console.WriteLine("\t======================================");
        }

        public void GerarRelatorio()
        {
            do
            {
                App.LimparTela();
                Console.WriteLine("\n\t========== RELATÓRIOS ==========");
                Console.WriteLine("\t[1] - LISTA DE PRODUTOS COM QUANTIDADE ABAIXO DO LIMITE");
                Console.WriteLine("\t[2] - LISTA DE PRODUTOS COM VALOR ENTRE MIN E MAX");
                Console.WriteLine("\t[3] - INFORMAR O VALOR TOTAL DE ESTOQUE E DE CADA PRODUTO");
                Console.WriteLine("\t[0] - MENU PRINCIPAL");
                Console.Write("\tENTRADA -> ");

                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            RelatorioQuantidadeAbaixoLimite();
                            break;

                        case 2:
                            RelatorioValorEntreMinMax();
                            break;

                        case 3:
                            RelatorioValorTotalEstoque();
                            break;

                        case 0:
                            Console.WriteLine("\n\tOps, retornando ao menu prncipal!...");
                            App.Pause();
                            return;

                        default:
                            Console.WriteLine("\n\tOpção inválida. Por favor, escolha uma opção válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n\tPor favor, insira um valor numérico válido.");
                }

            } while (true);
        }

        public void RelatorioQuantidadeAbaixoLimite()
        {
            Console.Write("\n\tInforme o limite de quantidade em estoque: ");

            if (int.TryParse(Console.ReadLine(), out int limite))
            {
                var produtosAbaixoLimite = ListaDeTuplas.Where(p => decimal.TryParse(p.Quantidade.ToString(), out decimal quantidade) && quantidade < limite).ToList();

                if (produtosAbaixoLimite.Any())
                {
                    App.LimparTela();
                    Console.WriteLine("\n\tProdutos com quantidade em estoque abaixo do limite:");
                    foreach (var produto in produtosAbaixoLimite)
                    {
                        App.Pause();
                        ExibirDadosDoProduto(produto);
                    }
                }
                else
                {
                    Console.WriteLine($"\n\tNão há produtos com quantidade em estoque abaixo de {limite}.");
                }
            }
            else
            {
                Console.WriteLine("\n\tPor favor, insira um valor numérico válido.");
            }

            App.Pause();
        }

        public void RelatorioValorEntreMinMax()
        {
            Console.Write("\n\tInforme o valor mínimo: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal precoMin))
            {
                Console.Write("\n\tInforme o valor máximo: ");

                if (decimal.TryParse(Console.ReadLine(), out decimal precoMax))
                {

                    var produtosEntreMinMax = ListaDeTuplas.Where(p => (decimal)p.Preco >= precoMin && (decimal)p.Preco <= precoMax).ToList();

                    if (produtosEntreMinMax.Any())
                    {
                        App.LimparTela();
                        Console.WriteLine("\n\tProdutos com valor entre o mínimo e o máximo informados:");
                        foreach (var produto in produtosEntreMinMax)
                        {
                            App.Pause();
                            ExibirDadosDoProduto(produto);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\n\tNão há produtos com valor entre {precoMin} e {precoMax}.");
                    }
                }
                else
                {
                    Console.WriteLine("\n\tPor favor, insira um valor numérico válido para o valor máximo.");

                }
            }
            else
            {
                Console.WriteLine("\n\tPor favor, insira um valor numérico válido para o valor mínimo.");

            }
            App.Pause();
        }

        public void RelatorioValorTotalEstoque()
        {
            App.LimparTela();
            Console.WriteLine("\n\t           RELATÓRIOS        ");
            decimal valorTotalEstoque = ListaDeTuplas.Sum(p => (decimal)p.Preco * p.Quantidade);

            Console.WriteLine($"\n\tValor total do estoque: {valorTotalEstoque:C}");

            Console.WriteLine("\n\tValor total de cada produto de acordo com seu estoque:");
            foreach (var produto in ListaDeTuplas)
            {
                decimal valorProduto = (decimal)produto.Preco * produto.Quantidade;
                Console.WriteLine($"\tProduto: {produto.Nome} - Valor Total: {valorProduto:C}");
            }

            App.Pause();
        }

        public bool IsCodigoIgual(int codigo)
        {

            if (ListaDeTuplas.Count == 0)
            {
                return false;
            }

            // Encontre o índice da tupla a ser verificada
            int indiceParaVerificacao = ListaDeTuplas.FindIndex(item => item.Codigo == codigo);


            if (indiceParaVerificacao != -1)
            {
                var itemParaAtualizacao = ListaDeTuplas[indiceParaVerificacao];

                App.LimparTela();
                Console.WriteLine("\n\t      CODIGO JÁ ESTA CADASTRADO        ");
                Console.WriteLine("\n\t========== DADOS DO PRODUTO ==========");
                Console.WriteLine($"\tID: {itemParaAtualizacao.Id}");
                Console.WriteLine($"\tCódigo: {itemParaAtualizacao.Codigo}");
                Console.WriteLine($"\tNome: {itemParaAtualizacao.Nome}");
                Console.WriteLine($"\tQuantidade: {itemParaAtualizacao.Quantidade}");
                Console.WriteLine($"\tPreço: {itemParaAtualizacao.Preco}");
                Console.WriteLine("\t======================================");

                Console.WriteLine("\n\tO código informado já está cadastrado. Por favor, informe outro código.");
                App.Pause();
                return true;
            }
            return false;
        }

        public int ValidarEntradaInt(string mensagem)
        {
            int valor;

            do
            {
                App.LimparTela();
                Console.WriteLine("\n\t========== SISTEMA DE GERENCIAMENTO DE PRODUTOS ========== ");
                Console.Write($"\t{mensagem}: ");

                string input = Console.ReadLine()!;

                try
                {
                    valor = Int32.Parse(input);

                    if (valor <= 0)
                    {
                        throw new OverflowException($"\n\tOps, entrada inválida! O valor não pode ser menor ou igual a zero.");
                    }
                    return valor;
                }
                catch (FormatException)
                {
                    App.LimparTela();
                    Console.WriteLine($"\n\tOps, entrada inválida. Por favor, insira um número válido.");
                    App.Pause();
                }
                catch (OverflowException ex)
                {
                    App.LimparTela();
                    Console.WriteLine(ex.Message);
                    App.Pause();
                }

            } while (true);
        }

        public double ValidarEntradaDouble(string mensagem)
        {
            do
            {
                App.LimparTela();
                Console.WriteLine("\n\t========== SISTEMA DE GERENCIAMENTO DE PRODUTOS ========== ");
                Console.Write($"\t{mensagem}: ");

                string input = Console.ReadLine()!;

                try
                {
                    if (double.TryParse(input, out double doubleValue))
                    {
                        if (doubleValue <= 0)
                        {
                            throw new OverflowException($"\n\tOps, entrada inválida! O valor não pode ser menor ou igual a zero.");
                        }
                        return doubleValue;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    App.LimparTela();
                    Console.WriteLine($"\n\tOps, entrada inválida. Por favor, insira um número válido.");
                    App.Pause();
                }
                catch (OverflowException ex)
                {
                    App.LimparTela();
                    Console.WriteLine(ex.Message);
                    App.Pause();
                }

            } while (true);
        }

        public String convertePrimeiraLetraParaMaiuscula(string palavra)
        {
            string palavraComMaiuscula = "";
            bool converteu = true;

            do
            {
                // Verifica se a string não está vazia
                if (!string.IsNullOrEmpty(palavra))
                {
                    // Converte a primeira letra para maiúscula
                    palavraComMaiuscula = char.ToUpper(palavra[0]) + palavra.Substring(1);
                    converteu = false;
                }
                else
                {
                    Console.WriteLine("\n\tA string está vazia.");
                    Console.Write("\tPressione Enter para continuar... ");
                    Console.ReadLine();
                    App.LimparTela();

                    Console.Write("\n\tInforme o nome do Produto: ");
                    palavra = Console.ReadLine()!;
                }
            } while (converteu);

            return palavraComMaiuscula;
        }

        public void SalvarArquivo()
        {
            string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:/Users/alber/OneDrive/Documentos/ProjetosResidencia/residenciaDotNet/semana3/P003/BancoDeDados/dados.txt"); // Nome do arquivo no diretório do projeto

            try
            {
                using (StreamWriter writer = new StreamWriter(caminhoArquivo))
                {
                    foreach (var item in ListaDeTuplas)
                    {
                        // Formatando os dados para gravar no arquivo
                        string linha = $"{item.Id},{item.Codigo},{item.Nome},{item.Quantidade},{item.Preco}";
                        writer.WriteLine(linha);
                    }
                }

                // Console.WriteLine("\n\tDados salvos com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\tOcorreu um erro ao salvar o arquivo: {ex.Message}");
            }
        }

        public void CarregarArquivo()
        {
            string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:/Users/alber/OneDrive/Documentos/ProjetosResidencia/residenciaDotNet/semana3/P003/BancoDeDados/dados.txt"); // Nome do arquivo no diretório do projeto

            try
            {
                ListaDeTuplas.Clear(); // Limpa a lista antes de carregar novos dados

                using (StreamReader reader = new StreamReader(caminhoArquivo))
                {
                    while (!reader.EndOfStream)
                    {
                        string linha = reader.ReadLine()!;
                        string[] dados = linha.Split(',');

                        // Certifique-se de que existam dados suficientes na linha
                        if (dados.Length >= 5)
                        {
                            int id = int.Parse(dados[0]);
                            int codigo = int.Parse(dados[1]);
                            string nome = dados[2];
                            int quantidade = int.Parse(dados[3]);
                            double preco = double.Parse(dados[4]);

                            AdcionarTupla(new Estoque(codigo, nome, quantidade, preco).DadosEstoque);
                        }
                        else
                        {
                            Console.WriteLine("A linha no arquivo não contém dados suficientes.");
                        }
                    }
                }

                Console.WriteLine("Dados carregados com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao carregar o arquivo: {ex.Message}");
            }
        }

    }
}