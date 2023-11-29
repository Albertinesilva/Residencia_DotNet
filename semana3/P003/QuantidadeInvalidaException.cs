namespace P003
{
    public class QuantidadeInvalidaException : Exception
    {
        public QuantidadeInvalidaException() : base("Quantidade inválida!")
        {
        }

        public QuantidadeInvalidaException(string mensagem) : base(mensagem)
        {
        }
    }
}