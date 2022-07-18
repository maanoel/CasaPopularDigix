using System.Collections.Generic;
using System.Linq;

namespace CasaPopular.Model
{
  public class Familia
  {
    private int Pontuacao { get; set; }
    private List<Pessoa> Membros { get; set; }

    public Familia(int pontuacao, List<Pessoa> membros)
    {
      Pontuacao = pontuacao;
      Membros = membros;
    }

    public decimal RendaTotal()
    {
      return Membros.Sum(m => m.Salario);
    }

    public int QuantidadeDependentes()
    {
      return Membros.Count(m => m.Dependente && m.Idade() < 18);
    }

    public int PontosTotais() {
      return Pontuacao;
    }

    public void DefinirMembro(Pessoa pessoa) {
      Membros.Add(pessoa);
    }

    public List<Pessoa> ObterMembros() {
      return new List<Pessoa>(Membros);
    }

    public void SomarPontos(int pontuacao) {
      Pontuacao += pontuacao;
    }
  }
}
