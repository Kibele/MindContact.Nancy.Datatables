using System;
using Nancy;
using Nancy.ModelBinding;

namespace MindContact.Nancy.Datatables
{
    /// <summary>
    /// Model binder for datatables.js parameters a la http://geeksprogramando.blogspot.com/2011/02/jquery-datatables-plug-in-with-asp-mvc.html
    /// </summary>
    public class DataTablesModelBinder : IModelBinder
    {
		#region IModelBinder implementation

		public bool CanBind(Type modelType)
		{
			return modelType == typeof(DataTablesParam);
		}

		#endregion

		#region IBinder implementation

		public object Bind(NancyContext context, Type modelType, object instance, BindingConfig configuration, params string[] blackList)
		{
			dynamic valueProvider = context.Request.Form;
            var obj = new DataTablesParam(GetIntValue(valueProvider, "iColumns"));

            obj.iDisplayStart = GetIntValue(valueProvider, "iDisplayStart");
            obj.iDisplayLength = GetIntValue(valueProvider, "iDisplayLength");
            obj.sSearch = GetStringValue(valueProvider, "sSearch");
            obj.bEscapeRegex = GetBoolValue(valueProvider, "bEscapeRegex");
            obj.iSortingCols = GetIntValue(valueProvider, "iSortingCols");
            obj.sEcho = GetIntValue(valueProvider, "sEcho");
            
            for (int i = 0; i < obj.iColumns; i++)
            {
                obj.bSortable.Add(GetBoolValue(valueProvider, "bSortable_" + i));
                obj.bSearchable.Add(GetBoolValue(valueProvider, "bSearchable_" + i));
                obj.sSearchColumns.Add(GetStringValue(valueProvider, "sSearch_" + i));
                obj.bEscapeRegexColumns.Add(GetBoolValue(valueProvider, "bEscapeRegex_" + i));
                obj.iSortCol.Add(GetIntValue(valueProvider, "iSortCol_" + i));
                obj.sSortDir.Add(GetStringValue(valueProvider, "sSortDir_" + i));
            }
            return obj;            
		}

		#endregion

		static int GetIntValue(dynamic valueProvider, string key)
        {
        	string valueResult = valueProvider[key].Value;

            return (valueResult != null)
                ? int.Parse(valueResult)
            	: 0;
        }

		static string GetStringValue(dynamic valueProvider, string key)
        {
        	string valueResult = valueProvider[key].Value;

			return valueResult ?? "";
        }

		static bool GetBoolValue(dynamic valueProvider, string key)
        {
        	string valueResult = valueProvider[key].Value;

			return (valueResult != null) && bool.Parse(valueResult);
        }
    }

//    public class DataTablesModelBinder : IModelBinder
//    {
//        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
//        {
//            var valueProvider = bindingContext.ValueProvider;
//
//            DataTablesParam obj = new DataTablesParam(GetValue<int>(valueProvider, "iColumns"));
//
//            obj.iDisplayStart = GetValue<int>(valueProvider, "iDisplayStart");
//            obj.iDisplayLength = GetValue<int>(valueProvider, "iDisplayLength");
//            obj.sSearch = GetValue<string>(valueProvider, "sSearch");
//            obj.bEscapeRegex = GetValue<bool>(valueProvider, "bEscapeRegex");
//            obj.iSortingCols = GetValue<int>(valueProvider, "iSortingCols");
//            obj.sEcho = GetValue<int>(valueProvider, "sEcho");
//            
//            for (int i = 0; i < obj.iColumns; i++)
//            {
//                obj.bSortable.Add(GetValue<bool>(valueProvider, "bSortable_" + i));
//                obj.bSearchable.Add(GetValue<bool>(valueProvider, "bSearchable_" + i));
//                obj.sSearchColumns.Add(GetValue<string>(valueProvider, "sSearch_" + i));
//                obj.bEscapeRegexColumns.Add(GetValue<bool>(valueProvider, "bEscapeRegex_" + i));
//                obj.iSortCol.Add(GetValue<int>(valueProvider, "iSortCol_" + i));
//                obj.sSortDir.Add(GetValue<string>(valueProvider, "sSortDir_" + i));
//            }
//            return obj;            
//        }
//
//        private static T GetValue<T>(IValueProvider valueProvider, string key)
//        {
//            ValueProviderResult valueResult = valueProvider.GetValue(key);
//            return (valueResult==null)
//                ? default(T)
//                : (T)valueResult.ConvertTo(typeof(T));
//        }
//    }
}