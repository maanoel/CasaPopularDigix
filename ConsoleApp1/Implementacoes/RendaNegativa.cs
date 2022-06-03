using CasaPopular.Interfaces;
using CasaPopular.Model;

namespace CasaPopular
{
  public class RendaNegativa : IComandoCalculoPotuacao
  {
    public int Calcular(Familia familia)
    {
      if (familia.RendaTotal() < 0)
        return 7;

      return 0;
    }
  }
}
