using API.DTOs;
using API.Models;

namespace API.Services;

public interface IRecordService
{
    Task<IEnumerable<Record>> GetAllRecordsAsync(string? filterBy, string? filterString);
    Task<CreatedRecordResponseBody> CreateNewRecordAsync(CreateRecordRequestBody requestBody);
}