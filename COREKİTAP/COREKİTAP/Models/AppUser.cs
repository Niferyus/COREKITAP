using Microsoft.AspNetCore.Identity;

namespace COREKİTAP.Models
{
    public class AppUser: IdentityUser
    {
        
        public virtual ICollection<OkumaGecmisi> OkumaGecmisi { get; set; }

        
        public virtual ICollection<Öneri> Öneri { get; set; }
    }
}
