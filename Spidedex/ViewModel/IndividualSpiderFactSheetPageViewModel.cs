using CommunityToolkit.Mvvm.ComponentModel;
using Spidedex.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spidedex.ViewModel
{
    [QueryProperty(nameof(SpiderFactSheet), "SpiderFactSheet")]
    public partial class IndividualSpiderFactSheetPageViewModel : BaseViewModel
    {
        public IndividualSpiderFactSheetPageViewModel()
        {
            
        }

        [ObservableProperty]
        private SpiderFactSheet _spiderFactSheet = new SpiderFactSheet();

    }
}
