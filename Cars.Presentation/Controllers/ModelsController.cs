using Cars.Contracts;
using Cars.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Presentation.Controllers
{
    [ApiController]
    [Route("api/Models")]
    public class ModelsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public ModelsController(IServiceManager serviceManager) => _serviceManager = serviceManager;
        [HttpGet]
        public async Task<IActionResult> GetModelsByBrandId (Guid brandId, CancellationToken cancellationToken)
        {
            var models = await _serviceManager.ModelService.GetAllByBrandIdAsync(brandId, cancellationToken);
            return Ok(models);
        }
        [HttpGet("{modelId:guid}")]
        public async Task<IActionResult> GetById (Guid modelId, CancellationToken cancellationToken)
        {
            var models = await _serviceManager.ModelService.GetByIdAsync(modelId, cancellationToken);
            return Ok(models);
        }
        [HttpPut("{modelId:guid}")]
        public async Task<IActionResult> UpdateMode(Guid brandId, Guid modelId, [FromBody] ModelUpdateDto modelUpdateDto, CancellationToken cancellationToken)
        {
            await _serviceManager.ModelService.UpdateAsync(brandId, modelId, modelUpdateDto, cancellationToken);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateModel(Guid brandId, [FromBody] ModelCreationDto modelCreationDto, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.ModelService.CreateAsync(brandId, modelCreationDto, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { modelId = response.Id }, response);
        }
        [HttpDelete("{modelId:guid}")]
        public async Task<IActionResult> RemoveModel(Guid brandId, Guid modelId, CancellationToken cancellationToken)
        {
            await _serviceManager.ModelService.RemoveAsync(brandId, modelId, cancellationToken);

            return NoContent();
        }
    }
}
