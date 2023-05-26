using System;
using System.Collections.Generic;
using System.Text;

namespace VrumApi.Models;

public class CarroDTO
{
    public int Id {get;set;}
    public string Marca {get;set;}
    public string Modelo {get;set;}
    public int Ano {get;set;}
    public string Placa {get;set;}
    public string Tipo {get;set;}
    // public string Cor {get;set;}
    // public double Preco {get;set;}
    public int Idade {get;set;}
}