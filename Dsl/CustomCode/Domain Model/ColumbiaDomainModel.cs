using Columbia.Dsl.CustomRules.DomainClasses;
using Columbia.Dsl.CustomRules.DomainRelationships;
using System;
using System.Collections.Generic;

namespace Columbia.Dsl
{
    public partial class ColumbiaDomainModel
    {
        protected override Type[] GetCustomDomainModelTypes()
        {
            List<Type> types = new List<Type>(base.GetCustomDomainModelTypes());

            #region Domain Class Rules

            //Entity
            types.Add(typeof(EntityAddRule));
            types.Add(typeof(EntityChangeRule));
            types.Add(typeof(EntityDeletingRule));

            //EntityProperty
            types.Add(typeof(EntityPropertyChangeRule));
            types.Add(typeof(EntityPropertyDeletingRule));

            #endregion

            #region Domain Relashionships Rules

            //DomainEntityCollectionReferencesDomainEntities
            types.Add(typeof(EntityReferencesTargetEntitiesAddRule));
            types.Add(typeof(EntityReferencesTargetEntitiesDeletingRule));

            #endregion

            return types.ToArray();
        }
    }
}
