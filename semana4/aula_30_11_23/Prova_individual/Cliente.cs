namespace _Cliente;

using _Pessoa;

public class Cliente : Pessoa{
    public string? EstadoCivil { get; set; }
    public string? Profissao { get; set; }

    public Cliente (string _nome, DateTime _dataNasc, string _cpf, string _estadoCivil, 
    string _profissao) : base(_nome, _dataNasc, _cpf){
        Nome = _nome;
        DataNasc = _dataNasc;
        CPF = _cpf;
        EstadoCivil = _estadoCivil;
        Profissao = _profissao;

    }
}