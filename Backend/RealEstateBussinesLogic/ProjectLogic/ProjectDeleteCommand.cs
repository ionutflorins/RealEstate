using RealEstateBussinesLogic.Interfaces.ProjectLogic;
using RealEstateDAL.Context;
using RealEstateDAL.Entities;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.ProjectLogic
{
    public class ProjectDeleteCommand : IProjectDeleteCommand
    {
        private RealEstateContext _dbContext;

        public ProjectDeleteCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Delete(int projectID)
        {
            Project projectExisting = null;

            using (var projectRep = new ProjectRepository(_dbContext))
            {
                projectExisting = projectRep
                   .GetWhere(x => x.ID == projectID)
                   .FirstOrDefault();
                if (projectExisting == null)
                {
                    return 0;
                }

                projectRep.Delete(projectExisting);
                _dbContext.SaveChanges();
            }
            return projectExisting.ID;
        }
    }
}
