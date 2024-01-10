
namespace COREKİTAP.Models
{
    public class Tür
    {
       
        public int TürID { get; set; }
        public string Tür1 { get; set; }
        public virtual ICollection<Kitap> Kitaplar { get; set; }

        internal IEnumerable<object> Split(char v)
        {
            throw new NotImplementedException();
        }
    }
}
