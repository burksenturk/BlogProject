using Microsoft.AspNetCore.Http;

namespace BlogProjectUI.Models
{
    public class AddprofileImage
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WiterPassword { get; set; }
        public bool WriterStatus { get; set; }
    }
}
