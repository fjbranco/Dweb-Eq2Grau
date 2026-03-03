using Eq2Grau.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Eq2Grau.Controllers
{
    public class HomeController : Controller
    {
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 'porta' de entrada no programa
        /// </summary>
        /// <returns></returns>
        // POST
        [HttpPost]
        public IActionResult Index(string A, string B, string C)
        {
            /*
             * Algoritmo:
             * ler os parâmetros A, B e C
             * validar os parâmetros A, B e C, se forem números e A=/=0
             *   calcular raízes
             *   mostrar resultado x1 e x2
             * senão, mostrar mensagem de erro
             */

            /*float.TryParse(A, out float a);
              float.TryParse(B, out float b);
              float.TryParse(C, out float c);*/

            A = A.Replace('.', ',');
            B = B.Replace('.', ',');
            C = C.Replace('.', ',');

            if (!float.TryParse(A, out float a) ||
               !float.TryParse(B, out float b) ||
               !float.TryParse(C, out float c)) {
                ViewBag.Erro = "Os valores A, B e C devem ser números válidos.";
                return View();
            }

            // Validar se A é diferente de 0
            if (a == 0)
            {
                ViewBag.Erro = "O valor de A deve ser diferente de 0.";
                return View();
            }

            
            // Calcular raízes
            float delta = b * b - 4 * a * c;

            // Verificar se delta tem raízes complexas
            if (delta < 0)
            {
                // ViewBag.Erro = "A equação não possui raízes reais.";
                double parteReal = -b / (2 * a);
                double parteImaginaria = Math.Sqrt(-delta) / (2 * a);

                ViewBag.X1 = parteReal + " + " + parteImaginaria + "i";
                ViewBag.X2 = parteReal + " + " + parteImaginaria + "i";
                return View();
            }

            float x1 = (-b + MathF.Sqrt(delta)) / (2 * a);
            float x2 = (-b - MathF.Sqrt(delta)) / (2 * a);

            // enviar os dados calculados para a View
            ViewBag.X1 = x1;
            ViewBag.X2 = x2;
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
