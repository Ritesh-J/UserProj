using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProj.Models.Domain;
using UserProj.Models.DTO;
using UserProj.Repository;

namespace UserProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository documentRepository;

        public DocumentController(IDocumentRepository documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        [HttpPost]
        [Route("Create_Document")]
        public IActionResult CreateDoc([FromBody] DocumentRequestDto requestDto)
        {
            try
            {
                var doc = documentRepository.CreateDocument(requestDto);
                if (doc == null) { return NotFound("User or Project Null"); }
                return Ok(doc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDocById([FromRoute] int id)
        {
            var doc = documentRepository.GetDoccumentById(id);
            if (doc == null) { return NotFound(); }
            return Ok(doc);
        }

        [HttpGet]
        public IActionResult GetAllDoc()
        {
            List<DocumentResponseDto> docs = documentRepository.GetAllDocument();
            return Ok(docs);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateDoc([FromRoute] int id, [FromBody] DocumentRequestDto requestDto)
        {
            var doc = documentRepository.UpdateDocument(id, requestDto);
            if (doc == null) { return NotFound(); }
            return Ok(doc);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDoc([FromRoute] int id)
        {
            var doc = documentRepository.DeleteDocument(id);
            if (doc == null) { return NotFound(); }
            return Ok();
        }
    }
}
