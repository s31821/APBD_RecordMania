namespace API.DTOs;

public class CreateRecordRequestBody(int languageId, int taskId, int studentId, long executionTime, DateTime createdAt)
{
    public int LanguageId { get; } = languageId;
    public int TaskId { get; } = taskId;
    public int StudentId { get; } = studentId;
    public long ExecutionTime { get; } = executionTime;
    public DateTime CreatedAt { get; } = createdAt;
}