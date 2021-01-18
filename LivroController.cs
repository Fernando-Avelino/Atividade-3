using System.Collections.Generic;
using System.Linq;
using Library.Domain.Entities;

namespace Library.Domain.Controllers
{
  public class LivroController
  {
    private readonly IList<Livro> _acervo;

    public LivroController()
    {
      _acervo = new List<Livro>();
    }

    public void Adicionar(Livro livro)
    {
      if (Pesquisar(livro) == null)
      {
        _acervo.Add(livro);
      }
    }
    public Livro Pesquisar(Livro livro)
    {
      return _acervo.FirstOrDefault(pre => pre.Equals(livro));
    }
  }
}