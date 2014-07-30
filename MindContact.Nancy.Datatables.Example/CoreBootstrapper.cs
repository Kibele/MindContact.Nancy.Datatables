/*
 * Created by SharpDevelop.
 * User: MindContact
 * Date: 30/07/2014
 * Time: 09.06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Nancy.Bootstrapper;

namespace MindContact.Nancy.Datatables.Example
{
	public class CoreBootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
        }

		protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
		{
			base.ConfigureRequestContainer(container, context);
		}

		protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
		{
			StaticConfiguration.CaseSensitive = true;
			StaticConfiguration.DisableErrorTraces = false;
			StaticConfiguration.EnableRequestTracing = true;

			base.ApplicationStartup(container, pipelines);
		}

		protected override void ConfigureConventions(NancyConventions conventions)
		{
			conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Content", @"Content"));
			conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Scripts", @"Scripts"));
			base.ConfigureConventions(conventions);
		}
	}
}