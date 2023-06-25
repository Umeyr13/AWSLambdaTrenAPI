
namespace TrenAPI.Entities
{
    public class Tren
    {

        public string Ad { get; set; }        
        public virtual List<Vagon> Vagonlar { get; set; }   

    }
}
