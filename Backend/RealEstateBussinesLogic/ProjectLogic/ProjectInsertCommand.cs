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
    public class ProjectInsertCommand : IProjectInsertCommand
    {
        private RealEstateContext _dbContext;

        public ProjectInsertCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(ProjectEdit projectEdit)
        {
            var project = new Project();
            var projectRep = new ProjectRepository(_dbContext);
            var projectExisting = projectRep
                .GetWhere(d => d.ProjectName == projectEdit.ProjectName)
                .ToList();
            project.ID = projectEdit.ID;
            project.ProjectName = projectEdit.ProjectName;
            project.City = projectEdit.City;
            project.Address = projectEdit.Address;
            project.BuildingsNo = projectEdit.BuildingsNo;
            project.ApartmentNo = projectEdit.ApartmentNo;
            project.HouseNo = projectEdit.HouseNo;
            project.Description = projectEdit.Description;
            project.DeveloperID = projectEdit.DeveloperID;

            if(projectExisting == null || projectExisting.Count <= 0)
            {
                projectRep.Insert(project);
                _dbContext.SaveChanges();
            }
            return project.ID;
        }
    }
}
