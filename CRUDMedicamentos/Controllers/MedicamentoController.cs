using MedicamentosCRUD.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDMedicamentos.Controllers
{
    public class MedicamentoController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string usuario, string contraseña)
        {
            string fileName = @"C:\dotNET\Proyectos\CRUDMedicamentos\CRUDMedicamentos\Models\BD\Usuarios.txt";
            List<string> lineas = new List<string>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;

                line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    lineas.Add(line);
                }
                foreach(var l in lineas)
                {
                    var user = l.Split('|');
                    if (user[3] == usuario && user[4] == contraseña)
                    {
                        return Redirect("~/Medicamento/");

                    }
                    else
                    {
                    }
                }
            }

            return View();
        }
        // GET: Medicamento
        public ActionResult Index()
        {
            List<ListMedicamentoViewModel> lista = new List<ListMedicamentoViewModel>();
            string fileName = @"C:\dotNET\Proyectos\CRUDMedicamentos\CRUDMedicamentos\Models\BD\Medicamentos.txt";

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    //IIDMEDICAMENTO|NOMBRE|CONCENTRACION|IIDFORMAFARMACEUTICA|PRECIO|STOCK|PRESENTACION|BHABILITADO

                    var linea = line.Split('|');
                    if(linea.Count() > 1)
                    {
                        ListMedicamentoViewModel medicamento = new ListMedicamentoViewModel();
                        medicamento.Iidmedicamento = linea[0];
                        medicamento.Nombre = linea[1];
                        medicamento.Concentracion = linea[2];
                        medicamento.Iidformafarmaceutica = linea[3];
                        medicamento.Precio = linea[4];
                        medicamento.Stock = linea[5];
                        medicamento.Presentacion = linea[6];
                        medicamento.Bhabilitado = linea[7];
                        lista.Add(medicamento);
                    }

                }
            }

            return View(lista);
        }

        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(MedicamentoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string fileName = @"C:\dotNET\Proyectos\CRUDMedicamentos\CRUDMedicamentos\Models\BD\Medicamentos.txt";
                    using (StreamWriter sw = new StreamWriter(fileName, true))
                    {
                        string medicamento = model.Iidmedicamento + "|" + model.Nombre + "|" + model.Concentracion + "|" + model.Iidformafarmaceutica + "|" + model.Precio + "|" + model.Stock + "|" + model.Presentacion + "|" + model.Bhabilitado;
                        sw.Write(medicamento);
                    }
                    return Redirect("~/Medicamento/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            MedicamentoViewModel model = new MedicamentoViewModel();
            string fileName = @"C:\dotNET\Proyectos\CRUDMedicamentos\CRUDMedicamentos\Models\BD\Medicamentos.txt";
            string[] linea ;
            using (var sr = new StreamReader(fileName))
            {
                for (int i = 1; i <= id; i++)
                    sr.ReadLine();
                linea = sr.ReadLine().Split('|');
            }
            model.Iidmedicamento = linea[0];
            model.Nombre = linea[1];
            model.Concentracion = linea[2];
            model.Iidformafarmaceutica = linea[3];
            model.Precio = linea[4];
            model.Stock = linea[5];
            model.Presentacion = linea[6];
            model.Bhabilitado = linea[7];

            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(MedicamentoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string fileName = @"C:\dotNET\Proyectos\CRUDMedicamentos\CRUDMedicamentos\Models\BD\Medicamentos.txt";
                    List<string> lineas = new List<string>();

                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string line;
                       
                        line = reader.ReadLine();
                        while ((line = reader. ReadLine()) != null)
                        {
                            lineas.Add(line);
                        }
                    }
                    using (StreamWriter sw = new StreamWriter(fileName, false))
                    {
                        string medicamento = model.Iidmedicamento + "|" + model.Nombre + "|" + model.Concentracion + "|" + model.Iidformafarmaceutica + "|" + model.Precio + "|" + model.Stock + "|" + model.Presentacion + "|" + model.Bhabilitado;

                        lineas[Convert.ToInt32(model.Iidmedicamento) - 1] = medicamento;
                        string contenido = "IIDMEDICAMENTO|NOMBRE|CONCENTRACION|IIDFORMAFARMACEUTICA|PRECIO|STOCK|PRESENTACION|BHABILITADO\n";
                        foreach(var l in lineas)
                        {
                            contenido += l.Trim() + "\n";
                        }
                        sw.Write(contenido);
                    }
                    return Redirect("~/Medicamento/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string fileName = @"C:\dotNET\Proyectos\CRUDMedicamentos\CRUDMedicamentos\Models\BD\Medicamentos.txt";
                    List<string> lineas = new List<string>();

                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string line;

                        line = reader.ReadLine();
                        while ((line = reader.ReadLine()) != null)
                        {
                            lineas.Add(line);
                        }
                    }
                    using (StreamWriter sw = new StreamWriter(fileName, false))
                    {

                        lineas[Convert.ToInt32(id) - 1] = "";
                        string contenido = "IIDMEDICAMENTO|NOMBRE|CONCENTRACION|IIDFORMAFARMACEUTICA|PRECIO|STOCK|PRESENTACION|BHABILITADO\n";
                        foreach (var l in lineas)
                        {
                            contenido += l.Trim() + "\n";
                        }
                        sw.Write(contenido);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Redirect("~/Medicamento/");
        }

    }
}