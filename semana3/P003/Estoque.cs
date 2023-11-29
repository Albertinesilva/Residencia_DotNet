namespace P003
{
    public class Estoque
    {
        public (int Id, int Codigo, string Nome, int Quantidade, double Preco) DadosEstoque { get; set; }
        
        public Estoque(int Codigo, string Nome, int Quantidade, double Preco)
        {
            this.Id = ++PeopleID;
            this.Codigo = Codigo;
            this.Nome = Nome;
            this.Quantidade = Quantidade;
            this.Preco = Preco;
            this.DadosEstoque = (Id, Codigo, Nome, Quantidade, Preco);
        }

        private static int PeopleID { get; set; } = 2023000;

        public int Id { get; }

        public int Codigo { get; set; }

        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public double Preco { get; set; }

    }
}