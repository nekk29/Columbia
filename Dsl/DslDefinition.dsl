<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="11f6368b-598b-42a7-a6c6-108b626f60ae" Description="Columbia framework templates for api projects using .Net 6, Entity Framework, CQRS and more." Name="Columbia" DisplayName="Columbia Domain Model" Namespace="Columbia.Dsl" ProductName="Columbia" CompanyName="Eleven Technologies" PackageGuid="3d6ef314-de50-4ddf-86a3-e67d43a67e64" PackageNamespace="Columbia.Dsl" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="bb6ceb9b-f6a4-49b3-b75c-310b2666cecd" Description="Columbia Domain Model" Name="DomainModel" DisplayName="Domain Model" Namespace="Columbia.Dsl">
      <Properties>
        <DomainProperty Id="171551e1-1dd1-4e5c-86f8-dae4d572d714" Description="Project which is used to generate api controllers" Name="Apis" DisplayName="Apis" DefaultValue="$safesolutionname$.Apis" Category="Implementation Projects" IsUIReadOnly="true">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Columbia.Dsl.CustomCode.DomainTypes.ProjectTypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6566630f-59c4-47b6-bd98-53b844839d27" Description="Project which is used to generate application classes" Name="Application" DisplayName="Application" DefaultValue="$safesolutionname$.Application" Category="Implementation Projects" IsUIReadOnly="true">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Columbia.Dsl.CustomCode.DomainTypes.ProjectTypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="21c4de20-1d09-4552-aa5f-d46044871826" Description="Project which is used to generate application interfaces" Name="ApplicationAbstractions" DisplayName="Application Abstractions" DefaultValue="$safesolutionname$.Application.Abstractions" Category="Implementation Projects" IsUIReadOnly="true">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Columbia.Dsl.CustomCode.DomainTypes.ProjectTypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="8f6eb373-a4f7-4c21-a476-acb9ac855e98" Description="Project which is used to generate commands and queries" Name="Domain" DisplayName="Domain" DefaultValue="$safesolutionname$.Domain" Category="Implementation Projects" IsUIReadOnly="true">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Columbia.Dsl.CustomCode.DomainTypes.ProjectTypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="f4a3ac56-a32d-49b5-aa5e-ec3af0d2a52b" Description="Project which is used to generate dto objects" Name="Dto" DisplayName="Dto" DefaultValue="$safesolutionname$.Dto" Category="Implementation Projects" IsUIReadOnly="true">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Columbia.Dsl.CustomCode.DomainTypes.ProjectTypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9d25f862-3fff-4712-87fb-e09f69058cc9" Description="Project which is used to generate entities" Name="Entity" DisplayName="Entity" DefaultValue="$safesolutionname$.Entity" Category="Implementation Projects" IsUIReadOnly="true">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Columbia.Dsl.CustomCode.DomainTypes.ProjectTypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="f4e7e077-2e3b-46ad-9677-36d45c5e29d7" Description="Project which is used to generate repository classes" Name="Repository" DisplayName="Repository" DefaultValue="$safesolutionname$.Repository" Category="Implementation Projects" IsUIReadOnly="true">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Columbia.Dsl.CustomCode.DomainTypes.ProjectTypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="63ddd377-5da5-4db0-90bc-0eb5f7c9f6db" Description="Project which is used to generate repository interfaces" Name="RepositoryAbstractions" DisplayName="Repository Abstractions" DefaultValue="$safesolutionname$.Repository.Abstractions" Category="Implementation Projects" IsUIReadOnly="true">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Columbia.Dsl.CustomCode.DomainTypes.ProjectTypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7371ca93-0211-45a2-87e1-2f3d783788e6" Description="Project which is used to generate rest client objects" Name="RestClient" DisplayName="Rest Client" DefaultValue="$safesolutionname$.RestClient" Category="Implementation Projects" IsUIReadOnly="true">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Columbia.Dsl.CustomCode.DomainTypes.ProjectTypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9441d07e-53ea-47ae-84c6-3765ba8041c5" Description="Project which is used to generate database objects" Name="Database" DisplayName="Database" DefaultValue="$safesolutionname$.Database" Category="Implementation Projects" IsUIReadOnly="true">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Columbia.Dsl.CustomCode.DomainTypes.ProjectTypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="8e6b9971-37f2-4970-90e9-0b1a641dc783" Description="Project which is used to generate unit tests" Name="Test" DisplayName="Test" DefaultValue="$safesolutionname$.Test" Category="Implementation Projects" IsUIReadOnly="true">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Columbia.Dsl.CustomCode.DomainTypes.ProjectTypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Entity" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DomainModelHasEntities.Entities</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="fa7ecba8-f890-4298-ae43-e2f1e0e24578" Description="Domain Entity" Name="Entity" DisplayName="Entity" Namespace="Columbia.Dsl">
      <Properties>
        <DomainProperty Id="408d7c56-fa41-4721-9eea-017452e05eb9" Description="Entity id" Name="EntityId" DisplayName="Entity id" Category="Definition" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="4700c1e5-8796-4be3-a213-395a84dc6b87" Description="Entity name" Name="Name" DisplayName="Entity name" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="f5634650-face-42e8-b1d6-79fad6cc7777" Description="Specify if the entity inherit base auditable class" Name="IsAuditable" DisplayName="Is Auditable" DefaultValue="true" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9a71e66e-e555-4165-9bd3-6e98f749f7a4" Description="Table Name" Name="TableName" DisplayName="Table Name" Category="Database">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="PrimitiveProperty" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>EntityHasPrimitiveProperties.PrimitiveProperties</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="EntityProperty" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>EntityHasEntityProperties.EntityProperties</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="dc90d05e-6092-4cc0-916a-b41e97a060f4" Description="Description for Columbia.Dsl.PrimitiveProperty" Name="PrimitiveProperty" DisplayName="Primitive Property" Namespace="Columbia.Dsl">
      <Properties>
        <DomainProperty Id="e47f0f94-81c0-491c-b1b4-c0661377d7e6" Description="Property name" Name="Name" DisplayName="Property name" DefaultValue="Property" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="75eaf0be-5a70-455e-bdc5-a3015a7475aa" Description="Property type" Name="Type" DisplayName="Type" DefaultValue="string" Category="Definition">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Columbia.Dsl.CustomCode.DomainTypes.PrimitiveTypeTypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d56ee40b-03bc-4463-b19b-f515aabec542" Description="Specify if the property is key or part of the primary key" Name="IsPrimaryKey" DisplayName="Is Primary Key" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="678d8826-485e-4028-8861-f616b574f9ef" Description="Specify if the property is required" Name="Required" DisplayName="Required" DefaultValue="true" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="53f85944-a77a-44d8-ab47-891a27e67dd5" Description="Description for Columbia.Dsl.EntityProperty" Name="EntityProperty" DisplayName="Entity Property" Namespace="Columbia.Dsl">
      <Properties>
        <DomainProperty Id="22c69281-ae73-43fc-8a53-fd9b4367e8b4" Description="Entity property id" Name="EntityPropertyId" DisplayName="Entity property id" DefaultValue="" Category="Definition" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="46c7641d-48ae-4953-9498-bcd15b405a05" Description="Entity id" Name="EntityId" DisplayName="Entity id" DefaultValue="" Category="Definition" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="b0d57d4b-28eb-49a7-8c3f-f1c5d1a45bec" Description="Property name" Name="Name" DisplayName="Property name" DefaultValue="" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d7fce8ab-7100-417e-8803-ee7c01f088fe" Description="Entity type" Name="Type" DisplayName="Entity type" Category="Definition">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Columbia.Dsl.CustomCode.DomainTypes.EntityTypeTypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="8275e1b0-b661-4993-825e-d7a2efde2b5c" Description="Description for Columbia.Dsl.EntityProperty.Entity References Target Entities Id" Name="EntityReferencesTargetEntitiesId" DisplayName="Entity References Target Entities Id" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="31f9c3f8-4b0a-4c7e-a0da-d1fe8ce67e5e" Description="Specify if the property is required" Name="Required" DisplayName="Required" DefaultValue="true" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="a3c0444c-1422-4536-af26-3faf8f1df6d1" Description="Domain Model Has Entities" Name="DomainModelHasEntities" DisplayName="Domain Model Has Entities" Namespace="Columbia.Dsl" IsEmbedding="true">
      <Source>
        <DomainRole Id="f97cf0fe-cd52-42ec-8091-2ad398934b22" Description="Description for Columbia.Dsl.DomainModelHasEntities.DomainModel" Name="DomainModel" DisplayName="Domain Model" PropertyName="Entities" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Entities">
          <RolePlayer>
            <DomainClassMoniker Name="DomainModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="c20ff070-95da-4dbe-a851-b340b828e65d" Description="Description for Columbia.Dsl.DomainModelHasEntities.Entity" Name="Entity" DisplayName="Entity" PropertyName="DomainModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Domain Model">
          <RolePlayer>
            <DomainClassMoniker Name="Entity" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="1475b97d-c118-4ce9-bfcc-ce2f5627c80a" Description="Entity References Target Entities" Name="EntityReferencesTargetEntities" DisplayName="Entity References Target Entities" Namespace="Columbia.Dsl">
      <Properties>
        <DomainProperty Id="3fa9ebdf-3c49-49e1-aeeb-49c7b8b7ca9c" Description="Entity References Target Entities Id" Name="EntityReferencesTargetEntitiesId" DisplayName="Entity References Target Entities Id" Category="Definition" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <Source>
        <DomainRole Id="19759194-b8ba-46b8-aeae-657c054fa5fc" Description="Description for Columbia.Dsl.EntityReferencesTargetEntities.SourceEntity" Name="SourceEntity" DisplayName="Source Entity" PropertyName="TargetEntities" PropertyDisplayName="Target Entities">
          <RolePlayer>
            <DomainClassMoniker Name="Entity" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="1c8528c7-0aa4-40fa-abd2-db76890ab7f8" Description="Description for Columbia.Dsl.EntityReferencesTargetEntities.TargetEntity" Name="TargetEntity" DisplayName="Target Entity" PropertyName="SourceEntities" PropertyDisplayName="Source Entities">
          <RolePlayer>
            <DomainClassMoniker Name="Entity" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="9a140409-6e11-4ef9-9128-fef0cdaad25c" Description="Entity Has Primitive Properties" Name="EntityHasPrimitiveProperties" DisplayName="Entity Has Primitive Properties" Namespace="Columbia.Dsl" IsEmbedding="true">
      <Source>
        <DomainRole Id="25a85ecf-2fda-49b8-8c23-eb652b850d32" Description="Description for Columbia.Dsl.EntityHasPrimitiveProperties.Entity" Name="Entity" DisplayName="Entity" PropertyName="PrimitiveProperties" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Primitive Properties">
          <RolePlayer>
            <DomainClassMoniker Name="Entity" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="3e7431e5-4162-4570-93a0-20717a488fd9" Description="Description for Columbia.Dsl.EntityHasPrimitiveProperties.PrimitiveProperty" Name="PrimitiveProperty" DisplayName="Primitive Property" PropertyName="Entity" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Entity">
          <RolePlayer>
            <DomainClassMoniker Name="PrimitiveProperty" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="c4ff5d7a-8e5e-4e5c-9eba-74c7bd76d287" Description="Entity Has Entity Properties" Name="EntityHasEntityProperties" DisplayName="Entity Has Entity Properties" Namespace="Columbia.Dsl" IsEmbedding="true">
      <Source>
        <DomainRole Id="de3e1065-6419-43ec-8610-0c9c3a19003b" Description="Description for Columbia.Dsl.EntityHasEntityProperties.Entity" Name="Entity" DisplayName="Entity" PropertyName="EntityProperties" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Entity Properties">
          <RolePlayer>
            <DomainClassMoniker Name="Entity" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="3c11cddc-b890-43da-b2e8-034509ddd739" Description="Description for Columbia.Dsl.EntityHasEntityProperties.EntityProperty" Name="EntityProperty" DisplayName="Entity Property" PropertyName="Entity" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Entity">
          <RolePlayer>
            <DomainClassMoniker Name="EntityProperty" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
  </Relationships>
  <Types>
    <ExternalType Name="DateTime" Namespace="System" />
    <ExternalType Name="String" Namespace="System" />
    <ExternalType Name="Int16" Namespace="System" />
    <ExternalType Name="Int32" Namespace="System" />
    <ExternalType Name="Int64" Namespace="System" />
    <ExternalType Name="UInt16" Namespace="System" />
    <ExternalType Name="UInt32" Namespace="System" />
    <ExternalType Name="UInt64" Namespace="System" />
    <ExternalType Name="SByte" Namespace="System" />
    <ExternalType Name="Byte" Namespace="System" />
    <ExternalType Name="Double" Namespace="System" />
    <ExternalType Name="Single" Namespace="System" />
    <ExternalType Name="Guid" Namespace="System" />
    <ExternalType Name="Boolean" Namespace="System" />
    <ExternalType Name="Char" Namespace="System" />
  </Types>
  <Shapes>
    <CompartmentShape Id="e876a5a6-fb9a-4dfd-a8c7-bf0e77e7b892" Description="Entity" Name="EntityShape" DisplayName="Entity" Namespace="Columbia.Dsl" FixedTooltipText="Entity" FillColor="189, 220, 168" OutlineColor="112, 173, 71" InitialWidth="2" InitialHeight="0.3" OutlineThickness="0.015" FillGradientMode="Vertical" Geometry="Rectangle">
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="Icon" DisplayName="Icon" DefaultIcon="Resources\Images\DomainEntity.bmp" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="Name" DisplayName="Name" DefaultText="Name" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopRight" HorizontalOffset="0" VerticalOffset="0">
        <ExpandCollapseDecorator Name="ExpandCollapse" DisplayName="Expand Collapse" />
      </ShapeHasDecorators>
      <Compartment Name="Properties" Title="Properties" />
      <Compartment Name="Relations" Title="Relations" />
    </CompartmentShape>
  </Shapes>
  <Connectors>
    <Connector Id="46d2a4d6-5571-49e5-a49c-5e60f976f496" Description="Relation connector between entities." Name="EntityConnector" DisplayName="Entity Relationship" Namespace="Columbia.Dsl" FixedTooltipText="Entity Relationship" Color="112, 173, 71" TargetEndStyle="EmptyArrow" Thickness="0.015" />
  </Connectors>
  <XmlSerializationBehavior Name="ColumbiaSerializationBehavior" Namespace="Columbia.Dsl">
    <ClassData>
      <XmlClassData TypeName="DomainModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainModelMoniker" ElementName="domainModel" MonikerTypeName="DomainModelMoniker">
        <DomainClassMoniker Name="DomainModel" />
        <ElementData>
          <XmlPropertyData XmlName="apis">
            <DomainPropertyMoniker Name="DomainModel/Apis" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="application">
            <DomainPropertyMoniker Name="DomainModel/Application" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="applicationAbstractions">
            <DomainPropertyMoniker Name="DomainModel/ApplicationAbstractions" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="domain">
            <DomainPropertyMoniker Name="DomainModel/Domain" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="dto">
            <DomainPropertyMoniker Name="DomainModel/Dto" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="entity">
            <DomainPropertyMoniker Name="DomainModel/Entity" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="repository">
            <DomainPropertyMoniker Name="DomainModel/Repository" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="repositoryAbstractions">
            <DomainPropertyMoniker Name="DomainModel/RepositoryAbstractions" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="restClient">
            <DomainPropertyMoniker Name="DomainModel/RestClient" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="entities">
            <DomainRelationshipMoniker Name="DomainModelHasEntities" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="database">
            <DomainPropertyMoniker Name="DomainModel/Database" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="test">
            <DomainPropertyMoniker Name="DomainModel/Test" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="EntityConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="entityConnectorMoniker" ElementName="entityConnector" MonikerTypeName="EntityConnectorMoniker">
        <ConnectorMoniker Name="EntityConnector" />
      </XmlClassData>
      <XmlClassData TypeName="ColumbiaDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="columbiaDiagramMoniker" ElementName="columbiaDiagram" MonikerTypeName="ColumbiaDiagramMoniker">
        <DiagramMoniker Name="ColumbiaDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="Entity" MonikerAttributeName="" SerializeId="true" MonikerElementName="entityMoniker" ElementName="entity" MonikerTypeName="EntityMoniker">
        <DomainClassMoniker Name="Entity" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="targetEntities">
            <DomainRelationshipMoniker Name="EntityReferencesTargetEntities" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="primitiveProperties">
            <DomainRelationshipMoniker Name="EntityHasPrimitiveProperties" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="entityProperties">
            <DomainRelationshipMoniker Name="EntityHasEntityProperties" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="entityId">
            <DomainPropertyMoniker Name="Entity/EntityId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="Entity/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isAuditable">
            <DomainPropertyMoniker Name="Entity/IsAuditable" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="tableName">
            <DomainPropertyMoniker Name="Entity/TableName" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainModelHasEntities" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainModelHasEntitiesMoniker" ElementName="domainModelHasEntities" MonikerTypeName="DomainModelHasEntitiesMoniker">
        <DomainRelationshipMoniker Name="DomainModelHasEntities" />
      </XmlClassData>
      <XmlClassData TypeName="EntityReferencesTargetEntities" MonikerAttributeName="" SerializeId="true" MonikerElementName="entityReferencesTargetEntitiesMoniker" ElementName="entityReferencesTargetEntities" MonikerTypeName="EntityReferencesTargetEntitiesMoniker">
        <DomainRelationshipMoniker Name="EntityReferencesTargetEntities" />
        <ElementData>
          <XmlPropertyData XmlName="entityReferencesTargetEntitiesId">
            <DomainPropertyMoniker Name="EntityReferencesTargetEntities/EntityReferencesTargetEntitiesId" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="EntityShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="entityShapeMoniker" ElementName="entityShape" MonikerTypeName="EntityShapeMoniker">
        <CompartmentShapeMoniker Name="EntityShape" />
      </XmlClassData>
      <XmlClassData TypeName="PrimitiveProperty" MonikerAttributeName="" SerializeId="true" MonikerElementName="primitivePropertyMoniker" ElementName="primitiveProperty" MonikerTypeName="PrimitivePropertyMoniker">
        <DomainClassMoniker Name="PrimitiveProperty" />
        <ElementData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="PrimitiveProperty/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="type">
            <DomainPropertyMoniker Name="PrimitiveProperty/Type" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isPrimaryKey">
            <DomainPropertyMoniker Name="PrimitiveProperty/IsPrimaryKey" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="required">
            <DomainPropertyMoniker Name="PrimitiveProperty/Required" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="EntityProperty" MonikerAttributeName="" SerializeId="true" MonikerElementName="entityPropertyMoniker" ElementName="entityProperty" MonikerTypeName="EntityPropertyMoniker">
        <DomainClassMoniker Name="EntityProperty" />
        <ElementData>
          <XmlPropertyData XmlName="entityPropertyId">
            <DomainPropertyMoniker Name="EntityProperty/EntityPropertyId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="entityId">
            <DomainPropertyMoniker Name="EntityProperty/EntityId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="EntityProperty/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="type">
            <DomainPropertyMoniker Name="EntityProperty/Type" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="entityReferencesTargetEntitiesId">
            <DomainPropertyMoniker Name="EntityProperty/EntityReferencesTargetEntitiesId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="required">
            <DomainPropertyMoniker Name="EntityProperty/Required" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="EntityHasPrimitiveProperties" MonikerAttributeName="" SerializeId="true" MonikerElementName="entityHasPrimitivePropertiesMoniker" ElementName="entityHasPrimitiveProperties" MonikerTypeName="EntityHasPrimitivePropertiesMoniker">
        <DomainRelationshipMoniker Name="EntityHasPrimitiveProperties" />
      </XmlClassData>
      <XmlClassData TypeName="EntityHasEntityProperties" MonikerAttributeName="" SerializeId="true" MonikerElementName="entityHasEntityPropertiesMoniker" ElementName="entityHasEntityProperties" MonikerTypeName="EntityHasEntityPropertiesMoniker">
        <DomainRelationshipMoniker Name="EntityHasEntityProperties" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="ColumbiaExplorer" />
  <ConnectionBuilders>
    <ConnectionBuilder Name="EntityReferencesTargetEntitiesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="EntityReferencesTargetEntities" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Entity" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Entity" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <Diagram Id="335cf4bb-55cc-4a3e-97d1-eaaefc111bcb" Description="Columbia domain model that allows you to generate code for Columbia Framework Template" Name="ColumbiaDiagram" DisplayName="Columbia Domain Model" Namespace="Columbia.Dsl" FillColor="179, 206, 235">
    <Class>
      <DomainClassMoniker Name="DomainModel" />
    </Class>
    <ShapeMaps>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="Entity" />
        <ParentElementPath>
          <DomainPath>DomainModelHasEntities.DomainModel/!DomainModel</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="EntityShape/Name" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Entity/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <CompartmentShapeMoniker Name="EntityShape" />
        <CompartmentMap>
          <CompartmentMoniker Name="EntityShape/Properties" />
          <ElementsDisplayed>
            <DomainPath>EntityHasPrimitiveProperties.PrimitiveProperties/!PrimitiveProperty</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="PrimitiveProperty/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
        <CompartmentMap>
          <CompartmentMoniker Name="EntityShape/Relations" />
          <ElementsDisplayed>
            <DomainPath>EntityHasEntityProperties.EntityProperties/!EntityProperty</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="EntityProperty/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
      </CompartmentShapeMap>
    </ShapeMaps>
    <ConnectorMaps>
      <ConnectorMap>
        <ConnectorMoniker Name="EntityConnector" />
        <DomainRelationshipMoniker Name="EntityReferencesTargetEntities" />
      </ConnectorMap>
    </ConnectorMaps>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="cdm" EditorGuid="b0ede48e-bc62-4c07-8a7a-0192d1eb2a46">
    <RootClass>
      <DomainClassMoniker Name="DomainModel" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="ColumbiaSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="Columbia">
      <ElementTool Name="Entity" ToolboxIcon="Resources\Images\DomainEntity.bmp" Caption="Entity" Tooltip="Create an Entity" HelpKeyword="CreateEntityF1Keyword">
        <DomainClassMoniker Name="Entity" />
      </ElementTool>
      <ConnectionTool Name="EntityRelationship" ToolboxIcon="Resources\Images\DomainEntityConnector.bmp" Caption="EntityRelationship" Tooltip="Drag between entites to create an relationship" HelpKeyword="ConnectExampleRelationF1Keyword">
        <ConnectionBuilderMoniker Name="Columbia/EntityReferencesTargetEntitiesBuilder" />
      </ConnectionTool>
    </ToolboxTab>
    <Validation UsesMenu="false" UsesOpen="false" UsesSave="false" UsesLoad="false" />
    <DiagramMoniker Name="ColumbiaDiagram" />
  </Designer>
  <Explorer ExplorerGuid="6052f0dc-5f8a-4cb9-817a-2e3b9822dc70" Title="Columbia Explorer">
    <ExplorerBehaviorMoniker Name="Columbia/ColumbiaExplorer" />
  </Explorer>
</Dsl>