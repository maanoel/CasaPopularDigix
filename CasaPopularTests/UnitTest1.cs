using CasaPopular.Model;
using System.Collections.Generic;
using Xunit;

namespace CasaPopularTests
{
  public class UnitTest1
  {
    private readonly Pessoa Mae;
    private readonly Pessoa Pai;
    private readonly Pessoa Filha;
    private readonly Pessoa Filho;
    private readonly List<Pessoa> MembrosFamilia;

    public UnitTest1()
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

      Familia familia = new Familia();
      familia.Membros = MembrosFamilia;

    }
  }
}

