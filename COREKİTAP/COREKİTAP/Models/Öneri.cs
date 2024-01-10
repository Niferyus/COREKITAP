namespace COREKİTAP.Models
{
    public class Öneri
    {
        public int ÖneriID { get; set; }
        public Nullable<int> KitapID { get; set; }
        public string KullanıcıID { get; set; }
        public virtual AppUser Kullanıcı { get; set; }
        public virtual Kitap Kitap { get; set; }

    }
}
