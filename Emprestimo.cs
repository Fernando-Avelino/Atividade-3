using System;

namespace Library.Domain.Entities
{
  public class Emprestimo
  {
    public Emprestimo()
    {
      DtEmprestimo = DateTime.Now;
      DtDevolucao = null;
    }

    public void FinalizarEmprestimo()
    {
      DtDevolucao = DateTime.Now;
    }

    public DateTime DtEmprestimo { get; private set; }
    public DateTime? DtDevolucao { get; private set; }
  }
}