using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBiotec.Models;


using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Cryptography;

namespace WebBiotec.Controllers
{
    public class AspNetUsersController : Controller
    {
        private ModelMantenedores db = new ModelMantenedores();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AspNetUsersController()
        {
        }

        public AspNetUsersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: AspNetUsers
        [Authorize]
        public ActionResult Index()
        {
            return View(db.AspNetUsers.ToList());
        }

        // GET: AspNetUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            if (aspNetUsers == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsers);
        }

        // GET: AspNetUsers/Create
        public ActionResult Create()
        {
            //var listCanalesUsuarios = Models.DAO.DaoControlDocumento.getCanalesUsuarios();
            //List<SelectListItem> SelectlistCanales = new List<SelectListItem>();
            //foreach (var item in listCanalesUsuarios)
            //{
            //    SelectListItem selectedListItem = new SelectListItem
            //    {
            //        Text = item.texto,
            //        Value = item.valor
            //    };
            //    SelectlistCanales.Add(selectedListItem);
            //}
            //ViewBag.CanalesUsuarios = SelectlistCanales;

            return View();
        }

        // POST: AspNetUsers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] AspNetUsers aspNetUsers)
        {
            if (ModelState.IsValid)
            {
                db.AspNetUsers.Add(aspNetUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aspNetUsers);
        }

        // GET: AspNetUsers/Edit/5
        public ActionResult Edit(string id)
        {

            var listCanalesUsuarios = Models.DAO.DaoControlDocumento.getCanalesUsuarios();
            List<SelectListItem> SelectlistCanales = new List<SelectListItem>();

            int indice = 0;
            foreach (var item in listCanalesUsuarios)
            {
                if (indice == 0)
                {
                    SelectListItem ItemInicial = new SelectListItem
                    {
                        Text = null,
                        Value = null
                    };
                    SelectlistCanales.Add(ItemInicial);
                }
                SelectListItem selectedListItem = new SelectListItem
                {
                    Text = item.texto,
                    Value = item.valor
                };
                SelectlistCanales.Add(selectedListItem);
                indice = indice++;
            }
            ViewBag.CanalesUsuarios = SelectlistCanales;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            aspNetUsers.PasswordHash = "";
            //aspNetUsers.PasswordHash = base64Decode(HashPassword(aspNetUsers.PasswordHash));
            if (aspNetUsers == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsers);
        }

        // POST: AspNetUsers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,CANALES_USUARIOS")] AspNetUsers aspNetUsers, string CANALES_USUARIOS)
        {
            var listCanalesUsuarios = Models.DAO.DaoControlDocumento.getCanalesUsuarios();
            List<SelectListItem> SelectlistCanales = new List<SelectListItem>();

            int indice = 0;
            foreach (var item in listCanalesUsuarios)
            {
                if (indice == 0)
                {
                    SelectListItem ItemInicial = new SelectListItem
                    {
                        Text = null,
                        Value = null
                    };
                    SelectlistCanales.Add(ItemInicial);
                }
                SelectListItem selectedListItem = new SelectListItem
                {
                    Text = item.texto,
                    Value = item.valor
                };
                SelectlistCanales.Add(selectedListItem);
                indice = indice++;
            }
            ViewBag.CanalesUsuarios = SelectlistCanales;
            if (ModelState.IsValid)
            {
                //var prueba = base64Decode(HashPassword(aspNetUsers.PasswordHash));
                if (!string.IsNullOrEmpty(aspNetUsers.PasswordHash))
                {
                    aspNetUsers.PasswordHash = HashPassword(aspNetUsers.PasswordHash);
                }
                
                db.Entry(aspNetUsers).State = EntityState.Modified;
                db.SaveChanges();

                try
                {
                    if (CANALES_USUARIOS !="")
                    {
                        string[] split_canales = CANALES_USUARIOS.Split('-');
                        string idCanal = split_canales[0].Trim().ToString();
                        string textoCanal = split_canales[1].Trim().ToString();
                        using (var ctx = new Model1())
                        {

                            ctx.Database.ExecuteSqlCommand(@"update Config_PerfilRetail set codigoCanal = {0} , canal = {1} where email = {2}", idCanal, textoCanal, aspNetUsers.Email);
                        }
                    }

                }
                catch (Exception ex)
                {
                    var error = ex.Message.ToString();
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(aspNetUsers);
        }
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }
        private static bool ByteArraysEqual(byte[] b0, byte[] b1)
        {
            if (b0 == b1)
            {
                return true;
            }

            if (b0 == null || b1 == null)
            {
                return false;
            }

            if (b0.Length != b1.Length)
            {
                return false;
            }

            for (int i = 0; i < b0.Length; i++)
            {
                if (b0[i] != b1[i])
                {
                    return false;
                }
            }

            return true;
        }



        public static string base64Decode(string sData) //Decode    
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }








        public  async Task <string> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return "false";
            }

            var user = UserManager.FindByEmail(model.Email);
            //var code =  UserManager.GeneratePasswordResetToken(user.Id);
            //var result =  UserManager.ResetPasswordAsync(user.Id, code, model.Password);


            var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
            var result = await UserManager.ResetPasswordAsync(user.Id, code, model.Password);
            //if (result.Succeeded)
            //{

            //}

            return "true";
        }

        // GET: AspNetUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            if (aspNetUsers == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsers);
        }

        // POST: AspNetUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string email= "")
        {
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(aspNetUsers);
            db.SaveChanges();
            using (var ctx = new Model1())
            {
                ctx.Database.ExecuteSqlCommand(@"delete AspNetUserRoles where UserId = {0}", id);
                ctx.Database.ExecuteSqlCommand(@"delete Config_PerfilRetail where email = {0}", email);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
