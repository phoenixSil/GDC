using Gdc.Api.Dtos.Enseignants;
using Gdc.Api.Services.Contrats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;

namespace Gdc.Api.Controllers
{
    [Route("api/[controller]")]
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
            return Ok(result);
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

            if (enseignantDetail == null)
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
            return Ok(resultat);
        }

        [HttpPut("numExterne/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUnEnseignant(Guid id, EnseignantAModifierDeGdeDto enseignantAModifierDto)
        {
            _logger.LogInformation($"Controller :: {nameof(ModifierUnEnseignant)} ");
            var resultat = await _service.ModifierUnEnseignantParNumeroExterne(id, enseignantAModifierDto);
            return Ok(resultat);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> SupprimerUnEnseignant(Guid id)
        {
            _logger.LogInformation($"Controller :: {nameof(SupprimerUnEnseignant)} ");
            var resultat = _service.SupprimerUnEnseignant(id);
            return Ok(resultat);
        }

        [HttpDelete("numExterne/{mumeroExterne}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> SupprimerParNumeroExterne(Guid mumeroExterne)
        {
            _logger.LogInformation($"Controller :: {nameof(SupprimerParNumeroExterne)} ");
            var resultat = await _service.SupprimerParNumeroExterne(mumeroExterne);
            return Ok(resultat);
        }
    }
}
