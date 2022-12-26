using Gdc.Features.Dtos.Enseignants;
using Gdc.Features.Contrats.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;
using Polly.Caching;

namespace Gdc.Api.Controllers
{
    [Route("api/Cours/[controller]")]
    [ApiController]
    public class EnseignantController : ControllerBase
    {
        private readonly IServiceDenseignant _service;
        private readonly ILogger<EnseignantController> _logger;
        public EnseignantController(IServiceDenseignant service, ILogger<EnseignantController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUnEnseignant(EnseignantACreerDto enseignantACreer)
        {
            _logger.LogInformation($"Controller :: {nameof(AjouterUnEnseignant)} ");
            var result = await _service.AjouterUnEnseignant(enseignantACreer);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<EnseignantDto>>> LireToutesLesEnseignants()
        {
            _logger.LogInformation($"Controller :: {nameof(LireToutesLesEnseignants)} ");
            var listeDeEnseignant = await _service.LireTousLesEnseignants();
            if (listeDeEnseignant.Count == 0)
                return NoContent();
            return Ok(listeDeEnseignant);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EnseignantDetailDto>> LireInfoDuneEnseignant(Guid id)
        {
            _logger.LogInformation($"Controller :: {nameof(LireInfoDuneEnseignant)} ");
            var enseignantDetail = await _service.LireUnEnseignant(id);

            if (enseignantDetail is null)
                return NotFound();
            return Ok(enseignantDetail);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUnEnseignant(Guid id, EnseignantAModifierDto enseignantAModifierDto)
        {
            _logger.LogInformation($"Controller :: {nameof(ModifierUnEnseignant)} ");
            var resultat = await _service.ModifierUnEnseignant(id, enseignantAModifierDto);
            return StatusCode(resultat.StatusCode, resultat);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> SupprimerUnEnseignant(Guid id)
        {
            _logger.LogInformation($"Controller :: {nameof(SupprimerUnEnseignant)} ");
            var resultat = await _service.SupprimerUnEnseignant(id);
            return StatusCode(resultat.StatusCode, resultat);
        }

        [HttpDelete("numExterne/{mumeroExterne}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> SupprimerParNumeroExterne(Guid mumeroExterne)
        {
            _logger.LogInformation($"Controller :: {nameof(SupprimerParNumeroExterne)} ");
            var resultat = await _service.SupprimerParNumeroExterne(mumeroExterne);
            return StatusCode(resultat.StatusCode, resultat);
        }
    }
}
