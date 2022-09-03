using Columbia.Dsl.Utils;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Columbia.Dsl.CustomRules.DomainClasses
{
    [RuleOn(typeof(EntityProperty), FireTime = TimeToFire.TopLevelCommit)]
    public class EntityPropertyChangeRule : ChangeRule
    {
        private const string EntityPropertyName = "Name";
        private const string EntityPropertyType = "Type";

        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            if (GlobalVariables.Model_EntityProperty_IsUpdating == CommonConstants.Booleans.True) return;

            base.ElementPropertyChanged(e);

            switch (e.DomainProperty.Name)
            {
                case EntityPropertyName:
                    ElementPropertyChangedName(e);
                    break;
                case EntityPropertyType:
                    ElementPropertyChangedType(e);
                    break;
            }
        }

        public void ElementPropertyChangedName(ElementPropertyChangedEventArgs e)
        {
            var entityProperty = e.ModelElement as EntityProperty;
            if (!string.IsNullOrEmpty(entityProperty.EntityPropertyId)) return;

            var targetEntity = entityProperty.Entity;
            if (targetEntity == null) return;

            var entityId = targetEntity.EntityId;
            var entityPropertyIdNumber = CommonFunctions.GetMaxEntityPropertyId(targetEntity) + 1;
            var entityPropertyId = CommonFunctions.GetStringId(entityPropertyIdNumber, CommonConstants.Numbers.Five);

            entityPropertyId = string.Concat(entityId, entityPropertyId);

            entityProperty.EntityId = entityId;
            entityProperty.EntityPropertyId = entityPropertyId;
            entityProperty.EntityReferencesTargetEntitiesId = entityPropertyId;
        }

        public void ElementPropertyChangedType(ElementPropertyChangedEventArgs e)
        {
            var sourceEntityOldExists = CommonConstants.Booleans.False;
            var sourceEntityNewExists = CommonConstants.Booleans.False;

            var entityProperty = e.ModelElement as EntityProperty;
            var targetEntity = entityProperty.Entity;
            var sourceEntityOld = entityProperty.Entity;
            var sourceEntityNew = entityProperty.Entity;

            ReadOnlyCollection<EntityReferencesTargetEntities> entityReferencesTargetEntities;

            if (targetEntity == null) return;

            var existsLink = CommonConstants.Booleans.False;
            var domainModel = targetEntity.DomainModel;

            foreach (var sourceEntity in domainModel.Entities)
                if (sourceEntity.Name == e.OldValue.ToString())
                {
                    sourceEntityOldExists = CommonConstants.Booleans.True;
                    sourceEntityOld = sourceEntity;
                    break;
                }

            foreach (var sourceEntity in domainModel.Entities)
                if (sourceEntity.Name == e.NewValue.ToString())
                {
                    sourceEntityNewExists = CommonConstants.Booleans.True;
                    sourceEntityNew = sourceEntity;
                    break;
                }

            if (sourceEntityOldExists)
            {
                //Delete Old Entity References
                entityReferencesTargetEntities = EntityReferencesTargetEntities.GetLinks(sourceEntityOld, targetEntity);

                if (entityReferencesTargetEntities != null)
                {
                    foreach (var entityReferencesTargetEntity in entityReferencesTargetEntities)
                    {
                        if (entityReferencesTargetEntity.EntityReferencesTargetEntitiesId == entityProperty.EntityPropertyId)
                        {
                            GlobalVariables.Model_EntityReferencesTargetEntities_IsDeleting = CommonConstants.Booleans.True;
                            entityReferencesTargetEntity.Delete();
                            GlobalVariables.Model_EntityReferencesTargetEntities_IsDeleting = CommonConstants.Booleans.False;
                            break;
                        }
                    }
                }
            }

            if (sourceEntityNewExists)
            {
                //Add New Entity References
                entityReferencesTargetEntities = EntityReferencesTargetEntities.GetLinks(sourceEntityNew, targetEntity);

                if (entityReferencesTargetEntities != null)
                {
                    foreach (var entityReferencesTargetEntity in entityReferencesTargetEntities)
                        if (entityReferencesTargetEntity.EntityReferencesTargetEntitiesId == entityProperty.EntityPropertyId)
                        {
                            existsLink = true;
                            break;
                        }
                }

                if (!existsLink)
                {
                    GlobalVariables.Model_EntityReferencesTargetEntities_IsAdding = CommonConstants.Booleans.True;
                    GlobalVariables.EntityReferencesTargetEntitiesId = entityProperty.EntityPropertyId;
                    EntityReferencesTargetEntitiesBuilder.Connect(sourceEntityNew, targetEntity);
                    GlobalVariables.Model_EntityReferencesTargetEntities_IsAdding = CommonConstants.Booleans.False;
                }
            }
        }
    }

    [RuleOn(typeof(EntityProperty), FireTime = TimeToFire.TopLevelCommit)]
    public class EntityPropertyDeletingRule : DeletingRule
    {
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            if (GlobalVariables.Model_EntityProperty_IsDeleting == CommonConstants.Booleans.True) return;

            base.ElementDeleting(e);

            var entityProperty = e.ModelElement as EntityProperty;

            var targetEntity = entityProperty.Entity;
            if (targetEntity == null) return;

            var domainModel = targetEntity.DomainModel;
            if (domainModel == null) return;

            foreach (var sourceEntity in domainModel.Entities)
            {
                if (sourceEntity.Name.CompareTo(entityProperty.Type) == 0)
                {
                    var entityReferencesTargetEntities = EntityReferencesTargetEntities.GetLinks(sourceEntity, targetEntity);
                    if (entityReferencesTargetEntities != null)
                    {
                        foreach (var entityReferencesTargetEntity in entityReferencesTargetEntities)
                        {
                            if (entityReferencesTargetEntity.EntityReferencesTargetEntitiesId == entityProperty.EntityReferencesTargetEntitiesId)
                            {
                                GlobalVariables.Model_EntityReferencesTargetEntities_IsDeleting = CommonConstants.Booleans.True;
                                entityReferencesTargetEntities[0].Delete();
                                GlobalVariables.Model_EntityReferencesTargetEntities_IsDeleting = CommonConstants.Booleans.False;
                                break;
                            }
                        }
                    }
                    break;
                }
            }
        }
    }
}
