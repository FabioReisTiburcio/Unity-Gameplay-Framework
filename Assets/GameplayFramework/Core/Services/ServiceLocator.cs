using System;
using System.Collections.Generic;

namespace GameplayFramework.Core.Services
{
	public static class ServiceLocator
	{
		private static readonly Dictionary<Type, object> _services = new();

		public static void Register<T>(T service)
		{
			if (service == null)
			{
				throw new ArgumentNullException(nameof(service));
			}
			Type serviceType = typeof(T);
			if (_services.ContainsKey(serviceType))
			{
				throw new InvalidOperationException(
	$"Service '{serviceType.Name}' is already registered.");
			}
			_services.Add(serviceType, service);
		}

		public static T Get<T>()
		{
			Type serviceType = typeof(T);
			if (_services.TryGetValue(serviceType, out var service))
			{
				return (T)service;
			}
			throw new InvalidOperationException(
	$"Service '{serviceType.Name}' is not registered.");
		}

		public static bool Contains<T>()
		{
			return _services.ContainsKey(typeof(T));
		}

		public static void Unregister<T>()
		{
			_services.Remove(typeof(T));
		}

		public static void Clear()
		{
			_services.Clear();
		}
	}
}