namespace Colecoes;

using Advogado;
using Cliente;

public class Colecao {
    public List<Advogado> advogados = new();
    public List<Cliente> clientes = new();

    

    public void AddAdvogado(){
        var tuplaAdvogado = (Nome: "Ian", DataNasc: new DateTime(1987,07,23), CPF: "06569235559", CNA: "06569235559");
        Advogado novoAdvogado = new Advogado{
            _nome = tuplaAdvogado.Nome,
            _dataNasc = tuplaAdvogado.DataNasc,
            _cpf = tuplaAdvogado.CPF,
            _cna = tuplaAdvogado.CNA
            };
        advogados.Add(novoAdvogado);

    }

    public void AddCliente(){

    }


}