using CasaPopular.Interfaces;
using CasaPopular.Model;

namespace CasaPopularTests
{
  public class TresOuMaisDependentes : IComandoCalculoPotuacao
  {
    public int Calcular(Familia familia)
    {
      if (familia.QuantidadeDependentes() >= 3)
        return 3;

      return 0;
    }
  }
}