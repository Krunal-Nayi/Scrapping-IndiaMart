using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP
{
    public class IndiaMartViewModel
    {
        #region Phase1
        public int inPhase1ID { get; set; }
        public string stPrimaryURL { get; set; }
        public string stURLInnerText { get; set; }
        public bool flgIsCompleted { get; set; }
        public bool? flgIsPhase2ProcessDone { get; set; }
        #endregion

        #region Phase2
        public int inPhase2ID { get; set; }
        public string stHostURL { get; set; }
        public string stLevel1Name { get; set; }
        public string stLevel1URL { get; set; }
        public string stLevel2Name { get; set; }
        public string stLevel2URL { get; set; }
        public string stLevel3Name { get; set; }
        public string stLevel3URL { get; set; }
        public bool? flgIsSiteMapProcessDone { get; set; }
        public bool? flgIsIndiaMartDomainProcess { get; set; }
        #endregion
    }
}
