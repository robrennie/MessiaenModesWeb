using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MessiaenModesWeb.Models;
using MessiaenModes;

namespace MessiaenModesWeb.Pages
{
    public class IndexModel : PageModel
    {
        public string Results { get; private set; }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ScaleInput ScaleInput { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            ScaleFinder finder = new ScaleFinder()
            {
                MaxChromatic = int.Parse(ScaleInput.MaxChromatic),
                MinNotes = int.Parse(ScaleInput.MinNotes),
                MaxNotes = int.Parse(ScaleInput.MaxNotes)
            };
            finder.CreateScales();

            // display scales
            StringBuilder results = new StringBuilder();
            foreach (Scale scale in finder.Scales)
            {
                if (!scale.IsMessiaen)
                    continue;

                results.AppendLine(scale.GetScaleString(ScaleInput.RootNote, ScaleInput.SharpsFlats.Equals("sharps")));
                results.AppendLine(scale.GetIntervalString(true));
                results.AppendLine(scale.GetIntervalString(false));
                results.AppendLine();
            }

            results.AppendLine("Total Scales Searched:" + finder.ScaleCount);
            results.AppendLine("Total Messiaen Scales Found:" + finder.MessiaenCount);

            // format html
            Results = results.ToString().Replace("\n", "<br />");
        }
    }
}
