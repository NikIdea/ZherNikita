//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TourAgency.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Statistic
    {
        public int IdStatistic { get; set; }
        public int idTour { get; set; }
        public string specific { get; set; }
        public string countContract { get; set; }
    
        public virtual Tour Tour { get; set; }
    }
}
