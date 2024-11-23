using Columbia.Dsl.Utils;
using Microsoft.VisualStudio.Modeling;

namespace Columbia.Dsl.CustomRules.DomainRelationships
{
    [RuleOn(typeof(EntityReferencesTargetEntities))]
    public class EntityReferencesTargetEntitiesAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            if (!(e.ModelElement is EntityReferencesTargetEntities link)) return;

            if (GlobalVariables.Model_EntityReferencesTargetEntities_IsAdding == CommonConstants.Booleans.True)
            {
                string entityReferencesTargetEntitiesId = GlobalVariables.EntityReferencesTargetEntitiesId;
                link.EntityReferencesTargetEntitiesId = entityReferencesTargetEntitiesId;
            }
            else
            {
                base.ElementAdded(e);

                var targetEntity = link.TargetEntity;
                var sourceEntity = link.SourceEntity;

                if (targetEntity == null || sourceEntity == null) return;
                if (targetEntity.EntityProperties == null) return;


                var entityId = targetEntity.EntityId;
                var entityPropertyIdNumber = CommonFunctions.GetMaxEntityPropertyId(targetEntity) + 1;
                var entityPropertyId = CommonFunctions.GetStringId(entityPropertyIdNumber, CommonConstants.Numbers.Five);

                entityPropertyId = string.Concat(entityId, entityPropertyId);

                var sourceEntityName = sourceEntity.Name;
                var entityPropertyNameIdNumber = CommonFunctions.GetEntityPropertiesCountByType(targetEntity, sourceEntityName) + 1;
                var entityPropertyName = string.Concat(sourceEntityName, entityPropertyNameIdNumber.ToString());
                var propertyAssignments = new PropertyAssignment[5];

                propertyAssignments[0] = new PropertyAssignment(EntityProperty.EntityIdDomainPropertyId, entityId);
                propertyAssignments[1] = new PropertyAssignment(EntityProperty.EntityPropertyIdDomainPropertyId, entityPropertyId);
                propertyAssignments[2] = new PropertyAssignment(EntityProperty.EntityReferencesTargetEntitiesIdDomainPropertyId, entityPropertyId);
                propertyAssignments[3] = new PropertyAssignment(EntityProperty.NameDomainPropertyId, entityPropertyName);
                propertyAssignments[4] = new PropertyAssignment(EntityProperty.TypeDomainPropertyId, sourceEntityName);

                var targetEntityProperty = new EntityProperty(targetEntity.Store, propertyAssignments);

                targetEntity.EntityProperties.Add(targetEntityProperty);
                link.EntityReferencesTargetEntitiesId = entityPropertyId;
            }
        }
    }

    [RuleOn(typeof(EntityReferencesTargetEntities), FireTime = TimeToFire.TopLevelCommit)]
    public class EntityReferencesTargetEntitiesDeletingRule : DeletingRule
    {
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            if (GlobalVariables.Model_EntityReferencesTargetEntities_IsDeleting == CommonConstants.Booleans.True) return;

            base.ElementDeleting(e);

            if (!(e.ModelElement is EntityReferencesTargetEntities link)) return;

            var targetEntity = link.TargetEntity;

            if (targetEntity == null) return;
            if (targetEntity.EntityProperties == null) return;


            foreach (var entityProperty in targetEntity.EntityProperties)
                if (entityProperty.EntityReferencesTargetEntitiesId == link.EntityReferencesTargetEntitiesId)
                {
                    entityProperty.Delete();
                    break;
                }
        }
    }
}
