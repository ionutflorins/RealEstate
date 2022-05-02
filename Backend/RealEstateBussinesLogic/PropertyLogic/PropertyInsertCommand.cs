using RealEstateBussinesLogic.Interfaces.PropertyLogic;
using RealEstateBussinesLogic.Models.Property;
using RealEstateDAL.Context;
using RealEstateDAL.Entities;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.PropertyLogic
{
    public class PropertyInsertCommand : IPropertyInsertCommand
    {
        private RealEstateContext _dbContext;

        public PropertyInsertCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(PropertyEdit propertyEdit)
        {
            var property = new Property();
            var propertyRep = new PropertyRepository(_dbContext);
            var propertyExisting = propertyRep
                .GetWhere(d => d.IdentityNo == propertyEdit.IdentityNo)
                .ToList();
            property.ID = propertyEdit.ID;
            property.Type = propertyEdit.Type;
            property.Price = propertyEdit.Price;
            property.RoomNo = propertyEdit.RoomNo;
            property.IdentityNo = propertyEdit.IdentityNo;
            property.BuildingNo = propertyEdit.BuildingNo;
            property.PropertySqm = propertyEdit.PropertySqm;
            property.LotSqm = propertyEdit.LotSqm;
            property.Description = propertyEdit.Description;
            property.ProjectID = propertyEdit.ProjectID;

            if(propertyExisting == null || propertyExisting.Count <=0)
            {
                propertyRep.Insert(property);
                _dbContext.SaveChanges();
            }
            return property.ID;
        }
    }
}
