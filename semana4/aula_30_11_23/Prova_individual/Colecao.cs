namespace Colecoes;

using Advogado;
using Cliente;

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
        var cliente = clientes.Select(x => new { x.Nome,});
    }


}