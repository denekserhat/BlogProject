using Microsoft.AspNetCore.Http;

namespace Entities.Dtos
{
    public class NoteInsertModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string PhotoUrl { get; set; }
        public IFormFile File { get; set; }
        public string PublicId { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }
    }
}