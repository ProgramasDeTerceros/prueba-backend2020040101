using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using backendEscuela.Models;

namespace backendEscuela.Controllers
{


	[Route("api/[controller]")]
	[ApiController]
	public class SolicitudController : ControllerBase
	{
		private readonly IMemoryCache _memoryCache;

		private readonly string SolicitudesKey = "SolicitudesKey";
		public SolicitudController(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		private void SaveList(Solicitud[] solicitudesCollection)
		{
			_memoryCache.Set(SolicitudesKey, solicitudesCollection);
		}
		private Solicitud[] GetList()
		{
			Solicitud[] solicitudesCollection = null;
			if (_memoryCache.TryGetValue(SolicitudesKey, out solicitudesCollection))
			{
				return solicitudesCollection;
			}
			solicitudesCollection = new Solicitud[] { };
			SaveList(solicitudesCollection);
			return solicitudesCollection;
		}

		[HttpGet]
		public IEnumerable<Solicitud> Get()
		{
			return GetList();
		}

		// GET api/escuela/1
		[HttpGet("{id}")]
		public ActionResult<Solicitud> Get(int id)
		{
			Solicitud[] solicitudes = GetList();
			return Array.Find(solicitudes, (element) => element.Id == id);
		}

		// POST
		[HttpPost]
		public void Post([FromBody] Solicitud solicitud)
		{
			if (!solicitud.IsValid())
			{
				return;
			}
			Solicitud[] solicitudes = GetList();
			Array.Resize(ref solicitudes, solicitudes.Length + 1);
			solicitudes[solicitudes.GetUpperBound(0)] = solicitud;
			SaveList(solicitudes);
		}


		// PUT api/escuela/1
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] Solicitud solicitud)
		{
			if (!solicitud.IsValid())
			{
				return;
			}
			Solicitud[] solicitudes = GetList();
			var index = Array.FindIndex(solicitudes, row => row.Id == id);
			solicitudes[index] = solicitud;
			SaveList(solicitudes);
		}

		// DELETE api/escuela/1
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			Solicitud[] solicitudes = GetList();
			solicitudes = solicitudes.Where(e => e.Id != id).ToArray();
			SaveList(solicitudes);
		}
	}
}