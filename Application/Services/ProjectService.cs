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
        private readonly ISubTaskRepository _subTasks;
        public ProjectService(IProjectRepository projectRepository, IMapper mapper, ISubTaskRepository subTaskRepository)  
        {
            _projects = projectRepository;
            _mapper = mapper;
            _subTasks = subTaskRepository;

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
            var project = await _projects.GetByIDAsync(id);

            var projectDtoType = _mapper.Map<ProjectDto>(project);


            var list = await _subTasks.CreateListOfTasks(project.Id);

            var mappedList = _mapper.Map<IEnumerable<SubTaskDto>>(list);

            foreach (var item in mappedList)
            {
                projectDtoType.MainTasks.Add(item);
            } 
            return projectDtoType;
        }

        public async Task UpdateAsync(UpdateProjectDto entityToUpdate)
        { 
            var projectType = _mapper.Map<Project>(entityToUpdate); 
            await _projects.UpdateAsync(projectType);
        }

        public async Task DeleteAllProjects() // just helper 
        {
            var allProjects = await _projects.GetAllAsync();

            foreach (var project in allProjects) 
            {
               await _projects.DeleteAsync(project);
            }
        }
    }
}
