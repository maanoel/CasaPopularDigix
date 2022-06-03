using CasaPopular.Model;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using System;

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
    public void Deve_Retornar_Tres_Pontos_Renda_Ate_900()
    {
      Filho.Nome = "Marcio Garcia";
      Filho.Dependente = true;
      Filho.DataNascimento = DateTime.Now;

      Filha.Nome = "Joana Garcia";
      Filha.Dependente = true;
      Filha.DataNascimento = DateTime.Now;

      Pai.Nome = "João Garcia";
      Mae.Nome = "Mariana Garcia";

      Pai.Salario = 200;
      Mae.Salario = 600;

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

      var construtorFamiliasAptas = new ConstrutorListaFamiliasAptas();
      construtorFamiliasAptas.AdicionarFamilia(familia);
      construtorFamiliasAptas.AdicionarComandoDeCalculo(rendaAte900);
      construtorFamiliasAptas.AdicionarComandoDeCalculo(rendaDe901A1500);
      construtorFamiliasAptas.AdicionarComandoDeCalculo(tresOuMaisDependentes);
      construtorFamiliasAptas.AdicionarComandoDeCalculo(umOuDoisDependentes);

      List<Familia> familiasAptas = construtorFamiliasAptas.Criar();

      var familiaApta = familiasAptas.FirstOrDefault();

      Assert.Equal(7, familiaApta.Pontuacao);
    }
  }
}

