namespace _Colecoes;

using _Advogado;
using _Cliente;

public class Colecao {
    public List<Advogado> advogados = new();
    public List<Cliente> clientes = new();


    public void AddAdvogado(){
        var tuplaAdvogado = (Nome: "Ian", DataNasc: new DateTime(1987,07,23), 
        CPF: "06569235559", CNA: "06569235559");
        Advogado novoAdvogado = new Advogado(
            tuplaAdvogado.Nome,
            tuplaAdvogado.DataNasc,
            tuplaAdvogado.CPF,
            tuplaAdvogado.CNA
        );
        advogados.Add(novoAdvogado);
        var advogado = advogados.Select(advogado => advogado.Nome );
    }

    public void AddCliente(){
        var tuplaCliente = (Nome: "Ian", DataNasc: new DateTime(1987,07,23), 
        CPF: "06569235559", EstadoCivil: "Solteiro", Profissao: "Estudante");
        Cliente novoCliente = new Cliente(
            tuplaCliente.Nome,
            tuplaCliente.DataNasc,
            tuplaCliente.CPF,
            tuplaCliente.EstadoCivil,
            tuplaCliente.Profissao
        );
        clientes.Add(novoCliente);
        var cliente = clientes.Select(cliente => cliente.Nome );
        Console.WriteLine(cliente);
    }


}