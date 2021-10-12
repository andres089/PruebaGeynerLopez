using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Prueba.Transversal
{
    public static class Seguridad
    {
        // se define el tamaño del key y del vector
        private static readonly int tamanyoClave = 32;
        private static readonly int tamanyoVector = 16;

        // Define la palabra clave para el cifrado y
        private static readonly string Clave = "CADFJKJASDJCERNJKDAKADKR";
        private static readonly string Vector = "5454ASKASDMER454ERE";

        // se convierte el vector y la key a bytes
        public static byte[] Key = UTF8Encoding.UTF8.GetBytes(Clave);
        public static byte[] IV = UTF8Encoding.UTF8.GetBytes(Vector);

        public static string Encriptar(string txtPlano)

        {
            Array.Resize(ref Key, tamanyoClave);
            Array.Resize(ref IV, tamanyoVector);

            // se instancia el Rijndael
            Rijndael RijndaelAlg = Rijndael.Create();

            // se establece cifrado
            MemoryStream memoryStream = new MemoryStream();

            // se crea el flujo de datos de cifrado
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                RijndaelAlg.CreateEncryptor(Key, IV),
                CryptoStreamMode.Write);

            // se obtine la información a cifrar
            byte[] txtPlanoBytes = UTF8Encoding.UTF8.GetBytes(txtPlano);

            // se cifran los datos
            cryptoStream.Write(txtPlanoBytes, 0, txtPlanoBytes.Length);
            cryptoStream.FlushFinalBlock();

            // se obtinen los datos cifrados
            byte[] cipherMessageBytes = memoryStream.ToArray();

            // se cierra todo
            memoryStream.Close();
            cryptoStream.Close();

            // Se devuelve la cadena cifrada
            return Convert.ToBase64String(cipherMessageBytes);
        }
    }
}
