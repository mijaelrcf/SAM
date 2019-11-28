using Service.ViewModels;

namespace Service.IServices
{
    public interface IAccountService
    {
        SignInStatus SignIn(string NombreUsuario, string Password, string Key, string VectorIni);
    }
}
