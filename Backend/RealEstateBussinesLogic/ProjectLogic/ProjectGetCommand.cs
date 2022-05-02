using RealEstateBussinesLogic.Interfaces.ProjectLogic;
using RealEstateBussinesLogic.Models.Project;
using RealEstateDAL.Context;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.ProjectLogic
{
    public class ProjectGetCommand : IProjectGetCommand
    {
        private RealEstateContext _dbContext;

        public ProjectGetCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<ProjectListView> GetAllProject()
        {
            var projectRep = new ProjectRepository(_dbContext);
            var projectList = projectRep.GetAll();
            var projectListModel = projectList
                .Select(x => new ProjectListView { ID = x.ID, ProjectName = x.ProjectName, Address = x.Address, ApartmentNo = x.ApartmentNo, BuildingsNo = x.BuildingsNo, City = x.City, HouseNo = x.HouseNo, Description = x.Description, DeveloperID = x.DeveloperID })
                .ToList();
            return projectListModel;
        }
    }
}
