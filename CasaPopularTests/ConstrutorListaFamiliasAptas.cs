using CasaPopular.Interfaces;
using CasaPopular.Model;
using System.Collections.Generic;

namespace CasaPopularTests
{
  public class ConstrutorListaFamiliasAptas
  {
    private readonly List<IComandoCalculoPotuacao> ComandoCalculoPontuacao;
    private readonly List<Familia> Familias;

    public ConstrutorListaFamiliasAptas()
    {
      ComandoCalculoPontuacao = new List<IComandoCalculoPotuacao>();
      Familias = new List<Familia>();
    }

    public void AdicionarFamilia(Familia familia)
    {
      Familias.Add(familia);
    }

    public void AdicionarComandoDeCalculo(IComandoCalculoPotuacao comandoDeCalculo)
    {
      ComandoCalculoPontuacao.Add(comandoDeCalculo);
    }
  }
}