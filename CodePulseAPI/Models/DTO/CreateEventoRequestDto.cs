﻿namespace CodePulseAPI.Models.DTO;

public class CreateEventoRequestDto
{
    public string Name { get; set; }
    public string Person { get; set; }
    public string Organization { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public string Identification { get; set; }
    public string Ong { get; set; }
    public long ValidationCode { get; set; }
    public string FoodType { get; set; }
    public long Kg { get; set; }
}
