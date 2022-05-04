using RealEstateBussinesLogic.Interfaces.ProjectLogic;
using RealEstateBussinesLogic.Models.Project;
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
    public class ProjectUpdateCommand : IProjectUpdateCommand
    {
        private RealEstateContext _dbContext;

        public ProjectUpdateCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Update(ProjectEdit projectEdit)
        {
            Project projectExisting = null;
            using (var projectRep = new ProjectRepository(_dbContext))
            {
                projectExisting = projectRep
                   .GetWhere(d => d.ID == projectEdit.ID)
                   .FirstOrDefault();

                if (projectExisting == null)
                {
                    return 0;
                }

                projectExisting.ProjectName = projectEdit.ProjectName;
                projectExisting.City = projectEdit.City;
                projectExisting.Address = projectEdit.Address;
                projectExisting.BuildingsNo = projectEdit.BuildingsNo;
                projectExisting.ApartmentNo = projectEdit.ApartmentNo;
                projectExisting.HouseNo = projectEdit.HouseNo;
                projectExisting.Description = projectEdit.Description;
                projectExisting.DeveloperID = projectEdit.DeveloperID;

                projectRep.Update(projectExisting);
                _dbContext.SaveChanges();
            }
            return projectExisting.ID;

        }
    }
}
