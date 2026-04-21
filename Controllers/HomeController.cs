using Microsoft.AspNetCore.Mvc;
using SaoJoaoVote.Models;

namespace SaoJoaoVote.Controllers
{
    public class HomeController : Controller
    {
        public static string ultimaAtualizacaoSite =
    System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location)
    .ToString("dd/MM/yyyy HH:mm");
        public static Dictionary<int, List<string>> votos = new Dictionary<int, List<string>>();

        public static List<Camisa> camisas = new List<Camisa>()
        {
            new Camisa { Id = 1, Nome = "Amarelo Colorido", Midia = "/video/amareloColorido.webm", EhVideo = true },
            new Camisa { Id = 2, Nome = "Azul Forte", Midia = "/video/azulForte.webm", EhVideo = true },
            new Camisa { Id = 3, Nome = "Azul Fraco", Midia = "/video/azulFraco.webm", EhVideo = true },
            new Camisa { Id = 4, Nome = "Brasil Copa", Midia = "/video/brasilCopa.webm", EhVideo = true },
            new Camisa { Id = 5, Nome = "Cinza Fraco", Midia = "/video/cinzafraco.webm", EhVideo = true },
            new Camisa { Id = 6, Nome = "Colorido", Midia = "/video/colorido.webm", EhVideo = true },
            new Camisa { Id = 7, Nome = "Laranja Colorido", Midia = "/video/laranjaColorido.webm", EhVideo = true },
            new Camisa { Id = 8, Nome = "Preto e Branco", Midia = "/video/pretoEBranco.webm", EhVideo = true },
            new Camisa { Id = 9, Nome = "Verde Fraco", Midia = "/video/verdeFraco.webm", EhVideo = true }
        };

        public IActionResult Index()
{
    ViewBag.SiteAtualizado = ultimaAtualizacaoSite;
    var ordenadas = camisas
        .OrderByDescending(c => votos.ContainsKey(c.Id) ? votos[c.Id].Count : 0)
        .ToList();

    return View(ordenadas);
}

        [HttpPost]
        public IActionResult Votar(int id, string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest("Nome inválido");

            if (!votos.ContainsKey(id))
                votos[id] = new List<string>();

            votos[id].Add(nome);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetVotos()
        {
            return Json(new
            {
                votos = votos,
                atualizado = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
            });
        }
    }
}