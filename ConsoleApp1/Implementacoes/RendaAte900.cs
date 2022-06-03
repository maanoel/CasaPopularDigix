using CasaPopular.Interfaces;
using CasaPopular.Model;

namespace CasaPopularTests
{
  public class RendaAte900 : IComandoCalculoPotuacao
  {
    public int Calcular(Familia familia)
    {
      if (familia.RendaTotal() <= 900)
        return 5;

      return 0;
    }
  }
}