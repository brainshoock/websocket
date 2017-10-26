
namespace TestApplication.Server.Contracts
{
    public interface ITestServer
    {
        /// <summary>
        /// Запуск сервиса.
        /// </summary>
        void Start();
        /// <summary>
        /// Остановка сервиса.
        /// </summary>
        void Stop();
    }
}
