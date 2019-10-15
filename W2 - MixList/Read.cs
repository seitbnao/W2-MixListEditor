using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W2___MixList
{
    public class Read
    {
        public static List<npcCompleto> Npcs = new List<npcCompleto>();
        public static SItemList[] Itemlist { get; private set; }
         

        static Byte[] pKeyList = { 0, };
        public static npcCompleto check;
     

        public static T ReadFileStruct<T>(string Filename) where T : struct
        {
            return LoadFile<T>(FileToByteArray(Filename));
        }

        public static T LoadFile<T>(byte[] rawData) where T : struct
        {
            var pinnedRawData = GCHandle.Alloc(rawData, GCHandleType.Pinned);
            try
            {
                var pinnedRawDataPtr = pinnedRawData.AddrOfPinnedObject();
                return (T)Marshal.PtrToStructure(pinnedRawDataPtr, typeof(T));
            }
            finally
            {
                pinnedRawData.Free();
            }
        }
        public static byte[] FileToByteArray(string fileName)
        {
            byte[] fileData = null;

            using (FileStream fs = File.OpenRead(fileName))
            {
                using (BinaryReader binaryReader = new BinaryReader(fs))
                {
                    fileData = binaryReader.ReadBytes((int)fs.Length);
                }
            }

            //pKeyList = ReadKeyList();
            //Array.Resize(ref pKeyList, pKeyList.Length + 1);
            //for (int i = 0; i < fileData.Length; i++)
            //{
            //    fileData[i] ^= pKeyList[i & (pKeyList.Length - 1)];

            //}

            return fileData;
        }

        public static Byte[] ReadKeyList()
        {
 
            return null;
        }

      

        public static void ReadArquivo()
        {
            try
            {
 
                Npcs.Clear();

                byte[] data = File.ReadAllBytes("Mixlist.bin");


                //byte[] pKeyList = File.ReadAllBytes("Keys.bin");
                //Array.Resize(ref pKeyList, pKeyList.Length + 1);
                //for (int i = 0; i < data.Length; i++)
                //{
                //    data[i] ^= pKeyList[i & (pKeyList.Length - 1)];

                //}


                check = (npcCompleto)Marshal.PtrToStructure(Marshal.UnsafeAddrOfPinnedArrayElement(data, 0), typeof(npcCompleto));

                npcCompleto npcs = (npcCompleto)Marshal.PtrToStructure(Marshal.UnsafeAddrOfPinnedArrayElement(data, 0), typeof(npcCompleto));


   

                Npcs.Add(npcs);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        
            public static unsafe T ToStruct<T>(byte[] data) => ToStruct<T>(data, 0);
            public static unsafe T ToStruct<T>(byte[] data, int start)
            {
                fixed (byte* pBuffer = data)
                {
                    return (T)(Marshal.PtrToStructure(new IntPtr((void*)(&pBuffer[start])), typeof(T)));
                }
            }

            public static unsafe byte[] ToByteArray<T>(T str)
            {
                byte[] data = new byte[Marshal.SizeOf(str)];

                fixed (byte* buffer = data)
                {
                    Marshal.StructureToPtr(str, new IntPtr((void*)buffer), true);
                }

                return data;
            }

        // Carrega a ItemList.bin
        public static void LoadItemlist()
        {
 
        }


        public static void SaveArquivo(npcCompleto NPC)
        {
            try
            {
                byte[] arr = new byte[Marshal.SizeOf(NPC)];

                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(NPC));
                Marshal.StructureToPtr(NPC, ptr, false);
                Marshal.Copy(ptr, arr, 0, Marshal.SizeOf(NPC));
                Marshal.FreeHGlobal(ptr);


                //byte[] pKeyList = File.ReadAllBytes("./Keys.bin");
                //Array.Resize(ref pKeyList, pKeyList.Length + 1);
                //for (int i = 0; i < arr.Length; i++)
                //{
                //    arr[i] ^= pKeyList[i & (pKeyList.Length - 1)];

                //}


                File.WriteAllBytes("Mixlist.bin", arr);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
