using AutoMapper;
using Gdc.Features.Dtos.Enseignants;
using Gdc.Api.Messages.HandlersMessages;
using Gdc.Features.Contrats.Services;
using MassTransit;
using MsCommun.Messages.Enseignants;
using MsCommun.Messages.Utils;
using Microsoft.Extensions.Logging;
using Gdc.Application.Services;

namespace Gdc.Api.Messages.EnseignantsMessageHandler
{
    public class SupprimerEnseignantMessageHandler: IConsumer<EnseignantASupprimerMessage>
    {
        private readonly IServiceDenseignant _service;
        private readonly ILogger<AjouterEnseignantMessageHandler> _logger;

        public SupprimerEnseignantMessageHandler(ILogger<AjouterEnseignantMessageHandler> logger, IServiceDenseignant service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<EnseignantASupprimerMessage> context)
        {
            _logger.LogInformation("On vas entamer la suppresion dun Enseignant A Partir du message recu du Bus ");
            
            var enseignantMessage = context.Message;
            if (enseignantMessage.Service == DesignationService.SERVICE_GEENS)
            {
                if (enseignantMessage.Type == TypeMessage.SUPPRESSION)
                {
                    EnseignantDto enseignant = await _service.LireEnseignantParNumeroExterne(enseignantMessage.Id);

                    if(enseignant is not null)
                    {
                        await _service.SupprimerUnEnseignant(enseignant.Id).ConfigureAwait(false);
                        _logger.LogInformation("BUS => GdC: Le enseignant a Ete bien supprimer  !!");
                    }
                    else
                    {
                        _logger.LogWarning("BUS => GdC: Lenseignant nexiste pas  !!");
                    }

                }
            }
        }
    }
}
