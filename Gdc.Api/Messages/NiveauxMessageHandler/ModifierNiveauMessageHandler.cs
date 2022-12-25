using AutoMapper;
using Gdc.Api.Messages.HandlersMessages;
using Gdc.Features.Contrats.Services;
using MassTransit;
using MsCommun.Messages.Niveaux;
using MsCommun.Messages.Utils;
using Microsoft.Extensions.Logging;
using Gdc.Features.Dtos.Niveaux;

namespace Gdc.Api.Messages.NiveauxMessageHandler
{
    public class ModifierNiveauMessageHandler : IConsumer<NiveauAModifierMessage>
    {
        private readonly IServiceDeNiveau _service;
        private readonly IMapper _mapper;
        private readonly ILogger<AjouterNiveauMessageHandler> _logger;

        public ModifierNiveauMessageHandler(ILogger<AjouterNiveauMessageHandler> logger, IServiceDeNiveau service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<NiveauAModifierMessage> context)
        {
            var niveauMessage = context.Message;
            
            if (niveauMessage.Service == DesignationService.SERVICE_GESC)
            {
                if (niveauMessage.Type == TypeMessage.MODIFICATION)
                {
                    _logger.LogInformation("On a recu un message de modification de Niveau dans le Bus, on vas le traiter Dans Gdc !!");
                    NiveauDetailDto niveau = await _service.LireNiveauParNumeroExterne(niveauMessage.NumeroExterne);
                    var dto = _mapper.Map<NiveauAModifierDto>(niveauMessage);
                    await _service.ModifierUnNiveau(niveau.Id, dto).ConfigureAwait(false);
                    _logger.LogInformation("BUS => GdC: Le niveau a Ete bien Ajouter  !!");

                }
            }
        }
    }
}
