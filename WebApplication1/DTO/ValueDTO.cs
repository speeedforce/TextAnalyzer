
using System.Collections.Generic;

namespace WebApplication1.ViewModels
{
    public class ValueDTO
    {
        public ValueDTO()
        {
            compose = new List<ComposeValueDTO>();
        }
        public string? count { get; set; }

        public List<ComposeValueDTO>? compose { get; set; }
    }
}
