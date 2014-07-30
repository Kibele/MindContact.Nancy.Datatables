﻿/*
 * Created by SharpDevelop.
 * User: MindContact
 * Date: 23/07/2014
 * Time: 16.38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MindContact.Nancy.Datatables
{
	public class ColDef
    {
        protected internal ColDef(Type type)
        {
            Type = type;
            Filter = new FilterDef(Type);
        }

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Visible { get; set; }
        public bool Sortable { get; set; }
        public Type Type { get; set; }
        public bool Searchable { get; set; }
        public String CssClass { get; set; }
        public String CssClassHeader { get; set; }
        public SortDirection SortDirection { get; set; }
        public string MRenderFunction { get; set; }
        public FilterDef Filter { get; set; }

        public static ColDef Create(string name, string p1, Type propertyType, bool visible = true, bool sortable = true,
            SortDirection sortDirection = SortDirection.None, string mRenderFunction = null, string pCssClass = "",
            string pCssClassHeader = "")
        {
            return new ColDef(propertyType)
            {
                Name = name,
                DisplayName = p1,
                Visible = visible,
                Sortable = sortable,
                SortDirection = sortDirection,
                MRenderFunction = mRenderFunction,
                CssClass = pCssClass,
                CssClassHeader = pCssClassHeader,
            };
        }


    }
}
