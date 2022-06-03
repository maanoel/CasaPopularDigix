using System.Collections.Generic;
using System.Linq;

namespace CasaPopular.Model
{
  public class Familia
  {
    public int Pontuacao { get; set; }
    public List<Pessoa> Membros { get; set; }

    public decimal RendaTotal()
    {
      return Membros.Sum(m => m.Salario);
    }

    public int QuantidadeDependentes()
    {
      return Membros.Count(m => m.Dependente && m.Idade() < 18);
    }
  }
}
