/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:367761
*  Stack Overflow answer #:367798
*  And Stack Overflow answer#:15608028
*/
public static bool IsManagedAssembly (string fileName) {
    uint peHeader;
    uint peHeaderSignature;
    ushort machine;
    ushort sections;
    uint timestamp;
    uint pSymbolTable;
    uint noOfSymbol;
    ushort optionalHeaderSize;
    ushort characteristics;
    ushort dataDictionaryStart;
    uint [] dataDictionaryRVA = new uint [16];
    uint [] dataDictionarySize = new uint [16];
    Stream fs = new FileStream (fileName, FileMode.Open, FileAccess.Read);
    BinaryReader reader = new BinaryReader (fs);
    fs.Position = 0x3C;
    peHeader = reader.ReadUInt32 ();
    fs.Position = peHeader;
    peHeaderSignature = reader.ReadUInt32 ();
    machine = reader.ReadUInt16 ();
    sections = reader.ReadUInt16 ();
    timestamp = reader.ReadUInt32 ();
    pSymbolTable = reader.ReadUInt32 ();
    noOfSymbol = reader.ReadUInt32 ();
    optionalHeaderSize = reader.ReadUInt16 ();
    characteristics = reader.ReadUInt16 ();
    dataDictionaryStart = Convert.ToUInt16 (Convert.ToUInt16 (fs.Position) + 0x60);
    fs.Position = dataDictionaryStart;
    for (int i = 0; i < 15; i ++) {
        dataDictionaryRVA [i] = reader.ReadUInt32 ();
        dataDictionarySize [i] = reader.ReadUInt32 ();
    }
    fs.Close ();
    if (dataDictionaryRVA [14] == 0)
        return false;
    else
        return true;
}

public static bool IsManagedAssembly (string fileName) {
    using (Stream fileStream = new FileStream (fileName, FileMode.Open, FileAccess.Read))
    using (BinaryReader binaryReader = new BinaryReader (fileStream))
    {
        if (fileStream.Length < 64) {
            return false;
        }
        fileStream.Position = 0x3C;
        uint peHeaderPointer = binaryReader.ReadUInt32 ();
        if (peHeaderPointer == 0) {
            peHeaderPointer = 0x80;
        }
        if (peHeaderPointer > fileStream.Length - 256) {
            return false;
        }
        fileStream.Position = peHeaderPointer;
        uint peHeaderSignature = binaryReader.ReadUInt32 ();
        if (peHeaderSignature != 0x00004550) {
            return false;
        }
        fileStream.Position += 20;
        const ushort PE32 = 0x10b;
        const ushort PE32Plus = 0x20b;
        var peFormat = binaryReader.ReadUInt16 ();
        if (peFormat != PE32 && peFormat != PE32Plus) {
            return false;
        }
        ushort dataDictionaryStart = (ushort) (peHeaderPointer + (peFormat == PE32 ? 232 : 248));
        fileStream.Position = dataDictionaryStart;
        uint cliHeaderRva = binaryReader.ReadUInt32 ();
        if (cliHeaderRva == 0) {
            return false;
        }
        return true;
    }}

