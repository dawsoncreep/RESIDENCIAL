//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FrontEnd.MVCGridConfig), "RegisterGrids")]

namespace FrontEnd
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using MVCGrid.Models;
    using MVCGrid.Web;
    using Model.Custom;
    using Model.Domain;
    using Resources;
    using Service.InternalService;
    using Common;

    public static class MVCGridConfig 
    {
        public static void RegisterGrids()
        {

            MVCGridDefinitionTable.Add("PermissionGrid", new MVCGridBuilder<Permission>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add("Edit").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => c.UrlHelper.Action("Edit","Permission",new { Area="Administration",id = i.Id }))
                        .WithValueTemplate("<a href={Value} class = 'btn btn-default'>" + Resources.Edit+"</a>");
                    cols.Add("Delete").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i,c) => i.Id.ToString()) 
                        .WithValueTemplate("<button class='btn btn-default deletePermissionButton' id='deleteBtnPermission' idDelete = '{Value}'>"+
                                @Resources.Delete+" </button> ");
                    cols.Add().WithColumnName("Id")
                        .WithHeaderText("Id")
                        .WithValueExpression(i => i.Name); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("ResourceCode")
                        .WithHeaderText(Resources.Permission_Code)
                        .WithValueExpression(i => i.ResourceCode);
                    cols.Add().WithColumnName("Name")
                        .WithHeaderText(Resources.Permission_Name)
                        .WithValueExpression(i => i.Name);
                    cols.Add().WithColumnName("Area")
                        .WithHeaderText(Resources.Permission_Area)
                        .WithValueExpression(i => i.Area);
                    cols.Add().WithColumnName("Action")
                        .WithHeaderText(Resources.Permission_Action)
                        .WithValueExpression(i => i.Action);
                    cols.Add().WithColumnName("Controller")
                        .WithHeaderText(Resources.Permission_Controller)
                        .WithValueExpression(i => i.Controller);

                })
                .WithSorting(true, "Id")
                .WithPaging(true, 10)
                .WithRetrieveDataMethod((context) =>
                {
                    var options = context.QueryOptions;
                    var result = new QueryResult<Permission>();
                    IPermissionService _permissionService = DependecyFactory.GetInstance<IPermissionService>();
                    var query = _permissionService.GetAll().AsQueryable();

                    result.TotalRecords = query.Count();
                    //if (!String.IsNullOrWhiteSpace(options.SortColumnName))
                    //{
                    //    switch (options.SortColumnName.ToLower())
                    //    {
                    //        case "Id":
                    //            query = query.OrderBy(p => p.Id, options.SortDirection);
                    //            break;
                    //    }
                    //}
                    if (options.GetLimitOffset().HasValue)
                    {
                        query = query.Skip(options.GetLimitOffset().Value).Take(options.GetLimitRowcount().Value);
                    }
                    result.Items = query.ToList();
                    return result;
                    //return new QueryResult<Permission>()
                    //{
                    //    Items = items,
                    //    TotalRecords = items.Count()
                    //};
                })
            );
        }
    }
}