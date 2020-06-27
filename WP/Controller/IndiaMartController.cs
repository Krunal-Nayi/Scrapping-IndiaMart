using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Controller
{
    public class IndiaMartController
    {
        IndiaMartDataContext _Context = new IndiaMartDataContext();

        #region Phase1 Functions
        public int SavePrimaryURL(String fsPrimaryURL, String fsURLInnerText)
        {
            IndiaMartViewModel loIndiaMartViewModel = new IndiaMartViewModel();
            loIndiaMartViewModel = new IndiaMartViewModel();
            loIndiaMartViewModel.stPrimaryURL = fsPrimaryURL;
            loIndiaMartViewModel.stURLInnerText = fsURLInnerText;
            loIndiaMartViewModel.flgIsCompleted = false;
            return _Context.SavePrimaryURL(loIndiaMartViewModel);
        }

        public void updateURLAsCompleted(int fiPhase1ID)
        {
            _Context.updateURLAsCompleted(fiPhase1ID);
        }
        #endregion

        #region Phase2 Functions
        public List<IndiaMartViewModel> getAllPrimaryURLList()
        {
            String lsStringQuery = "SELECT inPhase1ID, stPrimaryURL FROM [dbo].[tblPhase1] WHERE stPrimaryURL NOT LIKE '%indiamart.com%' AND ISNULL(flgIsPhase2ProcessDone, 0) = 0";
            return _Context.executeStringQuery(lsStringQuery);
        }

        public void updateRecordsAsPhase2ProcessDone(int fiPhase1ID)
        {
            String lsStringQuery = "UPDATE[dbo].[tblPhase1] SET flgIsPhase2ProcessDone = 1 WHERE inPhase1ID = " + fiPhase1ID;
            _Context.executeStringQuery(lsStringQuery);
        }

        public int saveSiteMapInformation(IndiaMartViewModel foIndiaMartViewModel)
        {
            return _Context.saveSiteMapInformation(foIndiaMartViewModel);
        }
        #endregion
    }
}
