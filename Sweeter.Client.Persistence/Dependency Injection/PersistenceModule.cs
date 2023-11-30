﻿using MediatR;
using Ninject.Web.Common;

namespace Sweeter.Client.Persistence
{
	public class PersistenceModule : Ninject.Modules.NinjectModule
	{
		public override void Load()
		{
			Bind<IServiceProvider>().ToMethod(ctx => ctx.Kernel);
			Bind<IMediator>().To<Mediator>();

			Bind<IRequestHandler<GetServerStatusQuery, ServerDiagnostics>>().To<GetServerStatusHandler>().InRequestScope();
		}
	}
}