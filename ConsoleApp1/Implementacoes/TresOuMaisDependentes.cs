using CasaPopular.Interfaces;
using CasaPopular.Model;

namespace CasaPopular
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