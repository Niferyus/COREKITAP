namespace COREKİTAP.Models
{
    public class OkumaGecmisi
    {
        public int OkumaGecmisiID { get; set; }
        public Nullable<int> KitapID { get; set; }
        public string KullanıcıID { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public virtual AppUser Kullanıcı { get; set; }
        public virtual Kitap Kitap { get; set; }
    }
}
