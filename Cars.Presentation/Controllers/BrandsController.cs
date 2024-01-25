using Cars.Contracts;
using Cars.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Presentation.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public BrandsController(IServiceManager serviceManager) => _serviceManager = serviceManager;
        [HttpGet]
        public async Task<IActionResult> GetBrands(CancellationToken cancellationToken)
        {
            var brands = await _serviceManager.BrandService.GetAllAsync(cancellationToken);
            return Ok(brands);
        }
        [HttpGet("{brandId:guid}")]
        public async Task<IActionResult> GetBrandById(Guid brandId, CancellationToken cancellationToken)
        {
            var brandDto = await _serviceManager.BrandService.GetByIdAsync(brandId, cancellationToken);
            return Ok(brandDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] BrandCreationDto brandCreationDto)
        {
            var brandDto = await _serviceManager.BrandService.CreateAsync(brandCreationDto);
            return CreatedAtAction(nameof(GetBrandById), new { brandId = brandDto.Id }, brandDto);
        }
        [HttpPut("{brandId:guid}")]
        public async Task<IActionResult> UpdateBrand(Guid brandId, [FromBody] BrandUpdateDto brandUpdateDto, CancellationToken cancellationToken)
        {
            await _serviceManager.BrandService.UpdateAsync(brandId, brandUpdateDto, cancellationToken);
            return NoContent();
        }
        [HttpDelete("{brandId:guid}")]
        public async Task<IActionResult> DeleteBrand(Guid brandId, CancellationToken cancellationToken)
        {
            await _serviceManager.BrandService.RemoveAsync(brandId, cancellationToken);
            return NoContent();
        }
    }
}
