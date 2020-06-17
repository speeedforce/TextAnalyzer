
using System.Collections.Generic;

namespace WebApplication1.ViewModels
{
    public class ModelMetricDTO
    {
        public ModelMetricDTO()
        {
            metrics = new List<MetricDTO>();
        }
        public List<MetricDTO> metrics { get; set; }
  
    }
}
