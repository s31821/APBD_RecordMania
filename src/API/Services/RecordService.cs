using API.DTOs;
using API.Models;
using API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class RecordService : IRecordService
{
    private readonly ApplicationDbContext context;

    public RecordService(ApplicationDbContext context)
    {
        this.context = context;
    }
    
    public async Task<IEnumerable<Record>> GetAllRecordsAsync(string? filterBy, string? filterString)
    {
        IOrderedQueryable<Record> result;
        if (!string.IsNullOrEmpty(filterBy) && !string.IsNullOrEmpty(filterString))
        {
            List<string> filterOptions = ["creationdate", "languageid", "taskid"];
            filterBy = filterBy.ToLower();
            if (!filterOptions.Contains(filterBy))
            {
                throw new ArgumentException("Invalid filter option");
            }

            result = filterBy switch
            {
                "creationdate" => context.Record.Where(d => d.CreatedAt == DateTime.Parse(filterString))
                    .OrderByDescending(d => d.CreatedAt).ThenBy(d => d.Student.LastName),
                "languageid" => context.Record.Where(d => d.LanguageId.ToString() == filterString)
                    .OrderByDescending(d => d.CreatedAt).ThenBy(d => d.Student.LastName),
                "taskid" => context.Record.Where(d => d.TaskId.ToString() == filterString)
                    .OrderByDescending(d => d.CreatedAt).ThenBy(d => d.Student.LastName)
            };
        }
        else
        {
            result = context.Record.OrderByDescending(d => d.CreatedAt).ThenBy(d => d.Student.LastName);
        }

        return await result.ToListAsync();
    }

    public async Task<CreatedRecordResponseBody> CreateNewRecordAsync(CreateRecordRequestBody requestBody)
    {
        var foundRecord = await context.Record.FirstAsync(d => d.StudentId == requestBody.StudentId && d.TaskId == requestBody.TaskId);
        if (foundRecord != null)
        {
            throw new ArgumentException("Record already exists");
        }

        Record newRecord = new()
        {
            Id = context.Record.Count() + 1,
            CreatedAt = requestBody.CreatedAt,
            ExecutionTime = requestBody.ExecutionTime,
            LanguageId = requestBody.LanguageId,
            StudentId = requestBody.StudentId,
            TaskId = requestBody.TaskId,
            Language = context.Language.First(l => l.Id == requestBody.LanguageId),
            Task = context.Task.First(t => t.Id == requestBody.TaskId),
            Student = context.Student.First(s => s.Id == requestBody.StudentId)
        };
        await context.Record.AddAsync(newRecord);
        await context.SaveChangesAsync();
        
        return new CreatedRecordResponseBody(newRecord.Id, newRecord.LanguageId, newRecord.TaskId, newRecord.LanguageId, newRecord.TaskId, newRecord.CreatedAt, newRecord.StudentId);
    }
}