namespace P003
{
    public interface EstoqueRepository
    {
        void Cadastrar();

        void Listar();

        void Editar();

        void Excluir();

        void Pesquisar();

        int ValidarEntradaInt(string mensagem);

        double ValidarEntradaDouble(string mensagem);

        String convertePrimeiraLetraParaMaiuscula(string palavra);

        void AdcionarTupla((int, int, string, int, double) tupla);

        void AtualizarEstoque();

        void ExibirDadosDoProduto((int Id, int Codigo, string Nome, int Quantidade, double Preco) produto);

        void AtualizarQuantidadeEstoque(int indice, bool isEntrada);

        void GerarRelatorio();

        void RelatorioQuantidadeAbaixoLimite();

        void RelatorioValorEntreMinMax();

        void RelatorioValorTotalEstoque();

        bool IsCodigoIgual(int codigo);

        void CarregarArquivo();

        void SalvarArquivo();
    }
}