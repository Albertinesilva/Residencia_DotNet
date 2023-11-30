using System;
using recursos;

namespace MeuPrimeiroProjeto
{
  class Program
  {
    static void Main(string[] args)
    {
      ListPaciente pacientes = new ListPaciente();
      App.MenuGestaoClinica(pacientes);
    }
  }
}