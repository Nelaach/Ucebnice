using Markdig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Ucebnice.Models;
using System.Text.RegularExpressions;



namespace Ucebnice.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Active = "index";

            ArrayList Nazev = existujici_ucebnice();
            ArrayList Metadata = new ArrayList();


            foreach (string file in Nazev)
            {
                using (var reader = new StreamReader(Directory.GetCurrentDirectory() + $@"\ucebnice\{file}\metadata.txt"))
                {
                    //Metadata.Add(reader.ReadLine()); // První řádek textu je autor
                    Metadata.Add(reader.ReadToEnd());

                }

            }
            ViewBag.data = Metadata;

            return View("Index");
        }
        [Authorize]
        public IActionResult Markdown(string ucebnice, string kapitola, string podkapitola)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated) {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                ArrayList podKapitoly = new ArrayList();
                string[] dirs = System.IO.Directory.GetDirectories(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}");
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}", "*.md");
                foreach (string file in files)
                    podKapitoly.Add(Path.GetFileName(file));

                if (dirs.Length == 0 && files.Length == 0) //pokud je adresář prázdný
                {
                    string[] lines = { " ", "**Toto je úvodní kapitola**" };

                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", ucebnice, "kapitoly", kapitola, podkapitola)))
                    {
                        foreach (string line in lines)
                            outputFile.WriteLine(line);
                    }

                }

                sw.Stop();
                string text = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\{podkapitola}");

                ViewBag.FileText = text;
                ViewBag.Ucebnice = ucebnice;
                ViewBag.PodKapitoly = podKapitoly;
                ViewBag.PodKapitola = podkapitola;
                ViewBag.Kapitola = kapitola;

                return View("Markdown");
          }
            return HttpUnauthorized();
        }

        private IActionResult HttpUnauthorized()
        {
            throw new NotImplementedException();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Markdown_text(string ucebnice, string kapitola, string podkapitola)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                if (kapitola == "null")
                {
                    Console.WriteLine("žádna kapitolka");
                }
                string text = HttpContext.Request.Form["text"];
                string zmena_nazvu = HttpContext.Request.Form["zmena_nazvu"];

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", ucebnice, "kapitoly", kapitola, podkapitola)))
                {
                    outputFile.WriteLine(text);
                }
                if (podkapitola != zmena_nazvu)
                {
                    System.IO.File.Move(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\{podkapitola}", Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\{zmena_nazvu}");
                    return Redirect($"Markdown?ucebnice={ucebnice}&kapitola={kapitola}&podkapitola={zmena_nazvu}");
                }
                else
                {
                    return Redirect($"Markdown?ucebnice={ucebnice}&kapitola={kapitola}&podkapitola={podkapitola}");
                }
            }
            return HttpUnauthorized();
        }
        [Authorize]
        public IActionResult NovaKapitola(string ucebnice, string kapitola)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                    string[] dirs = Directory.GetDirectories(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly", "", SearchOption.TopDirectoryOnly);
                int pocet_kapitol = dirs.Length + 1;
                string kapitola_ = pocet_kapitol + ". " + kapitola;

                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", ucebnice, "kapitoly", kapitola_));

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", ucebnice, "kapitoly", kapitola_, "1. Uvod.md")))
                {
                    string[] lines = { " ", "*Sem zadejte libovolný text*" };

                    foreach (string line in lines)
                        outputFile.WriteLine(line);

                    return Redirect($"Markdown?ucebnice={ucebnice}&kapitola={kapitola_}&podkapitola=1. Uvod.md");
                }
            }
            return HttpUnauthorized();
        }
        [Authorize]
        public IActionResult SmazatPodKapitolu(string ucebnice, string podkapitola, string kapitola)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                System.IO.File.Delete(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\{podkapitola}");
            return Redirect($"Markdown?ucebnice={ucebnice}&kapitola={kapitola}&podkapitola=1. Uvod.md");
            }
            return HttpUnauthorized();

        }
        [Authorize]
        public IActionResult NovaPodKapitola(string ucebnice, string kapitola)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\", "*.md");
            int pocet_kapitol = files.Length + 1;
            Console.WriteLine(pocet_kapitol);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", ucebnice, "kapitoly", kapitola, pocet_kapitol + ". Prejmenujte.md")))
            {
                string[] lines = { " ", "*Sem zadejte libovolný text*" };

                foreach (string line in lines)
                    outputFile.WriteLine(line);

                return Redirect($"Markdown?ucebnice={ucebnice}&kapitola={kapitola}&podkapitola={pocet_kapitol}. Prejmenujte.md");
            }
            }
            return HttpUnauthorized();
        }
        public IActionResult Text(string ucebnice, string kapitola, string podkapitola)
        {
            
            string text = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\{podkapitola}");
            var pipeline = new Markdig.MarkdownPipelineBuilder().UseAdvancedExtensions().UseBootstrap().Build();
            var result = Markdig.Markdown.ToHtml(text, pipeline);

            //string pattern = "<title1>[\\s\\S]*?<\\/title1>";
            //result = Regex.Replace(result, pattern, "<h3 style='color:red'>lala</h3>");
            Regex regex = new Regex("(?<=&&POZNAMKA&&)(.*?)(?=&&POZNAMKA-KONEC&&)");
            MatchCollection matches = regex.Matches(text);
            Console.WriteLine("there were {0} matches", matches.Count);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
                var tex = @$"&amp;&amp;POZNAMKA&amp;&amp;{match}&amp;&amp;POZNAMKA-KONEC&amp;&amp;";
                result = result.Replace(tex, @$"<mark>{match}</mark>");
            }


            ArrayList podKapitoly = new ArrayList();
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\", "*.md");
            foreach (string file in files)
                podKapitoly.Add(Path.GetFileName(file));

            ViewBag.Kapitola = kapitola;
            ViewBag.Ucebnice = ucebnice;
            ViewBag.PodKapitoly = podKapitoly;
            ViewBag.PodKapitola = podkapitola;
            ViewBag.FileText = result;
            return View();

        }
        [Authorize]
        public IActionResult NovaUcebnice()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                ViewBag.Active = "nova_ucebnice";

            return View("NovaUcebnice");
            }
            return HttpUnauthorized();
        }
        [Authorize]
        [HttpPost]
        public IActionResult NovaUcebnice(string nazev, string autor, string datum, IFormFile files)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                ArrayList ex_ucebnice = existujici_ucebnice();

            if(ex_ucebnice.Contains(nazev))
            {
                ViewBag.Validace = "Tento název učebnice již existuje, zvolte jiný.";
                return NovaUcebnice();

            }

            if (nazev != null && files != null)
            {
                string nazev_souboru = files.FileName;
                string[] rozdeleni = nazev_souboru.Split('.');
                var extension = rozdeleni[1];
                string[] lines = { nazev, autor, datum, "." + extension };
                string[] povoleny_format = { ".gif", ".jpeg", ".png", ".jpg"};
                var fileName = Path.GetFileName(files.FileName);
                Console.WriteLine(fileName);
                var fileExtension = Path.GetExtension(fileName);
                Console.WriteLine(fileExtension);
                var newFileName = String.Concat(nazev, fileExtension);
                Console.WriteLine(newFileName);

                if (povoleny_format.Contains(fileExtension))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", nazev, "kapitoly"));
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", nazev, $"metadata.txt")))
                    {
                        foreach (string line in lines)
                            outputFile.WriteLine("ß" + line);
                    }


                    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "obrazky")).Root + $@"\{newFileName}";
                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        files.CopyTo(fs);
                        fs.Flush();
                    }
                    return Redirect($"/");

                }
                ViewBag.Validace = "Obrázek nemá jeden z povolený formátů(.png, .jpeg, .gif, .jpg)";
                return NovaUcebnice();

            }
            ViewBag.Validace = "Pro vytvoření formuláře zvolte název a vyberte obrázek";
            return NovaUcebnice();
            }
            return HttpUnauthorized();
        }
        public IActionResult Uprava(string ucebnice, string kapitola)
        {
            ArrayList podkapitoly = get_podkapitoly(ucebnice, kapitola);
            ViewBag.Ucebnice = ucebnice;
            ViewBag.Kapitola = kapitola;
            ViewBag.PodKapitoly = podkapitoly;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        static ArrayList get_podkapitoly(string ucebnice, string kapitola) //vrací podkapitoly kapitoly, upravit, aby to nebylo ve zbylém kódu!
        {
            ArrayList podKapitoly = new ArrayList();
            string[] dirs = System.IO.Directory.GetDirectories(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}");
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}", "*.md");
            foreach (string file in files)
                podKapitoly.Add(Path.GetFileName(file));

            return podKapitoly;
        }
        static ArrayList existujici_ucebnice() //vrací učebnice, které jsou již vytvořené
        {
            ArrayList existujici_ucebnice = new ArrayList();

            foreach (var d in System.IO.Directory.GetDirectories(Directory.GetCurrentDirectory() + @"\ucebnice"))
            {
                var dir = new DirectoryInfo(d);
                var dirName = dir.Name;
                Console.WriteLine(dirName);
                existujici_ucebnice.Add(dirName);

            }
            return existujici_ucebnice;

        }

    }
}
