using System;
using System.ComponentModel.DataAnnotations;

namespace SuperMarketApp.Models
{
    public class Barang
    {
        [Key]
        public int BarangID { get; set; }
        public string KodeBarang { get; set; }
        public string NamaBarang { get; set; }
        public decimal HargaBarang { get; set; }
        public int JumlahBarang { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int GudangID { get; set; }
        public Gudang Gudang { get; set; }
    }
}
