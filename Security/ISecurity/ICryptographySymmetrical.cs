using Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.ISecurity
{
    public interface ICryptographySymmetrical
    {
        EncryptDecryptResponseModel EncryptionDecrypting(EncryptDecryptRequestModel encryptDecryptRequest);
    }
}
