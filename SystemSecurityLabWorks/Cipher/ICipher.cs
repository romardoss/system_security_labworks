namespace SystemSecurityLabWorks.Cipher
{
    internal interface ICipher
    {
        string Encrypt(string input, string key);
        string Decrypt(string input, string key);
    }
}
