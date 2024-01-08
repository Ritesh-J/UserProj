using UserProj.Data;
using UserProj.Models.Domain;
using UserProj.Models.DTO;

namespace UserProj.Repository
{
    public class DocumentRepositoryImpl : IDocumentRepository
    {
        private readonly UserProjDbContext dbContext;

        public DocumentRepositoryImpl(UserProjDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Document CreateDocument(DocumentRequestDto requestDto)
        { 

            var document = new Document
            {
                Name = requestDto.Name,
                UserId = requestDto.UserId,
                ProjectId = requestDto.ProjectId,
            };
            dbContext.Add(document);
            dbContext.SaveChanges();
            return document;
        }

        public Document? DeleteDocument(int Id)
        {
            var doc=dbContext.Documents.FirstOrDefault(x => x.Id == Id);
            if (doc == null) return null;
            dbContext.Remove(doc);
            dbContext.SaveChanges() ;
            return doc;
        }

        public List<DocumentResponseDto>? GetAllDocument()
        {
            List<Document> documents= dbContext.Documents.ToList();
            List<DocumentResponseDto> requestDtos = new List<DocumentResponseDto>();
            foreach (var document in documents)
            {
                DocumentResponseDto documentResponseDto = new DocumentResponseDto
                {
                    Name= document.Name,
                    Id= document.Id,
                    ProjectId= document.ProjectId,
                    UserId= document.UserId,
                };
                requestDtos.Add(documentResponseDto);
            }
            return requestDtos;
        }

        public DocumentResponseDto? GetDoccumentById(int Id)
        {
            var document = dbContext.Documents.FirstOrDefault(x => x.Id == Id);
            if (document == null) return null;
            DocumentResponseDto documentResponseDto = new DocumentResponseDto
            {
                Name = document.Name,
                Id = document.Id,
                ProjectId = document.ProjectId,
                UserId = document.UserId,
            };
            return documentResponseDto;

        }

        public Document? UpdateDocument(int Id, DocumentRequestDto requestDto)
        {
            var doc = dbContext.Documents.FirstOrDefault(x => x.Id == Id);
            if (doc == null) return null;
            doc.Name = requestDto.Name;
            doc.UserId = requestDto.UserId;
            doc.ProjectId = requestDto.ProjectId;
            dbContext.SaveChanges();
            return doc;
        }
    }
}
