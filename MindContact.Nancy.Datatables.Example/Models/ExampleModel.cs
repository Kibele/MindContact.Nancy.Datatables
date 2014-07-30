/*
 * Created by SharpDevelop.
 * User: MindContact
 * Date: 30/07/2014
 * Time: 09.10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MindContact.Nancy.Datatables.Example.Models
{
	/// <summary>
	/// Description of ExampleModel.
	/// </summary>
	public class ExampleModel
	{
		public string ExampleString { get; set; }
		public bool ExampleBool { get; set; }
		public int ExampleInt { get; set; }
		public DateTime ExampleDateTime { get; set; }
		
		public static ExampleModel GetRandom()
		{
			var x = new ExampleModel();
			
			x.ExampleString = DateTime.Now.Millisecond.ToString();
			x.ExampleBool = DateTime.Now.Second % 2 == 0;
			x.ExampleInt = DateTime.Now.Second;
			x.ExampleDateTime = DateTime.Now;
			
			return x;
		}
	}
}
