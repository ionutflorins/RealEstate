using RealEstateBussinesLogic.Interfaces;
using RealEstateBussinesLogic.Interfaces.PropertyLogic;
using RealEstateBussinesLogic.Models.Property;
using RealEstateDAL.Context;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.PropertyLogic
{
    public class PropertyGetCommand : IPropertyGetCommand
    {
        private RealEstateContext _dbContext;

        public PropertyGetCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<PropertyListView> GetAllProperty()
        {
            var propertyRep = new PropertyRepository(_dbContext);
            var propertyList = propertyRep.GetAll();
            var propertyListModel = propertyList
                .Select(x => new PropertyListView { ID = x.ID, Price = x.Price, Type = x.Type, IdentityNo = x.IdentityNo, BuildingNo = x.BuildingNo, LotSqm = x.LotSqm, PropertySqm = x.PropertySqm, RoomNo = x.RoomNo })
                .ToList();
            return propertyListModel;
        }
    }
}
