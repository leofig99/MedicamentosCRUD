using System.ComponentModel.DataAnnotations;

namespace MedicamentosCRUD.Models.ViewModels
{
    public class MedicamentoViewModel
    {
        //IIDMEDICAMENTO|NOMBRE|CONCENTRACION|IIDFORMAFARMACEUTICA|PRECIO|STOCK|PRESENTACION|BHABILITADO
        public string Iidmedicamento { get; set; }
        public string Nombre { get; set; }
        public string Concentracion { get; set; }
        public string Iidformafarmaceutica { get; set; }
        public string Precio { get; set; }
        public string Stock { get; set; }
        public string Presentacion { get; set; }
        public string Bhabilitado { get; set; }
    }
}
