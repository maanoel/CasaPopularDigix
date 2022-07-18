using CasaPopular.Interfaces;
using CasaPopular.Model;
using System.Collections.Generic;
using System.Linq;

namespace CasaPopular
{
  public class ConstrutorListaFamiliasAptas
  {
    private readonly List<IComandoCalculoPotuacao> ComandosCalculoPontuacao;
    private readonly List<Familia> Familias;

    public ConstrutorListaFamiliasAptas()
    {
      ComandosCalculoPontuacao = new List<IComandoCalculoPotuacao>();
      Familias = new List<Familia>();
    }

    public void AdicionarFamilia(Familia familia)
    {
      Familias.Add(familia);
    }

    public void AdicionarComandoDeCalculo(IComandoCalculoPotuacao comandoDeCalculo)
    {
      ComandosCalculoPontuacao.Add(comandoDeCalculo);
    }

    public List<Familia> Criar()
    {
      foreach (var familia in Familias)
      {
        CalcularPontuacao(familia);
      }

      return Familias.OrderByDescending(f => f.PontosTotais()).ToList();
    }

    private void CalcularPontuacao(Familia familia)
    {
      foreach (var calculoPontuacao in ComandosCalculoPontuacao)
      {
        var pontuacao = calculoPontuacao.Calcular(familia);

        familia.SomarPontos(pontuacao);
      }
    }
  }
}