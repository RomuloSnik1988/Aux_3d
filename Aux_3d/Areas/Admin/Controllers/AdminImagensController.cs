using Aux_3d.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Drawing;

namespace Aux_3d.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagensController : Controller
    {
        public readonly ConfigurationImagens _myConfig;
        public readonly IWebHostEnvironment _hostingEnvironment;

        public AdminImagensController(IWebHostEnvironment hostEnvironment, IOptions<ConfigurationImagens> MyConfiguration)
        {
            _hostingEnvironment = hostEnvironment;
            _myConfig = MyConfiguration.Value;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UploadFiles(List<IFormFile> Files)
        {
            if (Files == null || Files.Count == 0)
            {
                ViewData["Error"] = "Error: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }
            if (Files.Count > 10)
            {
                ViewData["Error"] = "Error: Quantidade de arquivos excedeu o limite";
                return View(ViewData);
            }
            long size = Files.Sum(f => f.Length);
            var filePathsName = new List<string>();
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            foreach (var formFile in Files)
            {
                if (formFile.FileName.Contains(".jpg") || formFile.FileName.Contains(".jpeg") ||
                    formFile.FileName.Contains(".png") || formFile.FileName.Contains(".gif"))
                {
                    var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);

                    filePathsName.Add(fileNameWithPath);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                }
            }

            ViewData["Resultado"] = $"{Files.Count} arquivos foram enviados ao servidor, " +
                                    $"com tamanho total de : {size} bytes";
            ViewBag.Arquivos = filePathsName;
            return View(ViewData);

        }
        public IActionResult GetImagens()
        {
            FileManagerModel model = new FileManagerModel();

            var userImagesPath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            DirectoryInfo dir = new DirectoryInfo(userImagesPath);

            FileInfo[] files = dir.GetFiles();

            model.PathImagesProduto = _myConfig.NomePastaImagensProdutos;

            if (files.Length == 0)
            {
                ViewData["Erro"] = $"Nenhum arquivo encontrado na pasta {userImagesPath}";
            }
            model.Files = files;
            return View(model);
        }
        public IActionResult DeleteFile(string fname)
        {
            string _imagemDeleta = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos + "\\", fname);

            if ((System.IO.File.Exists(_imagemDeleta)))
            {
                System.IO.File.Delete(_imagemDeleta);

                ViewData["Deletado"] = $"Arquivo(s) {_imagemDeleta} deletado com sucesso";
            }
            return View("Index");
        }
    }
}