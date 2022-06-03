using CasaPopular.Interfaces;
using CasaPopular.Model;

namespace CasaPopular
{
  public class RendaDe901A1500 : IComandoCalculoPotuacao
  {
    public int Calcular(Familia familia)
    {
      var rendaTotal = familia.RendaTotal();

      if (rendaTotal >= 901 && rendaTotal <= 1500)
        return 3;

      return 0;
    }
  }
}