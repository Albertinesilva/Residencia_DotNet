namespace exercicios
{
    public class NumeroNegativoException : Exception
    {
        public NumeroNegativoException(string message) : base(message)
        {

        }

         public NumeroNegativoException() : base("\n\tNúmero negativo não é permitido")
        {    

        }
    }
}