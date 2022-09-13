using System;
using System.Collections.Generic;

public class Itens {
    public string Name {get; set;}
    public int Price {get; set;}
}

public class Tab {
    public List<Itens> Order {get; set;}
    public int Total {get; set;}
    public int Clients {get; set;}
    public List<string> Remove {get;set;}
}

public class Test
{
    public static Tab Table;
    public static int Remove = 0;
    public static void processInput(string input)
    {
        var arr = input.Split(' ');
        // temp object to store the itens
        Itens aux = new Itens {
            Name = arr[0],
            Price = Convert.ToInt32(arr[1])
        };
        Table.Order.Add(aux);
        Table.Total += aux.Price;
    }
    
    public static void processRemoveString(string input) {
        var arr = input.Split(' ');
        for (int i = 0; i < arr.Length; i++) {
            foreach (var item in Table.Order)
            {
                if (item.Name == arr[i]) {
                    Remove += item.Price;
                    break;
                }
            }
        }
    }

    public static void printResult() {
        // Valor total da conta
        Console.WriteLine(Table.Total);
        //valor total de cada cliente pela divisão comum
        Console.WriteLine((Table.Total - Remove) / Table.Clients);
        // itens desconsiderados da  divisão comum
        Console.WriteLine(Remove);
    }

    //Este e um exemplo de processamento de entradas (inputs), sinta-se a vontade para altera-lo conforme necessidade da questao.
    public static void Main()
    {
        Table = new Tab {
            Order = new List<Itens>(),
            Total = 0,
            Clients = 0,
            Remove = new List<string>()
        };
        string line;
        Table.Clients = Convert.ToInt32(Console.ReadLine());
        int itens = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < itens; i++) {
            line = Console.ReadLine();
            processInput(line);
        }
        processRemoveString(Console.ReadLine());
        printResult();
    }
}