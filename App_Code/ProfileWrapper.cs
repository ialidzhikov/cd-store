using ECommerce.CdShop.Security;
using System;
using System.Web;
using System.Web.Security;

/// <summary>
/// A wrapper around profile information, including
/// credit card encryption functionality.
/// </summary>
public class ProfileWrapper
{
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string ShippingRegion { get; set; }
    public string DayPhone { get; set; }
    public string EvePhone { get; set; }
    public string MobPhone { get; set; }
    public string Email { get; set; }
    public string CreditCard { get; set; }
    public string CreditCardHolder { get; set; }
    public string CreditCardNumber { get; set; }
    public string CreditCardIssueDate { get; set; }
    public string CreditCardIssueNumber { get; set; }
    public string CreditCardExpiryDate { get; set; }
    public string CreditCardType { get; set; }

    public ProfileWrapper()
    {
        ProfileCommon profile =
        HttpContext.Current.Profile as ProfileCommon;
        Address1 = profile.Address1;
        Address2 = profile.Address2;
        City = profile.City;
        Region = profile.Region;
        PostalCode = profile.PostalCode;
        Country = profile.Country;
        ShippingRegion = (profile.ShippingRegion == null || profile.ShippingRegion == "" ? "1" : profile.ShippingRegion);
        DayPhone = profile.DayPhone;
        EvePhone = profile.EvePhone;
        MobPhone = profile.MobPhone;
        Email = Membership.GetUser(profile.UserName).Email;
        try
        {
            SecureCard secureCard = new SecureCard(profile.CreditCard);
            CreditCard = secureCard.CardNumberX;
            CreditCardHolder = secureCard.CardHolder;
            CreditCardNumber = secureCard.CardNumber;
            CreditCardIssueDate = secureCard.IssueDate;
            CreditCardIssueNumber = secureCard.IssueNumber;
            CreditCardExpiryDate = secureCard.ExpiryDate;
            CreditCardType = secureCard.CardType;
        }
        catch
        {
            CreditCard = "Not entered.";
        }
    }
    public void UpdateProfile()
    {
        ProfileCommon profile =
        HttpContext.Current.Profile as ProfileCommon;
        profile.Address1 = Address1;
        profile.Address2 = Address2;
        profile.City = City;
        profile.Region = Region;
        profile.PostalCode = PostalCode;
        profile.Country = Country;
        profile.ShippingRegion = ShippingRegion;
        profile.DayPhone = DayPhone;
        profile.EvePhone = EvePhone;
        profile.MobPhone = MobPhone;
        profile.CreditCard = CreditCard;
        MembershipUser user = Membership.GetUser(profile.UserName);
        user.Email = Email;
        Membership.UpdateUser(user);

        try
        {
            SecureCard secureCard = new SecureCard(
            CreditCardHolder, CreditCardNumber,
            CreditCardIssueDate, CreditCardExpiryDate,
            CreditCardIssueNumber, CreditCardType);
            profile.CreditCard = secureCard.EncryptedData;
        }
        catch
        {
            CreditCard = "";
        }
    }
}