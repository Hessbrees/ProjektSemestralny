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
    
    public partial class AnimationBoard400
    {
        public int id_animation { get; set; }
        public int id_project { get; set; }
        public int boardSize { get; set; }
    
        public virtual NewProject NewProject { get; set; }
    }
}
