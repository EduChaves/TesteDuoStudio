using API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public IEnumerable<Indicator> GetData()
        {
            var list = new List<Indicator>();
            list.Add(Service.DatabaseConfiguration(" SELECT (SELECT resposta_text FROM indicadores_respostas WHERE id = 4927575), cidades.latitude, longitude FROM cidades WHERE cidades_id = CAST((SELECT resposta_text FROM indicadores_respostas WHERE id = 4927583) AS UNSIGNED INTEGER)"));
            list.Add(Service.DatabaseConfiguration(" SELECT r1.resposta_text, r2.resposta_text AS latitude, r3.resposta_text AS longitude FROM (SELECT * FROM indicadores_respostas WHERE id = 195740) AS r1 INNER JOIN (SELECT * FROM indicadores_respostas WHERE id = 4927592) AS r2 INNER JOIN (SELECT * FROM indicadores_respostas WHERE id = 4927593) AS r3"));
            
            return list;
        }
    }
}
