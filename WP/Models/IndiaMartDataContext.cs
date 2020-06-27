using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Models;

namespace WP
{
    public class IndiaMartDataContext : DbContext
    {
        public IndiaMartDataContext()
            : base("name=DBConnectionString")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 600;
        }

        public DbSet<tblProductItems> tblProductItems { get; set; }
        public DbSet<tblProductCategories> tblProductCategories { get; set; }

        #region Phase1 Functions
        public int SavePrimaryURL(IndiaMartViewModel foRequest)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("stPrimaryURL", foRequest.stPrimaryURL.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stURLInnerText", foRequest.stURLInnerText.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("flgIsCompleted", foRequest.flgIsCompleted.handleDBNull()));
            return new IndiaMartDataContext().Database.SqlQuery<int>("SavePhase1".getSql(loSqlParameters), loSqlParameters.ToArray()).FirstOrDefault();
        }

        public IndiaMartViewModel getPrimaryURLList()
        {
            return new IndiaMartDataContext().Database.SqlQuery<IndiaMartViewModel>("SELECT TOP 1 inPhase1ID, stPrimaryURL FROM [dbo].[tblPhase1] WHERE ISNULL(flgIsCompleted, 0) = 0 AND stPrimaryURL LIKE '%indiamart.com%' ORDER BY inPhase1ID DESC").FirstOrDefault();
        }

        public int checkPrimaryURLExists()
        {
            return new IndiaMartDataContext().Database.SqlQuery<int>("SELECT TOP 1 1 FROM [dbo].[tblPhase1] WHERE ISNULL(flgIsCompleted, 0) = 0 AND stPrimaryURL LIKE '%indiamart.com%'").FirstOrDefault();
        }

        public void updateURLAsCompleted(int fiPhase1ID)
        {
            String lsStringQuery = "UPDATE [dbo].[tblPhase1] SET flgIsCompleted = 1 WHERE inPhase1ID = " + fiPhase1ID;
            new IndiaMartDataContext().Database.SqlQuery<IndiaMartViewModel>(lsStringQuery).ToList();
        }
        #endregion

