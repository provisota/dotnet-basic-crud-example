using BasicCrud.Api.Dtos;
using BasicCrud.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrud.Api.Controllers
{
    /// <summary>
    /// Addresses CRUD controller.
    /// </summary>
    [ApiController]
    [Route("addresses")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressesController(IAddressService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<AddressDto>>> GetAll(CancellationToken ct)
            => Ok(await _service.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AddressDto>> GetById(int id, CancellationToken ct)
        {
            var address = await _service.GetByIdAsync(id, ct);
            return address is null ? NotFound() : Ok(address);
        }

        [HttpPost]
        public async Task<ActionResult<AddressDto>> Create([FromBody] UpsertAddressDto dto, CancellationToken ct)
        {
            var created = await _service.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AddressDto>> Update(int id, [FromBody] UpsertAddressDto dto, CancellationToken ct)
        {
            var updated = await _service.UpdateAsync(id, dto, ct);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var ok = await _service.DeleteAsync(id, ct);
            return ok ? NoContent() : NotFound();
        }
    }
}
