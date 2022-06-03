using CasaPopular.Interfaces;
using CasaPopular.Model;
using System.Collections.Generic;
using Xunit;

namespace CasaPopularTests
{
  public class CasaPopularTests
  {
    private readonly Pessoa Mae;
    private readonly Pessoa Pai;
    private readonly Pessoa Filha;
    private readonly Pessoa Filho;
    private readonly List<Pessoa> MembrosFamilia;

    public CasaPopularTests()
    {
      Mae = new Pessoa();
      Pai = new Pessoa();
      Filha = new Pessoa();
      Filho = new Pessoa();
      MembrosFamilia = new List<Pessoa>();
    }

    [Fact]
    public void Deve_Retornar_Cinco_Pontos_Renda_Ate_9000()
    {
      Filho.Salario = 1000;
      Filha.Salario = 2000;
      Pai.Salario = 2000;
      Mae.Salario = 3000;

      MembrosFamilia.Add(Filho);
      MembrosFamilia.Add(Filha);
      MembrosFamilia.Add(Pai);
      MembrosFamilia.Add(Mae);

      var familia = new Familia();
      familia.Membros = MembrosFamilia;

      var rendaAte900 = new RendaAte900();
      var rendaDe901A1500 = new RendaDe901A1500();
      var tresOuMaisDependentes = new TresOuMaisDependentes();
      var umOuDoisDependentes = new UmOuDoisDependentes();

      var ContrutorFamilia = new ConstrutorListaFamiliasAptas();
      ContrutorFamilia.AdicionarFamilia(familia);
      ContrutorFamilia.AdicionarComandoDeCalculo(rendaAte900);
      ContrutorFamilia.AdicionarComandoDeCalculo(rendaDe901A1500);
      ContrutorFamilia.AdicionarComandoDeCalculo(tresOuMaisDependentes);
      ContrutorFamilia.AdicionarComandoDeCalculo(umOuDoisDependentes);
    }
  }
}