        #region Phase2 Functions
        public int saveSiteMapInformation(IndiaMartViewModel foRequest)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("stHostURL", foRequest.stHostURL.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stLevel1Name", foRequest.stLevel1Name.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stLevel1URL", foRequest.stLevel1URL.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stLevel2Name", foRequest.stLevel2Name.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stLevel2URL", foRequest.stLevel2URL.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stLevel3Name", foRequest.stLevel3Name.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stLevel3URL", foRequest.stLevel3URL.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("flgIsSiteMapProcessDone", foRequest.flgIsSiteMapProcessDone.handleDBNull()));
            return new IndiaMartDataContext().Database.SqlQuery<int>("SaveSiteMap".getSql(loSqlParameters), loSqlParameters.ToArray()).FirstOrDefault();
        }
        #endregion

        #region Phase3 Functions
        #region Contact Detail Store Functions
        public List<IndiaMartViewModel> getPhase2List()
        {
            return new IndiaMartDataContext().Database.SqlQuery<IndiaMartViewModel>("SELECT DISTINCT inPhase2ID,stHostURL,stLevel1Name,stLevel1URL,stLevel2Name,stLevel2URL,stLevel3Name,stLevel3URL FROM [dbo].[tblPhase2] WHERE ISNULL(flgIsSiteMapProcessDone, 0) = 1 AND ISNULL(flgIsSiteDataProcessDone, 0) = 0").ToList();
        }

        public int SaveCompanyDetails(CompanyViewModel foRequest)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("stCompanyName ", foRequest.stCompanyName.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stCompanyHostURL", foRequest.stCompanyHostURL.handleDBNull()));
            return new IndiaMartDataContext().Database.SqlQuery<int>("SaveCompanyDetails".getSql(loSqlParameters), loSqlParameters.ToArray()).FirstOrDefault();
        }

        public int SaveCompanyContacts(CompanyContactViewModel foRequest)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("inCompanyID ", foRequest.inCompanyID.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stContactName", foRequest.stContactName.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stAddress", foRequest.stAddress.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stLatitude", foRequest.stLatitude.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stLongitude", foRequest.stLongitude.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stCallUsNumber ", foRequest.stCallUsNumber.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stMobileNos", foRequest.stMobileNos.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stTelephoneNos", foRequest.stTelephoneNos.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stFaxNos", foRequest.stFaxNos.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("flgIsBranch ", foRequest.flgIsBranch.handleDBNull()));
            return new IndiaMartDataContext().Database.SqlQuery<int>("SaveCompanyContacts".getSql(loSqlParameters), loSqlParameters.ToArray()).FirstOrDefault();
        }
        #endregion

        #region Product Information Store Functions
        public int SaveProductCategory(tblProductCategories foRequest)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("stProductCategoryName", foRequest.stProductCategoryName.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("inCompanyID", foRequest.inCompanyID.handleDBNull()));
            return new IndiaMartDataContext().Database.SqlQuery<int>("SaveProductCategory".getSql(loSqlParameters), loSqlParameters.ToArray()).FirstOrDefault();
        }

        public int SaveProductIteam(tblProductItems foRequest)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("inCompanyID", foRequest.inCompanyID.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("inCategoryID", foRequest.inCategoryID.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stProductName", foRequest.stProductName.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stProductDescription", foRequest.stProductDescription.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stImagePath", foRequest.stImagePath.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stFeatures", foRequest.stFeatures.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stSpecification", foRequest.stSpecification.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stTechnicalSpecification", foRequest.stTechnicalSpecification.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stOtherInformationList", foRequest.stOtherInformationList.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stAdditionalInformation", foRequest.stAdditionalInformation.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stOtherDescription", foRequest.stOtherDescription.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stPrice", foRequest.stPrice.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stAccessories", foRequest.stAccessories.handleDBNull()));

            return new IndiaMartDataContext().Database.SqlQuery<int>("SaveProductIteam".getSql(loSqlParameters), loSqlParameters.ToArray()).FirstOrDefault();
        }
        #endregion

        #region
        public int SaveCompanyProfileAboutInformations(tblCompanyProfileAboutInformations foRequest)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("inCompanyID", foRequest.inCompanyID.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stNatureOfBusiness", foRequest.stNatureOfBusiness.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stAdditionaBusiness", foRequest.stAdditionaBusiness.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stCompanyCEO", foRequest.stCompanyCEO.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stKeyCustomers", foRequest.stKeyCustomers.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stRegisteredAddress", foRequest.stRegisteredAddress.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stIndustry", foRequest.stIndustry.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stTotalNoOfEmployees", foRequest.stTotalNoOfEmployees.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stYearOfEstablishment", foRequest.stYearOfEstablishment.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stOwnershipType", foRequest.stOwnershipType.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stLegalStatusOfFirm", foRequest.stLegalStatusOfFirm.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stProprietorName", foRequest.stProprietorName.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stAnnualTurnOver", foRequest.stAnnualTurnOver.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stTradeExportPercentage", foRequest.stTradeExportPercentage.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stInfrastuctureLocationType", foRequest.stInfrastuctureLocationType.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stInfrastuctureBuildingInfrastructure", foRequest.stInfrastuctureBuildingInfrastructure.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stInfrastuctureSizeOfPremises", foRequest.stInfrastuctureSizeOfPremises.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stInfrastructureSpace", foRequest.stInfrastructureSpace.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stInfrastructureLocationPic", foRequest.stInfrastructureLocationPic.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stProvideAfterSalesSupport", foRequest.stProvideAfterSalesSupport.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stPrimaryCompetitiveAdvantage", foRequest.stPrimaryCompetitiveAdvantage.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stQualityMeasureTestingFacility", foRequest.stQualityMeasureTestingFacility.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stQualityCertifications", foRequest.stQualityCertifications.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stStatutoryPANNo", foRequest.stStatutoryPANNo.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stStatutoryTANNo", foRequest.stStatutoryTANNo.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stStatutoryDGFTIECode", foRequest.stStatutoryDGFTIECode.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stStatutoryEPFNo", foRequest.stStatutoryEPFNo.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stStatutoryESINo", foRequest.stStatutoryESINo.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stStatutoryRegistrationAuthority", foRequest.stStatutoryRegistrationAuthority.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stStatutoryRegistrationNo", foRequest.stStatutoryRegistrationNo.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stStatutoryCentralTAXNo", foRequest.stStatutoryCentralTAXNo.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stStatutoryValueAddedTaxRegistrationCode", foRequest.stStatutoryValueAddedTaxRegistrationCode.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stStatutoryCINNo", foRequest.stStatutoryCINNo.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stStatutoryBanker", foRequest.stStatutoryBanker.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stStatutoryExciseRegistrationNo", foRequest.stStatutoryExciseRegistrationNo.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stStatutorySSINo", foRequest.stStatutorySSINo.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stDunBradstreetNumber", foRequest.stDunBradstreetNumber.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stPackShipPaymentMode", foRequest.stPackShipPaymentMode.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stPackShipShipmentMode", foRequest.stPackShipShipmentMode.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stPackShipCustomizedPackaging", foRequest.stPackShipCustomizedPackaging.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stProfileAboutParagraph", foRequest.stProfileAboutParagraph.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stMajarMarketParagraph", foRequest.stMajarMarketParagraph.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stQualityAssuranceParagraph", foRequest.stQualityAssuranceParagraph.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stQualityAssuranceQualityCertImage", foRequest.stQualityAssuranceQualityCertImage.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stIndustoryCareParagraph", foRequest.stIndustoryCareParagraph.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stIndustoryCareOtherInformation", foRequest.stIndustoryCareOtherInformation.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stCustomerSatisficationParagraph", foRequest.stCustomerSatisficationParagraph.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stManufacturingUnitParagraph", foRequest.stManufacturingUnitParagraph.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stWhyUsParagraph", foRequest.stWhyUsParagraph.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stWhyUsBoomingList", foRequest.stWhyUsBoomingList.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stOurStrengthParagraph", foRequest.stOurStrengthParagraph.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stOurStrengthOtherInformation", foRequest.stOurStrengthOtherInformation.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stOurServicesParagraph", foRequest.stOurServicesParagraph.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stOurServicesServiceList", foRequest.stOurServicesServiceList.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stOurTeamParagraph", foRequest.stOurTeamParagraph.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stOurTeamOtherInformation", foRequest.stOurTeamOtherInformation.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stBrandDeal", foRequest.stBrandDeal.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stCertificationParagraph", foRequest.stCertificationParagraph.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stCertificationImages", foRequest.stCertificationImages.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stCompanyBrochureFilePath", foRequest.stCompanyBrochureFilePath.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stCompanyVideoPath", foRequest.stCompanyVideoPath.handleDBNull()));
            return new IndiaMartDataContext().Database.SqlQuery<int>("SaveCompanyProfileAboutInformations".getSql(loSqlParameters), loSqlParameters.ToArray()).FirstOrDefault();
        }

        public int SaveCompanyTestimonials(tblCompanyTestimonials foRequest)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("inCompanyID", foRequest.inCompanyID.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stTestimonialName", foRequest.stTestimonialName.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stTestimonialDescription", foRequest.stTestimonialDescription.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("stTestimonialImagePath", foRequest.stTestimonialImagePath.handleDBNull()));
            return new IndiaMartDataContext().Database.SqlQuery<int>("SaveCompanyTestimonials".getSql(loSqlParameters), loSqlParameters.ToArray()).FirstOrDefault();
        }
        #endregion
        #endregion

        #region IndiaMart Domain Functions
        public IndiaMartViewModel getIndiamartDomainURL()
        {
            return new IndiaMartDataContext().Database.SqlQuery<IndiaMartViewModel>("SELECT TOP 1 inPhase1ID, stPrimaryURL FROM [dbo].[tblPhase1] WHERE stPrimaryURL LIKE '%indiamart.com%' AND stPrimaryURL LIKE '%#%' AND ISNULL(flgIsIndiaMartDomainProcess, 0) = 0").FirstOrDefault();
        }

        public int checkIndiamartSiteMapURL()
        {
            return new IndiaMartDataContext().Database.SqlQuery<int>("SELECT TOP 1 1 FROM [dbo].[tblPhase1] WHERE stPrimaryURL LIKE '%indiamart.com%' AND stPrimaryURL LIKE '%#%' AND ISNULL(flgIsIndiaMartDomainProcess, 0) = 0").FirstOrDefault();
        }

        public void updateIndiaartDomainProcess(int fiPhase1ID)
        {
            string lsStringURL = "UPDATE [dbo].[tblPhase1] SET flgIsIndiaMartDomainProcess = 1 WHERE inPhase1ID = " + fiPhase1ID;
            new IndiaMartDataContext().Database.SqlQuery<object>(lsStringURL).ToList();
        }

        public IndiaMartViewModel getIndiaMartURLListForData()
        {
            IndiaMartViewModel loIndiaMartViewModel = new IndiaMartDataContext().Database.SqlQuery<IndiaMartViewModel>("SELECT TOP 1 inPhase2ID,stHostURL,stLevel1Name,stLevel1URL,stLevel2Name,stLevel2URL,stLevel3Name,stLevel3URL FROM [dbo].[tblPhase2] WHERE stHostURL LIKE '%indiamart.com%' AND ISNULL(flgIsSiteDataProcessDone, 0) = 0 AND ISNULL(flgIsInProcess, 0) = 0").FirstOrDefault(); //get fresh records
            new IndiaMartDataContext().Database.SqlQuery<object>("UPDATE [dbo].[tblPhase2] SET flgIsInProcess = 1 WHERE inPhase2ID = " + loIndiaMartViewModel.inPhase2ID).FirstOrDefault(); //Mark as in Process
            return loIndiaMartViewModel;
        }

        public int checkStillExistsPendingProcessRecords()
        {
            return new IndiaMartDataContext().Database.SqlQuery<int>("SELECT TOP 1 1 FROM [dbo].[tblPhase2] WHERE stHostURL LIKE '%indiamart.com%' AND ISNULL(flgIsSiteDataProcessDone, 0) = 0 AND ISNULL(flgIsInProcess, 0) = 0").FirstOrDefault(); //Check records stil exists
        }

        public void updateIndiaMartDataProcess(int fiPhase2ID)
        {
            string lsStringURL = "UPDATE [dbo].[tblPhase2] SET flgIsSiteDataProcessDone = 1, flgIsInProcess = 0 WHERE inPhase2ID = " + fiPhase2ID;
            new IndiaMartDataContext().Database.SqlQuery<object>(lsStringURL).ToList();
        }

        public int getExistsCompanyID(string fsCompanyName, string fsCompanyHostURL)
        {
            string lsStringURL = "SELECT TOP 1 inCompanyID FROM [dbo].[tblCompanies] WHERE stCompanyName = '" + fsCompanyName.Replace(@"'", @"''") + "' AND stCompanyHostURL = '" + fsCompanyHostURL.Replace(@"'", @"''") + "'";
            return new IndiaMartDataContext().Database.SqlQuery<int>(lsStringURL).FirstOrDefault();
        }
        #endregion

        #region General Functions
        public List<IndiaMartViewModel> executeStringQuery(String fsStringQuery)
        {
            return new IndiaMartDataContext().Database.SqlQuery<IndiaMartViewModel>(fsStringQuery).ToList();
        }
        #endregion
    }
}