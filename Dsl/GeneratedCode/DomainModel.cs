﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;
namespace Columbia.Dsl
{
	/// <summary>
	/// DomainModel ColumbiaDomainModel
	/// Columbia framework templates for api projects using .Net 6, Entity Framework,
	/// CQRS and more.
	/// </summary>
	[DslDesign::DisplayNameResource("Columbia.Dsl.ColumbiaDomainModel.DisplayName", typeof(global::Columbia.Dsl.ColumbiaDomainModel), "Columbia.Dsl.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Columbia.Dsl.ColumbiaDomainModel.Description", typeof(global::Columbia.Dsl.ColumbiaDomainModel), "Columbia.Dsl.GeneratedCode.DomainModelResx")]
	[global::System.CLSCompliant(true)]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.CoreDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.Diagrams.CoreDesignSurfaceDomainModel))]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
	[DslModeling::DomainObjectId("11f6368b-598b-42a7-a6c6-108b626f60ae")]
	public partial class ColumbiaDomainModel : DslModeling::DomainModel
	{
		#region Constructor, domain model Id
	
		/// <summary>
		/// ColumbiaDomainModel domain model Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelId = new global::System.Guid(0x11f6368b, 0x598b, 0x42a7, 0xa6, 0xc6, 0x10, 0x8b, 0x62, 0x6f, 0x60, 0xae);
	
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store">Store containing the domain model.</param>
		public ColumbiaDomainModel(DslModeling::Store store)
			: base(store, DomainModelId)
		{
			// Call the partial method to allow any required serialization setup to be done.
			this.InitializeSerialization(store);		
		}
		
	
		///<Summary>
		/// Defines a partial method that will be called from the constructor to
		/// allow any necessary serialization setup to be done.
		///</Summary>
		///<remarks>
		/// For a DSL created with the DSL Designer wizard, an implementation of this 
		/// method will be generated in the GeneratedCode\SerializationHelper.cs class.
		///</remarks>
		partial void InitializeSerialization(DslModeling::Store store);
	
	
		#endregion
		#region Domain model reflection
			
		/// <summary>
		/// Gets the list of generated domain model types (classes, rules, relationships).
		/// </summary>
		/// <returns>List of types.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		protected sealed override global::System.Type[] GetGeneratedDomainModelTypes()
		{
			return new global::System.Type[]
			{
				typeof(DomainModel),
				typeof(Entity),
				typeof(PrimitiveProperty),
				typeof(EntityProperty),
				typeof(DomainModelHasEntities),
				typeof(EntityReferencesTargetEntities),
				typeof(EntityHasPrimitiveProperties),
				typeof(EntityHasEntityProperties),
				typeof(ColumbiaDiagram),
				typeof(EntityConnector),
				typeof(EntityShape),
				typeof(global::Columbia.Dsl.FixUpDiagram),
				typeof(global::Columbia.Dsl.ConnectorRolePlayerChanged),
				typeof(global::Columbia.Dsl.CompartmentItemAddRule),
				typeof(global::Columbia.Dsl.CompartmentItemDeleteRule),
				typeof(global::Columbia.Dsl.CompartmentItemRolePlayerChangeRule),
				typeof(global::Columbia.Dsl.CompartmentItemRolePlayerPositionChangeRule),
				typeof(global::Columbia.Dsl.CompartmentItemChangeRule),
			};
		}
		/// <summary>
		/// Gets the list of generated domain properties.
		/// </summary>
		/// <returns>List of property data.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		protected sealed override DomainMemberInfo[] GetGeneratedDomainProperties()
		{
			return new DomainMemberInfo[]
			{
				new DomainMemberInfo(typeof(DomainModel), "Apis", DomainModel.ApisDomainPropertyId, typeof(DomainModel.ApisPropertyHandler)),
				new DomainMemberInfo(typeof(DomainModel), "Application", DomainModel.ApplicationDomainPropertyId, typeof(DomainModel.ApplicationPropertyHandler)),
				new DomainMemberInfo(typeof(DomainModel), "ApplicationAbstractions", DomainModel.ApplicationAbstractionsDomainPropertyId, typeof(DomainModel.ApplicationAbstractionsPropertyHandler)),
				new DomainMemberInfo(typeof(DomainModel), "Domain", DomainModel.DomainDomainPropertyId, typeof(DomainModel.DomainPropertyHandler)),
				new DomainMemberInfo(typeof(DomainModel), "Dto", DomainModel.DtoDomainPropertyId, typeof(DomainModel.DtoPropertyHandler)),
				new DomainMemberInfo(typeof(DomainModel), "Entity", DomainModel.EntityDomainPropertyId, typeof(DomainModel.EntityPropertyHandler)),
				new DomainMemberInfo(typeof(DomainModel), "Repository", DomainModel.RepositoryDomainPropertyId, typeof(DomainModel.RepositoryPropertyHandler)),
				new DomainMemberInfo(typeof(DomainModel), "RepositoryAbstractions", DomainModel.RepositoryAbstractionsDomainPropertyId, typeof(DomainModel.RepositoryAbstractionsPropertyHandler)),
				new DomainMemberInfo(typeof(DomainModel), "RestClient", DomainModel.RestClientDomainPropertyId, typeof(DomainModel.RestClientPropertyHandler)),
				new DomainMemberInfo(typeof(DomainModel), "Database", DomainModel.DatabaseDomainPropertyId, typeof(DomainModel.DatabasePropertyHandler)),
				new DomainMemberInfo(typeof(DomainModel), "Test", DomainModel.TestDomainPropertyId, typeof(DomainModel.TestPropertyHandler)),
				new DomainMemberInfo(typeof(Entity), "EntityId", Entity.EntityIdDomainPropertyId, typeof(Entity.EntityIdPropertyHandler)),
				new DomainMemberInfo(typeof(Entity), "Name", Entity.NameDomainPropertyId, typeof(Entity.NamePropertyHandler)),
				new DomainMemberInfo(typeof(Entity), "IsAuditable", Entity.IsAuditableDomainPropertyId, typeof(Entity.IsAuditablePropertyHandler)),
				new DomainMemberInfo(typeof(Entity), "TableName", Entity.TableNameDomainPropertyId, typeof(Entity.TableNamePropertyHandler)),
				new DomainMemberInfo(typeof(PrimitiveProperty), "Name", PrimitiveProperty.NameDomainPropertyId, typeof(PrimitiveProperty.NamePropertyHandler)),
				new DomainMemberInfo(typeof(PrimitiveProperty), "Type", PrimitiveProperty.TypeDomainPropertyId, typeof(PrimitiveProperty.TypePropertyHandler)),
				new DomainMemberInfo(typeof(PrimitiveProperty), "IsPrimaryKey", PrimitiveProperty.IsPrimaryKeyDomainPropertyId, typeof(PrimitiveProperty.IsPrimaryKeyPropertyHandler)),
				new DomainMemberInfo(typeof(PrimitiveProperty), "Required", PrimitiveProperty.RequiredDomainPropertyId, typeof(PrimitiveProperty.RequiredPropertyHandler)),
				new DomainMemberInfo(typeof(EntityProperty), "EntityPropertyId", EntityProperty.EntityPropertyIdDomainPropertyId, typeof(EntityProperty.EntityPropertyIdPropertyHandler)),
				new DomainMemberInfo(typeof(EntityProperty), "EntityId", EntityProperty.EntityIdDomainPropertyId, typeof(EntityProperty.EntityIdPropertyHandler)),
				new DomainMemberInfo(typeof(EntityProperty), "Name", EntityProperty.NameDomainPropertyId, typeof(EntityProperty.NamePropertyHandler)),
				new DomainMemberInfo(typeof(EntityProperty), "Type", EntityProperty.TypeDomainPropertyId, typeof(EntityProperty.TypePropertyHandler)),
				new DomainMemberInfo(typeof(EntityProperty), "EntityReferencesTargetEntitiesId", EntityProperty.EntityReferencesTargetEntitiesIdDomainPropertyId, typeof(EntityProperty.EntityReferencesTargetEntitiesIdPropertyHandler)),
				new DomainMemberInfo(typeof(EntityProperty), "Required", EntityProperty.RequiredDomainPropertyId, typeof(EntityProperty.RequiredPropertyHandler)),
				new DomainMemberInfo(typeof(EntityReferencesTargetEntities), "EntityReferencesTargetEntitiesId", EntityReferencesTargetEntities.EntityReferencesTargetEntitiesIdDomainPropertyId, typeof(EntityReferencesTargetEntities.EntityReferencesTargetEntitiesIdPropertyHandler)),
			};
		}
		/// <summary>
		/// Gets the list of generated domain roles.
		/// </summary>
		/// <returns>List of role data.</returns>
		protected sealed override DomainRolePlayerInfo[] GetGeneratedDomainRoles()
		{
			return new DomainRolePlayerInfo[]
			{
				new DomainRolePlayerInfo(typeof(DomainModelHasEntities), "DomainModel", DomainModelHasEntities.DomainModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainModelHasEntities), "Entity", DomainModelHasEntities.EntityDomainRoleId),
				new DomainRolePlayerInfo(typeof(EntityReferencesTargetEntities), "SourceEntity", EntityReferencesTargetEntities.SourceEntityDomainRoleId),
				new DomainRolePlayerInfo(typeof(EntityReferencesTargetEntities), "TargetEntity", EntityReferencesTargetEntities.TargetEntityDomainRoleId),
				new DomainRolePlayerInfo(typeof(EntityHasPrimitiveProperties), "Entity", EntityHasPrimitiveProperties.EntityDomainRoleId),
				new DomainRolePlayerInfo(typeof(EntityHasPrimitiveProperties), "PrimitiveProperty", EntityHasPrimitiveProperties.PrimitivePropertyDomainRoleId),
				new DomainRolePlayerInfo(typeof(EntityHasEntityProperties), "Entity", EntityHasEntityProperties.EntityDomainRoleId),
				new DomainRolePlayerInfo(typeof(EntityHasEntityProperties), "EntityProperty", EntityHasEntityProperties.EntityPropertyDomainRoleId),
			};
		}
		#endregion
		#region Factory methods
		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementMap;
	
		/// <summary>
		/// Creates an element of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementType">Element type which belongs to this domain model.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		public sealed override DslModeling::ModelElement CreateElement(DslModeling::Partition partition, global::System.Type elementType, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementType == null) throw new global::System.ArgumentNullException("elementType");
	
			if (createElementMap == null)
			{
				createElementMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(7);
				createElementMap.Add(typeof(DomainModel), 0);
				createElementMap.Add(typeof(Entity), 1);
				createElementMap.Add(typeof(PrimitiveProperty), 2);
				createElementMap.Add(typeof(EntityProperty), 3);
				createElementMap.Add(typeof(ColumbiaDiagram), 4);
				createElementMap.Add(typeof(EntityConnector), 5);
				createElementMap.Add(typeof(EntityShape), 6);
			}
			int index;
			if (!createElementMap.TryGetValue(elementType, out index))
			{
				// construct exception error message		
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Columbia.Dsl.ColumbiaDomainModel.SingletonResourceManager.GetString("UnrecognizedElementType"),
								elementType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementType");
			}
			switch (index)
			{
				case 0: return new DomainModel(partition, propertyAssignments);
				case 1: return new Entity(partition, propertyAssignments);
				case 2: return new PrimitiveProperty(partition, propertyAssignments);
				case 3: return new EntityProperty(partition, propertyAssignments);
				case 4: return new ColumbiaDiagram(partition, propertyAssignments);
				case 5: return new EntityConnector(partition, propertyAssignments);
				case 6: return new EntityShape(partition, propertyAssignments);
				default: return null;
			}
		}
	
		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementLinkMap;
	
		/// <summary>
		/// Creates an element link of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementLinkType">Element link type which belongs to this domain model.</param>
		/// <param name="roleAssignments">List of relationship role assignments for the new link.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element link.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		public sealed override DslModeling::ElementLink CreateElementLink(DslModeling::Partition partition, global::System.Type elementLinkType, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementLinkType == null) throw new global::System.ArgumentNullException("elementLinkType");
			if (roleAssignments == null) throw new global::System.ArgumentNullException("roleAssignments");
	
			if (createElementLinkMap == null)
			{
				createElementLinkMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(4);
				createElementLinkMap.Add(typeof(DomainModelHasEntities), 0);
				createElementLinkMap.Add(typeof(EntityReferencesTargetEntities), 1);
				createElementLinkMap.Add(typeof(EntityHasPrimitiveProperties), 2);
				createElementLinkMap.Add(typeof(EntityHasEntityProperties), 3);
			}
			int index;
			if (!createElementLinkMap.TryGetValue(elementLinkType, out index))
			{
				// construct exception error message
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Columbia.Dsl.ColumbiaDomainModel.SingletonResourceManager.GetString("UnrecognizedElementLinkType"),
								elementLinkType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementLinkType");
			
			}
			switch (index)
			{
				case 0: return new DomainModelHasEntities(partition, roleAssignments, propertyAssignments);
				case 1: return new EntityReferencesTargetEntities(partition, roleAssignments, propertyAssignments);
				case 2: return new EntityHasPrimitiveProperties(partition, roleAssignments, propertyAssignments);
				case 3: return new EntityHasEntityProperties(partition, roleAssignments, propertyAssignments);
				default: return null;
			}
		}
		#endregion
		#region Resource manager
		
		private static global::System.Resources.ResourceManager resourceManager;
		
		/// <summary>
		/// The base name of this model's resources.
		/// </summary>
		public const string ResourceBaseName = "Columbia.Dsl.GeneratedCode.DomainModelResx";
		
		/// <summary>
		/// Gets the DomainModel's ResourceManager. If the ResourceManager does not already exist, then it is created.
		/// </summary>
		public override global::System.Resources.ResourceManager ResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return ColumbiaDomainModel.SingletonResourceManager;
			}
		}
	
		/// <summary>
		/// Gets the Singleton ResourceManager for this domain model.
		/// </summary>
		public static global::System.Resources.ResourceManager SingletonResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				if (ColumbiaDomainModel.resourceManager == null)
				{
					ColumbiaDomainModel.resourceManager = new global::System.Resources.ResourceManager(ResourceBaseName, typeof(ColumbiaDomainModel).Assembly);
				}
				return ColumbiaDomainModel.resourceManager;
			}
		}
		#endregion
		#region Copy/Remove closures
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter copyClosure;
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter removeClosure;
		/// <summary>
		/// Returns an IElementVisitorFilter that corresponds to the ClosureType.
		/// </summary>
		/// <param name="type">closure type</param>
		/// <param name="rootElements">collection of root elements</param>
		/// <returns>IElementVisitorFilter or null</returns>
		public override DslModeling::IElementVisitorFilter GetClosureFilter(DslModeling::ClosureType type, global::System.Collections.Generic.ICollection<DslModeling::ModelElement> rootElements)
		{
			switch (type)
			{
				case DslModeling::ClosureType.CopyClosure:
					return ColumbiaDomainModel.CopyClosure;
				case DslModeling::ClosureType.DeleteClosure:
					return ColumbiaDomainModel.DeleteClosure;
			}
			return base.GetClosureFilter(type, rootElements);
		}
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter CopyClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (ColumbiaDomainModel.copyClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter copyFilter = new DslModeling::ChainingElementVisitorFilter();
					copyFilter.AddFilter(new ColumbiaCopyClosure());
					copyFilter.AddFilter(new DslModeling::CoreCopyClosure());
					copyFilter.AddFilter(new DslDiagrams::CoreDesignSurfaceCopyClosure());
					
					ColumbiaDomainModel.copyClosure = copyFilter;
				}
				return ColumbiaDomainModel.copyClosure;
			}
		}
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter DeleteClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (ColumbiaDomainModel.removeClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter removeFilter = new DslModeling::ChainingElementVisitorFilter();
					removeFilter.AddFilter(new ColumbiaDeleteClosure());
					removeFilter.AddFilter(new DslModeling::CoreDeleteClosure());
					removeFilter.AddFilter(new DslDiagrams::CoreDesignSurfaceDeleteClosure());
		
					ColumbiaDomainModel.removeClosure = removeFilter;
				}
				return ColumbiaDomainModel.removeClosure;
			}
		}
		#endregion
		#region Diagram rule helpers
		/// <summary>
		/// Enables rules in this domain model related to diagram fixup for the given store.
		/// If diagram data will be loaded into the store, this method should be called first to ensure
		/// that the diagram behaves properly.
		/// </summary>
		public static void EnableDiagramRules(DslModeling::Store store)
		{
			if(store == null) throw new global::System.ArgumentNullException("store");
			
			DslModeling::RuleManager ruleManager = store.RuleManager;
			ruleManager.EnableRule(typeof(global::Columbia.Dsl.FixUpDiagram));
			ruleManager.EnableRule(typeof(global::Columbia.Dsl.ConnectorRolePlayerChanged));
			ruleManager.EnableRule(typeof(global::Columbia.Dsl.CompartmentItemAddRule));
			ruleManager.EnableRule(typeof(global::Columbia.Dsl.CompartmentItemDeleteRule));
			ruleManager.EnableRule(typeof(global::Columbia.Dsl.CompartmentItemRolePlayerChangeRule));
			ruleManager.EnableRule(typeof(global::Columbia.Dsl.CompartmentItemRolePlayerPositionChangeRule));
			ruleManager.EnableRule(typeof(global::Columbia.Dsl.CompartmentItemChangeRule));
		}
		
		/// <summary>
		/// Disables rules in this domain model related to diagram fixup for the given store.
		/// </summary>
		public static void DisableDiagramRules(DslModeling::Store store)
		{
			if(store == null) throw new global::System.ArgumentNullException("store");
			
			DslModeling::RuleManager ruleManager = store.RuleManager;
			ruleManager.DisableRule(typeof(global::Columbia.Dsl.FixUpDiagram));
			ruleManager.DisableRule(typeof(global::Columbia.Dsl.ConnectorRolePlayerChanged));
			ruleManager.DisableRule(typeof(global::Columbia.Dsl.CompartmentItemAddRule));
			ruleManager.DisableRule(typeof(global::Columbia.Dsl.CompartmentItemDeleteRule));
			ruleManager.DisableRule(typeof(global::Columbia.Dsl.CompartmentItemRolePlayerChangeRule));
			ruleManager.DisableRule(typeof(global::Columbia.Dsl.CompartmentItemRolePlayerPositionChangeRule));
			ruleManager.DisableRule(typeof(global::Columbia.Dsl.CompartmentItemChangeRule));
		}
		#endregion
	}
		
	#region Copy/Remove closure classes
	/// <summary>
	/// Remove closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class ColumbiaDeleteClosure : ColumbiaDeleteClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public ColumbiaDeleteClosure() : base()
		{
		}
	}
	
	/// <summary>
	/// Base class for remove closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class ColumbiaDeleteClosureBase : DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary domainRoles;
		/// <summary>
		/// Constructor
		/// </summary>
		public ColumbiaDeleteClosureBase()
		{
			#region Initialize DomainData Table
			DomainRoles.Add(global::Columbia.Dsl.DomainModelHasEntities.EntityDomainRoleId, true);
			DomainRoles.Add(global::Columbia.Dsl.EntityHasPrimitiveProperties.PrimitivePropertyDomainRoleId, true);
			DomainRoles.Add(global::Columbia.Dsl.EntityHasEntityProperties.EntityPropertyDomainRoleId, true);
			#endregion
		}
		/// <summary>
		/// Called to ask the filter if a particular relationship from a source element should be included in the traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship</param>
		/// <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
		/// <param name="targetRelationship">Relationship in question</param>
		/// <returns>Yes if the relationship should be traversed</returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRelationship(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::DomainRoleInfo sourceRoleInfo, DslModeling::DomainRelationshipInfo domainRelationshipInfo, DslModeling::ElementLink targetRelationship)
		{
			return DslModeling::VisitorFilterResult.Yes;
		}
		/// <summary>
		/// Called to ask the filter if a particular role player should be Visited during traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="elementLink">Element Link that forms the relationship to the role player in question</param>
		/// <param name="targetDomainRole">DomainRoleInfo of the target role</param>
		/// <param name="targetRolePlayer">Model Element that plays the target role in the relationship</param>
		/// <returns></returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRolePlayer(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::ElementLink elementLink, DslModeling::DomainRoleInfo targetDomainRole, DslModeling::ModelElement targetRolePlayer)
		{
			if (targetDomainRole == null) throw new global::System.ArgumentNullException("targetDomainRole");
			return this.DomainRoles.Contains(targetDomainRole.Id) ? DslModeling::VisitorFilterResult.Yes : DslModeling::VisitorFilterResult.DoNotCare;
		}
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary DomainRoles
		{
			get
			{
				if (this.domainRoles == null)
				{
					this.domainRoles = new global::System.Collections.Specialized.HybridDictionary();
				}
				return this.domainRoles;
			}
		}
	
	}
	/// <summary>
	/// Copy closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class ColumbiaCopyClosure : ColumbiaCopyClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public ColumbiaCopyClosure() : base()
		{
		}
	}
	/// <summary>
	/// Base class for copy closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class ColumbiaCopyClosureBase : DslModeling::CopyClosureFilter, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public ColumbiaCopyClosureBase():base()
		{
		}
	}
	#endregion
		
}

