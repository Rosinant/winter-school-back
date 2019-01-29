using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataService.Interfaces;
using Domain.Interfaces;
using Domain.Logic;
using Domain.Model;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace DataService
{
    /// <summary>
    /// Среда выполнения Service Fabric создает экземпляр этого класса для каждого экземпляра службы.
    /// </summary>
    public class DataService : StatelessService, IDataService
    {
        //Для DI подключен autofac
        private IRepository<Passport> _repository;

        public DataService(StatelessServiceContext context, IRepository<Passport> repository)
            : base(context)
        {
            _repository = repository;
        }

        public Task SavePassportAsync(Passport passport)
        {
            _repository.Create(passport);
            _repository.Save();
            return Task.FromResult(true);
        }

        /// <summary>
        /// Необязательное переопределение для создания прослушивателей (например, TCP, HTTP) для этой реплики службы, чтобы обрабатывать запросы клиентов или пользователей.
        /// </summary>
        /// <returns>Коллекция прослушивателей.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[0];
        }

        /// <summary>
        /// Это главная точка входа для экземпляра вашей службы.
        /// </summary>
        /// <param name="cancellationToken">Отменяется, когда Service Fabric нужно завершить работу этого экземпляра службы.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: замените приведенный ниже пример кода на свою логику 
            //       или удалите это переопределение RunAsync, если оно не нужно для вашей службы.

            long iterations = 0;

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                ServiceEventSource.Current.ServiceMessage(this.Context, "Working-{0}", ++iterations);

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }
    }
}
