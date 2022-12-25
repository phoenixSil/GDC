using AutoMapper;
using Gdc.Features.Dtos.Niveaux;
using Gdc.Api.Messages.HandlersMessages;
using Gdc.Features.Contrats.Services;
using MassTransit;
using MsCommun.Messages.Niveaux;
using MsCommun.Messages.Utils;
using Microsoft.Extensions.Logging;

namespace Gdc.Api.Messages.NiveauxMessageHandler
{
    public class SupprimerNiveauMessageHandler: IConsumer<NiveauASupprimerMessage>
    {
        private readonly IServiceDeNiveau _service;
        private readonly ILogger<AjouterNiveauMessageHandler> _logger;

        public SupprimerNiveauMessageHandler(ILogger<AjouterNiveauMessageHandler> logger, IServiceDeNiveau service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<NiveauASupprimerMessage> context)
        {
            _logger.LogInformation("On vas entamer la suppresion dun Niveau A Partir du message recu du Bus ");
            
            var niveauMessage = context.Message;
            if (niveauMessage.Service == DesignationService.SERVICE_GESC)
            {
                if (niveauMessage.Type == TypeMessage.SUPPRESSION)
                {
                    NiveauDetailDto niveau = await _service.LireNiveauParNumeroExterne(niveauMessage.NumeroExterne);

                    if(niveau is  not null)
                    {
                        await _service.SupprimerUnNiveau(niveau.Id).ConfigureAwait(false);
                        _logger.LogInformation("BUS => GdC: Le niveau a Ete bien supprimer  !!");
                    }
                    else
                    {
                        _logger.LogInformation("BUS => GdC: Le niveau nexiste pas  !!");
                    }
                    

                }
            }
        }
    }
}
