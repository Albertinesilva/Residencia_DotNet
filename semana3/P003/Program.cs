namespace P003
{
  class Program
  {
    static void Main(string[] args)
    {
      EstoqueService estoque = new EstoqueService();
      App.MenuEstoque(estoque);
    }
  }
}