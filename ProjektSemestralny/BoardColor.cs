//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektSemestralny
{
    using System;
    using System.Collections.Generic;
    
    public partial class BoardColor
    {
        public int id_boardColors { get; set; }
        public Nullable<int> id_project { get; set; }
        public byte rgb_red { get; set; }
        public byte rgb_green { get; set; }
        public byte rgb_blue { get; set; }
    
        public virtual NewProject NewProject { get; set; }
    }
}
