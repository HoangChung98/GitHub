using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N35_WebBanDT.Models.Entities;
namespace N35_WebBanDT.Models.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                if (HttpContext.Current == null)
                {
                    filterContext.Result = new RedirectToRouteResult(
                             new System.Web.Routing.RouteValueDictionary(
                              new
                              {
                                  Areas="Admin",
                                  Controller = "AdminLogin",
                                  Action = "AdminLogin",
                                  ReturnUrl = filterContext.HttpContext.Request.RawUrl
                              }));
                    return;
                }
            var acc = (Account)HttpContext.Current.Session["Login"];
            if (acc == null)
                {
                     
                    //  filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Account", Action = "Index" }));
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                            new
                            {
                                Areas="Admin",
                                Controller = "AdminLogin",
                                Action = "AdminLogin",
                                ReturnUrl = filterContext.HttpContext.Request.RawUrl
                            }));
                 
                }
                else
                {
                    CustomPrincipal cp = new CustomPrincipal(acc);
                    if (!cp.IsInRole(Roles))
                    {
                        filterContext.Result = new RedirectToRouteResult(
                            new System.Web.Routing.RouteValueDictionary(
                                new { Controller = "AdminLogin", Action = "AdminLogin" }));
                       
                }
                }
                // giờ sử dụng bằng cách thêm [CustomAuthorize] vào trước các controller bắt buộc phải đăng nhập
            }
        }
    }

