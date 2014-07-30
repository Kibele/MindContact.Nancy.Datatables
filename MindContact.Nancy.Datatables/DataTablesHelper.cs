﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MindContact.Nancy.Datatables
{
    public static class DataTablesHelper
    {
//        public static DataTableConfigVm DataTableVm<TController, TResult>(this HtmlHelper html, string id, Expression<Func<TController, DataTablesResult<TResult>>> exp, IEnumerable<ColDef> columns = null)
//        {
//            if (columns == null || !columns.Any())
//            {
//                columns = ColDefs<TResult>();
//            }
//
//            var mi = exp.MethodInfo();
//            var controllerName = typeof(TController).Name;
//            controllerName = controllerName.Substring(0, controllerName.LastIndexOf("Controller"));
//            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
//            var ajaxUrl = urlHelper.Action(mi.Name, controllerName);
//            return new DataTableConfigVm(id, ajaxUrl, columns);
//        }
//
//        public static DataTableConfigVm DataTableVm<TResult>(this HtmlHelper html, string id, Uri uri)
//        {
//            return new DataTableConfigVm(id, uri.ToString(), ColDefs<TResult>());
//        }

        public static DataTableConfigVm DataTableVm<TResult>(string id, string uri)
        {
            return new DataTableConfigVm(id, uri, ColDefs<TResult>());
        }

        public static ColDef[] ColDefs<TResult>()
        {
            var propInfos = DataTablesTypeInfo<TResult>.Properties;
            var columnList = new List<ColDef>();
            foreach (var pi in propInfos)
            {
                columnList.Add(new ColDef(pi.Item1.PropertyType)
                {
                    Name = pi.Item1.Name,
                    DisplayName = pi.Item2.ToDisplayName() ?? pi.Item1.Name,
                    Sortable = pi.Item2.Sortable,
                    Visible = pi.Item2.Visible,
                    Searchable = pi.Item2.Searchable,
                    SortDirection = pi.Item2.SortDirection,
                    MRenderFunction = pi.Item2.MRenderFunction,
                    CssClass = pi.Item2.CssClass,
                    CssClassHeader = pi.Item2.CssClassHeader
                });
            }
            return  columnList.ToArray();
        }

//        public static DataTableConfigVm DataTableVm(this HtmlHelper html, string id, string ajaxUrl, params string[] columns)
//        {
//            return new DataTableConfigVm(id, ajaxUrl, columns.Select(c => ColDef.Create(c, (string)null, typeof(string))));
//        }
    }
}