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
using System.Collections.Generic;
using System.IO.Compression;
using Microsoft.EntityFrameworkCore;

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
            ViewBag.Metadata = get_vsechna_metadata();
            return View("Index");
        }
        [Authorize]
        public IActionResult UpravaUcebnice(string ucebnice, string kapitola, string podkapitola) //Text v Markdownu k upravení
        {
            try
            {
                TempData["shortMessage"].ToString();
            }
            catch(NullReferenceException)
            {
                TempData["shortMessage"] = "";
            }
            finally
            {
                ViewBag.Validace = TempData["shortMessage"];
            }
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                var kapitoly_podkapitoly = get_kapitoly_podkapitoly(ucebnice);
                string text;
                text = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\{podkapitola}");


                ViewBag.FileText = text;
                ViewBag.Ucebnice = ucebnice;
                ViewBag.Kapitola = kapitola;
                ViewBag.PodKapitola = podkapitola;
                ViewBag.Kapitoly_podkapitoly = kapitoly_podkapitoly;

                return View("UpravaUcebnice");
            }
            return HttpUnauthorized();
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpravaUcebnicePost(string ucebnice, string kapitola, string podkapitola)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                if (kapitola == "null")
                {
                    Console.WriteLine("žádna kapitolka");
                }
                string text = HttpContext.Request.Form["text"];
                text = text.Remove(text.Length - 2);
                text = text.Replace("<", "&lt;");

                string zmena_nazvu = HttpContext.Request.Form["zmena_nazvu"];
                zmena_nazvu = zmena_nazvu + ".md";
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", ucebnice, "kapitoly", kapitola, podkapitola)))
                {
                    outputFile.WriteLine(text);
                }
                if (podkapitola != zmena_nazvu)
                {
                    if (!System.IO.File.Exists(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\{zmena_nazvu}"))
                    {
                        System.IO.File.Move(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\{podkapitola}", Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\{zmena_nazvu}");
                        TempData["shortMessage"] = "Úspěšně uloženo a přejmenováno";
                        return Redirect($"UpravaUcebnice?ucebnice={ucebnice}&kapitola={kapitola}&podkapitola={zmena_nazvu}");
                    }
                    else
                    {
                        TempData["shortMessage"] = "Učebnice nebyla přejmenována, protože tento název učebnice již existuje.";
                        return Redirect($"UpravaUcebnice?ucebnice={ucebnice}&kapitola={kapitola}&podkapitola={podkapitola}");
                    }
                }
                else
                {
                    TempData["shortMessage"] = "Úspěšně uloženo";
                    return Redirect($"UpravaUcebnice?ucebnice={ucebnice}&kapitola={kapitola}&podkapitola={podkapitola}");
                }
            }
            return HttpUnauthorized();
        }

        [Authorize]
        public IActionResult SmazatUcebnici(string ucebnice)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                System.IO.Directory.Delete(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}", true);
                return Index();
            }
            return HttpUnauthorized();
        }


        [Authorize]
        public IActionResult SmazatPodKapitolu(string ucebnice, string podkapitola, string kapitola)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            Console.Write(podkapitola);
            if (isAuthenticated)
            {
                System.IO.File.Delete(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\{podkapitola}");

                return Redirect($"UpravaMetadat?ucebnice={ucebnice}");
            }
            return HttpUnauthorized();
        }
        [Authorize]
        public IActionResult SmazatKapitolu(string ucebnice, string kapitola)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                if (Directory.Exists(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\"))
                {
                    System.IO.Directory.Delete(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\", true);
                    return Redirect($"UpravaMetadat?ucebnice={ucebnice}");
                }
                else
                {
                    return Redirect($"UpravaMetadat?ucebnice={ucebnice}");

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
                string kapitola_ = kapitola;

                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", ucebnice, "kapitoly", kapitola_));

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", ucebnice, "kapitoly", kapitola_, "1. Uvod.md")))
                {
                    string[] lines = { " ", "*Sem zadejte libovolný text*" };

                    foreach (string line in lines)
                        outputFile.WriteLine(line);

                    return Redirect($"UpravaUcebnice?ucebnice={ucebnice}&kapitola={kapitola_}&podkapitola=1. Uvod.md");
                }
            }
            return HttpUnauthorized();
        }
        [Authorize]
        public IActionResult NovaPodKapitola(string ucebnice, string kapitola, string podkapitola)
        {
            podkapitola = podkapitola + ".md";
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                if (!System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", ucebnice, "kapitoly", kapitola, podkapitola)))
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", ucebnice, "kapitoly", kapitola, podkapitola)))
                    {
                        string[] lines = { " ", "*Sem zadejte libovolný text*" };

                        foreach (string line in lines)
                            outputFile.WriteLine(line);

                        return Redirect($"UpravaUcebnice?ucebnice={ucebnice}&kapitola={kapitola}&podkapitola={podkapitola}");
                    }

                }
                return Redirect($"UpravaUcebnice?ucebnice={ucebnice}&kapitola={kapitola}&podkapitola={podkapitola}");



            }
            return HttpUnauthorized();
        }
        public IActionResult ZobrazeniUcebnice(string ucebnice, string kapitola, string podkapitola)
        {
            string text;
            text = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{kapitola}\{podkapitola}");

            var pipeline = new Markdig.MarkdownPipelineBuilder().UseAdvancedExtensions().UseBootstrap().Build();
            var result = Markdig.Markdown.ToHtml(text, pipeline);

            Regex regex = new Regex("(?<=&&POZNAMKA&&)(.*?)(?=&&POZNAMKA-KONEC&&)");
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
                var tex = @$"&amp;&amp;POZNAMKA&amp;&amp;{match}&amp;&amp;POZNAMKA-KONEC&amp;&amp;";
                result = result.Replace(tex, @$"<mark>{match}</mark>");
            }
            var kapitoly_podkapitoly = get_kapitoly_podkapitoly(ucebnice);

            ViewBag.Kapitoly_podkapitoly = kapitoly_podkapitoly;
            ViewBag.Ucebnice = ucebnice;
            ViewBag.FileText = result;
            ViewBag.Kapitola = kapitola;
            ViewBag.PodKapitola = podkapitola;
            return View();

        }
        [Authorize]
        public IActionResult FormularUcebnice()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                ViewBag.Active = "nova_ucebnice";

                return View("FormularUcebnice");
            }
            return HttpUnauthorized();
        }
        [Authorize]

        [HttpPost]
        public IActionResult PridaniUcebnice(string nazev, string autor, string datum, IFormFile obrazek, IFormFile ucebnice) //Přidání existující učebnice
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                ArrayList ex_ucebnice = Existujici_ucebnice();

                if (ex_ucebnice.Contains(nazev))
                {
                    ViewBag.ValidacePridani = "Tento název učebnice již existuje, zvolte jiný.";
                    return FormularUcebnice();

                }

                if (nazev != null && obrazek != null && autor != null && ucebnice != null)
                {
                    if (nazev.All(c => Char.IsLetterOrDigit(c) || c.Equals('_') || c.Equals('-')))
                    {
                        var nazev_obrazku = Path.GetFileName(obrazek.FileName);
                        var nazev_ucebnice = Path.GetFileName(ucebnice.FileName);
                        var pripona_obrazku = Path.GetExtension(nazev_obrazku);
                        string[] lines = { nazev, autor, datum, pripona_obrazku };
                        string[] povoleny_format_obrazku = { ".gif", ".jpeg", ".png", ".jpg" };

                        var newFileName = String.Concat(nazev, pripona_obrazku); //Vytvořen z názvu učebnice a přípony

                        if (povoleny_format_obrazku.Contains(pripona_obrazku))
                        {
                            if (ucebnice.FileName == "kapitoly.zip" && ucebnice.Length < 10000000)
                            {
                                Console.WriteLine(ucebnice.Length);
                                var ucebnicepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice")).Root + $@"\{nazev_ucebnice}";
                                using (FileStream fs = System.IO.File.Create(ucebnicepath))
                                {
                                    ucebnice.CopyTo(fs);
                                    fs.Flush();
                                }
                                var ucebnice_zip_cesta = Directory.GetCurrentDirectory() + @$"\ucebnice\{nazev_ucebnice}";
                                ZipFile.ExtractToDirectory(ucebnice_zip_cesta, Directory.GetCurrentDirectory() + @$"\ucebnice\{nazev}");
                                using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", nazev, $"metadata.txt")))
                                {
                                    foreach (string line in lines)
                                        outputFile.WriteLine(line);
                                }
                                System.IO.File.Delete(ucebnice_zip_cesta);


                                var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "obrazky")).Root + $@"\{newFileName}";
                                using (FileStream fs = System.IO.File.Create(filepath))
                                {
                                    obrazek.CopyTo(fs);
                                    fs.Flush();
                                }
                                using (System.IO.File.Create(Directory.GetCurrentDirectory() + @$"\ucebnice\{nazev}\uvod.md"))
                                    return Redirect($"/");
                            }
                            ViewBag.ValidacePridani = "Nahrávaný soubor musí mít název 'kapitoly', musí být zazipovaný a menší než 10 megabajtů. (kapitoly.zip)";
                            return FormularUcebnice();

                        }
                        ViewBag.ValidacePridani = "Obrázek nemá jeden z povolený formátů(.png, .jpeg, .gif, .jpg)";
                        return FormularUcebnice();
                    }

                    ViewBag.ValidaceVytvoreni = "Učebnice nesmí obsahovat speciální znaky v názvu a mezeru (může obsahovat pouze čísla, písmena, podtržítko a pomlčku)";
                    return FormularUcebnice();

                }
                ViewBag.ValidacePridani = "Pro přidání učebnice zvolte název, autora, vyberte obrázek a nahrejte učebnici. ";
                return FormularUcebnice();
            }
            return HttpUnauthorized();
        }
        [Authorize]
        [HttpPost]
        public IActionResult VytvoreniUcebnice(string nazev, string autor, string datum, IFormFile obrazek) //Vytvoření úplně nové učebnice
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                ArrayList ex_ucebnice = Existujici_ucebnice();

                if (ex_ucebnice.Contains(nazev))
                {
                    ViewBag.ValidaceVytvoreni = "Tento název učebnice již existuje, zvolte jiný.";
                    return FormularUcebnice();

                }
                if (nazev != null && obrazek != null && autor != null)
                {
                    if (nazev.All(c => Char.IsLetterOrDigit(c) || c.Equals('_') || c.Equals('-')))
                    {

                        var nazev_obrazku = Path.GetFileName(obrazek.FileName);
                        var pripona_obrazku = Path.GetExtension(nazev_obrazku);
                        string[] lines = { nazev, autor, datum, pripona_obrazku };
                        string[] povoleny_format_obrazku = { ".gif", ".jpeg", ".png", ".jpg" };

                        var newFileName = String.Concat(nazev, pripona_obrazku); //Vytvořen z názvu učebnice a přípony

                        if (povoleny_format_obrazku.Contains(pripona_obrazku))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", nazev, "kapitoly"));
                            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "ucebnice", nazev, $"metadata.txt")))
                            {
                                foreach (string line in lines)
                                    outputFile.WriteLine(line);
                            }


                            var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "obrazky")).Root + $@"\{newFileName}";
                            using (FileStream fs = System.IO.File.Create(filepath))
                            {
                                obrazek.CopyTo(fs);
                                fs.Flush();
                            }
                            using (System.IO.File.Create(Directory.GetCurrentDirectory() + @$"\ucebnice\{nazev}\uvod.md"))
                                return Redirect($"/");


                        }
                        ViewBag.ValidaceVytvoreni = "Obrázek nemá jeden z povolený formátů(.png, .jpeg, .gif, .jpg)";
                        return FormularUcebnice();
                    }

                    ViewBag.ValidaceVytvoreni = "Učebnice nesmí obsahovat speciální znaky v názvu a mezeru (může obsahovat pouze čísla, písmena, podtržítko a pomlčku)";
                    return FormularUcebnice();

                }
                ViewBag.ValidaceVytvoreni = "Pro vytvoření učebnice zvolte název, autora a vyberte obrázek";
                return FormularUcebnice();
            }
            return HttpUnauthorized();
        }
        [Authorize]
        public IActionResult UpravaMetadat(string ucebnice)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                var kapitoly_podkapitoly = get_kapitoly_podkapitoly(ucebnice);

                ViewBag.Kapitoly_podkapitoly = kapitoly_podkapitoly;
                ViewBag.Ucebnice = ucebnice;
                ViewBag.Metadata = get_jedna_metadata(ucebnice);

                return View();
            }
            return HttpUnauthorized();
        }
        public IActionResult ZobrazeniMetadat(string ucebnice)
        {
            var kapitoly_podkapitoly = get_kapitoly_podkapitoly(ucebnice);

            ViewBag.Kapitoly_podkapitoly = kapitoly_podkapitoly;
            ViewBag.Ucebnice = ucebnice;
            ViewBag.Metadata = get_jedna_metadata(ucebnice);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        static Dictionary<string, List<Tuple<string, string>>> get_kapitoly_podkapitoly(string ucebnice) //vrací podkapitoly a kapitoly
        {
            var kapitoly_podkapitoly = new Dictionary<string, List<Tuple<string, string>>>();
            foreach (var d in System.IO.Directory.GetDirectories(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly"))
            {
                var dir = new DirectoryInfo(d);
                var dirName = dir.Name;
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + @$"\ucebnice\{ucebnice}\kapitoly\{dirName}\", "*.md");
                ArrayList podKapitoly = new ArrayList();
                var list = new List<Tuple<string,string>>();
                

                foreach (string test in files)
                {
                    String text = System.IO.File.ReadAllText(test);
                    var pipeline = new Markdig.MarkdownPipelineBuilder().UseAdvancedExtensions().UseBootstrap().Build();
                    var result = Markdig.Markdown.ToHtml(text, pipeline);

                    Regex regex = new Regex("(^# )(.*)");
                    var match = regex.Match(text);
                    string match_value = match.Value;
                    if(match_value.Length > 2)
                    {
                        match_value = match_value.Remove(0, 1);
                        list.Add(new Tuple<string, string>(Path.GetFileName(test), match_value));

                    }
                    else
                    {
                        list.Add(new Tuple<string, string>(Path.GetFileName(test), ""));
                    }
                }

                kapitoly_podkapitoly[dirName] = list;

            }

            return kapitoly_podkapitoly;
        }
        static List<List<string>> get_vsechna_metadata()
        {
            List<string> JednaMetadata = new List<string>();
            List<List<string>> VsechnaMetadata = new List<List<string>>();
            ArrayList Nazev = Existujici_ucebnice();
            foreach (string file in Nazev)
            {
                using (var reader = new StreamReader(Directory.GetCurrentDirectory() + $@"\ucebnice\{file}\metadata.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        JednaMetadata.Add(line);
                    }

                }

                VsechnaMetadata.Add(JednaMetadata);
                JednaMetadata = new List<string>(); //Vyprázdnit JednaMetadata, aby se tam mohla uložit metadata dalších učebnic.

            }
            return VsechnaMetadata;
        }
        static List<string> get_jedna_metadata(string ucebnice)
        {
            List<string> JednaMetadata = new List<string>();

            using (var reader = new StreamReader(Directory.GetCurrentDirectory() + $@"\ucebnice\{ucebnice}\metadata.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    JednaMetadata.Add(line);
                }

            }
            return JednaMetadata;
        }
        static ArrayList Existujici_ucebnice() //vrací učebnice, které jsou již vytvořené
        {
            ArrayList existujici_ucebnice = new ArrayList();

            foreach (var d in System.IO.Directory.GetDirectories(Directory.GetCurrentDirectory() + @"\ucebnice"))
            {
                var dir = new DirectoryInfo(d);
                var dirName = dir.Name;
                existujici_ucebnice.Add(dirName);

            }
            return existujici_ucebnice;

        }
        private IActionResult HttpUnauthorized()
        {
            throw new NotImplementedException();
        }

    }
}
