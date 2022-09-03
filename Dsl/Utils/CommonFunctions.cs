namespace Columbia.Dsl.Utils
{
    public class CommonFunctions
    {
        public static string GetStringId(int numberId, int size)
            => numberId.ToString().PadLeft(size, char.Parse(CommonConstants.Strings.Zero));

        public static int GetEntityPropertiesCountByType(Entity entity, string entityPropertyType)
        {
            var count = CommonConstants.Numbers.Zero;
            var entityProperties = entity.EntityProperties;

            foreach (var entityProperty in entityProperties)
                if (entityProperty.Type == entityPropertyType) count += 1;

            return count;
        }

        public static int GetMaxEntityId(DomainModel domainModel)
        {
            var entityId = CommonConstants.Numbers.Zero;
            var entityIdMax = CommonConstants.Numbers.Zero;

            if (domainModel.Entities == null) return entityIdMax;

            foreach (var entity in domainModel.Entities)
            {
                if (int.TryParse(entity.EntityId, out int entityIdParsed))
                    entityId = entityIdParsed;

                if (entityId >= entityIdMax)
                    entityIdMax = entityId;
            }

            return entityIdMax;
        }

        public static int GetMaxEntityPropertyId(Entity entity)
        {
            var entityPropertyId = CommonConstants.Numbers.Zero;
            var entityPropertyIdMax = CommonConstants.Numbers.Zero;

            if (entity.EntityProperties == null) return entityPropertyIdMax;

            foreach (var entityProperty in entity.EntityProperties)
            {
                if (int.TryParse(entityProperty.EntityPropertyId, out int entityPropertyIdParsed))
                    entityPropertyId = entityPropertyIdParsed;

                if (entityPropertyId >= entityPropertyIdMax)
                    entityPropertyIdMax = entityPropertyId;
            }

            return entityPropertyIdMax;
        }
    }
}
