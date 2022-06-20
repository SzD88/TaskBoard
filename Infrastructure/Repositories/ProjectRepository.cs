//using Domain.Entities;
//using Domain.Interfaces;
//using Infrastructure.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Repositories
//{
//    public class ProjectRepository : IProjectsRepository
//    {
//        private readonly ProjectManagerContext _context;
//        public ProjectRepository(ProjectManagerContext context)
//        {
//            _context = context;
//        }
//        public Task<Project> AddProject(Project project)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task Delete(Guid id)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task EditProject(Project project)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<IEnumerable<Project>> GetAllNotes()
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task MarkAsCompleted(bool completed)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
