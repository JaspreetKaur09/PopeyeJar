using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace PopeyeJar.Models
{
    public class JarMaterialViewModel
    {
        public List<Jar> Jars { get; set; }
        public SelectList Material { get; set; }
        public string JarMaterial { get; set; }
        public string SearchString { get; set; }

    }
}
