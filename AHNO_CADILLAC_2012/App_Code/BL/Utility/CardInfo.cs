/// <summary>
/// Summary description for CardInfo
/// </summary>
using System;

public class CardInfo
{
       public CardInfo()
       {
              //
              // TODO: Add constructor logic here
              //
       }

       public string CardNumber
       {
              get;
              set;
       }

       public int ProgramId
       {
              get;
              set;
       }

       public string DealerCode
       {
              get;
              set;
       }

       public CardInfo(string strCardNumber, string strDealerCode, int iPrgmId)
       {
              this.CardNumber = strCardNumber;
              this.DealerCode = strDealerCode;
              this.ProgramId = iPrgmId;
       }
}

namespace Cust_Reg
{
       public class Customer_Registration
       {
              public Customer_Registration()
              {
                     //
                     // TODO: Add constructor logic here
                     //
              }

              #region Public Properties

              public int RegistrionID
              {
                     get;
                     set;
              }

              public string PreferedTitle
              {
                     get;
                     set;
              }

              public string FirstName
              {
                     get;
                     set;
              }

              public string LastName
              {
                     get;
                     set;
              }

              public string Address
              {
                     get;
                     set;
              }

              public string City
              {
                     get;
                     set;
              }

              public string State
              {
                     get;
                     set;
              }

              public string ZipCode
              {
                     get;
                     set;
              }

              public string EmailAddress
              {
                     get;
                     set;
              }

              public string Phone
              {
                     get;
                     set;
              }

              public string PhoneType
              {
                     get;
                     set;
              }

              public int ProgramID
              {
                     get;
                     set;
              }

              public string CardNumber
              {
                     get;
                     set;
              }

              public int CouponID
              {
                     get;
                     set;
              }

              public int TournamentID
              {
                     get;
                     set;
              }

              public int DealerID
              {
                     get;
                     set;
              }

              public DateTime TournamentDate
              {
                     get;
                     set;
              }

              public string ContractID
              {
                     get;
                     set;
              }

              public string PlanningInformation
              {
                     get;
                     set;
              }

              public string IntrestedModelInformation
              {
                     get;
                     set;
              }

              public string ContactLocalDealer
              {
                     get;
                     set;
              }

              public string PreferredDealer
              {
                     get;
                     set;
              }

              public string PreferredDealerName
              {
                     get;
                     set;
              }

              public string TimeFrame
              {
                     get;
                     set;
              }

              public string PurposeVehicleInterested
              {
                     get;
                     set;
              }

              public string CurrentHouseHoldVehicleMake01
              {
                     get;
                     set;
              }

              public string CurrentHouseHoldVehicleModel01
              {
                     get;
                     set;
              }

              public string CurrentHouseHoldVehicleOtherMake01
              {
                     get;
                     set;
              }

              public string CurrentHouseHoldVehicleOtherModel01
              {
                     get;
                     set;
              }

              public string CurrentHouseHoldVehicleYear01
              {
                     get;
                     set;
              }

              public string CurrentHouseHoldVehicleMake02
              {
                     get;
                     set;
              }

              public string CurrentHouseHoldVehicleOtherMake02
              {
                     get;
                     set;
              }

              public string CurrentHouseHoldVehicleModel02
              {
                     get;
                     set;
              }

              public string CurrentHouseHoldVehicleOtherModel02
              {
                     get;
                     set;
              }

              public string CurrentHouseHoldVehicleYear02
              {
                     get;
                     set;
              }

              public string DealerCode
              {
                     get;
                     set;
              }

              public string DealerName
              {
                     get;
                     set;
              }

              public string DealerEmail
              {
                     get;
                     set;
              }

              public string SalespersonName
              {
                     get;
                     set;
              }

              public string SalespersonEmail
              {
                     get;
                     set;
              }

              public DateTime TestDriveDate
              {
                     get;
                     set;
              }

              public string TestDriveVehicle
              {
                     get;
                     set;
              }

              public string TestDriveVehicleMake
              {
                     get;
                     set;
              }

              public string TestDriveVehicleModel
              {
                     get;
                     set;
              }

              public string SecondaryTestDriveVehicle
              {
                     get;
                     set;
              }

              public string SecondaryTestDriveVehicleMake
              {
                     get;
                     set;
              }

              public string SecondaryTestDriveVehicleModel
              {
                     get;
                     set;
              }

              public string SourceCode
              {
                     get;
                     set;
              }

              public string IPAddress
              {
                     get;
                     set;
              }

              public string VehicleMakeCode
              {
                     get;
                     set;
              }

              public string QuestionCode
              {
                     get;
                     set;
              }

              public string AnswerCode
              {
                     get;
                     set;
              }

              public string BACCode
              {
                     get;
                     set;
              }

              public string Autorized
              {
                     get;
                     set;
              }

              #endregion Public Properties
       }
}