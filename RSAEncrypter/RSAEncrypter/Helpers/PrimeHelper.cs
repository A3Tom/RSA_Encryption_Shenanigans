using System.Diagnostics;
using System.Numerics;

namespace RSAEncrypter.Helpers;
public static class PrimeHelper
{
    public static IEnumerable<BigInteger> CalculateCoprimes(BigInteger p, BigInteger q)
    {




        

        return [];
    }

    public static IEnumerable<BigInteger> CalculateNPrimes_Fermat(int primeCount)
    {
        var result = new List<BigInteger>();

        var sw = new Stopwatch();
        
        int i = 1;
        long totalElapsedMS = 0;

        while (result.Count < primeCount)
        {
            sw.Reset();
            sw.Start();

            for (int j = 1; j < i; j++)
            {
                if (BigInteger.DivRem(BigInteger.Pow(j, i - 1), i).Remainder != 1)
                    break;

                if(j == i - 1)
                {

                    Console.WriteLine($"Found prime[{result.Count} / {primeCount}]:  {i} in {sw.ElapsedMilliseconds}ms");
                    totalElapsedMS += sw.ElapsedMilliseconds;

                    result.Add(i);
                }
            }

            sw.Stop();

            i += 2;
        }

        Console.WriteLine($"Found {primeCount} prime numbers in {totalElapsedMS}ms with an average of {totalElapsedMS / primeCount}ms per prime resolve");

        return result;
    }

    public static BigInteger CalculateTotient(BigInteger p, BigInteger q) => BigInteger.Multiply(p - 1, q - 1);

    public static BigInteger Sqrt(this BigInteger n)
    {
        if (n == 0) return 0;
        if (n > 0)
        {
            int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
            BigInteger root = BigInteger.One << (bitLength / 2);

            while (!isSqrt(n, root))
            {
                root += n / root;
                root /= 2;
            }

            return root;
        }

        throw new ArithmeticException("NaN");
    }

    private static Boolean isSqrt(BigInteger n, BigInteger root)
    {
        BigInteger lowerBound = root * root;
        BigInteger upperBound = (root + 1) * (root + 1);

        return (n >= lowerBound && n < upperBound);
    }
}
