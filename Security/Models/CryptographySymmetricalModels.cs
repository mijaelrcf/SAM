using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Models
{
    class CryptographySymmetricalModels
    {
    }

    //
    // Summary:
    //     Type of Encryption Algorithms
    public enum AlgorithmEncryption
    {
        //
        // Summary:
        //     DES Encryption Algorithm
        DES = 0,
        //
        // Summary:
        //     TripleDES Encryption Algorithm
        TripleDES = 1,
        //
        // Summary:
        //     RC2 Encryption Algorithm
        RC2 = 2,
        //
        // Summary:
        //     Rijndael Encryption Algorithm
        Rijndael = 3,

        //
        // Summary:
        //     AES Encryption Algorithm
        AES = 4
    }

    //
    // Summary:
    //     Encryption or Decrypting Mode 
    public enum ModeEncryptDecrypt
    {
        //
        // Summary:
        //     Encryption Mode
        Encryption = 0,
        //
        // Summary:
        //     Decrypting Mode
        Decrypting = 1,
    }
    public class EncryptDecryptRequestModel
    {
        public ModeEncryptDecrypt Mode { get; set; }
        public AlgorithmEncryption Algorithm { get; set; }
        public string TextToEncrypt { get; set; }
        public string TextToDecrypt { get; set; }
        public string Key { get; set; }
        public string VectorInicial { get; set; }
    }

    public class EncryptDecryptResponseModel
    {
        public EncryptDecryptResult Result { get; set; }
        public string TextEncrypt { get; set; }
        public string TextDecrypt { get; set; }
        public string Mensaje { get; set; }
    }

    public enum EncryptDecryptResult
    {
        Failure = 0,
        Success = 1
    }
}
