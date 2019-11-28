using Entities.Models;
using Repository.Pattern.Repositories;
using Repository.Repositories;
using Security.ISecurity;
using Security.Models;
using Service.IServices;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepositoryAsync<Usuario> _repositoryUsuario;
        private readonly ICryptographySymmetrical _cryptographySymmetrical;

        public AccountService(IRepositoryAsync<Usuario> repositoryUsuario, ICryptographySymmetrical cryptographySymmetrical) 
        {
            _repositoryUsuario = repositoryUsuario;
            _cryptographySymmetrical = cryptographySymmetrical;
        }

        public SignInStatus SignIn(string NombreUsuario, string Password, string Key, string VectorIni)
        {
            SignInStatus status = SignInStatus.Failure;
            //AlgorithmEncryption algorithm = AlgorithmEncryption.AES;

            //EncryptDecryptRequestModel encryptDecryptRequest = new EncryptDecryptRequestModel()
            //{
            //    Mode = ModeEncryptDecrypt.Encryption,
            //    Algorithm = AlgorithmEncryption.DES,
            //    TextToEncrypt = Password,
            //    Key = Key,
            //    VectorInicial = VectorIni
            //};


            //var res = _cryptographySymmetrical.EncryptionDecrypting(encryptDecryptRequest);

            var result = _repositoryUsuario.UsersByUserName(NombreUsuario);
            if(result.Count() > 0)
            {
                EncryptDecryptRequestModel encryptDecryptRequest = new EncryptDecryptRequestModel()
                {
                    Mode = ModeEncryptDecrypt.Decrypting,
                    Algorithm = AlgorithmEncryption.DES,
                    TextToDecrypt = result.FirstOrDefault().Password,
                    Key = Key,
                    VectorInicial = VectorIni
                };

                EncryptDecryptResponseModel encryptDecryptResponse = _cryptographySymmetrical.EncryptionDecrypting(encryptDecryptRequest);

                switch (encryptDecryptResponse.Result)
                {
                    case EncryptDecryptResult.Success:
                        if (Password.Equals(encryptDecryptResponse.TextDecrypt))
                        {
                            status = SignInStatus.Success;
                        }
                        else
                        {
                            status = SignInStatus.Failure;
                        }
                            
                        break;
                    case EncryptDecryptResult.Failure:
                        status = SignInStatus.Failure;
                        break;
                }
                                
                //if (result.FirstOrDefault().Password.Equals(Password))
                //status = SignInStatus.Success;
            }

            return status;
        }
    }
}
