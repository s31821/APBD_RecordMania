using API.Models;
using Task = API.Models.Task;

namespace API.DTOs;

public class RecordInfoResponseBody(int id,int languageId, Language language, int taskId, Task task, int studentId, Student student, long executionTime, DateTime createdAt)
{
    public int Id { get; } = id;
    public int LanguageId { get; } = languageId;
    public Language Language { get; } = language;
    public int TaskId { get; } = taskId;
    public Task Task { get; } = task;
    public int StudentId { get; } = studentId;
    public Student Student { get; } = student;
    public long ExecutionTime { get; } = executionTime;
    public DateTime CreatedAt { get; } = createdAt;
}