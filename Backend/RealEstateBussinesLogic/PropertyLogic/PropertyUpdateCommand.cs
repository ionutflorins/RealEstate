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
    public class PropertyUpdateCommand : IPropertyUpdateCommand
    {
        private RealEstateContext _dbContext;

        public PropertyUpdateCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Edit(PropertyEdit propertyEdit)
        {
            Property propertyExisting = null;
            using (var propertyRep = new PropertyRepository(_dbContext))
            {
                propertyExisting = propertyRep
                   .GetWhere(d => d.ID == propertyEdit.ID)
                   .FirstOrDefault();

                if (propertyExisting == null)
                {
                    return 0;
                }

                propertyExisting.Type = propertyEdit.Type;
                propertyExisting.Price = propertyEdit.Price;
                propertyExisting.RoomNo = propertyEdit.RoomNo;
                propertyExisting.IdentityNo = propertyEdit.IdentityNo;
                propertyExisting.BuildingNo = propertyEdit.BuildingNo;
                propertyExisting.PropertySqm = propertyEdit.PropertySqm;
                propertyExisting.LotSqm = propertyEdit.LotSqm;
                propertyExisting.Description = propertyEdit.Description;
                propertyExisting.ProjectID = propertyEdit.ProjectID;

                propertyRep.Update(propertyExisting);
                _dbContext.SaveChanges();
            }
            return propertyExisting.ID;
        }
    }
}
