using Gdc.Features.Dtos.Matieres;
using Gdc.Features.Contrats.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;

namespace Gdc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatiereController : ControllerBase
    {
        private readonly IServiceDeMatiere _service;
        private readonly ILogger<MatiereController> _logger;
        public MatiereController(IServiceDeMatiere service, ILogger<MatiereController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUneMatiere(MatiereACreerDto matiereACreer)
        {
            _logger.LogInformation($"Controller :: {nameof(AjouterUneMatiere)} ");
            var result = await _service.AjouterUneMatiere(matiereACreer);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<MatiereDto>>> LireToutesLesMatieres()
        {
            _logger.LogInformation($"Controller :: {nameof(LireToutesLesMatieres)} ");
            var listeDeMatiere = await _service.LireToutesLesMatieres();
            if (listeDeMatiere.Count == 0)
                return NoContent();
            return Ok(listeDeMatiere);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MatiereDetailDto>> LireInfoDuneMatiere(Guid id)
        {
            _logger.LogInformation($"Controller :: {nameof(LireInfoDuneMatiere)} ");
            var matiereDetail = await _service.LireUneMatiere(id);

            if (matiereDetail == null)
                return NotFound();
            return Ok(matiereDetail);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUneMatiere(Guid id, MatiereAModifierDto matiereAModifierDto)
        {
            _logger.LogInformation($"Controller :: {nameof(ModifierUneMatiere)} ");
            var resultat = await _service.ModifierUneMatiere(id, matiereAModifierDto);
            return Ok(resultat);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> SupprimerUneMatiere(Guid id)
        {
            _logger.LogInformation($"Controller :: {nameof(SupprimerUneMatiere)} ");
            var resultat = await _service.SupprimerUneMatiere(id);
            return StatusCode(resultat.StatusCode, resultat);
        }
    }
}
