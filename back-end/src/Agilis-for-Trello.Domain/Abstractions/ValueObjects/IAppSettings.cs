namespace Agilis_for_Trello.Domain.Abstractions.ValueObjects
{
    /// <summary>
    /// Application settings interface, used to enable dependency injection
    /// </summary>
    public interface IAppSettings
    {
        /// <summary>
        /// Private key, used in encryption algorithms
        /// </summary>
        public string Segredo { get; set; }
    }
}
