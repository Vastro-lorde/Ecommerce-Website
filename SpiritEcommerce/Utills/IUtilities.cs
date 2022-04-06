namespace SpiritEcommerce.Utills
{
    public interface IUtilities
    {
        string BCryptEncryption(string rawData);
        string RandomDigits(int length);
    }
}
