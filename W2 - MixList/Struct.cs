using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;



[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct STRUCT_FIXITEM
{
    public String Name;
    public Int16 Value;
     
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct SItemListEF
{
    // Atributos
    public short Index; // 0 a 1	= 2
    public short Value; // 2 a 3	= 2
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct SItemList
{
    // Atributos
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
    public byte[] NameBytes;  // 0 a 63			= 64

    public short Mesh;          // 64 a 65		= 2
    public int Texture;         // 66 a 69		= 4

    public short Level;         // 70 a 71		= 2
    public short Str;           // 72 a 73		= 2
    public short Int;           // 74 a 75		= 2
    public short Dex;           // 76 a 77		= 2
    public short Con;           // 78 a 79		= 2

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
    public SItemListEF[] Ef;  // 80 a 127		= 48

    public int Price;           // 128 a 131	= 4
    public short Unique;        // 132 a 133	= 2
    public short Slot;          // 134 a 135	= 2
    public short Extreme;       // 136 a 137	= 2
    public short Grade;         // 138 a 139	= 2

    // Ajudantes
    public static string GetString(byte[] data)
    {
        if (data == null)
        {
            throw new Exception("data == null");
        }
        return Encoding.UTF8.GetString(data).TrimEnd('\0');
    }
    public string Name
    {
        get => GetString(this.NameBytes);
    }
}


















[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct STRUCT_ITEMLIST
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public String Name;
    public Int16 Mesh1;
    public Int32 Mesh2;
    public Int16 Level;
    public Int16 Str;
    public Int16 Int;
    public Int16 Dex;
    public Int16 Con;
    public UInt32 Unique;
    public UInt32 Price;
    public UInt16 Pos;
    public Int16 Extreme;
    public Int16 Grade;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
    public STRUCT_FIXITEM[] EFItem;
 
}

//92
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct pNPCComp
{
    public Int32 face;// 0 - 3

    public Int32 MapX;
    public Int32 MapY;

    public STRUCT_ITEM ItemSlot;  //12 - 19

    public Int32 Unknow_20; // 20 - 23
    public Int16 Unknow_24; // 24 - 25
    public Int16 Type; // 26 - 27// 2 = composiçaõ de soul, 1 = padrão

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public Item[] Item;

    public Int32 Gold;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2496)]
    public byte[] Blaaaa;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
    public byte[] NpcName;
    // Ajudantes
    public static string GetString(byte[] data)
    {
        if (data == null)
        {
            throw new Exception("data == null");
        }
        return Encoding.UTF8.GetString(data).TrimEnd('\0');
    }
    public string Name
    {
        get => GetString(this.NpcName).Replace("�","");

        set => this.NpcName = FromString(value.Replace("�", ""), 64);
         
    }
   
    public static byte[] FromString(string text, int size)
    {
        if (text == null)
        {
            throw new Exception("text == null");
        }

        byte[] buffer = Encoding.UTF8.GetBytes(text);

        Array.Resize(ref buffer, size);

        return buffer;
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct pNPCReq
{
    public Int32 Strdef;
    public Int32 Amount;
    public STRUCT_ITEM Item;
    public Int32 Unused;
    public Int32 Unused_02;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public Mix[] Mix;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] Unknow;

 
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
public struct Mix
{
    public Int32 MinID;
    public Int32 MaxID;

    public Mix clear()
    {
        Mix temp = new Mix();

        temp.MaxID = 0;
        temp.MinID = 0;
        return temp;

    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
public struct STRUCT_ITEM
{
    public short sIndex;//2
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public sItemADD[] sEffect;//8
};

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct sItemADD//2
{
    public Byte cEfeito;
    public Byte cValue;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Item
{
    public Int32 Value; // type
    public Int32 Req; // index do req
}


[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct npcCompleto
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
    public pNPCComp[] npcs;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
    public pNPCReq[] req;
}

