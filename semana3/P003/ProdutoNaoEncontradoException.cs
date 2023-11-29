namespace P003

{
    public class ProdutoNaoEncontradoException : Exception
    {
        public ProdutoNaoEncontradoException() : base("não há produto cadastrado com esse código")
        {
        }

        public ProdutoNaoEncontradoException(string mensagem) : base(mensagem)
        {
        }

    }
}