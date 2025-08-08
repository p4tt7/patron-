public static class Solution
{
    public static int Solve(bool[,] matrix, int i, int j)
    {
        int minPasos = int.MaxValue;
        bool[,] encendidos = new bool[matrix.GetLength(0), matrix.GetLength(1)];
        EncenderInicio(matrix, encendidos);
        Solver(matrix, i, j, encendidos, 0, ref minPasos);

        if (minPasos == int.MaxValue)
        {
            return -1;
        }

        return minPasos;
    }

    public static void Solver(bool[,] matrix, int i, int j, bool[,] encendidos, int pasos, ref int minPasos)
    {
        if (pasos >= minPasos) return;

        if (AllTurnedOn(encendidos))
        {
            minPasos = Math.Min(pasos, minPasos);
            return;
        }

        int[] dx = { 0, 1, 1, 0, -1, -1, 1, -1 };
        int[] dy = { 1, 0, 1, -1, 0, -1, -1, 1 };

        for (int dir = 0; dir < dx.Length; dir++)
        {
            int dirX = dx[dir];
            int dirY = dy[dir];

            int maxPasos = Math.Max(matrix.GetLength(0), matrix.GetLength(1));

            for (int pasito = 1; pasito < maxPasos; pasito++)
            {
                int newX = i + dirX * pasito;
                int newY = j + dirY * pasito;

                if (!IsInBorders(matrix, newX, newY)) break;
                if (encendidos[newX, newY]) continue;

                bool[,] encendidosAhora = CopiarArray(encendidos);
                Encender(encendidosAhora, i, j, pasito, dirX, dirY);
                Solver(matrix, newX, newY, encendidosAhora, pasos+1, ref minPasos);
                
            }
        }
    }

    public static bool[,] CopiarArray(bool[,] encendidos)
    {
        bool[,] copia = new bool[encendidos.GetLength(0), encendidos.GetLength(1)];

        for (int i = 0; i < copia.GetLength(0); i++)
        {
            for(int j = 0; j < copia.GetLength(1); j++)
            {
                if (encendidos[i, j])
                {
                    copia[i, j] = true;
                }
            }
        }

        return copia;
    }

    public static void Encender(bool[,] encendidos, int i, int j, int pasos, int dirX, int dirY)
    {
        for (int p = 0; p <= pasos; p++)
        {
            int newX = i + dirX * p;
            int newY = j + dirY * p;

            if(IsInBorders(encendidos, newX, newY))
            {
                encendidos[newX, newY] = true;
            }
            
        }

    }

    public static void EncenderInicio(bool[,] matrix, bool[,] encendidos)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = 0; j < matrix.GetLength(1);j++)
            {
                if(matrix[i,j] == true)
                {
                    encendidos[i,j] = true;
                }
            }
        }
    }

    public static bool AllTurnedOn(bool[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                if(matrix[i,j] == false) return false;  
            }
        }

        return true;
    }

    public static bool IsInBorders(bool[,] matrix, int i, int j)
    { 
        int largo = matrix.GetLength(0);
        int ancho = matrix.GetLength(1);

        return i>=0 && j>=0 && i<largo && j<ancho;
    }

}
