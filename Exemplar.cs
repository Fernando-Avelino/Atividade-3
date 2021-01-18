using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Entities
{
  public class Exemplar
  {
    private readonly IList<Emprestimo> _emprestimos;

    public Exemplar(int tombo)
    {
      Tombo = tombo;
      _emprestimos = new List<Emprestimo>();
    }

    public int Tombo { get; private set; }
    public IReadOnlyCollection<Emprestimo> Emprestimos { get => _emprestimos.ToArray(); }

    public bool Emprestar()
    {
      if (!Disponivel())
        return false;

      _emprestimos.Add(new Emprestimo());

      return true;
    }

    public bool Devolver()
    {
      if (Disponivel())
        return false;

      var emprestimo = _emprestimos.Last();

      emprestimo.FinalizarEmprestimo();
      return true;
    }

    public bool Disponivel()
    {
      if (_emprestimos.Count != 0)
      {
        var emprestimo = _emprestimos.Last();

        if (emprestimo.DtDevolucao != null)
          return false;
      }

      return true;
    }

    public int QtdeEmprestimos()
    {
      return _emprestimos.Count;
    }
  }
}