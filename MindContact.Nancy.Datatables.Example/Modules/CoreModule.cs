/*
 * Created by SharpDevelop.
 * User: MindContact
 * Date: 30/07/2014
 * Time: 09.08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using Nancy;
using Nancy.Extensions;
using Nancy.Json;
using Nancy.ModelBinding;
using MindContact.Nancy.Datatables.Example.Models;

namespace MindContact.Nancy.Datatables.Example.Module
{
	/// <summary>
	/// Description of CoreModule.
	/// </summary>
	public class CoreModule : NancyModule
	{
		public dynamic Model = new ExpandoObject();

		public CoreModule()
		{
			Get["/"] = x =>
			{
				Model.DataTableVm = DataTablesHelper.DataTableVm<ExampleModel>("ExampleDataTable", "/ajax/list");

				return View["Home/Index", Model];
			};
			
			Post["/ajax/list"] = x =>
			{
				DataTablesParam dataTableParam = this.Bind<DataTablesParam>();
				
				var aoData = new List<ExampleModel>();
				for (int i = 0; i < 256; i++)
					aoData.Add(ExampleModel.GetRandom());

				return DataTablesResult.CreateResultUsingEnumerable<ExampleModel>(aoData, dataTableParam).Data;
			};
		}
	}
}
