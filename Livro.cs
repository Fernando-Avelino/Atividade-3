using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Entities
{
  public class Livro
  {
    private readonly IList<Exemplar> _exemplares;

    public Livro(int isbn, string titulo, string autor, string editora)
    {
      Isbn = isbn;
      Titulo = titulo;
      Autor = autor;
      Editora = editora;
      _exemplares = new List<Exemplar>();
    }

    public int Isbn { get; private set; }
    public string Titulo { get; private set; }
    public string Autor { get; private set; }
    public string Editora { get; private set; }
    public IReadOnlyCollection<Exemplar> Exemplares { get => _exemplares.ToArray(); }

    public bool ChecarExemplarEmprestado(int tombo)
    {
      return !this._exemplares.Where(pre => pre.Tombo == tombo).First().Disponivel();
    }

    public int EmprestarExemplar()
    {
      var exemplar = Exemplares.Where(pre => pre.Disponivel()).First();

      exemplar.Emprestar();

      return exemplar.Tombo;
    }

    public void DevolverExemplar(int tombo)
    {
      var exemplar = Exemplares.Where(pre => pre.Tombo == tombo).First();

      exemplar.Devolver();
    }

    public void AdicionarExemplar(Exemplar exemplar)
    {
      _exemplares.Add(exemplar);
    }

    public int QtdeExemplares()
    {
      return _exemplares.Count;
    }

    public int QtdeDisponiveis()
    {
      return _exemplares.Where(pre => pre.Disponivel()).Count();
    }

    public int QtdeEmprestimos()
    {
      int qtdeEmprestimos = 0;

      foreach (var exemplar in _exemplares)
      {
        qtdeEmprestimos += exemplar.QtdeEmprestimos();
      }

      return qtdeEmprestimos;
    }

    public double PercDisponibilidade()
    {
      if(QtdeExemplares() == 0)
        return 0;

      return (QtdeDisponiveis() / QtdeExemplares()) * 100;
    }

    public override bool Equals(object obj)
    {
      return obj is Livro livro && Isbn == livro.Isbn;
    }
  }
}