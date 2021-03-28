using PgpCore;
using System;
using System.IO;

namespace TesteCSharp.Assistant
{
    public class Cripto
    {
        string appfolder = @Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Rodrigo's_Stuff\Ficha\";
        public void GenKey()
        {
            //Definir aqui o usuario e a senha
            string user = "username123";
            string password = "password";

            //As chaves vão ser geradas em
            //  C:\Users\%user%\AppData\Roaming\Rodrigo's_Stuff\Ficha\


            if(!Directory.Exists(appfolder))
            {
                Directory.CreateDirectory(appfolder);
            }

            PGP pgp = new PGP();
            pgp.GenerateKey(appfolder + "public.asc", appfolder +"private.asc", user,password);
        }
        /// <summary>
        /// encrypt a file based on the existing key
        /// </summary>
        /// <param name="inputFilePath">the path for the file to be encrypted</param>
        /// <param name="outputFilePath">the path for the new encrypted file</param>
        public void EncryptFile(string inputFilePath, string outputFilePath)
        {
            if (!File.Exists(appfolder + "public.asc"))
            {
                GenKey();
            };
            FileInfo publicKey = new FileInfo(appfolder + "public.asc");
            EncryptionKeys encryptionKeys = new EncryptionKeys(publicKey);

            FileInfo inputFile = new FileInfo(inputFilePath);
            FileInfo outputFile = new FileInfo(outputFilePath);

            PGP pgp = new PGP(encryptionKeys);
            pgp.EncryptFile(inputFile, outputFile);
        }
        /// <summary>
        /// Sign the document
        /// </summary>
        /// <param name="inputFilePath">The path to the file that will be signed</param>
        /// <param name="outputFilePath">The path to the signed file</param>
        /// <param name="password">The password for the signature</param>
        public void SignFile(string inputFilePath, string outputFilePath, string password)
        {
            if (!File.Exists(appfolder + "private.asc"))
            {
                GenKey();
            };

            //load the keys
            FileInfo privateKey = new FileInfo(@appfolder + "private.asc");
            EncryptionKeys encryptionKeys = new EncryptionKeys(privateKey,password);

            //input output
            FileInfo inputFile = new FileInfo(@inputFilePath);
            FileInfo outputFile = new FileInfo(outputFilePath);

            //assinar
            PGP pgp = new PGP(encryptionKeys);
            pgp.SignFile(inputFile, outputFile);
        }
        /// <summary>
        /// Sign a plain text string
        /// </summary>
        /// <param name="inputString">The string to be signed</param>
        /// <param name="password">The password used to sign</param>
        /// <returns>The signed string</returns>
        public string SignString(string inputString, string password)
        {
            //load the key
            FileInfo privateKey = new FileInfo(appfolder + "private.asc");
            EncryptionKeys encryptionKeys = new EncryptionKeys(privateKey, password);

            PGP pgp = new PGP(encryptionKeys);

            return pgp.SignArmoredString(inputString);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="password"></param>
        public void DecryptFile(string inputFilePath, string outputFilePath, string password)
        {
            //load keys
            FileInfo privateKey = new FileInfo(appfolder + "private.asc");
            EncryptionKeys encryptionKeys = new EncryptionKeys(privateKey, password);

            //in out
            FileInfo inputFile = new FileInfo(@inputFilePath);
            FileInfo outputFile = new FileInfo(@outputFilePath);

            //decrypt
            PGP pgp = new PGP(encryptionKeys);
            pgp.DecryptFile(inputFile, outputFile);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <returns></returns>
        public bool VerifySign(string inputFilePath)
        {
            FileInfo publicKey = new FileInfo(appfolder + "public.asc");
            EncryptionKeys encryptionKeys = new EncryptionKeys(publicKey);

            FileInfo inputfile = new FileInfo(@inputFilePath);

            PGP pgp = new PGP(encryptionKeys);
            return pgp.VerifyFile(inputfile);
        }
    }
}
