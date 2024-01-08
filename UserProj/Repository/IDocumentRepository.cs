using UserProj.Models.Domain;
using UserProj.Models.DTO;

namespace UserProj.Repository
{
    public interface IDocumentRepository
    {
        Document CreateDocument(DocumentRequestDto requestDto);
        DocumentResponseDto? GetDoccumentById(int Id);
        List<DocumentResponseDto>? GetAllDocument();
        Document? UpdateDocument(int Id, DocumentRequestDto requestDto);
        Document? DeleteDocument(int Id);
    }
}
