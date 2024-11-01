using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManagerAPI.Application.Common.Behaviors;

namespace TaskManagerAPI.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
		services.AddTransient(typeof(MediatR.IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		return services;
	}
}
