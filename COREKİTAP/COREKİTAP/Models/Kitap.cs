namespace COREKİTAP.Models
{
    public class Kitap
    {
        public int KitapID { get; set; }
        public string Ad { get; set; }
        public string ResimURL { get; set; }
        public string Yazar { get; set; }
        public string Yayınevi { get; set; }
        public Nullable<System.DateTime> YayınlanmaTarihi { get; set; }
        public string Konu { get; set; }
        public int TürID { get; set; }
        public virtual Tür Tür { get; set; }
        
        public virtual ICollection<OkumaGecmisi> OkumaGecmisi { get; set; }
        public virtual ICollection<Öneri> Öneri { get; set; }
    }
}
