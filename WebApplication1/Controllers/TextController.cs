using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextController : Controller
    {
        private readonly ITextService _textService;

        public TextController(ITextService textService)
        {
            _textService = textService;
        }

        [HttpPost("metrics")]
        public IActionResult CalculateMetrics([FromBody] ViewModels.RequestDTO input)
        {
            var metrics = Analyze(input.text);
            return Ok(metrics);
        }


        private ModelMetricDTO Analyze(string input)
        {
            var result = new ModelMetricDTO();

            result.metrics.Add(MapKeyPairToDTO(_textService.CountAllSymbols(input)));
            result.metrics.Add(MapKeyPairToDTO(_textService.CountSymbolsWithoutWhiteSpace(input)));
            result.metrics.Add(MapKeyPairToDTO(_textService.NumbersCount(input)));
            result.metrics.Add(MapDictionaryToDTO(_textService.TopChars(input, 5)));
            result.metrics.Add(MapDictionaryToDTO(_textService.TopWords(input, 5)));
            return result;

        }

        private MetricDTO MapDictionaryToDTO(KeyValuePair<string, Dictionary<string, int>> keyPair)
        {
            var dto = new MetricDTO
            {
                title = keyPair.Key,
                value = new ValueDTO()
                {
                    compose = keyPair.Value.Select(pair => new ComposeValueDTO()
                    {
                        text = pair.Key, count = pair.Value.ToString()
                    }).ToList()
                }
            };
            return dto;
        }

        private MetricDTO MapKeyPairToDTO(KeyValuePair<string, int> metrics)
        {
            return new MetricDTO()
            {
                title = metrics.Key,
                value = new ValueDTO { count = metrics.Value.ToString() }
            };
        }
    }
}