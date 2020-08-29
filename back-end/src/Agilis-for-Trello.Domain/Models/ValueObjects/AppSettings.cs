using Agilis_for_Trello.Domain.Abstractions.ValueObjects;

namespace Agilis_for_Trello.Domain.Models.ValueObjects
{
    /// <summary>
    /// Class of application settings
    /// </summary>
    public class AppSettings : IAppSettings
    {
        /// <summary>
        /// Private key, used in encryption algorithms
        /// </summary>
        public string Segredo { get; set; }
    }
}
