using CasaPopular.Model;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using System;

namespace CasaPopularTests
{
  public class RendaAcimaDe1500Tests
  {
    private readonly Pessoa Mae;
    private readonly Pessoa Pai;
    private readonly Pessoa Filha;
    private readonly Pessoa Filho;
    private readonly Pessoa Cacula;
    private readonly List<Pessoa> MembrosFamilia;
    private readonly RendaAte900 RendaAte900;
    private readonly RendaDe901A1500 RendaDe901A1500;
    private readonly TresOuMaisDependentes TresOuMaisDependentes;
    private readonly UmOuDoisDependentes UmOuDoisDependentes;
    private readonly ConstrutorListaFamiliasAptas ConstrutorFamiliasAptas;

    public RendaAcimaDe1500Tests()
    {
      Mae = new Pessoa();
      Pai = new Pessoa();
      Filha = new Pessoa();
      Filho = new Pessoa();
      Cacula = new Pessoa();
      MembrosFamilia = new List<Pessoa>();
      RendaAte900 = new RendaAte900();
      RendaDe901A1500 = new RendaDe901A1500();
      TresOuMaisDependentes = new TresOuMaisDependentes();
      UmOuDoisDependentes = new UmOuDoisDependentes();
      ConstrutorFamiliasAptas = new ConstrutorListaFamiliasAptas();

      AdicionarComandoConstrutor();
      MockValoresIniciais();
    }

    private void AdicionarComandoConstrutor()
    {
      ConstrutorFamiliasAptas.AdicionarComandoDeCalculo(RendaAte900);
      ConstrutorFamiliasAptas.AdicionarComandoDeCalculo(RendaDe901A1500);
      ConstrutorFamiliasAptas.AdicionarComandoDeCalculo(TresOuMaisDependentes);
      ConstrutorFamiliasAptas.AdicionarComandoDeCalculo(UmOuDoisDependentes);
    }

    private void MockValoresIniciais()
    {
      Filho.Nome = "Marcio Garcia";
      Filho.DataNascimento = DateTime.Now;
      Filho.Dependente = true;

      Filha.Nome = "Joana Garcia";
      Filha.DataNascimento = DateTime.Now;
      Filha.Dependente = true;

      Cacula.Nome = "Vitor Garcia";
      Cacula.DataNascimento = DateTime.Now;
      Cacula.Dependente = true;

      Pai.Nome = "João Garcia";
      Mae.Nome = "Mariana Garcia";
    }

    [Fact]
    public void Deve_Retornar_Dois_Pontos_Renda_Acima_1500_Dois_Dependentes()
    {
      Pai.Salario = 1000;
      Mae.Salario = 1000;

      MembrosFamilia.Add(Pai);
      MembrosFamilia.Add(Mae);
      MembrosFamilia.Add(Filho);
      MembrosFamilia.Add(Filha);

      var familia = new Familia();
      familia.Membros = MembrosFamilia;

      ConstrutorFamiliasAptas.AdicionarFamilia(familia);

      List<Familia> familiasAptas = ConstrutorFamiliasAptas.Criar();

      var familiaApta = familiasAptas.FirstOrDefault();

      Assert.Equal(2, familiaApta.Pontuacao);
    }

    [Fact]
    public void Deve_Retornar_Tres_Pontos_Renda_Acima_1500_Tres_Dependentes()
    {
      Pai.Salario = 1000;
      Mae.Salario = 600;

      MembrosFamilia.Add(Pai);
      MembrosFamilia.Add(Mae);
      MembrosFamilia.Add(Filho);
      MembrosFamilia.Add(Filha);
      MembrosFamilia.Add(Cacula);

      var familia = new Familia();
      familia.Membros = MembrosFamilia;

      ConstrutorFamiliasAptas.AdicionarFamilia(familia);

      List<Familia> familiasAptas = ConstrutorFamiliasAptas.Criar();

      var familiaApta = familiasAptas.FirstOrDefault();

      Assert.Equal(3, familiaApta.Pontuacao);
    }

    [Fact]
    public void Deve_Retornar_Zero_Pontos_Renda_Acima_1500_Sem_Dependentes()
    {
      Pai.Salario = 1400;
      Mae.Salario = 599;

      MembrosFamilia.Add(Pai);
      MembrosFamilia.Add(Mae);

      var familia = new Familia();
      familia.Membros = MembrosFamilia;

      ConstrutorFamiliasAptas.AdicionarFamilia(familia);

      List<Familia> familiasAptas = ConstrutorFamiliasAptas.Criar();

      var familiaApta = familiasAptas.FirstOrDefault();

      Assert.Equal(0, familiaApta.Pontuacao);
    }
  }
}

