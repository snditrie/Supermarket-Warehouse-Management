using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperMarketApp.Models
{
    public class Gudang
    {
        [Key]
        public int GudangID { get; set; }
        public string NamaGudang { get; set; }
        public ICollection<Barang> Barangs { get; set; }
    }
}
