using System.ComponentModel.DataAnnotations;

namespace MessiaenModesWeb.Models
{
    public class ScaleInput
    {
        [Required, StringLength(6)]
        public string SharpsFlats { get; set; }
        [Required, StringLength(2)]
        public string RootNote { get; set; }
        [Required, StringLength(2)]
        public string MaxNotes { get; set; }
        [Required, StringLength(2)]
        public string MinNotes { get; set; }
        [Required, StringLength(2)]
        public string MaxChromatic { get; set; }
    }
}