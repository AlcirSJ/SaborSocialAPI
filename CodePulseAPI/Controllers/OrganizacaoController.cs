using Azure;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Models.DTO;
using CodePulseAPI.Repositories.Implementation;
using CodePulseAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CodePulseAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganizacaoController : Controller
{
    private readonly IOrganizacaoRepository _organizacaoRepository;

    public OrganizacaoController(IOrganizacaoRepository organizacaoRepository)
    {
        _organizacaoRepository = organizacaoRepository;
    }

    // POST: {apibaseurl}/api/Organizacao
    [HttpPost]
    public async Task<IActionResult> CreateOrganizacao([FromBody] Organizacao request)
    {
        var organizacao = await _organizacaoRepository.CreateAsync(request);
        return Ok(organizacao);
    }

    // Get: {apibaseurl}/api/Organizacao
    [HttpGet]
    public async Task<IActionResult> GetAllOrganizacao()
    {
        var organizacaos = await _organizacaoRepository.GetAllAsync();
        return Ok(organizacaos);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetByIdOrganizacao(Guid id)
    {
        var organizacao = await _organizacaoRepository.GetByIdAsync(id);
        return Ok(organizacao);
    }

    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> UpdateOrganizacaoById([FromRoute] Guid id, [FromBody] Organizacao request)
    {

        var organizacao = await _organizacaoRepository.UpdateByIdAsync(id, request);

        if (organizacao is null)
        {
            return NotFound();
        }

        return Ok(organizacao);
    }

    // Delete: {apibaseurl}/api/Eventos/{id}
    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> DeleteEventoById([FromRoute] Guid id)
    {
        var evento = await _organizacaoRepository.DeleteByIdAsync(id);
        return Ok(evento);
    }

}
