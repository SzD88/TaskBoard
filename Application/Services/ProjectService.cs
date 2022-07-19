using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;


namespace Application.Services
{
    public class ProjectService : IProjectService  
    {
        private readonly IProjectRepository _projects;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository projectRepository, IMapper mapper)  
        {
            _projects = projectRepository;
            _mapper = mapper;
        }
        public async Task<ProjectDto> CreateAsync(CreateProjectDto project)
        {
            var asProjectType = _mapper.Map<Project>(project);
            var created = await _projects.CreateAsync(asProjectType);
            return _mapper.Map<ProjectDto>(created);
        }

        public async Task DeleteAsync(object id)
        {
            var guid = (Guid)id;
            var toDelete = await _projects.GetByIDAsync(guid);
            await _projects.DeleteAsync(toDelete);

        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var allNotes = await _projects.GetAllAsync();
            return _mapper.Map<IEnumerable<ProjectDto>>(allNotes);
        }

        public async Task<ProjectDto> GetByIDAsync(object id)
        {
            var subTask = await _projects.GetByIDAsync(id);
             
            var list = await _projects.CreateListOfMainTasks(subTask.Id);
             
            var subTaskDtoType = _mapper.Map<ProjectDto>(subTask);
            
            foreach (var item in list)
            {
                subTaskDtoType.MainTasks.Add(item);
            } 
            return subTaskDtoType;
        }

        public Task UpdateAsync(UpdateProjectDto entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
