namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class ExternalUserLocationsDeleteTestDomainClasses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentPerCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Students", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentPerCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "UpdatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "CreatedBy" });
            DropIndex("dbo.Courses", new[] { "UpdatedBy" });
            DropIndex("dbo.Courses", new[] { "DeletedBy" });
            DropIndex("dbo.StudentPerCourses", new[] { "StudentId" });
            DropIndex("dbo.StudentPerCourses", new[] { "CourseId" });
            DropIndex("dbo.Students", new[] { "CreatedBy" });
            DropIndex("dbo.Students", new[] { "UpdatedBy" });
            DropIndex("dbo.Students", new[] { "DeletedBy" });
            AddColumn("dbo.Externals", "Location_Id", c => c.Int());
            CreateIndex("dbo.Externals", "Location_Id");
            AddForeignKey("dbo.Externals", "Location_Id", "dbo.Locations", "Id");
            DropTable("dbo.Courses",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Course_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.StudentPerCourses");
            DropTable("dbo.Students",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Student_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        Birthday = c.DateTime(nullable: false),
                        Genre = c.Int(nullable: false),
                        CurrentStatus = c.Int(nullable: false),
                        LastVisit = c.DateTime(),
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
                    { "DynamicFilter_Student_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuscribedAt = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
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
                    { "DynamicFilter_Course_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Externals", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Externals", new[] { "Location_Id" });
            DropColumn("dbo.Externals", "Location_Id");
            CreateIndex("dbo.Students", "DeletedBy");
            CreateIndex("dbo.Students", "UpdatedBy");
            CreateIndex("dbo.Students", "CreatedBy");
            CreateIndex("dbo.StudentPerCourses", "CourseId");
            CreateIndex("dbo.StudentPerCourses", "StudentId");
            CreateIndex("dbo.Courses", "DeletedBy");
            CreateIndex("dbo.Courses", "UpdatedBy");
            CreateIndex("dbo.Courses", "CreatedBy");
            AddForeignKey("dbo.Courses", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Students", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.StudentPerCourses", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Students", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.StudentPerCourses", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Courses", "CreatedBy", "dbo.AspNetUsers", "Id");
        }
    }
}
