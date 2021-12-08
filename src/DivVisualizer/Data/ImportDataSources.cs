using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivVisualizer.Data
{
    public enum ImportDataSource
    {
        [Display(Name = "-")]
        None,
        [Display(Name = "Parqet-Api")]
        ParqetApi,
        [Display(Name = "Parqet-File")]
        ParqetFile,
        [Display(Name = "Portfolio Perfomance")]
        PortfolioPerfomance
    }
}
