using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper

    {
        // burası verdiğimiz passwordun hashini oluşturacak
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // out dışarıya verilecek değerlerdir
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                // key değeri bizim her kullanıcı için oluşturduğumuz bir kriptoğrafik anahtardır
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                // ComputeHash bizim verdiğimiz bir byte arrayini hashliyor
            }

        }

        // burası ise bizim verdiğimiz passwordun hashini doğrulayacak eşleşip eşleşmediğini kontrol edecek
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)

        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                // bizim verdiğimiz passwordun hashini oluşturuyor
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

            }

            return true;

        }
    }

}



 