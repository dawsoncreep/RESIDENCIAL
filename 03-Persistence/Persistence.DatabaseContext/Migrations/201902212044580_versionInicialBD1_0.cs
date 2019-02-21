namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class versionInicialBD1_0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Binnacles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        BinnaclePhoto_Id = c.Int(),
                        UserBinnacle_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Binnacle_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.BinnaclePhotoes", t => t.BinnaclePhoto_Id)
                .ForeignKey("dbo.UserBinnacles", t => t.UserBinnacle_Id)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.BinnaclePhoto_Id)
                .Index(t => t.UserBinnacle_Id);
            
            CreateTable(
                "dbo.BinnacleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        Binnacle_Id = c.Int(),
                        BinnaclePhoto_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BinnacleType_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.Binnacles", t => t.Binnacle_Id)
                .ForeignKey("dbo.BinnaclePhotoes", t => t.BinnaclePhoto_Id)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.Binnacle_Id)
                .Index(t => t.BinnaclePhoto_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        Binnacle_Id = c.Int(),
                        EventLocation_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Event_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.Binnacles", t => t.Binnacle_Id)
                .ForeignKey("dbo.EventLocations", t => t.EventLocation_Id)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.Binnacle_Id)
                .Index(t => t.EventLocation_Id);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        Event_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EventType_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.BinnaclePhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BinnaclePhoto_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.BinnaclePhotoTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BinnaclePhotoType_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Customer_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.CustomerBinnacles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CustomerBinnacle_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.CustomerPhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CustomerPhoto_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.EventLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EventLocation_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        EventLocation_Id = c.Int(),
                        LocationTelephone_Id = c.Int(),
                        LocationUser_Id = c.Int(),
                        LocationVehicle_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Location_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.EventLocations", t => t.EventLocation_Id)
                .ForeignKey("dbo.LocationTelephones", t => t.LocationTelephone_Id)
                .ForeignKey("dbo.LocationUsers", t => t.LocationUser_Id)
                .ForeignKey("dbo.LocationVehicles", t => t.LocationVehicle_Id)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.EventLocation_Id)
                .Index(t => t.LocationTelephone_Id)
                .Index(t => t.LocationUser_Id)
                .Index(t => t.LocationVehicle_Id);
            
            CreateTable(
                "dbo.LocationTelephones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LocationTelephone_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.LocationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LocationType_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.LocationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        LocationUserNotification_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LocationUser_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.LocationUserNotifications", t => t.LocationUserNotification_Id)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.LocationUserNotification_Id);
            
            CreateTable(
                "dbo.LocationUserNotifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LocationUserNotification_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        LocationUserNotification_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Notification_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.LocationUserNotifications", t => t.LocationUserNotification_Id)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.LocationUserNotification_Id);
            
            CreateTable(
                "dbo.LocationVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tag = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LocationVehicle_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        PermissionUser_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Permission_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.PermissionUsers", t => t.PermissionUser_Id)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.PermissionUser_Id);
            
            CreateTable(
                "dbo.PermissionUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PermissionUser_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.UserBinnacles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserBinnacle_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            AddColumn("dbo.AspNetUsers", "EventLocation_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "LocationUser_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "PermissionUser_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "UserBinnacle_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "EventLocation_Id");
            CreateIndex("dbo.AspNetUsers", "LocationUser_Id");
            CreateIndex("dbo.AspNetUsers", "PermissionUser_Id");
            CreateIndex("dbo.AspNetUsers", "UserBinnacle_Id");
            AddForeignKey("dbo.AspNetUsers", "EventLocation_Id", "dbo.EventLocations", "Id");
            AddForeignKey("dbo.AspNetUsers", "LocationUser_Id", "dbo.LocationUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "PermissionUser_Id", "dbo.PermissionUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "UserBinnacle_Id", "dbo.UserBinnacles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserBinnacle_Id", "dbo.UserBinnacles");
            DropForeignKey("dbo.UserBinnacles", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserBinnacles", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserBinnacles", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Binnacles", "UserBinnacle_Id", "dbo.UserBinnacles");
            DropForeignKey("dbo.AspNetUsers", "PermissionUser_Id", "dbo.PermissionUsers");
            DropForeignKey("dbo.PermissionUsers", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Permissions", "PermissionUser_Id", "dbo.PermissionUsers");
            DropForeignKey("dbo.PermissionUsers", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.PermissionUsers", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Permissions", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Permissions", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Permissions", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationVehicles", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Locations", "LocationVehicle_Id", "dbo.LocationVehicles");
            DropForeignKey("dbo.LocationVehicles", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationVehicles", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationUserNotifications", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "LocationUserNotification_Id", "dbo.LocationUserNotifications");
            DropForeignKey("dbo.Notifications", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationUsers", "LocationUserNotification_Id", "dbo.LocationUserNotifications");
            DropForeignKey("dbo.LocationUserNotifications", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationUserNotifications", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "LocationUser_Id", "dbo.LocationUsers");
            DropForeignKey("dbo.LocationUsers", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Locations", "LocationUser_Id", "dbo.LocationUsers");
            DropForeignKey("dbo.LocationUsers", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationUsers", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationTypes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationTypes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationTypes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationTelephones", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Locations", "LocationTelephone_Id", "dbo.LocationTelephones");
            DropForeignKey("dbo.LocationTelephones", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationTelephones", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "EventLocation_Id", "dbo.EventLocations");
            DropForeignKey("dbo.EventLocations", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Locations", "EventLocation_Id", "dbo.EventLocations");
            DropForeignKey("dbo.Locations", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Locations", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Locations", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "EventLocation_Id", "dbo.EventLocations");
            DropForeignKey("dbo.EventLocations", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventLocations", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerPhotoes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerPhotoes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerPhotoes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerBinnacles", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerBinnacles", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerBinnacles", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnaclePhotoTypes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnaclePhotoTypes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnaclePhotoTypes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnaclePhotoes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnaclePhotoes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnaclePhotoes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnacleTypes", "BinnaclePhoto_Id", "dbo.BinnaclePhotoes");
            DropForeignKey("dbo.Binnacles", "BinnaclePhoto_Id", "dbo.BinnaclePhotoes");
            DropForeignKey("dbo.Binnacles", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "Binnacle_Id", "dbo.Binnacles");
            DropForeignKey("dbo.Events", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventTypes", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.EventTypes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventTypes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventTypes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Binnacles", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Binnacles", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnacleTypes", "Binnacle_Id", "dbo.Binnacles");
            DropForeignKey("dbo.BinnacleTypes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnacleTypes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.BinnacleTypes", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.UserBinnacles", new[] { "DeletedBy" });
            DropIndex("dbo.UserBinnacles", new[] { "UpdatedBy" });
            DropIndex("dbo.UserBinnacles", new[] { "CreatedBy" });
            DropIndex("dbo.PermissionUsers", new[] { "DeletedBy" });
            DropIndex("dbo.PermissionUsers", new[] { "UpdatedBy" });
            DropIndex("dbo.PermissionUsers", new[] { "CreatedBy" });
            DropIndex("dbo.Permissions", new[] { "PermissionUser_Id" });
            DropIndex("dbo.Permissions", new[] { "DeletedBy" });
            DropIndex("dbo.Permissions", new[] { "UpdatedBy" });
            DropIndex("dbo.Permissions", new[] { "CreatedBy" });
            DropIndex("dbo.LocationVehicles", new[] { "DeletedBy" });
            DropIndex("dbo.LocationVehicles", new[] { "UpdatedBy" });
            DropIndex("dbo.LocationVehicles", new[] { "CreatedBy" });
            DropIndex("dbo.Notifications", new[] { "LocationUserNotification_Id" });
            DropIndex("dbo.Notifications", new[] { "DeletedBy" });
            DropIndex("dbo.Notifications", new[] { "UpdatedBy" });
            DropIndex("dbo.Notifications", new[] { "CreatedBy" });
            DropIndex("dbo.LocationUserNotifications", new[] { "DeletedBy" });
            DropIndex("dbo.LocationUserNotifications", new[] { "UpdatedBy" });
            DropIndex("dbo.LocationUserNotifications", new[] { "CreatedBy" });
            DropIndex("dbo.LocationUsers", new[] { "LocationUserNotification_Id" });
            DropIndex("dbo.LocationUsers", new[] { "DeletedBy" });
            DropIndex("dbo.LocationUsers", new[] { "UpdatedBy" });
            DropIndex("dbo.LocationUsers", new[] { "CreatedBy" });
            DropIndex("dbo.LocationTypes", new[] { "DeletedBy" });
            DropIndex("dbo.LocationTypes", new[] { "UpdatedBy" });
            DropIndex("dbo.LocationTypes", new[] { "CreatedBy" });
            DropIndex("dbo.LocationTelephones", new[] { "DeletedBy" });
            DropIndex("dbo.LocationTelephones", new[] { "UpdatedBy" });
            DropIndex("dbo.LocationTelephones", new[] { "CreatedBy" });
            DropIndex("dbo.Locations", new[] { "LocationVehicle_Id" });
            DropIndex("dbo.Locations", new[] { "LocationUser_Id" });
            DropIndex("dbo.Locations", new[] { "LocationTelephone_Id" });
            DropIndex("dbo.Locations", new[] { "EventLocation_Id" });
            DropIndex("dbo.Locations", new[] { "DeletedBy" });
            DropIndex("dbo.Locations", new[] { "UpdatedBy" });
            DropIndex("dbo.Locations", new[] { "CreatedBy" });
            DropIndex("dbo.EventLocations", new[] { "DeletedBy" });
            DropIndex("dbo.EventLocations", new[] { "UpdatedBy" });
            DropIndex("dbo.EventLocations", new[] { "CreatedBy" });
            DropIndex("dbo.CustomerPhotoes", new[] { "DeletedBy" });
            DropIndex("dbo.CustomerPhotoes", new[] { "UpdatedBy" });
            DropIndex("dbo.CustomerPhotoes", new[] { "CreatedBy" });
            DropIndex("dbo.CustomerBinnacles", new[] { "DeletedBy" });
            DropIndex("dbo.CustomerBinnacles", new[] { "UpdatedBy" });
            DropIndex("dbo.CustomerBinnacles", new[] { "CreatedBy" });
            DropIndex("dbo.Customers", new[] { "DeletedBy" });
            DropIndex("dbo.Customers", new[] { "UpdatedBy" });
            DropIndex("dbo.Customers", new[] { "CreatedBy" });
            DropIndex("dbo.BinnaclePhotoTypes", new[] { "DeletedBy" });
            DropIndex("dbo.BinnaclePhotoTypes", new[] { "UpdatedBy" });
            DropIndex("dbo.BinnaclePhotoTypes", new[] { "CreatedBy" });
            DropIndex("dbo.BinnaclePhotoes", new[] { "DeletedBy" });
            DropIndex("dbo.BinnaclePhotoes", new[] { "UpdatedBy" });
            DropIndex("dbo.BinnaclePhotoes", new[] { "CreatedBy" });
            DropIndex("dbo.EventTypes", new[] { "Event_Id" });
            DropIndex("dbo.EventTypes", new[] { "DeletedBy" });
            DropIndex("dbo.EventTypes", new[] { "UpdatedBy" });
            DropIndex("dbo.EventTypes", new[] { "CreatedBy" });
            DropIndex("dbo.Events", new[] { "EventLocation_Id" });
            DropIndex("dbo.Events", new[] { "Binnacle_Id" });
            DropIndex("dbo.Events", new[] { "DeletedBy" });
            DropIndex("dbo.Events", new[] { "UpdatedBy" });
            DropIndex("dbo.Events", new[] { "CreatedBy" });
            DropIndex("dbo.BinnacleTypes", new[] { "BinnaclePhoto_Id" });
            DropIndex("dbo.BinnacleTypes", new[] { "Binnacle_Id" });
            DropIndex("dbo.BinnacleTypes", new[] { "DeletedBy" });
            DropIndex("dbo.BinnacleTypes", new[] { "UpdatedBy" });
            DropIndex("dbo.BinnacleTypes", new[] { "CreatedBy" });
            DropIndex("dbo.Binnacles", new[] { "UserBinnacle_Id" });
            DropIndex("dbo.Binnacles", new[] { "BinnaclePhoto_Id" });
            DropIndex("dbo.Binnacles", new[] { "DeletedBy" });
            DropIndex("dbo.Binnacles", new[] { "UpdatedBy" });
            DropIndex("dbo.Binnacles", new[] { "CreatedBy" });
            DropIndex("dbo.AspNetUsers", new[] { "UserBinnacle_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "PermissionUser_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "LocationUser_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "EventLocation_Id" });
            DropColumn("dbo.AspNetUsers", "UserBinnacle_Id");
            DropColumn("dbo.AspNetUsers", "PermissionUser_Id");
            DropColumn("dbo.AspNetUsers", "LocationUser_Id");
            DropColumn("dbo.AspNetUsers", "EventLocation_Id");
            DropTable("dbo.UserBinnacles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserBinnacle_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PermissionUsers",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PermissionUser_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Permissions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Permission_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.LocationVehicles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LocationVehicle_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Notifications",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Notification_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.LocationUserNotifications",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LocationUserNotification_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.LocationUsers",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LocationUser_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.LocationTypes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LocationType_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.LocationTelephones",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LocationTelephone_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Locations",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Location_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.EventLocations",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EventLocation_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CustomerPhotoes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CustomerPhoto_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CustomerBinnacles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CustomerBinnacle_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Customers",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Customer_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BinnaclePhotoTypes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BinnaclePhotoType_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BinnaclePhotoes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BinnaclePhoto_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.EventTypes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EventType_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Events",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Event_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.BinnacleTypes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BinnacleType_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Binnacles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Binnacle_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
