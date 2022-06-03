using CasaPopular.Interfaces;
using CasaPopular.Model;

namespace CasaPopularTests
{
  public class UmOuDoisDependentes : IComandoCalculoPotuacao
  {
    public int Calcular(Familia familia)
    {
      var quantidadeDependentes = familia.QuantidadeDependentes();

      if (quantidadeDependentes == 1 || quantidadeDependentes == 2)
        return 2;

      return 0;
    }
  }
}