using Domain;

namespace Avans_NoWaste.Models;

public class PackageViewModel
{
   public Package? Package { get; set; } 
   public List<CheckboxOptions>? OptionsList { get; set; }
   public List<int>? ProductsList { get; set; }

   public class CheckboxOptions
   {
       public bool? IsChecked { get; set; }
       public Product? Value { get; set; }
   }
}