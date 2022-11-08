namespace Application.Commands
{
    public record UpdateSubTask(
      Guid Id,
      string Content,
      bool Completed,
      Guid LevelAboveId 
      );
}


