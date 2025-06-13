using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/api/records")]
public class RecordController : ControllerBase
{
    private readonly IRecordService _recordService;

    public RecordController(IRecordService recordService)
    {
        _recordService = recordService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllRecords([FromQuery] string? filterBy, string? filterString)
    {
        try
        {
            return Ok(await _recordService.GetAllRecordsAsync(filterBy, filterString));
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateNewRecord([FromBody] CreateRecordRequestBody requestBody)
    {
        try
        {
            var result = await _recordService.CreateNewRecordAsync(requestBody);
            return Created("created-record" + result.Id, result);
        }
        catch (KeyNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}