using CasaPopular.Model;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using System;

namespace CasaPopularTests
{
  public class ListaFamiliasAptasTests
  {
    private readonly Familia FamiliaGarcia;
    private readonly List<Pessoa> MembrosFamiliaGarcia;
    private readonly Familia FamiliaSerafim;
    private readonly List<Pessoa> MembrosFamiliaSerafim;
    private readonly RendaAte900 RendaAte900;
    private readonly RendaDe901A1500 RendaDe901A1500;
    private readonly TresOuMaisDependentes TresOuMaisDependentes;
    private readonly UmOuDoisDependentes UmOuDoisDependentes;
    private readonly ConstrutorListaFamiliasAptas ConstrutorFamiliasAptas;

    public ListaFamiliasAptasTests()
    {
      FamiliaGarcia = new Familia();
      MembrosFamiliaGarcia = new List<Pessoa>();

      FamiliaSerafim = new Familia();
      MembrosFamiliaSerafim = new List<Pessoa>();

      RendaAte900 = new RendaAte900();
      RendaDe901A1500 = new RendaDe901A1500();
      TresOuMaisDependentes = new TresOuMaisDependentes();
      UmOuDoisDependentes = new UmOuDoisDependentes();
      ConstrutorFamiliasAptas = new ConstrutorListaFamiliasAptas();

      AdicionarComandoConstrutor();
      MockValoresIniciaisFamilias();
    }

    private void AdicionarComandoConstrutor()
    {
      ConstrutorFamiliasAptas.AdicionarComandoDeCalculo(RendaAte900);
      ConstrutorFamiliasAptas.AdicionarComandoDeCalculo(RendaDe901A1500);
      ConstrutorFamiliasAptas.AdicionarComandoDeCalculo(TresOuMaisDependentes);
      ConstrutorFamiliasAptas.AdicionarComandoDeCalculo(UmOuDoisDependentes);
    }

    private void MockValoresIniciaisFamilias()
    {
      MembrosFamiliaGarcia.Add(new Pessoa { Nome = "João Garcia", Salario = 200 });
      MembrosFamiliaGarcia.Add(new Pessoa { Nome = "Mariana Garcia", Salario = 300 });
      MembrosFamiliaGarcia.Add(new Pessoa { Nome = "Marcio Garcia", DataNascimento = DateTime.Now, Dependente = true });
      MembrosFamiliaGarcia.Add(new Pessoa { Nome = "Joana Garcia", DataNascimento = DateTime.Now, Dependente = true });
      MembrosFamiliaGarcia.Add(new Pessoa { Nome = "Itamar Garcia", DataNascimento = DateTime.Now, Dependente = true });
      MembrosFamiliaSerafim.Add(new Pessoa { Nome = "Leon Serafim", Salario = 500 });
      MembrosFamiliaSerafim.Add(new Pessoa { Nome = "Alan Serafim" , Salario = 800});
      MembrosFamiliaSerafim.Add(new Pessoa { Nome = "Caua Serafim", DataNascimento = DateTime.Now, Dependente = true });
      MembrosFamiliaSerafim.Add(new Pessoa { Nome = "Josias Serafim", DataNascimento = DateTime.Now });
      MembrosFamiliaSerafim.Add(new Pessoa { Nome = "Esdras Serafim", DataNascimento = DateTime.Now });

      FamiliaGarcia.Membros = MembrosFamiliaGarcia;
      FamiliaSerafim.Membros = MembrosFamiliaSerafim;

      ConstrutorFamiliasAptas.AdicionarFamilia(FamiliaGarcia);
      ConstrutorFamiliasAptas.AdicionarFamilia(FamiliaSerafim);
    }

    [Fact]
    public void Deve_Retornar_Oito_Pontos_Na_Primeira_Posicao()
    {
      List<Familia> familiasAptas = ConstrutorFamiliasAptas.Criar();

      var familiaApta = familiasAptas.FirstOrDefault();
      var paiGarcia = familiaApta.Membros.Select(m => m.Nome == "João Garcia");

      Assert.Equal(8, familiaApta.Pontuacao);
      Assert.True(paiGarcia.Any());
    }

    [Fact]
    public void Deve_Retornar_Cinco_Pontos_Na_Ultima_Posicao()
    {
      List<Familia> familiasAptas = ConstrutorFamiliasAptas.Criar();

      var familiaApta = familiasAptas.LastOrDefault();
      var paiSerafim = familiaApta.Membros.Select(m=> m.Nome = "Leon Serafim");

      Assert.Equal(5, familiaApta.Pontuacao);
      Assert.True(paiSerafim.Any());
    }
  }
}

