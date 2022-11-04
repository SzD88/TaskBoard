namespace Application.Commands
{
    public record UpdateProject(
      Guid Id,
      string ProjectNumber,
      string Title,
      string Description,
      bool Completed
      );
}


 
