using System;

class Program
{
    static void Main()
    {
        int[] primos = GerarNumerosPrimos(100);
        
        Console.WriteLine("Digite um número primo para buscar:");
        int numeroAlvo = int.Parse(Console.ReadLine());

        int indice = BuscaBinaria(primos, numeroAlvo);

        if (indice != -1)
        {
            Console.WriteLine($"{numeroAlvo} encontrado no índice {indice}.");
        }
        else
        {
            Console.WriteLine($"{numeroAlvo} não encontrado na lista de números primos até 100.");
        }
    }
    static int[] GerarNumerosPrimos(int limite)
    {
        bool[] numeros = new bool[limite + 1];
        for (int i = 2; i <= limite; i++)
        {
            numeros[i] = true;
        }

        for (int p = 2; p * p <= limite; p++)
        {
            if (numeros[p])
            {
                for (int i = p * p; i <= limite; i += p)
                {
                    numeros[i] = false;
                }
            }
        }

        int count = 0;
        for (int i = 2; i <= limite; i++)
        {
            if (numeros[i])
            {
                count++;
            }
        }

        int[] primos = new int[count];
        int index = 0;
        for (int i = 2; i <= limite; i++)
        {
            if (numeros[i])
            {
                primos[index] = i;
                index++;
            }
        }

        return primos;
    }

    static int BuscaBinaria(int[] array, int alvo)
    {
        int esquerda = 0;
        int direita = array.Length - 1;

        while (esquerda <= direita)
        {
            int meio = (esquerda + direita) / 2;

            if (array[meio] == alvo)
            {
                return meio;
            }
            else if (array[meio] < alvo)
            {
                esquerda = meio + 1;
            }
            else
            {
                direita = meio - 1;
            }
        }

        return -1; 
    }
}

