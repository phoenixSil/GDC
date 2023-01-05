using AutoMapper;
using Gdc.Features.Dtos.Enseignants;
using Gdc.Features.Contrats.Services;
using MassTransit;
using MsCommun.Messages.Enseignants;
using MsCommun.Messages.Utils;

namespace Gdc.Api.Messages.HandlersMessages
{
    public class AjouterEnseignantMessageHandler: IConsumer<EnseignantACreerMessage>
    {
        private readonly IServiceDenseignant _service;
        private readonly IMapper _mapper;
        private readonly ILogger<AjouterEnseignantMessageHandler> _logger;

        public AjouterEnseignantMessageHandler(ILogger<AjouterEnseignantMessageHandler> logger, IServiceDenseignant service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<EnseignantACreerMessage> context)
        {
            var enseignantMessage = context.Message;
            if (enseignantMessage.Service == DesignationService.SERVICE_GEENS)
            {
                if (enseignantMessage.Type == TypeMessage.CREATION)
                {
                    _logger.LogInformation("On a recu un message dajout de Enseignant dans le Bus, on vas le traiter Dans Gdc !!");
                    var dto = _mapper.Map<EnseignantACreerDto>(enseignantMessage);
                    await _service.AjouterUnEnseignant(dto).ConfigureAwait(false);

                    _logger.LogInformation("BUS => GdC: Le enseignant a Ete bien Ajouter  !!");
                }
            }
        }
    }
}
