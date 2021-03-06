/*
 * Created by SharpDevelop.
 * User: MindContact
 * Date: 23/07/2014
 * Time: 19.10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;

namespace MindContact.Nancy.Datatables
{
	/// <summary>
	/// Description of DataTablesData.
	/// </summary>
	public class DataTablesData
    {
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public int sEcho { get; set; }
        public object[] aaData { get; set; }

        public DataTablesData Transform<TData, TTransform>(Func<TData, TTransform> transformRow)
        {
            var data = new DataTablesData 
            {
                aaData = aaData.Cast<TData>().Select(transformRow).Cast<object>().ToArray(),
                iTotalDisplayRecords = iTotalDisplayRecords,
                iTotalRecords = iTotalRecords,
                sEcho = sEcho
            };
            return data;
        }
    }
}
