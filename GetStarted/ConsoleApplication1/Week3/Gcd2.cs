using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
//using System.Numerics;
using System.Text;

// (?°?°)????????????????????????????
public class Solver {
    private const int MOD = 1000000007;
    private const int SIEVE_SIZE = 15000000;
    private readonly bool[] isComposite = new bool[SIEVE_SIZE + 1];
    void Sieve() {
        for(int i = 2; i * i <= SIEVE_SIZE; i++)
            if(!isComposite[i])
                for(int j = i * i; j <= SIEVE_SIZE; j += i)
                    isComposite[j] = true;
    }

    long Pow(long x, long y) {
        long ret = 1;
        while(y > 0) {
            if((y & 1) == 1)
                ret = ret * x % MOD;
            x = x * x % MOD;
            y >>= 1;
        }
        return ret;
    }

    long Fun(int prime, long n, long m) {
        if(n < prime || m < prime)
            return 1;

        return Pow(prime, (n / prime) * (m / prime)) * Fun(prime, n / prime, m / prime) % MOD;
    }

    public object Solve() {
        Sieve();

        int n = ReadInt();
        int m = ReadInt();
        int min = Math.Min(n, m);
        long ret = 1;
        for(int i = 2; i <= min; i++)
            if(!isComposite[i])
                ret = ret * Fun(i, n, m) % MOD;
        return ret;
    }

    #region Main

    protected static TextReader reader;
    protected static TextWriter writer;

    static void MainSolver() {
#if DEBUG
        reader = new StreamReader("..\\..\\input.txt");
        writer = Console.Out;
        //writer = new StreamWriter("..\\..\\output.txt");
#else
        reader = Console.In;
        writer = Console.Out;
#endif
        try {
            object result = new Solver().Solve();
            if(result != null)
                writer.WriteLine(result);
        }
        catch(Exception ex) {
#if DEBUG
            Console.WriteLine(ex);
#else
            throw;
#endif
        }
        reader.Close();
        writer.Close();
    }

    #endregion

    #region Read/Write

    private static Queue<string> currentLineTokens = new Queue<string>();

    private static string[] ReadAndSplitLine() {
        return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
    }

    public static string ReadToken() {
        while(currentLineTokens.Count == 0)
            currentLineTokens = new Queue<string>(ReadAndSplitLine());
        return currentLineTokens.Dequeue();
    }

    public static int ReadInt() {
        return int.Parse(ReadToken());
    }

    public static long ReadLong() {
        return long.Parse(ReadToken());
    }

    public static double ReadDouble() {
        return double.Parse(ReadToken(), CultureInfo.InvariantCulture);
    }

    public static int[] ReadIntArray() {
        return ReadAndSplitLine().Select(int.Parse).ToArray();
    }

    public static long[] ReadLongArray() {
        return ReadAndSplitLine().Select(long.Parse).ToArray();
    }

    public static double[] ReadDoubleArray() {
        return ReadAndSplitLine().Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
    }

    public static int[][] ReadIntMatrix(int numberOfRows) {
        int[][] matrix = new int[numberOfRows][];
        for(int i = 0; i < numberOfRows; i++)
            matrix[i] = ReadIntArray();
        return matrix;
    }

    public static string[] ReadLines(int quantity) {
        string[] lines = new string[quantity];
        for(int i = 0; i < quantity; i++)
            lines[i] = reader.ReadLine().Trim();
        return lines;
    }

    public static void WriteArray<T>(IEnumerable<T> array) {
        writer.WriteLine(string.Join(" ", array));
    }

    #endregion
}