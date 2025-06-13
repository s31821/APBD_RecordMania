namespace API.DTOs;

public class CreatedRecordResponseBody(int id, int languageId, int taskId, int studentId, long executionTime, DateTime createdAt)
{
    public int Id { get; } = id;
    public int LanguageId { get; } = languageId;
    public int TaskId { get; } = taskId;
    public int StudentId { get; } = studentId;
    public long ExecutionTime { get; } = executionTime;
    public DateTime CreatedAt { get; } = createdAt;
}