using RSAEncrypter.Helpers;
using System.Numerics;
using System.Text;

var primeCount = 2000;

Console.WriteLine($"Calculating the first {primeCount} primes");

var primes = PrimeHelper.CalculateNPrimes(primeCount);

var allPrime = primes.All(PrimeHelper.IsPrime_Fermat);

Console.WriteLine($"All Prime Verification: {allPrime}");

Console.WriteLine($"n+1 prime: {PrimeHelper.CalculateNextPrime(primes.Last())}");

Console.ReadLine();



void RunRSAEncryption()
{
    Console.WriteLine("RSA Encrypter\n");

    int p = 7;
    int q = 19;
    var product = BigInteger.Multiply(p, q);
    var totient = (p - 1) * (q - 1);
    var publicKey = 29;
    var privateKey = 41;

    var message = "Remo";

    int message_bits = BitConverter.ToInt32(Encoding.UTF8.GetBytes(message), 0);

    var message_e = BigInteger.DivRem(BigInteger.Pow(message_bits, publicKey), product).Remainder;
    var message_d = BigInteger.DivRem(BigInteger.Pow(message_e, privateKey), product).Remainder;

    var decoded_message = Encoding.UTF8.GetString(message_d.ToByteArray());

    Console.WriteLine($"Message : {message} | bits: {message_bits}");
    Console.WriteLine($"Cipher : {message_e}");
    Console.WriteLine($"Decrypted Cipher: {message_d}");
    Console.WriteLine($"Decrypted Message : {decoded_message}");
}