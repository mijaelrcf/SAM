using Security.ISecurity;
using Security.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Security.Security
{
    public class CryptographySymmetrical : ICryptographySymmetrical
    {
        public EncryptDecryptResponseModel EncryptionDecrypting(EncryptDecryptRequestModel encryptDecryptRequest)
        {
            EncryptDecryptResponseModel encryptDecryptResponse = new EncryptDecryptResponseModel();
            try
            {                
                byte[] plaintext = null;

                if (encryptDecryptRequest.Mode == ModeEncryptDecrypt.Encryption)
                    plaintext = Encoding.Default.GetBytes(encryptDecryptRequest.TextToEncrypt);
                else if (encryptDecryptRequest.Mode == ModeEncryptDecrypt.Decrypting)
                    plaintext = Convert.FromBase64String(encryptDecryptRequest.TextToDecrypt);


                byte[] keys = Encoding.Default.GetBytes(encryptDecryptRequest.Key);
                MemoryStream memdata = new MemoryStream();
                ICryptoTransform transform = null;

                switch (encryptDecryptRequest.Algorithm)
                {
                    case AlgorithmEncryption.DES:
                        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                        des.Mode = CipherMode.CBC;
                        switch (encryptDecryptRequest.Mode)
                        {
                            case ModeEncryptDecrypt.Encryption:
                                transform = des.CreateEncryptor(keys, Encoding.Default.GetBytes(encryptDecryptRequest.VectorInicial));
                                break;

                            case ModeEncryptDecrypt.Decrypting:
                                transform = des.CreateDecryptor(keys, Encoding.Default.GetBytes(encryptDecryptRequest.VectorInicial));

                                break;
                        }
                        //if (encryptDecryptRequest.Mode == ModeEncryptDecrypt.Encryption)
                        //    transforma = des.CreateEncryptor(keys, Encoding.Default.GetBytes(encryptDecryptRequest.VectorInicial));
                        //else if (encryptDecryptRequest.Mode == ModeEncryptDecrypt.Decrypting)
                        //    transforma = des.CreateDecryptor(keys, Encoding.Default.GetBytes(encryptDecryptRequest.VectorInicial));

                        break;

                    case AlgorithmEncryption.TripleDES:
                        TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider();
                        des3.Mode = CipherMode.CBC;
                        if (encryptDecryptRequest.Mode == ModeEncryptDecrypt.Encryption)
                            transform = des3.CreateEncryptor(keys, Encoding.Default.GetBytes(encryptDecryptRequest.VectorInicial));
                        else if (encryptDecryptRequest.Mode == ModeEncryptDecrypt.Decrypting)
                            transform = des3.CreateDecryptor(keys, Encoding.Default.GetBytes(encryptDecryptRequest.VectorInicial));

                        break;

                    case AlgorithmEncryption.RC2:
                        RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();
                        rc2.Mode = CipherMode.CBC;
                        if (encryptDecryptRequest.Mode == ModeEncryptDecrypt.Encryption)
                            transform = rc2.CreateEncryptor(keys, Encoding.Default.GetBytes(encryptDecryptRequest.VectorInicial));
                        else if (encryptDecryptRequest.Mode == ModeEncryptDecrypt.Decrypting)
                            transform = rc2.CreateDecryptor(keys, Encoding.Default.GetBytes(encryptDecryptRequest.VectorInicial));

                        break;

                    case AlgorithmEncryption.Rijndael:
                        RijndaelManaged rj = new RijndaelManaged();
                        rj.Mode = CipherMode.CBC;
                        if (encryptDecryptRequest.Mode == ModeEncryptDecrypt.Encryption)
                            transform = rj.CreateEncryptor(keys, Encoding.Default.GetBytes(encryptDecryptRequest.VectorInicial));
                        else if (encryptDecryptRequest.Mode == ModeEncryptDecrypt.Decrypting)
                            transform = rj.CreateDecryptor(keys, Encoding.Default.GetBytes(encryptDecryptRequest.VectorInicial));

                        break;

                    case AlgorithmEncryption.AES:
                        AesManaged aes = new AesManaged();
                        aes.Mode = CipherMode.CBC;

                        if (encryptDecryptRequest.Mode == ModeEncryptDecrypt.Encryption)
                            transform = aes.CreateEncryptor(keys, Encoding.Default.GetBytes(encryptDecryptRequest.VectorInicial));
                        else if (encryptDecryptRequest.Mode == ModeEncryptDecrypt.Decrypting)
                            transform = aes.CreateDecryptor(keys, Encoding.Default.GetBytes(encryptDecryptRequest.VectorInicial));

                        break;
                }

                CryptoStream encstream = new CryptoStream(memdata, transform, CryptoStreamMode.Write);
                encstream.Write(plaintext, 0, plaintext.Length);

                encstream.FlushFinalBlock();
                encstream.Close();

                switch (encryptDecryptRequest.Mode)
                {
                    case ModeEncryptDecrypt.Encryption:
                        encryptDecryptResponse.TextEncrypt = Convert.ToBase64String(memdata.ToArray());
                        encryptDecryptResponse.Result = EncryptDecryptResult.Success;
                        encryptDecryptResponse.Mensaje = "Encrypt " + encryptDecryptRequest.Mode.ToString() + "Success";
                        break;

                    case ModeEncryptDecrypt.Decrypting:
                        encryptDecryptResponse.TextDecrypt = Encoding.Default.GetString(memdata.ToArray());
                        encryptDecryptResponse.Result = EncryptDecryptResult.Success;
                        encryptDecryptResponse.Mensaje = "Decrypt " + encryptDecryptRequest.Mode.ToString() + "Success";
                        break;
                }
            }
            catch (Exception e)
            {
                encryptDecryptResponse.TextDecrypt = string.Empty;
                encryptDecryptResponse.Result = EncryptDecryptResult.Failure;
                encryptDecryptResponse.Mensaje = "Ocurrio un error, Exception Message: " + e.Message + "InnerException: " + e.InnerException;
            }

            return encryptDecryptResponse;
        }
    }
}
