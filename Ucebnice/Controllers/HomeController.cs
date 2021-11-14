using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ucebnice.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Markdig;



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

            ArrayList Nazev = new ArrayList();
            ArrayList Metadata = new ArrayList();


            foreach (var d in System.IO.Directory.GetDirectories(Directory.GetCurrentDirectory() + @"\ucebnice"))
            {
                var dir = new DirectoryInfo(d);
                var dirName = dir.Name;

                Nazev.Add(dirName);
                string aktualniAdresar = Directory.GetCurrentDirectory();

            }
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
        public IActionResult Markdown(string ucebnice, string kapitola, string podkapitola)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            ArrayList podKapitoly = new ArrayList();
            string[] dirs = System.IO.Directory.GetDirectories(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}");
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}", "*.md");
            foreach (string file in files)
                podKapitoly.Add(Path.GetFileName(file));

            if (dirs.Length == 0 && files.Length == 0) //pokud je adresář prázdný
            {
                Console.WriteLine("empty");
                string[] lines = { " ", "**Toto je úvodní kapitola**" };

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", ucebnice, "kapitoly", kapitola, podkapitola)))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }

            }
            else
            {
                Console.WriteLine("Not Empty");

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
        [HttpPost]
        public IActionResult Markdown_text(string ucebnice, string kapitola, string podkapitola)
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
            else {
                return Redirect($"Markdown?ucebnice={ucebnice}&kapitola={kapitola}&podkapitola={podkapitola}");
            }
        }
        public IActionResult NovaKapitola(string ucebnice, string kapitola)
        {
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", ucebnice, "kapitoly", kapitola));
            return Redirect($"NovaPodKapitola?ucebnice={ucebnice}&kapitola={kapitola}");

        }

        public IActionResult SmazatPodKapitolu(string ucebnice, string podkapitola, string kapitola)
        {
            System.IO.File.Delete(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\{podkapitola}");
            return Redirect($"Markdown?ucebnice={ucebnice}&kapitola={kapitola}&podkapitola=Uvod.md");


        }

        public IActionResult NovaPodKapitola(string ucebnice, string kapitola)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", ucebnice, "kapitoly", kapitola, "Uvod.md")))
            {
                string[] lines = { " ", "*Sem zadejte libovolný text*" };

                foreach (string line in lines)
                    outputFile.WriteLine(line);

                return Redirect($"Markdown?ucebnice={ucebnice}&kapitola={kapitola}&podkapitola=Uvod.md");
            }
        }
        public IActionResult Text(string ucebnice, string kapitola, string podkapitola)
        {
            string text = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\{podkapitola}");
            var pipeline = new Markdig.MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            var result = Markdig.Markdown.ToHtml(text, pipeline);

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
        public IActionResult NovaUcebnice()
        {
            ViewBag.Active = "nova_ucebnice";

            return View("NovaUcebnice");
        }
        [HttpPost]
        public IActionResult NovaUcebnice(string nazev, string autor, string datum, IFormFile files)
        {
            //dořešit háčky, čárky a bez souboru to nepustí dál
            string nazev_souboru = files.FileName;
            string[] rozdeleni =nazev_souboru.Split('.');
            var extension = rozdeleni[1];



            string[] lines = {nazev, autor, datum, "." + extension };
            if (nazev != null)
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", nazev, "kapitoly"));
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", nazev, $"metadata.txt")))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine("ß" + line);
                }
            }


            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    Console.WriteLine(fileName);

                    var fileExtension = Path.GetExtension(fileName);
                    Console.WriteLine(fileExtension);

                    var newFileName = String.Concat(nazev, fileExtension);
                    Console.WriteLine(newFileName);

                    var filepath =
                new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "obrazky")).Root + $@"\{newFileName}";

                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        files.CopyTo(fs);
                        fs.Flush();
                    }
                }
            }
            return Redirect($"/");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
