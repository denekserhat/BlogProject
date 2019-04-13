using Microsoft.AspNetCore.Http;

namespace Entities.Dtos
{
    public class CategoryInsertModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public IFormFile File { get; set; }
        public string PublicId { get; set; }

    }
}