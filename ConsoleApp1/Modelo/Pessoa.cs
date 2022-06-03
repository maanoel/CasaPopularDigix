﻿using System;

namespace CasaPopular.Model
{
  public class Pessoa
  {
    public DateTime DataNascimento { get; set; }
    public decimal Salario { get; set; }
    public bool Dependente { get; set; }

    public int Idade()
    {
      if (DataNascimento == null) return 0;

      int idade = DateTime.Now.Year - DataNascimento.Year;

      if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
        idade -= 1;

      return idade;
    }
  }
}
