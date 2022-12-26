using AutoMapper;
using Gdc.Api.Messages.HandlersMessages;
using Gdc.Features.Contrats.Services;
using MassTransit;
using MsCommun.Messages.Enseignants;
using MsCommun.Messages.Utils;
using Microsoft.Extensions.Logging;
using Gdc.Features.Dtos.Enseignants;
using Gdc.Application.Services;

namespace Gdc.Api.Messages.EnseignantsMessageHandler
{
    public class ModifierEnseignantMessageHandler : IConsumer<EnseignantAModifierMessage>
    {
        private readonly IServiceDenseignant _service;
        private readonly IMapper _mapper;
        private readonly ILogger<AjouterEnseignantMessageHandler> _logger;

        public ModifierEnseignantMessageHandler(ILogger<AjouterEnseignantMessageHandler> logger, IServiceDenseignant service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<EnseignantAModifierMessage> context)
        {
            var enseignantMessage = context.Message;
            
            if (enseignantMessage.Service == DesignationService.SERVICE_GEENS)
            {
                if (enseignantMessage.Type == TypeMessage.MODIFICATION)
                {
                    _logger.LogInformation("On a recu un message de modification de Enseignant dans le Bus, on vas le traiter Dans Gdc !!");
                    EnseignantDto enseignant = await _service.LireEnseignantParNumeroExterne(enseignantMessage.NumeroExterne);
                    var dto = _mapper.Map<EnseignantAModifierDto>(enseignantMessage);
                    await _service.ModifierUnEnseignant(enseignant.Id, dto).ConfigureAwait(false);
                    _logger.LogInformation("BUS => GdC: Le enseignant a Ete bien Ajouter  !!");

                }
            }
        }
    }
}
