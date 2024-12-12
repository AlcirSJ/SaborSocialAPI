using CodePulseAPI.Models.Domain;
using CodePulseAPI.Models.DTO;
using CodePulseAPI.Repositories.Implementation;
using CodePulseAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace CodePulseAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventosController : ControllerBase
{
    private readonly IEventosRepository _eventosRepository;
   
    public EventosController(IEventosRepository eventosRepository)
    {
        _eventosRepository = eventosRepository;        
    }
    // POST: {apibaseurl}/api/Eventos
    [HttpPost]
    public async Task<IActionResult> CreateEvento([FromBody] CreateEventoRequestDto request)
    {
        //Dto to domain model
        var evento = new Evento
        {
            Name = request.Name,
            Person = request.Person,
            Organization = request.Organization,
            Date = request.Date,
            Location = request.Location,
            Description = request.Description,
            Ong = request.Ong,
            ValidationCode = request.ValidationCode,
            FoodType = request.FoodType,
            Kg =  request.Kg,
            Identification = request.Identification
        };



        evento = await _eventosRepository.CreateAsync(evento);

        //Domain model to Dto
        var response = new EventoDto
        {
            Name = evento.Name,
            Person = evento.Person,
            Organization = evento.Organization,
            Date = evento.Date,
            Location = evento.Location,
            Description = evento.Description,
            Ong = evento.Ong,
            ValidationCode = evento.ValidationCode,
            FoodType = evento.FoodType,
            Kg = evento.Kg,
            Identification = evento.Identification
        };

        return Ok(response);
    }

    // GET: {apibaseurl}/api/Eventos
    [HttpGet]    
    public async Task<IActionResult> GetAllCreateEvento()
    {
        var eventos = await _eventosRepository.GetAllAsync();

        var response = new List<EventoDto>();
        foreach (var evento in eventos)
        {
            response.Add(new EventoDto
            {
                Name = evento.Name,
                Person = evento.Person,
                Organization = evento.Organization,
                Date = evento.Date,
                Location = evento.Location,
                Description = evento.Description,
                Ong = evento.Ong,
                ValidationCode = evento.ValidationCode,
                FoodType = evento.FoodType,
                Kg = evento.Kg
            });
        }
     

        return Ok(response);
    }

    // GET: {apibaseurl}/api/Eventos/{id}
    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetEventoById([FromRoute] Guid id)
    {

        var evento = await _eventosRepository.GetByIdAsync(id);

        if (evento is null)
        {
            return NotFound();
        }

        var response = new EventoDto
        {
            Name = evento.Name,
            Person = evento.Person,
            Organization = evento.Organization,
            Date = evento.Date,
            Location = evento.Location,
            Description = evento.Description,
            Ong = evento.Ong,
            ValidationCode = evento.ValidationCode,
            FoodType = evento.FoodType,
            Kg = evento.Kg
        };

        return Ok(response);
    }

    // Delete: {apibaseurl}/api/Eventos/{id}
    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> DeleteEventoById([FromRoute] Guid id)
    {
        var evento = await _eventosRepository.DeleteByIdAsync(id);
        return Ok(evento);
    }
}
