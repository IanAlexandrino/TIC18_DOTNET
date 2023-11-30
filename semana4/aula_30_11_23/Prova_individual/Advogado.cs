namespace _Advogado;

using _Pessoa;

public class Advogado : Pessoa{
    public string? CNA {set; get;}

    public Advogado (string _nome, DateTime _dataNasc, string _cpf, string _cna) 
    : base(_nome, _dataNasc, _cpf){
        CNA = _cna;
    }
}