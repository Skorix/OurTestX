using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Crypt
{
    public class Crypto
    {
        public static string hash = "!?%:((**.I.$$";
        public static void Enc(string o_path, string s_path)
        {
            string s;
            StreamWriter sw = new StreamWriter(s_path);
            StreamReader sr = new StreamReader(o_path);
            while ((s = sr.ReadLine()) != null)
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(s);

                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider TripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = TripDes.CreateEncryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        sw.WriteLine(Convert.ToBase64String(results, 0, results.Length));
                    }

                }

            }
            sw.Close();
        }

        public static string[] Dec(string o_path)
        {
            string s;
            StreamReader srr = new StreamReader(o_path);
            var r = new List<string>();
            while ((s = srr.ReadLine()) != null)
            {
                byte[] data = Convert.FromBase64String(s);

                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider TripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = TripDes.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        r.Add(UTF8Encoding.UTF8.GetString(results));
                    }
                }
            }
            string[] ss = r.ToArray();
            return ss;
        }
    }
}
