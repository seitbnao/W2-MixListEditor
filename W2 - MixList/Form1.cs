using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace W2___MixList
{
    public partial class W2MixList : Form
    {
        public int IndexOfStruct = 0;
        public W2MixList()
        {
            InitializeComponent();
            Read.ReadArquivo();
        }

        public static IDictionary npcname = new Dictionary<string, string>();
        public static int g_pRestante = 100;
        public static int[]  Count = new int[100];
        private void Form1_Load(object sender, EventArgs e)
        {


            npcname.Add("68", "Enhre");
            npcname.Add("-1", "Nenhum");
            npcname.Add("0", "Skill Alquimia");
            npcname.Add("1", "Config. Soul");
 
            npcname.Add("54", "Compositor Anct");
            npcname.Add("56", "Combinação do Item_Arch");
            npcname.Add("55", "Ailyn");
            npcname.Add("67", "Alquimista Odin");
            npcname.Add("66", "Dedekinto");
          




            for (int i = 0; i < 100; i++)
            {
                if (Read.Npcs[0].npcs[i].face == -842150451)
                    Read.Npcs[0].npcs[i].face = -1;

                if (Read.Npcs[0].npcs[i].face >= 0)
                    g_pRestante--;




                if (Read.Npcs[0].npcs[i].Name == "����������������")
                {
                    Read.Npcs[0].npcs[i].Name = "NoName";
                }




                NPCList.Items.Add("Index(" + i + "): [" + Read.Npcs[0].npcs[i].face + "] - " + Read.Npcs[0].npcs[i].Name);

                

                // ITENS
                txtItemItens.Text = "0,0,0,0,0,0,0";
                IndexOfStruct = 0;
                reqID.Text = IndexOfStruct.ToString();
                txtStrdef.Text = "0";

                txtAmount.Text = "0";
                txtMin0.Text = "0";
                txtMax0.Text = "0";

                txtMin1.Text = "0";
                txtMax1.Text = "0";
                txtUnused.Text = "0";
                txtUnused2.Text = "0";
                txtMin2.Text = "0";
                txtMax2.Text = "0";

                txtUnk.Text = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 ";
                txtGold.Text = "0";
                txtItem.Text = "0,0,0,0,0,0,0";
                txtMapX.Text = "0";
                txtMapY.Text = "0";
                txtTipo.Text = "0x00";

                txtItem1.Text = "0 0";
                txtItem2.Text = "0 0";
                txtItem3.Text = "0 0";
                txtItem4.Text = "0 0";
                txtItem5.Text = "0 0";
                txtItem6.Text = "0 0";
                txtItem7.Text = "0 0";
                txtItem8.Text = "0 0";
                nameNPC.Text = "Nenhum";
            }

            for (int i = 0; i < 100; i++)
            {
                if (Read.Npcs[0].req[i].Item.sIndex < -2)
                {

                    Read.Npcs[0].req[i].Item.sIndex = -1;

                    // ITENS
                    txtItemItens.Text = "0,0,0,0,0,0,0";
                    IndexOfStruct = 0;
                    reqID.Text = IndexOfStruct.ToString();
                    txtStrdef.Text = "0";

                    txtAmount.Text = "0";
                    txtMin0.Text = "0";
                    txtMax0.Text = "0";

                    txtMin1.Text = "0";
                    txtMax1.Text = "0";
                    txtUnused.Text = "0";
                    txtUnused2.Text = "0";
                    txtMin2.Text = "0";
                    txtMax2.Text = "0";

                    txtUnk.Text = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 ";
                }

                RequestList.Items.Add("[" + i + "] " + " " + Read.Npcs[0].req[i].Item.sIndex.ToString());
            }
            textFace.Text = "0";


            restante.Text = ""+ g_pRestante + " / 100";
        }

        private void lbNpc_SelectedIndexChanged(object sender, EventArgs e) // Ler dados do arquivo
        {
            var index = NPCList.SelectedIndex;

            textFace.Text = Read.Npcs[0].npcs[index].face.ToString();


            txtGold.Text = Read.Npcs[0].npcs[index].Gold.ToString();
            txtItem.Text = Read.Npcs[0].npcs[index].ItemSlot.sIndex.ToString() + "," + Read.Npcs[0].npcs[index].ItemSlot.sEffect[0].cEfeito.ToString() + "," + Read.Npcs[0].npcs[index].ItemSlot.sEffect[0].cValue.ToString() + "," + Read.Npcs[0].npcs[index].ItemSlot.sEffect[1].cEfeito.ToString() + "," + Read.Npcs[0].npcs[index].ItemSlot.sEffect[1].cValue.ToString() + "," + Read.Npcs[0].npcs[index].ItemSlot.sEffect[2].cEfeito.ToString() + "," + Read.Npcs[0].npcs[index].ItemSlot.sEffect[2].cValue.ToString();
            txtMapX.Text = Read.Npcs[0].npcs[index].MapX.ToString();
            txtMapY.Text = Read.Npcs[0].npcs[index].MapY.ToString();
            txtTipo.Text = "0x"+Read.Npcs[0].npcs[index].Type.ToString("X");
          
            txtItem1.Text = Read.Npcs[0].npcs[index].Item[0].Req.ToString() + " " + Read.Npcs[0].npcs[index].Item[0].Value.ToString();
            txtItem2.Text = Read.Npcs[0].npcs[index].Item[1].Req.ToString() + " " + Read.Npcs[0].npcs[index].Item[1].Value.ToString();
            txtItem3.Text = Read.Npcs[0].npcs[index].Item[2].Req.ToString() + " " + Read.Npcs[0].npcs[index].Item[2].Value.ToString();
            txtItem4.Text = Read.Npcs[0].npcs[index].Item[3].Req.ToString() + " " + Read.Npcs[0].npcs[index].Item[3].Value.ToString();
            txtItem5.Text = Read.Npcs[0].npcs[index].Item[4].Req.ToString() + " " + Read.Npcs[0].npcs[index].Item[4].Value.ToString();
            txtItem6.Text = Read.Npcs[0].npcs[index].Item[5].Req.ToString() + " " + Read.Npcs[0].npcs[index].Item[5].Value.ToString();
            txtItem7.Text = Read.Npcs[0].npcs[index].Item[6].Req.ToString() + " " + Read.Npcs[0].npcs[index].Item[6].Value.ToString();
            txtItem8.Text = Read.Npcs[0].npcs[index].Item[7].Req.ToString() + " " + Read.Npcs[0].npcs[index].Item[7].Value.ToString();






            // ITENS
            txtItemItens.Text = "0,0,0,0,0,0,0";
            IndexOfStruct = 0;
            reqID.Text = IndexOfStruct.ToString();
            txtStrdef.Text = "0";

            txtAmount.Text = "0";
            txtMin0.Text = "0";
            txtMax0.Text = "0";

            txtMin1.Text = "0";
            txtMax1.Text = "0";
            txtUnused.Text = "0";
            txtUnused2.Text = "0";
            txtMin2.Text = "0";
            txtMax2.Text = "0";

             


            nameNPC.Text = Read.Npcs[0].npcs[index].Name;
            txtUnk.Text = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 ";
            if (Read.Npcs[0].npcs[index].face == -842150451 || Read.Npcs[0].npcs[index].face == -1)
            {
                txtGold.Text = "0";
                txtItem.Text = "0,0,0,0,0,0,0";
                txtMapX.Text = "0";
                txtMapY.Text = "0";
                txtTipo.Text = "0x00";

                txtItem1.Text = "0 0";
                txtItem2.Text = "0 0";
                txtItem3.Text = "0 0";
                txtItem4.Text = "0 0";
                txtItem5.Text = "0 0";
                txtItem6.Text = "0 0";
                txtItem7.Text = "0 0";
                txtItem8.Text = "0 0";

            }
           
        }

        private void button1_Click(object sender, EventArgs e) // Salvar dados e escrever arquivo
        {
            if (NPCList.SelectedIndex >= 0)
            {
                npcCompleto npc = Read.Npcs[0];
                 
                var index = NPCList.SelectedIndex;

                string[] split = txtItem.Text.Split(',');
                string[] split2 = txtItemItens.Text.Split(',');

                string[] split3 = txtItem1.Text.Split(' ');
                string[] split4 = txtItem2.Text.Split(' ');
                string[] split5 = txtItem3.Text.Split(' ');
                string[] split6 = txtItem4.Text.Split(' ');
                string[] split7 = txtItem5.Text.Split(' ');
                string[] split8 = txtItem6.Text.Split(' ');
                string[] split9 = txtItem7.Text.Split(' ');
                string[] split10 = txtItem8.Text.Split(' ');

                 

                npc.npcs[index].Name = nameNPC.Text;
                 


                npc.npcs[index].face = Convert.ToInt32(textFace.Text);
                npc.npcs[index].Gold = Convert.ToInt32(txtGold.Text);
                npc.npcs[index].MapX = Convert.ToInt32(txtMapX.Text);
                npc.npcs[index].MapY = Convert.ToInt32(txtMapY.Text);


                short intValue = Convert.ToInt16(txtTipo.Text, 16);
                npc.npcs[index].Type = intValue;

                npc.npcs[index].ItemSlot.sIndex = Convert.ToInt16(split[0]);
                npc.npcs[index].ItemSlot.sEffect[0].cEfeito = Convert.ToByte(split[1]);
                npc.npcs[index].ItemSlot.sEffect[0].cValue = Convert.ToByte(split[2]);
                npc.npcs[index].ItemSlot.sEffect[1].cEfeito = Convert.ToByte(split[3]);
                npc.npcs[index].ItemSlot.sEffect[1].cValue = Convert.ToByte(split[4]);
                npc.npcs[index].ItemSlot.sEffect[2].cEfeito = Convert.ToByte(split[5]);
                npc.npcs[index].ItemSlot.sEffect[2].cValue = Convert.ToByte(split[6]);


                npc.npcs[index].Item[0].Req = Convert.ToInt32(split3[0]);
                npc.npcs[index].Item[0].Value = Convert.ToInt32(split3[1]);

                npc.npcs[index].Item[1].Req = Convert.ToInt32(split4[0]);
                npc.npcs[index].Item[1].Value = Convert.ToInt32(split4[1]);

                npc.npcs[index].Item[2].Req = Convert.ToInt32(split5[0]);
                npc.npcs[index].Item[2].Value = Convert.ToInt32(split5[1]);

                npc.npcs[index].Item[3].Req = Convert.ToInt32(split6[0]);
                npc.npcs[index].Item[3].Value = Convert.ToInt32(split6[1]);

                npc.npcs[index].Item[4].Req = Convert.ToInt32(split7[0]);
                npc.npcs[index].Item[4].Value = Convert.ToInt32(split7[1]);

                npc.npcs[index].Item[5].Req = Convert.ToInt32(split8[0]);
                npc.npcs[index].Item[5].Value = Convert.ToInt32(split8[1]);

                npc.npcs[index].Item[6].Req = Convert.ToInt32(split9[0]);
                npc.npcs[index].Item[6].Value = Convert.ToInt32(split9[1]);

                npc.npcs[index].Item[7].Req = Convert.ToInt32(split10[0]);
                npc.npcs[index].Item[7].Value = Convert.ToInt32(split10[1]);
                

                //itens

                if (IndexOfStruct != 0 )
                {


                    npc.req[IndexOfStruct].Strdef = Convert.ToInt32(txtStrdef.Text);
                    npc.req[IndexOfStruct].Amount = Convert.ToInt32(txtAmount.Text);

                    string[] explode = txtItemItens.Text.Split(',');

            

                    npc.req[IndexOfStruct].Item.sIndex = Convert.ToInt16(explode[0]);
                    npc.req[IndexOfStruct].Item.sEffect[0].cEfeito = Convert.ToByte(explode[1]);
                    npc.req[IndexOfStruct].Item.sEffect[0].cValue = Convert.ToByte(explode[2]);
                    npc.req[IndexOfStruct].Item.sEffect[1].cEfeito = Convert.ToByte(explode[3]);
                    npc.req[IndexOfStruct].Item.sEffect[1].cValue = Convert.ToByte(explode[4]);
                    npc.req[IndexOfStruct].Item.sEffect[2].cEfeito = Convert.ToByte(explode[5]);
                    npc.req[IndexOfStruct].Item.sEffect[2].cValue = Convert.ToByte(explode[6]);

                    npc.req[IndexOfStruct].Mix[0].MinID = Convert.ToInt32(txtMin0.Text);
                    npc.req[IndexOfStruct].Mix[0].MaxID = Convert.ToInt32(txtMax0.Text);

                    npc.req[IndexOfStruct].Mix[1].MinID = Convert.ToInt32(txtMin1.Text);
                    npc.req[IndexOfStruct].Mix[1].MaxID = Convert.ToInt32(txtMax1.Text);

                    npc.req[IndexOfStruct].Mix[2].MinID = Convert.ToInt32(txtMin2.Text);
                    npc.req[IndexOfStruct].Mix[2].MaxID = Convert.ToInt32(txtMax2.Text);

                    npc.req[IndexOfStruct].Unused = Convert.ToInt32(txtUnused.Text);
                    npc.req[IndexOfStruct].Unused_02 = Convert.ToInt32(txtUnused2.Text);


                    string[] splitUnks = txtUnk.Text.Split(' ');
                    for (int i = 0; i < 16; i++)
                    {
                        npc.req[IndexOfStruct].Unknow[i] = Convert.ToByte(splitUnks[i]);
                    }

                }



               
                Read.SaveArquivo(npc);

                MessageBox.Show("Arquivo salvo com sucesso");
                Reload();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var index = NPCList.SelectedIndex;

            string[] split = txtItem.Text.Split(',');
            string[] split2 = txtItemItens.Text.Split(',');

            string[] split3 = txtItem1.Text.Split(' ');
            string[] split4 = txtItem2.Text.Split(' ');
            string[] split5 = txtItem3.Text.Split(' ');
            string[] split6 = txtItem4.Text.Split(' ');
            string[] split7 = txtItem5.Text.Split(' ');
            string[] split8 = txtItem6.Text.Split(' ');
            string[] split9 = txtItem7.Text.Split(' ');
            string[] split10 = txtItem8.Text.Split(' ');
            npcCompleto npc = Read.Npcs[0];
            if (Read.Npcs[0].npcs[index].Item[0].Req > 0 && Read.Npcs[0].npcs[index].Item[0].Req < 100)
            {
                var RequestStruct = Read.Npcs[0].npcs[index].Item[0].Req;
                IndexOfStruct = RequestStruct;
                reqID.Text = RequestStruct.ToString();
                // ITENS
                txtItemItens.Text = Read.Npcs[0].req[RequestStruct].Item.sIndex.ToString() + "," + Read.Npcs[0].req[RequestStruct].Item.sEffect[0].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[0].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cValue.ToString();

                txtStrdef.Text = Read.Npcs[0].req[RequestStruct].Strdef.ToString();

                txtAmount.Text = Read.Npcs[0].req[RequestStruct].Amount.ToString();


                txtMin0.Text = npc.req[IndexOfStruct].Mix[0].MinID.ToString();
                txtMax0.Text = npc.req[IndexOfStruct].Mix[0].MaxID.ToString();

                txtMin1.Text = npc.req[IndexOfStruct].Mix[1].MinID.ToString();
                txtMax1.Text = npc.req[IndexOfStruct].Mix[1].MaxID.ToString();

                txtUnk.Text = String.Empty;
                for (int i = 0; i < 16; i++)
                {
                    txtUnk.Text += npc.req[IndexOfStruct].Unknow[i] + " ";
                }

                txtMin2.Text = npc.req[IndexOfStruct].Mix[2].MinID.ToString();
                txtMax2.Text = npc.req[IndexOfStruct].Mix[2].MaxID.ToString();
                txtUnused.Text = npc.req[IndexOfStruct].Unused.ToString();
                txtUnused2.Text = npc.req[IndexOfStruct].Unused_02.ToString();
            }
        }

        private void txtItemItens_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                var index = NPCList.SelectedIndex;

                string[] split = txtItem.Text.Split(',');
                string[] split2 = txtItemItens.Text.Split(',');

                string[] split3 = txtItem1.Text.Split(' ');
                string[] split4 = txtItem2.Text.Split(' ');
                string[] split5 = txtItem3.Text.Split(' ');
                string[] split6 = txtItem4.Text.Split(' ');
                string[] split7 = txtItem5.Text.Split(' ');
                string[] split8 = txtItem6.Text.Split(' ');
                string[] split9 = txtItem7.Text.Split(' ');
                string[] split10 = txtItem8.Text.Split(' ');
                npcCompleto npc = Read.Npcs[0];
                if (Read.Npcs[0].npcs[index].Item[1].Req > 0 && Read.Npcs[0].npcs[index].Item[1].Req < 100)
                {
                    var RequestStruct = Read.Npcs[0].npcs[index].Item[1].Req; IndexOfStruct = RequestStruct; reqID.Text = RequestStruct.ToString();
                    // ITENS
                    txtItemItens.Text = Read.Npcs[0].req[RequestStruct].Item.sIndex.ToString() + "," + Read.Npcs[0].req[RequestStruct].Item.sEffect[0].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[0].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cValue.ToString();

                    txtStrdef.Text = Read.Npcs[0].req[RequestStruct].Strdef.ToString();

                    txtAmount.Text = Read.Npcs[0].req[RequestStruct].Amount.ToString();
                    txtMin0.Text = npc.req[IndexOfStruct].Mix[0].MinID.ToString();
                    txtMax0.Text = npc.req[IndexOfStruct].Mix[0].MaxID.ToString();

                    txtMin1.Text = npc.req[IndexOfStruct].Mix[1].MinID.ToString();
                    txtMax1.Text = npc.req[IndexOfStruct].Mix[1].MaxID.ToString();

                    txtMin2.Text = npc.req[IndexOfStruct].Mix[2].MinID.ToString();
                    txtMax2.Text = npc.req[IndexOfStruct].Mix[2].MaxID.ToString();
                    txtUnk.Text = String.Empty;
                    for (int i = 0; i < 16; i++)
                    {
                        txtUnk.Text += npc.req[IndexOfStruct].Unknow[i] + " ";
                    }
                    txtUnused.Text = npc.req[IndexOfStruct].Unused.ToString();
                    txtUnused2.Text = npc.req[IndexOfStruct].Unused_02.ToString();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                var index = NPCList.SelectedIndex;

                string[] split = txtItem.Text.Split(',');
                string[] split2 = txtItemItens.Text.Split(',');

                string[] split3 = txtItem1.Text.Split(' ');
                string[] split4 = txtItem2.Text.Split(' ');
                string[] split5 = txtItem3.Text.Split(' ');
                string[] split6 = txtItem4.Text.Split(' ');
                string[] split7 = txtItem5.Text.Split(' ');
                string[] split8 = txtItem6.Text.Split(' ');
                string[] split9 = txtItem7.Text.Split(' ');
                string[] split10 = txtItem8.Text.Split(' ');
                npcCompleto npc = Read.Npcs[0];
                if (Read.Npcs[0].npcs[index].Item[2].Req > 0 && Read.Npcs[0].npcs[index].Item[2].Req < 100)
                {
                    var RequestStruct = Read.Npcs[0].npcs[index].Item[2].Req;

                    IndexOfStruct = RequestStruct; reqID.Text = RequestStruct.ToString();
                    // ITENS
                    txtItemItens.Text = Read.Npcs[0].req[RequestStruct].Item.sIndex.ToString() + "," + Read.Npcs[0].req[RequestStruct].Item.sEffect[0].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[0].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cValue.ToString();

                    txtStrdef.Text = Read.Npcs[0].req[RequestStruct].Strdef.ToString();

                    txtAmount.Text = Read.Npcs[0].req[RequestStruct].Amount.ToString();
                    txtMin0.Text = npc.req[IndexOfStruct].Mix[0].MinID.ToString();
                    txtMax0.Text = npc.req[IndexOfStruct].Mix[0].MaxID.ToString();

                    txtUnk.Text = String.Empty;
                    for (int i = 0; i < 16; i++)
                    {
                        txtUnk.Text += npc.req[IndexOfStruct].Unknow[i] + " ";
                    }

                    txtMin1.Text = npc.req[IndexOfStruct].Mix[1].MinID.ToString();
                    txtMax1.Text = npc.req[IndexOfStruct].Mix[1].MaxID.ToString();

                    txtUnused.Text = npc.req[IndexOfStruct].Unused.ToString();
                    txtUnused2.Text = npc.req[IndexOfStruct].Unused_02.ToString();

                    txtMin2.Text = npc.req[IndexOfStruct].Mix[2].MinID.ToString();
                    txtMax2.Text = npc.req[IndexOfStruct].Mix[2].MaxID.ToString();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                var index = NPCList.SelectedIndex;

                string[] split = txtItem.Text.Split(',');
                string[] split2 = txtItemItens.Text.Split(',');

                string[] split3 = txtItem1.Text.Split(' ');
                string[] split4 = txtItem2.Text.Split(' ');
                string[] split5 = txtItem3.Text.Split(' ');
                string[] split6 = txtItem4.Text.Split(' ');
                string[] split7 = txtItem5.Text.Split(' ');
                string[] split8 = txtItem6.Text.Split(' ');
                string[] split9 = txtItem7.Text.Split(' ');
                string[] split10 = txtItem8.Text.Split(' ');
                npcCompleto npc = Read.Npcs[0];
                if (Read.Npcs[0].npcs[index].Item[3].Req > 0 && Read.Npcs[0].npcs[index].Item[3].Req < 100)
                {
                    var RequestStruct = Read.Npcs[0].npcs[index].Item[3].Req; IndexOfStruct = RequestStruct; reqID.Text = RequestStruct.ToString();
                    // ITENS
                    txtItemItens.Text = Read.Npcs[0].req[RequestStruct].Item.sIndex.ToString() + "," + Read.Npcs[0].req[RequestStruct].Item.sEffect[0].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[0].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cValue.ToString();

                    txtStrdef.Text = Read.Npcs[0].req[RequestStruct].Strdef.ToString();

                    txtAmount.Text = Read.Npcs[0].req[RequestStruct].Amount.ToString();
                    txtMin0.Text = npc.req[IndexOfStruct].Mix[0].MinID.ToString();
                    txtMax0.Text = npc.req[IndexOfStruct].Mix[0].MaxID.ToString();
                    txtUnk.Text = String.Empty;
                    for (int i = 0; i < 16; i++)
                    {
                        txtUnk.Text += npc.req[IndexOfStruct].Unknow[i] + " ";
                    }
                    txtMin1.Text = npc.req[IndexOfStruct].Mix[1].MinID.ToString();
                    txtMax1.Text = npc.req[IndexOfStruct].Mix[1].MaxID.ToString();
                    txtUnused.Text = npc.req[IndexOfStruct].Unused.ToString();
                    txtUnused2.Text = npc.req[IndexOfStruct].Unused_02.ToString();
                    txtMin2.Text = npc.req[IndexOfStruct].Mix[2].MinID.ToString();
                    txtMax2.Text = npc.req[IndexOfStruct].Mix[2].MaxID.ToString();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            {
                var index = NPCList.SelectedIndex;

                string[] split = txtItem.Text.Split(',');
                string[] split2 = txtItemItens.Text.Split(',');

                string[] split3 = txtItem1.Text.Split(' ');
                string[] split4 = txtItem2.Text.Split(' ');
                string[] split5 = txtItem3.Text.Split(' ');
                string[] split6 = txtItem4.Text.Split(' ');
                string[] split7 = txtItem5.Text.Split(' ');
                string[] split8 = txtItem6.Text.Split(' ');
                string[] split9 = txtItem7.Text.Split(' ');
                string[] split10 = txtItem8.Text.Split(' ');
                npcCompleto npc = Read.Npcs[0];
                if (Read.Npcs[0].npcs[index].Item[4].Req > 0 && Read.Npcs[0].npcs[index].Item[4].Req < 100)
                {
                    var RequestStruct = Read.Npcs[0].npcs[index].Item[4].Req; IndexOfStruct = RequestStruct; reqID.Text = RequestStruct.ToString();
                    // ITENS
                    txtItemItens.Text = Read.Npcs[0].req[RequestStruct].Item.sIndex.ToString() + "," + Read.Npcs[0].req[RequestStruct].Item.sEffect[0].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[0].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cValue.ToString();

                    txtStrdef.Text = Read.Npcs[0].req[RequestStruct].Strdef.ToString();

                    txtAmount.Text = Read.Npcs[0].req[RequestStruct].Amount.ToString();
                    txtMin0.Text = npc.req[IndexOfStruct].Mix[0].MinID.ToString();
                    txtMax0.Text = npc.req[IndexOfStruct].Mix[0].MaxID.ToString();
                    txtUnk.Text = String.Empty;
                    for (int i = 0; i < 16; i++)
                    {
                        txtUnk.Text += npc.req[IndexOfStruct].Unknow[i] + " ";
                    }
                    txtMin1.Text = npc.req[IndexOfStruct].Mix[1].MinID.ToString();
                    txtMax1.Text = npc.req[IndexOfStruct].Mix[1].MaxID.ToString();
                    txtUnused.Text = npc.req[IndexOfStruct].Unused.ToString();
                    txtUnused2.Text = npc.req[IndexOfStruct].Unused_02.ToString();
                    txtMin2.Text = npc.req[IndexOfStruct].Mix[2].MinID.ToString();
                    txtMax2.Text = npc.req[IndexOfStruct].Mix[2].MaxID.ToString();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            {
                var index = NPCList.SelectedIndex;

                string[] split = txtItem.Text.Split(',');
                string[] split2 = txtItemItens.Text.Split(',');

                string[] split3 = txtItem1.Text.Split(' ');
                string[] split4 = txtItem2.Text.Split(' ');
                string[] split5 = txtItem3.Text.Split(' ');
                string[] split6 = txtItem4.Text.Split(' ');
                string[] split7 = txtItem5.Text.Split(' ');
                string[] split8 = txtItem6.Text.Split(' ');
                string[] split9 = txtItem7.Text.Split(' ');
                string[] split10 = txtItem8.Text.Split(' ');
                npcCompleto npc = Read.Npcs[0];
                if (Read.Npcs[0].npcs[index].Item[5].Req > 0 && Read.Npcs[0].npcs[index].Item[5].Req < 100)
                {
                    var RequestStruct = Read.Npcs[0].npcs[index].Item[5].Req; IndexOfStruct = RequestStruct; reqID.Text = RequestStruct.ToString();
                    // ITENS
                    txtItemItens.Text = Read.Npcs[0].req[RequestStruct].Item.sIndex.ToString() + "," + Read.Npcs[0].req[RequestStruct].Item.sEffect[0].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[0].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cValue.ToString();

                    txtStrdef.Text = Read.Npcs[0].req[RequestStruct].Strdef.ToString();

                    txtAmount.Text = Read.Npcs[0].req[RequestStruct].Amount.ToString();
                    txtMin0.Text = npc.req[IndexOfStruct].Mix[0].MinID.ToString();
                    txtMax0.Text = npc.req[IndexOfStruct].Mix[0].MaxID.ToString();
                    txtUnk.Text = String.Empty;
                    for (int i = 0; i < 16; i++)
                    {
                        txtUnk.Text += npc.req[IndexOfStruct].Unknow[i] + " ";
                    }
                    txtMin1.Text = npc.req[IndexOfStruct].Mix[1].MinID.ToString();
                    txtMax1.Text = npc.req[IndexOfStruct].Mix[1].MaxID.ToString();
                    txtUnused.Text = npc.req[IndexOfStruct].Unused.ToString();
                    txtUnused2.Text = npc.req[IndexOfStruct].Unused_02.ToString();
                    txtMin2.Text = npc.req[IndexOfStruct].Mix[2].MinID.ToString();
                    txtMax2.Text = npc.req[IndexOfStruct].Mix[2].MaxID.ToString();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            {
                var index = NPCList.SelectedIndex;

                string[] split = txtItem.Text.Split(',');
                string[] split2 = txtItemItens.Text.Split(',');

                string[] split3 = txtItem1.Text.Split(' ');
                string[] split4 = txtItem2.Text.Split(' ');
                string[] split5 = txtItem3.Text.Split(' ');
                string[] split6 = txtItem4.Text.Split(' ');
                string[] split7 = txtItem5.Text.Split(' ');
                string[] split8 = txtItem6.Text.Split(' ');
                string[] split9 = txtItem7.Text.Split(' ');
                string[] split10 = txtItem8.Text.Split(' ');
                npcCompleto npc = Read.Npcs[0];
                if (Read.Npcs[0].npcs[index].Item[6].Req > 0 && Read.Npcs[0].npcs[index].Item[6].Req < 100)
                {
                    var RequestStruct = Read.Npcs[0].npcs[index].Item[6].Req; IndexOfStruct = RequestStruct;
                    reqID.Text = RequestStruct.ToString();
                    // ITENS
                    txtItemItens.Text = Read.Npcs[0].req[RequestStruct].Item.sIndex.ToString() + "," + Read.Npcs[0].req[RequestStruct].Item.sEffect[0].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[0].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cValue.ToString();

                    txtStrdef.Text = Read.Npcs[0].req[RequestStruct].Strdef.ToString();

                    txtAmount.Text = Read.Npcs[0].req[RequestStruct].Amount.ToString();
                    txtMin0.Text = npc.req[IndexOfStruct].Mix[0].MinID.ToString();
                    txtMax0.Text = npc.req[IndexOfStruct].Mix[0].MaxID.ToString();
                    txtUnk.Text = String.Empty;
                    for (int i = 0; i < 16; i++)
                    {
                        txtUnk.Text += npc.req[IndexOfStruct].Unknow[i] + " ";
                    }
                    txtMin1.Text = npc.req[IndexOfStruct].Mix[1].MinID.ToString();
                    txtMax1.Text = npc.req[IndexOfStruct].Mix[1].MaxID.ToString();
                    txtUnused.Text = npc.req[IndexOfStruct].Unused.ToString();
                    txtUnused2.Text = npc.req[IndexOfStruct].Unused_02.ToString();
                    txtMin2.Text = npc.req[IndexOfStruct].Mix[2].MinID.ToString();
                    txtMax2.Text = npc.req[IndexOfStruct].Mix[2].MaxID.ToString();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            {
                var index = NPCList.SelectedIndex;

                string[] split = txtItem.Text.Split(',');
                string[] split2 = txtItemItens.Text.Split(',');

                string[] split3 = txtItem1.Text.Split(' ');
                string[] split4 = txtItem2.Text.Split(' ');
                string[] split5 = txtItem3.Text.Split(' ');
                string[] split6 = txtItem4.Text.Split(' ');
                string[] split7 = txtItem5.Text.Split(' ');
                string[] split8 = txtItem6.Text.Split(' ');
                string[] split9 = txtItem7.Text.Split(' ');
                string[] split10 = txtItem8.Text.Split(' ');
                npcCompleto npc = Read.Npcs[0];
                if (Read.Npcs[0].npcs[index].Item[7].Req > 0 && Read.Npcs[0].npcs[index].Item[7].Req < 100)
                {
                    var RequestStruct = Read.Npcs[0].npcs[index].Item[7].Req; IndexOfStruct = RequestStruct; reqID.Text = RequestStruct.ToString();
                    // ITENS
                    txtItemItens.Text = Read.Npcs[0].req[RequestStruct].Item.sIndex.ToString() + "," + Read.Npcs[0].req[RequestStruct].Item.sEffect[0].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[0].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cValue.ToString();

                    txtStrdef.Text = Read.Npcs[0].req[RequestStruct].Strdef.ToString();

                    txtAmount.Text = Read.Npcs[0].req[RequestStruct].Amount.ToString();
                    txtMin0.Text = npc.req[IndexOfStruct].Mix[0].MinID.ToString();
                    txtMax0.Text = npc.req[IndexOfStruct].Mix[0].MaxID.ToString();

                    txtMin1.Text = npc.req[IndexOfStruct].Mix[1].MinID.ToString();
                    txtMax1.Text = npc.req[IndexOfStruct].Mix[1].MaxID.ToString();
                    txtUnused.Text = npc.req[IndexOfStruct].Unused.ToString();
                    txtUnused2.Text = npc.req[IndexOfStruct].Unused_02.ToString();
                    txtMin2.Text = npc.req[IndexOfStruct].Mix[2].MinID.ToString();
                    txtMax2.Text = npc.req[IndexOfStruct].Mix[2].MaxID.ToString();

                    txtUnk.Text = String.Empty;
                    for (int i = 0; i < 16; i++)
                    {
                        txtUnk.Text += npc.req[IndexOfStruct].Unknow[i] + " ";
                    }
                }
            }
        }


        public void Reload()
        {
            g_pRestante = 100;
            // ITENS
            txtItemItens.Text = "0,0,0,0,0,0,0";
            IndexOfStruct = 0;
            reqID.Text = IndexOfStruct.ToString();
            txtStrdef.Text = "0";

            txtAmount.Text = "0";
            txtMin0.Text = "0";
            txtMax0.Text = "0";

            txtMin1.Text = "0";
            txtMax1.Text = "0";
            txtUnused.Text = "0";
            txtUnused2.Text = "0";
            txtMin2.Text = "0";
            txtMax2.Text = "0";

            txtUnk.Text = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 ";

            txtGold.Text = "0";
            txtItem.Text = "0,0,0,0,0,0,0";
            txtMapX.Text = "0";
            txtMapY.Text = "0";
            txtTipo.Text = "0x00";

            txtItem1.Text = "0 0";
            txtItem2.Text = "0 0";
            txtItem3.Text = "0 0";
            txtItem4.Text = "0 0";
            txtItem5.Text = "0 0";
            txtItem6.Text = "0 0";
            txtItem7.Text = "0 0";
            txtItem8.Text = "0 0";


            NPCList.Items.Clear();
            RequestList.Items.Clear();
            Read.Npcs.Clear();
            Read.ReadArquivo();
            for (int i = 0; i < 100; i++)
            {
                if (Read.Npcs[0].npcs[i].face == -842150451)
                {

                    Read.Npcs[0].npcs[i].face = -1;

                }
                if (Read.Npcs[0].npcs[i].face >= 0)
                {
                     
                    g_pRestante--;
                }

                if (Read.Npcs[0].npcs[i].Name == "����������������")
                {
                    Read.Npcs[0].npcs[i].Name = "NoName";
                }

                NPCList.Items.Add("Index(" + i + "): [" + Read.Npcs[0].npcs[i].face + "] - " + Read.Npcs[0].npcs[i].Name);
            }

            restante.Text = "" + g_pRestante + " / 100";

            for (int i = 0; i < 100; i++)
            {
                if (Read.Npcs[0].req[i].Item.sIndex < -2)
                {
                    Read.Npcs[0].req[i].Item.sIndex = -1;
                    // ITENS
                    txtItemItens.Text = "0,0,0,0,0,0,0";
                    IndexOfStruct = 0;
                    reqID.Text = IndexOfStruct.ToString();
                    txtStrdef.Text = "0";

                    txtAmount.Text = "0";
                    txtMin0.Text = "0";
                    txtMax0.Text = "0";

                    txtMin1.Text = "0";
                    txtMax1.Text = "0";
                    txtUnused.Text = "0";
                    txtUnused2.Text = "0";
                    txtMin2.Text = "0";
                    txtMax2.Text = "0";

                    txtUnk.Text = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 ";
                }

                RequestList.Items.Add("[" + i + "] " + " " + Read.Npcs[0].req[i].Item.sIndex.ToString());
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // ITENS
            txtItemItens.Text = "0,0,0,0,0,0,0";
            IndexOfStruct = 0;
            reqID.Text = IndexOfStruct.ToString();
            txtStrdef.Text = "0";

            txtAmount.Text = "0";
            txtMin0.Text = "0";
            txtMax0.Text = "0";

            txtMin1.Text = "0";
            txtMax1.Text = "0";
            txtUnused.Text = "0";
            txtUnused2.Text = "0";
            txtMin2.Text = "0";
            txtMax2.Text = "0";

            txtUnk.Text = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 ";
            txtGold.Text = "0";
            txtItem.Text = "0,0,0,0,0,0,0";
            txtMapX.Text = "0";
            txtMapY.Text = "0";
            txtTipo.Text = "0x00";

            txtItem1.Text = "0 0";
            txtItem2.Text = "0 0";
            txtItem3.Text = "0 0";
            txtItem4.Text = "0 0";
            txtItem5.Text = "0 0";
            txtItem6.Text = "0 0";
            txtItem7.Text = "0 0";
            txtItem8.Text = "0 0";
            nameNPC.Text = "Nenhum";
         
        }

        private void requestBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = RequestList.SelectedIndex;
            npcCompleto npc = Read.Npcs[0];
            
                

                // ITENS
                txtItemItens.Text = Read.Npcs[0].req[index].Item.sIndex.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[0].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[0].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[1].cValue.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cEfeito.ToString() + "," + Read.Npcs[0].req[index].Item.sEffect[2].cValue.ToString();

                txtStrdef.Text = Read.Npcs[0].req[index].Strdef.ToString();

                txtAmount.Text = Read.Npcs[0].req[index].Amount.ToString();


            for(int i = 0; i< 3;i++)
            {
                if (npc.req[index].Mix[i].MinID < 0)
                    npc.req[index].Mix[i].MinID = 0;
                if(npc.req[index].Mix[i].MaxID < 0)
                    npc.req[index].Mix[i].MaxID = 0;
            }
                txtMin0.Text = npc.req[index].Mix[0].MinID.ToString();
                txtMax0.Text = npc.req[index].Mix[0].MaxID.ToString();

                txtMin1.Text = npc.req[index].Mix[1].MinID.ToString();
                txtMax1.Text = npc.req[index].Mix[1].MaxID.ToString();

            if (npc.req[index].Unused < 0)
                npc.req[index].Unused = 0;
            if (npc.req[index].Unused_02 < 0)
                npc.req[index].Unused_02 = 0;

            txtUnused.Text = npc.req[index].Unused.ToString();
                txtUnused2.Text = npc.req[index].Unused_02.ToString();
                txtMin2.Text = npc.req[index].Mix[2].MinID.ToString();
                txtMax2.Text = npc.req[index].Mix[2].MaxID.ToString();

                txtUnk.Text = String.Empty;
                for (int i = 0; i < 16; i++)
                {
                if (npc.req[index].Unknow[i] == 205 || npc.req[index].Unknow[i] < 0)
                    npc.req[index].Unknow[i] = 0;
                    txtUnk.Text += npc.req[index].Unknow[i] + " ";
                }
                reqID.Text = index.ToString();

            if (Read.Npcs[0].req[index].Item.sIndex == -1 || Read.Npcs[0].req[index].Item.sIndex < 0)
            {
                Read.Npcs[0].req[index].Item.sIndex = -1;
                // ITENS
                txtItemItens.Text = "0,0,0,0,0,0,0";
                IndexOfStruct = index;
                reqID.Text = IndexOfStruct.ToString();
                txtStrdef.Text = "0";

                txtAmount.Text = "0";
                txtMin0.Text = "0";
                txtMax0.Text = "0";

                txtMin1.Text = "0";
                txtMax1.Text = "0";
                txtUnused.Text = "0";
                txtUnused2.Text = "0";
                txtMin2.Text = "0";
                txtMax2.Text = "0";

                txtUnk.Text = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 ";
            }

            IndexOfStruct = index;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //itens
            var index = RequestList.SelectedIndex;
            npcCompleto npc = Read.Npcs[0];
            if (index != -1)
            {
                npc.req[index].Strdef = Convert.ToInt32(txtStrdef.Text);
                npc.req[index].Amount = Convert.ToInt32(txtAmount.Text);

                string[] explode = txtItemItens.Text.Split(',');



                npc.req[index].Item.sIndex = Convert.ToInt16(explode[0]);
                npc.req[index].Item.sEffect[0].cEfeito = Convert.ToByte(explode[1]);
                npc.req[index].Item.sEffect[0].cValue = Convert.ToByte(explode[2]);
                npc.req[index].Item.sEffect[1].cEfeito = Convert.ToByte(explode[3]);
                npc.req[index].Item.sEffect[1].cValue = Convert.ToByte(explode[4]);
                npc.req[index].Item.sEffect[2].cEfeito = Convert.ToByte(explode[5]);
                npc.req[index].Item.sEffect[2].cValue = Convert.ToByte(explode[6]);

                npc.req[index].Mix[0].MinID = Convert.ToInt32(txtMin0.Text);
                npc.req[index].Mix[0].MaxID = Convert.ToInt32(txtMax0.Text);

                npc.req[index].Mix[1].MinID = Convert.ToInt32(txtMin1.Text);
                npc.req[index].Mix[1].MaxID = Convert.ToInt32(txtMax1.Text);

                npc.req[index].Mix[2].MinID = Convert.ToInt32(txtMin2.Text);
                npc.req[index].Mix[2].MaxID = Convert.ToInt32(txtMax2.Text);

                npc.req[index].Unused = Convert.ToInt32(txtUnused.Text);
                npc.req[index].Unused_02 = Convert.ToInt32(txtUnused2.Text);


                string[] splitUnks = txtUnk.Text.Split(' ');
                for (int i = 0; i < 16; i++)
                {
                    npc.req[index].Unknow[i] = Convert.ToByte(splitUnks[i]);
                }

            }




            Read.SaveArquivo(npc);

            MessageBox.Show("Arquivo salvo com sucesso");
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // ITENS
            txtItemItens.Text = "0,0,0,0,0,0,0";
            IndexOfStruct = 0;
            reqID.Text = IndexOfStruct.ToString();
            txtStrdef.Text = "0";

            txtAmount.Text = "0";
            txtMin0.Text = "0";
            txtMax0.Text = "0";

            txtMin1.Text = "0";
            txtMax1.Text = "0";
            txtUnused.Text = "0";
            txtUnused2.Text = "0";
            txtMin2.Text = "0";
            txtMax2.Text = "0";

            txtUnk.Text = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 ";

            //itens
            var index = RequestList.SelectedIndex;
            npcCompleto npc = Read.Npcs[0];
            if (index != -1)
            {
                npc.req[index].Strdef = Convert.ToInt32(txtStrdef.Text);
                npc.req[index].Amount = Convert.ToInt32(txtAmount.Text);

                string[] explode = txtItemItens.Text.Split(',');



                npc.req[index].Item.sIndex = Convert.ToInt16(explode[0]);
                npc.req[index].Item.sEffect[0].cEfeito = Convert.ToByte(explode[1]);
                npc.req[index].Item.sEffect[0].cValue = Convert.ToByte(explode[2]);
                npc.req[index].Item.sEffect[1].cEfeito = Convert.ToByte(explode[3]);
                npc.req[index].Item.sEffect[1].cValue = Convert.ToByte(explode[4]);
                npc.req[index].Item.sEffect[2].cEfeito = Convert.ToByte(explode[5]);
                npc.req[index].Item.sEffect[2].cValue = Convert.ToByte(explode[6]);

                npc.req[index].Mix[0].MinID = Convert.ToInt32(txtMin0.Text);
                npc.req[index].Mix[0].MaxID = Convert.ToInt32(txtMax0.Text);

                npc.req[index].Mix[1].MinID = Convert.ToInt32(txtMin1.Text);
                npc.req[index].Mix[1].MaxID = Convert.ToInt32(txtMax1.Text);

                npc.req[index].Mix[2].MinID = Convert.ToInt32(txtMin2.Text);
                npc.req[index].Mix[2].MaxID = Convert.ToInt32(txtMax2.Text);

                npc.req[index].Unused = Convert.ToInt32(txtUnused.Text);
                npc.req[index].Unused_02 = Convert.ToInt32(txtUnused2.Text);


                string[] splitUnks = txtUnk.Text.Split(' ');
                for (int i = 0; i < 16; i++)
                {
                    npc.req[index].Unknow[i] = Convert.ToByte(splitUnks[i]);
                }

            }

            RequestList.Items.Clear();
            for (int i = 0; i < 100; i++)
            {
                if (Read.Npcs[0].req[i].Item.sIndex < -2)
                {

                    Read.Npcs[0].req[i].Item.sIndex = -1;

                    // ITENS
                    txtItemItens.Text = "0,0,0,0,0,0,0";
                    IndexOfStruct = 0;
                    reqID.Text = IndexOfStruct.ToString();
                    txtStrdef.Text = "0";

                    txtAmount.Text = "0";
                    txtMin0.Text = "0";
                    txtMax0.Text = "0";

                    txtMin1.Text = "0";
                    txtMax1.Text = "0";
                    txtUnused.Text = "0";
                    txtUnused2.Text = "0";
                    txtMin2.Text = "0";
                    txtMax2.Text = "0";

                    txtUnk.Text = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 ";
                }

                RequestList.Items.Add("[" + i + "] " + " " + Read.Npcs[0].req[i].Item.sIndex.ToString());
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
