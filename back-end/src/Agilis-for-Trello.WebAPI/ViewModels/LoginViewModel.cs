using DDS.WebAPI.Abstractions.ViewModels;

namespace Agilis_for_Trello.WebAPI.ViewModels
{
    /// <summary>
    /// Dados necessário para realizar o login
    /// </summary>
    public class LoginViewModel : IViewModel
    {
        /// <summary>
        /// Endereço de e-mail para login
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha para realizar o login
        /// </summary>
        public string Senha { get; set; }
    }
}
