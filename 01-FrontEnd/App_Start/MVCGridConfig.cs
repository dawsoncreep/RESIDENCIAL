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

            MVCGridDefinitionTable.Add("ExternalUserGrid", new MVCGridBuilder<External>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add("Edit").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => c.UrlHelper.Action("Edit", "ExternalUser", new { Area = "Administration", id = i.Id }))
                        .WithValueTemplate("<a href={Value} class = 'btn btn-default'>" +
                        "<span class='glyphicon glyphicon-pencil' aria-hidden='true'></span>" +
                        "</a>")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 warning center" : "col-xs-1 danger");
                    cols.Add("Delete").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => i.Id.ToString())
                        .WithValueTemplate("<button class='btn btn-default deleteButton' id='deleteBtnExternalUser' idDelete = '{Value}'>" +
                        "<span class='glyphicon glyphicon-trash' aria-hidden='true'></span>" +
                        " </button> ")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 danger center" : "col-xs-1 danger");
                    cols.Add().WithColumnName("Id")
                        .WithHeaderText("Id")
                        .WithValueExpression(i => i.Id.ToString()); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("Name")
                        .WithHeaderText(Resources.Name)
                        .WithValueExpression(i => i.Name);
                    cols.Add().WithColumnName("FirstName")
                        .WithHeaderText(Resources.FirstName)
                        .WithValueExpression(i => i.FirstName);
                    cols.Add().WithColumnName("LastName")
                        .WithHeaderText(Resources.LastName)
                        .WithValueExpression(i => i.LastName);
                    cols.Add().WithColumnName("LicencePlate")
                        .WithHeaderText(Resources.LicensePlate)
                        .WithValueExpression(i => i.LicensePlate);
                    cols.Add().WithColumnName("ExternalType")
                        .WithHeaderText(Resources.ExternalType)
                        .WithValueExpression(i => i.ExternalType.Description);
                    cols.Add().WithColumnName("Location")
                        .WithHeaderText(Resources.Location)
                        .WithValueExpression(i => 
                            String.Format("{0} {1}",
                                i.Location.Street,
                                i.Location.OutNumber));
                    cols.Add("Image").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueTemplate("<img class='img-responsive img-thumbnail' id='imgExternalUser' src='{Model.Image}' />")
                        .WithCellCssClassExpression(p => p.Image != null ?  "col-xs-1 danger center" : "col-xs-1 danger");

                })
                .WithSorting(true, "Id")
                .WithPaging(true, 10)
                .WithRetrieveDataMethod((context) =>
                {
                    var options = context.QueryOptions;
                    var result = new QueryResult<External>();
                    IExternalUserService _externalUserService = DependecyFactory.GetInstance<IExternalUserService>();
                    var query = _externalUserService.GetAll().AsQueryable();

                    result.TotalRecords = query.Count();

                    if (options.GetLimitOffset().HasValue)
                    {
                        query = query.Skip(options.GetLimitOffset().Value).Take(options.GetLimitRowcount().Value);
                    }
                    result.Items = query.ToList();
                    return result;
                })
            );

            MVCGridDefinitionTable.Add("LocationUserGrid", new MVCGridBuilder<LocationUser>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add("Edit").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => c.UrlHelper.Action("Edit", "LocationUser", new { Area = "Administration", id = i.Id }))
                        .WithValueTemplate("<a href={Value} class = 'btn btn-default'>" +
                        "<span class='glyphicon glyphicon-pencil' aria-hidden='true'></span>" +
                        "</a>")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 warning center" : "col-xs-1 danger");
                    cols.Add("Delete").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => i.Id.ToString())
                        .WithValueTemplate("<button class='btn btn-default deleteButton' id='deleteBtnLocationUser' idDelete = '{Value}'>" +
                        "<span class='glyphicon glyphicon-trash' aria-hidden='true'></span>" +
                        " </button> ")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 danger center" : "col-xs-1 danger");
                    cols.Add().WithColumnName("Id")
                        .WithHeaderText("Id")
                        .WithValueExpression(i => i.Id.ToString()); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("User")
                        .WithHeaderText(Resources.LocationUser_UName)
                        .WithValueExpression(i => i.ApplicationUser.UserName);
                    cols.Add().WithColumnName("Location")
                        .WithHeaderText(Resources.LocationUser_lName)
                        .WithValueExpression(i => i.Location.Name);
                    
                })
                .WithSorting(true, "Id")
                .WithPaging(true, 10)
                .WithRetrieveDataMethod((context) =>
                {
                    var options = context.QueryOptions;
                    var result = new QueryResult<LocationUser>();
                    ILocationUserService _locationUserService = DependecyFactory.GetInstance<ILocationUserService>();
                    var query = _locationUserService.GetAll().AsQueryable();

                    result.TotalRecords = query.Count();

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

            MVCGridDefinitionTable.Add("PermissionGrid", new MVCGridBuilder<Permission>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add("Edit").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => c.UrlHelper.Action("Edit", "Permission", new { Area = "Administration", id = i.Id }))
                        .WithValueTemplate("<a href={Value} class = 'btn btn-default'>" +
                        "<span class='glyphicon glyphicon-pencil' aria-hidden='true'></span>" +
                        "</a>")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 warning center" : "col-xs-1 danger");
                    cols.Add("Delete").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i,c) => i.Id.ToString()) 
                        .WithValueTemplate("<button class='btn btn-default deleteButton' id='deleteBtnPermission' idDelete = '{Value}'>" +
                        "<span class='glyphicon glyphicon-trash' aria-hidden='true'></span>" +
                        " </button> ")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 danger center" : "col-xs-1 danger");
                    cols.Add().WithColumnName("Id")
                        .WithHeaderText("Id")
                        .WithValueExpression(i => i.Id.ToString()); // use the Value Expression to return the cell text for this column
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

            MVCGridDefinitionTable.Add("ApplicationParametersGrid", new MVCGridBuilder<ApplicationParameters>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add("Edit").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => c.UrlHelper.Action("Edit", "ApplicationParameters", new { Area = "Administration", id = i.Id }))
                        .WithValueTemplate("<a href={Value} class = 'btn btn-default'>" +
                        "<span class='glyphicon glyphicon-pencil' aria-hidden='true'></span>" +
                        "</a>")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 warning center" : "col-xs-1 danger");
                    cols.Add("Delete").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => i.Id.ToString())
                        .WithValueTemplate("<button class='btn btn-default deleteButton' id='deleteBtnApplicationParameters' idDelete = '{Value}'>" +
                        "<span class='glyphicon glyphicon-trash' aria-hidden='true'></span>" +
                        " </button> ")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 danger center" : "col-xs-1 danger");
                    cols.Add().WithColumnName("Id")
                        .WithHeaderText("Id")
                        .WithValueExpression(i => i.Id.ToString()); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("Key")
                        .WithHeaderText(Resources.Key)
                        .WithValueExpression(i => i.Key);
                    cols.Add().WithColumnName("Value")
                        .WithHeaderText(Resources.Value)
                        .WithValueExpression(i => i.Value);
                    cols.Add().WithColumnName("Description")
                        .WithHeaderText("Description")
                        .WithValueExpression(i => i.Description);
                })
                .WithSorting(true, "Id")
                .WithPaging(true, 10)
                .WithRetrieveDataMethod((context) =>
                {
                    var options = context.QueryOptions;
                    var result = new QueryResult<ApplicationParameters>();
                    IApplicationParametersService _ApplicationParametersService = DependecyFactory.GetInstance<IApplicationParametersService>();
                    var query = _ApplicationParametersService.GetAll().AsQueryable();

                    result.TotalRecords = query.Count();

                    if (options.GetLimitOffset().HasValue)
                    {
                        query = query.Skip(options.GetLimitOffset().Value).Take(options.GetLimitRowcount().Value);
                    }
                    result.Items = query.ToList();
                    return result;
                })
            );

            MVCGridDefinitionTable.Add("TagGrid", new MVCGridBuilder<Tag>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add("Edit").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => c.UrlHelper.Action("Edit", "Tag", new { Area = "Administration", id = i.Id }))
                        .WithValueTemplate("<a href={Value} class = 'btn btn-default'>" +
                        "<span class='glyphicon glyphicon-pencil' aria-hidden='true'></span>" +
                        "</a>")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 warning center" : "col-xs-1 danger");
                    cols.Add("Delete").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => i.Id.ToString())
                        .WithValueTemplate("<button class='btn btn-default deleteButton' id='deleteBtnTag' idDelete = '{Value}'>" +
                        "<span class='glyphicon glyphicon-trash' aria-hidden='true'></span>" +
                        " </button> ")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 danger center" : "col-xs-1 danger");
                    cols.Add().WithColumnName("Id")
                        .WithHeaderText("Id")
                        .WithValueExpression(i => i.Id.ToString()); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("TagCode")
                        .WithHeaderText(Resources.TagCode)
                        .WithValueExpression(i => i.TagCode);
                    cols.Add().WithColumnName("VehicleBrand")
                        .WithHeaderText(Resources.Vehicle)
                        .WithValueExpression(i => String.Format("{0} {1} {2}",
                                i.VehicleBrand,
                                i.VehicleModel,
                                i.VehicleYear));
                    cols.Add().WithColumnName("User")
                        .WithHeaderText(Resources.ColonialMenu)
                        .WithValueExpression(i => String.Format("{0} {1} {2}",
                            i.ApplicationUser != null ? i.ApplicationUser.Name : string.Empty,
                            i.ApplicationUser != null ? i.ApplicationUser.LastName : string.Empty,
                            i.ApplicationUser != null ? i.ApplicationUser.MotherSurname : string.Empty));
                    cols.Add().WithColumnName("Observations")
                        .WithHeaderText(Resources.Observations)
                        .WithValueExpression(i => i.Observations);
                    cols.Add().WithColumnName("CreatedAt")
                        .WithHeaderText("CreatedAt")
                        .WithValueExpression(i => i.CreatedAt.HasValue ? 
                            i.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty);
                    cols.Add().WithColumnName("UpdatedAt")
                        .WithHeaderText("UpdatedAt")
                        .WithValueExpression(i => i.UpdatedAt.HasValue ?
                            i.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty);


                })
                .WithSorting(true, "Id")
                .WithPaging(true, 10)
                .WithRetrieveDataMethod((context) =>
                {
                    var options = context.QueryOptions;
                    var result = new QueryResult<Tag>();
                    ITagService _tagService = DependecyFactory.GetInstance<ITagService>();
                    var query = _tagService.GetAll().AsQueryable();

                    result.TotalRecords = query.Count();

                    if (options.GetLimitOffset().HasValue)
                    {
                        query = query.Skip(options.GetLimitOffset().Value).Take(options.GetLimitRowcount().Value);
                    }
                    result.Items = query.ToList();
                    return result;
                })
            );

            MVCGridDefinitionTable.Add("ExternalTypeGrid", new MVCGridBuilder<ExternalType>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add("Edit").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => c.UrlHelper.Action("Edit", "ExternalType", new { Area = "Administration", id = i.Id }))
                        .WithValueTemplate("<a href={Value} class = 'btn btn-default'>" +
                        "<span class='glyphicon glyphicon-pencil' aria-hidden='true'></span>" +
                        "</a>")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 warning center" : "col-xs-1 danger");
                    cols.Add("Delete").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => i.Id.ToString())
                        .WithValueTemplate("<button class='btn btn-default deleteButton' id='deleteBtnExternalType' idDelete = '{Value}'>" +
                        "<span class='glyphicon glyphicon-trash' aria-hidden='true'></span>" +
                        " </button> ")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 danger center" : "col-xs-1 danger");
                    cols.Add().WithColumnName("Id")
                        .WithHeaderText("Id")
                        .WithValueExpression(i => i.Id.ToString()); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("Description")
                        .WithHeaderText("Description")
                        .WithValueExpression(i => i.Description);
                })
                .WithSorting(true, "Id")
                .WithPaging(true, 10)
                .WithRetrieveDataMethod((context) =>
                {
                    var options = context.QueryOptions;
                    var result = new QueryResult<ExternalType>();
                    IExternalTypeService _externalTypeService = DependecyFactory.GetInstance<IExternalTypeService>();
                    var query = _externalTypeService.GetAll().AsQueryable();

                    result.TotalRecords = query.Count();

                    if (options.GetLimitOffset().HasValue)
                    {
                        query = query.Skip(options.GetLimitOffset().Value).Take(options.GetLimitRowcount().Value);
                    }
                    result.Items = query.ToList();
                    return result;
                })
            );

            MVCGridDefinitionTable.Add("EventTypeGrid", new MVCGridBuilder<EventType>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add("Edit").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => c.UrlHelper.Action("Edit", "EventType", new { Area = "Administration", id = i.Id }))
                        .WithValueTemplate("<a href={Value} class = 'btn btn-default'>" +
                        "<span class='glyphicon glyphicon-pencil' aria-hidden='true'></span>" +
                        "</a>")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 warning center" : "col-xs-1 danger"); 
                    cols.Add("Delete").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => i.Id.ToString())
                        .WithValueTemplate("<button class='btn btn-default deleteButton' id='deleteBtnEventType' idDelete = '{Value}'>" +
                        "<span class='glyphicon glyphicon-trash' aria-hidden='true'></span>" +
                        " </button> ")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 danger center" : "col-xs-1 danger");
                    cols.Add().WithColumnName("Id")
                        .WithHeaderText("Id")
                        .WithValueExpression(i => i.Id.ToString()); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("Description")
                        .WithHeaderText("Description")
                        .WithValueExpression(i => i.Description);
                })
                .WithSorting(true, "Id")
                .WithPaging(true, 10)
                .WithRetrieveDataMethod((context) =>
                {
                    var options = context.QueryOptions;
                    var result = new QueryResult<EventType>();
                    IEventTypeService _eventTypeService = DependecyFactory.GetInstance<IEventTypeService>();
                    var query = _eventTypeService.GetAll().AsQueryable();

                    result.TotalRecords = query.Count();

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


            MVCGridDefinitionTable.Add("LocationTypeGrid", new MVCGridBuilder<LocationType>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add("Edit").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => c.UrlHelper.Action("Edit", "LocationType", new { Area = "Administration", id = i.Id }))
                        .WithValueTemplate("<a href={Value} class = 'btn btn-default'>" +
                        "<span class='glyphicon glyphicon-pencil' aria-hidden='true'></span>" +
                        "</a>")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 warning center" : "col-xs-1 danger");
                    cols.Add("Delete").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => i.Id.ToString())
                        .WithValueTemplate("<button class='btn btn-default deleteButton' id='deleteBtnLocationType' idDelete = '{Value}'>" +
                        "<span class='glyphicon glyphicon-trash' aria-hidden='true'></span>" +
                        " </button> ")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 danger center" : "col-xs-1 danger");
                    cols.Add().WithColumnName("Id")
                        .WithHeaderText("Id")
                        .WithValueExpression(i => i.Id.ToString()); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("Description")
                        .WithHeaderText("Description")
                        .WithValueExpression(i => i.Description);
                })
                .WithSorting(true, "Id")
                .WithPaging(true, 10)
                .WithRetrieveDataMethod((context) =>
                {
                    var options = context.QueryOptions;
                    var result = new QueryResult<LocationType>();
                    ILocationTypeService _locationTypeService = DependecyFactory.GetInstance<ILocationTypeService>();
                    var query = _locationTypeService.GetAll().AsQueryable();

                    result.TotalRecords = query.Count();

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


            MVCGridDefinitionTable.Add("LocationGrid", new MVCGridBuilder<Location>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add("Edit").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => c.UrlHelper.Action("Edit", "Location", new { Area = "Administration", id = i.Id }))
                        .WithValueTemplate("<a href={Value} class = 'btn btn-default'>" +
                        "<span class='glyphicon glyphicon-pencil' aria-hidden='true'></span>" +
                        "</a>")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 warning center" : "col-xs-1 danger");
                    cols.Add("Delete").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => i.Id.ToString())
                        .WithValueTemplate("<button class='btn btn-default deleteButton' id='deleteBtnLocation' idDelete = '{Value}'>" +
                        "<span class='glyphicon glyphicon-trash' aria-hidden='true'></span>" +
                        " </button> ")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 danger center" : "col-xs-1 danger");

                    cols.Add().WithColumnName("Id")
                        .WithHeaderText("Id")
                        .WithValueExpression(i => i.Id.ToString()); 

                    cols.Add().WithColumnName("Name")
                        .WithHeaderText("Name")
                        .WithValueExpression(i => i.Name);

                    cols.Add().WithColumnName("Description")
                        .WithHeaderText("Description")
                        .WithValueExpression(i => i.Description);

                    cols.Add().WithColumnName("OutNumber")
                        .WithHeaderText("OutNumber")
                        .WithValueExpression(i => i.OutNumber);

                    cols.Add().WithColumnName("InNumber")
                        .WithHeaderText("InNumber")
                        .WithValueExpression(i => i.InNumber);

                    cols.Add().WithColumnName("LocationType")
                        .WithHeaderText("LocationType")
                        .WithValueExpression(i => i.LocationType.Description);
                })
                .WithSorting(true, "Id")
                .WithPaging(true, 10)
                .WithRetrieveDataMethod((context) =>
                {
                    var options = context.QueryOptions;
                    var result = new QueryResult<Location>();
                    ILocationService _locationService = DependecyFactory.GetInstance<ILocationService>();
                    var query = _locationService.GetAll().AsQueryable();

                    result.TotalRecords = query.Count();

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


            MVCGridDefinitionTable.Add("EventGrid", new MVCGridBuilder<Event>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add("Edit").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => c.UrlHelper.Action("Edit", "Event", new { Area = "Colonial", id = i.Id }))
                        .WithValueTemplate("<a href={Value} class = 'btn btn-default'>" +
                        "<span class='glyphicon glyphicon-pencil' aria-hidden='true'></span>" +
                        "</a>")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 warning center" : "col-xs-1 danger");
                    cols.Add("Delete").WithHtmlEncoding(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((i, c) => i.Id.ToString())
                        .WithValueTemplate("<button class='btn btn-default deleteButton' id='deleteBtnEvent' idDelete = '{Value}'>" +
                        "<span class='glyphicon glyphicon-trash' aria-hidden='true'></span>" +
                        " </button> ")
                        .WithCellCssClassExpression(p => p.Id > 0 ? "col-xs-1 danger center" : "col-xs-1 danger");
                    cols.Add().WithColumnName("Id")
                        .WithHeaderText("Id")
                        .WithValueExpression(i => i.Id.ToString()); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("Description")
                        .WithHeaderText("Description")
                        .WithValueExpression(i => i.Description);
                    cols.Add().WithColumnName("DateStart")
                        .WithHeaderText("DateStart")
                        .WithValueExpression(i => i.DateStart.ToString("yyyy-MM-dd HH:mm:ss"));
                    cols.Add().WithColumnName("DateEnd")
                        .WithHeaderText("DateEnd")
                        .WithValueExpression(i => i.DateEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                    cols.Add().WithColumnName("EventTypeDescription")
                        .WithHeaderText("EventTypeDescription")
                        .WithValueExpression(i => i.EventType.Description);
                    cols.Add().WithColumnName("LocationDescription")
                        .WithHeaderText("LocationDescription")
                        .WithValueExpression(i => i.Location.Name);

                })
                .WithSorting(true, "Id")
                .WithPaging(true, 10)
                .WithRetrieveDataMethod((context) =>
                {
                    var options = context.QueryOptions;
                    var result = new QueryResult<Event>();
                    IEventService _locationTypeService = DependecyFactory.GetInstance<IEventService>();
                    var query = _locationTypeService.GetAll().AsQueryable();

                    result.TotalRecords = query.Count();

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