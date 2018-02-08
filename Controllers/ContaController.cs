using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutenticacaoEFCookie.Dados;
using AutenticacaoEFCookie.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AutenticacaoEFCookie.Controllers
{
    public class ContaController : Controller
    {
        readonly AutenticacaoContexto contexto;

        public ContaController(AutenticacaoContexto contexto)
        {
           this.contexto = contexto;
        }

        [HttpGet]
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario){
            try
            {
                Usuario user = contexto.Usuarios.FirstOrDefault(c => c.Email == usuario.Email && c.Senha == usuario.Senha);
                if(user != null){
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Email, user.Email));
                    claims.Add(new Claim(ClaimTypes.Name , user.NomeUsuario));
                    claims.Add(new Claim(ClaimTypes.Sid  , user.IdUsuario.ToString()));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Financeiro");
                }

                return View(usuario);
            }
            catch (System.Exception)
            {
                return View(usuario);
            }
        }
    }
}