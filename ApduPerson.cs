public static class ApduPerson
{
    // Check card
    public static byte[] SELECT = { 0x00, 0xa4, 0x04, 0x00, 0x08 };
    public static byte[] THAI_CARD = { 0xa0, 0x00, 0x00, 0x00, 0x54, 0x48, 0x00, 0x01 };

    // Command constants
    public static byte[] CMD_CID = GenerateCommand(0x80, 0xb0, 0x00, 0x04);
    public static byte[] CMD_THFULLNAME = GenerateCommand(0x80, 0xb0, 0x00, 0x11);
    public static byte[] CMD_ENFULLNAME = GenerateCommand(0x80, 0xb0, 0x00, 0x75);
    public static byte[] CMD_BIRTH = GenerateCommand(0x80, 0xb0, 0x00, 0xd9);
    public static byte[] CMD_GENDER = GenerateCommand(0x80, 0xb0, 0x00, 0xe1);
    public static byte[] CMD_ISSUER = GenerateCommand(0x80, 0xb0, 0x00, 0xf6);
    public static byte[] CMD_ISSUE = GenerateCommand(0x80, 0xb0, 0x01, 0x67);
    public static byte[] CMD_EXPIRE = GenerateCommand(0x80, 0xb0, 0x01, 0x6f);
    public static byte[] CMD_ADDRESS = GenerateCommand(0x80, 0xb0, 0x15, 0x79);

    // Photo commands
    public static byte[] CMD_PHOTO1 = GeneratePhotoCommand(0x80, 0xb0, 0x01, 0x7b);
    public static byte[] CMD_PHOTO2 = GeneratePhotoCommand(0x80, 0xb0, 0x02, 0x7a);
    public static byte[] CMD_PHOTO3 = GeneratePhotoCommand(0x80, 0xb0, 0x03, 0x79);
    public static byte[] CMD_PHOTO4 = GeneratePhotoCommand(0x80, 0xb0, 0x04, 0x78);
    public static byte[] CMD_PHOTO5 = GeneratePhotoCommand(0x80, 0xb0, 0x05, 0x77);
    public static byte[] CMD_PHOTO6 = GeneratePhotoCommand(0x80, 0xb0, 0x06, 0x76);
    public static byte[] CMD_PHOTO7 = GeneratePhotoCommand(0x80, 0xb0, 0x07, 0x75);
    public static byte[] CMD_PHOTO8 = GeneratePhotoCommand(0x80, 0xb0, 0x08, 0x74);
    public static byte[] CMD_PHOTO9 = GeneratePhotoCommand(0x80, 0xb0, 0x09, 0x73);
    public static byte[] CMD_PHOTO10 = GeneratePhotoCommand(0x80, 0xb0, 0x0a, 0x72);
    public static byte[] CMD_PHOTO11 = GeneratePhotoCommand(0x80, 0xb0, 0x0b, 0x71);
    public static byte[] CMD_PHOTO12 = GeneratePhotoCommand(0x80, 0xb0, 0x0c, 0x70);
    public static byte[] CMD_PHOTO13 = GeneratePhotoCommand(0x80, 0xb0, 0x0d, 0x6f);
    public static byte[] CMD_PHOTO14 = GeneratePhotoCommand(0x80, 0xb0, 0x0e, 0x6e);
    public static byte[] CMD_PHOTO15 = GeneratePhotoCommand(0x80, 0xb0, 0x0f, 0x6d);
    public static byte[] CMD_PHOTO16 = GeneratePhotoCommand(0x80, 0xb0, 0x10, 0x6c);
    public static byte[] CMD_PHOTO17 = GeneratePhotoCommand(0x80, 0xb0, 0x11, 0x6b);
    public static byte[] CMD_PHOTO18 = GeneratePhotoCommand(0x80, 0xb0, 0x12, 0x6a);
    public static byte[] CMD_PHOTO19 = GeneratePhotoCommand(0x80, 0xb0, 0x13, 0x69);
    public static byte[] CMD_PHOTO20 = GeneratePhotoCommand(0x80, 0xb0, 0x14, 0x68);

    // Helper methods
    private static byte[] GenerateCommand(byte byte1, byte byte2, byte byte3, byte byte4)
    {
        return new byte[] { byte1, byte2, byte3, byte4, 0x02, 0x00, 0xff };
    }

    private static byte[] GeneratePhotoCommand(byte byte1, byte byte2, byte byte3, byte byte4)
    {
        return new byte[] { byte1, byte2, byte3, byte4, 0x02, 0x00, 0xff };
    }
}
