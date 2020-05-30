using System;
using Microsoft.AspNetCore.Mvc;

namespace B3.Menehune.Domain
{
    [Route("MenehuneState")]
    [ApiController]
    public class MenehuneStateController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetState()
        {
            return Ok(MenehuneState.Instance.ReturnStrategy.ToString());
        }

        [Route("{returnStrategyString}")]
        [HttpPost]
        public IActionResult SetReturnStrategy(string returnStrategyString)
        {
            var returnStrategy = Enum.Parse<ServiceReturnStrategies>(returnStrategyString);

            MenehuneState.Instance.ReturnStrategy = returnStrategy;
            return Ok($"Return strategy set to {returnStrategy}");
        }
    }
}
