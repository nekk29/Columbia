using Columbia.Dsl.Utils;
using Microsoft.VisualStudio.Modeling;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Columbia.Dsl.CustomRules.DomainClasses
{

    [RuleOn(typeof(Entity), FireTime = TimeToFire.TopLevelCommit)]
    public class EntityAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            base.ElementAdded(e);

            var entity = e.ModelElement as Entity;
            if (!string.IsNullOrEmpty(entity.Name)) return;

            var domainModel = entity.DomainModel;
            if (domainModel == null) return;

            var entityId = CommonFunctions.GetMaxEntityId(domainModel) + 1;

            entity.EntityId = CommonFunctions.GetStringId(entityId, CommonConstants.Numbers.Five);
        }
    }

    [RuleOn(typeof(Entity), FireTime = TimeToFire.TopLevelCommit)]
    public class EntityChangeRule : ChangeRule
    {
        private const string DomainPropertyName = "Name";

        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            switch (e.DomainProperty.Name)
            {
                case DomainPropertyName:
                    ElementPropertyChangedName(e);
                    break;
            }
        }

        public void ElementPropertyChangedName(ElementPropertyChangedEventArgs e)
        {
            base.ElementPropertyChanged(e);

            var entity = e.ModelElement as Entity;
            if (entity == null) return;

            var domainModel = entity.DomainModel;
            if (domainModel == null) return;

            if (string.IsNullOrEmpty(entity.TableName)) entity.TableName = entity.Name;

            foreach (var entityTarget in domainModel.Entities)
            {
                if (entityTarget.EntityProperties == null) continue;

                foreach (var entityProperty in entityTarget.EntityProperties)
                {
                    if (entityProperty.Type.CompareTo(e.OldValue) == 0)
                    {
                        GlobalVariables.Model_EntityProperty_IsUpdating = CommonConstants.Booleans.True;
                        entityProperty.Type = entity.Name;
                        GlobalVariables.Model_EntityProperty_IsUpdating = CommonConstants.Booleans.False;
                    }
                }
            }
        }
    }

    [RuleOn(typeof(Entity), FireTime = TimeToFire.TopLevelCommit)]
    public class EntityDeletingRule : DeletingRule
    {
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            if (GlobalVariables.Model_EntityCollectionReferencesEntities_IsDeleting == CommonConstants.Booleans.True) return;

            base.ElementDeleting(e);

            var entity = e.ModelElement as Entity;
            if (entity == null) return;

            var domainModel = entity.DomainModel;
            if (domainModel == null) return;

            foreach (var entityTarget in domainModel.Entities)
            {
                if (entityTarget.EntityProperties == null) continue;

                var entityPropertyIds = new List<Guid>();

                foreach (var entityProperty in entityTarget.EntityProperties)
                {
                    if (entityProperty.Type.CompareTo(entity.Name) == 0)
                        entityPropertyIds.Add(entityProperty.Id);
                }

                foreach (var entityPropertyId in entityPropertyIds)
                {
                    var entityProperty = entityTarget.EntityProperties.FirstOrDefault(x => x.Id == entityPropertyId);
                    GlobalVariables.Model_EntityProperty_IsDeleting = CommonConstants.Booleans.True;
                    entityTarget.EntityProperties.Remove(entityProperty);
                    GlobalVariables.Model_EntityProperty_IsDeleting = CommonConstants.Booleans.False;
                }
            }
        }
    }
}
