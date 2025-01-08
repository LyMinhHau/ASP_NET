using System.Web.Mvc;
using System.Web.Routing;

public class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        // Route dành cho tìm kiếm sản phẩm
        routes.MapRoute(
            name: "ProductSearch",
            url: "Product/SearchResults",
            defaults: new { controller = "Product", action = "SearchResults" },
            namespaces: new[] { "ChuyenDeASPNET.Controllers" }
        );

        // Route mặc định
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "ChuyenDeASPNET.Controllers" }
        );
    }
}
