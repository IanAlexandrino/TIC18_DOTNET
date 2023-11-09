Console.WriteLine("Bom dia!!!");

int a = 2;
int b = 5;
int c = a + b;
string teclado;

Console.WriteLine(c);

teclado = Console.ReadLine();

Console.WriteLine(teclado);

#region Teste de tipos de dados

    int tipoInteiro;
    double tipoDouble;
    string tipoString;
    long tipoLong; 

    tipoInteiro = int.MaxValue;
    tipoDouble = double.MaxValue;
    tipoLong = long.MaxValue;
    tipoString = "100";

    tipoInteiro = int.Parse(tipoString);

    Console.WriteLine(tipoInteiro);
    Console.WriteLine(tipoDouble);
    Console.WriteLine(tipoLong);

#endregion

#region Operadores

    tipoDouble = tipoInteiro + tipoLong;

    tipoInteiro = 10 > 5 ? 1 : 0;

#endregion