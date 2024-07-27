using System.Diagnostics;
using System.Numerics;

namespace RSAEncrypter.Helpers;
public static class PrimeHelper
{
    public static IEnumerable<BigInteger> CalculateCoprimes(BigInteger p, BigInteger q)
    {




        

        return [];
    }

    public static IEnumerable<BigInteger> CalculateNPrimes(int primeCount, int startingInteger = 1)
    {
        var result = new List<BigInteger>();
        var sw = new Stopwatch();
        long totalElapsedMS = 0;

        // Is this cheatin ? I feel like it is but I want ma while loop to be cleaner
        if (startingInteger <= 2)
            result.Add(2);

        int i = startingInteger;
        while (result.Count < primeCount)
        {
            if (i == 1)
            {
                i++; 
                continue;
            }

            sw.Reset();
            sw.Start();

            if(IsPrime_Fermat(i))
            {
                result.Add(i);
                Console.WriteLine($"Found prime[{result.Count} / {primeCount}]:  {i} in {sw.ElapsedMilliseconds}ms");
            }

            totalElapsedMS += sw.ElapsedMilliseconds;
            sw.Stop();

            i += i % 2 == 0 
                ? 1 
                : 2;
        }

        Console.WriteLine($"Found {primeCount} prime numbers in {totalElapsedMS}ms with an average of {totalElapsedMS / primeCount}ms per prime resolve");

        return result;
    }

    public static BigInteger CalculateNextPrime(BigInteger prime) => CalculateNPrimes(1, (int)prime + 1).First();

    public static bool IsPrime_Fermat(BigInteger number)
    {
        for (int j = 1; j < number; j++)
            if (BigInteger.ModPow(j, number - 1, number) != 1)
                return false;

        return true;
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
