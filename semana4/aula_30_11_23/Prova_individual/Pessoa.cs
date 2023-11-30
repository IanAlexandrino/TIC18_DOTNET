namespace _Pessoa;

public abstract class Pessoa {
    public string? Nome { get; set; }
    public DateTime DataNasc { get; set; }
    public string? CPF { get; set; }

    public Pessoa (string? _nome, DateTime _dataNasc, string? _cpf) {
        Nome = _nome;
        DataNasc = _dataNasc;
        CPF = _cpf;
    }
}
