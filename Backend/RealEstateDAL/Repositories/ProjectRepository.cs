using Microsoft.EntityFrameworkCore;
using RealEstateDAL.Context;
using RealEstateDAL.Entities;
using RealEstateDAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDAL.Repositories
{
    public class ProjectRepository : GenericRepository<Project>
    {
        public ProjectRepository(RealEstateContext context) : base(context)
        {
        }

        public Project GetProject(int projectID)
        {
            return context.Projects.Find(projectID);
        }

        public void Insert(Project project)
        {
            dbSet.Add(project);
        }

        public void Delete(int projectID)
        {
            Project project = context.Projects.Find(projectID);
            context.Projects.Remove(project);
        }
        public void Update(Project project)
        {
            if (project != null)
            {
                context.Entry(project).State = EntityState.Modified;
            }
        }

    }
}
