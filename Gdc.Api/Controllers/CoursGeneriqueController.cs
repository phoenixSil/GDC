using Gdc.Api.Dtos.CoursGeneriques;
using Gdc.Api.Services.Contrats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;

namespace Gdc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursGeneriqueController : ControllerBase
    {
        private readonly IServiceDeCoursGenerique _service;
        private readonly ILogger<CoursGeneriqueController> _logger;
        public CoursGeneriqueController(IServiceDeCoursGenerique service, ILogger<CoursGeneriqueController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUnCoursGenerique(CoursGeneriqueACreerDto matiereACreer)
        {
            _logger.LogInformation($"Controller :: {nameof(AjouterUnCoursGenerique)} ");
            var result = await _service.AjouterUnCoursGenerique(matiereACreer);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<CoursGeneriqueDto>>> LireToutesLesCoursGeneriques()
        {
            _logger.LogInformation($"Controller :: {nameof(LireToutesLesCoursGeneriques)} ");
            var listeDeCoursGenerique = await _service.LireTousLesCoursGeneriques();
            if (listeDeCoursGenerique.Count == 0)
                return NoContent();
            return Ok(listeDeCoursGenerique);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CoursGeneriqueDetailDto>> LireInfoDuneCoursGenerique(Guid id)
        {
            _logger.LogInformation($"Controller :: {nameof(LireInfoDuneCoursGenerique)} ");
            var matiereDetail = await _service.LireUnCoursGenerique(id);

            if (matiereDetail == null)
                return NotFound();
            return Ok(matiereDetail);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUnCoursGenerique(Guid id, CoursGeneriqueAModifierDto matiereAModifierDto)
        {
            _logger.LogInformation($"Controller :: {nameof(ModifierUnCoursGenerique)} ");
            var resultat = await _service.ModifierUnCoursGenerique(id, matiereAModifierDto);
            return Ok(resultat);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> SupprimerUnCoursGenerique(Guid id)
        {
            _logger.LogInformation($"Controller :: {nameof(SupprimerUnCoursGenerique)} ");
            var resultat = _service.SupprimerUnCoursGenerique(id);
            return Ok(resultat);
        }
    }
}
