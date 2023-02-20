namespace Application.Commands
{
    public record UpdateDay(
      Guid Id,
      DateTime DayDate,
      string Title,
      string Description,
      bool Completed
      );
}


 
