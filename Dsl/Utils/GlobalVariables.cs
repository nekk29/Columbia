namespace Columbia.Dsl.Utils
{
    public class GlobalVariables
    {
        //DomainEntityReferencesTargetDomainEntities
        public static string EntityReferencesTargetEntitiesId { get; set; }

        //DomainEntityCollection
        public static bool Model_DomainEntityCollection_IsUpdating { get; set; }

        //DomainEntityProperty
        public static bool Model_EntityProperty_IsUpdating { get; set; }
        public static bool Model_EntityProperty_IsDeleting { get; set; }

        //DomainEntityReferencesTargetDomainEntities
        public static bool Model_EntityReferencesTargetEntities_IsAdding { get; set; }
        public static bool Model_EntityReferencesTargetEntities_IsDeleting { get; set; }

        //DomainEntityReferencesTargetDomainEntities
        public static bool Model_DomainEntityCollectionReferencesEntities_IsAdding { get; set; }
        public static bool Model_EntityCollectionReferencesEntities_IsDeleting { get; set; }
    }
}
